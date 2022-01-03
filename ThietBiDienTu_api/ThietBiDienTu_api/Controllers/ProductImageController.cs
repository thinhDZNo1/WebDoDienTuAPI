using DTOlayer.Collections.ProductImages;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Services.IServices;
using System;
using System.Collections.Generic;
using System.IO;

namespace ThietBiDienTu_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImagesService productImageService;

        public ProductImageController(IProductImagesService productImageService)
        {
            this.productImageService = productImageService;
        }
        [HttpGet(nameof(GetProductImage))]
        public IActionResult GetProductImage(int id)
        {
            var result = productImageService.GetProductImages(id);
            if (result is not null)
                return Ok(result);
            return BadRequest("Not found");
        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            List<ProductImagesToGet> result = productImageService.GetAll();
            List<ProductImagesToGet> list = new List<ProductImagesToGet>();
            ProductImagesToGet ProductImage;
            if (result is not null)
            {
                foreach (ProductImagesToGet item in result)
                {
                    string path = "Images/"+item.Images;
                    FileInfo fileInfo = new FileInfo(path);
                    ProductImage = item;
                    if (System.IO.File.Exists(path))
                    {
                        byte[] fileImage = new byte[fileInfo.Length];
                        using (FileStream fs = fileInfo.OpenRead())
                        {
                            fs.Read(fileImage, 0, fileImage.Length);
                        }
                        string Base64String = Convert.ToBase64String(fileImage);                        
                        ProductImage.ImageFile = Base64String;
                    }
                    list.Add(ProductImage);
                }
                return Ok(list);
            }
            return BadRequest("Not found");
        }
        [HttpPost(nameof(InsertProductImage))]
        public IActionResult InsertProductImage(ProductImagesToAdd ProductImage)
        {
            if (ProductImage.Images.Length > 1)
            {
                byte[] imageBytes = Convert.FromBase64String(ProductImage.Images);
                string path;
                char[] chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
                Random random = new Random();
                string imgName = "";               
                while (true)
                {
                    for (int i = 0; i < 15; i++)
                    {
                        imgName += chars[random.Next(0, chars.Length)].ToString();
                    }
                    if (System.IO.File.Exists("Images/" + imgName + ".png") == false)
                    {
                        break;
                    }
                }
                path = "Images/" + imgName + ".png";
                System.IO.File.WriteAllBytes(path, imageBytes);
                ProductImage.Images = imgName + ".png";
            }
            else
                ProductImage.Images = "default_img.png";
            ProductImage.CreatedDate = ProductImage.ModifiedDate = DateTime.Now;
            productImageService.InsertProductImages(ProductImage);
            return Ok("Insert success!");
        }
        
        [HttpDelete(nameof(DeleteProductImage))]
        public IActionResult DeleteProductImage(int id)
        {
            ProductImagesToGet ProductImage = productImageService.GetProductImages(id);
            if (ProductImage.Images.Length > 2 && ProductImage.Images.Equals("default_img.png") == false)
            {
                string path = "Images/" + ProductImage.Images;
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
            productImageService.DeleteProductImages(id);
            return Ok("Delete Success!");
        }

    }
}
