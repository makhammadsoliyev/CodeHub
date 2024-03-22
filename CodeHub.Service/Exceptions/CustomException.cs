namespace CodeHub.Service.Exceptions;

public class CustomException : Exception
{
    public int StatusCode { get; set; }

    public CustomException(int statusCode, string message) : base(message)
    {
        this.StatusCode = statusCode;
    }
}
