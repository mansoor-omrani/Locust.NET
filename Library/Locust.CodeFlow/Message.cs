using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Locust.Calendar;

namespace Locust.CodeFlow
{
    public class MessageParam
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }

    public class ErrorInfo
    {
        public Exception Exception { get; set; }

    }
    public class Message
    {
        public MessageSource Source { get; set; }
        public MessageType Type { get; set; }
        public DateTimeField Date { get; set; }
        public string Id { get; set; }
        public string Code { get; set; }
        public string Category { get; set; }
        public string Operation { get; set; }
        public string Operator { get; set; }
        public string Content { get; private set; }
        public string OriginalContent { get; set; }
        private dynamic args;
        public dynamic Args
        {
            get { return args; }
            set
            {
                args = value;

                argList.Clear();

                if (args != null)
                {
                    var d = args as IDictionary<string, object>;

                    if (d != null)
                    {
                        foreach (var item in d)
                        {
                            argList.Add(item.Key, item.Value);
                        }
                    }
                    else
                    {
                        var props = ((Type) args.GetType()).GetProperties(BindingFlags.Public | BindingFlags.Instance);

                        foreach (var property in props)
                        {
                            if (property.CanRead)
                            {
                                var propValue = property.GetValue(args, null);

                                argList.Add(property.Name, propValue);
                            }
                        }
                    }
                }
            }
        }
        public object Info { get; set; }
        public int Order { get; set; }
        public int Depth { get; set; }
        public Exception Exception { get; set; }
        public Dictionary<string, object> argList;
        private bool is_rendered;
        public void Render()
        {
            if (!is_rendered)
	        {
                var result = "";

                if (!string.IsNullOrEmpty(OriginalContent))
		        {
                    if (argList.Count > 0)
			        {
                        char ch;
                        var state = 1;
                        var i = 0;
                        var prev = 0;
                        var arg = "";
			            var breakWhile = false;
                        char? lastChar = null;
				
                        while (i < OriginalContent.Length && !breakWhile)
				        {
                            if (lastChar != null)
					        {
                                ch = lastChar.Value;
                                lastChar = null;
					        }
                            else
					        {
                                ch = OriginalContent[i];
                            }
					
                            switch (state)
					        {
                                case 1:
                                    if (ch == '\\')
							        {
                                        state = 2;
							        }
                                    else
							        if (ch == '{')
							        {
                                        state = 3;
                                        prev = i;
							        }
                                    else
							        {
                                        result += ch;
                                    }
							        break;
                                case 2:
                                    if (ch == '\\')
							        {
                                        result += ch;
                                        state = 1;
							        }
                                    else
							        if (ch == '{')
							        {
                                        result += ch;
                                        state = 1;
							        }
                                    else
							        if (ch == '}')
							        {
                                        result += ch;
                                        state = 1;
							        }
                                    else
							        {
							            breakWhile = true;
							        }
							        break;
                                case 3:
                                    if (char.IsLetterOrDigit(ch))
							        {
                                        state = 3;
							        }
                                    else
							        if (ch == '}')
							        {
                                        if (i - prev - 1 > 0 && argList.Count > 0)
								        {
                                            arg = OriginalContent.Substring(prev + 1, i - prev - 1);
									
                                            if (argList.ContainsKey(arg))
									        {
										        result += argList[arg];
									        }
                                        }
								
                                        state = 1;
							        }
                                    else
							        {
                                        breakWhile = true;
                                    }
							        break;
                            }
					
                            if (lastChar == null)
					        {
                                i++;
                            }
                        }
			        }
                    else
			        {
                        result = OriginalContent;
                    }
                }
                is_rendered = true;
                Content = result;
            }
        }
        public Message()
        {
            Date = new DateTimeField();
            Date.Gregorian.Read(DateTime.Now);
            argList = new Dictionary<string, object>();
        }
    }
}
