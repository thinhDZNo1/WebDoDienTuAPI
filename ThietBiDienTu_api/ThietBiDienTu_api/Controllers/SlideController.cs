using DTOlayer.Collections.Slide;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Services.IServices;
using System;
using System.Collections.Generic;
using System.IO;

namespace ThietBiDienTu_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlideController : ControllerBase
    {
        private readonly ISlideService slideService;

        public SlideController(ISlideService slideService)
        {
            this.slideService = slideService;
        }
        [HttpGet(nameof(GetSlide))]
        public IActionResult GetSlide(int id)
        {
            var result = slideService.GetSlide(id);
            if (result is not null)
                return Ok(result);
            return BadRequest("Not found");
        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            List<SlideToGet> result = slideService.GetAll();
            List<SlideToGet> list = new List<SlideToGet>();
            SlideToGet slide;
            if (result is not null)
            {
                foreach (SlideToGet item in result)
                {
                    string path = "Images/" + item.Image;
                    FileInfo fileInfo = new FileInfo(path);
                    slide = item;
                    if (System.IO.File.Exists(path))
                    {
                        byte[] fileImage = new byte[fileInfo.Length];
                        using (FileStream fs = fileInfo.OpenRead())
                        {
                            fs.Read(fileImage, 0, fileImage.Length);
                        }
                        string Base64String = Convert.ToBase64String(fileImage);
                        slide.ImageFile = Base64String;
                    }
                    list.Add(slide);
                }
                return Ok(list);
            }
            return BadRequest("Not found");
        }
        [HttpPost(nameof(InsertSlide))]
        public IActionResult InsertSlide(SlideToAdd slide)
        {
            if (slide.Image.Length > 1)
            {
                byte[] imageBytes = Convert.FromBase64String(slide.Image);
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
                slide.Image = imgName + ".png";
            }
            else
                slide.Image = "default_img.png";
            slide.CreatedDate = slide.ModifiedDate = DateTime.Now;
            slide.IsActive = true;
            slideService.InsertSlide(slide);
            return Ok("Insert success!");
        }
        [HttpPut(nameof(UpdateSlide))]
        public IActionResult UpdateSlide(SlideToUpdate slide)
        {
            if (slide.ImageFile.Length > 5)
            {
                if (System.IO.File.Exists("Image/" + slide.Image))
                {
                    System.IO.File.Delete("Image/" + slide.Image);
                }
                byte[] imageBytes = Convert.FromBase64String(slide.ImageFile);
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
                slide.Image = imgName + ".png";
            }

            slide.ModifiedDate = DateTime.Now;
            slideService.UpdateSlide(slide);
            return Ok("Update success!");
        }
        [HttpDelete(nameof(DeleteSlide))]
        public IActionResult DeleteSlide(int id)
        {
            SlideToGet slide = slideService.GetSlide(id);
            if (slide.Image.Length > 2 && slide.Image.Equals("default_img.png") == false)
            {
                string path = "Images/" + slide.Image;
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
            slideService.DeleteSlide(id);
            return Ok("Delete Success!");
        }

    }
}
