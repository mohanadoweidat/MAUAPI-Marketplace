using MAUAPI.Core.IRepositories;
using MAUAPI.Data;
using MAUAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using static MAUAPI.Models.UserOrders;

namespace MAUAPI.Core.Repositories
{
    public class UserOrdersRepository : GenericRepository<UserOrders>, IUserOrdersRepository
    {
        public UserOrdersRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
        }
 
        /*****Functions from Generic class****/

        //This function will return a list that contains all the orders with the products.
        public override async Task<IEnumerable<UserOrders>> All()
        {
            try
            {
#pragma warning disable CS8604 // Possible null reference argument.
                return await dbSet.Select(o => new UserOrders
                {
                    Id = o.Id,
                    OrderStatus = o.OrderStatus,
                    OrderDate  = o.OrderDate,
                    BuyerName = o.BuyerName,
                    Items = o.Items.Select(e => new UserOrders.OrderItem
                    {
                        //Id=e.Id,
                        ProductId = e.ProductId,
                        OrderId = e.OrderId,
                        ProductName = e.ProductName,
                        ProductPrice = e.ProductPrice,
                        SellerName = e.SellerName
                     }).ToList(),
                 }).ToListAsync();
#pragma warning restore CS8604 // Possible null reference argument.
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "{Repo} All method error", typeof(UserOrdersRepository));
                return new List<UserOrders>();
            }
        }

        //This function will get a single order by its id.
        public override async Task<UserOrders> GetById(Guid id)
        {
            try
            {
#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8604 // Possible null reference argument.
                return await dbSet.Where(e => e.Id == id).Select(e => new UserOrders
                {
                   Id = e.Id,
                   OrderStatus = e.OrderStatus,
                   OrderDate = e.OrderDate,
                   BuyerName = e.BuyerName,
                    Items = e.Items.Select(c => new UserOrders.OrderItem
                    {
                        ProductName = c.ProductName,
                        ProductId = c.ProductId,
                        OrderId= c.OrderId,
                        ProductPrice= c.ProductPrice,
                        SellerName= c.SellerName
                    }).ToList() 
                }).FirstOrDefaultAsync();
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8603 // Possible null reference return.
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetById method error", typeof(UserOrdersRepository));
                return null;
            }
        }

        //This function will delete a single order by its id.
        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var existingOrder = await dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (existingOrder != null)
                {
                    dbSet.Remove(existingOrder);
                    return true;
                }
                return false;
             }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete method error", typeof(UserOrdersRepository));
                return false;
            }
        }



        /*****Functions from IUserOrdersRepository interface****/

        //Gets all order that needs to be confirmed by the seller.
        public async Task<IEnumerable<UserOrders>> GetOrdersByUser(string username)
        {
            try
            {

#pragma warning disable CS8604 // Possible null reference argument.
                return await dbSet.Where(e => (e.BuyerName == username) && (e.OrderStatus == "Pending"|| e.OrderStatus == "Rejected")).Select(x => new UserOrders
                {
                    Id = x.Id,
                    OrderDate = x.OrderDate,
                    OrderStatus = x.OrderStatus,
                    Items = x.Items.Select(c  => new UserOrders.OrderItem
                    {
                        ProductName = c.ProductName,
                        ProductPrice = c.ProductPrice,
                        SellerName = c.SellerName,
                         
                    }).ToList(),
                }).ToListAsync();
#pragma warning restore CS8604 // Possible null reference argument.
            }
            catch (Exception ex)
            {
               _logger.LogError(ex, "{Repo} GetOrdersByUser method error", typeof(UserOrdersRepository));
                return null;
            }
        }
         
        //Gets all orders that has been confirmed by the seller.
        public async Task<IEnumerable<UserOrders>> GetCompletedOrdersByUser(string username)
        {
            try
            {

#pragma warning disable CS8604 // Possible null reference argument.
                return await dbSet.Where(e => (e.BuyerName == username) && e.OrderStatus == "Accepted").Select(x => new UserOrders
                {
                    Id = x.Id,
                    OrderDate = x.OrderDate,
                    OrderStatus = x.OrderStatus,
                    Items = x.Items.Select(c => new UserOrders.OrderItem
                    {
                        ProductName = c.ProductName,
                        ProductPrice = c.ProductPrice,
                        SellerName = c.SellerName,
                     }).ToList(),
                }).ToListAsync();
#pragma warning restore CS8604 // Possible null reference argument.
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetOrdersByUser method error", typeof(UserOrdersRepository));
                return null;
            }
        }
         
        //This function will get all the sellers order that needs to be confirmed or rejected.
        public async Task<IEnumerable<UserOrders>> GetSellerOrders(string sellerName)
        {
            try
            {
#pragma warning disable CS8604 // Possible null reference argument.
                return await dbSet.Where(e => e.Items.Any(x => x.SellerName == sellerName) && e.OrderStatus == "Pending").Select(x => new UserOrders
                {
                    Id = x.Id,
                    BuyerName = x.BuyerName,
                    
                    Items = x.Items.Select(c => new OrderItem
                    {
                         ProductId = c.ProductId,
                         ProductName = c.ProductName,
                         OrderId = c.OrderId,
                     }).ToList(),
                }).ToListAsync();
#pragma warning restore CS8604 // Possible null reference argument.
            }
            catch (Exception ex)
            {
                 _logger.LogError(ex, "{Repo} GetSellerOrders method error", typeof(UserOrdersRepository));
                return null;
            }
        }

        //This will change order status to Accepted when the user accept the order.
        public async Task<bool> ChangeOrderStatus(string sellerName, string newOrderState, Guid orderId)
        {
            try
            {
 #pragma warning disable CS8604 // Possible null reference argument.
                var order = await dbSet.Where(e => e.Items.Any(e => e.SellerName == sellerName) && (e.OrderStatus == "Pending") && (e.Id == orderId)).ToListAsync();
#pragma warning restore CS8604 // Possible null reference argument.
                if (order != null)
                {
                    var updatedOrderStatus = order.Select(e => e.OrderStatus = newOrderState).ToList();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} ChangeOrderStatus method error", typeof(UserOrdersRepository));
                return false;
             }
        }
         
        //Get a list of products within an accepted order ---> (orderStatus == Accepted).
        public async Task<IEnumerable<UserOrders>> GetAllProductsInAcceptedOrders()
        {
            try
            { 
                 return await dbSet.Where(e => e.OrderStatus == "Accepted").Select(o => new UserOrders
                 {
                    Items = o.Items.Select(e => new UserOrders.OrderItem
                    {
                      ProductId = e.ProductId,
                    }).ToList(),
                 }).ToListAsync();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "{Repo} GetAllProductsInAcceptedOrders method error", typeof(UserOrdersRepository));
                return null;
            }
            return null;
        }
         
        // Get a list of all purchased orders for the logged in user and with from-to date filter.
        public async Task<IEnumerable<UserOrders>> GetOrderHistoryByUser(string username, DateTime searchDateFrom, DateTime searchDateTo)
        {
            try
            {
 #pragma warning disable CS8604 // Possible null reference argument.
                return await dbSet.Where(e => (e.BuyerName == username) && e.OrderStatus == "Accepted" && e.OrderDate >= searchDateFrom && e.OrderDate <= searchDateTo).Select(x => new UserOrders
                {
                    Id = x.Id,
                    OrderDate = x.OrderDate,
                    OrderStatus = x.OrderStatus,
                    Items = x.Items.Select(c => new UserOrders.OrderItem
                    {
                        ProductName = c.ProductName,
                        ProductPrice = c.ProductPrice,
                        SellerName = c.SellerName,
                    }).ToList(),
                }).ToListAsync();
#pragma warning restore CS8604 // Possible null reference argument.
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetOrdersByUser method error", typeof(UserOrdersRepository));
                return null;
            }
        }
    }
    
}
