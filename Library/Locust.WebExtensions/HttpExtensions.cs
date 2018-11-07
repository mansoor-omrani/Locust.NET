using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Locust.Extensions;

namespace Locust.WebExtensions
{
    [Flags]
    public enum RequestRead
    {
        None = 0,
        Querystring = 1,
        Form = 2,
        QueryAndForm = 3,
        Headers = 4,
        ServerVariables = 8,
        HeadersAndVariables = 12,
        All = 15
    }
    public static class HttpExtensions
    {
        public static MvcHtmlString ToMvcHtmlString(this string s)
        {
            return new MvcHtmlString(s);
        }

        public static IDictionary<string, string> ToDictionary(this HttpRequest request, RequestRead whatToRead)
        {
            var requestBase = new HttpRequestWrapper(request);

            return requestBase.ToDictionary(whatToRead);
        }
        public static IDictionary<string, object> ToDictionary(this HttpBrowserCapabilities bc)
        {
            var result = new Dictionary<string, object>();

            result.Add("ActiveXControls", bc.ActiveXControls);
            result.Add("Adapters", bc.Adapters);
            result.Add("AOL", bc.AOL);
            result.Add("BackgroundSounds", bc.BackgroundSounds);
            result.Add("Beta", bc.Beta);
            result.Add("Browser", bc.Browser);
            result.Add("Browsers", bc.Browsers);
            result.Add("CanCombineFormsInDeck", bc.CanCombineFormsInDeck);
            result.Add("CanInitiateVoiceCall", bc.CanInitiateVoiceCall);
            result.Add("CanRenderAfterInputOrSelectElement", bc.CanRenderAfterInputOrSelectElement);
            result.Add("CanRenderEmptySelects", bc.CanRenderEmptySelects);
            result.Add("CanRenderInputAndSelectElementsTogether", bc.CanRenderInputAndSelectElementsTogether);
            result.Add("CanRenderMixedSelects", bc.CanRenderMixedSelects);
            result.Add("CanRenderOneventAndPrevElementsTogether", bc.CanRenderOneventAndPrevElementsTogether);
            result.Add("CanRenderPostBackCards", bc.CanRenderPostBackCards);
            result.Add("CanRenderSetvarZeroWithMultiSelectionList", bc.CanRenderSetvarZeroWithMultiSelectionList);
            result.Add("CanSendMail", bc.CanSendMail);
            result.Add("Capabilities", bc.Capabilities);
            result.Add("CDF", bc.CDF);
            result.Add("ClrVersion", bc.ClrVersion);
            result.Add("Cookies", bc.Cookies);
            result.Add("Crawler", bc.Crawler);
            result.Add("DefaultSubmitButtonLimit", bc.DefaultSubmitButtonLimit);
            result.Add("EcmaScriptVersion", bc.EcmaScriptVersion);
            result.Add("Frames", bc.Frames);
            result.Add("GatewayMajorVersion", bc.GatewayMajorVersion);
            result.Add("GatewayMinorVersion", bc.GatewayMinorVersion);
            result.Add("GatewayVersion", bc.GatewayVersion);
            result.Add("HasBackButton", bc.HasBackButton);
            result.Add("HidesRightAlignedMultiselectScrollbars", bc.HidesRightAlignedMultiselectScrollbars);
            result.Add("HtmlTextWriter", bc.HtmlTextWriter);
            result.Add("Id", bc.Id);
            result.Add("InputType", bc.InputType);
            result.Add("IsColor", bc.IsColor);
            result.Add("IsMobileDevice", bc.IsMobileDevice);
            result.Add("JavaApplets", bc.JavaApplets);
            result.Add("JScriptVersion", bc.JScriptVersion);
            result.Add("MajorVersion", bc.MajorVersion);
            result.Add("MaximumHrefLength", bc.MaximumHrefLength);
            result.Add("MaximumRenderedPageSize", bc.MaximumRenderedPageSize);
            result.Add("MaximumSoftkeyLabelLength", bc.MaximumSoftkeyLabelLength);
            result.Add("MinorVersion", bc.MinorVersion);
            result.Add("MinorVersionString", bc.MinorVersionString);
            result.Add("MobileDeviceManufacturer", bc.MobileDeviceManufacturer);
            result.Add("MobileDeviceModel", bc.MobileDeviceModel);
            result.Add("MSDomVersion", bc.MSDomVersion);
            result.Add("NumberOfSoftkeys", bc.NumberOfSoftkeys);
            result.Add("Platform", bc.Platform);
            result.Add("PreferredImageMime", bc.PreferredImageMime);
            result.Add("PreferredRenderingMime", bc.PreferredRenderingMime);
            result.Add("PreferredRenderingType", bc.PreferredRenderingType);
            result.Add("PreferredRequestEncoding", bc.PreferredRequestEncoding);
            result.Add("PreferredResponseEncoding", bc.PreferredResponseEncoding);
            result.Add("RendersBreakBeforeWmlSelectAndInput", bc.RendersBreakBeforeWmlSelectAndInput);
            result.Add("RendersBreaksAfterHtmlLists", bc.RendersBreaksAfterHtmlLists);
            result.Add("RendersBreaksAfterWmlAnchor", bc.RendersBreaksAfterWmlAnchor);
            result.Add("RendersBreaksAfterWmlInput", bc.RendersBreaksAfterWmlInput);
            result.Add("RendersWmlDoAcceptsInline", bc.RendersWmlDoAcceptsInline);
            result.Add("RendersWmlSelectsAsMenuCards", bc.RendersWmlSelectsAsMenuCards);
            result.Add("RequiredMetaTagNameValue", bc.RequiredMetaTagNameValue);
            result.Add("RequiresAttributeColonSubstitution", bc.RequiresAttributeColonSubstitution);
            result.Add("RequiresContentTypeMetaTag", bc.RequiresContentTypeMetaTag);
            result.Add("RequiresControlStateInSession", bc.RequiresControlStateInSession);
            result.Add("RequiresDBCSCharacter", bc.RequiresDBCSCharacter);
            result.Add("RequiresHtmlAdaptiveErrorReporting", bc.RequiresHtmlAdaptiveErrorReporting);
            result.Add("RequiresLeadingPageBreak", bc.RequiresLeadingPageBreak);
            result.Add("RequiresNoBreakInFormatting", bc.RequiresNoBreakInFormatting);
            result.Add("RequiresOutputOptimization", bc.RequiresOutputOptimization);
            result.Add("RequiresPhoneNumbersAsPlainText", bc.RequiresPhoneNumbersAsPlainText);
            result.Add("RequiresSpecialViewStateEncoding", bc.RequiresSpecialViewStateEncoding);
            result.Add("RequiresUniqueFilePathSuffix", bc.RequiresUniqueFilePathSuffix);
            result.Add("RequiresUniqueHtmlCheckboxNames", bc.RequiresUniqueHtmlCheckboxNames);
            result.Add("RequiresUniqueHtmlInputNames", bc.RequiresUniqueHtmlInputNames);
            result.Add("RequiresUrlEncodedPostfieldValues", bc.RequiresUrlEncodedPostfieldValues);
            result.Add("ScreenBitDepth", bc.ScreenBitDepth);
            result.Add("ScreenCharactersHeight", bc.ScreenCharactersHeight);
            result.Add("ScreenCharactersWidth", bc.ScreenCharactersWidth);
            result.Add("ScreenPixelsHeight", bc.ScreenPixelsHeight);
            result.Add("ScreenPixelsWidth", bc.ScreenPixelsWidth);
            result.Add("SupportsAccesskeyAttribute", bc.SupportsAccesskeyAttribute);
            result.Add("SupportsBodyColor", bc.SupportsBodyColor);
            result.Add("SupportsBold", bc.SupportsBold);
            result.Add("SupportsCacheControlMetaTag", bc.SupportsCacheControlMetaTag);
            result.Add("SupportsCallback", bc.SupportsCallback);
            result.Add("SupportsCss", bc.SupportsCss);
            result.Add("SupportsDivAlign", bc.SupportsDivAlign);
            result.Add("SupportsDivNoWrap", bc.SupportsDivNoWrap);
            result.Add("SupportsEmptyStringInCookieValue", bc.SupportsEmptyStringInCookieValue);
            result.Add("SupportsFontColor", bc.SupportsFontColor);
            result.Add("SupportsFontName", bc.SupportsFontName);
            result.Add("SupportsFontSize", bc.SupportsFontSize);
            result.Add("SupportsImageSubmit", bc.SupportsImageSubmit);
            result.Add("SupportsIModeSymbols", bc.SupportsIModeSymbols);
            result.Add("SupportsInputIStyle", bc.SupportsInputIStyle);
            result.Add("SupportsInputMode", bc.SupportsInputMode);
            result.Add("SupportsItalic", bc.SupportsItalic);
            result.Add("SupportsJPhoneMultiMediaAttributes", bc.SupportsJPhoneMultiMediaAttributes);
            result.Add("SupportsJPhoneSymbols", bc.SupportsJPhoneSymbols);
            result.Add("SupportsQueryStringInFormAction", bc.SupportsQueryStringInFormAction);
            result.Add("SupportsRedirectWithCookie", bc.SupportsRedirectWithCookie);
            result.Add("SupportsSelectMultiple", bc.SupportsSelectMultiple);
            result.Add("SupportsUncheck", bc.SupportsUncheck);
            result.Add("SupportsXmlHttp", bc.SupportsXmlHttp);
            result.Add("Tables", bc.Tables);
            result.Add("TagWriter", bc.TagWriter);
            result.Add("Type", bc.Type);
            result.Add("UseOptimizedCacheKey", bc.UseOptimizedCacheKey);
            result.Add("VBScript", bc.VBScript);
            result.Add("Version", bc.Version);
            result.Add("W3CDomVersion", bc.W3CDomVersion);
            result.Add("Win16", bc.Win16);
            result.Add("Win32", bc.Win32);

            return result;
        }
        public static IDictionary<string, object> ToDictionary(this HttpBrowserCapabilitiesBase bc)
        {
            var result = new Dictionary<string, object>();

            result.Add("ActiveXControls", bc.ActiveXControls);
            result.Add("Adapters", bc.Adapters);
            result.Add("AOL", bc.AOL);
            result.Add("BackgroundSounds", bc.BackgroundSounds);
            result.Add("Beta", bc.Beta);
            result.Add("Browser", bc.Browser);
            result.Add("Browsers", bc.Browsers);
            result.Add("CanCombineFormsInDeck", bc.CanCombineFormsInDeck);
            result.Add("CanInitiateVoiceCall", bc.CanInitiateVoiceCall);
            result.Add("CanRenderAfterInputOrSelectElement", bc.CanRenderAfterInputOrSelectElement);
            result.Add("CanRenderEmptySelects", bc.CanRenderEmptySelects);
            result.Add("CanRenderInputAndSelectElementsTogether", bc.CanRenderInputAndSelectElementsTogether);
            result.Add("CanRenderMixedSelects", bc.CanRenderMixedSelects);
            result.Add("CanRenderOneventAndPrevElementsTogether", bc.CanRenderOneventAndPrevElementsTogether);
            result.Add("CanRenderPostBackCards", bc.CanRenderPostBackCards);
            result.Add("CanRenderSetvarZeroWithMultiSelectionList", bc.CanRenderSetvarZeroWithMultiSelectionList);
            result.Add("CanSendMail", bc.CanSendMail);
            result.Add("Capabilities", bc.Capabilities);
            result.Add("CDF", bc.CDF);
            result.Add("ClrVersion", bc.ClrVersion);
            result.Add("Cookies", bc.Cookies);
            result.Add("Crawler", bc.Crawler);
            result.Add("DefaultSubmitButtonLimit", bc.DefaultSubmitButtonLimit);
            result.Add("EcmaScriptVersion", bc.EcmaScriptVersion);
            result.Add("Frames", bc.Frames);
            result.Add("GatewayMajorVersion", bc.GatewayMajorVersion);
            result.Add("GatewayMinorVersion", bc.GatewayMinorVersion);
            result.Add("GatewayVersion", bc.GatewayVersion);
            result.Add("HasBackButton", bc.HasBackButton);
            result.Add("HidesRightAlignedMultiselectScrollbars", bc.HidesRightAlignedMultiselectScrollbars);
            result.Add("HtmlTextWriter", bc.HtmlTextWriter);
            result.Add("Id", bc.Id);
            result.Add("InputType", bc.InputType);
            result.Add("IsColor", bc.IsColor);
            result.Add("IsMobileDevice", bc.IsMobileDevice);
            result.Add("JavaApplets", bc.JavaApplets);
            result.Add("JScriptVersion", bc.JScriptVersion);
            result.Add("MajorVersion", bc.MajorVersion);
            result.Add("MaximumHrefLength", bc.MaximumHrefLength);
            result.Add("MaximumRenderedPageSize", bc.MaximumRenderedPageSize);
            result.Add("MaximumSoftkeyLabelLength", bc.MaximumSoftkeyLabelLength);
            result.Add("MinorVersion", bc.MinorVersion);
            result.Add("MinorVersionString", bc.MinorVersionString);
            result.Add("MobileDeviceManufacturer", bc.MobileDeviceManufacturer);
            result.Add("MobileDeviceModel", bc.MobileDeviceModel);
            result.Add("MSDomVersion", bc.MSDomVersion);
            result.Add("NumberOfSoftkeys", bc.NumberOfSoftkeys);
            result.Add("Platform", bc.Platform);
            result.Add("PreferredImageMime", bc.PreferredImageMime);
            result.Add("PreferredRenderingMime", bc.PreferredRenderingMime);
            result.Add("PreferredRenderingType", bc.PreferredRenderingType);
            result.Add("PreferredRequestEncoding", bc.PreferredRequestEncoding);
            result.Add("PreferredResponseEncoding", bc.PreferredResponseEncoding);
            result.Add("RendersBreakBeforeWmlSelectAndInput", bc.RendersBreakBeforeWmlSelectAndInput);
            result.Add("RendersBreaksAfterHtmlLists", bc.RendersBreaksAfterHtmlLists);
            result.Add("RendersBreaksAfterWmlAnchor", bc.RendersBreaksAfterWmlAnchor);
            result.Add("RendersBreaksAfterWmlInput", bc.RendersBreaksAfterWmlInput);
            result.Add("RendersWmlDoAcceptsInline", bc.RendersWmlDoAcceptsInline);
            result.Add("RendersWmlSelectsAsMenuCards", bc.RendersWmlSelectsAsMenuCards);
            result.Add("RequiredMetaTagNameValue", bc.RequiredMetaTagNameValue);
            result.Add("RequiresAttributeColonSubstitution", bc.RequiresAttributeColonSubstitution);
            result.Add("RequiresContentTypeMetaTag", bc.RequiresContentTypeMetaTag);
            result.Add("RequiresControlStateInSession", bc.RequiresControlStateInSession);
            result.Add("RequiresDBCSCharacter", bc.RequiresDBCSCharacter);
            result.Add("RequiresHtmlAdaptiveErrorReporting", bc.RequiresHtmlAdaptiveErrorReporting);
            result.Add("RequiresLeadingPageBreak", bc.RequiresLeadingPageBreak);
            result.Add("RequiresNoBreakInFormatting", bc.RequiresNoBreakInFormatting);
            result.Add("RequiresOutputOptimization", bc.RequiresOutputOptimization);
            result.Add("RequiresPhoneNumbersAsPlainText", bc.RequiresPhoneNumbersAsPlainText);
            result.Add("RequiresSpecialViewStateEncoding", bc.RequiresSpecialViewStateEncoding);
            result.Add("RequiresUniqueFilePathSuffix", bc.RequiresUniqueFilePathSuffix);
            result.Add("RequiresUniqueHtmlCheckboxNames", bc.RequiresUniqueHtmlCheckboxNames);
            result.Add("RequiresUniqueHtmlInputNames", bc.RequiresUniqueHtmlInputNames);
            result.Add("RequiresUrlEncodedPostfieldValues", bc.RequiresUrlEncodedPostfieldValues);
            result.Add("ScreenBitDepth", bc.ScreenBitDepth);
            result.Add("ScreenCharactersHeight", bc.ScreenCharactersHeight);
            result.Add("ScreenCharactersWidth", bc.ScreenCharactersWidth);
            result.Add("ScreenPixelsHeight", bc.ScreenPixelsHeight);
            result.Add("ScreenPixelsWidth", bc.ScreenPixelsWidth);
            result.Add("SupportsAccesskeyAttribute", bc.SupportsAccesskeyAttribute);
            result.Add("SupportsBodyColor", bc.SupportsBodyColor);
            result.Add("SupportsBold", bc.SupportsBold);
            result.Add("SupportsCacheControlMetaTag", bc.SupportsCacheControlMetaTag);
            result.Add("SupportsCallback", bc.SupportsCallback);
            result.Add("SupportsCss", bc.SupportsCss);
            result.Add("SupportsDivAlign", bc.SupportsDivAlign);
            result.Add("SupportsDivNoWrap", bc.SupportsDivNoWrap);
            result.Add("SupportsEmptyStringInCookieValue", bc.SupportsEmptyStringInCookieValue);
            result.Add("SupportsFontColor", bc.SupportsFontColor);
            result.Add("SupportsFontName", bc.SupportsFontName);
            result.Add("SupportsFontSize", bc.SupportsFontSize);
            result.Add("SupportsImageSubmit", bc.SupportsImageSubmit);
            result.Add("SupportsIModeSymbols", bc.SupportsIModeSymbols);
            result.Add("SupportsInputIStyle", bc.SupportsInputIStyle);
            result.Add("SupportsInputMode", bc.SupportsInputMode);
            result.Add("SupportsItalic", bc.SupportsItalic);
            result.Add("SupportsJPhoneMultiMediaAttributes", bc.SupportsJPhoneMultiMediaAttributes);
            result.Add("SupportsJPhoneSymbols", bc.SupportsJPhoneSymbols);
            result.Add("SupportsQueryStringInFormAction", bc.SupportsQueryStringInFormAction);
            result.Add("SupportsRedirectWithCookie", bc.SupportsRedirectWithCookie);
            result.Add("SupportsSelectMultiple", bc.SupportsSelectMultiple);
            result.Add("SupportsUncheck", bc.SupportsUncheck);
            result.Add("SupportsXmlHttp", bc.SupportsXmlHttp);
            result.Add("Tables", bc.Tables);
            result.Add("TagWriter", bc.TagWriter);
            result.Add("Type", bc.Type);
            result.Add("UseOptimizedCacheKey", bc.UseOptimizedCacheKey);
            result.Add("VBScript", bc.VBScript);
            result.Add("Version", bc.Version);
            result.Add("W3CDomVersion", bc.W3CDomVersion);
            result.Add("Win16", bc.Win16);
            result.Add("Win32", bc.Win32);

            return result;
        }
        public static IDictionary<string, string> ToDictionary(this HttpRequestBase request, RequestRead whatToRead)
        {
            var result = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

            if ((whatToRead & RequestRead.ServerVariables) == RequestRead.ServerVariables)
            {
                if (request.ServerVariables != null)
                {
                    foreach (string key in request.ServerVariables)
                    {
                        if (!result.ContainsKey(key))
                        {
                            result.Add(key, request.ServerVariables[key]);
                        }
                        else
                        {
                            result[key] = request.ServerVariables[key];
                        }
                    }
                }
            }
            if ((whatToRead & RequestRead.Headers) == RequestRead.Headers)
            {
                if (request.Headers != null)
                {
                    foreach (string key in request.Headers)
                    {
                        if (!result.ContainsKey(key))
                        {
                            result.Add(key, request.Headers[key]);
                        }
                        else
                        {
                            result[key] = request.Headers[key];
                        }
                    }
                }
            }
            if ((whatToRead & RequestRead.Querystring) == RequestRead.Querystring)
            {
                if (request.QueryString != null)
                {
                    foreach (string key in request.QueryString)
                    {
                        if (!result.ContainsKey(key))
                        {
                            result.Add(key, request.QueryString[key]);
                        }
                        else
                        {
                            result[key] = request.QueryString[key];
                        }
                    }
                }
            }
            if ((whatToRead & RequestRead.Form) == RequestRead.Form)
            {
                if (request.Form != null)
                {
                    foreach (string key in request.Form)
                    {
                        if (!result.ContainsKey(key))
                        {
                            result.Add(key, request.Form[key]);
                        }
                        else
                        {
                            result[key] = request.Form[key];
                        }
                    }
                }
            }

            return result;
        }

