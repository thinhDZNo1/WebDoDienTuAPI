using DTOlayer.Collections.Product;
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
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly ICategoryDetailService cdService;
        private readonly ICompanyService companyService;

        public ProductController(IProductService productService, ICategoryDetailService cdService, ICompanyService companyService)
        {
            this.productService = productService;
            this.cdService = cdService;
            this.companyService = companyService;
        }
        [HttpGet(nameof(GetProduct))]
        public IActionResult GetProduct(int id)
        {
            ProductToGet product = productService.GetProduct(id);
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
            if (product is not null)
                return Ok(product);
            return BadRequest("Not found");
        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            List<ProductToGet> result = productService.GetAll();
            List<ProductToGet> list = new List<ProductToGet>();
            ProductToGet product;
            if (result is not null)
            {
                foreach (ProductToGet item in result)
                {
                    string path = "Images/"+item.Images;
                    FileInfo fileInfo = new FileInfo(path);
                    product = item;
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
                    product.CategoryDetail = cdService.GetCategoryDetail(product.CategoryDetailId);
                    product.Company = companyService.GetCompany(product.CompanyId);

                    list.Add(product);
                }
                return Ok(list);
            }
            return BadRequest("Not found");
        }

        [HttpGet(nameof(GetProductSale))]
        public IActionResult GetProductSale()
        {
            List<ProductToGet> result = productService.GetListProductSale();
            List<ProductToGet> list = new List<ProductToGet>();
            ProductToGet product;
            if (result is not null)
            {
                foreach (ProductToGet item in result)
                {
                    string path = "Images/"+item.Images;
                    FileInfo fileInfo = new FileInfo(path);
                    product = item;
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
                    list.Add(product);
                }
                return Ok(list);
            }
            return BadRequest("Not found");
        }
        [HttpGet(nameof(GetProductLikeSame))]
        public IActionResult GetProductLikeSame(int? cdId, int? companyId)
        {
            List<ProductToGet> result = productService.GetProductLikeSame(cdId, companyId);
            List<ProductToGet> list = new List<ProductToGet>();
            ProductToGet product;
            if (result is not null)
            {
                foreach (ProductToGet item in result)
                {
                    string path = "Images/" + item.Images;
                    FileInfo fileInfo = new FileInfo(path);
                    product = item;
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
                    list.Add(product);
                }
                return Ok(list);
            }
            return BadRequest("Not found");
        }
        [HttpGet(nameof(SearchProduct))]
        public IActionResult SearchProduct(string keyWord)
        {
            List<ProductToGet> result = productService.SearchProduct(keyWord);
            List<ProductToGet> list = new List<ProductToGet>();
            ProductToGet product;
            if (result is not null)
            {
                foreach (ProductToGet item in result)
                {
                    string path = "Images/" + item.Images;
                    FileInfo fileInfo = new FileInfo(path);
                    product = item;
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
                    list.Add(product);
                }
                return Ok(list);
            }
            return BadRequest("Not found");
        }
        [HttpPost(nameof(InsertProduct))]
        public IActionResult InsertProduct(ProductToAdd product)
        {
            if (product.Images.Length > 1)
            {
                byte[] imageBytes = Convert.FromBase64String(product.Images);
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
                product.Images = imgName + ".png";
            }
            else
                product.Images = "default_img.png";
            product.CreatedDate = product.ModifiedDate = DateTime.Now;
            productService.InsertProduct(product);
            return Ok("Insert success!");
        }
        [HttpPut(nameof(UpdateProduct))]
        public IActionResult UpdateProduct(ProductToUpdate product)
        {
            if (product.ImageFile.Length > 5)
            {
                if (System.IO.File.Exists("Image/" + product.Images))
                {
                    System.IO.File.Delete("Image/" + product.Images);
                }
                byte[] imageBytes = Convert.FromBase64String(product.ImageFile);
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
                product.Images = imgName + ".png";
            }

            product.ModifiedDate = DateTime.Now;
            productService.UpdateProduct(product);
            return Ok("Update success!");
        }
        [HttpDelete(nameof(DeleteProduct))]
        public IActionResult DeleteProduct(int id)
        {
            ProductToGet product = productService.GetProduct(id);
            if (product.Images.Length > 2 && product.Images.Equals("default_img.png") == false)
            {
                string path = "Images/" + product.Images;
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
            productService.DeleteProduct(id);
            return Ok("Delete Success!");
        }

    }
}
