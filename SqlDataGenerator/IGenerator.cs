using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockJsonGenerator
{
    public interface IGenerator
    {
        IGenerator GenerateStringField(int count, int minValue, int maxValue);

        IGenerator GenerateIntegerField(int count, int minValue, int maxValue);

        JObject Build();
    }
}
