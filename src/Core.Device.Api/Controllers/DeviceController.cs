using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Device.Api.Models.DTO;
using Core.Device.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Core.Device.Api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        public DeviceController(
            IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpPost("device")]
        public async Task<ActionResult<Models.DTO.Device>> Post(
            [FromBody] RegisterDevice device,
            CancellationToken cancellationToken)
        {
            var userId = "GET FROM JWT";
            var tenantId = "GET FROM JWT";
            return await _deviceService.Create(
                userId,
                tenantId,
                device,
                cancellationToken);
        }

        [HttpDelete("device/{id}")]
        public async Task<ActionResult<Models.DTO.Device>> Delete(
            [FromRoute] string id,
            CancellationToken cancellationToken)
        {
            var userId = "GET FROM JWT";
            var deletedDevice = await _deviceService.Delete(
                id,
                userId,
                cancellationToken);

            return Ok(deletedDevice);
        }

        [HttpPut("device/{id}")]
        public async Task<ActionResult<Models.DTO.Device>> Put(
            [FromRoute] string id,
            [FromBody] UpdateDevice device,
            CancellationToken cancellationToken)
        {
            var userId = "GET FROM JWT";
            var tenantId = "GET FROM JWT";
            var updatedDevice = await _deviceService.Update(
                id,
                userId,
                tenantId,
                device,
                cancellationToken);

            return Ok(updatedDevice);
        }

        [HttpGet("devices")]
        public async Task<ActionResult<IEnumerable<Models.DTO.Device>>> Fetch(
            CancellationToken cancellationToken)
        {
            var userId = "GET FROM JWT";
            var devices = await _deviceService.Fetch(
                userId,
                cancellationToken);

            return Ok(devices);
        }
    }
}