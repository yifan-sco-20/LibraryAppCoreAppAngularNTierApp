using LOGIC.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_API.Models.Unit;

namespace WEB_API.Controllers
{
    [EnableCors("angular")]
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private IUnit_Service _Unit_Service;

        public UnitController(IUnit_Service Unit_Service)
        {
            _Unit_Service = Unit_Service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddUnit(string name)
        {
            var result = await _Unit_Service.AddUnit(name);
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
        public async Task<IActionResult> GetAllUnits()
        {
            var result = await _Unit_Service.GetAllUnits();
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
        public async Task<IActionResult> UpdateUnit(Unit_Pass_Object unit)
        {
            var result = await _Unit_Service.UpdateUnit(unit.id, unit.name);
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
        public async Task<IActionResult> DeleteUnit(Unit_Pass_Object unit)
        {
            var result = await _Unit_Service.DeleteUnit(unit.id);
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
