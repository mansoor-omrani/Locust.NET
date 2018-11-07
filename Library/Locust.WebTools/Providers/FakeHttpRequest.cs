using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;

namespace Locust.WebTools.Providers
{
    public class FakeHttpRequest: HttpRequestBase
    {
        #region AcceptTypes
        private string[] acceptTypes;
        public override string[] AcceptTypes
        {
            get
            {
                return acceptTypes;
            }
        }
        public void SetAcceptTypes(string[] value)
        {
            acceptTypes = value;
        }
        #endregion
        #region AnonymousID
        private string anonymousID;
        public override string AnonymousID
        {
            get
            {
                return anonymousID;
            }
        }
        public void SetAnonymousID(string value)
        {
            anonymousID = value;
        }
        #endregion
        #region ApplicationPath
        private string applicationPath;
        public override string ApplicationPath
        {
            get
            {
                return applicationPath;
            }
        }
        public void SetApplicationPath(string value)
        {
            applicationPath = value;
        }
        #endregion
        #region AppRelativeCurrentExecutionFilePath
        private string appRelativeCurrentExecutionFilePath;
        public override string AppRelativeCurrentExecutionFilePath
        {
            get
            {
                return appRelativeCurrentExecutionFilePath;
            }
        }
        public void SetAppRelativeCurrentExecutionFilePath(string value)
        {
            appRelativeCurrentExecutionFilePath = value;
        }
        #endregion
        #region Browser
        private HttpBrowserCapabilitiesBase browser;
        public override HttpBrowserCapabilitiesBase Browser
        {
            get
            {
                return browser;
            }
        }
        public void SetBrowser(HttpBrowserCapabilitiesBase value)
        {
            browser = value;
        }
        #endregion
        #region ClientCertificate
        private HttpClientCertificate clientCertificate;
        public override HttpClientCertificate ClientCertificate
        {
            get
            {
                return clientCertificate;
            }
        }
        public void SetClientCertificate(HttpClientCertificate value)
        {
            clientCertificate = value;
        }
        #endregion
        #region ContentEncoding
        private Encoding contentEncoding;
        public override Encoding ContentEncoding
        {
            get
            {
                return contentEncoding;
            }
        }
        public void SetContentEncoding(Encoding value)
        {
            contentEncoding = value;
        }
        #endregion
        #region ContentLength
        private int contentLength;
        public override int ContentLength
        {
            get
            {
                return contentLength;
            }
        }
        public void SetContentLength(int value)
        {
            contentLength = value;
        }
        #endregion
        #region ContentType
        private string contentType;
        public override string ContentType
        {
            get
            {
                return contentType;
            }
        }
        public void SetContentType(string value)
        {
            contentType = value;
        }
        #endregion
        #region Cookies
        private HttpCookieCollection cookies;
        public override HttpCookieCollection Cookies
        {
            get
            {
                return cookies;
            }
        }
        public void SetCookies(HttpCookieCollection value)
        {
            cookies = value;
        }
        #endregion
        #region CurrentExecutionFilePath
        private string currentExecutionFilePath;
        public override string CurrentExecutionFilePath
        {
            get
            {
                return currentExecutionFilePath;
            }
        }
        public void SetCurrentExecutionFilePath(string value)
        {
            currentExecutionFilePath = value;
        }
        #endregion
        #region CurrentExecutionFilePathExtension
        private string currentExecutionFilePathExtension;
        public override string CurrentExecutionFilePathExtension
        {
            get
            {
                return currentExecutionFilePathExtension;
            }
        }
        public void SetCurrentExecutionFilePathExtension(string value)
        {
            currentExecutionFilePathExtension = value;
        }
        #endregion
        #region FilePath
        private string filePath;
        public override string FilePath
        {
            get
            {
                return filePath;
            }
        }
        public void SetFilePath(string value)
        {
            filePath = value;
        }
        #endregion
        #region Files
        private HttpFileCollectionBase files;
        public override HttpFileCollectionBase Files
        {
            get
            {
                return files;
            }
        }
        public void SetFiles(HttpFileCollectionBase value)
        {
            files = value;
        }
        #endregion
        #region Form
        private NameValueCollection form;
        public override NameValueCollection Form
        {
            get
            {
                return form;
            }
        }
        public void SetForm(NameValueCollection value)
        {
            form = value;
        }
        #endregion
        #region Headers
        private NameValueCollection headers;
        public override NameValueCollection Headers
        {
            get
            {
                return headers;
            }
        }
        public void SetHeaders(NameValueCollection value)
        {
            headers = value;
        }
        #endregion
        #region HttpChannelBinding
        private ChannelBinding httpChannelBinding;
        public override ChannelBinding HttpChannelBinding
        {
            get
            {
                return httpChannelBinding;
            }
        }
        public void SetHttpChannelBinding(ChannelBinding value)
        {
            httpChannelBinding = value;
        }
        #endregion
        #region HttpMethod
        private string httpMethod;
        public override string HttpMethod
        {
            get
            {
                return httpMethod;
            }
        }
        public void SetHttpMethod(string value)
        {
            httpMethod = value;
        }
        #endregion
        #region InputStream
        private Stream inputStream;
        public override Stream InputStream
        {
            get
            {
                return inputStream;
            }
        }
        public void SetInputStream(Stream value)
        {
            inputStream = value;
        }
        #endregion
        #region IsAuthenticated
        private bool isAuthenticated;
        public override bool IsAuthenticated
        {
            get
            {
                return isAuthenticated;
            }
        }
        public void SetIsAuthenticated(bool value)
        {
            isAuthenticated = value;
        }
        #endregion
        #region IsLocal
        private bool isLocal;
        public override bool IsLocal
        {
            get
            {
                return isLocal;
            }
        }
        public void SetIsLocal(bool value)
        {
            isLocal = value;
        }
        #endregion
        #region IsSecureConnection
        private bool isSecureConnection;
        public override bool IsSecureConnection
        {
            get
            {
                return isSecureConnection;
            }
        }
        public void SetIsSecureConnection(bool value)
        {
            isSecureConnection = value;
        }
        #endregion
        #region LogonUserIdentity
        private WindowsIdentity logonUserIdentity;
        public override WindowsIdentity LogonUserIdentity
        {
            get
            {
                return logonUserIdentity;
            }
        }
        public void SetLogonUserIdentity(WindowsIdentity value)
        {
            logonUserIdentity = value;
        }
        #endregion
        #region Params
        private NameValueCollection _params;
        public override NameValueCollection Params
        {
            get
            {
                return _params;
            }
        }
        public void SetParams(NameValueCollection value)
        {
            _params = value;
        }
        #endregion
        #region Path
        private string path;
        public override string Path
        {
            get
            {
                return path;
            }
        }
        public void SetPath(string value)
        {
            path = value;
        }
        #endregion
        #region PathInfo
        private string pathInfo;
        public override string PathInfo
        {
            get
            {
                return pathInfo;
            }
        }
        public void SetPathInfo(string value)
        {
            pathInfo = value;
        }
        #endregion
        #region PhysicalApplicationPath
        private string physicalApplicationPath;
        public override string PhysicalApplicationPath
        {
            get
            {
                return physicalApplicationPath;
            }
        }
        public void SetPhysicalApplicationPath(string value)
        {
            physicalApplicationPath = value;
        }
        #endregion
        #region PhysicalPath
        private string physicalPath;
        public override string PhysicalPath
        {
            get
            {
                return physicalPath;
            }
        }
        public void SetPhysicalPath(string value)
        {
            physicalPath = value;
        }
        #endregion
        #region QueryString
        private NameValueCollection queryString;
        public override NameValueCollection QueryString
        {
            get
            {
                return queryString;
            }
        }
        public void SetQueryString(NameValueCollection value)
        {
            queryString = value;
        }
        #endregion
        #region RawUrl
        private string rawUrl;
        public override string RawUrl
        {
            get
            {
                return rawUrl;
            }
        }
        public void SetRawUrl(string value)
        {
            rawUrl = value;
        }
        #endregion
        #region ReadEntityBodyMode
        private ReadEntityBodyMode readEntityBodyMode;
        public override ReadEntityBodyMode ReadEntityBodyMode
        {
            get
            {
                return readEntityBodyMode;
            }
        }
        public void SetReadEntityBodyMode(ReadEntityBodyMode value)
        {
            readEntityBodyMode = value;
        }
        #endregion
        #region RequestContext
        private RequestContext requestContext;
        public override RequestContext RequestContext
        {
            get
            {
                return requestContext;
            }
        }
        public void SetRequestContext(RequestContext value)
        {
            requestContext = value;
        }
        #endregion
        #region ServerVariables
        private NameValueCollection serverVariables;
        public override NameValueCollection ServerVariables
        {
            get
            {
                return serverVariables;
            }
        }
        public void SetServerVariables(NameValueCollection value)
        {
            serverVariables = value;
        }
        #endregion
        #region TimedOutToken
        private CancellationToken timedOutToken;
        public override CancellationToken TimedOutToken
        {
            get
            {
                return timedOutToken;
            }
        }
        public void SetTimedOutToken(CancellationToken value)
        {
            timedOutToken = value;
        }
        #endregion
        #region TlsTokenBindingInfo
        private ITlsTokenBindingInfo tlsTokenBindingInfo;
        public override ITlsTokenBindingInfo TlsTokenBindingInfo
        {
            get
            {
                return tlsTokenBindingInfo;
            }
        }
        public void SetTlsTokenBindingInfo(ITlsTokenBindingInfo value)
        {
            tlsTokenBindingInfo = value;
        }
        #endregion
        #region TotalBytes
        private int totalBytes;
        public override int TotalBytes
        {
            get
            {
                return totalBytes;
            }
        }
        public void SetTotalBytes(int value)
        {
            totalBytes = value;
        }
        #endregion
        #region Unvalidated
        private UnvalidatedRequestValuesBase unvalidated;
        public override UnvalidatedRequestValuesBase Unvalidated
        {
            get
            {
                return unvalidated;
            }
        }
        public void SetUnvalidated(UnvalidatedRequestValuesBase value)
        {
            unvalidated = value;
        }
        #endregion
        #region Url
        private Uri url;
        public override Uri Url
        {
            get
            {
                return url;
            }
        }
        public void SetUrl(Uri value)
        {
            url = value;
        }
        #endregion
        #region UrlReferrer
        private Uri urlReferrer;
        public override Uri UrlReferrer
        {
            get
            {
                return urlReferrer;
            }
        }
        public void SetUrlReferrer(Uri value)
        {
            urlReferrer = value;
        }
        #endregion
        #region UserAgent
        private string userAgent;
        public override string UserAgent
        {
            get
            {
                return userAgent;
            }
        }
        public void SetUserAgent(string value)
        {
            userAgent = value;
        }
        #endregion
        #region UserHostAddress
        private string userHostAddress;
        public override string UserHostAddress
        {
            get
            {
                return userHostAddress;
            }
        }
        public void SetUserHostAddress(string value)
        {
            userHostAddress = value;
        }
        #endregion
        #region UserHostName
        private string userHostName;
        public override string UserHostName
        {
            get
            {
                return userHostName;
            }
        }
        public void SetUserHostName(string value)
        {
            userHostName = value;
        }
        #endregion
        #region UserLanguages
        private string[] userLanguages;
        public override string[] UserLanguages
        {
            get
            {
                return userLanguages;
            }
        }
        public void SetUserLanguages(string[] value)
        {
            userLanguages = value;
        }
        #endregion

        public FakeHttpRequest()
        {
            browser = new FakeHttpBrowserCapabilities();
            acceptTypes = new string[0];
            SetContentEncoding(Encoding.UTF8);
            SetCookies(new HttpCookieCollection());
            SetForm(new NameValueCollection());
            SetHeaders(new NameValueCollection());
            SetParams(new NameValueCollection());
            SetQueryString(new NameValueCollection());
            SetServerVariables(new NameValueCollection());
            SetUserLanguages(new string[] { "en" });
        }
    }
}
