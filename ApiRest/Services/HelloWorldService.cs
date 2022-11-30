using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Services
{
    public class HelloWorldService : IHelloWorldService
    {

        
        
        public string GetHelloworld()
        {
           
            return "Hello World!";
        }
    }

    public interface IHelloWorldService
    {
        string GetHelloworld();
    }
}