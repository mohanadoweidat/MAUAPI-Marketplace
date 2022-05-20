using MAUAPI.IConfiguration;
using MAUAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MAUAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserOrdersController : ControllerBase
    {
        private readonly ILogger<UserAccountController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UserOrdersController(ILogger<UserAccountController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        //Endpoints from Generic methods.

        [HttpGet]
        [Route("Get/All")]
        public async Task<IActionResult> Get()
        {
            var user = await _unitOfWork.UserOrders.All();
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(Guid id)
        {
            var user = await _unitOfWork.UserOrders.GetById(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            var order = await _unitOfWork.UserOrders.GetById(id);
            if (order == null)
                return BadRequest();

            await _unitOfWork.UserOrders.Delete(id);
            await _unitOfWork.CompleteAsync();


            return Ok(id);

        }


        [HttpPost]
        [Route("Add/Order")]
        public async Task<IActionResult> CreateOrder(UserOrders order)
        {
            await _unitOfWork.UserOrders.Add(order);
            await _unitOfWork.CompleteAsync();
            return Ok(order);
        }

         


        //Endpoints from UserOrdersRepository methods.
        [HttpGet]
        [Route("username")]
        public async Task<IActionResult> GetOrdersByUser(string username)
        {
            if (ModelState.IsValid)
            {
                var user = await _unitOfWork.UserOrders.GetOrdersByUser(username);
                if (user == null)
                    return NotFound();

                return Ok(user);
            }
            return null;

        }


        [HttpGet]
        [Route("Completed/username")]
        public async Task<IActionResult> GetCompletedOrdersByUser(string username)
        {
            if (ModelState.IsValid)
            {
                var user = await _unitOfWork.UserOrders.GetCompletedOrdersByUser(username);
                if (user == null)
                    return NotFound();

                return Ok(user);
            }
            return null;

        }


        [HttpGet]
        [Route("sellerName")]
        public async Task<IActionResult> GetSellerOrders(string sellerName)
        {
            if (ModelState.IsValid)
            {
                var user = await _unitOfWork.UserOrders.GetSellerOrders(sellerName);
                if (user == null)
                    return NotFound();

                return Ok(user);
            }
            return null;

        }


        [HttpPut, Route("{sellerName},{newOrderState},{orderId}")]
        public async Task<IActionResult> ChangeOrderStatus(string sellerName, string newOrderState, Guid orderId)
        {

            if (await _unitOfWork.UserOrders.ChangeOrderStatus(sellerName, newOrderState, orderId))
            {
                await _unitOfWork.CompleteAsync();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }



        [HttpGet]
        [Route("GetAllProductsInAcceptedOrders")]
        public async Task<IActionResult> GetAllProductsInAcceptedOrders()
        {
            
                var user = await _unitOfWork.UserOrders.GetAllProductsInAcceptedOrders();
                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return NotFound();
                }
        }


        [HttpGet]
        [Route("Completed/History")]
        public async Task<IActionResult> GetOrderHistoryByUser(string username, DateTime searchDateFrom, DateTime searchDateTo)
        {
            if (ModelState.IsValid)
            {
                var user = await _unitOfWork.UserOrders.GetOrderHistoryByUser(username,searchDateFrom,searchDateTo);
                if (user == null)
                    return NotFound();

                return Ok(user);
            }
            return null;

        }

    }
}
