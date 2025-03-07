using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using businessLayer.@interface;
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

		public string GreetingMessage()
		{
			var result = _greetingRL.GreetingMessage();
			return result;

        }
    }
}

