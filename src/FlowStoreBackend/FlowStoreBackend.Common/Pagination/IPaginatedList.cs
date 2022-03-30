namespace FlowStoreBackend.Common.Pagination
{
    public interface IPaginatedList<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public bool HasPreviousPage { get; }
        public bool HasNextPage { get; }
        public IList<T> Data { get; set; }

    }
}
