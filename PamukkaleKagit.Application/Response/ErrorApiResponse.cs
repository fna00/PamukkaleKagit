namespace PamukkaleKagit.Application.Responses
{
    public class ErrorApiResponse<T> : ApiResponse<T>
    {
        public ErrorApiResponse(string message = "Operation failed")
            : base(default, message, false)
        {
        }
    }

    public class ErrorApiResponse : ApiResponse
    {
        public ErrorApiResponse(string message = "Operation failed")
            : base(message, false)
        {
        }
    }
}
