using businessLayer.@interface;
using Microsoft.AspNetCore.Mvc;
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
        private IGreetingAppBL _greetingBL;

        ///<summary>
        ///dependency with logger
        ///</summary>
        ///<returns>logger</returns>

        public GreetingAppController(ILogger<GreetingAppController> logger, IGreetingAppBL greetingBL)
        {
            _logger = logger;
            _greetingBL = greetingBL;
        }

        /// <summary>
        /// GET method to retrieve the greeting message
        /// </summary>
        /// <returns>A greeting message</returns>
        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("GET request received for GreetingAppController.");
            var greetingMessage = _greetingBL.HelloMessage();

            ResponseModel<string> responseModel = new ResponseModel<string>
            {
                Success = true,
                Message = "Hello to Greeting App API Endpoint",
                Data = greetingMessage
            };

            _logger.LogInformation("GET response sent successfully.");
            return Ok(responseModel);
        }

        /// <summary>
        /// POST method to receive a custom greeting message
        /// </summary>
        /// <param name="userModel">Custom greeting message</param>
        /// <returns>Response with the received message</returns>
        [HttpPost("Custom")]
        public IActionResult Post(UserModel userModel)
        {
            
            _logger.LogInformation("POST request received with message:");

            var greetingMessage = _greetingBL.GreetingMessage(userModel);
            ResponseModel<string> responseModel = new()
            {
                Success = true,
                Message = "Request received successfully",
                Data = greetingMessage
            };

            return Ok(responseModel);
        }

        /// <summary>
        /// PUT method to update an existing greeting
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns> responseModel </returns>
        [HttpPut]
        public IActionResult Put(RequestModel requestModel)
        {
            
            _logger.LogInformation($"PUT request received with Key: {requestModel.Key}");

            ResponseModel<string> responseModel = new()
            {
                Success = true,
                Message = "Request updated successfully",
                Data = $"Updated Key: {requestModel.Key} , Updated Value: {requestModel.Value}"
            };
            return Ok(responseModel);
        }

        /// <summary>
        /// PATCH method to partially update the greeting
        /// </summary>
        /// <param name="Key"></param>
        /// <returns> responseModel </returns>
        [HttpPatch]
        public IActionResult Patch(string Key)
        {
            
            _logger.LogInformation("PATCH request received with partial update of key: ",Key);

            return Ok(new ResponseModel<string>
            {
                Success = true,
                Message = "Greeting message partially updated",
                Data = $" Patched Key: {Key}"
            });
        }

        /// <summary>
        /// DELETE method to remove a greeting
        /// </summary>
        // <param name="Key"></param>
        /// <returns> responseModel </returns>
        
        [HttpDelete]
        public IActionResult Delete(string Key)
        {
            _logger.LogInformation($"DELETE request received with {Key} key");

            return Ok(new ResponseModel<string>
            {
                Success = true,
                Message = "Greeting message deleted successfully",
                Data = $"deleted key: {Key}"
            });
        }
    }
}
