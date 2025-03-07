using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using repositoryLayer.@interface;
using modelLayer.model;

namespace repositoryLayer.services
{
	public class GreetingAppRL: IGreetingAppRL
    {
		public string HelloMessage()
		{
            return "Hello, World!";
		}

        public string GreetingMessage(UserModel userModel)
        {
            var name = $"{userModel.FirstName} {userModel.LastName}".Trim();
            return string.IsNullOrEmpty(name) ? "Hello, world! " : $"Hello, {name}! ";
        }

    }
}

