using Locust.Extensions;
using Locust.Validation;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Linq;
using System.Text;

namespace Locust.Mailing
{
    public enum EmailEvaluationStatus
    {
        NotEvaludated,
        Empty,
        Invalid,
        Success,
        Company,
        Groups,
        InvalidExtension,
        FakeName,
        NameIsCountry,
        NameError,
        ServerError,
        FakeServer,
        YahooTypo,
        GmailTypo,
        MailTypo,
        HotmailTypo,
        ServerTypo,
        ServerMisUse,
        ServerVulgar,
        ExtensionTypo,
        TooShortName,
        TooShortServer,
        RepeatingCharName,
        RepeatingCharServer,
        NonesenseName,
        NonesenseServer
    }
    public class EmailEvaluationResult
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public EmailEvaluationStatus Status { get; set; }
        public bool? Success
        {
            get
            {
                if (Status == EmailEvaluationStatus.Success)
                {
                    return true;
                }

                if (!(Status.ToLowerCase().Contains("typo")))
                {
                    return false;
                }

                return null;
            }
        }
        public string Suggestion { get; set; }
        public bool Report { get; set; }
        public EmailEvaluationResult()
        {
            Status = EmailEvaluationStatus.NotEvaludated;
        }
    }
    public interface IEmailEvaluator
    {
        EmailEvaluationResult Eval(string email);
    }
    public class EmailEvaluator: IEmailEvaluator
    {
        private static string FakeNames;
        private static string FakeServerNames;
        private static string ServerGroupNames;
        static EmailEvaluator()
        {
            var domains = new string[]
            {
                "computer", "system", "site", "email", "example", "sites", "server", "servers",
                "domain", "subdomain", "sub-domain", "damane", "zirdamane", "subdamane", "damaneha", "damaneh", "zirdamaneh", "subdamaneh", "domains", "subdomains", "sub-domains",
                "test", "tests", "fake", "fakes", "domaininc", "domainname", "proxy",
                "dns", "host", "hosts", "guest", "place", "places", "location", "locations",
                "home", "house", "apartment", "building", "dummy", "company", "org", "organization", 
                "companyltd", "homeserver", "help", "university", "college", "school", "shop", "doctor", "dentist", "foo", "freedom", "center",
                "homeserver", "info", "department", "localhost", "name",
                "news", "bank", "software", "hardware", "office", "room",
                "alaki", "www", "network", "internet", "admin", "administrator", "lan", "modem", "mother", "father", "god", "day", "way",
                "path", "road", "street", "avenue", "highway", "car", "ship", "tv", "radio", "channel", "net", "com"
            };
            var buffer = new StringBuilder();

            foreach (var item in domains)
            {
                buffer.Append("," + item);

                buffer.Append(",my" + item);
                buffer.Append(",your" + item);
                buffer.Append(",him" + item);
                buffer.Append(",his" + item);
                buffer.Append(",her" + item);
                buffer.Append(",our" + item);
                buffer.Append(",their" + item);
                buffer.Append(",them" + item);

                buffer.Append(",mytest" + item);
                buffer.Append(",yourtest" + item);
                buffer.Append(",himtest" + item);
                buffer.Append(",histest" + item);
                buffer.Append(",hertest" + item);
                buffer.Append(",ourtest" + item);
                buffer.Append(",theirtest" + item);
                buffer.Append(",themtest" + item);

                buffer.Append(",myfake" + item);
                buffer.Append(",yourfake" + item);
                buffer.Append(",himfake" + item);
                buffer.Append(",hisfake" + item);
                buffer.Append(",herfake" + item);
                buffer.Append(",ourfake" + item);
                buffer.Append(",theirfake" + item);
                buffer.Append(",themfake" + item);

                buffer.Append(",mywww" + item);
                buffer.Append(",yourwww" + item);
                buffer.Append(",himwww" + item);
                buffer.Append(",hiswww" + item);
                buffer.Append(",herwww" + item);
                buffer.Append(",ourwww" + item);
                buffer.Append(",theirwww" + item);
                buffer.Append(",themwww" + item);

                buffer.Append(",test" + item);
                buffer.Append(",fake" + item);
                buffer.Append(",www" + item);
            }

            FakeServerNames = buffer.ToString().Substring(1);

            buffer = new StringBuilder();
            var groupDomains = new string[]
            {
                "yahoogroup", "yahoo-group", "yahoogroups", "yahoo-groups", "googlegroup", "google-group", "googlegroups", "google-groups", "facebookgroup", "facebookgroups", "facebook-group", "facebook-groups", "msngroup", "msngroups", "msn-group", "msn-groups", "group", "groups"
            };

            foreach (var item in groupDomains)
            {
                buffer.Append("," + item);
                buffer.Append(",my" + item);
                buffer.Append(",your" + item);
                buffer.Append(",him" + item);
                buffer.Append(",his" + item);
                buffer.Append(",her" + item);
                buffer.Append(",our" + item);
                buffer.Append(",their" + item);
                buffer.Append(",them" + item);

                buffer.Append(",mytest" + item);
                buffer.Append(",yourtest" + item);
                buffer.Append(",himtest" + item);
                buffer.Append(",histest" + item);
                buffer.Append(",hertest" + item);
                buffer.Append(",ourtest" + item);
                buffer.Append(",theirtest" + item);
                buffer.Append(",themtest" + item);

                buffer.Append(",myfake" + item);
                buffer.Append(",yourfake" + item);
                buffer.Append(",himfake" + item);
                buffer.Append(",hisfake" + item);
                buffer.Append(",herfake" + item);
                buffer.Append(",ourfake" + item);
                buffer.Append(",theirfake" + item);
                buffer.Append(",themfake" + item);

                buffer.Append(",mywww" + item);
                buffer.Append(",yourwww" + item);
                buffer.Append(",himwww" + item);
                buffer.Append(",hiswww" + item);
                buffer.Append(",herwww" + item);
                buffer.Append(",ourwww" + item);
                buffer.Append(",theirwww" + item);
                buffer.Append(",themwww" + item);

                buffer.Append(",test" + item);
                buffer.Append(",fake" + item);
                buffer.Append(",www" + item);
            }

            ServerGroupNames = buffer.ToString().Substring(1);

            var names = new string[] { "name", "nickname", "firstname", "lastname", "middlename", "family", "site", "server", "mail", "email", "example", "dns", "proxy", "net", "network", "host", "place", "location", "home", "house", "apartment", "building" };
            buffer = new StringBuilder();

            foreach (var item in names)
            {
                buffer.Append("," + item);

                buffer.Append(",my" + item);
                buffer.Append(",your" + item);
                buffer.Append(",him" + item);
                buffer.Append(",his" + item);
                buffer.Append(",her" + item);
                buffer.Append(",our" + item);
                buffer.Append(",their" + item);
                buffer.Append(",them" + item);

                buffer.Append(",mytest" + item);
                buffer.Append(",yourtest" + item);
                buffer.Append(",himtest" + item);
                buffer.Append(",histest" + item);
                buffer.Append(",hertest" + item);
                buffer.Append(",ourtest" + item);
                buffer.Append(",theirtest" + item);
                buffer.Append(",themtest" + item);

                buffer.Append(",myfake" + item);
                buffer.Append(",yourfake" + item);
                buffer.Append(",himfake" + item);
                buffer.Append(",hisfake" + item);
                buffer.Append(",herfake" + item);
                buffer.Append(",ourfake" + item);
                buffer.Append(",theirfake" + item);
                buffer.Append(",themfake" + item);

                buffer.Append(",mywww" + item);
                buffer.Append(",yourwww" + item);
                buffer.Append(",himwww" + item);
                buffer.Append(",hiswww" + item);
                buffer.Append(",herwww" + item);
                buffer.Append(",ourwww" + item);
                buffer.Append(",theirwww" + item);
                buffer.Append(",themwww" + item);

                buffer.Append(",fake" + item);
                buffer.Append(",test" + item);
            }

            FakeNames = buffer.ToString().Substring(1);
        }
        public EmailEvaluationResult Eval(string email)
        {
            var result = new EmailEvaluationResult();

            foreach (var foo in " ")
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    result.Status = EmailEvaluationStatus.Empty;
                    break;
                }

                if (!Locust.Validation.Validation.IsEmail(email))
                {
                    result.Status = EmailEvaluationStatus.Invalid;
                    break;
                }

                email = email.ToLower();

                var i = email.IndexOf("@");
                var name = email.Substring(0, i).Replace("-", "").Replace(".", "");
                var server = email.Substring(i + 1);
                i = server.LastIndexOf(".");
                var extension = server.Substring(i + 1);
                i = server.IndexOf(".");
                var serverName = server.Substring(0, i).Replace("-", "");

                if (name.Length < 3)
                {
                    result.Status = EmailEvaluationStatus.TooShortName;
                    break;
                }

                var prev = default(char);
                var cnt = 0;

                foreach (var ch in name)
                {
                    if (prev != default(char))
                    {
                        if (ch == prev)
                        {
                            cnt++;
                            prev = ch;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        prev = ch;
                        cnt = 1;
                    }
                }

                if (cnt == name.Length)
                {
                    result.Status = EmailEvaluationStatus.RepeatingCharName;
                    break;
                }

                if (name.In("info,information,support,supports,help,question,answer,questions,answers,faq,admin,phd,doctor,technician,operator,administrator,manage,manager,supervisor,sale,sales,purchase,reply,post,directory,list,test,tests,exam,copy,fax,print,tel,phone,mobile,him,her,them,their,his,network,net,repair,fix,follow,department,university,college,school,home,house"))
                {
                    result.Status = EmailEvaluationStatus.Company;
                    break;
                }

                //if (name.In("iran,ir,usa,uk,turkey,germany"))
                //{
                //    result.Status = EmailEvaluationStatus.NameIsCountry;
                //    break;
                //}

                if (name.In(FakeNames + ",abc,abcd,abcde,abcdefg"))
                {
                    result.Status = EmailEvaluationStatus.FakeName;
                    break;
                }

                if (name.StartsWith("www"))
                {
                    result.Status = EmailEvaluationStatus.NameError;
                    break;
                }

                // ------------------------ validating server --------------------
                if (serverName.Length < 3)
                {
                    result.Status = EmailEvaluationStatus.TooShortServer;
                    break;
                }

                if (serverName.StartsWith("www"))
                {
                    result.Status = EmailEvaluationStatus.ServerError;
                    break;
                }

                prev = default(char);
                
                foreach (var ch in serverName)
                {
                    if (prev != default(char))
                    {
                        if (ch == prev)
                        {
                            cnt++;
                            prev = ch;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        prev = ch;
                        cnt = 1;
                    }
                }

                if (cnt == serverName.Length)
                {
                    result.Status = EmailEvaluationStatus.RepeatingCharServer;
                    break;
                }

                if (serverName.In(FakeServerNames + ",abc,about,somewhere,somesite,somedomain,somedns,someproxy,nowhere,anywhere,however,elsewhere,where,here,there"))
                {
                    result.Status = EmailEvaluationStatus.FakeServer;
                    break;
                }

                if (serverName.In(ServerGroupNames))
                {
                    result.Status = EmailEvaluationStatus.Groups;
                    break;
                }

                if (serverName.In("acece,asd,asdasd,asdasdasd,zxc,zxcvzxc,qwe,qweqwe,wer,werwer"))
                {
                    result.Status = EmailEvaluationStatus.NonesenseServer;
                    break;
                }

                if (serverName.In("yhoo,yaho,yahooo,yahho,yahhoo,yaahoo,yaaho,yagoo,yaoo,yashoo,yshoo,yayhoo,yahool,yahoi,yhaoo,ymal,ymial,yamil,ygmail,uahoo,ahoo,ayhoo,yaooh,yahooc,yahoom,yahooinc,yah0o"))
                {
                    result.Status = EmailEvaluationStatus.YahooTypo;
                    break;
                }

                if (serverName.In("gamil,gmaill,gmeil,gmai,gmaial,gmailc,gmaile,gmal,gmali,gmial,gmil,gmile,gimail,gimal,gmill,gamail,gemail"))
                {
                    result.Status = EmailEvaluationStatus.GmailTypo;
                    break;
                }

                if (serverName.In("htomail,hotmial,hotmali,hotmeil"))
                {
                    result.Status = EmailEvaluationStatus.HotmailTypo;
                    break;
                }

                if (serverName.In("meil,mial,amil,maol,emial"))
                {
                    result.Status = EmailEvaluationStatus.MailTypo;
                    result.Suggestion = "mail.com";
                    break;
                }

                if (serverName.In("google,googlegroups,googlemail,goole"))
                {
                    result.Status = EmailEvaluationStatus.ServerMisUse;
                    result.Suggestion = "gmail.com";
                    break;
                }

                if (extension.In("coom,con,comv,ccom,cim,cm,co,cpm,om,oom,coml,comh,coma,coms,comy,comi,cmo,cno,ocm,cim,"))
                {
                    result.Status = EmailEvaluationStatus.ExtensionTypo;
                    break;
                }

                if (extension.In("local"))
                {
                    result.Status = EmailEvaluationStatus.InvalidExtension;
                    break;
                }

                if (serverName.Contains("fuck,sex,penis,cock,pussy,buttock,porn,thigh,skirt,hentai,shemale,slave,mistress,fetish,prostitute,bdsm,masterbation,"))
                {
                    result.Status = EmailEvaluationStatus.Success;
                    result.Report = true;
                    break;
                }

                result.Status = EmailEvaluationStatus.Success;
                break;
            }

            return result;
        }
    }
}