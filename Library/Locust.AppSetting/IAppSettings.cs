using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.AppSetting
{
    public interface IAppSettingsRead
    {
        string Get(string key);
        string this[int index] { get; }
        string this[string key] { get; }
    }
    public interface IAppSettingsWrite
    {
        void Set(string key, string value);
        string this[int index] { set; }
        string this[string key] { set; }
    }
    public interface IAppSettings: IAppSettingsRead, IAppSettingsWrite
    {
    }
}
