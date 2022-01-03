using DomainLayer.Model;
using DTOLayer.Collections.User;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using System.Linq;
using ServicesLayer.Services.IServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DTOlayer.Collections.Cart;

namespace ThietBiDienTu_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices userService;
        private readonly ICartService cartService;
        private readonly ThietBiDienTuDBContext db;

        public UserController(IUserServices userService, ThietBiDienTuDBContext db, ICartService cartService)
        {
            this.userService = userService;
            this.db = db;
            this.cartService = cartService;
        }
        [HttpGet(nameof(GetUser))]
        public IActionResult GetUser(int id)
        {
            UserToGet User = userService.GetUser(id);
            string path = "Images/" + User.Avatar;
            FileInfo fileInfo = new FileInfo(path);
            if (System.IO.File.Exists(path))
            {
                byte[] fileImage = new byte[fileInfo.Length];
                using (FileStream fs = fileInfo.OpenRead())
                {
                    fs.Read(fileImage, 0, fileImage.Length);
                }
                string Base64String = Convert.ToBase64String(fileImage);
                User.ImageFile = Base64String.ToString();
            }
            if (User is not null)
                return Ok(User);
            return BadRequest("Not found");
        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            List<UserToGet> result = userService.GetAll();
            List<UserToGet> list = new List<UserToGet>();
            UserToGet User;
            if (result is not null)
            {
                foreach (UserToGet item in result)
                {
                    string path = "Images/"+item.Avatar;
                    FileInfo fileInfo = new FileInfo(path);
                    User = item;
                    if (System.IO.File.Exists(path))
                    {
                        byte[] fileImage = new byte[fileInfo.Length];
                        using (FileStream fs = fileInfo.OpenRead())
                        {
                            fs.Read(fileImage, 0, fileImage.Length);
                        }
                        string Base64String = Convert.ToBase64String(fileImage);                        
                        User.ImageFile = Base64String.ToString();
                    }
                    UserRole userRoles = db.UserRole.FirstOrDefault(x => x.UserId.Equals(User.Id));
                    Role role = db.Role.FirstOrDefault(x => x.Id.Equals(userRoles.RoleId));
                    User.RoleName = role.Name;
                    list.Add(User);
                }
                return Ok(list);
            }
            return BadRequest("Not found");
        }

       
        [HttpPost(nameof(Insert))]
        public IActionResult Insert(UserToAdd user)
        {
            if (userService.CheckUser(user.UserName) == false)
            {
                user.Avatar = "default_img.png";
                byte[] passByte = Encoding.UTF8.GetBytes(user.Password);
                user.Password = Convert.ToBase64String(passByte).ToString();
                user.CreatedDate = user.ModifiedDate = DateTime.Now;
                userService.InsertUser(user);
                UserToGet users = userService.Login(user.UserName, user.Password);
                UserRole userRole = new UserRole()
                {
                    UserId = users.Id,
                    RoleId = 2
                };
                db.UserRole.Add(userRole);
                db.SaveChanges();
                return Ok("Insert success!");
            }
            return BadRequest("Not Insert");
        }

        [HttpPost(nameof(Register))]
        public IActionResult Register(UserToAdd user)
        {
            if (userService.CheckUser(user.UserName) == false)
            {
                user.Avatar = "default_img.png";
                byte[] passByte = Encoding.UTF8.GetBytes(user.Password);
                user.Password = Convert.ToBase64String(passByte).ToString();
                user.CreatedDate = user.ModifiedDate = DateTime.Now;
                userService.InsertUser(user);
                UserToGet users = userService.Login(user.UserName, user.Password);
                UserRole userRole = new UserRole()
                {
                    UserId = users.Id,
                    RoleId = 3
                };
                db.UserRole.Add(userRole);
                db.SaveChanges();
                CartToAdd cart = new CartToAdd()
                {
                    UserId = users.Id.Value,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    IsActive = true,
                };
                cartService.InsertCart(cart);
                return Ok("Insert success!");
            }
            return BadRequest("Not Insert");
        }

        [HttpGet(nameof(LoginAdmin))]
        public IActionResult LoginAdmin(string username, string password)
        {
            byte[] passByte = Encoding.UTF8.GetBytes(password);
            password = Convert.ToBase64String(passByte).ToString();
            UserToGet user = userService.Login(username, password);
            if (user != null)
            {
                UserRole userRole = db.UserRole.FirstOrDefault(x => x.UserId.Equals(user.Id));
                if (userRole.RoleId == 2 || userRole.RoleId == 1)
                {
                    string path = "Images/" + user.Avatar;
                    FileInfo fileInfo = new FileInfo(path);
                    if (System.IO.File.Exists(path))
                    {
                        byte[] fileImage = new byte[fileInfo.Length];
                        using (FileStream fs = fileInfo.OpenRead())
                        {
                            fs.Read(fileImage, 0, fileImage.Length);
                        }
                        string Base64String = Convert.ToBase64String(fileImage);
                        user.ImageFile = Base64String;
                    }
                    var en = Convert.FromBase64String(user.Password);
                    user.Password = Encoding.UTF8.GetString(en);
                    if (user is not null)
                        return Ok(user);
                }
            }
            return BadRequest("Not found");
        }

        [HttpGet(nameof(LoginCustomer))]
        public IActionResult LoginCustomer(string username, string password)
        {
            byte[] passByte = Encoding.UTF8.GetBytes(password);
            password = Convert.ToBase64String(passByte);
            UserToGet user = userService.Login(username, password);
            if (user != null)
            {
                UserRole userRole = db.UserRole.FirstOrDefault(x => x.UserId.Equals(user.Id));
                if (userRole.RoleId == 3)
                {
                    string path = "Images/" + user.Avatar;
                    FileInfo fileInfo = new FileInfo(path);
                    if (System.IO.File.Exists(path))
                    {
                        byte[] fileImage = new byte[fileInfo.Length];
                        using (FileStream fs = fileInfo.OpenRead())
                        {
                            fs.Read(fileImage, 0, fileImage.Length);
                        }
                        string Base64String = Convert.ToBase64String(fileImage);
                        user.ImageFile = Base64String;
                    }
                    var en = Convert.FromBase64String(user.Password);
                    user.Password = Encoding.UTF8.GetString(en);
                    if (user is not null)
                        return Ok(user);
                }
            }
            return BadRequest("Not found");
        }

        [HttpPut(nameof(UpdateUser))]
        public IActionResult UpdateUser(UserToUpdate User)
        {
            if (User.ImageFile.Length > 5)
            {
                if (System.IO.File.Exists("Image/" + User.Avatar))
                {
                    System.IO.File.Delete("Image/" + User.Avatar);
                }
                byte[] imageBytes = Convert.FromBase64String(User.ImageFile);
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
                User.Avatar = imgName + ".png";
            }

            User.ModifiedDate = DateTime.Now;
            userService.UpdateUser(User);
            return Ok("Update success!");
        }

        [HttpDelete(nameof(DeleteUser))]
        public IActionResult DeleteUser(int id)
        {
            UserToGet user = userService.GetUser(id);
            if (user.Avatar.Length > 2 && user.Avatar.Equals("default_img.png") == false)
            {
                string path = "Images/" + user.Avatar;
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
            UserRole userRole = db.UserRole.FirstOrDefault(x=>x.UserId.Equals(user.Id));
            db.UserRole.Remove(userRole);
            userService.DeleteUser(id);
            return Ok("Delete Success!");
        }

    }
}
