using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Locust.WebTools.Providers
{
    public class FakeHttpBrowserCapabilities: HttpBrowserCapabilitiesBase
    {

        #region ActiveXControls
        private Boolean activeXControls;
        public override Boolean ActiveXControls
        {
            get
            {
                return activeXControls;
            }
        }
        public void SetActiveXControls(Boolean value)
        {
            activeXControls = value;
        }
        #endregion

        #region Adapters
        private IDictionary adapters;
        public override IDictionary Adapters
        {
            get
            {
                return adapters;
            }
        }
        public void SetAdapters(IDictionary value)
        {
            adapters = value;
        }
        #endregion

        #region AOL
        private Boolean aOL;
        public override Boolean AOL
        {
            get
            {
                return aOL;
            }
        }
        public void SetAOL(Boolean value)
        {
            aOL = value;
        }
        #endregion

        #region BackgroundSounds
        private Boolean backgroundSounds;
        public override Boolean BackgroundSounds
        {
            get
            {
                return backgroundSounds;
            }
        }
        public void SetBackgroundSounds(Boolean value)
        {
            backgroundSounds = value;
        }
        #endregion

        #region Beta
        private Boolean beta;
        public override Boolean Beta
        {
            get
            {
                return beta;
            }
        }
        public void SetBeta(Boolean value)
        {
            beta = value;
        }
        #endregion

        #region Browser
        private String browser;
        public override String Browser
        {
            get
            {
                return browser;
            }
        }
        public void SetBrowser(String value)
        {
            browser = value;
        }
        #endregion

        #region Browsers
        private ArrayList browsers;
        public override ArrayList Browsers
        {
            get
            {
                return browsers;
            }
        }
        public void SetBrowsers(ArrayList value)
        {
            browsers = value;
        }
        #endregion

        #region CanCombineFormsInDeck
        private Boolean canCombineFormsInDeck;
        public override Boolean CanCombineFormsInDeck
        {
            get
            {
                return canCombineFormsInDeck;
            }
        }
        public void SetCanCombineFormsInDeck(Boolean value)
        {
            canCombineFormsInDeck = value;
        }
        #endregion

        #region CanInitiateVoiceCall
        private Boolean canInitiateVoiceCall;
        public override Boolean CanInitiateVoiceCall
        {
            get
            {
                return canInitiateVoiceCall;
            }
        }
        public void SetCanInitiateVoiceCall(Boolean value)
        {
            canInitiateVoiceCall = value;
        }
        #endregion

        #region CanRenderAfterInputOrSelectElement
        private Boolean canRenderAfterInputOrSelectElement;
        public override Boolean CanRenderAfterInputOrSelectElement
        {
            get
            {
                return canRenderAfterInputOrSelectElement;
            }
        }
        public void SetCanRenderAfterInputOrSelectElement(Boolean value)
        {
            canRenderAfterInputOrSelectElement = value;
        }
        #endregion

        #region CanRenderEmptySelects
        private Boolean canRenderEmptySelects;
        public override Boolean CanRenderEmptySelects
        {
            get
            {
                return canRenderEmptySelects;
            }
        }
        public void SetCanRenderEmptySelects(Boolean value)
        {
            canRenderEmptySelects = value;
        }
        #endregion

        #region CanRenderInputAndSelectElementsTogether
        private Boolean canRenderInputAndSelectElementsTogether;
        public override Boolean CanRenderInputAndSelectElementsTogether
        {
            get
            {
                return canRenderInputAndSelectElementsTogether;
            }
        }
        public void SetCanRenderInputAndSelectElementsTogether(Boolean value)
        {
            canRenderInputAndSelectElementsTogether = value;
        }
        #endregion

        #region CanRenderMixedSelects
        private Boolean canRenderMixedSelects;
        public override Boolean CanRenderMixedSelects
        {
            get
            {
                return canRenderMixedSelects;
            }
        }
        public void SetCanRenderMixedSelects(Boolean value)
        {
            canRenderMixedSelects = value;
        }
        #endregion

        #region CanRenderOneventAndPrevElementsTogether
        private Boolean canRenderOneventAndPrevElementsTogether;
        public override Boolean CanRenderOneventAndPrevElementsTogether
        {
            get
            {
                return canRenderOneventAndPrevElementsTogether;
            }
        }
        public void SetCanRenderOneventAndPrevElementsTogether(Boolean value)
        {
            canRenderOneventAndPrevElementsTogether = value;
        }
        #endregion

        #region CanRenderPostBackCards
        private Boolean canRenderPostBackCards;
        public override Boolean CanRenderPostBackCards
        {
            get
            {
                return canRenderPostBackCards;
            }
        }
        public void SetCanRenderPostBackCards(Boolean value)
        {
            canRenderPostBackCards = value;
        }
        #endregion

        #region CanRenderSetvarZeroWithMultiSelectionList
        private Boolean canRenderSetvarZeroWithMultiSelectionList;
        public override Boolean CanRenderSetvarZeroWithMultiSelectionList
        {
            get
            {
                return canRenderSetvarZeroWithMultiSelectionList;
            }
        }
        public void SetCanRenderSetvarZeroWithMultiSelectionList(Boolean value)
        {
            canRenderSetvarZeroWithMultiSelectionList = value;
        }
        #endregion

        #region CanSendMail
        private Boolean canSendMail;
        public override Boolean CanSendMail
        {
            get
            {
                return canSendMail;
            }
        }
        public void SetCanSendMail(Boolean value)
        {
            canSendMail = value;
        }
        #endregion

        #region Capabilities
        private IDictionary capabilities;
        public override IDictionary Capabilities
        {
            get
            {
                return capabilities;
            }
        }
        public void SetCapabilities(IDictionary value)
        {
            capabilities = value;
        }
        #endregion

        #region CDF
        private Boolean cDF;
        public override Boolean CDF
        {
            get
            {
                return cDF;
            }
        }
        public void SetCDF(Boolean value)
        {
            cDF = value;
        }
        #endregion

        #region ClrVersion
        private Version clrVersion;
        public override Version ClrVersion
        {
            get
            {
                return clrVersion;
            }
        }
        public void SetClrVersion(Version value)
        {
            clrVersion = value;
        }
        #endregion

        #region Cookies
        private Boolean cookies;
        public override Boolean Cookies
        {
            get
            {
                return cookies;
            }
        }
        public void SetCookies(Boolean value)
        {
            cookies = value;
        }
        #endregion

        #region Crawler
        private Boolean crawler;
        public override Boolean Crawler
        {
            get
            {
                return crawler;
            }
        }
        public void SetCrawler(Boolean value)
        {
            crawler = value;
        }
        #endregion

        #region DefaultSubmitButtonLimit
        private Int32 defaultSubmitButtonLimit;
        public override Int32 DefaultSubmitButtonLimit
        {
            get
            {
                return defaultSubmitButtonLimit;
            }
        }
        public void SetDefaultSubmitButtonLimit(Int32 value)
        {
            defaultSubmitButtonLimit = value;
        }
        #endregion

        #region EcmaScriptVersion
        private Version ecmaScriptVersion;
        public override Version EcmaScriptVersion
        {
            get
            {
                return ecmaScriptVersion;
            }
        }
        public void SetEcmaScriptVersion(Version value)
        {
            ecmaScriptVersion = value;
        }
        #endregion

        #region Frames
        private Boolean frames;
        public override Boolean Frames
        {
            get
            {
                return frames;
            }
        }
        public void SetFrames(Boolean value)
        {
            frames = value;
        }
        #endregion

        #region GatewayMajorVersion
        private Int32 gatewayMajorVersion;
        public override Int32 GatewayMajorVersion
        {
            get
            {
                return gatewayMajorVersion;
            }
        }
        public void SetGatewayMajorVersion(Int32 value)
        {
            gatewayMajorVersion = value;
        }
        #endregion

        #region GatewayMinorVersion
        private Double gatewayMinorVersion;
        public override Double GatewayMinorVersion
        {
            get
            {
                return gatewayMinorVersion;
            }
        }
        public void SetGatewayMinorVersion(Double value)
        {
            gatewayMinorVersion = value;
        }
        #endregion

        #region GatewayVersion
        private String gatewayVersion;
        public override String GatewayVersion
        {
            get
            {
                return gatewayVersion;
            }
        }
        public void SetGatewayVersion(String value)
        {
            gatewayVersion = value;
        }
        #endregion

        #region HasBackButton
        private Boolean hasBackButton;
        public override Boolean HasBackButton
        {
            get
            {
                return hasBackButton;
            }
        }
        public void SetHasBackButton(Boolean value)
        {
            hasBackButton = value;
        }
        #endregion

        #region HidesRightAlignedMultiselectScrollbars
        private Boolean hidesRightAlignedMultiselectScrollbars;
        public override Boolean HidesRightAlignedMultiselectScrollbars
        {
            get
            {
                return hidesRightAlignedMultiselectScrollbars;
            }
        }
        public void SetHidesRightAlignedMultiselectScrollbars(Boolean value)
        {
            hidesRightAlignedMultiselectScrollbars = value;
        }
        #endregion

        #region HtmlTextWriter
        private String htmlTextWriter;
        public override String HtmlTextWriter
        {
            get
            {
                return htmlTextWriter;
            }
        }
        public void SetHtmlTextWriter(String value)
        {
            htmlTextWriter = value;
        }
        #endregion

        #region Id
        private String id;
        public override String Id
        {
            get
            {
                return id;
            }
        }
        public void SetId(String value)
        {
            id = value;
        }
        #endregion

        #region InputType
        private String inputType;
        public override String InputType
        {
            get
            {
                return inputType;
            }
        }
        public void SetInputType(String value)
        {
            inputType = value;
        }
        #endregion

        #region IsColor
        private Boolean isColor;
        public override Boolean IsColor
        {
            get
            {
                return isColor;
            }
        }
        public void SetIsColor(Boolean value)
        {
            isColor = value;
        }
        #endregion

        #region IsMobileDevice
        private Boolean isMobileDevice;
        public override Boolean IsMobileDevice
        {
            get
            {
                return isMobileDevice;
            }
        }
        public void SetIsMobileDevice(Boolean value)
        {
            isMobileDevice = value;
        }
        #endregion

        #region JavaApplets
        private Boolean javaApplets;
        public override Boolean JavaApplets
        {
            get
            {
                return javaApplets;
            }
        }
        public void SetJavaApplets(Boolean value)
        {
            javaApplets = value;
        }
        #endregion

        #region JScriptVersion
        private Version jScriptVersion;
        public override Version JScriptVersion
        {
            get
            {
                return jScriptVersion;
            }
        }
        public void SetJScriptVersion(Version value)
        {
            jScriptVersion = value;
        }
        #endregion

        #region MajorVersion
        private Int32 majorVersion;
        public override Int32 MajorVersion
        {
            get
            {
                return majorVersion;
            }
        }
        public void SetMajorVersion(Int32 value)
        {
            majorVersion = value;
        }
        #endregion

        #region MaximumHrefLength
        private Int32 maximumHrefLength;
        public override Int32 MaximumHrefLength
        {
            get
            {
                return maximumHrefLength;
            }
        }
        public void SetMaximumHrefLength(Int32 value)
        {
            maximumHrefLength = value;
        }
        #endregion

        #region MaximumRenderedPageSize
        private Int32 maximumRenderedPageSize;
        public override Int32 MaximumRenderedPageSize
        {
            get
            {
                return maximumRenderedPageSize;
            }
        }
        public void SetMaximumRenderedPageSize(Int32 value)
        {
            maximumRenderedPageSize = value;
        }
        #endregion

        #region MaximumSoftkeyLabelLength
        private Int32 maximumSoftkeyLabelLength;
        public override Int32 MaximumSoftkeyLabelLength
        {
            get
            {
                return maximumSoftkeyLabelLength;
            }
        }
        public void SetMaximumSoftkeyLabelLength(Int32 value)
        {
            maximumSoftkeyLabelLength = value;
        }
        #endregion

        #region MinorVersion
        private Double minorVersion;
        public override Double MinorVersion
        {
            get
            {
                return minorVersion;
            }
        }
        public void SetMinorVersion(Double value)
        {
            minorVersion = value;
        }
        #endregion

        #region MinorVersionString
        private String minorVersionString;
        public override String MinorVersionString
        {
            get
            {
                return minorVersionString;
            }
        }
        public void SetMinorVersionString(String value)
        {
            minorVersionString = value;
        }
        #endregion

        #region MobileDeviceManufacturer
        private String mobileDeviceManufacturer;
        public override String MobileDeviceManufacturer
        {
            get
            {
                return mobileDeviceManufacturer;
            }
        }
        public void SetMobileDeviceManufacturer(String value)
        {
            mobileDeviceManufacturer = value;
        }
        #endregion

        #region MobileDeviceModel
        private String mobileDeviceModel;
        public override String MobileDeviceModel
        {
            get
            {
                return mobileDeviceModel;
            }
        }
        public void SetMobileDeviceModel(String value)
        {
            mobileDeviceModel = value;
        }
        #endregion

        #region MSDomVersion
        private Version mSDomVersion;
        public override Version MSDomVersion
        {
            get
            {
                return mSDomVersion;
            }
        }
        public void SetMSDomVersion(Version value)
        {
            mSDomVersion = value;
        }
        #endregion

        #region NumberOfSoftkeys
        private Int32 numberOfSoftkeys;
        public override Int32 NumberOfSoftkeys
        {
            get
            {
                return numberOfSoftkeys;
            }
        }
        public void SetNumberOfSoftkeys(Int32 value)
        {
            numberOfSoftkeys = value;
        }
        #endregion

        #region Platform
        private String platform;
        public override String Platform
        {
            get
            {
                return platform;
            }
        }
        public void SetPlatform(String value)
        {
            platform = value;
        }
        #endregion

        #region PreferredImageMime
        private String preferredImageMime;
        public override String PreferredImageMime
        {
            get
            {
                return preferredImageMime;
            }
        }
        public void SetPreferredImageMime(String value)
        {
            preferredImageMime = value;
        }
        #endregion

        #region PreferredRenderingMime
        private String preferredRenderingMime;
        public override String PreferredRenderingMime
        {
            get
            {
                return preferredRenderingMime;
            }
        }
        public void SetPreferredRenderingMime(String value)
        {
            preferredRenderingMime = value;
        }
        #endregion

        #region PreferredRenderingType
        private String preferredRenderingType;
        public override String PreferredRenderingType
        {
            get
            {
                return preferredRenderingType;
            }
        }
        public void SetPreferredRenderingType(String value)
        {
            preferredRenderingType = value;
        }
        #endregion

        #region PreferredRequestEncoding
        private String preferredRequestEncoding;
        public override String PreferredRequestEncoding
        {
            get
            {
                return preferredRequestEncoding;
            }
        }
        public void SetPreferredRequestEncoding(String value)
        {
            preferredRequestEncoding = value;
        }
        #endregion

        #region PreferredResponseEncoding
        private String preferredResponseEncoding;
        public override String PreferredResponseEncoding
        {
            get
            {
                return preferredResponseEncoding;
            }
        }
        public void SetPreferredResponseEncoding(String value)
        {
            preferredResponseEncoding = value;
        }
        #endregion

        #region RendersBreakBeforeWmlSelectAndInput
        private Boolean rendersBreakBeforeWmlSelectAndInput;
        public override Boolean RendersBreakBeforeWmlSelectAndInput
        {
            get
            {
                return rendersBreakBeforeWmlSelectAndInput;
            }
        }
        public void SetRendersBreakBeforeWmlSelectAndInput(Boolean value)
        {
            rendersBreakBeforeWmlSelectAndInput = value;
        }
        #endregion

        #region RendersBreaksAfterHtmlLists
        private Boolean rendersBreaksAfterHtmlLists;
        public override Boolean RendersBreaksAfterHtmlLists
        {
            get
            {
                return rendersBreaksAfterHtmlLists;
            }
        }
        public void SetRendersBreaksAfterHtmlLists(Boolean value)
        {
            rendersBreaksAfterHtmlLists = value;
        }
        #endregion

        #region RendersBreaksAfterWmlAnchor
        private Boolean rendersBreaksAfterWmlAnchor;
        public override Boolean RendersBreaksAfterWmlAnchor
        {
            get
            {
                return rendersBreaksAfterWmlAnchor;
            }
        }
        public void SetRendersBreaksAfterWmlAnchor(Boolean value)
        {
            rendersBreaksAfterWmlAnchor = value;
        }
        #endregion

        #region RendersBreaksAfterWmlInput
        private Boolean rendersBreaksAfterWmlInput;
        public override Boolean RendersBreaksAfterWmlInput
        {
            get
            {
                return rendersBreaksAfterWmlInput;
            }
        }
        public void SetRendersBreaksAfterWmlInput(Boolean value)
        {
            rendersBreaksAfterWmlInput = value;
        }
        #endregion

        #region RendersWmlDoAcceptsInline
        private Boolean rendersWmlDoAcceptsInline;
        public override Boolean RendersWmlDoAcceptsInline
        {
            get
            {
                return rendersWmlDoAcceptsInline;
            }
        }
        public void SetRendersWmlDoAcceptsInline(Boolean value)
        {
            rendersWmlDoAcceptsInline = value;
        }
        #endregion

        #region RendersWmlSelectsAsMenuCards
        private Boolean rendersWmlSelectsAsMenuCards;
        public override Boolean RendersWmlSelectsAsMenuCards
        {
            get
            {
                return rendersWmlSelectsAsMenuCards;
            }
        }
        public void SetRendersWmlSelectsAsMenuCards(Boolean value)
        {
            rendersWmlSelectsAsMenuCards = value;
        }
        #endregion

        #region RequiredMetaTagNameValue
        private String requiredMetaTagNameValue;
        public override String RequiredMetaTagNameValue
        {
            get
            {
                return requiredMetaTagNameValue;
            }
        }
        public void SetRequiredMetaTagNameValue(String value)
        {
            requiredMetaTagNameValue = value;
        }
        #endregion

        #region RequiresAttributeColonSubstitution
        private Boolean requiresAttributeColonSubstitution;
        public override Boolean RequiresAttributeColonSubstitution
        {
            get
            {
                return requiresAttributeColonSubstitution;
            }
        }
        public void SetRequiresAttributeColonSubstitution(Boolean value)
        {
            requiresAttributeColonSubstitution = value;
        }
        #endregion

        #region RequiresContentTypeMetaTag
        private Boolean requiresContentTypeMetaTag;
        public override Boolean RequiresContentTypeMetaTag
        {
            get
            {
                return requiresContentTypeMetaTag;
            }
        }
        public void SetRequiresContentTypeMetaTag(Boolean value)
        {
            requiresContentTypeMetaTag = value;
        }
        #endregion

        #region RequiresControlStateInSession
        private Boolean requiresControlStateInSession;
        public override Boolean RequiresControlStateInSession
        {
            get
            {
                return requiresControlStateInSession;
            }
        }
        public void SetRequiresControlStateInSession(Boolean value)
        {
            requiresControlStateInSession = value;
        }
        #endregion

        #region RequiresDBCSCharacter
        private Boolean requiresDBCSCharacter;
        public override Boolean RequiresDBCSCharacter
        {
            get
            {
                return requiresDBCSCharacter;
            }
        }
        public void SetRequiresDBCSCharacter(Boolean value)
        {
            requiresDBCSCharacter = value;
        }
        #endregion

        #region RequiresHtmlAdaptiveErrorReporting
        private Boolean requiresHtmlAdaptiveErrorReporting;
        public override Boolean RequiresHtmlAdaptiveErrorReporting
        {
            get
            {
                return requiresHtmlAdaptiveErrorReporting;
            }
        }
        public void SetRequiresHtmlAdaptiveErrorReporting(Boolean value)
        {
            requiresHtmlAdaptiveErrorReporting = value;
        }
        #endregion

        #region RequiresLeadingPageBreak
        private Boolean requiresLeadingPageBreak;
        public override Boolean RequiresLeadingPageBreak
        {
            get
            {
                return requiresLeadingPageBreak;
            }
        }
        public void SetRequiresLeadingPageBreak(Boolean value)
        {
            requiresLeadingPageBreak = value;
        }
        #endregion

        #region RequiresNoBreakInFormatting
        private Boolean requiresNoBreakInFormatting;
        public override Boolean RequiresNoBreakInFormatting
        {
            get
            {
                return requiresNoBreakInFormatting;
            }
        }
        public void SetRequiresNoBreakInFormatting(Boolean value)
        {
            requiresNoBreakInFormatting = value;
        }
        #endregion

        #region RequiresOutputOptimization
        private Boolean requiresOutputOptimization;
        public override Boolean RequiresOutputOptimization
        {
            get
            {
                return requiresOutputOptimization;
            }
        }
        public void SetRequiresOutputOptimization(Boolean value)
        {
            requiresOutputOptimization = value;
        }
        #endregion

        #region RequiresPhoneNumbersAsPlainText
        private Boolean requiresPhoneNumbersAsPlainText;
        public override Boolean RequiresPhoneNumbersAsPlainText
        {
            get
            {
                return requiresPhoneNumbersAsPlainText;
            }
        }
        public void SetRequiresPhoneNumbersAsPlainText(Boolean value)
        {
            requiresPhoneNumbersAsPlainText = value;
        }
        #endregion

        #region RequiresSpecialViewStateEncoding
        private Boolean requiresSpecialViewStateEncoding;
        public override Boolean RequiresSpecialViewStateEncoding
        {
            get
            {
                return requiresSpecialViewStateEncoding;
            }
        }
        public void SetRequiresSpecialViewStateEncoding(Boolean value)
        {
            requiresSpecialViewStateEncoding = value;
        }
        #endregion

        #region RequiresUniqueFilePathSuffix
        private Boolean requiresUniqueFilePathSuffix;
        public override Boolean RequiresUniqueFilePathSuffix
        {
            get
            {
                return requiresUniqueFilePathSuffix;
            }
        }
        public void SetRequiresUniqueFilePathSuffix(Boolean value)
        {
            requiresUniqueFilePathSuffix = value;
        }
        #endregion

        #region RequiresUniqueHtmlCheckboxNames
        private Boolean requiresUniqueHtmlCheckboxNames;
        public override Boolean RequiresUniqueHtmlCheckboxNames
        {
            get
            {
                return requiresUniqueHtmlCheckboxNames;
            }
        }
        public void SetRequiresUniqueHtmlCheckboxNames(Boolean value)
        {
            requiresUniqueHtmlCheckboxNames = value;
        }
        #endregion

        #region RequiresUniqueHtmlInputNames
        private Boolean requiresUniqueHtmlInputNames;
        public override Boolean RequiresUniqueHtmlInputNames
        {
            get
            {
                return requiresUniqueHtmlInputNames;
            }
        }
        public void SetRequiresUniqueHtmlInputNames(Boolean value)
        {
            requiresUniqueHtmlInputNames = value;
        }
        #endregion

        #region RequiresUrlEncodedPostfieldValues
        private Boolean requiresUrlEncodedPostfieldValues;
        public override Boolean RequiresUrlEncodedPostfieldValues
        {
            get
            {
                return requiresUrlEncodedPostfieldValues;
            }
        }
        public void SetRequiresUrlEncodedPostfieldValues(Boolean value)
        {
            requiresUrlEncodedPostfieldValues = value;
        }
        #endregion

        #region ScreenBitDepth
        private Int32 screenBitDepth;
        public override Int32 ScreenBitDepth
        {
            get
            {
                return screenBitDepth;
            }
        }
        public void SetScreenBitDepth(Int32 value)
        {
            screenBitDepth = value;
        }
        #endregion

        #region ScreenCharactersHeight
        private Int32 screenCharactersHeight;
        public override Int32 ScreenCharactersHeight
        {
            get
            {
                return screenCharactersHeight;
            }
        }
        public void SetScreenCharactersHeight(Int32 value)
        {
            screenCharactersHeight = value;
        }
        #endregion

        #region ScreenCharactersWidth
        private Int32 screenCharactersWidth;
        public override Int32 ScreenCharactersWidth
        {
            get
            {
                return screenCharactersWidth;
            }
        }
        public void SetScreenCharactersWidth(Int32 value)
        {
            screenCharactersWidth = value;
        }
        #endregion

        #region ScreenPixelsHeight
        private Int32 screenPixelsHeight;
        public override Int32 ScreenPixelsHeight
        {
            get
            {
                return screenPixelsHeight;
            }
        }
        public void SetScreenPixelsHeight(Int32 value)
        {
            screenPixelsHeight = value;
        }
        #endregion

        #region ScreenPixelsWidth
        private Int32 screenPixelsWidth;
        public override Int32 ScreenPixelsWidth
        {
            get
            {
                return screenPixelsWidth;
            }
        }
        public void SetScreenPixelsWidth(Int32 value)
        {
            screenPixelsWidth = value;
        }
        #endregion

        #region SupportsAccesskeyAttribute
        private Boolean supportsAccesskeyAttribute;
        public override Boolean SupportsAccesskeyAttribute
        {
            get
            {
                return supportsAccesskeyAttribute;
            }
        }
        public void SetSupportsAccesskeyAttribute(Boolean value)
        {
            supportsAccesskeyAttribute = value;
        }
        #endregion

        #region SupportsBodyColor
        private Boolean supportsBodyColor;
        public override Boolean SupportsBodyColor
        {
            get
            {
                return supportsBodyColor;
            }
        }
        public void SetSupportsBodyColor(Boolean value)
        {
            supportsBodyColor = value;
        }
        #endregion

        #region SupportsBold
        private Boolean supportsBold;
        public override Boolean SupportsBold
        {
            get
            {
                return supportsBold;
            }
        }
        public void SetSupportsBold(Boolean value)
        {
            supportsBold = value;
        }
        #endregion

        #region SupportsCacheControlMetaTag
        private Boolean supportsCacheControlMetaTag;
        public override Boolean SupportsCacheControlMetaTag
        {
            get
            {
                return supportsCacheControlMetaTag;
            }
        }
        public void SetSupportsCacheControlMetaTag(Boolean value)
        {
            supportsCacheControlMetaTag = value;
        }
        #endregion

        #region SupportsCallback
        private Boolean supportsCallback;
        public override Boolean SupportsCallback
        {
            get
            {
                return supportsCallback;
            }
        }
        public void SetSupportsCallback(Boolean value)
        {
            supportsCallback = value;
        }
        #endregion

        #region SupportsCss
        private Boolean supportsCss;
        public override Boolean SupportsCss
        {
            get
            {
                return supportsCss;
            }
        }
        public void SetSupportsCss(Boolean value)
        {
            supportsCss = value;
        }
        #endregion

        #region SupportsDivAlign
        private Boolean supportsDivAlign;
        public override Boolean SupportsDivAlign
        {
            get
            {
                return supportsDivAlign;
            }
        }
        public void SetSupportsDivAlign(Boolean value)
        {
            supportsDivAlign = value;
        }
        #endregion

        #region SupportsDivNoWrap
        private Boolean supportsDivNoWrap;
        public override Boolean SupportsDivNoWrap
        {
            get
            {
                return supportsDivNoWrap;
            }
        }
        public void SetSupportsDivNoWrap(Boolean value)
        {
            supportsDivNoWrap = value;
        }
        #endregion

        #region SupportsEmptyStringInCookieValue
        private Boolean supportsEmptyStringInCookieValue;
        public override Boolean SupportsEmptyStringInCookieValue
        {
            get
            {
                return supportsEmptyStringInCookieValue;
            }
        }
        public void SetSupportsEmptyStringInCookieValue(Boolean value)
        {
            supportsEmptyStringInCookieValue = value;
        }
        #endregion

        #region SupportsFontColor
        private Boolean supportsFontColor;
        public override Boolean SupportsFontColor
        {
            get
            {
                return supportsFontColor;
            }
        }
        public void SetSupportsFontColor(Boolean value)
        {
            supportsFontColor = value;
        }
        #endregion

        #region SupportsFontName
        private Boolean supportsFontName;
        public override Boolean SupportsFontName
        {
            get
            {
                return supportsFontName;
            }
        }
        public void SetSupportsFontName(Boolean value)
        {
            supportsFontName = value;
        }
        #endregion

        #region SupportsFontSize
        private Boolean supportsFontSize;
        public override Boolean SupportsFontSize
        {
            get
            {
                return supportsFontSize;
            }
        }
        public void SetSupportsFontSize(Boolean value)
        {
            supportsFontSize = value;
        }
        #endregion

        #region SupportsImageSubmit
        private Boolean supportsImageSubmit;
        public override Boolean SupportsImageSubmit
        {
            get
            {
                return supportsImageSubmit;
            }
        }
        public void SetSupportsImageSubmit(Boolean value)
        {
            supportsImageSubmit = value;
        }
        #endregion

        #region SupportsIModeSymbols
        private Boolean supportsIModeSymbols;
        public override Boolean SupportsIModeSymbols
        {
            get
            {
                return supportsIModeSymbols;
            }
        }
        public void SetSupportsIModeSymbols(Boolean value)
        {
            supportsIModeSymbols = value;
        }
        #endregion

        #region SupportsInputIStyle
        private Boolean supportsInputIStyle;
        public override Boolean SupportsInputIStyle
        {
            get
            {
                return supportsInputIStyle;
            }
        }
        public void SetSupportsInputIStyle(Boolean value)
        {
            supportsInputIStyle = value;
        }
        #endregion

        #region SupportsInputMode
        private Boolean supportsInputMode;
        public override Boolean SupportsInputMode
        {
            get
            {
                return supportsInputMode;
            }
        }
        public void SetSupportsInputMode(Boolean value)
        {
            supportsInputMode = value;
        }
        #endregion

        #region SupportsItalic
        private Boolean supportsItalic;
        public override Boolean SupportsItalic
        {
            get
            {
                return supportsItalic;
            }
        }
        public void SetSupportsItalic(Boolean value)
        {
            supportsItalic = value;
        }
        #endregion

        #region SupportsJPhoneMultiMediaAttributes
        private Boolean supportsJPhoneMultiMediaAttributes;
        public override Boolean SupportsJPhoneMultiMediaAttributes
        {
            get
            {
                return supportsJPhoneMultiMediaAttributes;
            }
        }
        public void SetSupportsJPhoneMultiMediaAttributes(Boolean value)
        {
            supportsJPhoneMultiMediaAttributes = value;
        }
        #endregion

        #region SupportsJPhoneSymbols
        private Boolean supportsJPhoneSymbols;
        public override Boolean SupportsJPhoneSymbols
        {
            get
            {
                return supportsJPhoneSymbols;
            }
        }
        public void SetSupportsJPhoneSymbols(Boolean value)
        {
            supportsJPhoneSymbols = value;
        }
        #endregion

        #region SupportsQueryStringInFormAction
        private Boolean supportsQueryStringInFormAction;
        public override Boolean SupportsQueryStringInFormAction
        {
            get
            {
                return supportsQueryStringInFormAction;
            }
        }
        public void SetSupportsQueryStringInFormAction(Boolean value)
        {
            supportsQueryStringInFormAction = value;
        }
        #endregion

        #region SupportsRedirectWithCookie
        private Boolean supportsRedirectWithCookie;
        public override Boolean SupportsRedirectWithCookie
        {
            get
            {
                return supportsRedirectWithCookie;
            }
        }
        public void SetSupportsRedirectWithCookie(Boolean value)
        {
            supportsRedirectWithCookie = value;
        }
        #endregion

        #region SupportsSelectMultiple
        private Boolean supportsSelectMultiple;
        public override Boolean SupportsSelectMultiple
        {
            get
            {
                return supportsSelectMultiple;
            }
        }
        public void SetSupportsSelectMultiple(Boolean value)
        {
            supportsSelectMultiple = value;
        }
        #endregion

        #region SupportsUncheck
        private Boolean supportsUncheck;
        public override Boolean SupportsUncheck
        {
            get
            {
                return supportsUncheck;
            }
        }
        public void SetSupportsUncheck(Boolean value)
        {
            supportsUncheck = value;
        }
        #endregion

        #region SupportsXmlHttp
        private Boolean supportsXmlHttp;
        public override Boolean SupportsXmlHttp
        {
            get
            {
                return supportsXmlHttp;
            }
        }
        public void SetSupportsXmlHttp(Boolean value)
        {
            supportsXmlHttp = value;
        }
        #endregion

        #region Tables
        private Boolean tables;
        public override Boolean Tables
        {
            get
            {
                return tables;
            }
        }
        public void SetTables(Boolean value)
        {
            tables = value;
        }
        #endregion

        #region TagWriter
        private Type tagWriter;
        public override Type TagWriter
        {
            get
            {
                return tagWriter;
            }
        }
        public void SetTagWriter(Type value)
        {
            tagWriter = value;
        }
        #endregion

        #region Type
        private String type;
        public override String Type
        {
            get
            {
                return type;
            }
        }
        public void SetType(String value)
        {
            type = value;
        }
        #endregion

        #region UseOptimizedCacheKey
        private Boolean useOptimizedCacheKey;
        public override Boolean UseOptimizedCacheKey
        {
            get
            {
                return useOptimizedCacheKey;
            }
        }
        public void SetUseOptimizedCacheKey(Boolean value)
        {
            useOptimizedCacheKey = value;
        }
        #endregion

        #region VBScript
        private Boolean vBScript;
        public override Boolean VBScript
        {
            get
            {
                return vBScript;
            }
        }
        public void SetVBScript(Boolean value)
        {
            vBScript = value;
        }
        #endregion

        #region Version
        private String version;
        public override String Version
        {
            get
            {
                return version;
            }
        }
        public void SetVersion(String value)
        {
            version = value;
        }
        #endregion

        #region W3CDomVersion
        private Version w3CDomVersion;
        public override Version W3CDomVersion
        {
            get
            {
                return w3CDomVersion;
            }
        }
        public void SetW3CDomVersion(Version value)
        {
            w3CDomVersion = value;
        }
        #endregion

        #region Win16
        private Boolean win16;
        public override Boolean Win16
        {
            get
            {
                return win16;
            }
        }
        public void SetWin16(Boolean value)
        {
            win16 = value;
        }
        #endregion

        #region Win32
        private Boolean win32;
        public override Boolean Win32
        {
            get
            {
                return win32;
            }
        }
        public void SetWin32(Boolean value)
        {
            win32 = value;
        }
        #endregion
        public FakeHttpBrowserCapabilities()
        {
            SetAdapters(new Hashtable());
            SetBrowsers(new ArrayList());
            SetCapabilities(new Hashtable());
            SetClrVersion(new System.Version(0, 0));
            SetDefaultSubmitButtonLimit(1);
            SetEcmaScriptVersion(new System.Version(3, 0));
            SetHtmlTextWriter(typeof(System.Web.UI.HtmlTextWriter).FullName);
            SetJScriptVersion(new System.Version(0, 0));
            SetMSDomVersion(new System.Version(0, 0));
            SetTagWriter(typeof(System.Web.UI.HtmlTextWriter));
            SetW3CDomVersion(new System.Version(1, 0));
            SetMobileDeviceManufacturer("Unknown");
            SetMobileDeviceModel("Unknown");
            SetNumberOfSoftkeys(0);
            SetPlatform("WinNT");
            SetPreferredImageMime("image/gif");
            SetPreferredRenderingMime("text/html");
            SetPreferredRenderingType("html32");
        }
    }
}
