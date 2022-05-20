using MAUAPI.IConfiguration;
using MAUAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MAUAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class UserProductsController : ControllerBase
    {
        private readonly ILogger<UserAccountController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UserProductsController(ILogger<UserAccountController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }



        //Endpoints from Generic methods.

        [HttpGet]
        [Route("Get/All")]
        public async Task<IActionResult> Get()
        {
            var products = await _unitOfWork.UserProducts.All();
            if (products == null)
                return NotFound();

            return Ok(products);
        }


        

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(Guid id)
        {
            var product = await _unitOfWork.UserProducts.GetById(id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> CreateProduct(UserProducts userProducts)
        {
            if (ModelState.IsValid)
            {
                userProducts.Id = Guid.NewGuid();
                await _unitOfWork.UserProducts.Add(userProducts);
                await _unitOfWork.CompleteAsync();

                return CreatedAtAction("GetItem", new { userProducts.Id }, userProducts);
            }
            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            var item = await _unitOfWork.UserProducts.GetById(id);
            if (item == null)
                return BadRequest();

            await _unitOfWork.UserProducts.Delete(id);
            await _unitOfWork.CompleteAsync();


            return Ok(id);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateItem(Guid id, UserProducts userProducts){
            if (id != userProducts.Id)
                return BadRequest();

            await _unitOfWork.UserProducts.Update(userProducts);
            await _unitOfWork.CompleteAsync();


            return NoContent();
        }




        [HttpGet]
        [Route("Get/Some")]
        public async Task<IActionResult> LoadSomeProducts()
        {
            var products = await _unitOfWork.UserProducts.LoadSomeProducts();
            if (products == null)
                return NotFound();

            return Ok(products);
        }



        [HttpPost]
        [Route("GetProductsByOwner")]
        public async Task<IActionResult> GetProductsByOwner(UserProducts userProducts)
        {
             
            var products = await _unitOfWork.UserProducts.GetProductsByOwner(userProducts);
            if (products == null)
                return NotFound();

            return Ok(products);
        }


        [HttpPost]
        [Route("GetProductsBySearchInput")]
        public async Task<IActionResult> GetProductsBySearchInput(UserProducts userProducts)
        {

            var products = await _unitOfWork.UserProducts.GetProductsBySearchInput(userProducts);
            if (products == null)
                return NotFound();

            return Ok(products);
        }



        [HttpPost]
        [Route("ChangeProductStatus")]
        public async Task<IActionResult> ChangeProductStatus(List<UserProducts> productsId)
        {
           if (await _unitOfWork.UserProducts.ChangeProductStatus(productsId))
           {
                await _unitOfWork.CompleteAsync();
                return Ok();
           }
            else
            {
                return NotFound();
            }
        }



    }
}
