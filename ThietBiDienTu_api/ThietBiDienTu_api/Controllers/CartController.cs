using DTOlayer.Collections.Cart;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Services.IServices;

namespace ThietBiDienTu_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;

        public CartController(ICartService cartService)
        {
            this.cartService = cartService;
        }
        [HttpGet(nameof(GetCart))]
        public IActionResult GetCart(int id)
        {
            var result = cartService.GetCart(id);
            if (result is not null)
                return Ok(result);
            return BadRequest("Not found");
        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            var result = cartService.GetAll();
            if (result is not null)
                return Ok(result);
            return BadRequest("Not found");
        }
        [HttpPost(nameof(InsertCart))]
        public IActionResult InsertCart(CartToAdd cart)
        {
            cartService.InsertCart(cart);
            return Ok("Insert success!");
        }
        [HttpPut(nameof(UpdateCart))]
        public IActionResult UpdateCart(CartToUpdate cart)
        {
            cartService.UpdateCart(cart);
            return Ok("Update success!");
        }
        [HttpDelete(nameof(DeleteCart))]
        public IActionResult DeleteCart(int id)
        {
            cartService.DeleteCart(id);
            return Ok("Delete Success!");
        }

    }
}
