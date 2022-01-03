using DTOlayer.Collections.CategoryDetail;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Services.IServices;
using System;
using System.Collections.Generic;
using System.IO;

namespace ThietBiDienTu_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryDetailController : ControllerBase
    {
        private readonly ICategoryDetailService categoryDetailService;
        private readonly ICategoryService categoryService;

        public CategoryDetailController(ICategoryDetailService categoryDetailService, ICategoryService categoryService)
        {
            this.categoryDetailService = categoryDetailService;
            this.categoryService = categoryService;
        }
        [HttpGet(nameof(GetCategoryDetail))]
        public IActionResult GetCategoryDetail(int id)
        {
            var result = categoryDetailService.GetCategoryDetail(id);
            if (result is not null)
                return Ok(result);
            return BadRequest("Not found");
        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            List<CategoryDetailToGet> result = categoryDetailService.GetAll();
            List<CategoryDetailToGet> list = new List<CategoryDetailToGet>();
            CategoryDetailToGet categoryDetail;
            if (result is not null)
            {
                foreach (CategoryDetailToGet item in result)
                {
                    string path = "Images/" + item.Icon;
                    FileInfo fileInfo = new FileInfo(path);
                    categoryDetail = item;
                    if (System.IO.File.Exists(path))
                    {
                        byte[] fileImage = new byte[fileInfo.Length];
                        using (FileStream fs = fileInfo.OpenRead())
                        {
                            fs.Read(fileImage, 0, fileImage.Length);
                        }
                        string Base64String = Convert.ToBase64String(fileImage);
                        categoryDetail.ImageFile = Base64String;
                    }
                    categoryDetail.Category = categoryService.GetCategory(item.CategoryId);
                    list.Add(categoryDetail);
                }
                return Ok(list);
            }
            return BadRequest("Not found");
        }
        [HttpPost(nameof(InsertCategoryDetail))]
        public IActionResult InsertCategoryDetail(CategoryDetailToAdd categoryDetail)
        {
            if (categoryDetail.Icon.Length > 1)
            {
                byte[] imageBytes = Convert.FromBase64String(categoryDetail.Icon);
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
                categoryDetail.Icon = imgName + ".png";
            }
            else
                categoryDetail.Icon = "default_img.png";
            categoryDetail.CreatedDate = categoryDetail.ModifiedDate = DateTime.Now;
            categoryDetailService.InsertCategoryDetail(categoryDetail);
            return Ok("Insert success!");
        }
        [HttpPut(nameof(UpdateCategoryDetail))]
        public IActionResult UpdateCategoryDetail(CategoryDetailToUpdate categoryDetail)
        {
            if (categoryDetail.ImageFile.Length > 5)
            {
                if (System.IO.File.Exists("Image/" + categoryDetail.Icon))
                {
                    System.IO.File.Delete("Image/" + categoryDetail.Icon);
                }
                byte[] imageBytes = Convert.FromBase64String(categoryDetail.ImageFile);
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
                categoryDetail.Icon = imgName + ".png";
            }

            categoryDetail.ModifiedDate = DateTime.Now;
            categoryDetailService.UpdateCategoryDetail(categoryDetail);
            return Ok("Update success!");
        }
        [HttpDelete(nameof(DeleteCategoryDetail))]
        public IActionResult DeleteCategoryDetail(int id)
        {
            CategoryDetailToGet category = categoryDetailService.GetCategoryDetail(id);
            if (category.Icon.Length > 2 && category.Icon.Equals("default_img.png") == false)
            {
                string path = "Images/" + category.Icon;
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
            categoryDetailService.DeleteCategoryDetail(id);
            return Ok("Delete Success!");
        }

    }
}
