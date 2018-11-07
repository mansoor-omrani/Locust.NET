using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.WebTools.Providers
{
    public class FakeChromeBrowserCapabilities : FakeHttpBrowserCapabilities
    {
        public FakeChromeBrowserCapabilities()
        {
            SetActiveXControls(false);
            SetAOL(false);
            SetBackgroundSounds(false);
            SetBeta(false);
            SetBrowser("Chrome");
            SetBrowsers(new ArrayList { "default", "mozilla", "webkit", "chrome" });
            SetCanCombineFormsInDeck(true);
            SetCanInitiateVoiceCall(false);
            SetCanRenderAfterInputOrSelectElement(true);
            SetCanRenderEmptySelects(true);
            SetCanRenderInputAndSelectElementsTogether(true);
            SetCanRenderMixedSelects(true);
            SetCanRenderOneventAndPrevElementsTogether(true);
            SetCanRenderPostBackCards(true);
            SetCanRenderSetvarZeroWithMultiSelectionList(true);
            SetCanSendMail(true);
            SetCapabilities(new Hashtable {
                {"canInitiateVoiceCall","false"},
                {"isColor","true"},
                {"supportsDivAlign","true"},
                {"requiresFullyQualifiedRedirectUrl","false"},
                {"requiresAttributeColonSubstitution","false"},
                {"maximumRenderedPageSize","300000"},
                {"backgroundsounds","false"},
                {"requiresUniqueHtmlCheckboxNames","false"},
                {"rendersBreakBeforeWmlSelectAndInput","false"},
                {"supportsItalic","true"},
                {"ecmascriptversion","3.0"},
                {"supportsXmlHttp","true"},
                {"isMobileDevice","false"},
                {"rendersBreaksAfterWmlInput","false"},
                {"preferredRenderingMime","text/html"},
                {"vbscript","false"},
                {"w3cdomversion","1.0"},
                {"rendersWmlSelectsAsMenuCards","false"},
                {"supportsAccesskeyAttribute","true"},
                {"supportsDivNoWrap","false"},
                {"requiresLeadingPageBreak","false"},
                {"rendersWmlDoAcceptsInline","true"},
                {"requiresPhoneNumbersAsPlainText","false"},
                {"SupportsMaintainScrollPositionOnPostback","true"},
                {"minorversion","0"},
                {"jscriptversion","0.0"},
                {"supportsImageSubmit","true"},
                {"preferredImageMime","image/gif"},
                {"supportsVCard","false"},
                {"screenBitDepth","8"},
                {"requiresOutputOptimization","false"},
                {"layoutEngineVersion","537"},
                {"requiresContentTypeMetaTag","false"},
                {"gatewayVersion","None"},
                {"supportsFontName","true"},
                {"inputType","keyboard"},
                {"maximumSoftkeyLabelLength","5"},
                {"version","67.0"},
                {"beta","false"},
                {"canRenderOneventAndPrevElementsTogether","true"},
                {"supportsIModeSymbols","false"},
                {"requiresAdaptiveErrorReporting","false"},
                {"requiresUrlEncodedPostfieldValues","false" },
                { "aol","false"},
                { "crawler","false"},
                { "requiresSpecialViewStateEncoding","false"},
                { "win16","false"},
                { "majorversion","67"},
                { "supportsQueryStringInFormAction","true"},
                { "requiresPostRedirectionHandling","false"},
                { "requiresNoBreakInFormatting","false"},
                { "requiresXhtmlCssSuppression","false"},
                { "canRenderSetvarZeroWithMultiSelectionList","true"},
                { "preferredRenderingType","html32"},
                { "mobileDeviceModel","Unknown"},
                { "requiresControlStateInSession","false"},
                { "gatewayMajorVersion","0"},
                { "javascriptversion","1.7"},
                { "canCombineFormsInDeck","true"},
                { "cookies","true"},
                { "frames","true"},
                { "requiresAbsolutePostbackUrl","false"},
                { "supportsJPhoneMultiMediaAttributes","false"},
                { "javaapplets","true"},
                { "supportsEmptyStringInCookieValue","true"},
                { "canRenderAfterInputOrSelectElement","true" },
                { "supportsSelectMultiple","true"},
                { "mobileDeviceManufacturer","Unknown"},
                { "javascript","true"},
                { "tagwriter","System.Web.UI.HtmlTextWriter"},
                { "canSendMail","true"},
                { "supportsCallback","true"},
                { "supportsUncheck","true"},
                { "platform","WinNT"},
                { "canRenderPostBackCards","true"},
                { "defaultSubmitButtonLimit","1"},
                { "requiresUniqueHtmlInputNames","false"},
                { "cdf","false"},
                { "supportsFileUpload","true"},
                { "supportsBodyColor","true"},
                { "canRenderMixedSelects","true"},
                { "hasBackButton","true"},
                { "gatewayMinorVersion","0"},
                { "maximumHrefLength","10000" },
                { "tables","true"},
                { "hidesRightAlignedMultiselectScrollbars","false"},
                { "browser","Chrome"},
                { "supportsFontColor","true"},
                { "layoutEngine","WebKit"},
                { "activexcontrols","false"},
                { "msdomversion","0.0"},
                { "supportsCss","true"},
                { "supportsMultilineTextBoxDisplay","true"},
                { "win32","true"},
                { "supportsCacheControlMetaTag","true"},
                { "requiredMetaTagNameValue",""},
                { "canRenderInputAndSelectElementsTogether","true"},
                { "canRenderEmptySelects","true"},
                { "supportsBold","true"},
                { "rendersBreaksAfterHtmlLists","true"},
                { "supportsRedirectWithCookie","true"},
                { "supportsInputMode","false"},
                { "supportsJPhoneSymbols","false"},
                { "numberOfSoftkeys","0"},
                { "requiresDBCSCharacter","false"},
                { "rendersBreaksAfterWmlAnchor","false"},
                { "supportsFontSize","true"},
                { "supportsInputIStyle","false"},
                { "requiresUniqueFilePathSuffix","false"},
                { "type","Chrome67"}
            });

            SetCDF(false);
            SetClrVersion(new System.Version(0, 0));
            SetCookies(true);
            SetCrawler(false);
            SetDefaultSubmitButtonLimit(1);
            SetEcmaScriptVersion(new System.Version(3, 0));
            SetFrames(true);
            SetGatewayMajorVersion(0);
            SetGatewayMinorVersion(0);
            SetGatewayVersion("None");
            SetHasBackButton(true);
            SetHidesRightAlignedMultiselectScrollbars(false);
            SetHtmlTextWriter("");
            SetId("chrome");
            SetInputType("keyboard");
            SetIsColor(true);
            SetIsMobileDevice(false);
            SetJavaApplets(true);
            SetJScriptVersion(new System.Version(0, 0));
            SetMajorVersion(67);
            SetMaximumHrefLength(10000);
            SetMaximumRenderedPageSize(300000);
            SetMaximumSoftkeyLabelLength(5);
            SetMinorVersion(0);
            SetMinorVersionString("0");
            SetMobileDeviceManufacturer("Unknown");
            SetMobileDeviceModel("Unknown");
            SetMSDomVersion(new System.Version(0, 0));
            SetNumberOfSoftkeys(0);
            SetPlatform("WinNT");
            SetPreferredImageMime("image/gif");
            SetPreferredRenderingMime("text/html");
            SetPreferredRenderingType("html32");
            SetRendersBreakBeforeWmlSelectAndInput(false);
            SetRendersBreaksAfterHtmlLists(true);
            SetRendersBreaksAfterWmlAnchor(false);
            SetRendersBreaksAfterWmlInput(false);
            SetRendersWmlDoAcceptsInline(true);
            SetRendersWmlSelectsAsMenuCards(false);
            SetRequiresAttributeColonSubstitution(false);
            SetRequiresContentTypeMetaTag(false);
            SetRequiresControlStateInSession(false);
            SetRequiresDBCSCharacter(false);
            SetRequiresHtmlAdaptiveErrorReporting(false);
            SetRequiresLeadingPageBreak(false);
            SetRequiresNoBreakInFormatting(false);
            SetRequiresOutputOptimization(false);
            SetRequiresPhoneNumbersAsPlainText(false);
            SetRequiresSpecialViewStateEncoding(false);
            SetRequiresUniqueFilePathSuffix(false);
            SetRequiresUniqueHtmlCheckboxNames(false);
            SetRequiresUniqueHtmlInputNames(false);
            SetRequiresUrlEncodedPostfieldValues(false);
            SetScreenBitDepth(8);
            SetScreenCharactersHeight(40);
            SetScreenCharactersWidth(80);
            SetScreenPixelsHeight(480);
            SetScreenPixelsWidth(640);
            SetSupportsAccesskeyAttribute(true);
            SetSupportsBodyColor(true);
            SetSupportsBold(true);
            SetSupportsCacheControlMetaTag(true);
            SetSupportsCallback(true);
            SetSupportsCss(true);
            SetSupportsDivAlign(true);
            SetSupportsDivNoWrap(false);
            SetSupportsEmptyStringInCookieValue(true);
            SetSupportsFontColor(true);
            SetSupportsFontName(true);
            SetSupportsFontSize(true);
            SetSupportsImageSubmit(true);
            SetSupportsIModeSymbols(false);
            SetSupportsInputIStyle(false);
            SetSupportsInputMode(false);
            SetSupportsItalic(true);
            SetSupportsJPhoneMultiMediaAttributes(false);
            SetSupportsJPhoneSymbols(false);
            SetSupportsQueryStringInFormAction(true);
            SetSupportsRedirectWithCookie(true);
            SetSupportsSelectMultiple(true);
            SetSupportsUncheck(true);
            SetSupportsXmlHttp(true);
            SetTables(true);
            SetTagWriter(typeof(System.Web.UI.HtmlTextWriter));
            SetType("Chrome67");
            SetUseOptimizedCacheKey(true);
            SetVBScript(false);
            SetVersion("67.0");
            SetW3CDomVersion(new System.Version(1, 0));
            SetWin16(false);
            SetWin32(true);
        }
    }
}
