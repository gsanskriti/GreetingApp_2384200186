using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using modelLayer.model;

namespace HelloGreetingApplication.Controllers
{
    /// <summary>
    /// Class providing API for HelloGreeting
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class GreetingAppController : ControllerBase
    {
        private readonly ILogger<GreetingAppController> _logger;
        ///<summary>
        ///dependency with logger
        ///</summary>
        ///<returns>logger</returns>

        public GreetingAppController(ILogger<GreetingAppController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// GET method to retrieve the greeting message
        /// </summary>
        /// <returns>A greeting message</returns>
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("GET request received for GreetingAppController.");

            ResponseModel<string> responseModel = new ResponseModel<string>
            {
                Success = true,
                Message = "Hello to Greeting App API Endpoint",
                Data = "Hello, World!"
            };

            _logger.LogInformation("GET response sent successfully.");
            return Ok(responseModel);
        }

        /// <summary>
        /// POST method to receive a custom greeting message
        /// </summary>
        /// <param name="greeting">Custom greeting message</param>
        /// <returns>Response with the received message</returns>
        [HttpPost]
        public IActionResult Post([FromBody] string greeting)
        {
            if (string.IsNullOrEmpty(greeting))
            {
                _logger.LogWarning("POST request failed: Greeting message is empty.");
                return BadRequest(new ResponseModel<string>
                {
                    Success = false,
                    Message = "Greeting message cannot be empty.",
                    Data = null
                });
            }

            _logger.LogInformation("POST request received with message: {Greeting}", greeting);

            ResponseModel<string> responseModel = new ResponseModel<string>
            {
                Success = true,
                Message = "Greeting message received successfully",
                Data = greeting
            };

            return Ok(responseModel);
        }

        /// <summary>
        /// PUT method to update an existing greeting
        /// </summary>
        /// <param name="updatedGreeting">Updated greeting message</param>
        /// <returns>Updated response</returns>
        [HttpPut]
        public IActionResult Put([FromBody] string updatedGreeting)
        {
            if (string.IsNullOrEmpty(updatedGreeting))
            {
                _logger.LogWarning("PUT request failed: Updated greeting message is empty.");

                return BadRequest(new ResponseModel<string>
                {
                    Success = false,
                    Message = "Updated greeting message cannot be empty.",
                    Data = null
                });
            }
            _logger.LogInformation("PUT request received with updated message: {UpdatedGreeting}", updatedGreeting);

            return Ok(new ResponseModel<string>
            {
                Success = true,
                Message = "Greeting message updated successfully",
                Data = updatedGreeting
            });
        }

        /// <summary>
        /// PATCH method to partially update the greeting
        /// </summary>
        /// <param name="partialUpdate">Partial update to greeting message</param>
        /// <returns>Partially updated greeting</returns>
        [HttpPatch]
        public IActionResult Patch([FromBody] string partialUpdate)
        {
            if (string.IsNullOrEmpty(partialUpdate))
            {
                _logger.LogWarning("PATCH request failed: Partial update message is empty.");

                return BadRequest(new ResponseModel<string>
                {
                    Success = false,
                    Message = "Partial update cannot be empty.",
                    Data = null
                });
            }

            _logger.LogInformation("PATCH request received with partial update: {PartialUpdate}", partialUpdate);

            return Ok(new ResponseModel<string>
            {
                Success = true,
                Message = "Greeting message partially updated",
                Data = partialUpdate
            });
        }

        /// <summary>
        /// DELETE method to remove a greeting
        /// </summary>
        /// <returns>Success message</returns>
        [HttpDelete]
        public IActionResult Delete()
        {
            _logger.LogInformation("DELETE request received ");

            return Ok(new ResponseModel<string>
            {
                Success = true,
                Message = "Greeting message deleted successfully",
                Data = null
            });
        }
    }
}
