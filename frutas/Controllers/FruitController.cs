using FrutasApi.Dtos.Fruits;
using FrutasApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrutasApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("fruits")]
    public class FruitController : ControllerBase
    {
        private readonly IFruitService _fruitService;

        public FruitController(IFruitService fruitService)
        {
            _fruitService=fruitService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_fruitService.Get(id));
        }

        [HttpGet("list")]
        public IActionResult GetList()
        {
            return Ok(_fruitService.GetList());
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] CreateUpdateFruitDto input)
        {
            return Ok(_fruitService.Update(id, input));
        }

        [HttpPost]
        public IActionResult Post(CreateUpdateFruitDto input)
        {
            return Ok(_fruitService.Create(input));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _fruitService.Delete(id);
            return Ok("registro eliminado correctamente");
        }
    }
}
