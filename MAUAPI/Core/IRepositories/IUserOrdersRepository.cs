using MAUAPI.Models;

namespace MAUAPI.Core.IRepositories
{
    public interface IUserOrdersRepository : IGenericRepository<UserOrders>
    {
        public Task<IEnumerable<UserOrders>> GetOrdersByUser(string username);
        public Task<IEnumerable<UserOrders>> GetCompletedOrdersByUser(string username);

        public Task<IEnumerable<UserOrders>> GetSellerOrders(string sellerName);

        public Task<bool> ChangeOrderStatus(string sellerName, string newOrderState, Guid orderId);
        public Task<IEnumerable<UserOrders>> GetAllProductsInAcceptedOrders();

        public Task<IEnumerable<UserOrders>> GetOrderHistoryByUser(string username, DateTime searchDateFrom, DateTime searchDateTo);
    }
}
