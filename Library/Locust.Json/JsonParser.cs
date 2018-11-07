using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Json
{
    public delegate void OnBasicPropertyDetectedHandler(string propertyName, string propertyValue, JsonValueType propertyType);

    public delegate void OnBasicItemDetectedHandler(string item, JsonValueType itemType);

    public delegate bool OnObjectPropertyDetectedHandler(string propertyName, JsonReader reader);

    public delegate bool OnObjectItemDetectedHandler(JsonReader reader);

    public delegate bool OnArrayPropertyDetectedHandler(string propertyName, JsonReader reader);

    public delegate bool OnArrayItemDetectedHandler(JsonReader reader);
    public class JsonParser:JsonModel
    {
        public event OnBasicPropertyDetectedHandler OnBasicProperty;
        public event OnBasicItemDetectedHandler OnBasicItem;
        public event OnObjectPropertyDetectedHandler OnObjectProperty;
        public event OnObjectItemDetectedHandler OnObjectItem;
        public event OnArrayPropertyDetectedHandler OnArrayProperty;
        public event OnArrayItemDetectedHandler OnArrayItem;
        protected override void OnBasicPropertyDetected(string propertyName, string propertyValue, JsonValueType propertyType)
        {
            OnBasicProperty?.Invoke(propertyName, propertyValue, propertyType);
        }
        protected override void OnBasicItemDetected(string item, JsonValueType itemType)
        {
            OnBasicItem?.Invoke(item, itemType);
        }
        protected override bool OnObjectPropertyDetected(string propertyName, JsonReader reader)
        {
            if (OnObjectProperty != null)
                return OnObjectProperty(propertyName, reader);
            else
                return false;
        }
        protected override bool OnObjectItemDetected(JsonReader reader)
        {
            if (OnObjectItem != null)
                return OnObjectItem(reader);
            else
                return false;
        }
        protected override bool OnArrayPropertyDetected(string propertyName, JsonReader reader)
        {
            if (OnArrayProperty != null)
                return OnArrayProperty(propertyName, reader);
            else
                return false;
        }
        protected override bool OnArrayItemDetected(JsonReader reader)
        {
            if (OnArrayItem != null)
                return OnArrayItem(reader);
            else
                return false;
        }
    }
}
