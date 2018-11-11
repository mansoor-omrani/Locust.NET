using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Locust.AppPath;
using Locust.Base;
using Locust.Calendar;
using Locust.Db;
using Locust.Language;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Test.Benchmark;
using Locust.Test.Test;
using Locust.Tracing;
using Locust.Translation;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Locust.ConnectionString;
using Locust.Conversion;
using Locust.Extensions;
using Locust.Model;
using Locust.ModelField;
using Locust.WebExtensions;
using Locust.WebTools;
using MessageType = Locust.Db.MessageType;
using Locust.Json;
using Locust.Network;
using JsonReader = Locust.Json.JsonReader;
using Locust.Cryptography;

namespace Locust.Test
{
    
    class Program
    {
        static void test()
        {
            BaseTest t;
            //t = new test_locust_conn();
            //t = new test_conn_manual();
            //t = new test_basemodel_query();
            //t = new test_EF_retrive();
            //t = new test_appdomaincachemanager();
            //t = new test_model_using_ado();
            //t = new test_OveriddenBaseModel();
            //t = new test_gettype_by_string();
            t = new test_servicemodel();
            t = new test_newtonsoft_json();
            t = new test_BabbageMessageProvider();
            t = new test_nested_basemodel();
            t = new test_random_numbers();
            t = new test_rolecategoryservice();
            t = new test_empty_json_model();
            t = new test_baseInfo();
            t = new test_baseinfo_in_model();
            t = new test_guid_and_commandparameter_input_output();
            t = new test_sp_and_guid();
            t = new test_rolecategoryservice();
            t = new test_modelfield_operator_overloads();
            t = new test_json_reader();
            t = new test_conn_manual();
            t = new test_da_nvarchar_max();

            t.Test();
        }

        static void benchmark()
        {
            BaseBenchmark b;

            b = new test_basemodel_vs_ef();
            b = new benchmark_manual_prop_vs_reflection();
            //b = new benchmark_manual_prop_vs_cached_reflection();
            //b = new benchmark_basemodel_vs_ado();
            //b = new benchmark_Basemodel_vs_overiddenBasemodel();
            b = new benchmark_reflection_vs_cachedreflection_using_appdomaincachemanager();
            b = new benchmark_ActivatorCreateInstance_vs_TypeHelperCreateInstance();
            
            b.Run();
        }
        
        static void Main(string[] args)
        {
            test();
            //benchmark();
            //System.Console.WriteLine(typeof(RoleCategoryGetByIdStrategy).GetInterfaces().Contains(typeof(IBaseServiceStrategy)));
            //Cryptography.Cryptography.GetMD5()

            //System.Console.WriteLine(JsonConvert.SerializeObject(x),Newtonsoft.Json.Formatting.None,
            //                    new JsonSerializerSettings
            //                    {
            //                        NullValueHandling = NullValueHandling.Ignore
            //                    });
            //dynamic x;
            //x = 23;
            //System.Console.WriteLine(x > null);
            //System.Console.WriteLine(x < null);
            //System.Console.WriteLine(x >= null);
            //System.Console.WriteLine(x <= null);

            //var x = JsonConvert.DeserializeObject<CaseInsensitiveStringDictionary>("{city:\"tehran\"}");
            //foreach (var item in x)
            //{
            //    System.Console.WriteLine("{0}: {1}", item.Key, item.Value);
            //}
            //var f1 = (Hatra.Products.Foo)Activator.CreateInstance(typeof(Hatra.Products.Foo));
            //f1.Print();
            
            System.Console.WriteLine("\nProgram Finished");
            System.Console.ReadKey();
        }
        
    }
    
}
