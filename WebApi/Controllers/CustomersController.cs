using Microsoft.AspNetCore.Mvc;
using WebApi.CQRS;
using WebApi.Interface;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerCommand command)
        {
            var handler = new CreateCustomerHandler(_unitOfWork);
            await handler.Handle(command);
            return Ok();
        }

        [HttpGet("{id}/orders")]
        public async Task<IActionResult> GetCustomerOrders(int id, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var handler = new GetCustomerOrdersHandler(_unitOfWork);
            var orders = await handler.Handle(new GetCustomerOrdersQuery { CustomerId = id, FromDate = fromDate, ToDate = toDate });
            return Ok(orders);
        }
    }
}
