using MAUAPI.Core.IRepositories;
using MAUAPI.Core.Repositories;
using MAUAPI.IConfiguration;

namespace MAUAPI.Data
{
    public class UnitOfwork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public IUserAccountRepository UserAccount { get; private set; }

        public IUserProductsRepository UserProducts { get; private set; }


        public IUserOrdersRepository UserOrders { get; private set; }


        public UnitOfwork(ApplicationDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            UserAccount = new UserAccountsRepository(_context, _logger);
            UserProducts = new UserProductsRepository(_context, _logger);
            UserOrders = new UserOrdersRepository(_context, _logger);   
        }

       
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
