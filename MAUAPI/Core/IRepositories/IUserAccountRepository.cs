using MAUAPI.Models;

namespace MAUAPI.Core.IRepositories
{
    public interface IUserAccountRepository : IGenericRepository<UserAccount>
    {
        Task<bool> checkUserLogin(UserAccount entity);
        Task<bool> CheckUsernameExist(UserAccount entity);
        Task<bool> GetUserPassword(UserAccount entity);
        Task<bool> GetUserInformationByUsername(UserAccount entity);

        Task<bool> UpdateUserProfile(UserAccount entity);

        Task<IEnumerable<UserAccount>> GetUsersWithInterest(UserAccount entity);

        Task<bool> AddInterest(UserAccount entity);

        Task<bool> AddNotification(Notify notify);

        Task<UserAccount> GetNotificationByUsername(String Username);

        Task<bool> resetNotification(UserAccount entity);

    }
}
