using businessLayer.@interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using repositoryLayer.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloGreetingApplication.Controllers
{
    /// <summary>
    /// Controller providing API endpoints for managing greeting messages.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class GreetingAppController : ControllerBase
    {
        private readonly ILogger<GreetingAppController> _logger;
        private readonly IGreetingAppBL _greetingBL;

        /// <summary>
        /// Constructor for injecting logger and business logic layer.
        /// </summary>
        /// <param name="logger">Logger instance</param>
        /// <param name="greetingBL">Business logic layer instance</param>
        public GreetingAppController(ILogger<GreetingAppController> logger, IGreetingAppBL greetingBL)
        {
            _logger = logger;
            _greetingBL = greetingBL;
        }

        /// <summary>
        /// Retrieves all greeting messages.
        /// </summary>
        /// <returns>List of all greeting messages</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllGreetings()
        {
            _logger.LogInformation("Fetching all greetings.");
            var greetings = await _greetingBL.GetAllGreetings();
            return Ok(greetings);
        }

        /// <summary>
        /// Retrieves a specific greeting message by its key.
        /// </summary>
        /// <param name="key">Unique key of the greeting</param>
        /// <returns>Greeting message</returns>
        [HttpGet("{key}")]
        public async Task<IActionResult> GetGreetingByKey(string key)
        {
            _logger.LogInformation($"Fetching greeting with key: {key}");
            var greeting = await _greetingBL.GetGreetingById(key);
            if (greeting == null)
                return NotFound($"Greeting with key {key} not found.");
            return Ok(greeting);
        }

        /// <summary>
        /// Creates a new greeting message.
        /// </summary>
        /// <param name="greetingEntity">Greeting entity containing message details</param>
        /// <returns>Created greeting message</returns>
        [HttpPost]
        public async Task<IActionResult> CreateGreeting([FromBody] HelloGreetingEntity greetingEntity)
        {
            _logger.LogInformation("Creating a new greeting.");
            var createdGreeting = await _greetingBL.GreetingMessage(HelloGreetingEntity);
            return Ok(createdGreeting);
        }

        /// <summary>
        /// Updates an existing greeting message.
        /// </summary>
        /// <param name="key">Unique key of the greeting</param>
        /// <param name="newValue">New value of the greeting message</param>
        /// <returns>Response indicating update status</returns>
        [HttpPut("{key}")]
        public async Task<IActionResult> UpdateGreeting(string key, [FromBody] string newValue)
        {
            _logger.LogInformation($"Updating greeting with key: {key}");
            var isUpdated = await _greetingBL.UpdateGreeting(key, newValue);
            if (!isUpdated)
                return NotFound($"Greeting with key {key} not found for update.");
            return Ok("Greeting updated successfully.");
        }

        /// <summary>
        /// Partially updates an existing greeting message.
        /// </summary>
        /// <param name="key">Unique key of the greeting</param>
        /// <param name="newValue">New value of the greeting message</param>
        /// <returns>Response indicating partial update status</returns>
        [HttpPatch("{key}")]
        public async Task<IActionResult> PatchGreeting(string key, [FromBody] string newValue)
        {
            _logger.LogInformation($"Patching greeting with key: {key}");
            var isUpdated = await _greetingBL.UpdateGreeting(key, newValue);
            if (!isUpdated)
                return NotFound($"Greeting with key {key} not found for update.");
            return Ok("Greeting partially updated successfully.");
        }

        /// <summary>
        /// Deletes a greeting message.
        /// </summary>
        /// <param name="key">Unique key of the greeting</param>
        /// <returns>Response indicating deletion status</returns>
        [HttpDelete("{key}")]
        public async Task<IActionResult> DeleteGreeting(string key)
        {
            _logger.LogInformation($"Deleting greeting with key: {key}");
            var isDeleted = await _greetingBL.DeleteGreeting(key);
            if (!isDeleted)
                return NotFound($"Greeting with key {key} not found for deletion.");
            return Ok("Greeting deleted successfully.");
        }
    }
}
