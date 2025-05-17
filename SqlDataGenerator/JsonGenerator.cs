using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MockJsonGenerator
{
    public class JsonGenerator : IGenerator
    {
        public readonly JObject _jsonObject = new JObject();

        public IGenerator GenerateStringField(int count, int minLength, int maxLength)
        {
            for (int i = 0; i < count; i++)
            {
                string value = GenerateString(minLength, maxLength);
                string fieldName = $"stringField{i + 1}";

                _jsonObject[fieldName] = value;
            }

            return this;
        }

        public IGenerator GenerateIntegerField(int count, int minValue, int maxValue)
        {
            for (int i = 0; i < count; i++)
            {
                int value = GenerateInteger(minValue, maxValue);
                string fieldName = $"integerField{i + 1}";

                _jsonObject[fieldName] = value;
            }

            return this;
        }

        public static int GenerateInteger(int minValue, int maxValue)
        {
            Random random = new Random();
            var randomInt = random.Next(minValue, maxValue);

            return randomInt;
        }

        public JObject Build()
        {
            return _jsonObject;
        }

        public static string GenerateString(int minValue, int maxValue)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();

            int length = random.Next(minValue, maxValue + 1);

            return new string(Enumerable
                .Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());
        }
    }
}
