using DTOlayer.Collections.Product_Type;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Services.IServices;
using System;

namespace ThietBiDienTu_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProduct_TypeService ProductTypeService;

        public ProductTypeController(IProduct_TypeService ProductTypeService)
        {
            this.ProductTypeService = ProductTypeService;
        }
        [HttpGet(nameof(GetProductType))]
        public IActionResult GetProductType(int id)
        {
            var result = ProductTypeService.GetProduct_Type(id);
            if (result is not null)
                return Ok(result);
            return BadRequest("Not found");
        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            var result = ProductTypeService.GetAll();
            if (result is not null)
                return Ok(result);
            return BadRequest("Not found");
        }
        [HttpPost(nameof(InsertProductType))]
        public IActionResult InsertProductType(Product_TypeToAdd ProductType)
        {
            ProductType.CreatedDate = ProductType.ModifiedDate = DateTime.Now;
            ProductTypeService.InsertProduct_Type(ProductType);
            return Ok("Insert success!");
        }
        [HttpPut(nameof(UpdateProductType))]
        public IActionResult UpdateProductType(Product_TypeToUpdate ProductType)
        {
            ProductType.ModifiedDate = DateTime.Now;
            ProductTypeService.UpdateProduct_Type(ProductType);
            return Ok("Update success!");
        }
        [HttpDelete(nameof(DeleteProductType))]
        public IActionResult DeleteProductType(int id)
        {
            ProductTypeService.DeleteProduct_Type(id);
            return Ok("Delete Success!");
        }

    }
}
