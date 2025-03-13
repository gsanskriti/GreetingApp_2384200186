using businessLayer.@interface;
using Microsoft.AspNetCore.Mvc;
using modelLayer.model;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelloGreetingApplication.Controllers
{
    /// <summary>
    /// Controller providing API for Hello Greeting operations.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class GreetingAppController : ControllerBase
    {
        private readonly ILogger<GreetingAppController> _logger;
        private readonly IGreetingAppBL _greetingBL;

        /// <summary>
        /// Constructor with dependency injection for logger and business layer.
        /// </summary>
        /// <param name="logger">Logger instance</param>
        /// <param name="greetingBL">Business logic layer instance</param>
        public GreetingAppController(ILogger<GreetingAppController> logger, IGreetingAppBL greetingBL)
        {
            _logger = logger;
            _greetingBL = greetingBL;
        }

        /// <summary>
        /// GET method to retrieve all greeting messages.
        /// </summary>
        /// <returns>List of greeting messages</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllGreetings()
        {
            _logger.LogInformation("GET request received for fetching all greetings.");

            var greetings = await _greetingBL.GetAllGreetings();

            return Ok(new ResponseModel<List<UserModel>>
            {
                Success = true,
                Message = "All greetings retrieved successfully.",
                Data = greetings
            });
        }

        /// <summary>
        /// GET method to retrieve a specific greeting message by ID.
        /// </summary>
        /// <param name="id">Unique identifier of the greeting</param>
        /// <returns>Greeting message</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGreetingById(int id)
        {
            _logger.LogInformation($"GET request received for Greeting ID: {id}");

            var greeting = await _greetingBL.GetGreetingById(id);
            if (greeting == null)
            {
                _logger.LogWarning($"Greeting with ID {id} not found.");
                return NotFound(new ResponseModel<string>
                {
                    Success = false,
                    Message = "Greeting not found."
                });
            }

            return Ok(new ResponseModel<UserModel>
            {
                Success = true,
                Message = "Greeting retrieved successfully.",
                Data = greeting
            });
        }

        /// <summary>
        /// POST method to create a new greeting message.
        /// </summary>
        /// <param name="userModel">User input model containing greeting details</param>
        /// <returns>Response containing the created greeting</returns>
        [HttpPost("Custom")]
        public async Task<IActionResult> Post(UserModel userModel)
        {
            _logger.LogInformation("POST request received to create a greeting.");

            var greetingMessage = await _greetingBL.GreetingMessage(userModel);

            return Ok(new ResponseModel<string>
            {
                Success = true,
                Message = "Greeting created successfully.",
                Data = greetingMessage
            });
        }

        /// <summary>
        /// PUT method to update an existing greeting.
        /// </summary>
        /// <param name="id">Unique identifier of the greeting</param>
        /// <param name="userModel">Updated user model</param>
        /// <returns>Response containing the updated greeting</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UserModel userModel)
        {
            _logger.LogInformation($"PUT request received to update Greeting ID: {id}");

            var updatedGreeting = await _greetingBL.UpdateGreeting(id, userModel);
            if (updatedGreeting == null)
            {
                _logger.LogWarning($"Greeting with ID {id} not found for update.");
                return NotFound(new ResponseModel<string>
                {
                    Success = false,
                    Message = "Greeting not found."
                });
            }

            return Ok(new ResponseModel<UserModel>
            {
                Success = true,
                Message = "Greeting updated successfully.",
                Data = updatedGreeting
            });
        }

        /// <summary>
        /// PATCH method to partially update the greeting message.
        /// </summary>
        /// <param name="id">Unique identifier of the greeting</param>
        /// <param name="newValue">New greeting message value</param>
        /// <returns>Response containing the updated greeting</returns>
        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch(int id, [FromBody] string newValue)
        {
            _logger.LogInformation($"PATCH request received for Greeting ID: {id}");

            var existingGreeting = await _greetingBL.GetGreetingById(id);
            if (existingGreeting == null)
            {
                _logger.LogWarning($"Greeting with ID {id} not found for patch update.");
                return NotFound(new ResponseModel<string>
                {
                    Success = false,
                    Message = "Greeting not found."
                });
            }

            existingGreeting.LastName = newValue; // Assuming LastName holds the greeting message
            var updatedGreeting = await _greetingBL.UpdateGreeting(id, existingGreeting);

            return Ok(new ResponseModel<UserModel>
            {
                Success = true,
                Message = "Greeting partially updated successfully.",
                Data = updatedGreeting
            });
        }

        /// <summary>
        /// DELETE method to remove a greeting.
        /// </summary>
        /// <param name="id">Unique identifier of the greeting</param>
        /// <returns>Response indicating success or failure</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation($"DELETE request received for Greeting ID: {id}");

            var isDeleted = await _greetingBL.DeleteGreeting(id);
            if (!isDeleted)
            {
                _logger.LogWarning($"Greeting with ID {id} not found for deletion.");
                return NotFound(new ResponseModel<string>
                {
                    Success = false,
                    Message = "Greeting not found."
                });
            }

            return Ok(new ResponseModel<string>
            {
                Success = true,
                Message = "Greeting deleted successfully."
            });
        }
    }
}
