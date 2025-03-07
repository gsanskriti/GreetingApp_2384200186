using System;
using modelLayer.model;

namespace businessLayer.@interface
{
	public interface IGreetingAppBL
	{
        public string HelloMessage();
        public string GreetingMessage(UserModel userMode);
    }
}

