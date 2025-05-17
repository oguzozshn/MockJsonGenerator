using System;
using Newtonsoft.Json.Linq;
using MockJsonGenerator;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            var generator = new JsonGenerator()
            .GenerateStringField(1, 10, 100)
            .GenerateIntegerField(3, 10, 500);

            Console.WriteLine(generator.Build().ToString());
        }
    }
}
