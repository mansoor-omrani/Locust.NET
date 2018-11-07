using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Locust.Conversion;
using Locust.Extensions;
using Locust.Json;
using Locust.Model;
using Locust.Serialization;
using JsonReader = Locust.Json.JsonReader;

namespace Locust.ServiceModel
{
    public enum DataSource { None, Memory, Db, Disk, Network, Framework, Application, Cache }
    public interface IBaseServiceResponse
    {
        bool Success { get; }
        void Faulted();
        void Succeeded();
        void Failed();
        void Errored();
        void NotFound();
        string GetStatus();
        object GetData();
        Type GetDataType();
        DataSource Source { get; set; }
    }

    public class EmptyResponse : IBaseServiceResponse
    {
        public DataSource Source { get; set; }
        public bool Success { get { return false; } }
        public void Faulted() {}
        public void Succeeded() { }
        public void Failed() { }
        public void Errored() { }
        public void NotFound() { }
        public string GetStatus()
        {
            return "";
        }
        public object GetData()
        {
            return null;
        }

        public Type GetDataType()
        {
            return typeof(object);
        }
    }
    public interface IBaseServiceResponse<UData, VStatus> : IBaseServiceResponse
    {
        VStatus Status { get; }
        UData Data { get; }
    }

    public abstract class BaseServiceResponse<UData, VStatus> : IBaseServiceResponse<UData, VStatus>
    {
        public DataSource Source { get; set; }
        public bool Success
        {
            get
            {
                return IsSuccessfull(); // && Exception == null;
            }
        }
        public VStatus Status { get; set; }
        public UData Data { get; set; }
        public abstract bool IsSuccessfull();
        public abstract bool IsFailed();
        public abstract bool IsErrored();
        public abstract bool IsFaulted();
        public abstract void Faulted();
        public abstract void Succeeded();
        public abstract void Failed();
        public abstract void Errored();
        public abstract void NotFound();
        public virtual object GetData()
        {
            return Data;
        }

        public string GetStatus()
        {
            return Status.ToString();
        }
        public abstract bool SetStatus(object status);
        public BaseServiceResponse(VStatus status, UData data)
        {
            this.Data = data;
            this.Status = status;
        }

        public virtual Type GetDataType()
        {
            return typeof (UData);
        }
    }
    public abstract class BaseServiceListResponse<UDataItem, VStatus> : BaseServiceResponse<IList<UDataItem>, VStatus>
    {
        public BaseServiceListResponse(VStatus status, IList<UDataItem> data):base(status,data)
        { }

        public virtual Type GetDataItemType()
        {
            return typeof(UDataItem);
        }
    }

    public class PageData<TDataItem>: JsonModel
    {
        public int Count { get; set; }
        private IList<TDataItem> items;

        public IList<TDataItem> Items
        {
            get
            {
                if (items == null)
                {
                    items = new List<TDataItem>();
                }
                return items;
            }
            set { items = value; }
        }

        protected override void OnBasicPropertyDetected(string propertyName, string propertyValue, JsonValueType propertyType)
        {
            if (string.Compare(propertyName, "count", StringComparison.OrdinalIgnoreCase) == 0)
            {
                Count = SafeClrConvert.ToInt32(propertyValue);
            }
        }

        protected override bool OnArrayPropertyDetected(string propertyName, JsonReader reader)
        {
            if (string.Compare(propertyName, "items", StringComparison.OrdinalIgnoreCase) == 0)
            {
                items = new List<TDataItem>();

                if (typeof(TDataItem).IsBasicType())
                {
                    var x = new JsonArrayOfBasicType<TDataItem>();
                    x.ReadJson(reader);

                    foreach (var item in x)
                    {
                        items.Add(item);
                    }

                    return true;
                }
                else
                {
                    if (typeof(TDataItem).IsJsonModel())
                    {
                        var x = new JsonArrayOfObject<TDataItem>();
                        x.ReadJson(reader);

                        foreach (var item in x)
                        {
                            items.Add(item);
                        }

                        return true;
                    }
                }
            }
            return false;
        }

        // currently we don't support List or Arrays for TDataItem
        //protected override bool OnArrayItemDetected(JsonReader reader)
        //{
        //    return base.OnArrayItemDetected(reader);
        //}

        protected override void OnBasicItemDetected(string item, JsonValueType itemType)
        {
            var x = Activator.CreateInstance<TDataItem>();
            x = (TDataItem)System.Convert.ChangeType(item, typeof(TDataItem));
            items.Add(x);
        }

        protected override bool OnObjectItemDetected(JsonReader reader)
        {
            var x = Activator.CreateInstance<TDataItem>();
            var jsonModel = x as JsonModel;

            if (jsonModel != null)
            {
                jsonModel.ReadJson(reader);
            }
            else
            {
                var emptyReader = new EmptyJson();
                emptyReader.Accumulate = true;
                emptyReader.ReadJson(reader);

                x = (TDataItem)JsonConvert.DeserializeObject(emptyReader.JsonString, typeof(TDataItem));
            }

            items.Add(x);
            return true;
        }

        protected override IEnumerable<KeyValuePair<string, object>> GetProperties()
        {
            var result = new List<KeyValuePair<string, object>>();

            result.Add(new KeyValuePair<string, object>("Count", Count));
            result.Add(new KeyValuePair<string, object>("Items", Items));

            return result;
        }

        public override string ToJson(JsonSerializationOptions options = null)
        {
            var sb = new StringBuilder();
            if (Items != null)
            {
                foreach (var item in Items)
                {
                    var baseModel = item as IJsonSerializable;

                    if (baseModel != null)
                    {
                        sb.AppendWithComma(baseModel.ToJson());
                    }
                    else
                    {
                        sb.AppendWithComma(JsonConvert.SerializeObject(item));
                    }
                }
            }

            return string.Format("{{\"Count\":{0}", Count) + ",\"Items\":[" + sb + "]}";
        }
    }
    public abstract class BaseServicePageResponse<UDataItem, VStatus> : BaseServiceResponse<PageData<UDataItem>, VStatus>
    {
        public BaseServicePageResponse(VStatus status, PageData<UDataItem> data) : base(status, data)
        { }

        public virtual Type GetDataItemType()
        {
            return typeof(UDataItem);
        }
    }
}
