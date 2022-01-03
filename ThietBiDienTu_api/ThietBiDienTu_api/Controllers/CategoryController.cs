using DTOlayer.Collections.Category;
using DTOlayer.Collections.Product;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using ServicesLayer.Services.IServices;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace ThietBiDienTu_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;

        public CategoryController(ICategoryService categoryService, IProductService productService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
        }
        [HttpGet(nameof(GetCategory))]
        public IActionResult GetCategory(int id)
        {
            var result = categoryService.GetCategory(id);
            if (result is not null)
                return Ok(result);
            return BadRequest("Not found");
        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            List<CategoryToGet> result = categoryService.GetAll();
            List<CategoryToGet> list = new List<CategoryToGet>();
            CategoryToGet category;
            if (result is not null)
            {
                foreach (CategoryToGet item in result)
                {
                    string path = "Images/" + item.Icon;
                    FileInfo fileInfo = new FileInfo(path);
                    category = item;
                    if (System.IO.File.Exists(path))
                    {
                        byte[] fileImage = new byte[fileInfo.Length];
                        using (FileStream fs = fileInfo.OpenRead())
                        {
                            fs.Read(fileImage, 0, fileImage.Length);
                        }
                        string Base64String = Convert.ToBase64String(fileImage);
                        category.ImageFile = Base64String;
                    }
                    list.Add(category);
                }
                return Ok(list);
            }
            return BadRequest("Not found");
        }

        [HttpGet(nameof(GetProductWithCategory))]
        public IActionResult GetProductWithCategory()
        {
            List<CategoryToGet> result = categoryService.GetAll();
            List<CategoryToGet> list = new List<CategoryToGet>();
            CategoryToGet category;
            ProductToGet products;
            if (result is not null)
            {
                foreach (CategoryToGet item in result)
                {
                    string path = "Images/" + item.Icon;
                    FileInfo fileInfo = new FileInfo(path);
                    category = item;
                    if (System.IO.File.Exists(path))
                    {
                        byte[] fileImage = new byte[fileInfo.Length];
                        using (FileStream fs = fileInfo.OpenRead())
                        {
                            fs.Read(fileImage, 0, fileImage.Length);
                        }
                        string Base64String = Convert.ToBase64String(fileImage);
                        category.ImageFile = Base64String;
                    }
                    item.Product = productService.GetProductWithCategory(item.Id);
                    List<ProductToGet> lproducts = new List<ProductToGet>();
                    foreach (ProductToGet product in item.Product)
                    {
                        FileInfo fileInfoProduct = new FileInfo("Images/" + product.Images);
                        products = product;
                        if (System.IO.File.Exists("Images/" + product.Images))
                        {

                            byte[] fileImage = new byte[fileInfoProduct.Length];
                            using (FileStream fs = fileInfoProduct.OpenRead())
                            {
                                fs.Read(fileImage, 0, fileImage.Length);
                            }
                            string Base64String = Convert.ToBase64String(fileImage);
                            products.ImageFile = Base64String;
                        }
                        lproducts.Add(products);
                    }
                    category.Product = lproducts;
                    list.Add(category);
                }
                return Ok(list);
            }
            return BadRequest("Not found");
        }
        [HttpPost(nameof(InsertCategory))]
        public IActionResult InsertCategory(CategoryToAdd category)
        {
            if (category.Icon.Length > 1)
            {
                byte[] imageBytes = Convert.FromBase64String(category.Icon);
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
                category.Icon = imgName + ".png";
            }
            else
                category.Icon = "default_img.png";
            category.CreatedDate = category.ModifiedDate = DateTime.Now;
            categoryService.InsertCategory(category);
            return Ok("Insert success!");
        }
        [HttpPut(nameof(UpdateCategory))]
        public IActionResult UpdateCategory(CategoryToUpdate category)
        {
            if (category.ImageFile.Length > 5)
            {
                if (System.IO.File.Exists("Image/" + category.Icon))
                {
                    System.IO.File.Delete("Image/" + category.Icon);
                }
                byte[] imageBytes = Convert.FromBase64String(category.ImageFile);
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
                category.Icon = imgName + ".png";
            }

            category.ModifiedDate = DateTime.Now;
            categoryService.UpdateCategory(category);
            return Ok("Update success!");
        }
        [HttpDelete(nameof(DeleteCategory))]
        public IActionResult DeleteCategory(int id)
        {
            CategoryToGet category = categoryService.GetCategory(id);
            if (category.Icon.Length > 2 && category.Icon.Equals("default_img.png") == false)
            {
                string path = "Images/" + category.Icon;
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
            categoryService.DeleteCategory(id);
            return Ok("Delete Success!");
        }

    }
}
