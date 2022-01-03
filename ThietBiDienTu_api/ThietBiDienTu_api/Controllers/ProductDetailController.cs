using DTOlayer.Collections.ProductDetail;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Services.IServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace ThietBiDienTu_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailDetail : ControllerBase
    {
        private readonly IProductDetailService ProductDetailService;

        public ProductDetailDetail(IProductDetailService ProductDetailService)
        {
            this.ProductDetailService = ProductDetailService;
        }
        [HttpGet(nameof(GetProductDetail))]
        public IActionResult GetProductDetail(int id)
        {
            ProductDetailToGet ProductDetail = ProductDetailService.GetProductDetail(id);
            string path = "Images/" + ProductDetail.Image;
            FileInfo fileInfo = new FileInfo(path);
            if (System.IO.File.Exists(path))
            {
                byte[] fileImage = new byte[fileInfo.Length];
                using (FileStream fs = fileInfo.OpenRead())
                {
                    fs.Read(fileImage, 0, fileImage.Length);
                }
                string Base64String = Convert.ToBase64String(fileImage);
                ProductDetail.ImageFile = Base64String;
            }
            if (ProductDetail is not null)
                return Ok(ProductDetail);
            return BadRequest("Not found");
        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            List<ProductDetailToGet> result = ProductDetailService.GetAll();
            List<ProductDetailToGet> list = new List<ProductDetailToGet>();
            ProductDetailToGet ProductDetail;
            if (result is not null)
            {
                foreach (ProductDetailToGet item in result)
                {
                    string path = "Images/"+item.Image;
                    FileInfo fileInfo = new FileInfo(path);
                    ProductDetail = item;
                    if (System.IO.File.Exists(path))
                    {
                        byte[] fileImage = new byte[fileInfo.Length];
                        using (FileStream fs = fileInfo.OpenRead())
                        {
                            fs.Read(fileImage, 0, fileImage.Length);
                        }
                        string Base64String = Convert.ToBase64String(fileImage);                        
                        ProductDetail.ImageFile = Base64String;
                    }
                    list.Add(ProductDetail);
                }
                return Ok(list);
            }
            return BadRequest("Not found");
        }
        [HttpPost(nameof(InsertProductDetail))]
        public IActionResult InsertProductDetail(ProductDetailToAdd ProductDetail)
        {
            if (ProductDetail.Image.Length > 1)
            {
                byte[] imageBytes = Convert.FromBase64String(ProductDetail.Image);
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
                ProductDetail.Image = imgName + ".png";
            }
            else
                ProductDetail.Image = "default_img.png";
            ProductDetail.CreatedDate = ProductDetail.ModifiedDate = DateTime.Now;
            ProductDetailService.InsertProductDetail(ProductDetail);
            return Ok("Insert success!");
        }
        [HttpPut(nameof(UpdateProductDetail))]
        public IActionResult UpdateProductDetail(ProductDetailToUpdate ProductDetail)
        {
            if (ProductDetail.ImageFile.Length > 5)
            {
                if (System.IO.File.Exists("Image/" + ProductDetail.Image))
                {
                    System.IO.File.Delete("Image/" + ProductDetail.Image);
                }
                byte[] imageBytes = Convert.FromBase64String(ProductDetail.ImageFile);
                //Image image;
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
                ProductDetail.Image = imgName + ".png";
            }

            ProductDetail.ModifiedDate = DateTime.Now;
            ProductDetailService.UpdateProductDetail(ProductDetail);
            return Ok("Update success!");
        }
        [HttpDelete(nameof(DeleteProductDetail))]
        public IActionResult DeleteProductDetail(int id)
        {
            ProductDetailToGet ProductDetail = ProductDetailService.GetProductDetail(id);
            if (ProductDetail.Image.Length > 2 && ProductDetail.Image.Equals("default_img.png") == false)
            {
                string path = "Images/" + ProductDetail.Image;
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
            ProductDetailService.DeleteProductDetail(id);
            return Ok("Delete Success!");
        }

    }
}
