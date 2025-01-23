using EmployeeManagementSystem.Models;
using EmployeeManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollController : ControllerBase
    {
        private readonly IPayrollService _payrollService;

        public PayrollController(IPayrollService payrollService)
        {
            _payrollService = payrollService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payroll>>> GetAll()
        {
            return Ok(await _payrollService.GetAllPayrollsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Payroll>> GetById(int id)
        {
            var payroll = await _payrollService.GetPayrollByIdAsync(id);
            if (payroll == null) return NotFound();
            return Ok(payroll);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Payroll payroll)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _payrollService.AddPayrollAsync(payroll);
            return CreatedAtAction(nameof(GetById), new { id = payroll.Id }, payroll);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Payroll payroll)
        {
            if (id != payroll.Id) return BadRequest("Payroll ID mismatch.");

            var existingPayroll = await _payrollService.GetPayrollByIdAsync(id);
            if (existingPayroll == null) return NotFound();

            await _payrollService.UpdatePayrollAsync(payroll);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existingPayroll = await _payrollService.GetPayrollByIdAsync(id);
            if (existingPayroll == null) return NotFound();

            await _payrollService.DeletePayrollAsync(id);
            return NoContent();
        }
    }
}
