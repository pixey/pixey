using Microsoft.AspNetCore.Mvc;
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
        public CreatedAtRouteResult StartTroubleshooting()
        {
            var id = _troubleshootingService.StartTroubleshooting("TODO: UserId");
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
            catch (TroubleshootingNotFoundException)
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
            catch (TroubleshootingNotFoundException)
            {
                return NotFound(id);
            }
        }
    }
}