using System.Collections.Generic;
using System.Threading.Tasks;
using businessLayer.@interface;
using modelLayer.model;
using repositoryLayer.@interface;
using repositoryLayer.Entity;

namespace businessLayer.services
{
    public class GreetingAppBL : IGreetingAppBL
    {
        private readonly IGreetingAppRL _greetingRL;

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
            return await _greetingRL.GreetingMessage(userModel);
        }

        public async Task<List<HelloGreetingEntity>> GetAllGreetings()
        {
            return await _greetingRL.GetAllGreetings();
        }

        public async Task<HelloGreetingEntity?> GetGreetingById(string key)
        {
            return await _greetingRL.GetGreetingById(key);
        }

        public async Task<HelloGreetingEntity?> UpdateGreeting(string key, string newValue)
        {
            return await _greetingRL.UpdateGreeting(key, newValue);
        }

        public async Task<bool> DeleteGreeting(string key)
        {
            return await _greetingRL.DeleteGreeting(key);
        }
    }
}
