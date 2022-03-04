namespace ReportsBLL.Tools;

public class ReportsServiceException : Exception
{
    public ReportsServiceException()
    {
    }

    public ReportsServiceException(string? message)
        : base(message)
    {
    }

    public ReportsServiceException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}