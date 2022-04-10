namespace Reports.Domain.Services.Communication;

public class Response<T>
{
    public Response(string errorMessage)
    {
        ErrorMessage = errorMessage;
        Success = false;
    }

    public Response(T resource)
    {
        Resource = resource;
        Success = true;
    }

    public bool Success { get; protected set; }
    public string ErrorMessage { get; protected set; } = string.Empty;
    public T Resource { get; set; }
}