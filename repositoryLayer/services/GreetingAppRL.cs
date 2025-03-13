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

        public async Task<List<UserModel>> GetAllGreetings()
        {
            var greetings = await _context.Greetings.ToListAsync();
            return greetings.Select(g => new UserModel
            {
                FirstName = g.Key,
                LastName = g.Value
            }).ToList();
        }

        public async Task<UserModel?> GetGreetingById(int id)
        {
            var greeting = await _context.Greetings.FindAsync(id);
            if (greeting == null)
                return null;

            return new UserModel
            {
                FirstName = greeting.Key,
                LastName = greeting.Value
            };
        }

        public async Task<UserModel?> UpdateGreeting(int id, UserModel userModel)
        {
            var greeting = await _context.Greetings.FindAsync(id);
            if (greeting == null)
                return null;

            greeting.Value = $"{userModel.FirstName} {userModel.LastName}";

            _context.Greetings.Update(greeting);
            await _context.SaveChangesAsync();

            return new UserModel
            {
                FirstName = greeting.Key,
                LastName = greeting.Value
            };
        }

        public async Task<bool> DeleteGreeting(int id)
        {
            var greeting = await _context.Greetings.FindAsync(id);
            if (greeting == null)
                return false;

            _context.Greetings.Remove(greeting);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
