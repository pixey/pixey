using Microsoft.AspNetCore.Mvc;
using Pixey.Website.Middlewares;
using Pixey.Website.Payloads;
using Pixey.Website.Services.Troubleshooting;

namespace Pixey.Website.Controllers
{
    [Route("api/v1/diagnostics/troubleshooting")]
    public class TroubleshootingController : Controller
    {
        private readonly ITroubleshootingService _troubleshootingService;

        public TroubleshootingController(
            ITroubleshootingService troubleshootingService)
        {
            _troubleshootingService = troubleshootingService;
        }

        [HttpPost("/api/v1/diagnostics/troubleshooting")]
        public IActionResult StartTroubleshooting()
        {
            if (!Request.Cookies.TryGetValue(SignInUserMiddleware.UserIdCookieName, out var userId))
            {
                return BadRequest("The request did not contain the UserId cookie.");
            }

            var id = _troubleshootingService.StartTroubleshooting(userId);
            var payload = new TroubleshootingIdPayload(id);

            return CreatedAtRoute(nameof(GetTroubleshooting), new { id }, payload);
        }

        [HttpGet("/api/v1/diagnostics/troubleshooting/{id}", Name = nameof(GetTroubleshooting))]
        public ObjectResult GetTroubleshooting(string id)
        {
            try
            {
                var status = _troubleshootingService.GetTroubleshootingStatus(id);

                var payload = TroubleshootingStatusPayload.FromDomain(status);

                return Ok(payload);
            }
            catch (TroubleshooterNotFoundException)
            {
                return NotFound(id);
            }
        }

        [HttpDelete("/api/v1/diagnostics/troubleshooting/{id}")]
        public IActionResult CancelTroubleshooting(string id)
        {
            try
            {
                _troubleshootingService.CancelTroubleshooting(id);

                return Ok();
            }
            catch (TroubleshooterNotFoundException)
            {
                return NotFound(id);
            }
        }
    }
}