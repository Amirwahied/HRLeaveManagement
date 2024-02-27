namespace HRLeaveManagement.BlazorUI.Services.Base
{
    public class Response<T>
    {
        public string? Message { get; set; }
        public string? ValidationErrors { get; set; }
        public bool IsSuccess { get; set; }
        T? Data { get; set; }
    }
}
