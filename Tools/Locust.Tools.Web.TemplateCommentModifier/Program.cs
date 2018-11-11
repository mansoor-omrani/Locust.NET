using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Locust.Tools.Web.TemplateCommentModifier
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                System.Console.WriteLine("Locust Tools, Web Package: Template Comment Modifier 1.0.0");
                System.Console.WriteLine("This tiny utility converts HTML comments in a template file into ASP.NET MVC Razor comments or vice-versa");
                System.Console.WriteLine("Syntax: tcm commentType source [target]");
                System.Console.WriteLine("commentType: target comment (html | razor)\r\n");
                System.Console.WriteLine("If no target is specified changes will be applied to the source file");
            }
            else
            {
                var commentType = args[0];
                var source = args.Length > 1 ? args[1] : "";
                var target = args.Length > 2 ? args[2]: source;

                commentType = commentType?.Trim().ToLower();
                source = source?.Trim().ToLower();
                target = target?.Trim().ToLower();

                if (string.IsNullOrEmpty(commentType))
                {
                    System.Console.WriteLine($"please specify comment type (html or razor).");
                    return;
                }

                if (commentType != "html" && commentType != "razor")
                {
                    System.Console.WriteLine($"Invalid comment type.");
                    return;
                }

                if (string.IsNullOrEmpty(source))
                {
                    System.Console.WriteLine($"Source file not specified.");
                    return;
                }

                if (!File.Exists(source))
                {
                    System.Console.WriteLine($"File {source} was not found.");
                    return;
                }

                if (string.IsNullOrEmpty(target))
                {
                    target = source;
                }

                var content = "";

                try
                {
                    content = File.ReadAllText(source);
                }
                catch (Exception e)
                {
                    System.Console.WriteLine($"File cannot be read.");
                    System.Console.WriteLine(e.Message);

                    return;
                }

                if (commentType == "razor")
                {
                    content = content.Replace("<!--", "@*").Replace("-->", "*@");
                }
                else
                {
                    content = content.Replace("@*", "<!--").Replace("*@", "-->");
                }

                try
                {
                    File.WriteAllText(target, content);
                }
                catch (Exception e)
                {
                    System.Console.WriteLine($"Cannot write to file.");
                    System.Console.WriteLine(e.Message);

                    return;
                }
            }
        }
    }
}
