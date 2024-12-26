namespace PamukkaleKagit.Domain.Responses
{
    public class SuccessApiResponse<T> : ApiResponse<T>
    {
        public SuccessApiResponse(T data, string message = "Operation successful")
            : base(data, message, true)
        {
        }
    }

    public class SuccessApiResponse : ApiResponse
    {
        public SuccessApiResponse(string message = "Operation successful")
            : base(message, true)
        {
        }
    }
}
