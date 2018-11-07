using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Caching;
using Locust.Extensions;
using Locust.AppPath;
using System.Configuration;
using Locust.Logging;
using Locust.Collections;

namespace Locust.Translation
{
    public class FileBasedTranslator : BaseTranslator
    {
        protected override void Init(ICacheManager cache, IExceptionLogger exceptionLogger, ILogger logger)
        {
            var basePath = ConfigurationManager.AppSettings["TextFileTranslator.BasePath"]?.ToString();

            if (string.IsNullOrEmpty(basePath))
            {
                BasePath = ApplicationPath.Root + "\\Localization";
            }

            Logger.Log($"BasePath: {BasePath}");
        }
        public FileBasedTranslator():base()
        {
        }
        public FileBasedTranslator(ICacheManager cache, IExceptionLogger exceptionLogger, ILogger logger): base(cache, exceptionLogger, logger)
        {
        }
        private string _basePath;
        public string BasePath { get { return _basePath; } set { _basePath = value; loaded = false; } }
        protected override void LoadInternal()
        {
            var files = new string[] { };

            Logger.Log($"Loading Path: {BasePath}");

            files = Directory.GetFiles(BasePath, $"*{CultureDependentTextExtension}", SearchOption.AllDirectories);

            Logger.Log($"culture dependent files: {files.Length}");

            foreach (var file in files)
            {
                var content = File.ReadAllText(file);
                var filename = Path.GetFileNameWithoutExtension(file);

                Logger.Log($"Loading File: {file}");

                try
                {
                    ProcessCultureDependentText(filename, content);
                }
                catch (Exception e)
                {
                    Logger.Log($"error loading {file}");
                    exceptionLogger.LogException(e, $"{nameof(FileBasedTranslator)}.Load(): ProcessCultureDependentText('{file}')");
                }
            }

            files = Directory.GetFiles(BasePath, $"*{CultureIndependentTextExtension}", SearchOption.AllDirectories);

            Logger.Log($"culture independent files: {files.Length}");

            foreach (var file in files)
            {
                var content = File.ReadAllText(file);
                var filename = Path.GetFileNameWithoutExtension(file);

                Logger.Log($"Loading File: {file}");

                try
                {
                    ProcessCultureIndependentText(filename, content);
                }
                catch (Exception e)
                {
                    Logger.Log($"error loading {file}");
                    exceptionLogger.LogException(e, $"{nameof(FileBasedTranslator)}.Load(): ProcessCultureIndependentText('{file}')");
                }
            }
        }
    }
}
