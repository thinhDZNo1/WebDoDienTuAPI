using DTOlayer.Collections.Post;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Services.IServices;
using System;
using System.Collections.Generic;
using System.IO;

namespace ThietBiDienTu_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }
        [HttpGet(nameof(GetPost))]
        public IActionResult GetPost(int id)
        {
            PostToGet Post = postService.GetPost(id);
            string path = "Images/" + Post.Image;
            FileInfo fileInfo = new FileInfo(path);
            if (System.IO.File.Exists(path))
            {
                byte[] fileImage = new byte[fileInfo.Length];
                using (FileStream fs = fileInfo.OpenRead())
                {
                    fs.Read(fileImage, 0, fileImage.Length);
                }
                string Base64String = Convert.ToBase64String(fileImage);
                Post.ImageFile = Base64String;
            }
            if (Post is not null)
                return Ok(Post);
            return BadRequest("Not found");
        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            List<PostToGet> result = postService.GetAll();
            List<PostToGet> list = new List<PostToGet>();
            PostToGet post;
            if (result is not null)
            {
                foreach (PostToGet item in result)
                {
                    string path = "Images/" + item.Image;
                    FileInfo fileInfo = new FileInfo(path);
                    post = item;
                    if (System.IO.File.Exists(path))
                    {
                        byte[] fileImage = new byte[fileInfo.Length];
                        using (FileStream fs = fileInfo.OpenRead())
                        {
                            fs.Read(fileImage, 0, fileImage.Length);
                        }
                        string Base64String = Convert.ToBase64String(fileImage);
                        post.ImageFile = Base64String;
                    }
                    list.Add(post);
                }
                return Ok(list);
            }
            return BadRequest("Not found");
        }
        [HttpPost(nameof(InsertPost))]
        public IActionResult InsertPost(PostToAdd post)
        {
            if (post.Image.Length > 1)
            {
                byte[] imageBytes = Convert.FromBase64String(post.Image);
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
                post.Image = imgName + ".png";
            }
            else
                post.Image = "default_img.png";
            post.CreatedDate = post.ModifiedDate = DateTime.Now;
            postService.InsertPost(post);
            return Ok("Insert success!");
        }
        [HttpPut(nameof(UpdatePost))]
        public IActionResult UpdatePost(PostToUpdate post)
        {
            if (post.ImageFile.Length > 5)
            {
                if (System.IO.File.Exists("Image/" + post.Image))
                {
                    System.IO.File.Delete("Image/" + post.Image);
                }
                byte[] imageBytes = Convert.FromBase64String(post.ImageFile);
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
                post.Image = imgName + ".png";
            }

            post.ModifiedDate = DateTime.Now;
            postService.UpdatePost(post);
            return Ok("Update success!");
        }
        [HttpDelete(nameof(DeletePost))]
        public IActionResult DeletePost(int id)
        {
            PostToGet post = postService.GetPost(id);
            if (post.Image.Length > 2 && post.Image.Equals("default_img.png") == false)
            {
                string path = "Images/" + post.Image;
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
            postService.DeletePost(id);
            return Ok("Delete Success!");
        }

    }
}
