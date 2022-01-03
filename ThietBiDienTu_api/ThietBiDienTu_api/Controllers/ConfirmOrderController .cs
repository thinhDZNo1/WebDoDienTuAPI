using AutoMapper;
using DomainLayer.Model;
using DTOlayer.Collections.ConfirmOrder;
using DTOlayer.Collections.Product;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using System.Linq;
using ServicesLayer.Services.IServices;
using System.Collections.Generic;
using System.IO;
using System;

namespace ThietBiDienTu_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfirmOrderController : ControllerBase
    {
        private readonly IConfirmOrderService confirmOrderService;
        private readonly ICartDetailService cartService;
        private readonly IProductService productService;
        private readonly ThietBiDienTuDBContext db;
        private readonly IMapper mapper;

        public ConfirmOrderController(IConfirmOrderService confirmOrderService, ThietBiDienTuDBContext db, IMapper mapper, ICartDetailService cartService, IProductService productService)
        {
            this.confirmOrderService = confirmOrderService;
            this.cartService = cartService;
            this.db = db;
            this.productService = productService;
            this.mapper = mapper;
        }
        [HttpGet(nameof(GetConfirmOrder))]
        public IActionResult GetConfirmOrder(int id)
        {
            var result = confirmOrderService.GetConfirmOrder(id);
            if (result is not null)
                return Ok(result);
            return BadRequest("Not found");
        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            var result = confirmOrderService.GetAll();
            List<ConfirmOrderToGet> list = new List<ConfirmOrderToGet>();
            ConfirmOrderToGet confirmOrder;
            foreach (ConfirmOrderToGet item in result)
            {
                confirmOrder = item;
                confirmOrder.CartDetail = cartService.GetCartDetail(confirmOrder.CartDetailId);                
                ProductToGet product = productService.GetProduct(confirmOrder.CartDetail.ProductId);
                string path = "Images/" + product.Images;
                FileInfo fileInfo = new FileInfo(path);
                if (System.IO.File.Exists(path))
                {
                    byte[] fileImage = new byte[fileInfo.Length];
                    using (FileStream fs = fileInfo.OpenRead())
                    {
                        fs.Read(fileImage, 0, fileImage.Length);
                    }
                    string Base64String = Convert.ToBase64String(fileImage);
                    product.ImageFile = Base64String;
                }
                confirmOrder.CartDetail.Product = product;
                list.Add(confirmOrder);
            }
            if (list is not null)
                return Ok(list);
            return BadRequest("Not found");
        }
        [HttpPost(nameof(InsertConfirmOrder))]
        public IActionResult InsertConfirmOrder(ConfirmOrderToAdd confirmOrder)
        {
            confirmOrderService.InsertConfirmOrder(confirmOrder);
            return Ok("Insert success!");
        }
        [HttpPut(nameof(UpdateConfirmOrder))]
        public IActionResult UpdateConfirmOrder(ConfirmOrderToUpdate confirmOrder)
        {
            confirmOrderService.UpdateConfirmOrder(confirmOrder);
            return Ok("Update success!");
        }
        [HttpDelete(nameof(DeleteConfirmOrder))]
        public IActionResult DeleteConfirmOrder(int id)
        {
            confirmOrderService.DeleteConfirmOrder(id);
            return Ok("Delete Success!");
        }

    }
}
