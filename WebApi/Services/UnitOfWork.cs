using WebApi.Database;
using WebApi.Interface;
using WebApi.Models;

namespace WebApi.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Customers = new Repository<Customer>(_context);
            Orders = new Repository<Order>(_context);
            OrderItems = new Repository<OrderItem>(_context);
            Products = new Repository<Product>(_context);
        }

        public IRepository<Customer> Customers { get; private set; }
        public IRepository<Order> Orders { get; private set; }
        public IRepository<OrderItem> OrderItems { get; private set; }
        public IRepository<Product> Products { get; private set; }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
