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
}