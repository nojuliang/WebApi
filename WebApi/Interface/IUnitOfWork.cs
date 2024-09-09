using WebApi.Models;

namespace WebApi.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Customer> Customers { get; }
        IRepository<Order> Orders { get; }
        IRepository<OrderItem> OrderItems { get; }
        IRepository<Product> Products { get; }
        Task<int> CompleteAsync();
    }
}
