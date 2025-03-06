using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        /// <summary>
        /// GET method to retrieve the greeting message
        /// </summary>
        /// <returns>A greeting message</returns>
        [HttpGet]
        public IActionResult Get()
        {
            ResponseModel<string> responseModel = new ResponseModel<string>
            {
                Success = true,
                Message = "Hello to Greeting App API Endpoint",
                Data = "Hello, World!"
            };

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
                return BadRequest(new ResponseModel<string>
                {
                    Success = false,
                    Message = "Greeting message cannot be empty.",
                    Data = null
                });
            }

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
                return BadRequest(new ResponseModel<string>
                {
                    Success = false,
                    Message = "Updated greeting message cannot be empty.",
                    Data = null
                });
            }

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
                return BadRequest(new ResponseModel<string>
                {
                    Success = false,
                    Message = "Partial update cannot be empty.",
                    Data = null
                });
            }

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
            return Ok(new ResponseModel<string>
            {
                Success = true,
                Message = "Greeting message deleted successfully",
                Data = null
            });
        }
    }
}
