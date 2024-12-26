namespace PamukkaleKagit.Domain.Responses
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

        public ApiResponse(T data, string message, bool isSuccess)
        {
            Data = data;
            Message = message;
            IsSuccess = isSuccess;
        }
    }

    public class ApiResponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

        public ApiResponse( string message, bool isSuccess)
        {
            Message = message;
            IsSuccess = isSuccess;
        }
    }
}
