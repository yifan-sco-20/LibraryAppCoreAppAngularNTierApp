using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API.Models.Major;

namespace WEB_API.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class MajorController : ControllerBase
    {
        private IMajor_Service _Major_Service;

        public MajorController(IMajor_Service Major_Service)
        {
            _Major_Service = Major_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddMajor(string name)
        {
            var result = await _Major_Service.AddMajor(name);
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
        public async Task<IActionResult> GetAllMajors()
        {
            var result = await _Major_Service.GetAllMajors();
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
        public async Task<IActionResult> UpdateMajor(Major_Pass_Object major)
        {
            var result = await _Major_Service.UpdateMajor(major.id, major.name);
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
        public async Task<IActionResult> DeleteMajor(Major_Pass_Object major)
        {
            var result = await _Major_Service.DeleteMajor(major.id);
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
