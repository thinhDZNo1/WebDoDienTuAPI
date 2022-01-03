using DTOlayer.Collections.Menu;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Services.IServices;
using System;

namespace ThietBiDienTu_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService menuService;

        public MenuController(IMenuService menuService)
        {
            this.menuService = menuService;
        }
        [HttpGet(nameof(GetMenu))]
        public IActionResult GetMenu(int id)
        {
            var result = menuService.GetMenu(id);
            if (result is not null)
                return Ok(result);
            return BadRequest("Not found");
        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            var result = menuService.GetAll();
            if (result is not null)
                return Ok(result);
            return BadRequest("Not found");
        }
        [HttpPost(nameof(InsertMenu))]
        public IActionResult InsertMenu(MenuToAdd menu)
        {
            menu.CreatedDate = menu.ModifiedDate = DateTime.Now;
            menuService.InsertMenu(menu);
            return Ok("Insert success!");
        }
        [HttpPut(nameof(UpdateMenu))]
        public IActionResult UpdateMenu(MenuToUpdate menu)
        {
            menuService.UpdateMenu(menu);
            return Ok("Update success!");
        }
        [HttpDelete(nameof(DeleteMenu))]
        public IActionResult DeleteMenu(int id)
        {
            menuService.DeleteMenu(id);
            return Ok("Delete Success!");
        }

    }
}
