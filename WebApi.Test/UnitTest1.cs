using Moq;
using WebApi.CQRS;
using WebApi.Interface;
using WebApi.Models;

namespace WebApi.Test
{
    [TestFixture]
    public class CustomerTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private CreateCustomerHandler _handler;

        [SetUp]
        public void SetUp()
        {
            var customerRepositoryMock = new Mock<IRepository<Customer>>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _unitOfWorkMock.Setup(u => u.Customers).Returns(customerRepositoryMock.Object);
            _handler = new CreateCustomerHandler(_unitOfWorkMock.Object);
            
        }

        [Test]
        public async Task Should_Create_New_Customer()
        {
            var command = new CreateCustomerCommand
            {
                FirstName = "John",
                LastName = "Doe",
                Address = "123 Main St",
                PostalCode = "12345"
            };

            await _handler.Handle(command);

            _unitOfWorkMock.Verify(u => u.Customers.AddAsync(It.IsAny<Customer>()), Times.Once);
            _unitOfWorkMock.Verify(u => u.CompleteAsync(), Times.Once);
        }
    }
}