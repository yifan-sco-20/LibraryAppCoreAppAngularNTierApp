using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API.Models.Message;

namespace WEB_API.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private IMessage_Service _Message_Service;

        public MessageController(IMessage_Service Message_Service)
        {
            _Message_Service = Message_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddMessage(string contnet)
        {
            var result = await _Message_Service.AddMessage(contnet);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllMessages()
        {
            var result = await _Message_Service.GetAllMessages();
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> UpdateMessage(Message_Pass_Object message)
        {
            var result = await _Message_Service.UpdateMessage(message.id, message.content);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> DeleteMessage(Message_Pass_Object message)
        {
            var result = await _Message_Service.DeleteMessage(message.id);
            switch (result.success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

    }
}
