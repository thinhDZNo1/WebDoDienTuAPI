using DTOlayer.Collections.Message;
using Microsoft.AspNetCore.Mvc;
using ServicesLayer.Services.IServices;

namespace ThietBiDienTu_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService messageService;

        public MessageController(IMessageService messageService)
        {
            this.messageService = messageService;
        }
        [HttpGet(nameof(GetMessage))]
        public IActionResult GetMessage(int id)
        {
            var result = messageService.GetMessage(id);
            if (result is not null)
                return Ok(result);
            return BadRequest("Not found");
        }

        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            var result = messageService.GetAll();
            if (result is not null)
                return Ok(result);
            return BadRequest("Not found");
        }
        [HttpPost(nameof(InsertMessage))]
        public IActionResult InsertMessage(MessageToAdd message)
        {
            messageService.InsertMessage(message);
            return Ok("Insert success!");
        }
        [HttpPut(nameof(UpdateMessage))]
        public IActionResult UpdateMessage(MessageToUpdate message)
        {
            messageService.UpdateMessage(message);
            return Ok("Update success!");
        }
        [HttpDelete(nameof(DeleteMessage))]
        public IActionResult DeleteMessage(int id)
        {
            messageService.DeleteMessage(id);
            return Ok("Delete Success!");
        }

    }
}
