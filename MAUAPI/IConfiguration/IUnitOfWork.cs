using MAUAPI.Core.IRepositories;

namespace MAUAPI.IConfiguration
{
    public interface IUnitOfWork
    {
        IUserAccountRepository UserAccount { get; }

        IUserProductsRepository UserProducts { get; }

        IUserOrdersRepository UserOrders { get; }

        Task CompleteAsync();
    }
}
