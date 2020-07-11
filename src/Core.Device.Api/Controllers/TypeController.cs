using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Device.Api.Models.DTO;
using Core.Device.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Core.Device.Api.Controllers
{
    [ApiController]
    [Route("api/device")]
    public class TypeController : ControllerBase
    {
        private readonly ITypeService _typeService;

        public TypeController(
            ITypeService typeService)
        {
            _typeService = typeService;
        }

        [HttpPost("type")]
        public async Task<ActionResult<Type>> Post(
            [FromBody] CreateType type,
            CancellationToken cancellationToken)
        {
            var tenantId = "GET FROM JWT";
            return await _typeService.Create(
                type,
                tenantId,
                cancellationToken);
        }

        [HttpDelete("type/{id}")]
        public async Task<ActionResult<Type>> Delete(
            [FromRoute] string id,
            CancellationToken cancellationToken)
        {
            var tenantId = "GET FROM JWT";
            var deletedType = await _typeService.Delete(
                id,
                tenantId,
                cancellationToken);

            return Ok(deletedType);
        }

        [HttpPut("type/{id}")]
        public async Task<ActionResult<Type>> Put(
            [FromRoute] string id,
            [FromBody] UpdateType device,
            CancellationToken cancellationToken)
        {
            var tenantId = "GET FROM JWT";
            var updatedType = await _typeService.Update(
                id,
                tenantId,
                device,
                cancellationToken);

            return Ok(updatedType);
        }
        
        [HttpGet("type/{id}")]
        public async Task<ActionResult<Type>> Get(
            [FromRoute] string id,
            CancellationToken cancellationToken)
        {
            var tenantId = "GET FROM JWT";
            var type = await _typeService.Get(
                id,
                tenantId,
                cancellationToken);

            return Ok(type);
        }
        
        [HttpGet("types")]
        public async Task<ActionResult<IEnumerable<Type>>> Fetch(
            CancellationToken cancellationToken)
        {
            var tenantId = "GET FROM JWT";
            var types = await _typeService.Fetch(
                tenantId,
                cancellationToken);

            return Ok(types);
        }
    }
}