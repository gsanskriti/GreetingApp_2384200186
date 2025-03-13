using System.Collections.Generic;
using System.Threading.Tasks;
using modelLayer.model;

namespace repositoryLayer.@interface
{
    public interface IGreetingAppRL
    {
        string HelloMessage();
        Task<string> GreetingMessage(UserModel userModel);
        Task<List<UserModel>> GetAllGreetings();
        Task<UserModel?> GetGreetingById(int id);
        Task<UserModel?> UpdateGreeting(int id, UserModel userModel);
        Task<bool> DeleteGreeting(int id);
    }
}
