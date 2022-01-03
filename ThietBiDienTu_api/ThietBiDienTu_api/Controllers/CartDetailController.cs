using AutoMapper;
using DTOlayer.Collections.Cart;
using DTOlayer.Collections.CartDetail;
using DTOlayer.Collections.Product;
using DTOlayer.Collections.ProductDetail;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using System.Linq;
using ServicesLayer.Services.IServices;
using System;
using System.Collections.Generic;
using System.IO;

namespace ThietBiDienTu_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartDetailController : ControllerBase
    {
        private readonly ICartDetailService cartDetailService;
        private readonly ICartService cartService;
        private readonly IProductDetailService productDetailService;
        private readonly IProductService productService;
        private readonly ThietBiDienTuDBContext db;
        private readonly IMapper mapper;

        public CartDetailController(ICartDetailService cartDetailService, ThietBiDienTuDBContext db, IMapper mapper, ICartService cartService, IProductDetailService productDetailService, IProductService productService)
        {
            this.cartDetailService = cartDetailService;
            this.productDetailService = productDetailService;
            this.productService = productService;
            this.cartDetailService = cartDetailService;
            this.db = db;
            this.mapper = mapper;
        }
        [HttpGet(nameof(GetCartDetail))]
        public IActionResult GetCartDetail(int id)
        {
            var result = cartDetailService.GetCartDetail(id);
            if (result is not null)
                return Ok(result);
            return BadRequest("Not found");
        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            List<CartDetailToGet> result = cartDetailService.GetAll();
            List<CartDetailToGet> cartDetails = new List<CartDetailToGet>();
            CartDetailToGet cartDetail;
            foreach (CartDetailToGet item in result)
            {
                cartDetail = item;
                if (item.ProductId == null)
                {
                    cartDetail.ProductDetail = productDetailService.GetProductDetail(item.PDId);
                    string path = "Images/" + cartDetail.ProductDetail.Image;
                    FileInfo fileInfo = new FileInfo(path);
                    if (System.IO.File.Exists(path))
                    {
                        byte[] fileImage = new byte[fileInfo.Length];
                        using (FileStream fs = fileInfo.OpenRead())
                        {
                            fs.Read(fileImage, 0, fileImage.Length);
                        }
                        string Base64String = Convert.ToBase64String(fileImage);
                        cartDetail.ProductDetail.ImageFile = Base64String;
                    }
                    cartDetail.Product = productService.GetProduct(item.ProductDetail.ProductId);
                    string pathP = "Images/" + cartDetail.Product.Images;
                    FileInfo fileInfoP = new FileInfo(pathP);
                    if (System.IO.File.Exists(pathP))
                    {
                        byte[] fileImage = new byte[fileInfoP.Length];
                        using (FileStream fs = fileInfoP.OpenRead())
                        {
                            fs.Read(fileImage, 0, fileImage.Length);
                        }
                        string Base64String = Convert.ToBase64String(fileImage);
                        cartDetail.Product.ImageFile = Base64String;
                    }
                }
                else
                {
                    cartDetail.Product = productService.GetProduct(item.ProductDetail.ProductId);
                    string path = "Images/" + cartDetail.Product.Images;
                    FileInfo fileInfo = new FileInfo(path);
                    if (System.IO.File.Exists(path))
                    {
                        byte[] fileImage = new byte[fileInfo.Length];
                        using (FileStream fs = fileInfo.OpenRead())
                        {
                            fs.Read(fileImage, 0, fileImage.Length);
                        }
                        string Base64String = Convert.ToBase64String(fileImage);
                        cartDetail.Product.ImageFile = Base64String;
                    }
                }
                cartDetails.Add(cartDetail);
            }
            if (cartDetails is not null)
                return Ok(cartDetails);
            return BadRequest("Not found");
        }

        [HttpGet(nameof(GetCartByUser))]
        public IActionResult GetCartByUser(int? userId)
        {
            List<CartDetailToGet> result = cartDetailService.GetCartByUser(userId);
            List<CartDetailToGet> cartDetails = new List<CartDetailToGet>();
            CartDetailToGet cartDetail;
            foreach (CartDetailToGet item in result)
            {
                cartDetail = item;
                if (item.ProductId == null)
                {
                    cartDetail.ProductDetail = productDetailService.GetProductDetail(item.PDId);
                    string path = "Images/" + cartDetail.ProductDetail.Image;
                    FileInfo fileInfo = new FileInfo(path);
                    if (System.IO.File.Exists(path))
                    {
                        byte[] fileImage = new byte[fileInfo.Length];
                        using (FileStream fs = fileInfo.OpenRead())
                        {
                            fs.Read(fileImage, 0, fileImage.Length);
                        }
                        string Base64String = Convert.ToBase64String(fileImage);
                        cartDetail.ProductDetail.ImageFile = Base64String;
                    }
                    cartDetail.Product = productService.GetProduct(item.ProductDetail.ProductId);
                    string pathP = "Images/" + cartDetail.Product.Images;
                    FileInfo fileInfoP = new FileInfo(pathP);
                    if (System.IO.File.Exists(pathP))
                    {
                        byte[] fileImage = new byte[fileInfoP.Length];
                        using (FileStream fs = fileInfoP.OpenRead())
                        {
                            fs.Read(fileImage, 0, fileImage.Length);
                        }
                        string Base64String = Convert.ToBase64String(fileImage);
                        cartDetail.Product.ImageFile = Base64String;
                    }
                }
                else
                {
                    cartDetail.Product = productService.GetProduct(item.ProductId);
                    string path = "Images/" + cartDetail.Product.Images;
                    FileInfo fileInfo = new FileInfo(path);
                    if (System.IO.File.Exists(path))
                    {
                        byte[] fileImage = new byte[fileInfo.Length];
                        using (FileStream fs = fileInfo.OpenRead())
                        {
                            fs.Read(fileImage, 0, fileImage.Length);
                        }
                        string Base64String = Convert.ToBase64String(fileImage);
                        cartDetail.Product.ImageFile = Base64String;
                    }
                }
                cartDetails.Add(cartDetail);
            }
            if (cartDetails is not null)
                return Ok(cartDetails);
            return BadRequest("Not found");
        }

        [HttpPost(nameof(AddToCart))]
        public IActionResult AddToCart(CartDetailToAdd cartDetail)
        {
            CartToGet cart = mapper.Map<CartToGet>(db.Cart.FirstOrDefault(x => x.UserId.Equals(cartDetail.UserId)));
            CartDetailToGet cartDT = cartDetailService.GetCartDetail(cartDetail.PDId, cartDetail.ProductId);
            if (cartDT != null)
            {
                if (cartDT.IsActive)
                {
                    cartDT.Quantity += cartDetail.Quantity;
                    CartDetailToUpdate cartDetailToUpdate = mapper.Map<CartDetailToUpdate>(cartDT);
                    cartDetailService.UpdateCartDetail(cartDetailToUpdate);
                }
                else
                {
                    cartDetail.CreatedDate = cartDetail.ModifiedDate = DateTime.Now;
                    cartDetail.IsActive = true;
                    cartDetail.CartId = cart.Id;
                    cartDetailService.InsertCartDetail(cartDetail);
                }
                    
            }
            else
            {
                cartDetail.CreatedDate = cartDetail.ModifiedDate = DateTime.Now;
                cartDetail.IsActive = true;
                cartDetail.CartId = cart.Id;
                cartDetailService.InsertCartDetail(cartDetail);
            }
            return Ok("Success!");
        }
        [HttpPut(nameof(ConfirmCart))]
        public IActionResult ConfirmCart(CartDetailToUpdate cartDetail)
        {
            cartDetail.IsActive = false;
            cartDetail.ModifiedDate = DateTime.Now;
            cartDetailService.UpdateCartDetail(cartDetail);
            return Ok("Update success!");
        }
        [HttpDelete(nameof(DeleteCartDetail))]
        public IActionResult DeleteCartDetail(int id)
        {
            cartDetailService.DeleteCartDetail(id);
            return Ok("Delete Success!");
        }

    }
}
