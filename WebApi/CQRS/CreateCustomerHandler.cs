using WebApi.Interface;
using WebApi.Models;

namespace WebApi.CQRS
{
    public class CreateCustomerHandler
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateCustomerCommand command)
        {
            var customer = new Customer
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                Address = command.Address,
                PostalCode = command.PostalCode
            };

            await _unitOfWork.Customers.AddAsync(customer);
            await _unitOfWork.CompleteAsync();
        }
    }
}
