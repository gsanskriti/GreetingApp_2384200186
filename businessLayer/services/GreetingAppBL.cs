using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using businessLayer.@interface;
using modelLayer.model;
using repositoryLayer.@interface;
using repositoryLayer.Entity;
using NLog;
using Microsoft.Extensions.Logging;

namespace businessLayer.services
{
    public class GreetingAppBL : IGreetingAppBL
    {
        private readonly IGreetingAppRL _greetingRL;
        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        public GreetingAppBL(IGreetingAppRL greetingRL)
        {
            _greetingRL = greetingRL;
        }

        public string HelloMessage()
        {
            return _greetingRL.HelloMessage();
        }

        public async Task<string> GreetingMessage(UserModel userModel)
        {
            var result = await _greetingRL.GreetingMessage(userModel);
            logger.Info("Greeting message created successfully");
            return result;
        }

        public async Task<List<HelloGreetingEntity>> GetAllGreetings()
        {
            return await _greetingRL.GetAllGreetings();
        }

        public async Task<HelloGreetingEntity?> GetGreetingById(string key)
        {
            return await _greetingRL.GetGreetingById(key);
        }

        public async Task<bool> UpdateGreeting(string key, string newValue)
        {
            var result = await _greetingRL.UpdateGreeting(key, newValue);
            if (result)
                logger.Info("Greeting updated successfully with key: {0}", key);
            else
                logger.Warn("Failed to update greeting, key not found: {0}", key);

            return result;
        }

        public async Task<bool> DeleteGreeting(string key)
        {
            var result = await _greetingRL.DeleteGreeting(key);
            if (result)
                logger.Info("Greeting deleted successfully with key: {0}", key);
            else
                logger.Warn("Failed to delete greeting, key not found: {0}", key);

            return result;
        }
    }
}

