using ReportsBLL.Interfaces;

namespace ReportsBLL.Services.Communication;

public class Response<T> where T : class, IViewModel
{
    private readonly IList<T>? _dataTransferObjects;

    public Response(string errorMessage)
    {
        ErrorMessage = errorMessage;
        Success = false;
    }

    public Response(IList<T> dataTransferObjects)
    {
        _dataTransferObjects = dataTransferObjects;
        Success = true;
    }
    
    public Response(T dataTransferObject)
    {
        _dataTransferObjects = new List<T>(1) { dataTransferObject };
        Success = true;
    }

    public bool Success { get; protected set; }
    public string ErrorMessage { get; protected set; } = string.Empty;
    public IEnumerable<T>? DataTransferObjects => _dataTransferObjects;
    public T? DataTransferObject => _dataTransferObjects?[0];
}