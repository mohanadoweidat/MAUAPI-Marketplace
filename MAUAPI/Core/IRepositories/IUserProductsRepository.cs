using MAUAPI.Models;

namespace MAUAPI.Core.IRepositories
{
    public interface IUserProductsRepository : IGenericRepository<UserProducts>
    {
        Task<IEnumerable<UserProducts>> GetProductsByOwner(UserProducts entity);

        Task<IEnumerable<UserProducts>> GetProductsBySearchInput(UserProducts entity);

        Task<bool> ChangeProductStatus(List<UserProducts> products);

        Task<List<UserProducts>> LoadSomeProducts();





    }
}
