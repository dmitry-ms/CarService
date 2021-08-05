namespace CarService.Web.Models
{
    public class PaginationPageViewModel
    {
        public int PageNumber { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage{ get; set; }
        public bool HasNextPage { get; set; }
    }
}
