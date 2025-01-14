namespace EmployeeManagementSystem.Utilities
{
    public class ResponseResult
    {
        public bool Status { get; private set; }
        public string Message { get; private set; }
        public object? Data { get; private set; }

        private ResponseResult(bool status, string message, object? data = null)
        {
            Status = status;
            Message = message;
            Data = data;
        }

        public static ResponseResult Success(string message, object? data = null)
        {
            return new ResponseResult(true, message, data);
        }

        public static ResponseResult Failure(string message, object? data = null)
        {
            return new ResponseResult(false, message, data);
        }

        public static ResponseResult NotFound(string message)
        {
            return new ResponseResult(false, message);
        }

        public static ResponseResult BadRequest(string message)
        {
            return new ResponseResult(false, message);
        }

        public static ResponseResult InternalError(string message)
        {
            return new ResponseResult(false, message);
        }
    }
}
