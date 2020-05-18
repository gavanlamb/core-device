using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Devices.Api.Models.DTO;
using Core.Devices.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Core.Devices.Api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserDevice : ControllerBase
    {
        private readonly IUserDeviceService _userDeviceService;

        public UserDevice(
            IUserDeviceService userDeviceService)
        {
            _userDeviceService = userDeviceService;
        }

        [HttpPost("device")]
        public async Task<ActionResult<Models.DTO.UserDevice>> Post(
            [FromBody] CreateUserDevice userDevice,
            CancellationToken cancellationToken)
        {
            var userId = "GET FROM JWT";
            var tenantId = "GET FROM JWT";

            return await _userDeviceService.Create(
                userDevice,
                userId,
                tenantId,
                cancellationToken);
        }

        [HttpDelete("device/{id}")]
        public async Task<ActionResult> Delete(
            [FromRoute] string id,
            CancellationToken cancellationToken)
        {
            var userId = "GET FROM JWT";

            var deletedUserDevice = await _userDeviceService.Delete(
                id,
                userId,
                cancellationToken);

            return Ok(deletedUserDevice);
        }

        [HttpPut("device/{id}")]
        public async Task<ActionResult<Models.DTO.UserDevice>> Put(
            [FromRoute] string id,
            [FromBody] UpdateUserDevice userDevice,
            CancellationToken cancellationToken)
        {
            var userId = "GET FROM JWT";

            var updatedDevice = await _userDeviceService.Update(
                id,
                userDevice,
                userId,
                cancellationToken);

            return Ok(updatedDevice);
        }


        [HttpGet("devices")]
        public async Task<ActionResult<IEnumerable<Models.DTO.UserDevice>>> Items(
            CancellationToken cancellationToken)
        {
            var userId = "GET FROM JWT";

            var userDevices = await _userDeviceService.Fetch(
                userId,
                cancellationToken);

            return Ok(userDevices);
        }
    }
}