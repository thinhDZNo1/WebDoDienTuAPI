using DTOlayer.Collections.Color;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Services.IServices;

namespace ThietBiDienTu_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly IColorService colorService;

        public ColorController(IColorService colorService)
        {
            this.colorService = colorService;
        }
        [HttpGet(nameof(GetColor))]
        public IActionResult GetColor(int id)
        {
            var result = colorService.GetColor(id);
            if (result is not null)
                return Ok(result);
            return BadRequest("Not found");
        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            var result = colorService.GetAll();
            if (result is not null)
                return Ok(result);
            return BadRequest("Not found");
        }
        [HttpPost(nameof(InsertColor))]
        public IActionResult InsertColor(ColorToAdd color)
        {
            colorService.InsertColor(color);
            return Ok("Insert success!");
        }
        [HttpPut(nameof(UpdateColor))]
        public IActionResult UpdateColor(ColorToUpdate color)
        {
            colorService.UpdateColor(color);
            return Ok("Update success!");
        }
        [HttpDelete(nameof(DeleteColor))]
        public IActionResult DeleteColor(int id)
        {
            colorService.DeleteColor(id);
            return Ok("Delete Success!");
        }

    }
}
