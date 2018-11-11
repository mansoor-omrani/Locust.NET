using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Json;

namespace Locust.Test.Test
{
    class MyData : JsonModel
    {
        protected override void OnBasicPropertyDetected(string propertyName, string propertyValue, JsonValueType propertyType)
        {
            System.Console.WriteLine("MyData: {0} = {1}", propertyName, propertyValue);
        }
    }
    class MyJson : JsonModel
    {
        public MyJson()
        {
            _data = new MyData();
        }
        private MyData _data;
        public MyData Data
        {
            get { return _data; }
        }
        protected override void OnBasicPropertyDetected(string propertyName, string propertyValue, JsonValueType propertyType)
        {
            System.Console.WriteLine("MyJson: {0} = {1}", propertyName, propertyValue);
        }

        protected override bool OnObjectPropertyDetected(string propertyName, JsonReader reader)
        {
            if (string.Compare(propertyName, "data", StringComparison.OrdinalIgnoreCase) == 0)
            {
                Data.ReadJson(reader);
                return true;
            }
            else
            {
                return base.OnObjectPropertyDetected(propertyName, reader);
            }
        }

    }
    public class test_json_reader:BaseTest
    {
        public override void Test()
        {
            var body =
                "9ydSh7z0hWxBRNXsNM3g6RewHnO7zNrqojLt5kx26zypB4S09hPZNGdW9RpZS/2nZifWLFbBdizW+2gM5Fi1xG1233V7k9apQvTyvyHFq/o=";
            var key = "8crdHijYiZOVDgdP";
            var x = Locust.Cryptography.Cryptography.AES.Decrypt(body, key);
            var jp = new MyJson();
            jp.ReadJson(x);
        }
    }
}
