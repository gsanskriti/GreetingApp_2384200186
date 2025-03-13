using System.Collections.Generic;
using System.Threading.Tasks;
using businessLayer.@interface;
using modelLayer.model;
using repositoryLayer.@interface;

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

        public async Task<List<UserModel>> GetAllGreetings()
        {
            return await _greetingRL.GetAllGreetings();
        }

        public async Task<UserModel?> GetGreetingById(int id)
        {
            return await _greetingRL.GetGreetingById(id);
        }

        public async Task<UserModel?> UpdateGreeting(int id, UserModel userModel)
        {
            return await _greetingRL.UpdateGreeting(id, userModel);
        }

        public async Task<bool> DeleteGreeting(int id)
        {
            return await _greetingRL.DeleteGreeting(id);
        }
    }
}
