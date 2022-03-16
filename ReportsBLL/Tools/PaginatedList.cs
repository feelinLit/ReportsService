using Microsoft.EntityFrameworkCore;

namespace ReportsBLL.Tools;

public class PaginatedList<T> : List<T>
{
    public int PageIndex { get; private set; }
    public int TotalPages { get; private set; }

    public PaginatedList(List<T> source, int pageIndex, int pageSize)
    {
        PageIndex = pageIndex;
        TotalPages = (int)Math.Ceiling(source.Count / (double)pageSize);

        var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

        this.AddRange(items);
    }

    public bool HasPreviousPage => PageIndex > 1;

    public bool HasNextPage => PageIndex < TotalPages;
}