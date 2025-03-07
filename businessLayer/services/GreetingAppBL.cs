using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            var result = _greetingRL.HelloMessage();
            return result;
        }

        public string GreetingMessage(UserModel userMode)
		{
			var result = _greetingRL.GreetingMessage(userMode);
			return result;

        }

    }
}

