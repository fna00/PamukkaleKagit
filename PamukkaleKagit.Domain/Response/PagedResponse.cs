using PamukkaleKagit.Domain.Responses; 

namespace PamukkaleKagit.Domain.Response.PaginatedList
{
    public class PagedResponse<T> : ApiResponse<IEnumerable<T>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }

        public PagedResponse(IEnumerable<T> data, int pageNumber, int pageSize, int totalRecords)
            : base(data, string.Empty, true)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalRecords = totalRecords;
            TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
        }

        //public PagedResponse(IEnumerable<T>? data, int pageNumber, int pageSize) : base(data, string.Empty, true)
        //{
        //    PageNumber = pageNumber;
        //    PageSize = pageSize;
        //    Data = data;
        //}
        //public static PagedResponse<T> EmptyPagedResponse() => new(default, 1, 10);
    }
}
