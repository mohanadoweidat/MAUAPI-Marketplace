using MAUAPI.IConfiguration;
using MAUAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MAUAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserAccountController : ControllerBase
    {
        private readonly ILogger<UserAccountController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UserAccountController(ILogger<UserAccountController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }



        //Endpoints from Generic methods.

        [HttpGet]
        [Route("Get/All")]
        public async Task<IActionResult> Get()
        {
            var user = await _unitOfWork.UserAccount.All();
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(Guid id)
        {
            var user = await _unitOfWork.UserAccount.GetById(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> CreateUser(UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                userAccount.Id = Guid.NewGuid();
                await _unitOfWork.UserAccount.Add(userAccount);
                await _unitOfWork.CompleteAsync();

                return CreatedAtAction("GetItem", new { userAccount.Id }, userAccount);
            }
            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            var item = await _unitOfWork.UserAccount.GetById(id);
            if (item == null)
                return BadRequest();

            await _unitOfWork.UserAccount.Delete(id);
            await _unitOfWork.CompleteAsync();


            return Ok(id);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateItem(Guid id, UserAccount userAccount)
        {
            if (id != userAccount.Id)
                return BadRequest();

            await _unitOfWork.UserAccount.Update(userAccount);
            await _unitOfWork.CompleteAsync();
            
 
            return NoContent();
        }

         
        //Endpoints from UserAccountRepository methods.

        [HttpPost]
        [Route("CheckUserLogin")]
        public async Task<IActionResult> CheckUserLogin(UserAccount userAccount)
        {
               if (await _unitOfWork.UserAccount.checkUserLogin(userAccount) == true)
               {
                    return Ok(userAccount);
               }
               else
               {
                    return NotFound();
               }
        }

        [HttpPost]
        [Route("CheckUsernameExist")]
        public async Task<IActionResult> CheckUsernameExist(UserAccount userAccount)
        {
            if (await _unitOfWork.UserAccount.CheckUsernameExist(userAccount) == true)
            {
                return Ok(userAccount);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        [Route("GetUserPassword")]
        public async Task<IActionResult> GetUserPassword(UserAccount userAccount)
        {
            if (await _unitOfWork.UserAccount.GetUserPassword(userAccount))
            {
                return Ok(userAccount.Password);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        [Route("GetUserInformationByUsername")]
        public async Task<IActionResult> GetUserInformationByUsername(UserAccount userAccount)
        {
            if (await _unitOfWork.UserAccount.GetUserInformationByUsername(userAccount))
            {
                return Ok(userAccount);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        [Route("UpdateUserProfile")]
        public async Task<IActionResult> UpdateUserProfile(UserAccount userAccount)
        {
            if (await _unitOfWork.UserAccount.UpdateUserProfile(userAccount))
            {
                await _unitOfWork.CompleteAsync();
                return Ok(userAccount);
            }
            else
            {
                return NotFound();
            }
        }


       

        [HttpPost]
        [Route("GetUserWithInterest")]
        public async Task<IActionResult> GetUserWithInterest(UserAccount userAccount)
        {
            var users =  await _unitOfWork.UserAccount.GetUsersWithInterest(userAccount);
            if (users == null)
                return NotFound();

            return Ok(users);
            
        }


        [HttpPost]
        [Route("AddInterest")]
        public async Task<IActionResult> AddInterest(UserAccount userAccount)
        {
            if (await _unitOfWork.UserAccount.AddInterest(userAccount))
            {
                await _unitOfWork.CompleteAsync();
                return Ok(userAccount);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("AddNotification")]
        public async Task<IActionResult> AddNotification(Notify notify)
        {
            if (await _unitOfWork.UserAccount.AddNotification(notify))
            {
                await _unitOfWork.CompleteAsync();
                return Ok(notify.productType);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("username")]
        public async Task<IActionResult> GetNotificationByUsername(string username)
        {
            var product = await _unitOfWork.UserAccount.GetNotificationByUsername(username);
            if (product == null)
                return NotFound();

            return Ok(product);
        }


        [HttpPost]
        [Route("ResetNotification")]
        public async Task<IActionResult> ResetNotification(UserAccount entity)
        {
            if (await _unitOfWork.UserAccount.resetNotification(entity))
            {
                await _unitOfWork.CompleteAsync();
                return Ok(entity.Username);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
