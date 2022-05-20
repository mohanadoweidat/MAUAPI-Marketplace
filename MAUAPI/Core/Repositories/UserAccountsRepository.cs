using MAUAPI.Core.IRepositories;
using MAUAPI.Data;
using MAUAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MAUAPI.Core.Repositories
{
    public class UserAccountsRepository : GenericRepository<UserAccount>, IUserAccountRepository
    {
        public UserAccountsRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {

        }

         /****** Functions from Generic class*****/

        //Get all accounts.
        public override async Task<IEnumerable<UserAccount>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "{Repo} All method error", typeof(UserAccountsRepository));
                return new List<UserAccount>();
            }
        }

        //Update user account information based on its id.
        public override async Task<bool> Update(UserAccount entity)
        {
             try
             {
                var existingUser = await dbSet.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();
                if (existingUser == null)
                    return await Add(entity);

                existingUser.FirstName = entity.FirstName;
                existingUser.LastName = entity.LastName;
                existingUser.DateOfBirth = entity.DateOfBirth;
                existingUser.Email = entity.Email;
                existingUser.Username = entity.Username;
                existingUser.Password = entity.Password;
                return true;
             }
            catch (Exception ex)
             {
              _logger.LogError(ex, "{Repo} Update method error", typeof(UserAccountsRepository));
              return false;
             }
         }
        //Delete user account by its id.
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
                _logger.LogError(ex, "{Repo} Delete method error", typeof(UserAccountsRepository));
                return false;
            }
        }


        /****** Functions from UserAccountRepository class*****/
 
        //Check if the login data exist.
        public async Task<bool> checkUserLogin(UserAccount entity)
        {
            try
            {
                
                var existingUser = await dbSet.Where(x => x.Username == entity.Username && x.Password == entity.Password).FirstOrDefaultAsync();
                if (existingUser == null)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} checkUserLogin method error", typeof(UserAccountsRepository));
                return false;
            }
            return true;
         }
        //Check the username of the user exist.
        public async Task<bool> CheckUsernameExist(UserAccount entity)
        {
            try
            {
                var existingUsername = await dbSet.Where(e => e.Username == entity.Username).FirstOrDefaultAsync();
                if (existingUsername == null)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} CheckUsernameExist method error", typeof(UserAccountsRepository));
                return false;
            }
            return true;
        }
        //Get users password.
        public async Task<bool> GetUserPassword(UserAccount entity)
        {
             try
             {
                //var password = await (from x in dbSet where x.Email == entity.Email select x.Password).SingleOrDefaultAsync();

                var password = await dbSet.Where(x => x.Username == entity.Username).Select(x => x.Password).FirstOrDefaultAsync();

                if (password != null)
                {
                    entity.Password = password.ToString();
                }
                  
            }
            catch (Exception ex)
             {
                 _logger.LogError(ex, "{Repo} GetUserPassword method error", typeof(UserAccountsRepository));
                return false;
             }
            return true;
            
        }
        // Get user information by its username.
        public async Task<bool> GetUserInformationByUsername(UserAccount entity)
        {
            try
            {
                //var password = await (from x in dbSet
                //              where x.Email == entity.Email
                //              select x.Password).SingleOrDefaultAsync();

                var info = await dbSet.Where(x => x.Username == entity.Username).ToListAsync();
                
                 if (info != null)
                 {
                    entity.FirstName =info.First().FirstName;
                    entity.LastName = info.First().LastName;
                    entity.Email = info.First().Email;
                    entity.Password = info.First().Password;
                    entity.DateOfBirth = info.First().DateOfBirth;
                    return true;
                 }
             }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetUserInformationByUsername method error", typeof(UserAccountsRepository));
                return false;
            }
            return false;
        }
        //This function will update logged in user profile information by its username.
        public async Task<bool> UpdateUserProfile(UserAccount entity)
        {
            try
            {
 
                var info = await dbSet.Where(x => x.Username == entity.Username).FirstOrDefaultAsync();

                if (info != null)
                {
                    info.FirstName = entity.FirstName;
                    info.LastName = entity.LastName;
                    info.Email = entity.Email;
                    info.Password = entity.Password;
                    info.DateOfBirth = entity.DateOfBirth;
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} UpdateUserProfile method error", typeof(UserAccountsRepository));
                return false;
            }
            return false;
        }
        //Get all users that have interest.
        public async Task<IEnumerable<UserAccount>> GetUsersWithInterest(UserAccount entity)
        {
            try
            {
                return await dbSet.Where(x => x.Interest.Contains(entity.Notification)).ToListAsync();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "{Repo} GetUsersWithInterest method error", typeof(UserAccountsRepository));
                return new List<UserAccount>();
            }
   
        }
        //This function will add a new interest to the user.
        public async Task<bool> AddInterest(UserAccount entity)
        {
            bool done = false;
            try
            { 
                var info = await dbSet.Where(x => x.Username == entity.Username).FirstOrDefaultAsync();

                if (info != null)
                {
                    if (info.Interest == null)
                    {
                        info.Interest = entity.Interest;
                        done = true;
                         
                    }
                    else
                    {
                        if (info.Interest.Contains(entity.Interest))
                        {
                            done = false;
                        }
                        else
                        {
                            info.Interest += "," + entity.Interest;
                            done = true;
                        }
                    }
                   return done;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} AddInterest method error", typeof(UserAccountsRepository));
                return done;
            }
            return done;

        }
        //This function will change add a new Notification based on the intrest
        public async Task<bool> AddNotification(Notify notify)
        {
            bool done = false;
            try
            {
                foreach (var db in await dbSet.ToListAsync())
                {
                    foreach (var item in notify.usersWithInterest)
                    {
                        if (db.Username == item.Username)
                        {
                            if (db.Notification == null)
                            {
                                db.Notification = "";
                            }
                            if (!db.Notification.Contains(notify.productType))
                            {
                                if (db.Notification != "")
                                {
                                    db.Notification += ", " + notify.productType;
                                    done = true;
                                }
                                else
                                {
                                    db.Notification = notify.productType;
                                    done = true;
                                }
                            }
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "{Repo} AddNotification method error", typeof(UserAccountsRepository));
                return false;
            }
            return done;

            
             
        }
        //Notify user by its username.
        public async Task<UserAccount> GetNotificationByUsername(string username)
        {
            try
            {
                //var password = await (from x in dbSet where x.Email == entity.Email select x.Password).SingleOrDefaultAsync();

                 var userNotification =  await dbSet.Where(x => x.Username == username).Select(x => x.Notification).FirstOrDefaultAsync();
                 UserAccount account = new UserAccount();
                 account.Notification = userNotification;
                 return account;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetNotificationById method error", typeof(UserAccountsRepository));
                return null;
            }
            return null;
        }
        //Reset the notfication field for the logged in user by its username.
        public async Task<bool> resetNotification(UserAccount entity)
        {
            bool removed = false;
            try
            {
                var info = await dbSet.Where(x => x.Username == entity.Username).FirstOrDefaultAsync();

                if (info != null)
                {
                    if (info.Notification != "")
                    {
                        info.Notification = "";
                        removed = true;
                    }
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "{Repo} resetNotification method error", typeof(UserAccountsRepository));
                return false;
            }
            return removed;
        }
    }
}
