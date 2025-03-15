using System.Collections.Generic;
using System.Threading.Tasks;
using modelLayer.model;
using repositoryLayer.Entity;

namespace businessLayer.@interface
{
    public interface IGreetingAppBL
    {
        string HelloMessage();
        Task<string> GreetingMessage(UserModel userModel);
        Task<List<HelloGreetingEntity>> GetAllGreetings();
        Task<HelloGreetingEntity?> GetGreetingById(string key);
        Task<HelloGreetingEntity?> UpdateGreeting(string key, string newValue);
        Task<bool> DeleteGreeting(string key);
    }
}
