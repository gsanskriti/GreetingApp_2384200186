using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using repositoryLayer.@interface;
using repositoryLayer.Context;
using repositoryLayer.Entity;
using modelLayer.model;
using Microsoft.EntityFrameworkCore;

namespace repositoryLayer.services
{
    public class GreetingAppRL : IGreetingAppRL
    {
        private readonly HelloGreetingContext _context;

        public GreetingAppRL(HelloGreetingContext context)
        {
            _context = context;
        }

        public string HelloMessage()
        {
            return "Hello, World!";
        }

        public async Task<string> GreetingMessage(UserModel userModel)
        {
            var name = $"{userModel.FirstName} {userModel.LastName}".Trim();
            string greetingMessage = string.IsNullOrEmpty(name) ? "Hello, world!" : $"Hello, {name}!";

            var greetingEntity = new HelloGreetingEntity
            {
                Key = System.Guid.NewGuid().ToString(),
                Value = greetingMessage
            };

            await _context.Greetings.AddAsync(greetingEntity);
            await _context.SaveChangesAsync();

            return greetingMessage;
        }

        public async Task<List<HelloGreetingEntity>> GetAllGreetings()
        {
            return await _context.Greetings.ToListAsync();
        }

        public async Task<HelloGreetingEntity?> GetGreetingById(string key)
        {
            return await _context.Greetings.FirstOrDefaultAsync(g => g.Key == key);
        }

        public async Task<HelloGreetingEntity?> UpdateGreeting(string key, string newValue)
        {
            var greeting = await _context.Greetings.FirstOrDefaultAsync(g => g.Key == key);
            if (greeting == null)
                return null;

            greeting.Value = newValue;
            _context.Greetings.Update(greeting);
            await _context.SaveChangesAsync();

            return greeting;
        }

        public async Task<bool> DeleteGreeting(string key)
        {
            var greeting = await _context.Greetings.FirstOrDefaultAsync(g => g.Key == key);
            if (greeting == null)
                return false;

            _context.Greetings.Remove(greeting);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
