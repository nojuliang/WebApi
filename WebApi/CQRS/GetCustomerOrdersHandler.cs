using WebApi.Interface;
using WebApi.Models;

namespace WebApi.CQRS
{
    public class GetCustomerOrdersHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCustomerOrdersHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Order>> Handle(GetCustomerOrdersQuery query)
        {
            var orders = await _unitOfWork.Orders.GetAllAsync();
            return orders.Where(o => o.CustomerId == query.CustomerId
                && (query.FromDate == null || o.OrderDate >= query.FromDate)
                && (query.ToDate == null || o.OrderDate <= query.ToDate))
                .OrderBy(o => o.OrderDate);
        }
    }
}