        public static IDictionary<string, object> AsDictionary(this HttpRequestBase request)
        {
            var result = new Dictionary<string, object>();

            if (request.Form != null)
            {
                result.Add("Form", request.Form.Count.ToString());

                foreach (string key in request.Form)
                {
                    result.Add("Form." + key, request.Form[key]);
                }
            }
            else
            {
                result.Add("Form", "0");
            }

            return result;
        }
        public static IDictionary<string, object> ToCollection(this HttpRequestBase request, Func<string, object, object> transform = null)
        {
            var result = new Dictionary<string, object>();
            Func<string, object, object> _transform = (key, value) =>
            {
                var _result = transform == null ? value : transform(key, value);

                return _result ?? value;
            };

            result.Add("AcceptTypes", _transform("AcceptTypes", request.AcceptTypes));
            result.Add("AnonymousID", _transform("AnonymousID", request.AnonymousID));
            result.Add("ApplicationPath", _transform("ApplicationPath", request.ApplicationPath));
            result.Add("AppRelativeCurrentExecutionFilePath", _transform("AppRelativeCurrentExecutionFilePath", request.AppRelativeCurrentExecutionFilePath));
            result.Add("Browser", _transform("Browser", request.Browser));
            result.Add("ClientCertificate", _transform("ClientCertificate", request.ClientCertificate));
            result.Add("ContentEncoding", _transform("ContentEncoding", request.ContentEncoding));
            result.Add("ContentLength", _transform("ContentLength", request.ContentLength));
            result.Add("ContentType", _transform("ContentType", request.ContentType));
            result.Add("Cookies", _transform("Cookies", request.Cookies));
            result.Add("CurrentExecutionFilePath", _transform("CurrentExecutionFilePath", request.CurrentExecutionFilePath));
            result.Add("CurrentExecutionFilePathExtension", _transform("CurrentExecutionFilePathExtension", request.CurrentExecutionFilePathExtension));
            result.Add("FilePath", _transform("FilePath", request.FilePath));
            result.Add("Files", _transform("Files", request.Files));
            result.Add("Filter", _transform("Filter", request.Filter));
            result.Add("Form", _transform("Form", request.Form));
            result.Add("Headers", _transform("Headers", request.Headers));
            result.Add("HttpChannelBinding", _transform("HttpChannelBinding", request.HttpChannelBinding));
            result.Add("HttpMethod", _transform("HttpMethod", request.HttpMethod));
            result.Add("InputStream", _transform("InputStream", request.InputStream));
            result.Add("IsAuthenticated", _transform("IsAuthenticated", request.IsAuthenticated));
            result.Add("IsLocal", _transform("IsLocal", request.IsLocal));
            result.Add("IsSecureConnection", _transform("IsSecureConnection", request.IsSecureConnection));
            result.Add("LogonUserIdentity", _transform("LogonUserIdentity", request.LogonUserIdentity));
            result.Add("Params", _transform("Params", request.Params));
            result.Add("Path", _transform("Path", request.Path));
            result.Add("PathInfo", _transform("PathInfo", request.PathInfo));
            result.Add("PhysicalApplicationPath", _transform("PhysicalApplicationPath", request.PhysicalApplicationPath));
            result.Add("PhysicalPath", _transform("PhysicalPath", request.PhysicalPath));
            result.Add("QueryString", _transform("QueryString", request.QueryString));
            result.Add("RawUrl", _transform("RawUrl", request.RawUrl));
            result.Add("ReadEntityBodyMode", _transform("ReadEntityBodyMode", request.ReadEntityBodyMode));
            result.Add("RequestContext", _transform("RequestContext", request.RequestContext));
            result.Add("RequestType", _transform("RequestType", request.RequestType));
            result.Add("ServerVariables", _transform("ServerVariables", request.ServerVariables));
            result.Add("TimedOutToken", _transform("TimedOutToken", request.TimedOutToken));
            result.Add("TotalBytes", _transform("TotalBytes", request.TotalBytes));
            result.Add("Unvalidated", _transform("Unvalidated", request.Unvalidated));
            result.Add("Url", _transform("Url", request.Url));
            result.Add("UrlReferrer", _transform("UrlReferrer", request.UrlReferrer));
            result.Add("UserAgent", _transform("UserAgent", request.UserAgent));
            result.Add("UserHostAddress", _transform("UserHostAddress", request.UserHostAddress));
            result.Add("UserHostName", _transform("UserHostName", request.UserHostName));
            result.Add("UserLanguages", _transform("UserLanguages", request.UserLanguages));

            return result;
        }
        public static string Join(this HttpCookieCollection c, string separator = ",")
        {
            var sb = new StringBuilder();

            for (int i = 0; i < c.Count; i++)
            {
                sb.Append(String.Format("{0} {1}: {2}", (i > 0) ? separator : "", c.GetKey(i), c.Get(i)));
            }

            return sb.ToString();
        }
        public static string Join(this HttpCookieCollection cookies, Func<HttpCookie, string> transform, string separator = ",")
        {
            var sb = new StringBuilder();
            var i = 0;
            foreach (HttpCookie c in cookies)
            {
                sb.Append(String.Format("{0} {1}", (i > 0) ? separator : "", transform(c)));
                i++;
            }
            return sb.ToString();
        }
        public static IDictionary<string, object> ToCollection(this Uri uri, Func<string, object, object> transform = null)
        {
            var result = new Dictionary<string, object>();
            Func<string, object, object> _transform = (key, value) =>
            {
                var _result = transform == null ? value : transform(key, value);

                return _result ?? value;
            };

            try { result.Add("AbsolutePath", _transform("AbsolutePath", uri.AbsolutePath)); }
            catch { result.Add("AbsolutePath", null); }
            try { result.Add("AbsoluteUri", _transform("AbsoluteUri", uri.AbsoluteUri)); }
            catch { result.Add("AbsoluteUri", null); }
            try { result.Add("Authority", _transform("Authority", uri.Authority)); }
            catch { result.Add("Authority", null); }
            try { result.Add("DnsSafeHost", _transform("DnsSafeHost", uri.DnsSafeHost)); }
            catch { result.Add("DnsSafeHost", null); }
            try { result.Add("Fragment", _transform("Fragment", uri.Fragment)); }
            catch { result.Add("Fragment", null); }
            try { result.Add("Host", _transform("Host", uri.Host)); }
            catch { result.Add("Host", null); }
            try { result.Add("HostNameType", _transform("HostNameType", uri.HostNameType)); }
            catch { result.Add("HostNameType", null); }
            try { result.Add("IsAbsoluteUri", _transform("IsAbsoluteUri", uri.IsAbsoluteUri)); }
            catch { result.Add("IsAbsoluteUri", null); }
            try { result.Add("IsDefaultPort", _transform("IsDefaultPort", uri.IsDefaultPort)); }
            catch { result.Add("IsDefaultPort", null); }
            try { result.Add("IsFile", _transform("IsFile", uri.IsFile)); }
            catch { result.Add("IsFile", null); }
            try { result.Add("IsLoopback", _transform("IsLoopback", uri.IsLoopback)); }
            catch { result.Add("IsLoopback", null); }
            try { result.Add("IsUnc", _transform("IsUnc", uri.IsUnc)); }
            catch { result.Add("IsUnc", null); }
            try { result.Add("IsWellFormedOriginalString", _transform("IsWellFormedOriginalString", uri.IsWellFormedOriginalString())); }
            catch { result.Add("IsWellFormedOriginalString", null); }
            try { result.Add("LocalPath", _transform("LocalPath", uri.LocalPath)); }
            catch { result.Add("LocalPath", null); }
            try { result.Add("OriginalString", _transform("OriginalString", uri.OriginalString)); }
            catch { result.Add("OriginalString", null); }
            try { result.Add("PathAndQuery", _transform("PathAndQuery", uri.PathAndQuery)); }
            catch { result.Add("PathAndQuery", null); }
            try { result.Add("Port", _transform("Port", uri.Port)); }
            catch { result.Add("Port", null); }
            try { result.Add("Query", _transform("Query", uri.Query)); }
            catch { result.Add("Query", null); }
            try { result.Add("Scheme", _transform("Scheme", uri.Scheme)); }
            catch { result.Add("Scheme", null); }
            try { result.Add("Segments", _transform("Segments", uri.Segments.Join(','))); }
            catch { result.Add("Segments", null); }
            try { result.Add("UserEscaped", _transform("UserEscaped", uri.UserEscaped)); }
            catch { result.Add("UserEscaped", null); }
            try { result.Add("UserInfo", _transform("UserInfo", uri.UserInfo)); }
            catch { result.Add("UserInfo", null); }

            return result;
        }
        public static string GetClientIpAddress(this HttpRequest request)
        {
            var requestBase = new HttpRequestWrapper(request);

            return requestBase.GetClientIpAddress();
        }
        public static string GetClientIpAddress(this HttpRequestBase request)
        {
            try
            {
                var userHostAddress = request.UserHostAddress;

                // Attempt to parse.  If it fails, we catch below and return "0.0.0.0"
                // Could use TryParse instead, but I wanted to catch all exceptions
                IPAddress.Parse(userHostAddress);

                var xForwardedFor = request.ServerVariables["X_FORWARDED_FOR"];

                if (string.IsNullOrEmpty(xForwardedFor))
                {
                    if (string.IsNullOrEmpty(userHostAddress))
                        return "0.0.0.0";
                    else
                        if (userHostAddress == "::1")
                        return "127.0.0.1";
                    else
                        return userHostAddress;
                }

                // Get a list of public ip addresses in the X_FORWARDED_FOR variable
                var publicForwardingIps = xForwardedFor.Split(',').Where(ip => !IsPrivateIpAddress(ip)).ToList();

                // If we found any, return the last one, otherwise return the user host address
                return publicForwardingIps.Any() ? publicForwardingIps.Last() : userHostAddress;
            }
            catch (Exception)
            {
                // Always return all zeroes for any failure (my calling code expects it)
                return "0.0.0.0";
            }
        }
        private static bool IsPrivateIpAddress(string ipAddress)
        {
            // http://en.wikipedia.org/wiki/Private_network
            // Private IP Addresses are: 
            //  24-bit block: 10.0.0.0 through 10.255.255.255
            //  20-bit block: 172.16.0.0 through 172.31.255.255
            //  16-bit block: 192.168.0.0 through 192.168.255.255
            //  Link-local addresses: 169.254.0.0 through 169.254.255.255 (http://en.wikipedia.org/wiki/Link-local_address)

            var ip = IPAddress.Parse(ipAddress);
            var octets = ip.GetAddressBytes();

            var is24BitBlock = octets[0] == 10;
            if (is24BitBlock) return true; // Return to prevent further processing

            var is20BitBlock = octets[0] == 172 && octets[1] >= 16 && octets[1] <= 31;
            if (is20BitBlock) return true; // Return to prevent further processing

            var is16BitBlock = octets[0] == 192 && octets[1] == 168;
            if (is16BitBlock) return true; // Return to prevent further processing

            var isLinkLocalAddress = octets[0] == 169 && octets[1] == 254;
            return isLinkLocalAddress;
        }
        public static string MyUserName(this HttpContextBase context)
        {
            return context.User?.Identity?.Name;
        }
        public static string MyRoleName(this HttpContextBase context)
        {
            return context.User?.Identity?.GetRoleName();
        }
        public static string MyRoleNames(this HttpContextBase context)
        {
            return context.User?.Identity?.GetRoleNames();
        }
    }
}
