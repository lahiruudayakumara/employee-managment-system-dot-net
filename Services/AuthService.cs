using EmployeeManagementSystem.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Enums;
using EmployeeManagementSystem.Utilities;

namespace EmployeeManagementSystem.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

            Console.WriteLine($"Config JwtSettings:Secret: '{_configuration["JwtSettings:Secret"]}'");
        }

        public async Task<User> RegisterAsync(string fullName, string email, string password, string role)
        {
            if (await _context.Users.AnyAsync(u => u.Email == email))
                throw new InvalidOperationException("Email already exists");

            var user = new User
            {
                FullName = fullName,
                Email = email,
                PasswordHash = PasswordHasher.HashPassword(password),
                Role = Enum.Parse<UserRole>(role),
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<string> LoginAsync(string email, string password)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null || !PasswordVerifier.VerifyPassword(password, user.PasswordHash))
                throw new UnauthorizedAccessException("Invalid credentials");

            return GenerateJwtToken(user);
        }

        public async Task<User> GetCurrentUserAsync(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var keyString = _configuration["JwtSettings:Secret"] ?? "ThisIsASuperSecretKeyThatIsAtLeast32Chars!";
                Console.WriteLine($"GetCurrentUserAsync - Key: '{keyString}' (Length: {keyString.Length}, Bits: {keyString.Length * 8})");
                var key = Encoding.UTF8.GetBytes(keyString);

                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = _configuration["JwtSettings:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = _configuration["JwtSettings:Audience"],
                    ValidateLifetime = true
                }, out SecurityToken validatedToken);

                var userIdString = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (!int.TryParse(userIdString, out int userId))
                    throw new SecurityTokenException("Invalid user ID in token");

                var user = await _context.Users.FindAsync(userId);
                if (user == null)
                    throw new InvalidOperationException("User not found");

                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetCurrentUserAsync Error: {ex.Message}");
                throw new InvalidOperationException($"Failed to get current user: {ex.Message}");
            }
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            };

            var keyString = _configuration["JwtSettings:Secret"] ?? "ThisIsASuperSecretKeyThatIsAtLeast32Chars!";
            Console.WriteLine($"GenerateJwtToken - Key: '{keyString}' (Length: {keyString.Length}, Bits: {keyString.Length * 8})");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiryMinutes = int.TryParse(_configuration["JwtSettings:ExpiryMinutes"], out int minutes) ? minutes : 60;

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(expiryMinutes),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}