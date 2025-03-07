using System;
using modelLayer.model;

namespace repositoryLayer.@interface
{
	public interface IGreetingAppRL
	{
        public string HelloMessage();
        string GreetingMessage(UserModel userModel);
    }
}

