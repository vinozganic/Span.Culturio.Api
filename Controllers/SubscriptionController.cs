using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Span.Culturio.Api.Models.Subscriptions;
using Span.Culturio.Api.Services.Subscriptions;

namespace Span.Culturio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionController(ISubscriptionService subscriptionService) {
            _subscriptionService = subscriptionService;
        }
        /// <summary>
        /// Create a subscription
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<SubscriptionDto>> CreateAsync(CreateSubscriptionDto createSubscriptionDto) {
            var subscription = await _subscriptionService.CreateAsync(createSubscriptionDto);
            if (subscription is null) return BadRequest("Subscription could not be created");
            return Ok(subscription);
        }
        /// <summary>
        /// Get user subscriptions
        /// </summary>
        [HttpGet("{userId}")]
        public async Task<ActionResult<SubscriptionDto>> GetAsync(int userId) {
            var subscription = await _subscriptionService.GetAsync(userId);
            if (subscription is null) return BadRequest("Subscription could not be found");
            return Ok(subscription);
        }

        /// <summary>
        /// Track single visit
        /// </summary>
        [HttpPost("track-visit")]
        public async Task<ActionResult<string>> TrackVisit(TrackVisitDto trackVisitDto) {
            var result = await _subscriptionService.TrackVisit(trackVisitDto);
            switch (result) {
                case "SubscriptionNotFound":
                    return BadRequest("Subscription could not be found");
                case "SubscriptionNotActive":
                    return BadRequest("Subscription is inactive");
                case "VisitNotFound":
                    return BadRequest("Subscription with that culture object does not exist");
                case "NoVisitsLeft":
                    return BadRequest("No visits left");
                case "VisitTracked":
                    return Ok("Visit has been tracked");
                default:
                    return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        /// <summary>
        /// Activate subscription
        /// </summary>
        [HttpPost("activate")]
        public async Task<ActionResult<string>> Activate(ActivateDto activateDto) {
            var result = await _subscriptionService.Activate(activateDto);
            switch (result) {
                case "SubscriptionNotFound":
                    return BadRequest("Subscription could not be found");
                case "SubscriptionAlreadyActive":
                    return BadRequest("Subscription is already active");
                case "SubscriptionActivated":
                    return Ok("Subscription has been activated");
                default:
                    return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
