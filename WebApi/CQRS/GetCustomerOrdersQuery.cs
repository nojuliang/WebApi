namespace WebApi.CQRS
{
    public class GetCustomerOrdersQuery
    {
        public int CustomerId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
