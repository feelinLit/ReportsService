namespace Reports.API.Tools;

public class PaginatedList<T> : List<T>
{
    public int PageIndex { get; private set; }
    public int TotalPages { get; private set; }

    public PaginatedList(IReadOnlyCollection<T> source, int pageIndex, int pageSize)
    {
        PageIndex = pageIndex;
        TotalPages = (int)Math.Ceiling(source.Count / (double)pageSize);

        var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

        AddRange(items);
    }

    public bool HasPreviousPage => PageIndex > 1;

    public bool HasNextPage => PageIndex < TotalPages;
}