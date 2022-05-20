using MAUAPI.Core.IRepositories;
using MAUAPI.Data;
using MAUAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MAUAPI.Core.Repositories
{
    public class UserProductsRepository : GenericRepository<UserProducts>, IUserProductsRepository
    {
        public UserProductsRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
        }

        /******Functions from Generic Interface*****/
        

        //Get a list of products with productStatus == "Available".
        public override async Task<IEnumerable<UserProducts>> All()
        {
            try
            {
                return await dbSet.Where(x => x.productStatus == "Available").ToListAsync();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "{Repo} All method error", typeof(UserProductsRepository));
                return new List<UserProducts>();
            }
        }
        //Get a product by its id.
        public override async Task<UserProducts> GetById(Guid id)
        {
            try
            {
              return await dbSet.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
               _logger.LogError(ex, "{Repo} GetById method error", typeof(UserProductsRepository));
                return null;
            }
             
              
            
            
           
             
        }
        //Update product information by its id.
        public override async Task<bool> Update(UserProducts entity)
        {
            try
            {
                var existingProduct = await dbSet.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();
                if (existingProduct == null)
                    return await Add(entity);

                existingProduct.ProductName = entity.ProductName;
                existingProduct.ProductType = entity.ProductType;
                existingProduct.productPrice = entity.productPrice;
                existingProduct.ProductYearOfMake = entity.ProductYearOfMake;
                existingProduct.ProductColour = entity.ProductColour;
                existingProduct.ProductCondition = entity.ProductCondition;
                existingProduct.ProductOwner = entity.ProductOwner;
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update method error", typeof(UserProductsRepository));
                return false;
            }
        }
        //Delete a product by its id.
        public override async Task<bool> Delete(Guid id)
        {

            try
            {
                var exist = await dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (exist != null)
                {
                    dbSet.Remove(exist);
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete method error", typeof(UserProductsRepository));
                return false;
            }
        }


        /******Functions from IUserProductsRepository interface*****/
        
         //Get products information by its owner username.
        public async Task<IEnumerable<UserProducts>> GetProductsByOwner(UserProducts entity)
        {
            try
            {
                 return await dbSet.Where(x => x.ProductOwner == entity.ProductOwner).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetProductsByOwner method error", typeof(UserProductsRepository));
                return new List<UserProducts>();
            }
        }
        //Get products based on user search filter ---> (ProductName, ProductType, ProductCondition).
        public async Task<IEnumerable<UserProducts>> GetProductsBySearchInput(UserProducts entity)
        {
            try
            {
                if (!String.IsNullOrEmpty(entity.ProductName))
                {
                    return await dbSet.Where(x => x.ProductName.Contains(entity.ProductName)).ToListAsync();
                }

                if (!String.IsNullOrEmpty(entity.ProductType))
                {
                    return await dbSet.Where(x => x.ProductType == entity.ProductType).ToListAsync();
                }

                if (!String.IsNullOrEmpty(entity.ProductCondition))
                {
                    return await dbSet.Where(x => x.ProductCondition == entity.ProductCondition).ToListAsync();
                }
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "{Repo} GetProductsBySearchInput method error", typeof(UserProductsRepository));
                return new List<UserProducts>();
            }
        }


        //This function will change product status to sold --> When the order stats is Accepted.
        public async Task<bool> ChangeProductStatus(List<UserProducts> productsId)
        {

            foreach (var item in productsId)
            {
                foreach (var db in await dbSet.ToListAsync())
                {
                    if (db.Id  == item.Id)
                    {
                        db.productStatus = "Sold";
                    }
                }
            }
            return true;
        }


        //This function will only load 3 products from the database.
        public async Task<List<UserProducts>> LoadSomeProducts()
        {
            try
            {
                return await dbSet.Where(x => x.productStatus == "Available").Skip(0).Take(10).ToListAsync();
             }
            catch (Exception ex)
            {
                 _logger.LogError(ex, "{Repo} LoadSomeProducts method error", typeof(UserProductsRepository));
                return new List<UserProducts>();
            }
            
        }
    }
}
