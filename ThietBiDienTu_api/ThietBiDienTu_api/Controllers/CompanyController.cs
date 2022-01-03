using DTOlayer.Collections.Company;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Services.IServices;
using System;
using System.Collections.Generic;
using System.IO;

namespace ThietBiDienTu_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }
        [HttpGet(nameof(GetCompany))]
        public IActionResult GetCompany(int id)
        {
            var result = companyService.GetCompany(id);
            if (result is not null)
                return Ok(result);
            return BadRequest("Not found");
        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            List<CompanyToGet> result = companyService.GetAll();
            List<CompanyToGet> list = new List<CompanyToGet>();
            CompanyToGet company;
            if (result is not null)
            {
                foreach (CompanyToGet item in result)
                {
                    string path = "Images/" + item.Logo;
                    FileInfo fileInfo = new FileInfo(path);
                    company = item;
                    if (System.IO.File.Exists(path))
                    {
                        byte[] fileImage = new byte[fileInfo.Length];
                        using (FileStream fs = fileInfo.OpenRead())
                        {
                            fs.Read(fileImage, 0, fileImage.Length);
                        }
                        string Base64String = Convert.ToBase64String(fileImage);
                        company.ImageFile = Base64String;
                    }
                    list.Add(company);
                }
                return Ok(list);
            }
            return BadRequest("Not found");
        }
        [HttpPost(nameof(InsertCompany))]
        public IActionResult InsertCompany(CompanyToAdd company)
        {
            if (company.Logo.Length > 1)
            {
                byte[] imageBytes = Convert.FromBase64String(company.Logo);
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
                company.Logo = imgName + ".png";
            }
            else
                company.Logo = "default_img.png";
            company.CreatedDate = company.ModifiedDate = DateTime.Now;
            companyService.InsertCompany(company);
            return Ok("Insert success!");
        }
        [HttpPut(nameof(UpdateCompany))]
        public IActionResult UpdateCompany(CompanyToUpdate company)
        {
            if (company.ImageFile.Length > 5)
            {
                if (System.IO.File.Exists("Image/" + company.Logo))
                {
                    System.IO.File.Delete("Image/" + company.Logo);
                }
                byte[] imageBytes = Convert.FromBase64String(company.ImageFile);
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
                company.Logo = imgName + ".png";
            }
            company.ModifiedDate = DateTime.Now;
            companyService.UpdateCompany(company);
            return Ok("Update success!");
        }
        [HttpDelete(nameof(DeleteCompany))]
        public IActionResult DeleteCompany(int id)
        {
            CompanyToGet company = companyService.GetCompany(id);
            if (company.Logo.Length > 2 && company.Logo.Equals("default_img.png") == false)
            {
                string path = "Images/" + company.Logo;
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);
                }
            }
            companyService.DeleteCompany(id);
            return Ok("Delete Success!");
        }

    }
}
