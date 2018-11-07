using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Mime
{
    public static class MimeHelper
    {
        private static Lazy<Mime[]> __mimes;
        private static Lazy<MimeType[]> __mimeTypes;
        private static int[] __mimeType_lookup;
        static MimeHelper()
        {
            __mimes = new Lazy<Mime[]>(_initMimes);
            __mimeTypes = new Lazy<MimeType[]>(_initMimeTypes);
            
            // this is an index of the first letter of extensions in __mimeTypes array
            //                                 0  1   2  3   4   5   6  7   8   9, a  b   c   d    e    f    g    h    i    j    k    l    m    n    o    p    q    r    s    t    u    v    w    x    y     z
            __mimeType_lookup = new int[36] { -1, 0, -1, 1, -1, -1, -1, 7, -1, -1, 8, 51, 73, 151, 205, 238, 275, 312, 334, 367, 391, 409, 432, 543, 562, 604, 682, 693, 731, 842, 881, 923, 943, 988, 1050, 1055 };
        }
        private static Mime[] _initMimes()
        {
            return new Mime[]{
                  new Mime { Id = 1, Source = "iana", Value = "application/1d-interleaved-parityfec" , Compressible = false, CharSet = "UTF-8", Extensions = "" }
                , new Mime { Id = 2, Source = "iana", Value = "application/3gpdash-qoe-report+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 3, Source = "iana", Value = "application/3gpp-ims+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 4, Source = "iana", Value = "application/a2l" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 5, Source = "iana", Value = "application/activemessage" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 6, Source = "iana", Value = "application/alto-costmap+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 7, Source = "iana", Value = "application/alto-costmapfilter+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 8, Source = "iana", Value = "application/alto-directory+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 9, Source = "iana", Value = "application/alto-endpointcost+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 10, Source = "iana", Value = "application/alto-endpointcostparams+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 11, Source = "iana", Value = "application/alto-endpointprop+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 12, Source = "iana", Value = "application/alto-endpointpropparams+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 13, Source = "iana", Value = "application/alto-error+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 14, Source = "iana", Value = "application/alto-networkmap+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 15, Source = "iana", Value = "application/alto-networkmapfilter+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 16, Source = "iana", Value = "application/aml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 17, Source = "iana", Value = "application/andrew-inset" , Compressible = false, CharSet = "", Extensions = "ez" }
                , new Mime { Id = 18, Source = "iana", Value = "application/applefile" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 19, Source = "apache", Value = "application/applixware" , Compressible = false, CharSet = "", Extensions = "aw" }
                , new Mime { Id = 20, Source = "iana", Value = "application/atf" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 21, Source = "iana", Value = "application/atfx" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 22, Source = "iana", Value = "application/atom+xml" , Compressible = true, CharSet = "", Extensions = "atom" }
                , new Mime { Id = 23, Source = "iana", Value = "application/atomcat+xml" , Compressible = false, CharSet = "", Extensions = "atomcat" }
                , new Mime { Id = 24, Source = "iana", Value = "application/atomdeleted+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 25, Source = "iana", Value = "application/atomicmail" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 26, Source = "iana", Value = "application/atomsvc+xml" , Compressible = false, CharSet = "", Extensions = "atomsvc" }
                , new Mime { Id = 27, Source = "iana", Value = "application/atxml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 28, Source = "iana", Value = "application/auth-policy+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 29, Source = "iana", Value = "application/bacnet-xdd+zip" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 30, Source = "iana", Value = "application/batch-smtp" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 31, Source = "", Value = "application/bdoc" , Compressible = false, CharSet = "", Extensions = "bdoc" }
                , new Mime { Id = 32, Source = "iana", Value = "application/beep+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 33, Source = "iana", Value = "application/calendar+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 34, Source = "iana", Value = "application/calendar+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 35, Source = "iana", Value = "application/call-completion" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 36, Source = "iana", Value = "application/cals-1840" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 37, Source = "iana", Value = "application/cbor" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 38, Source = "iana", Value = "application/ccmp+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 39, Source = "iana", Value = "application/ccxml+xml" , Compressible = false, CharSet = "", Extensions = "ccxml" }
                , new Mime { Id = 40, Source = "iana", Value = "application/cdfx+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 41, Source = "iana", Value = "application/cdmi-capability" , Compressible = false, CharSet = "", Extensions = "cdmia" }
                , new Mime { Id = 42, Source = "iana", Value = "application/cdmi-container" , Compressible = false, CharSet = "", Extensions = "cdmic" }
                , new Mime { Id = 43, Source = "iana", Value = "application/cdmi-domain" , Compressible = false, CharSet = "", Extensions = "cdmid" }
                , new Mime { Id = 44, Source = "iana", Value = "application/cdmi-object" , Compressible = false, CharSet = "", Extensions = "cdmio" }
                , new Mime { Id = 45, Source = "iana", Value = "application/cdmi-queue" , Compressible = false, CharSet = "", Extensions = "cdmiq" }
                , new Mime { Id = 46, Source = "iana", Value = "application/cdni" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 47, Source = "iana", Value = "application/cea" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 48, Source = "iana", Value = "application/cea-2018+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 49, Source = "iana", Value = "application/cellml+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 50, Source = "iana", Value = "application/cfw" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 51, Source = "iana", Value = "application/cms" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 52, Source = "iana", Value = "application/cnrp+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 53, Source = "iana", Value = "application/coap-group+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 54, Source = "iana", Value = "application/commonground" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 55, Source = "iana", Value = "application/conference-info+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 56, Source = "iana", Value = "application/cpl+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 57, Source = "iana", Value = "application/csrattrs" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 58, Source = "iana", Value = "application/csta+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 59, Source = "iana", Value = "application/cstadata+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 60, Source = "iana", Value = "application/csvm+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 61, Source = "apache", Value = "application/cu-seeme" , Compressible = false, CharSet = "", Extensions = "cu" }
                , new Mime { Id = 62, Source = "iana", Value = "application/cybercash" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 63, Source = "", Value = "application/dart" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 64, Source = "iana", Value = "application/dash+xml" , Compressible = false, CharSet = "", Extensions = "mpd" }
                , new Mime { Id = 65, Source = "iana", Value = "application/dashdelta" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 66, Source = "iana", Value = "application/davmount+xml" , Compressible = false, CharSet = "", Extensions = "davmount" }
                , new Mime { Id = 67, Source = "iana", Value = "application/dca-rft" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 68, Source = "iana", Value = "application/dcd" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 69, Source = "iana", Value = "application/dec-dx" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 70, Source = "iana", Value = "application/dialog-info+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 71, Source = "iana", Value = "application/dicom" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 72, Source = "iana", Value = "application/dii" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 73, Source = "iana", Value = "application/dit" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 74, Source = "iana", Value = "application/dns" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 75, Source = "apache", Value = "application/docbook+xml" , Compressible = false, CharSet = "", Extensions = "dbk" }
                , new Mime { Id = 76, Source = "iana", Value = "application/dskpp+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 77, Source = "iana", Value = "application/dssc+der" , Compressible = false, CharSet = "", Extensions = "dssc" }
                , new Mime { Id = 78, Source = "iana", Value = "application/dssc+xml" , Compressible = false, CharSet = "", Extensions = "xdssc" }
                , new Mime { Id = 79, Source = "iana", Value = "application/dvcs" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 80, Source = "iana", Value = "application/ecmascript" , Compressible = true, CharSet = "", Extensions = "ecma" }
                , new Mime { Id = 81, Source = "iana", Value = "application/edi-consent" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 82, Source = "iana", Value = "application/edi-x12" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 83, Source = "iana", Value = "application/edifact" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 84, Source = "iana", Value = "application/efi" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 85, Source = "iana", Value = "application/emergencycalldata.comment+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 86, Source = "iana", Value = "application/emergencycalldata.deviceinfo+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 87, Source = "iana", Value = "application/emergencycalldata.providerinfo+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 88, Source = "iana", Value = "application/emergencycalldata.serviceinfo+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 89, Source = "iana", Value = "application/emergencycalldata.subscriberinfo+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 90, Source = "iana", Value = "application/emma+xml" , Compressible = false, CharSet = "", Extensions = "emma" }
                , new Mime { Id = 91, Source = "iana", Value = "application/emotionml+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 92, Source = "iana", Value = "application/encaprtp" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 93, Source = "iana", Value = "application/epp+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 94, Source = "iana", Value = "application/epub+zip" , Compressible = false, CharSet = "", Extensions = "epub" }
                , new Mime { Id = 95, Source = "iana", Value = "application/eshop" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 96, Source = "iana", Value = "application/exi" , Compressible = false, CharSet = "", Extensions = "exi" }
                , new Mime { Id = 97, Source = "iana", Value = "application/fastinfoset" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 98, Source = "iana", Value = "application/fastsoap" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 99, Source = "iana", Value = "application/fdt+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 100, Source = "iana", Value = "application/fits" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 101, Source = "iana", Value = "application/font-sfnt" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 102, Source = "iana", Value = "application/font-tdpfr" , Compressible = false, CharSet = "", Extensions = "pfr" }
                , new Mime { Id = 103, Source = "iana", Value = "application/font-woff" , Compressible = false, CharSet = "", Extensions = "woff" }
                , new Mime { Id = 104, Source = "", Value = "application/font-woff2" , Compressible = false, CharSet = "", Extensions = "woff2" }
                , new Mime { Id = 105, Source = "iana", Value = "application/framework-attributes+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 106, Source = "apache", Value = "application/gml+xml" , Compressible = false, CharSet = "", Extensions = "gml" }
                , new Mime { Id = 107, Source = "apache", Value = "application/gpx+xml" , Compressible = false, CharSet = "", Extensions = "gpx" }
                , new Mime { Id = 108, Source = "apache", Value = "application/gxf" , Compressible = false, CharSet = "", Extensions = "gxf" }
                , new Mime { Id = 109, Source = "iana", Value = "application/gzip" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 110, Source = "iana", Value = "application/h224" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 111, Source = "iana", Value = "application/held+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 112, Source = "iana", Value = "application/http" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 113, Source = "iana", Value = "application/hyperstudio" , Compressible = false, CharSet = "", Extensions = "stk" }
                , new Mime { Id = 114, Source = "iana", Value = "application/ibe-key-request+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 115, Source = "iana", Value = "application/ibe-pkg-reply+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 116, Source = "iana", Value = "application/ibe-pp-data" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 117, Source = "iana", Value = "application/iges" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 118, Source = "iana", Value = "application/im-iscomposing+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 119, Source = "iana", Value = "application/index" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 120, Source = "iana", Value = "application/index.cmd" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 121, Source = "iana", Value = "application/index.obj" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 122, Source = "iana", Value = "application/index.response" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 123, Source = "iana", Value = "application/index.vnd" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 124, Source = "iana", Value = "application/inkml+xml" , Compressible = false, CharSet = "", Extensions = "ink, inkml" }
                , new Mime { Id = 125, Source = "iana", Value = "application/iotp" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 126, Source = "iana", Value = "application/ipfix" , Compressible = false, CharSet = "", Extensions = "ipfix" }
                , new Mime { Id = 127, Source = "iana", Value = "application/ipp" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 128, Source = "iana", Value = "application/isup" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 129, Source = "iana", Value = "application/its+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 130, Source = "apache", Value = "application/java-archive" , Compressible = false, CharSet = "", Extensions = "jar, war, ear" }
                , new Mime { Id = 131, Source = "apache", Value = "application/java-serialized-object" , Compressible = false, CharSet = "", Extensions = "ser" }
                , new Mime { Id = 132, Source = "apache", Value = "application/java-vm" , Compressible = false, CharSet = "", Extensions = "class" }
                , new Mime { Id = 133, Source = "iana", Value = "application/javascript" , Compressible = true, CharSet = "UTF-8", Extensions = "js" }
                , new Mime { Id = 134, Source = "iana", Value = "application/jose" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 135, Source = "iana", Value = "application/jose+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 136, Source = "iana", Value = "application/jrd+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 137, Source = "iana", Value = "application/json" , Compressible = true, CharSet = "UTF-8", Extensions = "json, map" }
                , new Mime { Id = 138, Source = "iana", Value = "application/json-patch+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 139, Source = "iana", Value = "application/json-seq" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 140, Source = "", Value = "application/json5" , Compressible = false, CharSet = "", Extensions = "json5" }
                , new Mime { Id = 141, Source = "apache", Value = "application/jsonml+json" , Compressible = true, CharSet = "", Extensions = "jsonml" }
                , new Mime { Id = 142, Source = "iana", Value = "application/jwk+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 143, Source = "iana", Value = "application/jwk-set+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 144, Source = "iana", Value = "application/jwt" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 145, Source = "iana", Value = "application/kpml-request+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 146, Source = "iana", Value = "application/kpml-response+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 147, Source = "iana", Value = "application/ld+json" , Compressible = true, CharSet = "", Extensions = "jsonld" }
                , new Mime { Id = 148, Source = "iana", Value = "application/link-format" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 149, Source = "iana", Value = "application/load-control+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 150, Source = "iana", Value = "application/lost+xml" , Compressible = false, CharSet = "", Extensions = "lostxml" }
                , new Mime { Id = 151, Source = "iana", Value = "application/lostsync+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 152, Source = "iana", Value = "application/lxf" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 153, Source = "iana", Value = "application/mac-binhex40" , Compressible = false, CharSet = "", Extensions = "hqx" }
                , new Mime { Id = 154, Source = "apache", Value = "application/mac-compactpro" , Compressible = false, CharSet = "", Extensions = "cpt" }
                , new Mime { Id = 155, Source = "iana", Value = "application/macwriteii" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 156, Source = "iana", Value = "application/mads+xml" , Compressible = false, CharSet = "", Extensions = "mads" }
                , new Mime { Id = 157, Source = "", Value = "application/manifest+json" , Compressible = true, CharSet = "UTF-8", Extensions = "webmanifest" }
                , new Mime { Id = 158, Source = "iana", Value = "application/marc" , Compressible = false, CharSet = "", Extensions = "mrc" }
                , new Mime { Id = 159, Source = "iana", Value = "application/marcxml+xml" , Compressible = false, CharSet = "", Extensions = "mrcx" }
                , new Mime { Id = 160, Source = "iana", Value = "application/mathematica" , Compressible = false, CharSet = "", Extensions = "ma, nb, mb" }
                , new Mime { Id = 161, Source = "iana", Value = "application/mathml+xml" , Compressible = false, CharSet = "", Extensions = "mathml" }
                , new Mime { Id = 162, Source = "iana", Value = "application/mathml-content+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 163, Source = "iana", Value = "application/mathml-presentation+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 164, Source = "iana", Value = "application/mbms-associated-procedure-description+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 165, Source = "iana", Value = "application/mbms-deregister+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 166, Source = "iana", Value = "application/mbms-envelope+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 167, Source = "iana", Value = "application/mbms-msk+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 168, Source = "iana", Value = "application/mbms-msk-response+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 169, Source = "iana", Value = "application/mbms-protection-description+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 170, Source = "iana", Value = "application/mbms-reception-report+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 171, Source = "iana", Value = "application/mbms-register+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 172, Source = "iana", Value = "application/mbms-register-response+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 173, Source = "iana", Value = "application/mbms-schedule+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 174, Source = "iana", Value = "application/mbms-user-service-description+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 175, Source = "iana", Value = "application/mbox" , Compressible = false, CharSet = "", Extensions = "mbox" }
                , new Mime { Id = 176, Source = "iana", Value = "application/media-policy-dataset+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 177, Source = "iana", Value = "application/media_control+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 178, Source = "iana", Value = "application/mediaservercontrol+xml" , Compressible = false, CharSet = "", Extensions = "mscml" }
                , new Mime { Id = 179, Source = "iana", Value = "application/merge-patch+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 180, Source = "apache", Value = "application/metalink+xml" , Compressible = false, CharSet = "", Extensions = "metalink" }
                , new Mime { Id = 181, Source = "iana", Value = "application/metalink4+xml" , Compressible = false, CharSet = "", Extensions = "meta4" }
                , new Mime { Id = 182, Source = "iana", Value = "application/mets+xml" , Compressible = false, CharSet = "", Extensions = "mets" }
                , new Mime { Id = 183, Source = "iana", Value = "application/mf4" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 184, Source = "iana", Value = "application/mikey" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 185, Source = "iana", Value = "application/mods+xml" , Compressible = false, CharSet = "", Extensions = "mods" }
                , new Mime { Id = 186, Source = "iana", Value = "application/moss-keys" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 187, Source = "iana", Value = "application/moss-signature" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 188, Source = "iana", Value = "application/mosskey-data" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 189, Source = "iana", Value = "application/mosskey-request" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 190, Source = "iana", Value = "application/mp21" , Compressible = false, CharSet = "", Extensions = "m21, mp21" }
                , new Mime { Id = 191, Source = "iana", Value = "application/mp4" , Compressible = false, CharSet = "", Extensions = "mp4s, m4p" }
                , new Mime { Id = 192, Source = "iana", Value = "application/mpeg4-generic" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 193, Source = "iana", Value = "application/mpeg4-iod" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 194, Source = "iana", Value = "application/mpeg4-iod-xmt" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 195, Source = "iana", Value = "application/mrb-consumer+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 196, Source = "iana", Value = "application/mrb-publish+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 197, Source = "iana", Value = "application/msc-ivr+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 198, Source = "iana", Value = "application/msc-mixer+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 199, Source = "iana", Value = "application/msword" , Compressible = false, CharSet = "", Extensions = "doc, dot" }
                , new Mime { Id = 200, Source = "iana", Value = "application/mxf" , Compressible = false, CharSet = "", Extensions = "mxf" }
                , new Mime { Id = 201, Source = "iana", Value = "application/nasdata" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 202, Source = "iana", Value = "application/news-checkgroups" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 203, Source = "iana", Value = "application/news-groupinfo" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 204, Source = "iana", Value = "application/news-transmission" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 205, Source = "iana", Value = "application/nlsml+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 206, Source = "iana", Value = "application/nss" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 207, Source = "iana", Value = "application/ocsp-request" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 208, Source = "iana", Value = "application/ocsp-response" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 209, Source = "iana", Value = "application/octet-stream" , Compressible = false, CharSet = "", Extensions = "bin, dms, lrf, mar, so, dist, distz, pkg, bpk, dump, elc, deploy, exe, dll, deb, dmg, iso, img, msi, msp, msm, buffer" }
                , new Mime { Id = 210, Source = "iana", Value = "application/oda" , Compressible = false, CharSet = "", Extensions = "oda" }
                , new Mime { Id = 211, Source = "iana", Value = "application/odx" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 212, Source = "iana", Value = "application/oebps-package+xml" , Compressible = false, CharSet = "", Extensions = "opf" }
                , new Mime { Id = 213, Source = "iana", Value = "application/ogg" , Compressible = false, CharSet = "", Extensions = "ogx" }
                , new Mime { Id = 214, Source = "apache", Value = "application/omdoc+xml" , Compressible = false, CharSet = "", Extensions = "omdoc" }
                , new Mime { Id = 215, Source = "apache", Value = "application/onenote" , Compressible = false, CharSet = "", Extensions = "onetoc, onetoc2, onetmp, onepkg" }
                , new Mime { Id = 216, Source = "iana", Value = "application/oxps" , Compressible = false, CharSet = "", Extensions = "oxps" }
                , new Mime { Id = 217, Source = "iana", Value = "application/p2p-overlay+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 218, Source = "iana", Value = "application/parityfec" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 219, Source = "iana", Value = "application/patch-ops-error+xml" , Compressible = false, CharSet = "", Extensions = "xer" }
                , new Mime { Id = 220, Source = "iana", Value = "application/pdf" , Compressible = false, CharSet = "", Extensions = "pdf" }
                , new Mime { Id = 221, Source = "iana", Value = "application/pdx" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 222, Source = "iana", Value = "application/pgp-encrypted" , Compressible = false, CharSet = "", Extensions = "pgp" }
                , new Mime { Id = 223, Source = "iana", Value = "application/pgp-keys" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 224, Source = "iana", Value = "application/pgp-signature" , Compressible = false, CharSet = "", Extensions = "asc, sig" }
                , new Mime { Id = 225, Source = "apache", Value = "application/pics-rules" , Compressible = false, CharSet = "", Extensions = "prf" }
                , new Mime { Id = 226, Source = "iana", Value = "application/pidf+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 227, Source = "iana", Value = "application/pidf-diff+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 228, Source = "iana", Value = "application/pkcs10" , Compressible = false, CharSet = "", Extensions = "p10" }
                , new Mime { Id = 229, Source = "iana", Value = "application/pkcs12" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 230, Source = "iana", Value = "application/pkcs7-mime" , Compressible = false, CharSet = "", Extensions = "p7m, p7c" }
                , new Mime { Id = 231, Source = "iana", Value = "application/pkcs7-signature" , Compressible = false, CharSet = "", Extensions = "p7s" }
                , new Mime { Id = 232, Source = "iana", Value = "application/pkcs8" , Compressible = false, CharSet = "", Extensions = "p8" }
                , new Mime { Id = 233, Source = "iana", Value = "application/pkix-attr-cert" , Compressible = false, CharSet = "", Extensions = "ac" }
                , new Mime { Id = 234, Source = "iana", Value = "application/pkix-cert" , Compressible = false, CharSet = "", Extensions = "cer" }
                , new Mime { Id = 235, Source = "iana", Value = "application/pkix-crl" , Compressible = false, CharSet = "", Extensions = "crl" }
                , new Mime { Id = 236, Source = "iana", Value = "application/pkix-pkipath" , Compressible = false, CharSet = "", Extensions = "pkipath" }
                , new Mime { Id = 237, Source = "iana", Value = "application/pkixcmp" , Compressible = false, CharSet = "", Extensions = "pki" }
                , new Mime { Id = 238, Source = "iana", Value = "application/pls+xml" , Compressible = false, CharSet = "", Extensions = "pls" }
                , new Mime { Id = 239, Source = "iana", Value = "application/poc-settings+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 240, Source = "iana", Value = "application/postscript" , Compressible = true, CharSet = "", Extensions = "ai, eps, ps" }
                , new Mime { Id = 241, Source = "iana", Value = "application/ppsp-tracker+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 242, Source = "iana", Value = "application/problem+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 243, Source = "iana", Value = "application/problem+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 244, Source = "iana", Value = "application/provenance+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 245, Source = "iana", Value = "application/prs.alvestrand.titrax-sheet" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 246, Source = "iana", Value = "application/prs.cww" , Compressible = false, CharSet = "", Extensions = "cww" }
                , new Mime { Id = 247, Source = "iana", Value = "application/prs.hpub+zip" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 248, Source = "iana", Value = "application/prs.nprend" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 249, Source = "iana", Value = "application/prs.plucker" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 250, Source = "iana", Value = "application/prs.rdf-xml-crypt" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 251, Source = "iana", Value = "application/prs.xsf+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 252, Source = "iana", Value = "application/pskc+xml" , Compressible = false, CharSet = "", Extensions = "pskcxml" }
                , new Mime { Id = 253, Source = "iana", Value = "application/qsig" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 254, Source = "iana", Value = "application/raptorfec" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 255, Source = "iana", Value = "application/rdap+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 256, Source = "iana", Value = "application/rdf+xml" , Compressible = true, CharSet = "", Extensions = "rdf" }
                , new Mime { Id = 257, Source = "iana", Value = "application/reginfo+xml" , Compressible = false, CharSet = "", Extensions = "rif" }
                , new Mime { Id = 258, Source = "iana", Value = "application/relax-ng-compact-syntax" , Compressible = false, CharSet = "", Extensions = "rnc" }
                , new Mime { Id = 259, Source = "iana", Value = "application/remote-printing" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 260, Source = "iana", Value = "application/reputon+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 261, Source = "iana", Value = "application/resource-lists+xml" , Compressible = false, CharSet = "", Extensions = "rl" }
                , new Mime { Id = 262, Source = "iana", Value = "application/resource-lists-diff+xml" , Compressible = false, CharSet = "", Extensions = "rld" }
                , new Mime { Id = 263, Source = "iana", Value = "application/rfc+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 264, Source = "iana", Value = "application/riscos" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 265, Source = "iana", Value = "application/rlmi+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 266, Source = "iana", Value = "application/rls-services+xml" , Compressible = false, CharSet = "", Extensions = "rs" }
                , new Mime { Id = 267, Source = "iana", Value = "application/rpki-ghostbusters" , Compressible = false, CharSet = "", Extensions = "gbr" }
                , new Mime { Id = 268, Source = "iana", Value = "application/rpki-manifest" , Compressible = false, CharSet = "", Extensions = "mft" }
                , new Mime { Id = 269, Source = "iana", Value = "application/rpki-roa" , Compressible = false, CharSet = "", Extensions = "roa" }
                , new Mime { Id = 270, Source = "iana", Value = "application/rpki-updown" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 271, Source = "apache", Value = "application/rsd+xml" , Compressible = false, CharSet = "", Extensions = "rsd" }
                , new Mime { Id = 272, Source = "apache", Value = "application/rss+xml" , Compressible = true, CharSet = "", Extensions = "rss" }
                , new Mime { Id = 273, Source = "iana", Value = "application/rtf" , Compressible = true, CharSet = "", Extensions = "rtf" }
                , new Mime { Id = 274, Source = "iana", Value = "application/rtploopback" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 275, Source = "iana", Value = "application/rtx" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 276, Source = "iana", Value = "application/samlassertion+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 277, Source = "iana", Value = "application/samlmetadata+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 278, Source = "iana", Value = "application/sbml+xml" , Compressible = false, CharSet = "", Extensions = "sbml" }
                , new Mime { Id = 279, Source = "iana", Value = "application/scaip+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 280, Source = "iana", Value = "application/scim+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 281, Source = "iana", Value = "application/scvp-cv-request" , Compressible = false, CharSet = "", Extensions = "scq" }
                , new Mime { Id = 282, Source = "iana", Value = "application/scvp-cv-response" , Compressible = false, CharSet = "", Extensions = "scs" }
                , new Mime { Id = 283, Source = "iana", Value = "application/scvp-vp-request" , Compressible = false, CharSet = "", Extensions = "spq" }
                , new Mime { Id = 284, Source = "iana", Value = "application/scvp-vp-response" , Compressible = false, CharSet = "", Extensions = "spp" }
                , new Mime { Id = 285, Source = "iana", Value = "application/sdp" , Compressible = false, CharSet = "", Extensions = "sdp" }
                , new Mime { Id = 286, Source = "iana", Value = "application/sep+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 287, Source = "iana", Value = "application/sep-exi" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 288, Source = "iana", Value = "application/session-info" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 289, Source = "iana", Value = "application/set-payment" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 290, Source = "iana", Value = "application/set-payment-initiation" , Compressible = false, CharSet = "", Extensions = "setpay" }
                , new Mime { Id = 291, Source = "iana", Value = "application/set-registration" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 292, Source = "iana", Value = "application/set-registration-initiation" , Compressible = false, CharSet = "", Extensions = "setreg" }
                , new Mime { Id = 293, Source = "iana", Value = "application/sgml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 294, Source = "iana", Value = "application/sgml-open-catalog" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 295, Source = "iana", Value = "application/shf+xml" , Compressible = false, CharSet = "", Extensions = "shf" }
                , new Mime { Id = 296, Source = "iana", Value = "application/sieve" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 297, Source = "iana", Value = "application/simple-filter+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 298, Source = "iana", Value = "application/simple-message-summary" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 299, Source = "iana", Value = "application/simplesymbolcontainer" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 300, Source = "iana", Value = "application/slate" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 301, Source = "iana", Value = "application/smil" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 302, Source = "iana", Value = "application/smil+xml" , Compressible = false, CharSet = "", Extensions = "smi, smil" }
                , new Mime { Id = 303, Source = "iana", Value = "application/smpte336m" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 304, Source = "iana", Value = "application/soap+fastinfoset" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 305, Source = "iana", Value = "application/soap+xml" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 306, Source = "iana", Value = "application/sparql-query" , Compressible = false, CharSet = "", Extensions = "rq" }
                , new Mime { Id = 307, Source = "iana", Value = "application/sparql-results+xml" , Compressible = false, CharSet = "", Extensions = "srx" }
                , new Mime { Id = 308, Source = "iana", Value = "application/spirits-event+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 309, Source = "iana", Value = "application/sql" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 310, Source = "iana", Value = "application/srgs" , Compressible = false, CharSet = "", Extensions = "gram" }
                , new Mime { Id = 311, Source = "iana", Value = "application/srgs+xml" , Compressible = false, CharSet = "", Extensions = "grxml" }
                , new Mime { Id = 312, Source = "iana", Value = "application/sru+xml" , Compressible = false, CharSet = "", Extensions = "sru" }
                , new Mime { Id = 313, Source = "apache", Value = "application/ssdl+xml" , Compressible = false, CharSet = "", Extensions = "ssdl" }
                , new Mime { Id = 314, Source = "iana", Value = "application/ssml+xml" , Compressible = false, CharSet = "", Extensions = "ssml" }
                , new Mime { Id = 315, Source = "iana", Value = "application/tamp-apex-update" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 316, Source = "iana", Value = "application/tamp-apex-update-confirm" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 317, Source = "iana", Value = "application/tamp-community-update" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 318, Source = "iana", Value = "application/tamp-community-update-confirm" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 319, Source = "iana", Value = "application/tamp-error" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 320, Source = "iana", Value = "application/tamp-sequence-adjust" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 321, Source = "iana", Value = "application/tamp-sequence-adjust-confirm" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 322, Source = "iana", Value = "application/tamp-status-query" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 323, Source = "iana", Value = "application/tamp-status-response" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 324, Source = "iana", Value = "application/tamp-update" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 325, Source = "iana", Value = "application/tamp-update-confirm" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 326, Source = "", Value = "application/tar" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 327, Source = "iana", Value = "application/tei+xml" , Compressible = false, CharSet = "", Extensions = "tei, teicorpus" }
                , new Mime { Id = 328, Source = "iana", Value = "application/thraud+xml" , Compressible = false, CharSet = "", Extensions = "tfi" }
                , new Mime { Id = 329, Source = "iana", Value = "application/timestamp-query" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 330, Source = "iana", Value = "application/timestamp-reply" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 331, Source = "iana", Value = "application/timestamped-data" , Compressible = false, CharSet = "", Extensions = "tsd" }
                , new Mime { Id = 332, Source = "iana", Value = "application/ttml+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 333, Source = "iana", Value = "application/tve-trigger" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 334, Source = "iana", Value = "application/ulpfec" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 335, Source = "iana", Value = "application/urc-grpsheet+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 336, Source = "iana", Value = "application/urc-ressheet+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 337, Source = "iana", Value = "application/urc-targetdesc+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 338, Source = "iana", Value = "application/urc-uisocketdesc+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 339, Source = "iana", Value = "application/vcard+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 340, Source = "iana", Value = "application/vcard+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 341, Source = "iana", Value = "application/vemmi" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 342, Source = "apache", Value = "application/vividence.scriptfile" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 343, Source = "iana", Value = "application/vnd.3gpp-prose+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 344, Source = "iana", Value = "application/vnd.3gpp-prose-pc3ch+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 345, Source = "iana", Value = "application/vnd.3gpp.access-transfer-events+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 346, Source = "iana", Value = "application/vnd.3gpp.bsf+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 347, Source = "iana", Value = "application/vnd.3gpp.mid-call+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 348, Source = "iana", Value = "application/vnd.3gpp.pic-bw-large" , Compressible = false, CharSet = "", Extensions = "plb" }
                , new Mime { Id = 349, Source = "iana", Value = "application/vnd.3gpp.pic-bw-small" , Compressible = false, CharSet = "", Extensions = "psb" }
                , new Mime { Id = 350, Source = "iana", Value = "application/vnd.3gpp.pic-bw-var" , Compressible = false, CharSet = "", Extensions = "pvb" }
                , new Mime { Id = 351, Source = "iana", Value = "application/vnd.3gpp.sms" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 352, Source = "iana", Value = "application/vnd.3gpp.sms+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 353, Source = "iana", Value = "application/vnd.3gpp.srvcc-ext+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 354, Source = "iana", Value = "application/vnd.3gpp.srvcc-info+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 355, Source = "iana", Value = "application/vnd.3gpp.state-and-event-info+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 356, Source = "iana", Value = "application/vnd.3gpp.ussd+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 357, Source = "iana", Value = "application/vnd.3gpp2.bcmcsinfo+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 358, Source = "iana", Value = "application/vnd.3gpp2.sms" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 359, Source = "iana", Value = "application/vnd.3gpp2.tcap" , Compressible = false, CharSet = "", Extensions = "tcap" }
                , new Mime { Id = 360, Source = "iana", Value = "application/vnd.3lightssoftware.imagescal" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 361, Source = "iana", Value = "application/vnd.3m.post-it-notes" , Compressible = false, CharSet = "", Extensions = "pwn" }
                , new Mime { Id = 362, Source = "iana", Value = "application/vnd.accpac.simply.aso" , Compressible = false, CharSet = "", Extensions = "aso" }
                , new Mime { Id = 363, Source = "iana", Value = "application/vnd.accpac.simply.imp" , Compressible = false, CharSet = "", Extensions = "imp" }
                , new Mime { Id = 364, Source = "iana", Value = "application/vnd.acucobol" , Compressible = false, CharSet = "", Extensions = "acu" }
                , new Mime { Id = 365, Source = "iana", Value = "application/vnd.acucorp" , Compressible = false, CharSet = "", Extensions = "atc, acutc" }
                , new Mime { Id = 366, Source = "apache", Value = "application/vnd.adobe.air-application-installer-package+zip" , Compressible = false, CharSet = "", Extensions = "air" }
                , new Mime { Id = 367, Source = "iana", Value = "application/vnd.adobe.flash.movie" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 368, Source = "iana", Value = "application/vnd.adobe.formscentral.fcdt" , Compressible = false, CharSet = "", Extensions = "fcdt" }
                , new Mime { Id = 369, Source = "iana", Value = "application/vnd.adobe.fxp" , Compressible = false, CharSet = "", Extensions = "fxp, fxpl" }
                , new Mime { Id = 370, Source = "iana", Value = "application/vnd.adobe.partial-upload" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 371, Source = "iana", Value = "application/vnd.adobe.xdp+xml" , Compressible = false, CharSet = "", Extensions = "xdp" }
                , new Mime { Id = 372, Source = "iana", Value = "application/vnd.adobe.xfdf" , Compressible = false, CharSet = "", Extensions = "xfdf" }
                , new Mime { Id = 373, Source = "iana", Value = "application/vnd.aether.imp" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 374, Source = "iana", Value = "application/vnd.ah-barcode" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 375, Source = "iana", Value = "application/vnd.ahead.space" , Compressible = false, CharSet = "", Extensions = "ahead" }
                , new Mime { Id = 376, Source = "iana", Value = "application/vnd.airzip.filesecure.azf" , Compressible = false, CharSet = "", Extensions = "azf" }
                , new Mime { Id = 377, Source = "iana", Value = "application/vnd.airzip.filesecure.azs" , Compressible = false, CharSet = "", Extensions = "azs" }
                , new Mime { Id = 378, Source = "apache", Value = "application/vnd.amazon.ebook" , Compressible = false, CharSet = "", Extensions = "azw" }
                , new Mime { Id = 379, Source = "iana", Value = "application/vnd.americandynamics.acc" , Compressible = false, CharSet = "", Extensions = "acc" }
                , new Mime { Id = 380, Source = "iana", Value = "application/vnd.amiga.ami" , Compressible = false, CharSet = "", Extensions = "ami" }
                , new Mime { Id = 381, Source = "iana", Value = "application/vnd.amundsen.maze+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 382, Source = "apache", Value = "application/vnd.android.package-archive" , Compressible = false, CharSet = "", Extensions = "apk" }
                , new Mime { Id = 383, Source = "iana", Value = "application/vnd.anki" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 384, Source = "iana", Value = "application/vnd.anser-web-certificate-issue-initiation" , Compressible = false, CharSet = "", Extensions = "cii" }
                , new Mime { Id = 385, Source = "apache", Value = "application/vnd.anser-web-funds-transfer-initiation" , Compressible = false, CharSet = "", Extensions = "fti" }
                , new Mime { Id = 386, Source = "iana", Value = "application/vnd.antix.game-component" , Compressible = false, CharSet = "", Extensions = "atx" }
                , new Mime { Id = 387, Source = "iana", Value = "application/vnd.apache.thrift.binary" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 388, Source = "iana", Value = "application/vnd.apache.thrift.compact" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 389, Source = "iana", Value = "application/vnd.apache.thrift.json" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 390, Source = "iana", Value = "application/vnd.api+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 391, Source = "iana", Value = "application/vnd.apple.installer+xml" , Compressible = false, CharSet = "", Extensions = "mpkg" }
                , new Mime { Id = 392, Source = "iana", Value = "application/vnd.apple.mpegurl" , Compressible = false, CharSet = "", Extensions = "m3u8" }
                , new Mime { Id = 393, Source = "", Value = "application/vnd.apple.pkpass" , Compressible = false, CharSet = "", Extensions = "pkpass" }
                , new Mime { Id = 394, Source = "iana", Value = "application/vnd.arastra.swi" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 395, Source = "iana", Value = "application/vnd.aristanetworks.swi" , Compressible = false, CharSet = "", Extensions = "swi" }
                , new Mime { Id = 396, Source = "iana", Value = "application/vnd.artsquare" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 397, Source = "iana", Value = "application/vnd.astraea-software.iota" , Compressible = false, CharSet = "", Extensions = "iota" }
                , new Mime { Id = 398, Source = "iana", Value = "application/vnd.audiograph" , Compressible = false, CharSet = "", Extensions = "aep" }
                , new Mime { Id = 399, Source = "iana", Value = "application/vnd.autopackage" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 400, Source = "iana", Value = "application/vnd.avistar+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 401, Source = "iana", Value = "application/vnd.balsamiq.bmml+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 402, Source = "iana", Value = "application/vnd.balsamiq.bmpr" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 403, Source = "iana", Value = "application/vnd.bekitzur-stech+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 404, Source = "iana", Value = "application/vnd.biopax.rdf+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 405, Source = "iana", Value = "application/vnd.blueice.multipass" , Compressible = false, CharSet = "", Extensions = "mpm" }
                , new Mime { Id = 406, Source = "iana", Value = "application/vnd.bluetooth.ep.oob" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 407, Source = "iana", Value = "application/vnd.bluetooth.le.oob" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 408, Source = "iana", Value = "application/vnd.bmi" , Compressible = false, CharSet = "", Extensions = "bmi" }
                , new Mime { Id = 409, Source = "iana", Value = "application/vnd.businessobjects" , Compressible = false, CharSet = "", Extensions = "rep" }
                , new Mime { Id = 410, Source = "iana", Value = "application/vnd.cab-jscript" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 411, Source = "iana", Value = "application/vnd.canon-cpdl" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 412, Source = "iana", Value = "application/vnd.canon-lips" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 413, Source = "iana", Value = "application/vnd.cendio.thinlinc.clientconf" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 414, Source = "iana", Value = "application/vnd.century-systems.tcp_stream" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 415, Source = "iana", Value = "application/vnd.chemdraw+xml" , Compressible = false, CharSet = "", Extensions = "cdxml" }
                , new Mime { Id = 416, Source = "iana", Value = "application/vnd.chipnuts.karaoke-mmd" , Compressible = false, CharSet = "", Extensions = "mmd" }
                , new Mime { Id = 417, Source = "iana", Value = "application/vnd.cinderella" , Compressible = false, CharSet = "", Extensions = "cdy" }
                , new Mime { Id = 418, Source = "iana", Value = "application/vnd.cirpack.isdn-ext" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 419, Source = "iana", Value = "application/vnd.citationstyles.style+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 420, Source = "iana", Value = "application/vnd.claymore" , Compressible = false, CharSet = "", Extensions = "cla" }
                , new Mime { Id = 421, Source = "iana", Value = "application/vnd.cloanto.rp9" , Compressible = false, CharSet = "", Extensions = "rp9" }
                , new Mime { Id = 422, Source = "iana", Value = "application/vnd.clonk.c4group" , Compressible = false, CharSet = "", Extensions = "c4g, c4d, c4f, c4p, c4u" }
                , new Mime { Id = 423, Source = "iana", Value = "application/vnd.cluetrust.cartomobile-config" , Compressible = false, CharSet = "", Extensions = "c11amc" }
                , new Mime { Id = 424, Source = "iana", Value = "application/vnd.cluetrust.cartomobile-config-pkg" , Compressible = false, CharSet = "", Extensions = "c11amz" }
                , new Mime { Id = 425, Source = "iana", Value = "application/vnd.coffeescript" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 426, Source = "iana", Value = "application/vnd.collection+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 427, Source = "iana", Value = "application/vnd.collection.doc+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 428, Source = "iana", Value = "application/vnd.collection.next+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 429, Source = "iana", Value = "application/vnd.commerce-battelle" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 430, Source = "iana", Value = "application/vnd.commonspace" , Compressible = false, CharSet = "", Extensions = "csp" }
                , new Mime { Id = 431, Source = "iana", Value = "application/vnd.contact.cmsg" , Compressible = false, CharSet = "", Extensions = "cdbcmsg" }
                , new Mime { Id = 432, Source = "iana", Value = "application/vnd.coreos.ignition+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 433, Source = "iana", Value = "application/vnd.cosmocaller" , Compressible = false, CharSet = "", Extensions = "cmc" }
                , new Mime { Id = 434, Source = "iana", Value = "application/vnd.crick.clicker" , Compressible = false, CharSet = "", Extensions = "clkx" }
                , new Mime { Id = 435, Source = "iana", Value = "application/vnd.crick.clicker.keyboard" , Compressible = false, CharSet = "", Extensions = "clkk" }
                , new Mime { Id = 436, Source = "iana", Value = "application/vnd.crick.clicker.palette" , Compressible = false, CharSet = "", Extensions = "clkp" }
                , new Mime { Id = 437, Source = "iana", Value = "application/vnd.crick.clicker.template" , Compressible = false, CharSet = "", Extensions = "clkt" }
                , new Mime { Id = 438, Source = "iana", Value = "application/vnd.crick.clicker.wordbank" , Compressible = false, CharSet = "", Extensions = "clkw" }
                , new Mime { Id = 439, Source = "iana", Value = "application/vnd.criticaltools.wbs+xml" , Compressible = false, CharSet = "", Extensions = "wbs" }
                , new Mime { Id = 440, Source = "iana", Value = "application/vnd.ctc-posml" , Compressible = false, CharSet = "", Extensions = "pml" }
                , new Mime { Id = 441, Source = "iana", Value = "application/vnd.ctct.ws+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 442, Source = "iana", Value = "application/vnd.cups-pdf" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 443, Source = "iana", Value = "application/vnd.cups-postscript" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 444, Source = "iana", Value = "application/vnd.cups-ppd" , Compressible = false, CharSet = "", Extensions = "ppd" }
                , new Mime { Id = 445, Source = "iana", Value = "application/vnd.cups-raster" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 446, Source = "iana", Value = "application/vnd.cups-raw" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 447, Source = "iana", Value = "application/vnd.curl" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 448, Source = "apache", Value = "application/vnd.curl.car" , Compressible = false, CharSet = "", Extensions = "car" }
                , new Mime { Id = 449, Source = "apache", Value = "application/vnd.curl.pcurl" , Compressible = false, CharSet = "", Extensions = "pcurl" }
                , new Mime { Id = 450, Source = "iana", Value = "application/vnd.cyan.dean.root+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 451, Source = "iana", Value = "application/vnd.cybank" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 452, Source = "iana", Value = "application/vnd.dart" , Compressible = true, CharSet = "", Extensions = "dart" }
                , new Mime { Id = 453, Source = "iana", Value = "application/vnd.data-vision.rdz" , Compressible = false, CharSet = "", Extensions = "rdz" }
                , new Mime { Id = 454, Source = "iana", Value = "application/vnd.debian.binary-package" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 455, Source = "iana", Value = "application/vnd.dece.data" , Compressible = false, CharSet = "", Extensions = "uvf, uvvf, uvd, uvvd" }
                , new Mime { Id = 456, Source = "iana", Value = "application/vnd.dece.ttml+xml" , Compressible = false, CharSet = "", Extensions = "uvt, uvvt" }
                , new Mime { Id = 457, Source = "iana", Value = "application/vnd.dece.unspecified" , Compressible = false, CharSet = "", Extensions = "uvx, uvvx" }
                , new Mime { Id = 458, Source = "iana", Value = "application/vnd.dece.zip" , Compressible = false, CharSet = "", Extensions = "uvz, uvvz" }
                , new Mime { Id = 459, Source = "iana", Value = "application/vnd.denovo.fcselayout-link" , Compressible = false, CharSet = "", Extensions = "fe_launch" }
                , new Mime { Id = 460, Source = "iana", Value = "application/vnd.desmume-movie" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 461, Source = "apache", Value = "application/vnd.desmume.movie" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 462, Source = "iana", Value = "application/vnd.dir-bi.plate-dl-nosuffix" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 463, Source = "iana", Value = "application/vnd.dm.delegation+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 464, Source = "iana", Value = "application/vnd.dna" , Compressible = false, CharSet = "", Extensions = "dna" }
                , new Mime { Id = 465, Source = "iana", Value = "application/vnd.document+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 466, Source = "apache", Value = "application/vnd.dolby.mlp" , Compressible = false, CharSet = "", Extensions = "mlp" }
                , new Mime { Id = 467, Source = "iana", Value = "application/vnd.dolby.mobile.1" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 468, Source = "iana", Value = "application/vnd.dolby.mobile.2" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 469, Source = "iana", Value = "application/vnd.doremir.scorecloud-binary-document" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 470, Source = "iana", Value = "application/vnd.dpgraph" , Compressible = false, CharSet = "", Extensions = "dpg" }
                , new Mime { Id = 471, Source = "iana", Value = "application/vnd.dreamfactory" , Compressible = false, CharSet = "", Extensions = "dfac" }
                , new Mime { Id = 472, Source = "iana", Value = "application/vnd.drive+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 473, Source = "apache", Value = "application/vnd.ds-keypoint" , Compressible = false, CharSet = "", Extensions = "kpxx" }
                , new Mime { Id = 474, Source = "iana", Value = "application/vnd.dtg.local" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 475, Source = "iana", Value = "application/vnd.dtg.local.flash" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 476, Source = "iana", Value = "application/vnd.dtg.local.html" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 477, Source = "iana", Value = "application/vnd.dvb.ait" , Compressible = false, CharSet = "", Extensions = "ait" }
                , new Mime { Id = 478, Source = "iana", Value = "application/vnd.dvb.dvbj" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 479, Source = "iana", Value = "application/vnd.dvb.esgcontainer" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 480, Source = "iana", Value = "application/vnd.dvb.ipdcdftnotifaccess" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 481, Source = "iana", Value = "application/vnd.dvb.ipdcesgaccess" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 482, Source = "iana", Value = "application/vnd.dvb.ipdcesgaccess2" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 483, Source = "iana", Value = "application/vnd.dvb.ipdcesgpdd" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 484, Source = "iana", Value = "application/vnd.dvb.ipdcroaming" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 485, Source = "iana", Value = "application/vnd.dvb.iptv.alfec-base" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 486, Source = "iana", Value = "application/vnd.dvb.iptv.alfec-enhancement" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 487, Source = "iana", Value = "application/vnd.dvb.notif-aggregate-root+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 488, Source = "iana", Value = "application/vnd.dvb.notif-container+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 489, Source = "iana", Value = "application/vnd.dvb.notif-generic+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 490, Source = "iana", Value = "application/vnd.dvb.notif-ia-msglist+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 491, Source = "iana", Value = "application/vnd.dvb.notif-ia-registration-request+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 492, Source = "iana", Value = "application/vnd.dvb.notif-ia-registration-response+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 493, Source = "iana", Value = "application/vnd.dvb.notif-init+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 494, Source = "iana", Value = "application/vnd.dvb.pfr" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 495, Source = "iana", Value = "application/vnd.dvb.service" , Compressible = false, CharSet = "", Extensions = "svc" }
                , new Mime { Id = 496, Source = "iana", Value = "application/vnd.dxr" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 497, Source = "iana", Value = "application/vnd.dynageo" , Compressible = false, CharSet = "", Extensions = "geo" }
                , new Mime { Id = 498, Source = "iana", Value = "application/vnd.dzr" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 499, Source = "iana", Value = "application/vnd.easykaraoke.cdgdownload" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 500, Source = "iana", Value = "application/vnd.ecdis-update" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 501, Source = "iana", Value = "application/vnd.ecowin.chart" , Compressible = false, CharSet = "", Extensions = "mag" }
                , new Mime { Id = 502, Source = "iana", Value = "application/vnd.ecowin.filerequest" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 503, Source = "iana", Value = "application/vnd.ecowin.fileupdate" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 504, Source = "iana", Value = "application/vnd.ecowin.series" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 505, Source = "iana", Value = "application/vnd.ecowin.seriesrequest" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 506, Source = "iana", Value = "application/vnd.ecowin.seriesupdate" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 507, Source = "iana", Value = "application/vnd.emclient.accessrequest+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 508, Source = "iana", Value = "application/vnd.enliven" , Compressible = false, CharSet = "", Extensions = "nml" }
                , new Mime { Id = 509, Source = "iana", Value = "application/vnd.enphase.envoy" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 510, Source = "iana", Value = "application/vnd.eprints.data+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 511, Source = "iana", Value = "application/vnd.epson.esf" , Compressible = false, CharSet = "", Extensions = "esf" }
                , new Mime { Id = 512, Source = "iana", Value = "application/vnd.epson.msf" , Compressible = false, CharSet = "", Extensions = "msf" }
                , new Mime { Id = 513, Source = "iana", Value = "application/vnd.epson.quickanime" , Compressible = false, CharSet = "", Extensions = "qam" }
                , new Mime { Id = 514, Source = "iana", Value = "application/vnd.epson.salt" , Compressible = false, CharSet = "", Extensions = "slt" }
                , new Mime { Id = 515, Source = "iana", Value = "application/vnd.epson.ssf" , Compressible = false, CharSet = "", Extensions = "ssf" }
                , new Mime { Id = 516, Source = "iana", Value = "application/vnd.ericsson.quickcall" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 517, Source = "iana", Value = "application/vnd.eszigno3+xml" , Compressible = false, CharSet = "", Extensions = "es3, et3" }
                , new Mime { Id = 518, Source = "iana", Value = "application/vnd.etsi.aoc+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 519, Source = "iana", Value = "application/vnd.etsi.asic-e+zip" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 520, Source = "iana", Value = "application/vnd.etsi.asic-s+zip" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 521, Source = "iana", Value = "application/vnd.etsi.cug+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 522, Source = "iana", Value = "application/vnd.etsi.iptvcommand+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 523, Source = "iana", Value = "application/vnd.etsi.iptvdiscovery+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 524, Source = "iana", Value = "application/vnd.etsi.iptvprofile+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 525, Source = "iana", Value = "application/vnd.etsi.iptvsad-bc+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 526, Source = "iana", Value = "application/vnd.etsi.iptvsad-cod+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 527, Source = "iana", Value = "application/vnd.etsi.iptvsad-npvr+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 528, Source = "iana", Value = "application/vnd.etsi.iptvservice+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 529, Source = "iana", Value = "application/vnd.etsi.iptvsync+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 530, Source = "iana", Value = "application/vnd.etsi.iptvueprofile+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 531, Source = "iana", Value = "application/vnd.etsi.mcid+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 532, Source = "iana", Value = "application/vnd.etsi.mheg5" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 533, Source = "iana", Value = "application/vnd.etsi.overload-control-policy-dataset+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 534, Source = "iana", Value = "application/vnd.etsi.pstn+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 535, Source = "iana", Value = "application/vnd.etsi.sci+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 536, Source = "iana", Value = "application/vnd.etsi.simservs+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 537, Source = "iana", Value = "application/vnd.etsi.timestamp-token" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 538, Source = "iana", Value = "application/vnd.etsi.tsl+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 539, Source = "iana", Value = "application/vnd.etsi.tsl.der" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 540, Source = "iana", Value = "application/vnd.eudora.data" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 541, Source = "iana", Value = "application/vnd.ezpix-album" , Compressible = false, CharSet = "", Extensions = "ez2" }
                , new Mime { Id = 542, Source = "iana", Value = "application/vnd.ezpix-package" , Compressible = false, CharSet = "", Extensions = "ez3" }
                , new Mime { Id = 543, Source = "iana", Value = "application/vnd.f-secure.mobile" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 544, Source = "iana", Value = "application/vnd.fastcopy-disk-image" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 545, Source = "iana", Value = "application/vnd.fdf" , Compressible = false, CharSet = "", Extensions = "fdf" }
                , new Mime { Id = 546, Source = "iana", Value = "application/vnd.fdsn.mseed" , Compressible = false, CharSet = "", Extensions = "mseed" }
                , new Mime { Id = 547, Source = "iana", Value = "application/vnd.fdsn.seed" , Compressible = false, CharSet = "", Extensions = "seed, dataless" }
                , new Mime { Id = 548, Source = "iana", Value = "application/vnd.ffsns" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 549, Source = "iana", Value = "application/vnd.filmit.zfc" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 550, Source = "iana", Value = "application/vnd.fints" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 551, Source = "iana", Value = "application/vnd.firemonkeys.cloudcell" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 552, Source = "iana", Value = "application/vnd.flographit" , Compressible = false, CharSet = "", Extensions = "gph" }
                , new Mime { Id = 553, Source = "iana", Value = "application/vnd.fluxtime.clip" , Compressible = false, CharSet = "", Extensions = "ftc" }
                , new Mime { Id = 554, Source = "iana", Value = "application/vnd.font-fontforge-sfd" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 555, Source = "iana", Value = "application/vnd.framemaker" , Compressible = false, CharSet = "", Extensions = "fm, frame, maker, book" }
                , new Mime { Id = 556, Source = "iana", Value = "application/vnd.frogans.fnc" , Compressible = false, CharSet = "", Extensions = "fnc" }
                , new Mime { Id = 557, Source = "iana", Value = "application/vnd.frogans.ltf" , Compressible = false, CharSet = "", Extensions = "ltf" }
                , new Mime { Id = 558, Source = "iana", Value = "application/vnd.fsc.weblaunch" , Compressible = false, CharSet = "", Extensions = "fsc" }
                , new Mime { Id = 559, Source = "iana", Value = "application/vnd.fujitsu.oasys" , Compressible = false, CharSet = "", Extensions = "oas" }
                , new Mime { Id = 560, Source = "iana", Value = "application/vnd.fujitsu.oasys2" , Compressible = false, CharSet = "", Extensions = "oa2" }
                , new Mime { Id = 561, Source = "iana", Value = "application/vnd.fujitsu.oasys3" , Compressible = false, CharSet = "", Extensions = "oa3" }
                , new Mime { Id = 562, Source = "iana", Value = "application/vnd.fujitsu.oasysgp" , Compressible = false, CharSet = "", Extensions = "fg5" }
                , new Mime { Id = 563, Source = "iana", Value = "application/vnd.fujitsu.oasysprs" , Compressible = false, CharSet = "", Extensions = "bh2" }
                , new Mime { Id = 564, Source = "iana", Value = "application/vnd.fujixerox.art-ex" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 565, Source = "iana", Value = "application/vnd.fujixerox.art4" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 566, Source = "iana", Value = "application/vnd.fujixerox.ddd" , Compressible = false, CharSet = "", Extensions = "ddd" }
                , new Mime { Id = 567, Source = "iana", Value = "application/vnd.fujixerox.docuworks" , Compressible = false, CharSet = "", Extensions = "xdw" }
                , new Mime { Id = 568, Source = "iana", Value = "application/vnd.fujixerox.docuworks.binder" , Compressible = false, CharSet = "", Extensions = "xbd" }
                , new Mime { Id = 569, Source = "iana", Value = "application/vnd.fujixerox.docuworks.container" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 570, Source = "iana", Value = "application/vnd.fujixerox.hbpl" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 571, Source = "iana", Value = "application/vnd.fut-misnet" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 572, Source = "iana", Value = "application/vnd.fuzzysheet" , Compressible = false, CharSet = "", Extensions = "fzs" }
                , new Mime { Id = 573, Source = "iana", Value = "application/vnd.genomatix.tuxedo" , Compressible = false, CharSet = "", Extensions = "txd" }
                , new Mime { Id = 574, Source = "iana", Value = "application/vnd.geo+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 575, Source = "iana", Value = "application/vnd.geocube+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 576, Source = "iana", Value = "application/vnd.geogebra.file" , Compressible = false, CharSet = "", Extensions = "ggb" }
                , new Mime { Id = 577, Source = "iana", Value = "application/vnd.geogebra.tool" , Compressible = false, CharSet = "", Extensions = "ggt" }
                , new Mime { Id = 578, Source = "iana", Value = "application/vnd.geometry-explorer" , Compressible = false, CharSet = "", Extensions = "gex, gre" }
                , new Mime { Id = 579, Source = "iana", Value = "application/vnd.geonext" , Compressible = false, CharSet = "", Extensions = "gxt" }
                , new Mime { Id = 580, Source = "iana", Value = "application/vnd.geoplan" , Compressible = false, CharSet = "", Extensions = "g2w" }
                , new Mime { Id = 581, Source = "iana", Value = "application/vnd.geospace" , Compressible = false, CharSet = "", Extensions = "g3w" }
                , new Mime { Id = 582, Source = "iana", Value = "application/vnd.gerber" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 583, Source = "iana", Value = "application/vnd.globalplatform.card-content-mgt" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 584, Source = "iana", Value = "application/vnd.globalplatform.card-content-mgt-response" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 585, Source = "iana", Value = "application/vnd.gmx" , Compressible = false, CharSet = "", Extensions = "gmx" }
                , new Mime { Id = 586, Source = "", Value = "application/vnd.google-apps.document" , Compressible = false, CharSet = "", Extensions = "gdoc" }
                , new Mime { Id = 587, Source = "", Value = "application/vnd.google-apps.presentation" , Compressible = false, CharSet = "", Extensions = "gslides" }
                , new Mime { Id = 588, Source = "", Value = "application/vnd.google-apps.spreadsheet" , Compressible = false, CharSet = "", Extensions = "gsheet" }
                , new Mime { Id = 589, Source = "iana", Value = "application/vnd.google-earth.kml+xml" , Compressible = true, CharSet = "", Extensions = "kml" }
                , new Mime { Id = 590, Source = "iana", Value = "application/vnd.google-earth.kmz" , Compressible = false, CharSet = "", Extensions = "kmz" }
                , new Mime { Id = 591, Source = "iana", Value = "application/vnd.gov.sk.e-form+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 592, Source = "iana", Value = "application/vnd.gov.sk.e-form+zip" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 593, Source = "iana", Value = "application/vnd.gov.sk.xmldatacontainer+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 594, Source = "iana", Value = "application/vnd.grafeq" , Compressible = false, CharSet = "", Extensions = "gqf, gqs" }
                , new Mime { Id = 595, Source = "iana", Value = "application/vnd.gridmp" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 596, Source = "iana", Value = "application/vnd.groove-account" , Compressible = false, CharSet = "", Extensions = "gac" }
                , new Mime { Id = 597, Source = "iana", Value = "application/vnd.groove-help" , Compressible = false, CharSet = "", Extensions = "ghf" }
                , new Mime { Id = 598, Source = "iana", Value = "application/vnd.groove-identity-message" , Compressible = false, CharSet = "", Extensions = "gim" }
                , new Mime { Id = 599, Source = "iana", Value = "application/vnd.groove-injector" , Compressible = false, CharSet = "", Extensions = "grv" }
                , new Mime { Id = 600, Source = "iana", Value = "application/vnd.groove-tool-message" , Compressible = false, CharSet = "", Extensions = "gtm" }
                , new Mime { Id = 601, Source = "iana", Value = "application/vnd.groove-tool-template" , Compressible = false, CharSet = "", Extensions = "tpl" }
                , new Mime { Id = 602, Source = "iana", Value = "application/vnd.groove-vcard" , Compressible = false, CharSet = "", Extensions = "vcg" }
                , new Mime { Id = 603, Source = "iana", Value = "application/vnd.hal+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 604, Source = "iana", Value = "application/vnd.hal+xml" , Compressible = false, CharSet = "", Extensions = "hal" }
                , new Mime { Id = 605, Source = "iana", Value = "application/vnd.handheld-entertainment+xml" , Compressible = false, CharSet = "", Extensions = "zmm" }
                , new Mime { Id = 606, Source = "iana", Value = "application/vnd.hbci" , Compressible = false, CharSet = "", Extensions = "hbci" }
                , new Mime { Id = 607, Source = "iana", Value = "application/vnd.hcl-bireports" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 608, Source = "iana", Value = "application/vnd.hdt" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 609, Source = "iana", Value = "application/vnd.heroku+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 610, Source = "iana", Value = "application/vnd.hhe.lesson-player" , Compressible = false, CharSet = "", Extensions = "les" }
                , new Mime { Id = 611, Source = "iana", Value = "application/vnd.hp-hpgl" , Compressible = false, CharSet = "", Extensions = "hpgl" }
                , new Mime { Id = 612, Source = "iana", Value = "application/vnd.hp-hpid" , Compressible = false, CharSet = "", Extensions = "hpid" }
                , new Mime { Id = 613, Source = "iana", Value = "application/vnd.hp-hps" , Compressible = false, CharSet = "", Extensions = "hps" }
                , new Mime { Id = 614, Source = "iana", Value = "application/vnd.hp-jlyt" , Compressible = false, CharSet = "", Extensions = "jlt" }
                , new Mime { Id = 615, Source = "iana", Value = "application/vnd.hp-pcl" , Compressible = false, CharSet = "", Extensions = "pcl" }
                , new Mime { Id = 616, Source = "iana", Value = "application/vnd.hp-pclxl" , Compressible = false, CharSet = "", Extensions = "pclxl" }
                , new Mime { Id = 617, Source = "iana", Value = "application/vnd.httphone" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 618, Source = "iana", Value = "application/vnd.hydrostatix.sof-data" , Compressible = false, CharSet = "", Extensions = "sfd-hdstx" }
                , new Mime { Id = 619, Source = "iana", Value = "application/vnd.hyperdrive+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 620, Source = "iana", Value = "application/vnd.hzn-3d-crossword" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 621, Source = "iana", Value = "application/vnd.ibm.afplinedata" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 622, Source = "iana", Value = "application/vnd.ibm.electronic-media" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 623, Source = "iana", Value = "application/vnd.ibm.minipay" , Compressible = false, CharSet = "", Extensions = "mpy" }
                , new Mime { Id = 624, Source = "iana", Value = "application/vnd.ibm.modcap" , Compressible = false, CharSet = "", Extensions = "afp, listafp, list3820" }
                , new Mime { Id = 625, Source = "iana", Value = "application/vnd.ibm.rights-management" , Compressible = false, CharSet = "", Extensions = "irm" }
                , new Mime { Id = 626, Source = "iana", Value = "application/vnd.ibm.secure-container" , Compressible = false, CharSet = "", Extensions = "sc" }
                , new Mime { Id = 627, Source = "iana", Value = "application/vnd.iccprofile" , Compressible = false, CharSet = "", Extensions = "icc, icm" }
                , new Mime { Id = 628, Source = "iana", Value = "application/vnd.ieee.1905" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 629, Source = "iana", Value = "application/vnd.igloader" , Compressible = false, CharSet = "", Extensions = "igl" }
                , new Mime { Id = 630, Source = "iana", Value = "application/vnd.immervision-ivp" , Compressible = false, CharSet = "", Extensions = "ivp" }
                , new Mime { Id = 631, Source = "iana", Value = "application/vnd.immervision-ivu" , Compressible = false, CharSet = "", Extensions = "ivu" }
                , new Mime { Id = 632, Source = "iana", Value = "application/vnd.ims.imsccv1p1" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 633, Source = "iana", Value = "application/vnd.ims.imsccv1p2" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 634, Source = "iana", Value = "application/vnd.ims.imsccv1p3" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 635, Source = "iana", Value = "application/vnd.ims.lis.v2.result+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 636, Source = "iana", Value = "application/vnd.ims.lti.v2.toolconsumerprofile+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 637, Source = "iana", Value = "application/vnd.ims.lti.v2.toolproxy+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 638, Source = "iana", Value = "application/vnd.ims.lti.v2.toolproxy.id+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 639, Source = "iana", Value = "application/vnd.ims.lti.v2.toolsettings+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 640, Source = "iana", Value = "application/vnd.ims.lti.v2.toolsettings.simple+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 641, Source = "iana", Value = "application/vnd.informedcontrol.rms+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 642, Source = "iana", Value = "application/vnd.informix-visionary" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 643, Source = "iana", Value = "application/vnd.infotech.project" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 644, Source = "iana", Value = "application/vnd.infotech.project+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 645, Source = "iana", Value = "application/vnd.innopath.wamp.notification" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 646, Source = "iana", Value = "application/vnd.insors.igm" , Compressible = false, CharSet = "", Extensions = "igm" }
                , new Mime { Id = 647, Source = "iana", Value = "application/vnd.intercon.formnet" , Compressible = false, CharSet = "", Extensions = "xpw, xpx" }
                , new Mime { Id = 648, Source = "iana", Value = "application/vnd.intergeo" , Compressible = false, CharSet = "", Extensions = "i2g" }
                , new Mime { Id = 649, Source = "iana", Value = "application/vnd.intertrust.digibox" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 650, Source = "iana", Value = "application/vnd.intertrust.nncp" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 651, Source = "iana", Value = "application/vnd.intu.qbo" , Compressible = false, CharSet = "", Extensions = "qbo" }
                , new Mime { Id = 652, Source = "iana", Value = "application/vnd.intu.qfx" , Compressible = false, CharSet = "", Extensions = "qfx" }
                , new Mime { Id = 653, Source = "iana", Value = "application/vnd.iptc.g2.catalogitem+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 654, Source = "iana", Value = "application/vnd.iptc.g2.conceptitem+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 655, Source = "iana", Value = "application/vnd.iptc.g2.knowledgeitem+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 656, Source = "iana", Value = "application/vnd.iptc.g2.newsitem+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 657, Source = "iana", Value = "application/vnd.iptc.g2.newsmessage+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 658, Source = "iana", Value = "application/vnd.iptc.g2.packageitem+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 659, Source = "iana", Value = "application/vnd.iptc.g2.planningitem+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 660, Source = "iana", Value = "application/vnd.ipunplugged.rcprofile" , Compressible = false, CharSet = "", Extensions = "rcprofile" }
                , new Mime { Id = 661, Source = "iana", Value = "application/vnd.irepository.package+xml" , Compressible = false, CharSet = "", Extensions = "irp" }
                , new Mime { Id = 662, Source = "iana", Value = "application/vnd.is-xpr" , Compressible = false, CharSet = "", Extensions = "xpr" }
                , new Mime { Id = 663, Source = "iana", Value = "application/vnd.isac.fcs" , Compressible = false, CharSet = "", Extensions = "fcs" }
                , new Mime { Id = 664, Source = "iana", Value = "application/vnd.jam" , Compressible = false, CharSet = "", Extensions = "jam" }
                , new Mime { Id = 665, Source = "iana", Value = "application/vnd.japannet-directory-service" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 666, Source = "iana", Value = "application/vnd.japannet-jpnstore-wakeup" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 667, Source = "iana", Value = "application/vnd.japannet-payment-wakeup" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 668, Source = "iana", Value = "application/vnd.japannet-registration" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 669, Source = "iana", Value = "application/vnd.japannet-registration-wakeup" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 670, Source = "iana", Value = "application/vnd.japannet-setstore-wakeup" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 671, Source = "iana", Value = "application/vnd.japannet-verification" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 672, Source = "iana", Value = "application/vnd.japannet-verification-wakeup" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 673, Source = "iana", Value = "application/vnd.jcp.javame.midlet-rms" , Compressible = false, CharSet = "", Extensions = "rms" }
                , new Mime { Id = 674, Source = "iana", Value = "application/vnd.jisp" , Compressible = false, CharSet = "", Extensions = "jisp" }
                , new Mime { Id = 675, Source = "iana", Value = "application/vnd.joost.joda-archive" , Compressible = false, CharSet = "", Extensions = "joda" }
                , new Mime { Id = 676, Source = "iana", Value = "application/vnd.jsk.isdn-ngn" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 677, Source = "iana", Value = "application/vnd.kahootz" , Compressible = false, CharSet = "", Extensions = "ktz, ktr" }
                , new Mime { Id = 678, Source = "iana", Value = "application/vnd.kde.karbon" , Compressible = false, CharSet = "", Extensions = "karbon" }
                , new Mime { Id = 679, Source = "iana", Value = "application/vnd.kde.kchart" , Compressible = false, CharSet = "", Extensions = "chrt" }
                , new Mime { Id = 680, Source = "iana", Value = "application/vnd.kde.kformula" , Compressible = false, CharSet = "", Extensions = "kfo" }
                , new Mime { Id = 681, Source = "iana", Value = "application/vnd.kde.kivio" , Compressible = false, CharSet = "", Extensions = "flw" }
                , new Mime { Id = 682, Source = "iana", Value = "application/vnd.kde.kontour" , Compressible = false, CharSet = "", Extensions = "kon" }
                , new Mime { Id = 683, Source = "iana", Value = "application/vnd.kde.kpresenter" , Compressible = false, CharSet = "", Extensions = "kpr, kpt" }
                , new Mime { Id = 684, Source = "iana", Value = "application/vnd.kde.kspread" , Compressible = false, CharSet = "", Extensions = "ksp" }
                , new Mime { Id = 685, Source = "iana", Value = "application/vnd.kde.kword" , Compressible = false, CharSet = "", Extensions = "kwd, kwt" }
                , new Mime { Id = 686, Source = "iana", Value = "application/vnd.kenameaapp" , Compressible = false, CharSet = "", Extensions = "htke" }
                , new Mime { Id = 687, Source = "iana", Value = "application/vnd.kidspiration" , Compressible = false, CharSet = "", Extensions = "kia" }
                , new Mime { Id = 688, Source = "iana", Value = "application/vnd.kinar" , Compressible = false, CharSet = "", Extensions = "kne, knp" }
                , new Mime { Id = 689, Source = "iana", Value = "application/vnd.koan" , Compressible = false, CharSet = "", Extensions = "skp, skd, skt, skm" }
                , new Mime { Id = 690, Source = "iana", Value = "application/vnd.kodak-descriptor" , Compressible = false, CharSet = "", Extensions = "sse" }
                , new Mime { Id = 691, Source = "iana", Value = "application/vnd.las.las+xml" , Compressible = false, CharSet = "", Extensions = "lasxml" }
                , new Mime { Id = 692, Source = "iana", Value = "application/vnd.liberty-request+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 693, Source = "iana", Value = "application/vnd.llamagraphics.life-balance.desktop" , Compressible = false, CharSet = "", Extensions = "lbd" }
                , new Mime { Id = 694, Source = "iana", Value = "application/vnd.llamagraphics.life-balance.exchange+xml" , Compressible = false, CharSet = "", Extensions = "lbe" }
                , new Mime { Id = 695, Source = "iana", Value = "application/vnd.lotus-1-2-3" , Compressible = false, CharSet = "", Extensions = "123" }
                , new Mime { Id = 696, Source = "iana", Value = "application/vnd.lotus-approach" , Compressible = false, CharSet = "", Extensions = "apr" }
                , new Mime { Id = 697, Source = "iana", Value = "application/vnd.lotus-freelance" , Compressible = false, CharSet = "", Extensions = "pre" }
                , new Mime { Id = 698, Source = "iana", Value = "application/vnd.lotus-notes" , Compressible = false, CharSet = "", Extensions = "nsf" }
                , new Mime { Id = 699, Source = "iana", Value = "application/vnd.lotus-organizer" , Compressible = false, CharSet = "", Extensions = "org" }
                , new Mime { Id = 700, Source = "iana", Value = "application/vnd.lotus-screencam" , Compressible = false, CharSet = "", Extensions = "scm" }
                , new Mime { Id = 701, Source = "iana", Value = "application/vnd.lotus-wordpro" , Compressible = false, CharSet = "", Extensions = "lwp" }
                , new Mime { Id = 702, Source = "iana", Value = "application/vnd.macports.portpkg" , Compressible = false, CharSet = "", Extensions = "portpkg" }
                , new Mime { Id = 703, Source = "iana", Value = "application/vnd.mapbox-vector-tile" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 704, Source = "iana", Value = "application/vnd.marlin.drm.actiontoken+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 705, Source = "iana", Value = "application/vnd.marlin.drm.conftoken+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 706, Source = "iana", Value = "application/vnd.marlin.drm.license+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 707, Source = "iana", Value = "application/vnd.marlin.drm.mdcf" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 708, Source = "iana", Value = "application/vnd.mason+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 709, Source = "iana", Value = "application/vnd.maxmind.maxmind-db" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 710, Source = "iana", Value = "application/vnd.mcd" , Compressible = false, CharSet = "", Extensions = "mcd" }
                , new Mime { Id = 711, Source = "iana", Value = "application/vnd.medcalcdata" , Compressible = false, CharSet = "", Extensions = "mc1" }
                , new Mime { Id = 712, Source = "iana", Value = "application/vnd.mediastation.cdkey" , Compressible = false, CharSet = "", Extensions = "cdkey" }
                , new Mime { Id = 713, Source = "iana", Value = "application/vnd.meridian-slingshot" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 714, Source = "iana", Value = "application/vnd.mfer" , Compressible = false, CharSet = "", Extensions = "mwf" }
                , new Mime { Id = 715, Source = "iana", Value = "application/vnd.mfmp" , Compressible = false, CharSet = "", Extensions = "mfm" }
                , new Mime { Id = 716, Source = "iana", Value = "application/vnd.micro+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 717, Source = "iana", Value = "application/vnd.micrografx.flo" , Compressible = false, CharSet = "", Extensions = "flo" }
                , new Mime { Id = 718, Source = "iana", Value = "application/vnd.micrografx.igx" , Compressible = false, CharSet = "", Extensions = "igx" }
                , new Mime { Id = 719, Source = "iana", Value = "application/vnd.microsoft.portable-executable" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 720, Source = "iana", Value = "application/vnd.miele+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 721, Source = "iana", Value = "application/vnd.mif" , Compressible = false, CharSet = "", Extensions = "mif" }
                , new Mime { Id = 722, Source = "iana", Value = "application/vnd.minisoft-hp3000-save" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 723, Source = "iana", Value = "application/vnd.mitsubishi.misty-guard.trustweb" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 724, Source = "iana", Value = "application/vnd.mobius.daf" , Compressible = false, CharSet = "", Extensions = "daf" }
                , new Mime { Id = 725, Source = "iana", Value = "application/vnd.mobius.dis" , Compressible = false, CharSet = "", Extensions = "dis" }
                , new Mime { Id = 726, Source = "iana", Value = "application/vnd.mobius.mbk" , Compressible = false, CharSet = "", Extensions = "mbk" }
                , new Mime { Id = 727, Source = "iana", Value = "application/vnd.mobius.mqy" , Compressible = false, CharSet = "", Extensions = "mqy" }
                , new Mime { Id = 728, Source = "iana", Value = "application/vnd.mobius.msl" , Compressible = false, CharSet = "", Extensions = "msl" }
                , new Mime { Id = 729, Source = "iana", Value = "application/vnd.mobius.plc" , Compressible = false, CharSet = "", Extensions = "plc" }
                , new Mime { Id = 730, Source = "iana", Value = "application/vnd.mobius.txf" , Compressible = false, CharSet = "", Extensions = "txf" }
                , new Mime { Id = 731, Source = "iana", Value = "application/vnd.mophun.application" , Compressible = false, CharSet = "", Extensions = "mpn" }
                , new Mime { Id = 732, Source = "iana", Value = "application/vnd.mophun.certificate" , Compressible = false, CharSet = "", Extensions = "mpc" }
                , new Mime { Id = 733, Source = "iana", Value = "application/vnd.motorola.flexsuite" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 734, Source = "iana", Value = "application/vnd.motorola.flexsuite.adsi" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 735, Source = "iana", Value = "application/vnd.motorola.flexsuite.fis" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 736, Source = "iana", Value = "application/vnd.motorola.flexsuite.gotap" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 737, Source = "iana", Value = "application/vnd.motorola.flexsuite.kmr" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 738, Source = "iana", Value = "application/vnd.motorola.flexsuite.ttc" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 739, Source = "iana", Value = "application/vnd.motorola.flexsuite.wem" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 740, Source = "iana", Value = "application/vnd.motorola.iprm" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 741, Source = "iana", Value = "application/vnd.mozilla.xul+xml" , Compressible = true, CharSet = "", Extensions = "xul" }
                , new Mime { Id = 742, Source = "iana", Value = "application/vnd.ms-3mfdocument" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 743, Source = "iana", Value = "application/vnd.ms-artgalry" , Compressible = false, CharSet = "", Extensions = "cil" }
                , new Mime { Id = 744, Source = "iana", Value = "application/vnd.ms-asf" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 745, Source = "iana", Value = "application/vnd.ms-cab-compressed" , Compressible = false, CharSet = "", Extensions = "cab" }
                , new Mime { Id = 746, Source = "apache", Value = "application/vnd.ms-color.iccprofile" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 747, Source = "iana", Value = "application/vnd.ms-excel" , Compressible = false, CharSet = "", Extensions = "xls, xlm, xla, xlc, xlt, xlw" }
                , new Mime { Id = 748, Source = "iana", Value = "application/vnd.ms-excel.addin.macroenabled.12" , Compressible = false, CharSet = "", Extensions = "xlam" }
                , new Mime { Id = 749, Source = "iana", Value = "application/vnd.ms-excel.sheet.binary.macroenabled.12" , Compressible = false, CharSet = "", Extensions = "xlsb" }
                , new Mime { Id = 750, Source = "iana", Value = "application/vnd.ms-excel.sheet.macroenabled.12" , Compressible = false, CharSet = "", Extensions = "xlsm" }
                , new Mime { Id = 751, Source = "iana", Value = "application/vnd.ms-excel.template.macroenabled.12" , Compressible = false, CharSet = "", Extensions = "xltm" }
                , new Mime { Id = 752, Source = "iana", Value = "application/vnd.ms-fontobject" , Compressible = true, CharSet = "", Extensions = "eot" }
                , new Mime { Id = 753, Source = "iana", Value = "application/vnd.ms-htmlhelp" , Compressible = false, CharSet = "", Extensions = "chm" }
                , new Mime { Id = 754, Source = "iana", Value = "application/vnd.ms-ims" , Compressible = false, CharSet = "", Extensions = "ims" }
                , new Mime { Id = 755, Source = "iana", Value = "application/vnd.ms-lrm" , Compressible = false, CharSet = "", Extensions = "lrm" }
                , new Mime { Id = 756, Source = "iana", Value = "application/vnd.ms-office.activex+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 757, Source = "iana", Value = "application/vnd.ms-officetheme" , Compressible = false, CharSet = "", Extensions = "thmx" }
                , new Mime { Id = 758, Source = "apache", Value = "application/vnd.ms-opentype" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 759, Source = "apache", Value = "application/vnd.ms-package.obfuscated-opentype" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 760, Source = "apache", Value = "application/vnd.ms-pki.seccat" , Compressible = false, CharSet = "", Extensions = "cat" }
                , new Mime { Id = 761, Source = "apache", Value = "application/vnd.ms-pki.stl" , Compressible = false, CharSet = "", Extensions = "stl" }
                , new Mime { Id = 762, Source = "iana", Value = "application/vnd.ms-playready.initiator+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 763, Source = "iana", Value = "application/vnd.ms-powerpoint" , Compressible = false, CharSet = "", Extensions = "ppt, pps, pot" }
                , new Mime { Id = 764, Source = "iana", Value = "application/vnd.ms-powerpoint.addin.macroenabled.12" , Compressible = false, CharSet = "", Extensions = "ppam" }
                , new Mime { Id = 765, Source = "iana", Value = "application/vnd.ms-powerpoint.presentation.macroenabled.12" , Compressible = false, CharSet = "", Extensions = "pptm" }
                , new Mime { Id = 766, Source = "iana", Value = "application/vnd.ms-powerpoint.slide.macroenabled.12" , Compressible = false, CharSet = "", Extensions = "sldm" }
                , new Mime { Id = 767, Source = "iana", Value = "application/vnd.ms-powerpoint.slideshow.macroenabled.12" , Compressible = false, CharSet = "", Extensions = "ppsm" }
                , new Mime { Id = 768, Source = "iana", Value = "application/vnd.ms-powerpoint.template.macroenabled.12" , Compressible = false, CharSet = "", Extensions = "potm" }
                , new Mime { Id = 769, Source = "iana", Value = "application/vnd.ms-printdevicecapabilities+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 770, Source = "apache", Value = "application/vnd.ms-printing.printticket+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 771, Source = "iana", Value = "application/vnd.ms-printschematicket+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 772, Source = "iana", Value = "application/vnd.ms-project" , Compressible = false, CharSet = "", Extensions = "mpp, mpt" }
                , new Mime { Id = 773, Source = "iana", Value = "application/vnd.ms-tnef" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 774, Source = "iana", Value = "application/vnd.ms-windows.devicepairing" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 775, Source = "iana", Value = "application/vnd.ms-windows.nwprinting.oob" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 776, Source = "iana", Value = "application/vnd.ms-windows.printerpairing" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 777, Source = "iana", Value = "application/vnd.ms-windows.wsd.oob" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 778, Source = "iana", Value = "application/vnd.ms-wmdrm.lic-chlg-req" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 779, Source = "iana", Value = "application/vnd.ms-wmdrm.lic-resp" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 780, Source = "iana", Value = "application/vnd.ms-wmdrm.meter-chlg-req" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 781, Source = "iana", Value = "application/vnd.ms-wmdrm.meter-resp" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 782, Source = "iana", Value = "application/vnd.ms-word.document.macroenabled.12" , Compressible = false, CharSet = "", Extensions = "docm" }
                , new Mime { Id = 783, Source = "iana", Value = "application/vnd.ms-word.template.macroenabled.12" , Compressible = false, CharSet = "", Extensions = "dotm" }
                , new Mime { Id = 784, Source = "iana", Value = "application/vnd.ms-works" , Compressible = false, CharSet = "", Extensions = "wps, wks, wcm, wdb" }
                , new Mime { Id = 785, Source = "iana", Value = "application/vnd.ms-wpl" , Compressible = false, CharSet = "", Extensions = "wpl" }
                , new Mime { Id = 786, Source = "iana", Value = "application/vnd.ms-xpsdocument" , Compressible = false, CharSet = "", Extensions = "xps" }
                , new Mime { Id = 787, Source = "iana", Value = "application/vnd.msa-disk-image" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 788, Source = "iana", Value = "application/vnd.mseq" , Compressible = false, CharSet = "", Extensions = "mseq" }
                , new Mime { Id = 789, Source = "iana", Value = "application/vnd.msign" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 790, Source = "iana", Value = "application/vnd.multiad.creator" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 791, Source = "iana", Value = "application/vnd.multiad.creator.cif" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 792, Source = "iana", Value = "application/vnd.music-niff" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 793, Source = "iana", Value = "application/vnd.musician" , Compressible = false, CharSet = "", Extensions = "mus" }
                , new Mime { Id = 794, Source = "iana", Value = "application/vnd.muvee.style" , Compressible = false, CharSet = "", Extensions = "msty" }
                , new Mime { Id = 795, Source = "iana", Value = "application/vnd.mynfc" , Compressible = false, CharSet = "", Extensions = "taglet" }
                , new Mime { Id = 796, Source = "iana", Value = "application/vnd.ncd.control" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 797, Source = "iana", Value = "application/vnd.ncd.reference" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 798, Source = "iana", Value = "application/vnd.nervana" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 799, Source = "iana", Value = "application/vnd.netfpx" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 800, Source = "iana", Value = "application/vnd.neurolanguage.nlu" , Compressible = false, CharSet = "", Extensions = "nlu" }
                , new Mime { Id = 801, Source = "iana", Value = "application/vnd.nintendo.nitro.rom" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 802, Source = "iana", Value = "application/vnd.nintendo.snes.rom" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 803, Source = "iana", Value = "application/vnd.nitf" , Compressible = false, CharSet = "", Extensions = "ntf, nitf" }
                , new Mime { Id = 804, Source = "iana", Value = "application/vnd.noblenet-directory" , Compressible = false, CharSet = "", Extensions = "nnd" }
                , new Mime { Id = 805, Source = "iana", Value = "application/vnd.noblenet-sealer" , Compressible = false, CharSet = "", Extensions = "nns" }
                , new Mime { Id = 806, Source = "iana", Value = "application/vnd.noblenet-web" , Compressible = false, CharSet = "", Extensions = "nnw" }
                , new Mime { Id = 807, Source = "iana", Value = "application/vnd.nokia.catalogs" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 808, Source = "iana", Value = "application/vnd.nokia.conml+wbxml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 809, Source = "iana", Value = "application/vnd.nokia.conml+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 810, Source = "iana", Value = "application/vnd.nokia.iptv.config+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 811, Source = "iana", Value = "application/vnd.nokia.isds-radio-presets" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 812, Source = "iana", Value = "application/vnd.nokia.landmark+wbxml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 813, Source = "iana", Value = "application/vnd.nokia.landmark+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 814, Source = "iana", Value = "application/vnd.nokia.landmarkcollection+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 815, Source = "iana", Value = "application/vnd.nokia.n-gage.ac+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 816, Source = "iana", Value = "application/vnd.nokia.n-gage.data" , Compressible = false, CharSet = "", Extensions = "ngdat" }
                , new Mime { Id = 817, Source = "iana", Value = "application/vnd.nokia.n-gage.symbian.install" , Compressible = false, CharSet = "", Extensions = "n-gage" }
                , new Mime { Id = 818, Source = "iana", Value = "application/vnd.nokia.ncd" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 819, Source = "iana", Value = "application/vnd.nokia.pcd+wbxml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 820, Source = "iana", Value = "application/vnd.nokia.pcd+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 821, Source = "iana", Value = "application/vnd.nokia.radio-preset" , Compressible = false, CharSet = "", Extensions = "rpst" }
                , new Mime { Id = 822, Source = "iana", Value = "application/vnd.nokia.radio-presets" , Compressible = false, CharSet = "", Extensions = "rpss" }
                , new Mime { Id = 823, Source = "iana", Value = "application/vnd.novadigm.edm" , Compressible = false, CharSet = "", Extensions = "edm" }
                , new Mime { Id = 824, Source = "iana", Value = "application/vnd.novadigm.edx" , Compressible = false, CharSet = "", Extensions = "edx" }
                , new Mime { Id = 825, Source = "iana", Value = "application/vnd.novadigm.ext" , Compressible = false, CharSet = "", Extensions = "ext" }
                , new Mime { Id = 826, Source = "iana", Value = "application/vnd.ntt-local.content-share" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 827, Source = "iana", Value = "application/vnd.ntt-local.file-transfer" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 828, Source = "iana", Value = "application/vnd.ntt-local.ogw_remote-access" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 829, Source = "iana", Value = "application/vnd.ntt-local.sip-ta_remote" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 830, Source = "iana", Value = "application/vnd.ntt-local.sip-ta_tcp_stream" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 831, Source = "iana", Value = "application/vnd.oasis.opendocument.chart" , Compressible = false, CharSet = "", Extensions = "odc" }
                , new Mime { Id = 832, Source = "iana", Value = "application/vnd.oasis.opendocument.chart-template" , Compressible = false, CharSet = "", Extensions = "otc" }
                , new Mime { Id = 833, Source = "iana", Value = "application/vnd.oasis.opendocument.database" , Compressible = false, CharSet = "", Extensions = "odb" }
                , new Mime { Id = 834, Source = "iana", Value = "application/vnd.oasis.opendocument.formula" , Compressible = false, CharSet = "", Extensions = "odf" }
                , new Mime { Id = 835, Source = "iana", Value = "application/vnd.oasis.opendocument.formula-template" , Compressible = false, CharSet = "", Extensions = "odft" }
                , new Mime { Id = 836, Source = "iana", Value = "application/vnd.oasis.opendocument.graphics" , Compressible = false, CharSet = "", Extensions = "odg" }
                , new Mime { Id = 837, Source = "iana", Value = "application/vnd.oasis.opendocument.graphics-template" , Compressible = false, CharSet = "", Extensions = "otg" }
                , new Mime { Id = 838, Source = "iana", Value = "application/vnd.oasis.opendocument.image" , Compressible = false, CharSet = "", Extensions = "odi" }
                , new Mime { Id = 839, Source = "iana", Value = "application/vnd.oasis.opendocument.image-template" , Compressible = false, CharSet = "", Extensions = "oti" }
                , new Mime { Id = 840, Source = "iana", Value = "application/vnd.oasis.opendocument.presentation" , Compressible = false, CharSet = "", Extensions = "odp" }
                , new Mime { Id = 841, Source = "iana", Value = "application/vnd.oasis.opendocument.presentation-template" , Compressible = false, CharSet = "", Extensions = "otp" }
                , new Mime { Id = 842, Source = "iana", Value = "application/vnd.oasis.opendocument.spreadsheet" , Compressible = false, CharSet = "", Extensions = "ods" }
                , new Mime { Id = 843, Source = "iana", Value = "application/vnd.oasis.opendocument.spreadsheet-template" , Compressible = false, CharSet = "", Extensions = "ots" }
                , new Mime { Id = 844, Source = "iana", Value = "application/vnd.oasis.opendocument.text" , Compressible = false, CharSet = "", Extensions = "odt" }
                , new Mime { Id = 845, Source = "iana", Value = "application/vnd.oasis.opendocument.text-master" , Compressible = false, CharSet = "", Extensions = "odm" }
                , new Mime { Id = 846, Source = "iana", Value = "application/vnd.oasis.opendocument.text-template" , Compressible = false, CharSet = "", Extensions = "ott" }
                , new Mime { Id = 847, Source = "iana", Value = "application/vnd.oasis.opendocument.text-web" , Compressible = false, CharSet = "", Extensions = "oth" }
                , new Mime { Id = 848, Source = "iana", Value = "application/vnd.obn" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 849, Source = "iana", Value = "application/vnd.oftn.l10n+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 850, Source = "iana", Value = "application/vnd.oipf.contentaccessdownload+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 851, Source = "iana", Value = "application/vnd.oipf.contentaccessstreaming+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 852, Source = "iana", Value = "application/vnd.oipf.cspg-hexbinary" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 853, Source = "iana", Value = "application/vnd.oipf.dae.svg+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 854, Source = "iana", Value = "application/vnd.oipf.dae.xhtml+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 855, Source = "iana", Value = "application/vnd.oipf.mippvcontrolmessage+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 856, Source = "iana", Value = "application/vnd.oipf.pae.gem" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 857, Source = "iana", Value = "application/vnd.oipf.spdiscovery+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 858, Source = "iana", Value = "application/vnd.oipf.spdlist+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 859, Source = "iana", Value = "application/vnd.oipf.ueprofile+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 860, Source = "iana", Value = "application/vnd.oipf.userprofile+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 861, Source = "iana", Value = "application/vnd.olpc-sugar" , Compressible = false, CharSet = "", Extensions = "xo" }
                , new Mime { Id = 862, Source = "iana", Value = "application/vnd.oma-scws-config" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 863, Source = "iana", Value = "application/vnd.oma-scws-http-request" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 864, Source = "iana", Value = "application/vnd.oma-scws-http-response" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 865, Source = "iana", Value = "application/vnd.oma.bcast.associated-procedure-parameter+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 866, Source = "iana", Value = "application/vnd.oma.bcast.drm-trigger+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 867, Source = "iana", Value = "application/vnd.oma.bcast.imd+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 868, Source = "iana", Value = "application/vnd.oma.bcast.ltkm" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 869, Source = "iana", Value = "application/vnd.oma.bcast.notification+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 870, Source = "iana", Value = "application/vnd.oma.bcast.provisioningtrigger" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 871, Source = "iana", Value = "application/vnd.oma.bcast.sgboot" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 872, Source = "iana", Value = "application/vnd.oma.bcast.sgdd+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 873, Source = "iana", Value = "application/vnd.oma.bcast.sgdu" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 874, Source = "iana", Value = "application/vnd.oma.bcast.simple-symbol-container" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 875, Source = "iana", Value = "application/vnd.oma.bcast.smartcard-trigger+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 876, Source = "iana", Value = "application/vnd.oma.bcast.sprov+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 877, Source = "iana", Value = "application/vnd.oma.bcast.stkm" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 878, Source = "iana", Value = "application/vnd.oma.cab-address-book+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 879, Source = "iana", Value = "application/vnd.oma.cab-feature-handler+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 880, Source = "iana", Value = "application/vnd.oma.cab-pcc+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 881, Source = "iana", Value = "application/vnd.oma.cab-subs-invite+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 882, Source = "iana", Value = "application/vnd.oma.cab-user-prefs+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 883, Source = "iana", Value = "application/vnd.oma.dcd" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 884, Source = "iana", Value = "application/vnd.oma.dcdc" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 885, Source = "iana", Value = "application/vnd.oma.dd2+xml" , Compressible = false, CharSet = "", Extensions = "dd2" }
                , new Mime { Id = 886, Source = "iana", Value = "application/vnd.oma.drm.risd+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 887, Source = "iana", Value = "application/vnd.oma.group-usage-list+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 888, Source = "iana", Value = "application/vnd.oma.pal+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 889, Source = "iana", Value = "application/vnd.oma.poc.detailed-progress-report+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 890, Source = "iana", Value = "application/vnd.oma.poc.final-report+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 891, Source = "iana", Value = "application/vnd.oma.poc.groups+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 892, Source = "iana", Value = "application/vnd.oma.poc.invocation-descriptor+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 893, Source = "iana", Value = "application/vnd.oma.poc.optimized-progress-report+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 894, Source = "iana", Value = "application/vnd.oma.push" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 895, Source = "iana", Value = "application/vnd.oma.scidm.messages+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 896, Source = "iana", Value = "application/vnd.oma.xcap-directory+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 897, Source = "iana", Value = "application/vnd.omads-email+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 898, Source = "iana", Value = "application/vnd.omads-file+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 899, Source = "iana", Value = "application/vnd.omads-folder+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 900, Source = "iana", Value = "application/vnd.omaloc-supl-init" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 901, Source = "iana", Value = "application/vnd.onepager" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 902, Source = "iana", Value = "application/vnd.openblox.game+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 903, Source = "iana", Value = "application/vnd.openblox.game-binary" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 904, Source = "iana", Value = "application/vnd.openeye.oeb" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 905, Source = "apache", Value = "application/vnd.openofficeorg.extension" , Compressible = false, CharSet = "", Extensions = "oxt" }
                , new Mime { Id = 906, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.custom-properties+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 907, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.customxmlproperties+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 908, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.drawing+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 909, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.drawingml.chart+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 910, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.drawingml.chartshapes+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 911, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.drawingml.diagramcolors+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 912, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.drawingml.diagramdata+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 913, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.drawingml.diagramlayout+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 914, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.drawingml.diagramstyle+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 915, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.extended-properties+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 916, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.presentationml-template" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 917, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.presentationml.commentauthors+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 918, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.presentationml.comments+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 919, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.presentationml.handoutmaster+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 920, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.presentationml.notesmaster+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 921, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.presentationml.notesslide+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 922, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.presentationml.presentation" , Compressible = false, CharSet = "", Extensions = "pptx" }
                , new Mime { Id = 923, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.presentationml.presentation.main+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 924, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.presentationml.presprops+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 925, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.presentationml.slide" , Compressible = false, CharSet = "", Extensions = "sldx" }
                , new Mime { Id = 926, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.presentationml.slide+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 927, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.presentationml.slidelayout+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 928, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.presentationml.slidemaster+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 929, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.presentationml.slideshow" , Compressible = false, CharSet = "", Extensions = "ppsx" }
                , new Mime { Id = 930, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.presentationml.slideshow.main+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 931, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.presentationml.slideupdateinfo+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 932, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.presentationml.tablestyles+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 933, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.presentationml.tags+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 934, Source = "apache", Value = "application/vnd.openxmlformats-officedocument.presentationml.template" , Compressible = false, CharSet = "", Extensions = "potx" }
                , new Mime { Id = 935, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.presentationml.template.main+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 936, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.presentationml.viewprops+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 937, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.spreadsheetml-template" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 938, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.spreadsheetml.calcchain+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 939, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.spreadsheetml.chartsheet+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 940, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.spreadsheetml.comments+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 941, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.spreadsheetml.connections+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 942, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.spreadsheetml.dialogsheet+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 943, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.spreadsheetml.externallink+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 944, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.spreadsheetml.pivotcachedefinition+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 945, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.spreadsheetml.pivotcacherecords+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 946, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.spreadsheetml.pivottable+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 947, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.spreadsheetml.querytable+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 948, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.spreadsheetml.revisionheaders+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 949, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.spreadsheetml.revisionlog+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 950, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.spreadsheetml.sharedstrings+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 951, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" , Compressible = false, CharSet = "", Extensions = "xlsx" }
                , new Mime { Id = 952, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 953, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheetmetadata+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 954, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.spreadsheetml.styles+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 955, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.spreadsheetml.table+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 956, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.spreadsheetml.tablesinglecells+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 957, Source = "apache", Value = "application/vnd.openxmlformats-officedocument.spreadsheetml.template" , Compressible = false, CharSet = "", Extensions = "xltx" }
                , new Mime { Id = 958, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.spreadsheetml.template.main+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 959, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.spreadsheetml.usernames+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 960, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.spreadsheetml.volatiledependencies+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 961, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.spreadsheetml.worksheet+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 962, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.theme+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 963, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.themeoverride+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 964, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.vmldrawing" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 965, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.wordprocessingml-template" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 966, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.wordprocessingml.comments+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 967, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.wordprocessingml.document" , Compressible = false, CharSet = "", Extensions = "docx" }
                , new Mime { Id = 968, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.wordprocessingml.document.glossary+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 969, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.wordprocessingml.document.main+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 970, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.wordprocessingml.endnotes+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 971, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.wordprocessingml.fonttable+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 972, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.wordprocessingml.footer+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 973, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.wordprocessingml.footnotes+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 974, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.wordprocessingml.numbering+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 975, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.wordprocessingml.settings+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 976, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.wordprocessingml.styles+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 977, Source = "apache", Value = "application/vnd.openxmlformats-officedocument.wordprocessingml.template" , Compressible = false, CharSet = "", Extensions = "dotx" }
                , new Mime { Id = 978, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.wordprocessingml.template.main+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 979, Source = "iana", Value = "application/vnd.openxmlformats-officedocument.wordprocessingml.websettings+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 980, Source = "iana", Value = "application/vnd.openxmlformats-package.core-properties+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 981, Source = "iana", Value = "application/vnd.openxmlformats-package.digital-signature-xmlsignature+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 982, Source = "iana", Value = "application/vnd.openxmlformats-package.relationships+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 983, Source = "iana", Value = "application/vnd.oracle.resource+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 984, Source = "iana", Value = "application/vnd.orange.indata" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 985, Source = "iana", Value = "application/vnd.osa.netdeploy" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 986, Source = "iana", Value = "application/vnd.osgeo.mapguide.package" , Compressible = false, CharSet = "", Extensions = "mgp" }
                , new Mime { Id = 987, Source = "iana", Value = "application/vnd.osgi.bundle" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 988, Source = "iana", Value = "application/vnd.osgi.dp" , Compressible = false, CharSet = "", Extensions = "dp" }
                , new Mime { Id = 989, Source = "iana", Value = "application/vnd.osgi.subsystem" , Compressible = false, CharSet = "", Extensions = "esa" }
                , new Mime { Id = 990, Source = "iana", Value = "application/vnd.otps.ct-kip+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 991, Source = "iana", Value = "application/vnd.oxli.countgraph" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 992, Source = "iana", Value = "application/vnd.pagerduty+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 993, Source = "iana", Value = "application/vnd.palm" , Compressible = false, CharSet = "", Extensions = "pdb, pqa, oprc" }
                , new Mime { Id = 994, Source = "iana", Value = "application/vnd.panoply" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 995, Source = "iana", Value = "application/vnd.paos+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 996, Source = "apache", Value = "application/vnd.paos.xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 997, Source = "iana", Value = "application/vnd.pawaafile" , Compressible = false, CharSet = "", Extensions = "paw" }
                , new Mime { Id = 998, Source = "iana", Value = "application/vnd.pcos" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 999, Source = "iana", Value = "application/vnd.pg.format" , Compressible = false, CharSet = "", Extensions = "str" }
                , new Mime { Id = 1000, Source = "iana", Value = "application/vnd.pg.osasli" , Compressible = false, CharSet = "", Extensions = "ei6" }
                , new Mime { Id = 1001, Source = "iana", Value = "application/vnd.piaccess.application-licence" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1002, Source = "iana", Value = "application/vnd.picsel" , Compressible = false, CharSet = "", Extensions = "efif" }
                , new Mime { Id = 1003, Source = "iana", Value = "application/vnd.pmi.widget" , Compressible = false, CharSet = "", Extensions = "wg" }
                , new Mime { Id = 1004, Source = "iana", Value = "application/vnd.poc.group-advertisement+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1005, Source = "iana", Value = "application/vnd.pocketlearn" , Compressible = false, CharSet = "", Extensions = "plf" }
                , new Mime { Id = 1006, Source = "iana", Value = "application/vnd.powerbuilder6" , Compressible = false, CharSet = "", Extensions = "pbd" }
                , new Mime { Id = 1007, Source = "iana", Value = "application/vnd.powerbuilder6-s" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1008, Source = "iana", Value = "application/vnd.powerbuilder7" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1009, Source = "iana", Value = "application/vnd.powerbuilder7-s" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1010, Source = "iana", Value = "application/vnd.powerbuilder75" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1011, Source = "iana", Value = "application/vnd.powerbuilder75-s" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1012, Source = "iana", Value = "application/vnd.preminet" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1013, Source = "iana", Value = "application/vnd.previewsystems.box" , Compressible = false, CharSet = "", Extensions = "box" }
                , new Mime { Id = 1014, Source = "iana", Value = "application/vnd.proteus.magazine" , Compressible = false, CharSet = "", Extensions = "mgz" }
                , new Mime { Id = 1015, Source = "iana", Value = "application/vnd.publishare-delta-tree" , Compressible = false, CharSet = "", Extensions = "qps" }
                , new Mime { Id = 1016, Source = "iana", Value = "application/vnd.pvi.ptid1" , Compressible = false, CharSet = "", Extensions = "ptid" }
                , new Mime { Id = 1017, Source = "iana", Value = "application/vnd.pwg-multiplexed" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1018, Source = "iana", Value = "application/vnd.pwg-xhtml-print+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1019, Source = "iana", Value = "application/vnd.qualcomm.brew-app-res" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1020, Source = "iana", Value = "application/vnd.quark.quarkxpress" , Compressible = false, CharSet = "", Extensions = "qxd, qxt, qwd, qwt, qxl, qxb" }
                , new Mime { Id = 1021, Source = "iana", Value = "application/vnd.quobject-quoxdocument" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1022, Source = "iana", Value = "application/vnd.radisys.moml+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1023, Source = "iana", Value = "application/vnd.radisys.msml+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1024, Source = "iana", Value = "application/vnd.radisys.msml-audit+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1025, Source = "iana", Value = "application/vnd.radisys.msml-audit-conf+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1026, Source = "iana", Value = "application/vnd.radisys.msml-audit-conn+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1027, Source = "iana", Value = "application/vnd.radisys.msml-audit-dialog+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1028, Source = "iana", Value = "application/vnd.radisys.msml-audit-stream+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1029, Source = "iana", Value = "application/vnd.radisys.msml-conf+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1030, Source = "iana", Value = "application/vnd.radisys.msml-dialog+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1031, Source = "iana", Value = "application/vnd.radisys.msml-dialog-base+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1032, Source = "iana", Value = "application/vnd.radisys.msml-dialog-fax-detect+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1033, Source = "iana", Value = "application/vnd.radisys.msml-dialog-fax-sendrecv+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1034, Source = "iana", Value = "application/vnd.radisys.msml-dialog-group+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1035, Source = "iana", Value = "application/vnd.radisys.msml-dialog-speech+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1036, Source = "iana", Value = "application/vnd.radisys.msml-dialog-transform+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1037, Source = "iana", Value = "application/vnd.rainstor.data" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1038, Source = "iana", Value = "application/vnd.rapid" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1039, Source = "iana", Value = "application/vnd.realvnc.bed" , Compressible = false, CharSet = "", Extensions = "bed" }
                , new Mime { Id = 1040, Source = "iana", Value = "application/vnd.recordare.musicxml" , Compressible = false, CharSet = "", Extensions = "mxl" }
                , new Mime { Id = 1041, Source = "iana", Value = "application/vnd.recordare.musicxml+xml" , Compressible = false, CharSet = "", Extensions = "musicxml" }
                , new Mime { Id = 1042, Source = "iana", Value = "application/vnd.renlearn.rlprint" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1043, Source = "iana", Value = "application/vnd.rig.cryptonote" , Compressible = false, CharSet = "", Extensions = "cryptonote" }
                , new Mime { Id = 1044, Source = "apache", Value = "application/vnd.rim.cod" , Compressible = false, CharSet = "", Extensions = "cod" }
                , new Mime { Id = 1045, Source = "apache", Value = "application/vnd.rn-realmedia" , Compressible = false, CharSet = "", Extensions = "rm" }
                , new Mime { Id = 1046, Source = "apache", Value = "application/vnd.rn-realmedia-vbr" , Compressible = false, CharSet = "", Extensions = "rmvb" }
                , new Mime { Id = 1047, Source = "iana", Value = "application/vnd.route66.link66+xml" , Compressible = false, CharSet = "", Extensions = "link66" }
                , new Mime { Id = 1048, Source = "iana", Value = "application/vnd.rs-274x" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1049, Source = "iana", Value = "application/vnd.ruckus.download" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1050, Source = "iana", Value = "application/vnd.s3sms" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1051, Source = "iana", Value = "application/vnd.sailingtracker.track" , Compressible = false, CharSet = "", Extensions = "st" }
                , new Mime { Id = 1052, Source = "iana", Value = "application/vnd.sbm.cid" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1053, Source = "iana", Value = "application/vnd.sbm.mid2" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1054, Source = "iana", Value = "application/vnd.scribus" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1055, Source = "iana", Value = "application/vnd.sealed.3df" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1056, Source = "iana", Value = "application/vnd.sealed.csf" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1057, Source = "iana", Value = "application/vnd.sealed.doc" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1058, Source = "iana", Value = "application/vnd.sealed.eml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1059, Source = "iana", Value = "application/vnd.sealed.mht" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1060, Source = "iana", Value = "application/vnd.sealed.net" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1061, Source = "iana", Value = "application/vnd.sealed.ppt" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1062, Source = "iana", Value = "application/vnd.sealed.tiff" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1063, Source = "iana", Value = "application/vnd.sealed.xls" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1064, Source = "iana", Value = "application/vnd.sealedmedia.softseal.html" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1065, Source = "iana", Value = "application/vnd.sealedmedia.softseal.pdf" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1066, Source = "iana", Value = "application/vnd.seemail" , Compressible = false, CharSet = "", Extensions = "see" }
                , new Mime { Id = 1067, Source = "iana", Value = "application/vnd.sema" , Compressible = false, CharSet = "", Extensions = "sema" }
                , new Mime { Id = 1068, Source = "iana", Value = "application/vnd.semd" , Compressible = false, CharSet = "", Extensions = "semd" }
                , new Mime { Id = 1069, Source = "iana", Value = "application/vnd.semf" , Compressible = false, CharSet = "", Extensions = "semf" }
                , new Mime { Id = 1070, Source = "iana", Value = "application/vnd.shana.informed.formdata" , Compressible = false, CharSet = "", Extensions = "ifm" }
                , new Mime { Id = 1071, Source = "iana", Value = "application/vnd.shana.informed.formtemplate" , Compressible = false, CharSet = "", Extensions = "itp" }
                , new Mime { Id = 1072, Source = "iana", Value = "application/vnd.shana.informed.interchange" , Compressible = false, CharSet = "", Extensions = "iif" }
                , new Mime { Id = 1073, Source = "iana", Value = "application/vnd.shana.informed.package" , Compressible = false, CharSet = "", Extensions = "ipk" }
                , new Mime { Id = 1074, Source = "iana", Value = "application/vnd.simtech-mindmapper" , Compressible = false, CharSet = "", Extensions = "twd, twds" }
                , new Mime { Id = 1075, Source = "iana", Value = "application/vnd.siren+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 1076, Source = "iana", Value = "application/vnd.smaf" , Compressible = false, CharSet = "", Extensions = "mmf" }
                , new Mime { Id = 1077, Source = "iana", Value = "application/vnd.smart.notebook" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1078, Source = "iana", Value = "application/vnd.smart.teacher" , Compressible = false, CharSet = "", Extensions = "teacher" }
                , new Mime { Id = 1079, Source = "iana", Value = "application/vnd.software602.filler.form+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1080, Source = "iana", Value = "application/vnd.software602.filler.form-xml-zip" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1081, Source = "iana", Value = "application/vnd.solent.sdkm+xml" , Compressible = false, CharSet = "", Extensions = "sdkm, sdkd" }
                , new Mime { Id = 1082, Source = "iana", Value = "application/vnd.spotfire.dxp" , Compressible = false, CharSet = "", Extensions = "dxp" }
                , new Mime { Id = 1083, Source = "iana", Value = "application/vnd.spotfire.sfs" , Compressible = false, CharSet = "", Extensions = "sfs" }
                , new Mime { Id = 1084, Source = "iana", Value = "application/vnd.sss-cod" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1085, Source = "iana", Value = "application/vnd.sss-dtf" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1086, Source = "iana", Value = "application/vnd.sss-ntf" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1087, Source = "apache", Value = "application/vnd.stardivision.calc" , Compressible = false, CharSet = "", Extensions = "sdc" }
                , new Mime { Id = 1088, Source = "apache", Value = "application/vnd.stardivision.draw" , Compressible = false, CharSet = "", Extensions = "sda" }
                , new Mime { Id = 1089, Source = "apache", Value = "application/vnd.stardivision.impress" , Compressible = false, CharSet = "", Extensions = "sdd" }
                , new Mime { Id = 1090, Source = "apache", Value = "application/vnd.stardivision.math" , Compressible = false, CharSet = "", Extensions = "smf" }
                , new Mime { Id = 1091, Source = "apache", Value = "application/vnd.stardivision.writer" , Compressible = false, CharSet = "", Extensions = "sdw, vor" }
                , new Mime { Id = 1092, Source = "apache", Value = "application/vnd.stardivision.writer-global" , Compressible = false, CharSet = "", Extensions = "sgl" }
                , new Mime { Id = 1093, Source = "iana", Value = "application/vnd.stepmania.package" , Compressible = false, CharSet = "", Extensions = "smzip" }
                , new Mime { Id = 1094, Source = "iana", Value = "application/vnd.stepmania.stepchart" , Compressible = false, CharSet = "", Extensions = "sm" }
                , new Mime { Id = 1095, Source = "iana", Value = "application/vnd.street-stream" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1096, Source = "iana", Value = "application/vnd.sun.wadl+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1097, Source = "apache", Value = "application/vnd.sun.xml.calc" , Compressible = false, CharSet = "", Extensions = "sxc" }
                , new Mime { Id = 1098, Source = "apache", Value = "application/vnd.sun.xml.calc.template" , Compressible = false, CharSet = "", Extensions = "stc" }
                , new Mime { Id = 1099, Source = "apache", Value = "application/vnd.sun.xml.draw" , Compressible = false, CharSet = "", Extensions = "sxd" }
                , new Mime { Id = 1100, Source = "apache", Value = "application/vnd.sun.xml.draw.template" , Compressible = false, CharSet = "", Extensions = "std" }
                , new Mime { Id = 1101, Source = "apache", Value = "application/vnd.sun.xml.impress" , Compressible = false, CharSet = "", Extensions = "sxi" }
                , new Mime { Id = 1102, Source = "apache", Value = "application/vnd.sun.xml.impress.template" , Compressible = false, CharSet = "", Extensions = "sti" }
                , new Mime { Id = 1103, Source = "apache", Value = "application/vnd.sun.xml.math" , Compressible = false, CharSet = "", Extensions = "sxm" }
                , new Mime { Id = 1104, Source = "apache", Value = "application/vnd.sun.xml.writer" , Compressible = false, CharSet = "", Extensions = "sxw" }
                , new Mime { Id = 1105, Source = "apache", Value = "application/vnd.sun.xml.writer.global" , Compressible = false, CharSet = "", Extensions = "sxg" }
                , new Mime { Id = 1106, Source = "apache", Value = "application/vnd.sun.xml.writer.template" , Compressible = false, CharSet = "", Extensions = "stw" }
                , new Mime { Id = 1107, Source = "iana", Value = "application/vnd.sus-calendar" , Compressible = false, CharSet = "", Extensions = "sus, susp" }
                , new Mime { Id = 1108, Source = "iana", Value = "application/vnd.svd" , Compressible = false, CharSet = "", Extensions = "svd" }
                , new Mime { Id = 1109, Source = "iana", Value = "application/vnd.swiftview-ics" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1110, Source = "apache", Value = "application/vnd.symbian.install" , Compressible = false, CharSet = "", Extensions = "sis, sisx" }
                , new Mime { Id = 1111, Source = "iana", Value = "application/vnd.syncml+xml" , Compressible = false, CharSet = "", Extensions = "xsm" }
                , new Mime { Id = 1112, Source = "iana", Value = "application/vnd.syncml.dm+wbxml" , Compressible = false, CharSet = "", Extensions = "bdm" }
                , new Mime { Id = 1113, Source = "iana", Value = "application/vnd.syncml.dm+xml" , Compressible = false, CharSet = "", Extensions = "xdm" }
                , new Mime { Id = 1114, Source = "iana", Value = "application/vnd.syncml.dm.notification" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1115, Source = "iana", Value = "application/vnd.syncml.dmddf+wbxml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1116, Source = "iana", Value = "application/vnd.syncml.dmddf+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1117, Source = "iana", Value = "application/vnd.syncml.dmtnds+wbxml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1118, Source = "iana", Value = "application/vnd.syncml.dmtnds+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1119, Source = "iana", Value = "application/vnd.syncml.ds.notification" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1120, Source = "iana", Value = "application/vnd.tao.intent-module-archive" , Compressible = false, CharSet = "", Extensions = "tao" }
                , new Mime { Id = 1121, Source = "iana", Value = "application/vnd.tcpdump.pcap" , Compressible = false, CharSet = "", Extensions = "pcap, cap, dmp" }
                , new Mime { Id = 1122, Source = "iana", Value = "application/vnd.tmd.mediaflex.api+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1123, Source = "iana", Value = "application/vnd.tml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1124, Source = "iana", Value = "application/vnd.tmobile-livetv" , Compressible = false, CharSet = "", Extensions = "tmo" }
                , new Mime { Id = 1125, Source = "iana", Value = "application/vnd.trid.tpt" , Compressible = false, CharSet = "", Extensions = "tpt" }
                , new Mime { Id = 1126, Source = "iana", Value = "application/vnd.triscape.mxs" , Compressible = false, CharSet = "", Extensions = "mxs" }
                , new Mime { Id = 1127, Source = "iana", Value = "application/vnd.trueapp" , Compressible = false, CharSet = "", Extensions = "tra" }
                , new Mime { Id = 1128, Source = "iana", Value = "application/vnd.truedoc" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1129, Source = "iana", Value = "application/vnd.ubisoft.webplayer" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1130, Source = "iana", Value = "application/vnd.ufdl" , Compressible = false, CharSet = "", Extensions = "ufd, ufdl" }
                , new Mime { Id = 1131, Source = "iana", Value = "application/vnd.uiq.theme" , Compressible = false, CharSet = "", Extensions = "utz" }
                , new Mime { Id = 1132, Source = "iana", Value = "application/vnd.umajin" , Compressible = false, CharSet = "", Extensions = "umj" }
                , new Mime { Id = 1133, Source = "iana", Value = "application/vnd.unity" , Compressible = false, CharSet = "", Extensions = "unityweb" }
                , new Mime { Id = 1134, Source = "iana", Value = "application/vnd.uoml+xml" , Compressible = false, CharSet = "", Extensions = "uoml" }
                , new Mime { Id = 1135, Source = "iana", Value = "application/vnd.uplanet.alert" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1136, Source = "iana", Value = "application/vnd.uplanet.alert-wbxml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1137, Source = "iana", Value = "application/vnd.uplanet.bearer-choice" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1138, Source = "iana", Value = "application/vnd.uplanet.bearer-choice-wbxml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1139, Source = "iana", Value = "application/vnd.uplanet.cacheop" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1140, Source = "iana", Value = "application/vnd.uplanet.cacheop-wbxml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1141, Source = "iana", Value = "application/vnd.uplanet.channel" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1142, Source = "iana", Value = "application/vnd.uplanet.channel-wbxml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1143, Source = "iana", Value = "application/vnd.uplanet.list" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1144, Source = "iana", Value = "application/vnd.uplanet.list-wbxml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1145, Source = "iana", Value = "application/vnd.uplanet.listcmd" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1146, Source = "iana", Value = "application/vnd.uplanet.listcmd-wbxml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1147, Source = "iana", Value = "application/vnd.uplanet.signal" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1148, Source = "iana", Value = "application/vnd.uri-map" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1149, Source = "iana", Value = "application/vnd.valve.source.material" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1150, Source = "iana", Value = "application/vnd.vcx" , Compressible = false, CharSet = "", Extensions = "vcx" }
                , new Mime { Id = 1151, Source = "iana", Value = "application/vnd.vd-study" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1152, Source = "iana", Value = "application/vnd.vectorworks" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1153, Source = "iana", Value = "application/vnd.vel+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 1154, Source = "iana", Value = "application/vnd.verimatrix.vcas" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1155, Source = "iana", Value = "application/vnd.vidsoft.vidconference" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1156, Source = "iana", Value = "application/vnd.visio" , Compressible = false, CharSet = "", Extensions = "vsd, vst, vss, vsw" }
                , new Mime { Id = 1157, Source = "iana", Value = "application/vnd.visionary" , Compressible = false, CharSet = "", Extensions = "vis" }
                , new Mime { Id = 1158, Source = "iana", Value = "application/vnd.vividence.scriptfile" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1159, Source = "iana", Value = "application/vnd.vsf" , Compressible = false, CharSet = "", Extensions = "vsf" }
                , new Mime { Id = 1160, Source = "iana", Value = "application/vnd.wap.sic" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1161, Source = "iana", Value = "application/vnd.wap.slc" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1162, Source = "iana", Value = "application/vnd.wap.wbxml" , Compressible = false, CharSet = "", Extensions = "wbxml" }
                , new Mime { Id = 1163, Source = "iana", Value = "application/vnd.wap.wmlc" , Compressible = false, CharSet = "", Extensions = "wmlc" }
                , new Mime { Id = 1164, Source = "iana", Value = "application/vnd.wap.wmlscriptc" , Compressible = false, CharSet = "", Extensions = "wmlsc" }
                , new Mime { Id = 1165, Source = "iana", Value = "application/vnd.webturbo" , Compressible = false, CharSet = "", Extensions = "wtb" }
                , new Mime { Id = 1166, Source = "iana", Value = "application/vnd.wfa.p2p" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1167, Source = "iana", Value = "application/vnd.wfa.wsc" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1168, Source = "iana", Value = "application/vnd.windows.devicepairing" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1169, Source = "iana", Value = "application/vnd.wmc" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1170, Source = "iana", Value = "application/vnd.wmf.bootstrap" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1171, Source = "iana", Value = "application/vnd.wolfram.mathematica" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1172, Source = "iana", Value = "application/vnd.wolfram.mathematica.package" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1173, Source = "iana", Value = "application/vnd.wolfram.player" , Compressible = false, CharSet = "", Extensions = "nbp" }
                , new Mime { Id = 1174, Source = "iana", Value = "application/vnd.wordperfect" , Compressible = false, CharSet = "", Extensions = "wpd" }
                , new Mime { Id = 1175, Source = "iana", Value = "application/vnd.wqd" , Compressible = false, CharSet = "", Extensions = "wqd" }
                , new Mime { Id = 1176, Source = "iana", Value = "application/vnd.wrq-hp3000-labelled" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1177, Source = "iana", Value = "application/vnd.wt.stf" , Compressible = false, CharSet = "", Extensions = "stf" }
                , new Mime { Id = 1178, Source = "iana", Value = "application/vnd.wv.csp+wbxml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1179, Source = "iana", Value = "application/vnd.wv.csp+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1180, Source = "iana", Value = "application/vnd.wv.ssp+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1181, Source = "iana", Value = "application/vnd.xacml+json" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 1182, Source = "iana", Value = "application/vnd.xara" , Compressible = false, CharSet = "", Extensions = "xar" }
                , new Mime { Id = 1183, Source = "iana", Value = "application/vnd.xfdl" , Compressible = false, CharSet = "", Extensions = "xfdl" }
                , new Mime { Id = 1184, Source = "iana", Value = "application/vnd.xfdl.webform" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1185, Source = "iana", Value = "application/vnd.xmi+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1186, Source = "iana", Value = "application/vnd.xmpie.cpkg" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1187, Source = "iana", Value = "application/vnd.xmpie.dpkg" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1188, Source = "iana", Value = "application/vnd.xmpie.plan" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1189, Source = "iana", Value = "application/vnd.xmpie.ppkg" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1190, Source = "iana", Value = "application/vnd.xmpie.xlim" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1191, Source = "iana", Value = "application/vnd.yamaha.hv-dic" , Compressible = false, CharSet = "", Extensions = "hvd" }
                , new Mime { Id = 1192, Source = "iana", Value = "application/vnd.yamaha.hv-script" , Compressible = false, CharSet = "", Extensions = "hvs" }
                , new Mime { Id = 1193, Source = "iana", Value = "application/vnd.yamaha.hv-voice" , Compressible = false, CharSet = "", Extensions = "hvp" }
                , new Mime { Id = 1194, Source = "iana", Value = "application/vnd.yamaha.openscoreformat" , Compressible = false, CharSet = "", Extensions = "osf" }
                , new Mime { Id = 1195, Source = "iana", Value = "application/vnd.yamaha.openscoreformat.osfpvg+xml" , Compressible = false, CharSet = "", Extensions = "osfpvg" }
                , new Mime { Id = 1196, Source = "iana", Value = "application/vnd.yamaha.remote-setup" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1197, Source = "iana", Value = "application/vnd.yamaha.smaf-audio" , Compressible = false, CharSet = "", Extensions = "saf" }
                , new Mime { Id = 1198, Source = "iana", Value = "application/vnd.yamaha.smaf-phrase" , Compressible = false, CharSet = "", Extensions = "spf" }
                , new Mime { Id = 1199, Source = "iana", Value = "application/vnd.yamaha.through-ngn" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1200, Source = "iana", Value = "application/vnd.yamaha.tunnel-udpencap" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1201, Source = "iana", Value = "application/vnd.yaoweme" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1202, Source = "iana", Value = "application/vnd.yellowriver-custom-menu" , Compressible = false, CharSet = "", Extensions = "cmp" }
                , new Mime { Id = 1203, Source = "iana", Value = "application/vnd.zul" , Compressible = false, CharSet = "", Extensions = "zir, zirz" }
                , new Mime { Id = 1204, Source = "iana", Value = "application/vnd.zzazz.deck+xml" , Compressible = false, CharSet = "", Extensions = "zaz" }
                , new Mime { Id = 1205, Source = "iana", Value = "application/voicexml+xml" , Compressible = false, CharSet = "", Extensions = "vxml" }
                , new Mime { Id = 1206, Source = "iana", Value = "application/vq-rtcpxr" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1207, Source = "iana", Value = "application/watcherinfo+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1208, Source = "iana", Value = "application/whoispp-query" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1209, Source = "iana", Value = "application/whoispp-response" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1210, Source = "iana", Value = "application/widget" , Compressible = false, CharSet = "", Extensions = "wgt" }
                , new Mime { Id = 1211, Source = "apache", Value = "application/winhlp" , Compressible = false, CharSet = "", Extensions = "hlp" }
                , new Mime { Id = 1212, Source = "iana", Value = "application/wita" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1213, Source = "iana", Value = "application/wordperfect5.1" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1214, Source = "iana", Value = "application/wsdl+xml" , Compressible = false, CharSet = "", Extensions = "wsdl" }
                , new Mime { Id = 1215, Source = "iana", Value = "application/wspolicy+xml" , Compressible = false, CharSet = "", Extensions = "wspolicy" }
                , new Mime { Id = 1216, Source = "apache", Value = "application/x-7z-compressed" , Compressible = false, CharSet = "", Extensions = "7z" }
                , new Mime { Id = 1217, Source = "apache", Value = "application/x-abiword" , Compressible = false, CharSet = "", Extensions = "abw" }
                , new Mime { Id = 1218, Source = "apache", Value = "application/x-ace-compressed" , Compressible = false, CharSet = "", Extensions = "ace" }
                , new Mime { Id = 1219, Source = "apache", Value = "application/x-amf" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1220, Source = "apache", Value = "application/x-apple-diskimage" , Compressible = false, CharSet = "", Extensions = "dmg" }
                , new Mime { Id = 1221, Source = "apache", Value = "application/x-authorware-bin" , Compressible = false, CharSet = "", Extensions = "aab, x32, u32, vox" }
                , new Mime { Id = 1222, Source = "apache", Value = "application/x-authorware-map" , Compressible = false, CharSet = "", Extensions = "aam" }
                , new Mime { Id = 1223, Source = "apache", Value = "application/x-authorware-seg" , Compressible = false, CharSet = "", Extensions = "aas" }
                , new Mime { Id = 1224, Source = "apache", Value = "application/x-bcpio" , Compressible = false, CharSet = "", Extensions = "bcpio" }
                , new Mime { Id = 1225, Source = "", Value = "application/x-bdoc" , Compressible = false, CharSet = "", Extensions = "bdoc" }
                , new Mime { Id = 1226, Source = "apache", Value = "application/x-bittorrent" , Compressible = false, CharSet = "", Extensions = "torrent" }
                , new Mime { Id = 1227, Source = "apache", Value = "application/x-blorb" , Compressible = false, CharSet = "", Extensions = "blb, blorb" }
                , new Mime { Id = 1228, Source = "apache", Value = "application/x-bzip" , Compressible = false, CharSet = "", Extensions = "bz" }
                , new Mime { Id = 1229, Source = "apache", Value = "application/x-bzip2" , Compressible = false, CharSet = "", Extensions = "bz2, boz" }
                , new Mime { Id = 1230, Source = "apache", Value = "application/x-cbr" , Compressible = false, CharSet = "", Extensions = "cbr, cba, cbt, cbz, cb7" }
                , new Mime { Id = 1231, Source = "apache", Value = "application/x-cdlink" , Compressible = false, CharSet = "", Extensions = "vcd" }
                , new Mime { Id = 1232, Source = "apache", Value = "application/x-cfs-compressed" , Compressible = false, CharSet = "", Extensions = "cfs" }
                , new Mime { Id = 1233, Source = "apache", Value = "application/x-chat" , Compressible = false, CharSet = "", Extensions = "chat" }
                , new Mime { Id = 1234, Source = "apache", Value = "application/x-chess-pgn" , Compressible = false, CharSet = "", Extensions = "pgn" }
                , new Mime { Id = 1235, Source = "", Value = "application/x-chrome-extension" , Compressible = false, CharSet = "", Extensions = "crx" }
                , new Mime { Id = 1236, Source = "nginx", Value = "application/x-cocoa" , Compressible = false, CharSet = "", Extensions = "cco" }
                , new Mime { Id = 1237, Source = "apache", Value = "application/x-compress" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1238, Source = "apache", Value = "application/x-conference" , Compressible = false, CharSet = "", Extensions = "nsc" }
                , new Mime { Id = 1239, Source = "apache", Value = "application/x-cpio" , Compressible = false, CharSet = "", Extensions = "cpio" }
                , new Mime { Id = 1240, Source = "apache", Value = "application/x-csh" , Compressible = false, CharSet = "", Extensions = "csh" }
                , new Mime { Id = 1241, Source = "", Value = "application/x-deb" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1242, Source = "apache", Value = "application/x-debian-package" , Compressible = false, CharSet = "", Extensions = "deb, udeb" }
                , new Mime { Id = 1243, Source = "apache", Value = "application/x-dgc-compressed" , Compressible = false, CharSet = "", Extensions = "dgc" }
                , new Mime { Id = 1244, Source = "apache", Value = "application/x-director" , Compressible = false, CharSet = "", Extensions = "dir, dcr, dxr, cst, cct, cxt, w3d, fgd, swa" }
                , new Mime { Id = 1245, Source = "apache", Value = "application/x-doom" , Compressible = false, CharSet = "", Extensions = "wad" }
                , new Mime { Id = 1246, Source = "apache", Value = "application/x-dtbncx+xml" , Compressible = false, CharSet = "", Extensions = "ncx" }
                , new Mime { Id = 1247, Source = "apache", Value = "application/x-dtbook+xml" , Compressible = false, CharSet = "", Extensions = "dtb" }
                , new Mime { Id = 1248, Source = "apache", Value = "application/x-dtbresource+xml" , Compressible = false, CharSet = "", Extensions = "res" }
                , new Mime { Id = 1249, Source = "apache", Value = "application/x-dvi" , Compressible = false, CharSet = "", Extensions = "dvi" }
                , new Mime { Id = 1250, Source = "apache", Value = "application/x-envoy" , Compressible = false, CharSet = "", Extensions = "evy" }
                , new Mime { Id = 1251, Source = "apache", Value = "application/x-eva" , Compressible = false, CharSet = "", Extensions = "eva" }
                , new Mime { Id = 1252, Source = "apache", Value = "application/x-font-bdf" , Compressible = false, CharSet = "", Extensions = "bdf" }
                , new Mime { Id = 1253, Source = "apache", Value = "application/x-font-dos" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1254, Source = "apache", Value = "application/x-font-framemaker" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1255, Source = "apache", Value = "application/x-font-ghostscript" , Compressible = false, CharSet = "", Extensions = "gsf" }
                , new Mime { Id = 1256, Source = "apache", Value = "application/x-font-libgrx" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1257, Source = "apache", Value = "application/x-font-linux-psf" , Compressible = false, CharSet = "", Extensions = "psf" }
                , new Mime { Id = 1258, Source = "apache", Value = "application/x-font-otf" , Compressible = true, CharSet = "", Extensions = "otf" }
                , new Mime { Id = 1259, Source = "apache", Value = "application/x-font-pcf" , Compressible = false, CharSet = "", Extensions = "pcf" }
                , new Mime { Id = 1260, Source = "apache", Value = "application/x-font-snf" , Compressible = false, CharSet = "", Extensions = "snf" }
                , new Mime { Id = 1261, Source = "apache", Value = "application/x-font-speedo" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1262, Source = "apache", Value = "application/x-font-sunos-news" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1263, Source = "apache", Value = "application/x-font-ttf" , Compressible = true, CharSet = "", Extensions = "ttf, ttc" }
                , new Mime { Id = 1264, Source = "apache", Value = "application/x-font-type1" , Compressible = false, CharSet = "", Extensions = "pfa, pfb, pfm, afm" }
                , new Mime { Id = 1265, Source = "apache", Value = "application/x-font-vfont" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1266, Source = "apache", Value = "application/x-freearc" , Compressible = false, CharSet = "", Extensions = "arc" }
                , new Mime { Id = 1267, Source = "apache", Value = "application/x-futuresplash" , Compressible = false, CharSet = "", Extensions = "spl" }
                , new Mime { Id = 1268, Source = "apache", Value = "application/x-gca-compressed" , Compressible = false, CharSet = "", Extensions = "gca" }
                , new Mime { Id = 1269, Source = "apache", Value = "application/x-glulx" , Compressible = false, CharSet = "", Extensions = "ulx" }
                , new Mime { Id = 1270, Source = "apache", Value = "application/x-gnumeric" , Compressible = false, CharSet = "", Extensions = "gnumeric" }
                , new Mime { Id = 1271, Source = "apache", Value = "application/x-gramps-xml" , Compressible = false, CharSet = "", Extensions = "gramps" }
                , new Mime { Id = 1272, Source = "apache", Value = "application/x-gtar" , Compressible = false, CharSet = "", Extensions = "gtar" }
                , new Mime { Id = 1273, Source = "apache", Value = "application/x-gzip" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1274, Source = "apache", Value = "application/x-hdf" , Compressible = false, CharSet = "", Extensions = "hdf" }
                , new Mime { Id = 1275, Source = "", Value = "application/x-httpd-php" , Compressible = true, CharSet = "", Extensions = "php" }
                , new Mime { Id = 1276, Source = "apache", Value = "application/x-install-instructions" , Compressible = false, CharSet = "", Extensions = "install" }
                , new Mime { Id = 1277, Source = "apache", Value = "application/x-iso9660-image" , Compressible = false, CharSet = "", Extensions = "iso" }
                , new Mime { Id = 1278, Source = "nginx", Value = "application/x-java-archive-diff" , Compressible = false, CharSet = "", Extensions = "jardiff" }
                , new Mime { Id = 1279, Source = "apache", Value = "application/x-java-jnlp-file" , Compressible = false, CharSet = "", Extensions = "jnlp" }
                , new Mime { Id = 1280, Source = "", Value = "application/x-javascript" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 1281, Source = "apache", Value = "application/x-latex" , Compressible = false, CharSet = "", Extensions = "latex" }
                , new Mime { Id = 1282, Source = "", Value = "application/x-lua-bytecode" , Compressible = false, CharSet = "", Extensions = "luac" }
                , new Mime { Id = 1283, Source = "apache", Value = "application/x-lzh-compressed" , Compressible = false, CharSet = "", Extensions = "lzh, lha" }
                , new Mime { Id = 1284, Source = "nginx", Value = "application/x-makeself" , Compressible = false, CharSet = "", Extensions = "run" }
                , new Mime { Id = 1285, Source = "apache", Value = "application/x-mie" , Compressible = false, CharSet = "", Extensions = "mie" }
                , new Mime { Id = 1286, Source = "apache", Value = "application/x-mobipocket-ebook" , Compressible = false, CharSet = "", Extensions = "prc, mobi" }
                , new Mime { Id = 1287, Source = "", Value = "application/x-mpegurl" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1288, Source = "apache", Value = "application/x-ms-application" , Compressible = false, CharSet = "", Extensions = "application" }
                , new Mime { Id = 1289, Source = "apache", Value = "application/x-ms-shortcut" , Compressible = false, CharSet = "", Extensions = "lnk" }
                , new Mime { Id = 1290, Source = "apache", Value = "application/x-ms-wmd" , Compressible = false, CharSet = "", Extensions = "wmd" }
                , new Mime { Id = 1291, Source = "apache", Value = "application/x-ms-wmz" , Compressible = false, CharSet = "", Extensions = "wmz" }
                , new Mime { Id = 1292, Source = "apache", Value = "application/x-ms-xbap" , Compressible = false, CharSet = "", Extensions = "xbap" }
                , new Mime { Id = 1293, Source = "apache", Value = "application/x-msaccess" , Compressible = false, CharSet = "", Extensions = "mdb" }
                , new Mime { Id = 1294, Source = "apache", Value = "application/x-msbinder" , Compressible = false, CharSet = "", Extensions = "obd" }
                , new Mime { Id = 1295, Source = "apache", Value = "application/x-mscardfile" , Compressible = false, CharSet = "", Extensions = "crd" }
                , new Mime { Id = 1296, Source = "apache", Value = "application/x-msclip" , Compressible = false, CharSet = "", Extensions = "clp" }
                , new Mime { Id = 1297, Source = "", Value = "application/x-msdos-program" , Compressible = false, CharSet = "", Extensions = "exe" }
                , new Mime { Id = 1298, Source = "apache", Value = "application/x-msdownload" , Compressible = false, CharSet = "", Extensions = "exe, dll, com, bat, msi" }
                , new Mime { Id = 1299, Source = "apache", Value = "application/x-msmediaview" , Compressible = false, CharSet = "", Extensions = "mvb, m13, m14" }
                , new Mime { Id = 1300, Source = "apache", Value = "application/x-msmetafile" , Compressible = false, CharSet = "", Extensions = "wmf, wmz, emf, emz" }
                , new Mime { Id = 1301, Source = "apache", Value = "application/x-msmoney" , Compressible = false, CharSet = "", Extensions = "mny" }
                , new Mime { Id = 1302, Source = "apache", Value = "application/x-mspublisher" , Compressible = false, CharSet = "", Extensions = "pub" }
                , new Mime { Id = 1303, Source = "apache", Value = "application/x-msschedule" , Compressible = false, CharSet = "", Extensions = "scd" }
                , new Mime { Id = 1304, Source = "apache", Value = "application/x-msterminal" , Compressible = false, CharSet = "", Extensions = "trm" }
                , new Mime { Id = 1305, Source = "apache", Value = "application/x-mswrite" , Compressible = false, CharSet = "", Extensions = "wri" }
                , new Mime { Id = 1306, Source = "apache", Value = "application/x-netcdf" , Compressible = false, CharSet = "", Extensions = "nc, cdf" }
                , new Mime { Id = 1307, Source = "", Value = "application/x-ns-proxy-autoconfig" , Compressible = true, CharSet = "", Extensions = "pac" }
                , new Mime { Id = 1308, Source = "apache", Value = "application/x-nzb" , Compressible = false, CharSet = "", Extensions = "nzb" }
                , new Mime { Id = 1309, Source = "nginx", Value = "application/x-perl" , Compressible = false, CharSet = "", Extensions = "pl, pm" }
                , new Mime { Id = 1310, Source = "nginx", Value = "application/x-pilot" , Compressible = false, CharSet = "", Extensions = "prc, pdb" }
                , new Mime { Id = 1311, Source = "apache", Value = "application/x-pkcs12" , Compressible = false, CharSet = "", Extensions = "p12, pfx" }
                , new Mime { Id = 1312, Source = "apache", Value = "application/x-pkcs7-certificates" , Compressible = false, CharSet = "", Extensions = "p7b, spc" }
                , new Mime { Id = 1313, Source = "apache", Value = "application/x-pkcs7-certreqresp" , Compressible = false, CharSet = "", Extensions = "p7r" }
                , new Mime { Id = 1314, Source = "apache", Value = "application/x-rar-compressed" , Compressible = false, CharSet = "", Extensions = "rar" }
                , new Mime { Id = 1315, Source = "nginx", Value = "application/x-redhat-package-manager" , Compressible = false, CharSet = "", Extensions = "rpm" }
                , new Mime { Id = 1316, Source = "apache", Value = "application/x-research-info-systems" , Compressible = false, CharSet = "", Extensions = "ris" }
                , new Mime { Id = 1317, Source = "nginx", Value = "application/x-sea" , Compressible = false, CharSet = "", Extensions = "sea" }
                , new Mime { Id = 1318, Source = "apache", Value = "application/x-sh" , Compressible = true, CharSet = "", Extensions = "sh" }
                , new Mime { Id = 1319, Source = "apache", Value = "application/x-shar" , Compressible = false, CharSet = "", Extensions = "shar" }
                , new Mime { Id = 1320, Source = "apache", Value = "application/x-shockwave-flash" , Compressible = false, CharSet = "", Extensions = "swf" }
                , new Mime { Id = 1321, Source = "apache", Value = "application/x-silverlight-app" , Compressible = false, CharSet = "", Extensions = "xap" }
                , new Mime { Id = 1322, Source = "apache", Value = "application/x-sql" , Compressible = false, CharSet = "", Extensions = "sql" }
                , new Mime { Id = 1323, Source = "apache", Value = "application/x-stuffit" , Compressible = false, CharSet = "", Extensions = "sit" }
                , new Mime { Id = 1324, Source = "apache", Value = "application/x-stuffitx" , Compressible = false, CharSet = "", Extensions = "sitx" }
                , new Mime { Id = 1325, Source = "apache", Value = "application/x-subrip" , Compressible = false, CharSet = "", Extensions = "srt" }
                , new Mime { Id = 1326, Source = "apache", Value = "application/x-sv4cpio" , Compressible = false, CharSet = "", Extensions = "sv4cpio" }
                , new Mime { Id = 1327, Source = "apache", Value = "application/x-sv4crc" , Compressible = false, CharSet = "", Extensions = "sv4crc" }
                , new Mime { Id = 1328, Source = "apache", Value = "application/x-t3vm-image" , Compressible = false, CharSet = "", Extensions = "t3" }
                , new Mime { Id = 1329, Source = "apache", Value = "application/x-tads" , Compressible = false, CharSet = "", Extensions = "gam" }
                , new Mime { Id = 1330, Source = "apache", Value = "application/x-tar" , Compressible = true, CharSet = "", Extensions = "tar" }
                , new Mime { Id = 1331, Source = "apache", Value = "application/x-tcl" , Compressible = false, CharSet = "", Extensions = "tcl, tk" }
                , new Mime { Id = 1332, Source = "apache", Value = "application/x-tex" , Compressible = false, CharSet = "", Extensions = "tex" }
                , new Mime { Id = 1333, Source = "apache", Value = "application/x-tex-tfm" , Compressible = false, CharSet = "", Extensions = "tfm" }
                , new Mime { Id = 1334, Source = "apache", Value = "application/x-texinfo" , Compressible = false, CharSet = "", Extensions = "texinfo, texi" }
                , new Mime { Id = 1335, Source = "apache", Value = "application/x-tgif" , Compressible = false, CharSet = "", Extensions = "obj" }
                , new Mime { Id = 1336, Source = "apache", Value = "application/x-ustar" , Compressible = false, CharSet = "", Extensions = "ustar" }
                , new Mime { Id = 1337, Source = "apache", Value = "application/x-wais-source" , Compressible = false, CharSet = "", Extensions = "src" }
                , new Mime { Id = 1338, Source = "", Value = "application/x-web-app-manifest+json" , Compressible = true, CharSet = "", Extensions = "webapp" }
                , new Mime { Id = 1339, Source = "iana", Value = "application/x-www-form-urlencoded" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 1340, Source = "apache", Value = "application/x-x509-ca-cert" , Compressible = false, CharSet = "", Extensions = "der, crt, pem" }
                , new Mime { Id = 1341, Source = "apache", Value = "application/x-xfig" , Compressible = false, CharSet = "", Extensions = "fig" }
                , new Mime { Id = 1342, Source = "apache", Value = "application/x-xliff+xml" , Compressible = false, CharSet = "", Extensions = "xlf" }
                , new Mime { Id = 1343, Source = "apache", Value = "application/x-xpinstall" , Compressible = false, CharSet = "", Extensions = "xpi" }
                , new Mime { Id = 1344, Source = "apache", Value = "application/x-xz" , Compressible = false, CharSet = "", Extensions = "xz" }
                , new Mime { Id = 1345, Source = "apache", Value = "application/x-zmachine" , Compressible = false, CharSet = "", Extensions = "z1, z2, z3, z4, z5, z6, z7, z8" }
                , new Mime { Id = 1346, Source = "iana", Value = "application/x400-bp" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1347, Source = "iana", Value = "application/xacml+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1348, Source = "apache", Value = "application/xaml+xml" , Compressible = false, CharSet = "", Extensions = "xaml" }
                , new Mime { Id = 1349, Source = "iana", Value = "application/xcap-att+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1350, Source = "iana", Value = "application/xcap-caps+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1351, Source = "iana", Value = "application/xcap-diff+xml" , Compressible = false, CharSet = "", Extensions = "xdf" }
                , new Mime { Id = 1352, Source = "iana", Value = "application/xcap-el+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1353, Source = "iana", Value = "application/xcap-error+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1354, Source = "iana", Value = "application/xcap-ns+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1355, Source = "iana", Value = "application/xcon-conference-info+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1356, Source = "iana", Value = "application/xcon-conference-info-diff+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1357, Source = "iana", Value = "application/xenc+xml" , Compressible = false, CharSet = "", Extensions = "xenc" }
                , new Mime { Id = 1358, Source = "iana", Value = "application/xhtml+xml" , Compressible = true, CharSet = "", Extensions = "xhtml, xht" }
                , new Mime { Id = 1359, Source = "apache", Value = "application/xhtml-voice+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1360, Source = "iana", Value = "application/xml" , Compressible = true, CharSet = "", Extensions = "xml, xsl, xsd, rng" }
                , new Mime { Id = 1361, Source = "iana", Value = "application/xml-dtd" , Compressible = true, CharSet = "", Extensions = "dtd" }
                , new Mime { Id = 1362, Source = "iana", Value = "application/xml-external-parsed-entity" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1363, Source = "iana", Value = "application/xml-patch+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1364, Source = "iana", Value = "application/xmpp+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1365, Source = "iana", Value = "application/xop+xml" , Compressible = true, CharSet = "", Extensions = "xop" }
                , new Mime { Id = 1366, Source = "apache", Value = "application/xproc+xml" , Compressible = false, CharSet = "", Extensions = "xpl" }
                , new Mime { Id = 1367, Source = "iana", Value = "application/xslt+xml" , Compressible = false, CharSet = "", Extensions = "xslt" }
                , new Mime { Id = 1368, Source = "apache", Value = "application/xspf+xml" , Compressible = false, CharSet = "", Extensions = "xspf" }
                , new Mime { Id = 1369, Source = "iana", Value = "application/xv+xml" , Compressible = false, CharSet = "", Extensions = "mxml, xhvml, xvml, xvm" }
                , new Mime { Id = 1370, Source = "iana", Value = "application/yang" , Compressible = false, CharSet = "", Extensions = "yang" }
                , new Mime { Id = 1371, Source = "iana", Value = "application/yin+xml" , Compressible = false, CharSet = "", Extensions = "yin" }
                , new Mime { Id = 1372, Source = "iana", Value = "application/zip" , Compressible = false, CharSet = "", Extensions = "zip" }
                , new Mime { Id = 1373, Source = "iana", Value = "application/zlib" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1374, Source = "iana", Value = "audio/1d-interleaved-parityfec" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1375, Source = "iana", Value = "audio/32kadpcm" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1376, Source = "iana", Value = "audio/3gpp" , Compressible = false, CharSet = "", Extensions = "3gpp" }
                , new Mime { Id = 1377, Source = "iana", Value = "audio/3gpp2" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1378, Source = "iana", Value = "audio/ac3" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1379, Source = "apache", Value = "audio/adpcm" , Compressible = false, CharSet = "", Extensions = "adp" }
                , new Mime { Id = 1380, Source = "iana", Value = "audio/amr" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1381, Source = "iana", Value = "audio/amr-wb" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1382, Source = "iana", Value = "audio/amr-wb+" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1383, Source = "iana", Value = "audio/aptx" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1384, Source = "iana", Value = "audio/asc" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1385, Source = "iana", Value = "audio/atrac-advanced-lossless" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1386, Source = "iana", Value = "audio/atrac-x" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1387, Source = "iana", Value = "audio/atrac3" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1388, Source = "iana", Value = "audio/basic" , Compressible = false, CharSet = "", Extensions = "au, snd" }
                , new Mime { Id = 1389, Source = "iana", Value = "audio/bv16" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1390, Source = "iana", Value = "audio/bv32" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1391, Source = "iana", Value = "audio/clearmode" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1392, Source = "iana", Value = "audio/cn" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1393, Source = "iana", Value = "audio/dat12" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1394, Source = "iana", Value = "audio/dls" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1395, Source = "iana", Value = "audio/dsr-es201108" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1396, Source = "iana", Value = "audio/dsr-es202050" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1397, Source = "iana", Value = "audio/dsr-es202211" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1398, Source = "iana", Value = "audio/dsr-es202212" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1399, Source = "iana", Value = "audio/dv" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1400, Source = "iana", Value = "audio/dvi4" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1401, Source = "iana", Value = "audio/eac3" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1402, Source = "iana", Value = "audio/encaprtp" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1403, Source = "iana", Value = "audio/evrc" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1404, Source = "iana", Value = "audio/evrc-qcp" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1405, Source = "iana", Value = "audio/evrc0" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1406, Source = "iana", Value = "audio/evrc1" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1407, Source = "iana", Value = "audio/evrcb" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1408, Source = "iana", Value = "audio/evrcb0" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1409, Source = "iana", Value = "audio/evrcb1" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1410, Source = "iana", Value = "audio/evrcnw" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1411, Source = "iana", Value = "audio/evrcnw0" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1412, Source = "iana", Value = "audio/evrcnw1" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1413, Source = "iana", Value = "audio/evrcwb" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1414, Source = "iana", Value = "audio/evrcwb0" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1415, Source = "iana", Value = "audio/evrcwb1" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1416, Source = "iana", Value = "audio/evs" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1417, Source = "iana", Value = "audio/fwdred" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1418, Source = "iana", Value = "audio/g711-0" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1419, Source = "iana", Value = "audio/g719" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1420, Source = "iana", Value = "audio/g722" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1421, Source = "iana", Value = "audio/g7221" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1422, Source = "iana", Value = "audio/g723" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1423, Source = "iana", Value = "audio/g726-16" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1424, Source = "iana", Value = "audio/g726-24" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1425, Source = "iana", Value = "audio/g726-32" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1426, Source = "iana", Value = "audio/g726-40" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1427, Source = "iana", Value = "audio/g728" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1428, Source = "iana", Value = "audio/g729" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1429, Source = "iana", Value = "audio/g7291" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1430, Source = "iana", Value = "audio/g729d" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1431, Source = "iana", Value = "audio/g729e" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1432, Source = "iana", Value = "audio/gsm" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1433, Source = "iana", Value = "audio/gsm-efr" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1434, Source = "iana", Value = "audio/gsm-hr-08" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1435, Source = "iana", Value = "audio/ilbc" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1436, Source = "iana", Value = "audio/ip-mr_v2.5" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1437, Source = "apache", Value = "audio/isac" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1438, Source = "iana", Value = "audio/l16" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1439, Source = "iana", Value = "audio/l20" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1440, Source = "iana", Value = "audio/l24" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1441, Source = "iana", Value = "audio/l8" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1442, Source = "iana", Value = "audio/lpc" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1443, Source = "apache", Value = "audio/midi" , Compressible = false, CharSet = "", Extensions = "mid, midi, kar, rmi" }
                , new Mime { Id = 1444, Source = "iana", Value = "audio/mobile-xmf" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1445, Source = "iana", Value = "audio/mp4" , Compressible = false, CharSet = "", Extensions = "m4a, mp4a" }
                , new Mime { Id = 1446, Source = "iana", Value = "audio/mp4a-latm" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1447, Source = "iana", Value = "audio/mpa" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1448, Source = "iana", Value = "audio/mpa-robust" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1449, Source = "iana", Value = "audio/mpeg" , Compressible = false, CharSet = "", Extensions = "mpga, mp2, mp2a, mp3, m2a, m3a" }
                , new Mime { Id = 1450, Source = "iana", Value = "audio/mpeg4-generic" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1451, Source = "apache", Value = "audio/musepack" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1452, Source = "iana", Value = "audio/ogg" , Compressible = false, CharSet = "", Extensions = "oga, ogg, spx" }
                , new Mime { Id = 1453, Source = "iana", Value = "audio/opus" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1454, Source = "iana", Value = "audio/parityfec" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1455, Source = "iana", Value = "audio/pcma" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1456, Source = "iana", Value = "audio/pcma-wb" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1457, Source = "iana", Value = "audio/pcmu" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1458, Source = "iana", Value = "audio/pcmu-wb" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1459, Source = "iana", Value = "audio/prs.sid" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1460, Source = "iana", Value = "audio/qcelp" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1461, Source = "iana", Value = "audio/raptorfec" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1462, Source = "iana", Value = "audio/red" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1463, Source = "iana", Value = "audio/rtp-enc-aescm128" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1464, Source = "iana", Value = "audio/rtp-midi" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1465, Source = "iana", Value = "audio/rtploopback" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1466, Source = "iana", Value = "audio/rtx" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1467, Source = "apache", Value = "audio/s3m" , Compressible = false, CharSet = "", Extensions = "s3m" }
                , new Mime { Id = 1468, Source = "apache", Value = "audio/silk" , Compressible = false, CharSet = "", Extensions = "sil" }
                , new Mime { Id = 1469, Source = "iana", Value = "audio/smv" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1470, Source = "iana", Value = "audio/smv-qcp" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1471, Source = "iana", Value = "audio/smv0" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1472, Source = "iana", Value = "audio/sp-midi" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1473, Source = "iana", Value = "audio/speex" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1474, Source = "iana", Value = "audio/t140c" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1475, Source = "iana", Value = "audio/t38" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1476, Source = "iana", Value = "audio/telephone-event" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1477, Source = "iana", Value = "audio/tone" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1478, Source = "iana", Value = "audio/uemclip" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1479, Source = "iana", Value = "audio/ulpfec" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1480, Source = "iana", Value = "audio/vdvi" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1481, Source = "iana", Value = "audio/vmr-wb" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1482, Source = "iana", Value = "audio/vnd.3gpp.iufp" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1483, Source = "iana", Value = "audio/vnd.4sb" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1484, Source = "iana", Value = "audio/vnd.audiokoz" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1485, Source = "iana", Value = "audio/vnd.celp" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1486, Source = "iana", Value = "audio/vnd.cisco.nse" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1487, Source = "iana", Value = "audio/vnd.cmles.radio-events" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1488, Source = "iana", Value = "audio/vnd.cns.anp1" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1489, Source = "iana", Value = "audio/vnd.cns.inf1" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1490, Source = "iana", Value = "audio/vnd.dece.audio" , Compressible = false, CharSet = "", Extensions = "uva, uvva" }
                , new Mime { Id = 1491, Source = "iana", Value = "audio/vnd.digital-winds" , Compressible = false, CharSet = "", Extensions = "eol" }
                , new Mime { Id = 1492, Source = "iana", Value = "audio/vnd.dlna.adts" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1493, Source = "iana", Value = "audio/vnd.dolby.heaac.1" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1494, Source = "iana", Value = "audio/vnd.dolby.heaac.2" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1495, Source = "iana", Value = "audio/vnd.dolby.mlp" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1496, Source = "iana", Value = "audio/vnd.dolby.mps" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1497, Source = "iana", Value = "audio/vnd.dolby.pl2" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1498, Source = "iana", Value = "audio/vnd.dolby.pl2x" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1499, Source = "iana", Value = "audio/vnd.dolby.pl2z" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1500, Source = "iana", Value = "audio/vnd.dolby.pulse.1" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1501, Source = "iana", Value = "audio/vnd.dra" , Compressible = false, CharSet = "", Extensions = "dra" }
                , new Mime { Id = 1502, Source = "iana", Value = "audio/vnd.dts" , Compressible = false, CharSet = "", Extensions = "dts" }
                , new Mime { Id = 1503, Source = "iana", Value = "audio/vnd.dts.hd" , Compressible = false, CharSet = "", Extensions = "dtshd" }
                , new Mime { Id = 1504, Source = "iana", Value = "audio/vnd.dvb.file" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1505, Source = "iana", Value = "audio/vnd.everad.plj" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1506, Source = "iana", Value = "audio/vnd.hns.audio" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1507, Source = "iana", Value = "audio/vnd.lucent.voice" , Compressible = false, CharSet = "", Extensions = "lvp" }
                , new Mime { Id = 1508, Source = "iana", Value = "audio/vnd.ms-playready.media.pya" , Compressible = false, CharSet = "", Extensions = "pya" }
                , new Mime { Id = 1509, Source = "iana", Value = "audio/vnd.nokia.mobile-xmf" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1510, Source = "iana", Value = "audio/vnd.nortel.vbk" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1511, Source = "iana", Value = "audio/vnd.nuera.ecelp4800" , Compressible = false, CharSet = "", Extensions = "ecelp4800" }
                , new Mime { Id = 1512, Source = "iana", Value = "audio/vnd.nuera.ecelp7470" , Compressible = false, CharSet = "", Extensions = "ecelp7470" }
                , new Mime { Id = 1513, Source = "iana", Value = "audio/vnd.nuera.ecelp9600" , Compressible = false, CharSet = "", Extensions = "ecelp9600" }
                , new Mime { Id = 1514, Source = "iana", Value = "audio/vnd.octel.sbc" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1515, Source = "iana", Value = "audio/vnd.qcelp" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1516, Source = "iana", Value = "audio/vnd.rhetorex.32kadpcm" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1517, Source = "iana", Value = "audio/vnd.rip" , Compressible = false, CharSet = "", Extensions = "rip" }
                , new Mime { Id = 1518, Source = "", Value = "audio/vnd.rn-realaudio" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1519, Source = "iana", Value = "audio/vnd.sealedmedia.softseal.mpeg" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1520, Source = "iana", Value = "audio/vnd.vmx.cvsd" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1521, Source = "", Value = "audio/vnd.wave" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1522, Source = "iana", Value = "audio/vorbis" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1523, Source = "iana", Value = "audio/vorbis-config" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1524, Source = "", Value = "audio/wav" , Compressible = false, CharSet = "", Extensions = "wav" }
                , new Mime { Id = 1525, Source = "", Value = "audio/wave" , Compressible = false, CharSet = "", Extensions = "wav" }
                , new Mime { Id = 1526, Source = "apache", Value = "audio/webm" , Compressible = false, CharSet = "", Extensions = "weba" }
                , new Mime { Id = 1527, Source = "apache", Value = "audio/x-aac" , Compressible = false, CharSet = "", Extensions = "aac" }
                , new Mime { Id = 1528, Source = "apache", Value = "audio/x-aiff" , Compressible = false, CharSet = "", Extensions = "aif, aiff, aifc" }
                , new Mime { Id = 1529, Source = "apache", Value = "audio/x-caf" , Compressible = false, CharSet = "", Extensions = "caf" }
                , new Mime { Id = 1530, Source = "apache", Value = "audio/x-flac" , Compressible = false, CharSet = "", Extensions = "flac" }
                , new Mime { Id = 1531, Source = "nginx", Value = "audio/x-m4a" , Compressible = false, CharSet = "", Extensions = "m4a" }
                , new Mime { Id = 1532, Source = "apache", Value = "audio/x-matroska" , Compressible = false, CharSet = "", Extensions = "mka" }
                , new Mime { Id = 1533, Source = "apache", Value = "audio/x-mpegurl" , Compressible = false, CharSet = "", Extensions = "m3u" }
                , new Mime { Id = 1534, Source = "apache", Value = "audio/x-ms-wax" , Compressible = false, CharSet = "", Extensions = "wax" }
                , new Mime { Id = 1535, Source = "apache", Value = "audio/x-ms-wma" , Compressible = false, CharSet = "", Extensions = "wma" }
                , new Mime { Id = 1536, Source = "apache", Value = "audio/x-pn-realaudio" , Compressible = false, CharSet = "", Extensions = "ram, ra" }
                , new Mime { Id = 1537, Source = "apache", Value = "audio/x-pn-realaudio-plugin" , Compressible = false, CharSet = "", Extensions = "rmp" }
                , new Mime { Id = 1538, Source = "nginx", Value = "audio/x-realaudio" , Compressible = false, CharSet = "", Extensions = "ra" }
                , new Mime { Id = 1539, Source = "apache", Value = "audio/x-tta" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1540, Source = "apache", Value = "audio/x-wav" , Compressible = false, CharSet = "", Extensions = "wav" }
                , new Mime { Id = 1541, Source = "apache", Value = "audio/xm" , Compressible = false, CharSet = "", Extensions = "xm" }
                , new Mime { Id = 1542, Source = "apache", Value = "chemical/x-cdx" , Compressible = false, CharSet = "", Extensions = "cdx" }
                , new Mime { Id = 1543, Source = "apache", Value = "chemical/x-cif" , Compressible = false, CharSet = "", Extensions = "cif" }
                , new Mime { Id = 1544, Source = "apache", Value = "chemical/x-cmdf" , Compressible = false, CharSet = "", Extensions = "cmdf" }
                , new Mime { Id = 1545, Source = "apache", Value = "chemical/x-cml" , Compressible = false, CharSet = "", Extensions = "cml" }
                , new Mime { Id = 1546, Source = "apache", Value = "chemical/x-csml" , Compressible = false, CharSet = "", Extensions = "csml" }
                , new Mime { Id = 1547, Source = "apache", Value = "chemical/x-pdb" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1548, Source = "apache", Value = "chemical/x-xyz" , Compressible = false, CharSet = "", Extensions = "xyz" }
                , new Mime { Id = 1549, Source = "", Value = "font/opentype" , Compressible = true, CharSet = "", Extensions = "otf" }
                , new Mime { Id = 1550, Source = "apache", Value = "image/bmp" , Compressible = true, CharSet = "", Extensions = "bmp" }
                , new Mime { Id = 1551, Source = "iana", Value = "image/cgm" , Compressible = false, CharSet = "", Extensions = "cgm" }
                , new Mime { Id = 1552, Source = "iana", Value = "image/fits" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1553, Source = "iana", Value = "image/g3fax" , Compressible = false, CharSet = "", Extensions = "g3" }
                , new Mime { Id = 1554, Source = "iana", Value = "image/gif" , Compressible = false, CharSet = "", Extensions = "gif" }
                , new Mime { Id = 1555, Source = "iana", Value = "image/ief" , Compressible = false, CharSet = "", Extensions = "ief" }
                , new Mime { Id = 1556, Source = "iana", Value = "image/jp2" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1557, Source = "iana", Value = "image/jpeg" , Compressible = false, CharSet = "", Extensions = "jpeg, jpg, jpe" }
                , new Mime { Id = 1558, Source = "iana", Value = "image/jpm" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1559, Source = "iana", Value = "image/jpx" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1560, Source = "iana", Value = "image/ktx" , Compressible = false, CharSet = "", Extensions = "ktx" }
                , new Mime { Id = 1561, Source = "iana", Value = "image/naplps" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1562, Source = "", Value = "image/pjpeg" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1563, Source = "iana", Value = "image/png" , Compressible = false, CharSet = "", Extensions = "png" }
                , new Mime { Id = 1564, Source = "iana", Value = "image/prs.btif" , Compressible = false, CharSet = "", Extensions = "btif" }
                , new Mime { Id = 1565, Source = "iana", Value = "image/prs.pti" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1566, Source = "iana", Value = "image/pwg-raster" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1567, Source = "apache", Value = "image/sgi" , Compressible = false, CharSet = "", Extensions = "sgi" }
                , new Mime { Id = 1568, Source = "iana", Value = "image/svg+xml" , Compressible = true, CharSet = "", Extensions = "svg, svgz" }
                , new Mime { Id = 1569, Source = "iana", Value = "image/t38" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1570, Source = "iana", Value = "image/tiff" , Compressible = false, CharSet = "", Extensions = "tiff, tif" }
                , new Mime { Id = 1571, Source = "iana", Value = "image/tiff-fx" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1572, Source = "iana", Value = "image/vnd.adobe.photoshop" , Compressible = true, CharSet = "", Extensions = "psd" }
                , new Mime { Id = 1573, Source = "iana", Value = "image/vnd.airzip.accelerator.azv" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1574, Source = "iana", Value = "image/vnd.cns.inf2" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1575, Source = "iana", Value = "image/vnd.dece.graphic" , Compressible = false, CharSet = "", Extensions = "uvi, uvvi, uvg, uvvg" }
                , new Mime { Id = 1576, Source = "iana", Value = "image/vnd.djvu" , Compressible = false, CharSet = "", Extensions = "djvu, djv" }
                , new Mime { Id = 1577, Source = "iana", Value = "image/vnd.dvb.subtitle" , Compressible = false, CharSet = "", Extensions = "sub" }
                , new Mime { Id = 1578, Source = "iana", Value = "image/vnd.dwg" , Compressible = false, CharSet = "", Extensions = "dwg" }
                , new Mime { Id = 1579, Source = "iana", Value = "image/vnd.dxf" , Compressible = false, CharSet = "", Extensions = "dxf" }
                , new Mime { Id = 1580, Source = "iana", Value = "image/vnd.fastbidsheet" , Compressible = false, CharSet = "", Extensions = "fbs" }
                , new Mime { Id = 1581, Source = "iana", Value = "image/vnd.fpx" , Compressible = false, CharSet = "", Extensions = "fpx" }
                , new Mime { Id = 1582, Source = "iana", Value = "image/vnd.fst" , Compressible = false, CharSet = "", Extensions = "fst" }
                , new Mime { Id = 1583, Source = "iana", Value = "image/vnd.fujixerox.edmics-mmr" , Compressible = false, CharSet = "", Extensions = "mmr" }
                , new Mime { Id = 1584, Source = "iana", Value = "image/vnd.fujixerox.edmics-rlc" , Compressible = false, CharSet = "", Extensions = "rlc" }
                , new Mime { Id = 1585, Source = "iana", Value = "image/vnd.globalgraphics.pgb" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1586, Source = "iana", Value = "image/vnd.microsoft.icon" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1587, Source = "iana", Value = "image/vnd.mix" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1588, Source = "iana", Value = "image/vnd.mozilla.apng" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1589, Source = "iana", Value = "image/vnd.ms-modi" , Compressible = false, CharSet = "", Extensions = "mdi" }
                , new Mime { Id = 1590, Source = "apache", Value = "image/vnd.ms-photo" , Compressible = false, CharSet = "", Extensions = "wdp" }
                , new Mime { Id = 1591, Source = "iana", Value = "image/vnd.net-fpx" , Compressible = false, CharSet = "", Extensions = "npx" }
                , new Mime { Id = 1592, Source = "iana", Value = "image/vnd.radiance" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1593, Source = "iana", Value = "image/vnd.sealed.png" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1594, Source = "iana", Value = "image/vnd.sealedmedia.softseal.gif" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1595, Source = "iana", Value = "image/vnd.sealedmedia.softseal.jpg" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1596, Source = "iana", Value = "image/vnd.svf" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1597, Source = "iana", Value = "image/vnd.tencent.tap" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1598, Source = "iana", Value = "image/vnd.valve.source.texture" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1599, Source = "iana", Value = "image/vnd.wap.wbmp" , Compressible = false, CharSet = "", Extensions = "wbmp" }
                , new Mime { Id = 1600, Source = "iana", Value = "image/vnd.xiff" , Compressible = false, CharSet = "", Extensions = "xif" }
                , new Mime { Id = 1601, Source = "iana", Value = "image/vnd.zbrush.pcx" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1602, Source = "apache", Value = "image/webp" , Compressible = false, CharSet = "", Extensions = "webp" }
                , new Mime { Id = 1603, Source = "apache", Value = "image/x-3ds" , Compressible = false, CharSet = "", Extensions = "3ds" }
                , new Mime { Id = 1604, Source = "apache", Value = "image/x-cmu-raster" , Compressible = false, CharSet = "", Extensions = "ras" }
                , new Mime { Id = 1605, Source = "apache", Value = "image/x-cmx" , Compressible = false, CharSet = "", Extensions = "cmx" }
                , new Mime { Id = 1606, Source = "apache", Value = "image/x-freehand" , Compressible = false, CharSet = "", Extensions = "fh, fhc, fh4, fh5, fh7" }
                , new Mime { Id = 1607, Source = "apache", Value = "image/x-icon" , Compressible = true, CharSet = "", Extensions = "ico" }
                , new Mime { Id = 1608, Source = "nginx", Value = "image/x-jng" , Compressible = false, CharSet = "", Extensions = "jng" }
                , new Mime { Id = 1609, Source = "apache", Value = "image/x-mrsid-image" , Compressible = false, CharSet = "", Extensions = "sid" }
                , new Mime { Id = 1610, Source = "nginx", Value = "image/x-ms-bmp" , Compressible = true, CharSet = "", Extensions = "bmp" }
                , new Mime { Id = 1611, Source = "apache", Value = "image/x-pcx" , Compressible = false, CharSet = "", Extensions = "pcx" }
                , new Mime { Id = 1612, Source = "apache", Value = "image/x-pict" , Compressible = false, CharSet = "", Extensions = "pic, pct" }
                , new Mime { Id = 1613, Source = "apache", Value = "image/x-portable-anymap" , Compressible = false, CharSet = "", Extensions = "pnm" }
                , new Mime { Id = 1614, Source = "apache", Value = "image/x-portable-bitmap" , Compressible = false, CharSet = "", Extensions = "pbm" }
                , new Mime { Id = 1615, Source = "apache", Value = "image/x-portable-graymap" , Compressible = false, CharSet = "", Extensions = "pgm" }
                , new Mime { Id = 1616, Source = "apache", Value = "image/x-portable-pixmap" , Compressible = false, CharSet = "", Extensions = "ppm" }
                , new Mime { Id = 1617, Source = "apache", Value = "image/x-rgb" , Compressible = false, CharSet = "", Extensions = "rgb" }
                , new Mime { Id = 1618, Source = "apache", Value = "image/x-tga" , Compressible = false, CharSet = "", Extensions = "tga" }
                , new Mime { Id = 1619, Source = "apache", Value = "image/x-xbitmap" , Compressible = false, CharSet = "", Extensions = "xbm" }
                , new Mime { Id = 1620, Source = "", Value = "image/x-xcf" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1621, Source = "apache", Value = "image/x-xpixmap" , Compressible = false, CharSet = "", Extensions = "xpm" }
                , new Mime { Id = 1622, Source = "apache", Value = "image/x-xwindowdump" , Compressible = false, CharSet = "", Extensions = "xwd" }
                , new Mime { Id = 1623, Source = "iana", Value = "message/cpim" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1624, Source = "iana", Value = "message/delivery-status" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1625, Source = "iana", Value = "message/disposition-notification" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1626, Source = "iana", Value = "message/external-body" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1627, Source = "iana", Value = "message/feedback-report" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1628, Source = "iana", Value = "message/global" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1629, Source = "iana", Value = "message/global-delivery-status" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1630, Source = "iana", Value = "message/global-disposition-notification" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1631, Source = "iana", Value = "message/global-headers" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1632, Source = "iana", Value = "message/http" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1633, Source = "iana", Value = "message/imdn+xml" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 1634, Source = "iana", Value = "message/news" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1635, Source = "iana", Value = "message/partial" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1636, Source = "iana", Value = "message/rfc822" , Compressible = true, CharSet = "", Extensions = "eml, mime" }
                , new Mime { Id = 1637, Source = "iana", Value = "message/s-http" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1638, Source = "iana", Value = "message/sip" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1639, Source = "iana", Value = "message/sipfrag" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1640, Source = "iana", Value = "message/tracking-status" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1641, Source = "iana", Value = "message/vnd.si.simp" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1642, Source = "iana", Value = "message/vnd.wfa.wsc" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1643, Source = "iana", Value = "model/iges" , Compressible = false, CharSet = "", Extensions = "igs, iges" }
                , new Mime { Id = 1644, Source = "iana", Value = "model/mesh" , Compressible = false, CharSet = "", Extensions = "msh, mesh, silo" }
                , new Mime { Id = 1645, Source = "iana", Value = "model/vnd.collada+xml" , Compressible = false, CharSet = "", Extensions = "dae" }
                , new Mime { Id = 1646, Source = "iana", Value = "model/vnd.dwf" , Compressible = false, CharSet = "", Extensions = "dwf" }
                , new Mime { Id = 1647, Source = "iana", Value = "model/vnd.flatland.3dml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1648, Source = "iana", Value = "model/vnd.gdl" , Compressible = false, CharSet = "", Extensions = "gdl" }
                , new Mime { Id = 1649, Source = "apache", Value = "model/vnd.gs-gdl" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1650, Source = "iana", Value = "model/vnd.gs.gdl" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1651, Source = "iana", Value = "model/vnd.gtw" , Compressible = false, CharSet = "", Extensions = "gtw" }
                , new Mime { Id = 1652, Source = "iana", Value = "model/vnd.moml+xml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1653, Source = "iana", Value = "model/vnd.mts" , Compressible = false, CharSet = "", Extensions = "mts" }
                , new Mime { Id = 1654, Source = "iana", Value = "model/vnd.opengex" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1655, Source = "iana", Value = "model/vnd.parasolid.transmit.binary" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1656, Source = "iana", Value = "model/vnd.parasolid.transmit.text" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1657, Source = "iana", Value = "model/vnd.rosette.annotated-data-model" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1658, Source = "iana", Value = "model/vnd.valve.source.compiled-map" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1659, Source = "iana", Value = "model/vnd.vtu" , Compressible = false, CharSet = "", Extensions = "vtu" }
                , new Mime { Id = 1660, Source = "iana", Value = "model/vrml" , Compressible = false, CharSet = "", Extensions = "wrl, vrml" }
                , new Mime { Id = 1661, Source = "apache", Value = "model/x3d+binary" , Compressible = false, CharSet = "", Extensions = "x3db, x3dbz" }
                , new Mime { Id = 1662, Source = "iana", Value = "model/x3d+fastinfoset" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1663, Source = "apache", Value = "model/x3d+vrml" , Compressible = false, CharSet = "", Extensions = "x3dv, x3dvz" }
                , new Mime { Id = 1664, Source = "iana", Value = "model/x3d+xml" , Compressible = true, CharSet = "", Extensions = "x3d, x3dz" }
                , new Mime { Id = 1665, Source = "iana", Value = "model/x3d-vrml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1666, Source = "iana", Value = "multipart/alternative" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1667, Source = "iana", Value = "multipart/appledouble" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1668, Source = "iana", Value = "multipart/byteranges" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1669, Source = "iana", Value = "multipart/digest" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1670, Source = "iana", Value = "multipart/encrypted" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1671, Source = "iana", Value = "multipart/form-data" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1672, Source = "iana", Value = "multipart/header-set" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1673, Source = "iana", Value = "multipart/mixed" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1674, Source = "iana", Value = "multipart/parallel" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1675, Source = "iana", Value = "multipart/related" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1676, Source = "iana", Value = "multipart/report" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1677, Source = "iana", Value = "multipart/signed" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1678, Source = "iana", Value = "multipart/voice-message" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1679, Source = "iana", Value = "multipart/x-mixed-replace" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1680, Source = "iana", Value = "text/1d-interleaved-parityfec" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1681, Source = "iana", Value = "text/cache-manifest" , Compressible = true, CharSet = "", Extensions = "appcache, manifest" }
                , new Mime { Id = 1682, Source = "iana", Value = "text/calendar" , Compressible = false, CharSet = "", Extensions = "ics, ifb" }
                , new Mime { Id = 1683, Source = "", Value = "text/calender" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 1684, Source = "", Value = "text/cmd" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 1685, Source = "", Value = "text/coffeescript" , Compressible = false, CharSet = "", Extensions = "coffee, litcoffee" }
                , new Mime { Id = 1686, Source = "iana", Value = "text/css" , Compressible = true, CharSet = "", Extensions = "css" }
                , new Mime { Id = 1687, Source = "iana", Value = "text/csv" , Compressible = true, CharSet = "", Extensions = "csv" }
                , new Mime { Id = 1688, Source = "iana", Value = "text/csv-schema" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1689, Source = "iana", Value = "text/directory" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1690, Source = "iana", Value = "text/dns" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1691, Source = "iana", Value = "text/ecmascript" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1692, Source = "iana", Value = "text/encaprtp" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1693, Source = "iana", Value = "text/enriched" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1694, Source = "iana", Value = "text/fwdred" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1695, Source = "iana", Value = "text/grammar-ref-list" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1696, Source = "", Value = "text/json" , Compressible = false, CharSet = "", Extensions = "json" }
                , new Mime { Id = 1697, Source = "iana", Value = "text/html" , Compressible = true, CharSet = "", Extensions = "html, htm, shtml" }
                , new Mime { Id = 1698, Source = "", Value = "text/jade" , Compressible = false, CharSet = "", Extensions = "jade" }
                , new Mime { Id = 1699, Source = "iana", Value = "text/javascript" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 1700, Source = "iana", Value = "text/jcr-cnd" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1701, Source = "", Value = "text/jsx" , Compressible = true, CharSet = "", Extensions = "jsx" }
                , new Mime { Id = 1702, Source = "", Value = "text/less" , Compressible = false, CharSet = "", Extensions = "less" }
                , new Mime { Id = 1703, Source = "iana", Value = "text/markdown" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1704, Source = "nginx", Value = "text/mathml" , Compressible = false, CharSet = "", Extensions = "mml" }
                , new Mime { Id = 1705, Source = "iana", Value = "text/mizar" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1706, Source = "iana", Value = "text/n3" , Compressible = true, CharSet = "", Extensions = "n3" }
                , new Mime { Id = 1707, Source = "iana", Value = "text/parameters" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1708, Source = "iana", Value = "text/parityfec" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1709, Source = "iana", Value = "text/plain" , Compressible = true, CharSet = "", Extensions = "txt, text, conf, def, list, log, in, ini" }
                , new Mime { Id = 1710, Source = "iana", Value = "text/provenance-notation" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1711, Source = "iana", Value = "text/prs.fallenstein.rst" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1712, Source = "iana", Value = "text/prs.lines.tag" , Compressible = false, CharSet = "", Extensions = "dsc" }
                , new Mime { Id = 1713, Source = "iana", Value = "text/prs.prop.logic" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1714, Source = "iana", Value = "text/raptorfec" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1715, Source = "iana", Value = "text/red" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1716, Source = "iana", Value = "text/rfc822-headers" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1717, Source = "iana", Value = "text/richtext" , Compressible = true, CharSet = "", Extensions = "rtx" }
                , new Mime { Id = 1718, Source = "iana", Value = "text/rtf" , Compressible = true, CharSet = "", Extensions = "rtf" }
                , new Mime { Id = 1719, Source = "iana", Value = "text/rtp-enc-aescm128" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1720, Source = "iana", Value = "text/rtploopback" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1721, Source = "iana", Value = "text/rtx" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1722, Source = "iana", Value = "text/sgml" , Compressible = false, CharSet = "", Extensions = "sgml, sgm" }
                , new Mime { Id = 1723, Source = "", Value = "text/slim" , Compressible = false, CharSet = "", Extensions = "slim, slm" }
                , new Mime { Id = 1724, Source = "", Value = "text/stylus" , Compressible = false, CharSet = "", Extensions = "stylus, styl" }
                , new Mime { Id = 1725, Source = "iana", Value = "text/t140" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1726, Source = "iana", Value = "text/tab-separated-values" , Compressible = true, CharSet = "", Extensions = "tsv" }
                , new Mime { Id = 1727, Source = "iana", Value = "text/troff" , Compressible = false, CharSet = "", Extensions = "t, tr, roff, man, me, ms" }
                , new Mime { Id = 1728, Source = "iana", Value = "text/turtle" , Compressible = false, CharSet = "", Extensions = "ttl" }
                , new Mime { Id = 1729, Source = "iana", Value = "text/ulpfec" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1730, Source = "iana", Value = "text/uri-list" , Compressible = true, CharSet = "", Extensions = "uri, uris, urls" }
                , new Mime { Id = 1731, Source = "iana", Value = "text/vcard" , Compressible = true, CharSet = "", Extensions = "vcard" }
                , new Mime { Id = 1732, Source = "iana", Value = "text/vnd.a" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1733, Source = "iana", Value = "text/vnd.abc" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1734, Source = "iana", Value = "text/vnd.curl" , Compressible = false, CharSet = "", Extensions = "curl" }
                , new Mime { Id = 1735, Source = "apache", Value = "text/vnd.curl.dcurl" , Compressible = false, CharSet = "", Extensions = "dcurl" }
                , new Mime { Id = 1736, Source = "apache", Value = "text/vnd.curl.mcurl" , Compressible = false, CharSet = "", Extensions = "mcurl" }
                , new Mime { Id = 1737, Source = "apache", Value = "text/vnd.curl.scurl" , Compressible = false, CharSet = "", Extensions = "scurl" }
                , new Mime { Id = 1738, Source = "iana", Value = "text/vnd.debian.copyright" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1739, Source = "iana", Value = "text/vnd.dmclientscript" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1740, Source = "iana", Value = "text/vnd.dvb.subtitle" , Compressible = false, CharSet = "", Extensions = "sub" }
                , new Mime { Id = 1741, Source = "iana", Value = "text/vnd.esmertec.theme-descriptor" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1742, Source = "iana", Value = "text/vnd.fly" , Compressible = false, CharSet = "", Extensions = "fly" }
                , new Mime { Id = 1743, Source = "iana", Value = "text/vnd.fmi.flexstor" , Compressible = false, CharSet = "", Extensions = "flx" }
                , new Mime { Id = 1744, Source = "iana", Value = "text/vnd.graphviz" , Compressible = false, CharSet = "", Extensions = "gv" }
                , new Mime { Id = 1745, Source = "iana", Value = "text/vnd.in3d.3dml" , Compressible = false, CharSet = "", Extensions = "3dml" }
                , new Mime { Id = 1746, Source = "iana", Value = "text/vnd.in3d.spot" , Compressible = false, CharSet = "", Extensions = "spot" }
                , new Mime { Id = 1747, Source = "iana", Value = "text/vnd.iptc.newsml" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1748, Source = "iana", Value = "text/vnd.iptc.nitf" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1749, Source = "iana", Value = "text/vnd.latex-z" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1750, Source = "iana", Value = "text/vnd.motorola.reflex" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1751, Source = "iana", Value = "text/vnd.ms-mediapackage" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1752, Source = "iana", Value = "text/vnd.net2phone.commcenter.command" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1753, Source = "iana", Value = "text/vnd.radisys.msml-basic-layout" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1754, Source = "iana", Value = "text/vnd.si.uricatalogue" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1755, Source = "iana", Value = "text/vnd.sun.j2me.app-descriptor" , Compressible = false, CharSet = "", Extensions = "jad" }
                , new Mime { Id = 1756, Source = "iana", Value = "text/vnd.trolltech.linguist" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1757, Source = "iana", Value = "text/vnd.wap.si" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1758, Source = "iana", Value = "text/vnd.wap.sl" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1759, Source = "iana", Value = "text/vnd.wap.wml" , Compressible = false, CharSet = "", Extensions = "wml" }
                , new Mime { Id = 1760, Source = "iana", Value = "text/vnd.wap.wmlscript" , Compressible = false, CharSet = "", Extensions = "wmls" }
                , new Mime { Id = 1761, Source = "", Value = "text/vtt" , Compressible = true, CharSet = "UTF-8", Extensions = "vtt" }
                , new Mime { Id = 1762, Source = "apache", Value = "text/x-asm" , Compressible = false, CharSet = "", Extensions = "s, asm" }
                , new Mime { Id = 1763, Source = "apache", Value = "text/x-c" , Compressible = false, CharSet = "", Extensions = "c, cc, cxx, cpp, h, hh, dic" }
                , new Mime { Id = 1764, Source = "nginx", Value = "text/x-component" , Compressible = false, CharSet = "", Extensions = "htc" }
                , new Mime { Id = 1765, Source = "apache", Value = "text/x-fortran" , Compressible = false, CharSet = "", Extensions = "f, for, f77, f90" }
                , new Mime { Id = 1766, Source = "", Value = "text/x-gwt-rpc" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 1767, Source = "", Value = "text/x-handlebars-template" , Compressible = false, CharSet = "", Extensions = "hbs" }
                , new Mime { Id = 1768, Source = "apache", Value = "text/x-java-source" , Compressible = false, CharSet = "", Extensions = "java" }
                , new Mime { Id = 1769, Source = "", Value = "text/x-jquery-tmpl" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 1770, Source = "", Value = "text/x-lua" , Compressible = false, CharSet = "", Extensions = "lua" }
                , new Mime { Id = 1771, Source = "", Value = "text/x-markdown" , Compressible = true, CharSet = "", Extensions = "markdown, md, mkd" }
                , new Mime { Id = 1772, Source = "apache", Value = "text/x-nfo" , Compressible = false, CharSet = "", Extensions = "nfo" }
                , new Mime { Id = 1773, Source = "apache", Value = "text/x-opml" , Compressible = false, CharSet = "", Extensions = "opml" }
                , new Mime { Id = 1774, Source = "apache", Value = "text/x-pascal" , Compressible = false, CharSet = "", Extensions = "p, pas" }
                , new Mime { Id = 1775, Source = "", Value = "text/x-processing" , Compressible = true, CharSet = "", Extensions = "pde" }
                , new Mime { Id = 1776, Source = "", Value = "text/x-sass" , Compressible = false, CharSet = "", Extensions = "sass" }
                , new Mime { Id = 1777, Source = "", Value = "text/x-scss" , Compressible = false, CharSet = "", Extensions = "scss" }
                , new Mime { Id = 1778, Source = "apache", Value = "text/x-setext" , Compressible = false, CharSet = "", Extensions = "etx" }
                , new Mime { Id = 1779, Source = "apache", Value = "text/x-sfv" , Compressible = false, CharSet = "", Extensions = "sfv" }
                , new Mime { Id = 1780, Source = "", Value = "text/x-suse-ymp" , Compressible = true, CharSet = "", Extensions = "ymp" }
                , new Mime { Id = 1781, Source = "apache", Value = "text/x-uuencode" , Compressible = false, CharSet = "", Extensions = "uu" }
                , new Mime { Id = 1782, Source = "apache", Value = "text/x-vcalendar" , Compressible = false, CharSet = "", Extensions = "vcs" }
                , new Mime { Id = 1783, Source = "apache", Value = "text/x-vcard" , Compressible = false, CharSet = "", Extensions = "vcf" }
                , new Mime { Id = 1784, Source = "iana", Value = "text/xml" , Compressible = true, CharSet = "", Extensions = "xml" }
                , new Mime { Id = 1785, Source = "iana", Value = "text/xml-external-parsed-entity" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1786, Source = "", Value = "text/yaml" , Compressible = false, CharSet = "", Extensions = "yaml, yml" }
                , new Mime { Id = 1787, Source = "apache", Value = "video/1d-interleaved-parityfec" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1788, Source = "apache", Value = "video/3gpp" , Compressible = false, CharSet = "", Extensions = "3gp, 3gpp" }
                , new Mime { Id = 1789, Source = "apache", Value = "video/3gpp-tt" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1790, Source = "apache", Value = "video/3gpp2" , Compressible = false, CharSet = "", Extensions = "3g2" }
                , new Mime { Id = 1791, Source = "apache", Value = "video/bmpeg" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1792, Source = "apache", Value = "video/bt656" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1793, Source = "apache", Value = "video/celb" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1794, Source = "apache", Value = "video/dv" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1795, Source = "apache", Value = "video/encaprtp" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1796, Source = "apache", Value = "video/h261" , Compressible = false, CharSet = "", Extensions = "h261" }
                , new Mime { Id = 1797, Source = "apache", Value = "video/h263" , Compressible = false, CharSet = "", Extensions = "h263" }
                , new Mime { Id = 1798, Source = "apache", Value = "video/h263-1998" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1799, Source = "apache", Value = "video/h263-2000" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1800, Source = "apache", Value = "video/h264" , Compressible = false, CharSet = "", Extensions = "h264" }
                , new Mime { Id = 1801, Source = "apache", Value = "video/h264-rcdo" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1802, Source = "apache", Value = "video/h264-svc" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1803, Source = "apache", Value = "video/h265" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1804, Source = "apache", Value = "video/iso.segment" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1805, Source = "apache", Value = "video/jpeg" , Compressible = false, CharSet = "", Extensions = "jpgv" }
                , new Mime { Id = 1806, Source = "apache", Value = "video/jpeg2000" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1807, Source = "apache", Value = "video/jpm" , Compressible = false, CharSet = "", Extensions = "jpm, jpgm" }
                , new Mime { Id = 1808, Source = "apache", Value = "video/mj2" , Compressible = false, CharSet = "", Extensions = "mj2, mjp2" }
                , new Mime { Id = 1809, Source = "apache", Value = "video/mp1s" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1810, Source = "apache", Value = "video/mp2p" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1811, Source = "apache", Value = "video/mp2t" , Compressible = false, CharSet = "", Extensions = "ts" }
                , new Mime { Id = 1812, Source = "apache", Value = "video/mp4" , Compressible = false, CharSet = "", Extensions = "mp4, mp4v, mpg4" }
                , new Mime { Id = 1813, Source = "apache", Value = "video/mp4v-es" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1814, Source = "apache", Value = "video/mpeg" , Compressible = false, CharSet = "", Extensions = "mpeg, mpg, mpe, m1v, m2v" }
                , new Mime { Id = 1815, Source = "apache", Value = "video/mpeg4-generic" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1816, Source = "apache", Value = "video/mpv" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1817, Source = "apache", Value = "video/nv" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1818, Source = "apache", Value = "video/ogg" , Compressible = false, CharSet = "", Extensions = "ogv" }
                , new Mime { Id = 1819, Source = "apache", Value = "video/parityfec" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1820, Source = "apache", Value = "video/pointer" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1821, Source = "apache", Value = "video/quicktime" , Compressible = false, CharSet = "", Extensions = "qt, mov" }
                , new Mime { Id = 1822, Source = "apache", Value = "video/raptorfec" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1823, Source = "apache", Value = "video/raw" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1824, Source = "apache", Value = "video/rtp-enc-aescm128" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1825, Source = "apache", Value = "video/rtploopback" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1826, Source = "apache", Value = "video/rtx" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1827, Source = "apache", Value = "video/smpte292m" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1828, Source = "apache", Value = "video/ulpfec" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1829, Source = "apache", Value = "video/vc1" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1830, Source = "apache", Value = "video/vnd.cctv" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1831, Source = "apache", Value = "video/vnd.dece.hd" , Compressible = false, CharSet = "", Extensions = "uvh, uvvh" }
                , new Mime { Id = 1832, Source = "apache", Value = "video/vnd.dece.mobile" , Compressible = false, CharSet = "", Extensions = "uvm, uvvm" }
                , new Mime { Id = 1833, Source = "apache", Value = "video/vnd.dece.mp4" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1834, Source = "apache", Value = "video/vnd.dece.pd" , Compressible = false, CharSet = "", Extensions = "uvp, uvvp" }
                , new Mime { Id = 1835, Source = "apache", Value = "video/vnd.dece.sd" , Compressible = false, CharSet = "", Extensions = "uvs, uvvs" }
                , new Mime { Id = 1836, Source = "apache", Value = "video/vnd.dece.video" , Compressible = false, CharSet = "", Extensions = "uvv, uvvv" }
                , new Mime { Id = 1837, Source = "apache", Value = "video/vnd.directv.mpeg" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1838, Source = "apache", Value = "video/vnd.directv.mpeg-tts" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1839, Source = "apache", Value = "video/vnd.dlna.mpeg-tts" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1840, Source = "apache", Value = "video/vnd.dvb.file" , Compressible = false, CharSet = "", Extensions = "dvb" }
                , new Mime { Id = 1841, Source = "apache", Value = "video/vnd.fvt" , Compressible = false, CharSet = "", Extensions = "fvt" }
                , new Mime { Id = 1842, Source = "apache", Value = "video/vnd.hns.video" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1843, Source = "apache", Value = "video/vnd.iptvforum.1dparityfec-1010" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1844, Source = "apache", Value = "video/vnd.iptvforum.1dparityfec-2005" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1845, Source = "apache", Value = "video/vnd.iptvforum.2dparityfec-1010" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1846, Source = "apache", Value = "video/vnd.iptvforum.2dparityfec-2005" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1847, Source = "apache", Value = "video/vnd.iptvforum.ttsavc" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1848, Source = "apache", Value = "video/vnd.iptvforum.ttsmpeg2" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1849, Source = "apache", Value = "video/vnd.motorola.video" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1850, Source = "apache", Value = "video/vnd.motorola.videop" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1851, Source = "apache", Value = "video/vnd.mpegurl" , Compressible = false, CharSet = "", Extensions = "mxu, m4u" }
                , new Mime { Id = 1852, Source = "apache", Value = "video/vnd.ms-playready.media.pyv" , Compressible = false, CharSet = "", Extensions = "pyv" }
                , new Mime { Id = 1853, Source = "apache", Value = "video/vnd.nokia.interleaved-multimedia" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1854, Source = "apache", Value = "video/vnd.nokia.videovoip" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1855, Source = "apache", Value = "video/vnd.objectvideo" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1856, Source = "apache", Value = "video/vnd.radgamettools.bink" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1857, Source = "apache", Value = "video/vnd.radgamettools.smacker" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1858, Source = "apache", Value = "video/vnd.sealed.mpeg1" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1859, Source = "apache", Value = "video/vnd.sealed.mpeg4" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1860, Source = "apache", Value = "video/vnd.sealed.swf" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1861, Source = "apache", Value = "video/vnd.sealedmedia.softseal.mov" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1862, Source = "apache", Value = "video/vnd.uvvu.mp4" , Compressible = false, CharSet = "", Extensions = "uvu, uvvu" }
                , new Mime { Id = 1863, Source = "apache", Value = "video/vnd.vivo" , Compressible = false, CharSet = "", Extensions = "viv" }
                , new Mime { Id = 1864, Source = "apache", Value = "video/vp8" , Compressible = false, CharSet = "", Extensions = "" }
                , new Mime { Id = 1865, Source = "apache", Value = "video/webm" , Compressible = false, CharSet = "", Extensions = "webm" }
                , new Mime { Id = 1866, Source = "apache", Value = "video/x-f4v" , Compressible = false, CharSet = "", Extensions = "f4v" }
                , new Mime { Id = 1867, Source = "apache", Value = "video/x-fli" , Compressible = false, CharSet = "", Extensions = "fli" }
                , new Mime { Id = 1868, Source = "apache", Value = "video/x-flv" , Compressible = false, CharSet = "", Extensions = "flv" }
                , new Mime { Id = 1869, Source = "apache", Value = "video/x-m4v" , Compressible = false, CharSet = "", Extensions = "m4v" }
                , new Mime { Id = 1870, Source = "apache", Value = "video/x-matroska" , Compressible = false, CharSet = "", Extensions = "mkv, mk3d, mks" }
                , new Mime { Id = 1871, Source = "apache", Value = "video/x-mng" , Compressible = false, CharSet = "", Extensions = "mng" }
                , new Mime { Id = 1872, Source = "apache", Value = "video/x-ms-asf" , Compressible = false, CharSet = "", Extensions = "asf, asx" }
                , new Mime { Id = 1873, Source = "apache", Value = "video/x-ms-vob" , Compressible = false, CharSet = "", Extensions = "vob" }
                , new Mime { Id = 1874, Source = "apache", Value = "video/x-ms-wm" , Compressible = false, CharSet = "", Extensions = "wm" }
                , new Mime { Id = 1875, Source = "apache", Value = "video/x-ms-wmv" , Compressible = false, CharSet = "", Extensions = "wmv" }
                , new Mime { Id = 1876, Source = "apache", Value = "video/x-ms-wmx" , Compressible = false, CharSet = "", Extensions = "wmx" }
                , new Mime { Id = 1877, Source = "apache", Value = "video/x-ms-wvx" , Compressible = false, CharSet = "", Extensions = "wvx" }
                , new Mime { Id = 1878, Source = "apache", Value = "video/x-msvideo" , Compressible = false, CharSet = "", Extensions = "avi" }
                , new Mime { Id = 1879, Source = "apache", Value = "video/x-sgi-movie" , Compressible = false, CharSet = "", Extensions = "movie" }
                , new Mime { Id = 1880, Source = "apache", Value = "video/x-smv" , Compressible = false, CharSet = "", Extensions = "smv" }
                , new Mime { Id = 1881, Source = "apache", Value = "x-conference/x-cooltalk" , Compressible = false, CharSet = "", Extensions = "ice" }
                , new Mime { Id = 1882, Source = "", Value = "x-shader/x-fragment" , Compressible = true, CharSet = "", Extensions = "" }
                , new Mime { Id = 1883, Source = "", Value = "x-shader/x-vertex" , Compressible = true, CharSet = "", Extensions = "" }
            };
        }
        private static MimeType[] _initMimeTypes()
        {
            return new MimeType[]{
                  new MimeType { Id = 352, MimeId = 695, Extension = "123", IsDefault = true }
                , new MimeType { Id = 965, MimeId = 1745, Extension = "3dml", IsDefault = true }
                , new MimeType { Id = 866, MimeId = 1603, Extension = "3ds", IsDefault = true }
                , new MimeType { Id = 1009, MimeId = 1790, Extension = "3g2", IsDefault = true }
                , new MimeType { Id = 1007, MimeId = 1788, Extension = "3gp", IsDefault = true }
                , new MimeType { Id = 1008, MimeId = 1788, Extension = "3gpp", IsDefault = true }
                , new MimeType { Id = 769, MimeId = 1376, Extension = "3gpp", IsDefault = false }
                , new MimeType { Id = 582, MimeId = 1216, Extension = "7z", IsDefault = true }
                , new MimeType { Id = 586, MimeId = 1221, Extension = "aab", IsDefault = true }
                , new MimeType { Id = 805, MimeId = 1527, Extension = "aac", IsDefault = true }
                , new MimeType { Id = 590, MimeId = 1222, Extension = "aam", IsDefault = true }
                , new MimeType { Id = 591, MimeId = 1223, Extension = "aas", IsDefault = true }
                , new MimeType { Id = 583, MimeId = 1217, Extension = "abw", IsDefault = true }
                , new MimeType { Id = 110, MimeId = 233, Extension = "ac", IsDefault = true }
                , new MimeType { Id = 175, MimeId = 379, Extension = "acc", IsDefault = true }
                , new MimeType { Id = 584, MimeId = 1218, Extension = "ace", IsDefault = true }
                , new MimeType { Id = 162, MimeId = 364, Extension = "acu", IsDefault = true }
                , new MimeType { Id = 163, MimeId = 365, Extension = "acutc", IsDefault = true }
                , new MimeType { Id = 770, MimeId = 1379, Extension = "adp", IsDefault = true }
                , new MimeType { Id = 186, MimeId = 398, Extension = "aep", IsDefault = true }
                , new MimeType { Id = 641, MimeId = 1264, Extension = "afm", IsDefault = true }
                , new MimeType { Id = 304, MimeId = 624, Extension = "afp", IsDefault = true }
                , new MimeType { Id = 171, MimeId = 375, Extension = "ahead", IsDefault = true }
                , new MimeType { Id = 116, MimeId = 240, Extension = "ai", IsDefault = true }
                , new MimeType { Id = 806, MimeId = 1528, Extension = "aif", IsDefault = true }
                , new MimeType { Id = 807, MimeId = 1528, Extension = "aifc", IsDefault = true }
                , new MimeType { Id = 808, MimeId = 1528, Extension = "aiff", IsDefault = true }
                , new MimeType { Id = 165, MimeId = 366, Extension = "air", IsDefault = true }
                , new MimeType { Id = 233, MimeId = 477, Extension = "ait", IsDefault = true }
                , new MimeType { Id = 176, MimeId = 380, Extension = "ami", IsDefault = true }
                , new MimeType { Id = 177, MimeId = 382, Extension = "apk", IsDefault = true }
                , new MimeType { Id = 911, MimeId = 1681, Extension = "appcache", IsDefault = true }
                , new MimeType { Id = 666, MimeId = 1288, Extension = "application", IsDefault = true }
                , new MimeType { Id = 353, MimeId = 696, Extension = "apr", IsDefault = true }
                , new MimeType { Id = 645, MimeId = 1266, Extension = "arc", IsDefault = true }
                , new MimeType { Id = 102, MimeId = 224, Extension = "asc", IsDefault = true }
                , new MimeType { Id = 1057, MimeId = 1872, Extension = "asf", IsDefault = true }
                , new MimeType { Id = 971, MimeId = 1762, Extension = "asm", IsDefault = true }
                , new MimeType { Id = 160, MimeId = 362, Extension = "aso", IsDefault = true }
                , new MimeType { Id = 1058, MimeId = 1872, Extension = "asx", IsDefault = true }
                , new MimeType { Id = 164, MimeId = 365, Extension = "atc", IsDefault = true }
                , new MimeType { Id = 3, MimeId = 22, Extension = "atom", IsDefault = true }
                , new MimeType { Id = 4, MimeId = 23, Extension = "atomcat", IsDefault = true }
                , new MimeType { Id = 5, MimeId = 26, Extension = "atomsvc", IsDefault = true }
                , new MimeType { Id = 180, MimeId = 386, Extension = "atx", IsDefault = true }
                , new MimeType { Id = 771, MimeId = 1388, Extension = "au", IsDefault = true }
                , new MimeType { Id = 1064, MimeId = 1878, Extension = "avi", IsDefault = true }
                , new MimeType { Id = 2, MimeId = 19, Extension = "aw", IsDefault = true }
                , new MimeType { Id = 172, MimeId = 376, Extension = "azf", IsDefault = true }
                , new MimeType { Id = 173, MimeId = 377, Extension = "azs", IsDefault = true }
                , new MimeType { Id = 174, MimeId = 378, Extension = "azw", IsDefault = true }
                , new MimeType { Id = 676, MimeId = 1298, Extension = "bat", IsDefault = true }
                , new MimeType { Id = 592, MimeId = 1224, Extension = "bcpio", IsDefault = true }
                , new MimeType { Id = 633, MimeId = 1252, Extension = "bdf", IsDefault = true }
                , new MimeType { Id = 533, MimeId = 1112, Extension = "bdm", IsDefault = true }
                , new MimeType { Id = 593, MimeId = 1225, Extension = "bdoc", IsDefault = false }
                , new MimeType { Id = 6, MimeId = 31, Extension = "bdoc", IsDefault = true }
                , new MimeType { Id = 483, MimeId = 1039, Extension = "bed", IsDefault = true }
                , new MimeType { Id = 264, MimeId = 563, Extension = "bh2", IsDefault = true }
                , new MimeType { Id = 68, MimeId = 209, Extension = "bin", IsDefault = true }
                , new MimeType { Id = 595, MimeId = 1227, Extension = "blb", IsDefault = true }
                , new MimeType { Id = 596, MimeId = 1227, Extension = "blorb", IsDefault = true }
                , new MimeType { Id = 188, MimeId = 408, Extension = "bmi", IsDefault = true }
                , new MimeType { Id = 877, MimeId = 1610, Extension = "bmp", IsDefault = false }
                , new MimeType { Id = 829, MimeId = 1550, Extension = "bmp", IsDefault = true }
                , new MimeType { Id = 253, MimeId = 555, Extension = "book", IsDefault = true }
                , new MimeType { Id = 473, MimeId = 1013, Extension = "box", IsDefault = true }
                , new MimeType { Id = 598, MimeId = 1229, Extension = "boz", IsDefault = true }
                , new MimeType { Id = 69, MimeId = 209, Extension = "bpk", IsDefault = true }
                , new MimeType { Id = 839, MimeId = 1564, Extension = "btif", IsDefault = true }
                , new MimeType { Id = 70, MimeId = 209, Extension = "buffer", IsDefault = true }
                , new MimeType { Id = 597, MimeId = 1228, Extension = "bz", IsDefault = true }
                , new MimeType { Id = 599, MimeId = 1229, Extension = "bz2", IsDefault = true }
                , new MimeType { Id = 973, MimeId = 1763, Extension = "c", IsDefault = true }
                , new MimeType { Id = 200, MimeId = 423, Extension = "c11amc", IsDefault = true }
                , new MimeType { Id = 201, MimeId = 424, Extension = "c11amz", IsDefault = true }
                , new MimeType { Id = 195, MimeId = 422, Extension = "c4d", IsDefault = true }
                , new MimeType { Id = 196, MimeId = 422, Extension = "c4f", IsDefault = true }
                , new MimeType { Id = 197, MimeId = 422, Extension = "c4g", IsDefault = true }
                , new MimeType { Id = 198, MimeId = 422, Extension = "c4p", IsDefault = true }
                , new MimeType { Id = 199, MimeId = 422, Extension = "c4u", IsDefault = true }
                , new MimeType { Id = 379, MimeId = 745, Extension = "cab", IsDefault = true }
                , new MimeType { Id = 809, MimeId = 1529, Extension = "caf", IsDefault = true }
                , new MimeType { Id = 536, MimeId = 1121, Extension = "cap", IsDefault = true }
                , new MimeType { Id = 213, MimeId = 448, Extension = "car", IsDefault = true }
                , new MimeType { Id = 395, MimeId = 760, Extension = "cat", IsDefault = true }
                , new MimeType { Id = 600, MimeId = 1230, Extension = "cb7", IsDefault = true }
                , new MimeType { Id = 601, MimeId = 1230, Extension = "cba", IsDefault = true }
                , new MimeType { Id = 602, MimeId = 1230, Extension = "cbr", IsDefault = true }
                , new MimeType { Id = 603, MimeId = 1230, Extension = "cbt", IsDefault = true }
                , new MimeType { Id = 604, MimeId = 1230, Extension = "cbz", IsDefault = true }
                , new MimeType { Id = 974, MimeId = 1763, Extension = "cc", IsDefault = true }
                , new MimeType { Id = 610, MimeId = 1236, Extension = "cco", IsDefault = true }
                , new MimeType { Id = 617, MimeId = 1244, Extension = "cct", IsDefault = true }
                , new MimeType { Id = 7, MimeId = 39, Extension = "ccxml", IsDefault = true }
                , new MimeType { Id = 203, MimeId = 431, Extension = "cdbcmsg", IsDefault = true }
                , new MimeType { Id = 693, MimeId = 1306, Extension = "cdf", IsDefault = true }
                , new MimeType { Id = 362, MimeId = 712, Extension = "cdkey", IsDefault = true }
                , new MimeType { Id = 8, MimeId = 41, Extension = "cdmia", IsDefault = true }
                , new MimeType { Id = 9, MimeId = 42, Extension = "cdmic", IsDefault = true }
                , new MimeType { Id = 10, MimeId = 43, Extension = "cdmid", IsDefault = true }
                , new MimeType { Id = 11, MimeId = 44, Extension = "cdmio", IsDefault = true }
                , new MimeType { Id = 12, MimeId = 45, Extension = "cdmiq", IsDefault = true }
                , new MimeType { Id = 822, MimeId = 1542, Extension = "cdx", IsDefault = true }
                , new MimeType { Id = 190, MimeId = 415, Extension = "cdxml", IsDefault = true }
                , new MimeType { Id = 192, MimeId = 417, Extension = "cdy", IsDefault = true }
                , new MimeType { Id = 111, MimeId = 234, Extension = "cer", IsDefault = true }
                , new MimeType { Id = 606, MimeId = 1232, Extension = "cfs", IsDefault = true }
                , new MimeType { Id = 830, MimeId = 1551, Extension = "cgm", IsDefault = true }
                , new MimeType { Id = 607, MimeId = 1233, Extension = "chat", IsDefault = true }
                , new MimeType { Id = 391, MimeId = 753, Extension = "chm", IsDefault = true }
                , new MimeType { Id = 331, MimeId = 679, Extension = "chrt", IsDefault = true }
                , new MimeType { Id = 823, MimeId = 1543, Extension = "cif", IsDefault = true }
                , new MimeType { Id = 178, MimeId = 384, Extension = "cii", IsDefault = true }
                , new MimeType { Id = 378, MimeId = 743, Extension = "cil", IsDefault = true }
                , new MimeType { Id = 193, MimeId = 420, Extension = "cla", IsDefault = true }
                , new MimeType { Id = 37, MimeId = 132, Extension = "class", IsDefault = true }
                , new MimeType { Id = 206, MimeId = 435, Extension = "clkk", IsDefault = true }
                , new MimeType { Id = 207, MimeId = 436, Extension = "clkp", IsDefault = true }
                , new MimeType { Id = 208, MimeId = 437, Extension = "clkt", IsDefault = true }
                , new MimeType { Id = 209, MimeId = 438, Extension = "clkw", IsDefault = true }
                , new MimeType { Id = 205, MimeId = 434, Extension = "clkx", IsDefault = true }
                , new MimeType { Id = 674, MimeId = 1296, Extension = "clp", IsDefault = true }
                , new MimeType { Id = 204, MimeId = 433, Extension = "cmc", IsDefault = true }
                , new MimeType { Id = 824, MimeId = 1544, Extension = "cmdf", IsDefault = true }
                , new MimeType { Id = 825, MimeId = 1545, Extension = "cml", IsDefault = true }
                , new MimeType { Id = 573, MimeId = 1202, Extension = "cmp", IsDefault = true }
                , new MimeType { Id = 868, MimeId = 1605, Extension = "cmx", IsDefault = true }
                , new MimeType { Id = 487, MimeId = 1044, Extension = "cod", IsDefault = true }
                , new MimeType { Id = 915, MimeId = 1685, Extension = "coffee", IsDefault = true }
                , new MimeType { Id = 677, MimeId = 1298, Extension = "com", IsDefault = true }
                , new MimeType { Id = 928, MimeId = 1709, Extension = "conf", IsDefault = true }
                , new MimeType { Id = 612, MimeId = 1239, Extension = "cpio", IsDefault = true }
                , new MimeType { Id = 975, MimeId = 1763, Extension = "cpp", IsDefault = true }
                , new MimeType { Id = 46, MimeId = 154, Extension = "cpt", IsDefault = true }
                , new MimeType { Id = 673, MimeId = 1295, Extension = "crd", IsDefault = true }
                , new MimeType { Id = 112, MimeId = 235, Extension = "crl", IsDefault = true }
                , new MimeType { Id = 733, MimeId = 1340, Extension = "crt", IsDefault = true }
                , new MimeType { Id = 609, MimeId = 1235, Extension = "crx", IsDefault = true }
                , new MimeType { Id = 486, MimeId = 1043, Extension = "cryptonote", IsDefault = true }
                , new MimeType { Id = 613, MimeId = 1240, Extension = "csh", IsDefault = true }
                , new MimeType { Id = 826, MimeId = 1546, Extension = "csml", IsDefault = true }
                , new MimeType { Id = 202, MimeId = 430, Extension = "csp", IsDefault = true }
                , new MimeType { Id = 917, MimeId = 1686, Extension = "css", IsDefault = true }
                , new MimeType { Id = 618, MimeId = 1244, Extension = "cst", IsDefault = true }
                , new MimeType { Id = 918, MimeId = 1687, Extension = "csv", IsDefault = true }
                , new MimeType { Id = 13, MimeId = 61, Extension = "cu", IsDefault = true }
                , new MimeType { Id = 957, MimeId = 1734, Extension = "curl", IsDefault = true }
                , new MimeType { Id = 119, MimeId = 246, Extension = "cww", IsDefault = true }
                , new MimeType { Id = 619, MimeId = 1244, Extension = "cxt", IsDefault = true }
                , new MimeType { Id = 976, MimeId = 1763, Extension = "cxx", IsDefault = true }
                , new MimeType { Id = 897, MimeId = 1645, Extension = "dae", IsDefault = true }
                , new MimeType { Id = 368, MimeId = 724, Extension = "daf", IsDefault = true }
                , new MimeType { Id = 215, MimeId = 452, Extension = "dart", IsDefault = true }
                , new MimeType { Id = 249, MimeId = 547, Extension = "dataless", IsDefault = true }
                , new MimeType { Id = 15, MimeId = 66, Extension = "davmount", IsDefault = true }
                , new MimeType { Id = 16, MimeId = 75, Extension = "dbk", IsDefault = true }
                , new MimeType { Id = 620, MimeId = 1244, Extension = "dcr", IsDefault = true }
                , new MimeType { Id = 958, MimeId = 1735, Extension = "dcurl", IsDefault = true }
                , new MimeType { Id = 450, MimeId = 885, Extension = "dd2", IsDefault = true }
                , new MimeType { Id = 265, MimeId = 566, Extension = "ddd", IsDefault = true }
                , new MimeType { Id = 71, MimeId = 209, Extension = "deb", IsDefault = false }
                , new MimeType { Id = 614, MimeId = 1242, Extension = "deb", IsDefault = true }
                , new MimeType { Id = 929, MimeId = 1709, Extension = "def", IsDefault = true }
                , new MimeType { Id = 72, MimeId = 209, Extension = "deploy", IsDefault = true }
                , new MimeType { Id = 734, MimeId = 1340, Extension = "der", IsDefault = true }
                , new MimeType { Id = 231, MimeId = 471, Extension = "dfac", IsDefault = true }
                , new MimeType { Id = 616, MimeId = 1243, Extension = "dgc", IsDefault = true }
                , new MimeType { Id = 977, MimeId = 1763, Extension = "dic", IsDefault = true }
                , new MimeType { Id = 621, MimeId = 1244, Extension = "dir", IsDefault = true }
                , new MimeType { Id = 369, MimeId = 725, Extension = "dis", IsDefault = true }
                , new MimeType { Id = 73, MimeId = 209, Extension = "dist", IsDefault = true }
                , new MimeType { Id = 74, MimeId = 209, Extension = "distz", IsDefault = true }
                , new MimeType { Id = 850, MimeId = 1576, Extension = "djv", IsDefault = true }
                , new MimeType { Id = 851, MimeId = 1576, Extension = "djvu", IsDefault = true }
                , new MimeType { Id = 678, MimeId = 1298, Extension = "dll", IsDefault = false }
                , new MimeType { Id = 75, MimeId = 209, Extension = "dll", IsDefault = true }
                , new MimeType { Id = 76, MimeId = 209, Extension = "dmg", IsDefault = false }
                , new MimeType { Id = 585, MimeId = 1220, Extension = "dmg", IsDefault = true }
                , new MimeType { Id = 537, MimeId = 1121, Extension = "dmp", IsDefault = true }
                , new MimeType { Id = 77, MimeId = 209, Extension = "dms", IsDefault = true }
                , new MimeType { Id = 228, MimeId = 464, Extension = "dna", IsDefault = true }
                , new MimeType { Id = 65, MimeId = 199, Extension = "doc", IsDefault = true }
                , new MimeType { Id = 407, MimeId = 782, Extension = "docm", IsDefault = true }
                , new MimeType { Id = 458, MimeId = 967, Extension = "docx", IsDefault = true }
                , new MimeType { Id = 66, MimeId = 199, Extension = "dot", IsDefault = true }
                , new MimeType { Id = 408, MimeId = 783, Extension = "dotm", IsDefault = true }
                , new MimeType { Id = 459, MimeId = 977, Extension = "dotx", IsDefault = true }
                , new MimeType { Id = 461, MimeId = 988, Extension = "dp", IsDefault = true }
                , new MimeType { Id = 230, MimeId = 470, Extension = "dpg", IsDefault = true }
                , new MimeType { Id = 793, MimeId = 1501, Extension = "dra", IsDefault = true }
                , new MimeType { Id = 936, MimeId = 1712, Extension = "dsc", IsDefault = true }
                , new MimeType { Id = 17, MimeId = 77, Extension = "dssc", IsDefault = true }
                , new MimeType { Id = 628, MimeId = 1247, Extension = "dtb", IsDefault = true }
                , new MimeType { Id = 757, MimeId = 1361, Extension = "dtd", IsDefault = true }
                , new MimeType { Id = 794, MimeId = 1502, Extension = "dts", IsDefault = true }
                , new MimeType { Id = 795, MimeId = 1503, Extension = "dtshd", IsDefault = true }
                , new MimeType { Id = 78, MimeId = 209, Extension = "dump", IsDefault = true }
                , new MimeType { Id = 1040, MimeId = 1840, Extension = "dvb", IsDefault = true }
                , new MimeType { Id = 630, MimeId = 1249, Extension = "dvi", IsDefault = true }
                , new MimeType { Id = 898, MimeId = 1646, Extension = "dwf", IsDefault = true }
                , new MimeType { Id = 853, MimeId = 1578, Extension = "dwg", IsDefault = true }
                , new MimeType { Id = 854, MimeId = 1579, Extension = "dxf", IsDefault = true }
                , new MimeType { Id = 506, MimeId = 1082, Extension = "dxp", IsDefault = true }
                , new MimeType { Id = 622, MimeId = 1244, Extension = "dxr", IsDefault = true }
                , new MimeType { Id = 33, MimeId = 130, Extension = "ear", IsDefault = true }
                , new MimeType { Id = 798, MimeId = 1511, Extension = "ecelp4800", IsDefault = true }
                , new MimeType { Id = 799, MimeId = 1512, Extension = "ecelp7470", IsDefault = true }
                , new MimeType { Id = 800, MimeId = 1513, Extension = "ecelp9600", IsDefault = true }
                , new MimeType { Id = 19, MimeId = 80, Extension = "ecma", IsDefault = true }
                , new MimeType { Id = 429, MimeId = 823, Extension = "edm", IsDefault = true }
                , new MimeType { Id = 430, MimeId = 824, Extension = "edx", IsDefault = true }
                , new MimeType { Id = 469, MimeId = 1002, Extension = "efif", IsDefault = true }
                , new MimeType { Id = 468, MimeId = 1000, Extension = "ei6", IsDefault = true }
                , new MimeType { Id = 79, MimeId = 209, Extension = "elc", IsDefault = true }
                , new MimeType { Id = 684, MimeId = 1300, Extension = "emf", IsDefault = true }
                , new MimeType { Id = 890, MimeId = 1636, Extension = "eml", IsDefault = true }
                , new MimeType { Id = 20, MimeId = 90, Extension = "emma", IsDefault = true }
                , new MimeType { Id = 685, MimeId = 1300, Extension = "emz", IsDefault = true }
                , new MimeType { Id = 792, MimeId = 1491, Extension = "eol", IsDefault = true }
                , new MimeType { Id = 390, MimeId = 752, Extension = "eot", IsDefault = true }
                , new MimeType { Id = 117, MimeId = 240, Extension = "eps", IsDefault = true }
                , new MimeType { Id = 21, MimeId = 94, Extension = "epub", IsDefault = true }
                , new MimeType { Id = 243, MimeId = 517, Extension = "es3", IsDefault = true }
                , new MimeType { Id = 462, MimeId = 989, Extension = "esa", IsDefault = true }
                , new MimeType { Id = 238, MimeId = 511, Extension = "esf", IsDefault = true }
                , new MimeType { Id = 244, MimeId = 517, Extension = "et3", IsDefault = true }
                , new MimeType { Id = 998, MimeId = 1778, Extension = "etx", IsDefault = true }
                , new MimeType { Id = 632, MimeId = 1251, Extension = "eva", IsDefault = true }
                , new MimeType { Id = 631, MimeId = 1250, Extension = "evy", IsDefault = true }
                , new MimeType { Id = 679, MimeId = 1298, Extension = "exe", IsDefault = false }
                , new MimeType { Id = 675, MimeId = 1297, Extension = "exe", IsDefault = false }
                , new MimeType { Id = 80, MimeId = 209, Extension = "exe", IsDefault = true }
                , new MimeType { Id = 22, MimeId = 96, Extension = "exi", IsDefault = true }
                , new MimeType { Id = 431, MimeId = 825, Extension = "ext", IsDefault = true }
                , new MimeType { Id = 1, MimeId = 17, Extension = "ez", IsDefault = true }
                , new MimeType { Id = 245, MimeId = 541, Extension = "ez2", IsDefault = true }
                , new MimeType { Id = 246, MimeId = 542, Extension = "ez3", IsDefault = true }
                , new MimeType { Id = 981, MimeId = 1765, Extension = "f", IsDefault = true }
                , new MimeType { Id = 1049, MimeId = 1866, Extension = "f4v", IsDefault = true }
                , new MimeType { Id = 982, MimeId = 1765, Extension = "f77", IsDefault = true }
                , new MimeType { Id = 983, MimeId = 1765, Extension = "f90", IsDefault = true }
                , new MimeType { Id = 855, MimeId = 1580, Extension = "fbs", IsDefault = true }
                , new MimeType { Id = 166, MimeId = 368, Extension = "fcdt", IsDefault = true }
                , new MimeType { Id = 323, MimeId = 663, Extension = "fcs", IsDefault = true }
                , new MimeType { Id = 247, MimeId = 545, Extension = "fdf", IsDefault = true }
                , new MimeType { Id = 227, MimeId = 459, Extension = "fe_launch", IsDefault = true }
                , new MimeType { Id = 263, MimeId = 562, Extension = "fg5", IsDefault = true }
                , new MimeType { Id = 623, MimeId = 1244, Extension = "fgd", IsDefault = true }
                , new MimeType { Id = 869, MimeId = 1606, Extension = "fh", IsDefault = true }
                , new MimeType { Id = 870, MimeId = 1606, Extension = "fh4", IsDefault = true }
                , new MimeType { Id = 871, MimeId = 1606, Extension = "fh5", IsDefault = true }
                , new MimeType { Id = 872, MimeId = 1606, Extension = "fh7", IsDefault = true }
                , new MimeType { Id = 873, MimeId = 1606, Extension = "fhc", IsDefault = true }
                , new MimeType { Id = 736, MimeId = 1341, Extension = "fig", IsDefault = true }
                , new MimeType { Id = 810, MimeId = 1530, Extension = "flac", IsDefault = true }
                , new MimeType { Id = 1050, MimeId = 1867, Extension = "fli", IsDefault = true }
                , new MimeType { Id = 365, MimeId = 717, Extension = "flo", IsDefault = true }
                , new MimeType { Id = 1051, MimeId = 1868, Extension = "flv", IsDefault = true }
                , new MimeType { Id = 333, MimeId = 681, Extension = "flw", IsDefault = true }
                , new MimeType { Id = 963, MimeId = 1743, Extension = "flx", IsDefault = true }
                , new MimeType { Id = 962, MimeId = 1742, Extension = "fly", IsDefault = true }
                , new MimeType { Id = 254, MimeId = 555, Extension = "fm", IsDefault = true }
                , new MimeType { Id = 257, MimeId = 556, Extension = "fnc", IsDefault = true }
                , new MimeType { Id = 984, MimeId = 1765, Extension = "for", IsDefault = true }
                , new MimeType { Id = 856, MimeId = 1581, Extension = "fpx", IsDefault = true }
                , new MimeType { Id = 255, MimeId = 555, Extension = "frame", IsDefault = true }
                , new MimeType { Id = 259, MimeId = 558, Extension = "fsc", IsDefault = true }
                , new MimeType { Id = 857, MimeId = 1582, Extension = "fst", IsDefault = true }
                , new MimeType { Id = 252, MimeId = 553, Extension = "ftc", IsDefault = true }
                , new MimeType { Id = 179, MimeId = 385, Extension = "fti", IsDefault = true }
                , new MimeType { Id = 1041, MimeId = 1841, Extension = "fvt", IsDefault = true }
                , new MimeType { Id = 167, MimeId = 369, Extension = "fxp", IsDefault = true }
                , new MimeType { Id = 168, MimeId = 369, Extension = "fxpl", IsDefault = true }
                , new MimeType { Id = 268, MimeId = 572, Extension = "fzs", IsDefault = true }
                , new MimeType { Id = 275, MimeId = 580, Extension = "g2w", IsDefault = true }
                , new MimeType { Id = 831, MimeId = 1553, Extension = "g3", IsDefault = true }
                , new MimeType { Id = 276, MimeId = 581, Extension = "g3w", IsDefault = true }
                , new MimeType { Id = 285, MimeId = 596, Extension = "gac", IsDefault = true }
                , new MimeType { Id = 721, MimeId = 1329, Extension = "gam", IsDefault = true }
                , new MimeType { Id = 127, MimeId = 267, Extension = "gbr", IsDefault = true }
                , new MimeType { Id = 647, MimeId = 1268, Extension = "gca", IsDefault = true }
                , new MimeType { Id = 899, MimeId = 1648, Extension = "gdl", IsDefault = true }
                , new MimeType { Id = 278, MimeId = 586, Extension = "gdoc", IsDefault = true }
                , new MimeType { Id = 235, MimeId = 497, Extension = "geo", IsDefault = true }
                , new MimeType { Id = 272, MimeId = 578, Extension = "gex", IsDefault = true }
                , new MimeType { Id = 270, MimeId = 576, Extension = "ggb", IsDefault = true }
                , new MimeType { Id = 271, MimeId = 577, Extension = "ggt", IsDefault = true }
                , new MimeType { Id = 286, MimeId = 597, Extension = "ghf", IsDefault = true }
                , new MimeType { Id = 832, MimeId = 1554, Extension = "gif", IsDefault = true }
                , new MimeType { Id = 287, MimeId = 598, Extension = "gim", IsDefault = true }
                , new MimeType { Id = 26, MimeId = 106, Extension = "gml", IsDefault = true }
                , new MimeType { Id = 277, MimeId = 585, Extension = "gmx", IsDefault = true }
                , new MimeType { Id = 649, MimeId = 1270, Extension = "gnumeric", IsDefault = true }
                , new MimeType { Id = 251, MimeId = 552, Extension = "gph", IsDefault = true }
                , new MimeType { Id = 27, MimeId = 107, Extension = "gpx", IsDefault = true }
                , new MimeType { Id = 283, MimeId = 594, Extension = "gqf", IsDefault = true }
                , new MimeType { Id = 284, MimeId = 594, Extension = "gqs", IsDefault = true }
                , new MimeType { Id = 146, MimeId = 310, Extension = "gram", IsDefault = true }
                , new MimeType { Id = 650, MimeId = 1271, Extension = "gramps", IsDefault = true }
                , new MimeType { Id = 273, MimeId = 578, Extension = "gre", IsDefault = true }
                , new MimeType { Id = 288, MimeId = 599, Extension = "grv", IsDefault = true }
                , new MimeType { Id = 147, MimeId = 311, Extension = "grxml", IsDefault = true }
                , new MimeType { Id = 634, MimeId = 1255, Extension = "gsf", IsDefault = true }
                , new MimeType { Id = 280, MimeId = 588, Extension = "gsheet", IsDefault = true }
                , new MimeType { Id = 279, MimeId = 587, Extension = "gslides", IsDefault = true }
                , new MimeType { Id = 651, MimeId = 1272, Extension = "gtar", IsDefault = true }
                , new MimeType { Id = 289, MimeId = 600, Extension = "gtm", IsDefault = true }
                , new MimeType { Id = 900, MimeId = 1651, Extension = "gtw", IsDefault = true }
                , new MimeType { Id = 964, MimeId = 1744, Extension = "gv", IsDefault = true }
                , new MimeType { Id = 28, MimeId = 108, Extension = "gxf", IsDefault = true }
                , new MimeType { Id = 274, MimeId = 579, Extension = "gxt", IsDefault = true }
                , new MimeType { Id = 978, MimeId = 1763, Extension = "h", IsDefault = true }
                , new MimeType { Id = 1010, MimeId = 1796, Extension = "h261", IsDefault = true }
                , new MimeType { Id = 1011, MimeId = 1797, Extension = "h263", IsDefault = true }
                , new MimeType { Id = 1012, MimeId = 1800, Extension = "h264", IsDefault = true }
                , new MimeType { Id = 292, MimeId = 604, Extension = "hal", IsDefault = true }
                , new MimeType { Id = 294, MimeId = 606, Extension = "hbci", IsDefault = true }
                , new MimeType { Id = 985, MimeId = 1767, Extension = "hbs", IsDefault = true }
                , new MimeType { Id = 652, MimeId = 1274, Extension = "hdf", IsDefault = true }
                , new MimeType { Id = 979, MimeId = 1763, Extension = "hh", IsDefault = true }
                , new MimeType { Id = 919, MimeId = 1696, Extension = "hjson", IsDefault = true }
                , new MimeType { Id = 579, MimeId = 1211, Extension = "hlp", IsDefault = true }
                , new MimeType { Id = 296, MimeId = 611, Extension = "hpgl", IsDefault = true }
                , new MimeType { Id = 297, MimeId = 612, Extension = "hpid", IsDefault = true }
                , new MimeType { Id = 298, MimeId = 613, Extension = "hps", IsDefault = true }
                , new MimeType { Id = 45, MimeId = 153, Extension = "hqx", IsDefault = true }
                , new MimeType { Id = 980, MimeId = 1764, Extension = "htc", IsDefault = true }
                , new MimeType { Id = 340, MimeId = 686, Extension = "htke", IsDefault = true }
                , new MimeType { Id = 920, MimeId = 1697, Extension = "htm", IsDefault = true }
                , new MimeType { Id = 921, MimeId = 1697, Extension = "html", IsDefault = true }
                , new MimeType { Id = 566, MimeId = 1191, Extension = "hvd", IsDefault = true }
                , new MimeType { Id = 568, MimeId = 1193, Extension = "hvp", IsDefault = true }
                , new MimeType { Id = 567, MimeId = 1192, Extension = "hvs", IsDefault = true }
                , new MimeType { Id = 317, MimeId = 648, Extension = "i2g", IsDefault = true }
                , new MimeType { Id = 309, MimeId = 627, Extension = "icc", IsDefault = true }
                , new MimeType { Id = 1067, MimeId = 1881, Extension = "ice", IsDefault = true }
                , new MimeType { Id = 310, MimeId = 627, Extension = "icm", IsDefault = true }
                , new MimeType { Id = 874, MimeId = 1607, Extension = "ico", IsDefault = true }
                , new MimeType { Id = 913, MimeId = 1682, Extension = "ics", IsDefault = true }
                , new MimeType { Id = 833, MimeId = 1555, Extension = "ief", IsDefault = true }
                , new MimeType { Id = 914, MimeId = 1682, Extension = "ifb", IsDefault = true }
                , new MimeType { Id = 496, MimeId = 1070, Extension = "ifm", IsDefault = true }
                , new MimeType { Id = 892, MimeId = 1643, Extension = "iges", IsDefault = true }
                , new MimeType { Id = 311, MimeId = 629, Extension = "igl", IsDefault = true }
                , new MimeType { Id = 314, MimeId = 646, Extension = "igm", IsDefault = true }
                , new MimeType { Id = 893, MimeId = 1643, Extension = "igs", IsDefault = true }
                , new MimeType { Id = 366, MimeId = 718, Extension = "igx", IsDefault = true }
                , new MimeType { Id = 498, MimeId = 1072, Extension = "iif", IsDefault = true }
                , new MimeType { Id = 81, MimeId = 209, Extension = "img", IsDefault = true }
                , new MimeType { Id = 161, MimeId = 363, Extension = "imp", IsDefault = true }
                , new MimeType { Id = 392, MimeId = 754, Extension = "ims", IsDefault = true }
                , new MimeType { Id = 930, MimeId = 1709, Extension = "in", IsDefault = true }
                , new MimeType { Id = 931, MimeId = 1709, Extension = "ini", IsDefault = true }
                , new MimeType { Id = 30, MimeId = 124, Extension = "ink", IsDefault = true }
                , new MimeType { Id = 31, MimeId = 124, Extension = "inkml", IsDefault = true }
                , new MimeType { Id = 654, MimeId = 1276, Extension = "install", IsDefault = true }
                , new MimeType { Id = 185, MimeId = 397, Extension = "iota", IsDefault = true }
                , new MimeType { Id = 32, MimeId = 126, Extension = "ipfix", IsDefault = true }
                , new MimeType { Id = 499, MimeId = 1073, Extension = "ipk", IsDefault = true }
                , new MimeType { Id = 307, MimeId = 625, Extension = "irm", IsDefault = true }
                , new MimeType { Id = 321, MimeId = 661, Extension = "irp", IsDefault = true }
                , new MimeType { Id = 82, MimeId = 209, Extension = "iso", IsDefault = false }
                , new MimeType { Id = 655, MimeId = 1277, Extension = "iso", IsDefault = true }
                , new MimeType { Id = 497, MimeId = 1071, Extension = "itp", IsDefault = true }
                , new MimeType { Id = 312, MimeId = 630, Extension = "ivp", IsDefault = true }
                , new MimeType { Id = 313, MimeId = 631, Extension = "ivu", IsDefault = true }
                , new MimeType { Id = 967, MimeId = 1755, Extension = "jad", IsDefault = true }
                , new MimeType { Id = 923, MimeId = 1698, Extension = "jade", IsDefault = true }
                , new MimeType { Id = 324, MimeId = 664, Extension = "jam", IsDefault = true }
                , new MimeType { Id = 34, MimeId = 130, Extension = "jar", IsDefault = true }
                , new MimeType { Id = 656, MimeId = 1278, Extension = "jardiff", IsDefault = true }
                , new MimeType { Id = 986, MimeId = 1768, Extension = "java", IsDefault = true }
                , new MimeType { Id = 326, MimeId = 674, Extension = "jisp", IsDefault = true }
                , new MimeType { Id = 299, MimeId = 614, Extension = "jlt", IsDefault = true }
                , new MimeType { Id = 875, MimeId = 1608, Extension = "jng", IsDefault = true }
                , new MimeType { Id = 657, MimeId = 1279, Extension = "jnlp", IsDefault = true }
                , new MimeType { Id = 327, MimeId = 675, Extension = "joda", IsDefault = true }
                , new MimeType { Id = 834, MimeId = 1557, Extension = "jpe", IsDefault = true }
                , new MimeType { Id = 835, MimeId = 1557, Extension = "jpeg", IsDefault = true }
                , new MimeType { Id = 836, MimeId = 1557, Extension = "jpg", IsDefault = true }
                , new MimeType { Id = 1014, MimeId = 1807, Extension = "jpgm", IsDefault = true }
                , new MimeType { Id = 1013, MimeId = 1805, Extension = "jpgv", IsDefault = true }
                , new MimeType { Id = 1015, MimeId = 1807, Extension = "jpm", IsDefault = true }
                , new MimeType { Id = 38, MimeId = 133, Extension = "js", IsDefault = true }
                , new MimeType { Id = 39, MimeId = 137, Extension = "json", IsDefault = true }
                , new MimeType { Id = 1068, MimeId = 1696, Extension = "json", IsDefault = false }
                , new MimeType { Id = 41, MimeId = 140, Extension = "json5", IsDefault = true }
                , new MimeType { Id = 43, MimeId = 147, Extension = "jsonld", IsDefault = true }
                , new MimeType { Id = 42, MimeId = 141, Extension = "jsonml", IsDefault = true }
                , new MimeType { Id = 924, MimeId = 1701, Extension = "jsx", IsDefault = true }
                , new MimeType { Id = 773, MimeId = 1443, Extension = "kar", IsDefault = true }
                , new MimeType { Id = 330, MimeId = 678, Extension = "karbon", IsDefault = true }
                , new MimeType { Id = 332, MimeId = 680, Extension = "kfo", IsDefault = true }
                , new MimeType { Id = 341, MimeId = 687, Extension = "kia", IsDefault = true }
                , new MimeType { Id = 281, MimeId = 589, Extension = "kml", IsDefault = true }
                , new MimeType { Id = 282, MimeId = 590, Extension = "kmz", IsDefault = true }
                , new MimeType { Id = 342, MimeId = 688, Extension = "kne", IsDefault = true }
                , new MimeType { Id = 343, MimeId = 688, Extension = "knp", IsDefault = true }
                , new MimeType { Id = 334, MimeId = 682, Extension = "kon", IsDefault = true }
                , new MimeType { Id = 335, MimeId = 683, Extension = "kpr", IsDefault = true }
                , new MimeType { Id = 336, MimeId = 683, Extension = "kpt", IsDefault = true }
                , new MimeType { Id = 232, MimeId = 473, Extension = "kpxx", IsDefault = true }
                , new MimeType { Id = 337, MimeId = 684, Extension = "ksp", IsDefault = true }
                , new MimeType { Id = 328, MimeId = 677, Extension = "ktr", IsDefault = true }
                , new MimeType { Id = 837, MimeId = 1560, Extension = "ktx", IsDefault = true }
                , new MimeType { Id = 329, MimeId = 677, Extension = "ktz", IsDefault = true }
                , new MimeType { Id = 338, MimeId = 685, Extension = "kwd", IsDefault = true }
                , new MimeType { Id = 339, MimeId = 685, Extension = "kwt", IsDefault = true }
                , new MimeType { Id = 349, MimeId = 691, Extension = "lasxml", IsDefault = true }
                , new MimeType { Id = 658, MimeId = 1281, Extension = "latex", IsDefault = true }
                , new MimeType { Id = 350, MimeId = 693, Extension = "lbd", IsDefault = true }
                , new MimeType { Id = 351, MimeId = 694, Extension = "lbe", IsDefault = true }
                , new MimeType { Id = 295, MimeId = 610, Extension = "les", IsDefault = true }
                , new MimeType { Id = 925, MimeId = 1702, Extension = "less", IsDefault = true }
                , new MimeType { Id = 660, MimeId = 1283, Extension = "lha", IsDefault = true }
                , new MimeType { Id = 490, MimeId = 1047, Extension = "link66", IsDefault = true }
                , new MimeType { Id = 932, MimeId = 1709, Extension = "list", IsDefault = true }
                , new MimeType { Id = 305, MimeId = 624, Extension = "list3820", IsDefault = true }
                , new MimeType { Id = 306, MimeId = 624, Extension = "listafp", IsDefault = true }
                , new MimeType { Id = 916, MimeId = 1685, Extension = "litcoffee", IsDefault = true }
                , new MimeType { Id = 667, MimeId = 1289, Extension = "lnk", IsDefault = true }
                , new MimeType { Id = 933, MimeId = 1709, Extension = "log", IsDefault = true }
                , new MimeType { Id = 44, MimeId = 150, Extension = "lostxml", IsDefault = true }
                , new MimeType { Id = 83, MimeId = 209, Extension = "lrf", IsDefault = true }
                , new MimeType { Id = 393, MimeId = 755, Extension = "lrm", IsDefault = true }
                , new MimeType { Id = 258, MimeId = 557, Extension = "ltf", IsDefault = true }
                , new MimeType { Id = 987, MimeId = 1770, Extension = "lua", IsDefault = true }
                , new MimeType { Id = 659, MimeId = 1282, Extension = "luac", IsDefault = true }
                , new MimeType { Id = 796, MimeId = 1507, Extension = "lvp", IsDefault = true }
                , new MimeType { Id = 358, MimeId = 701, Extension = "lwp", IsDefault = true }
                , new MimeType { Id = 661, MimeId = 1283, Extension = "lzh", IsDefault = true }
                , new MimeType { Id = 681, MimeId = 1299, Extension = "m13", IsDefault = true }
                , new MimeType { Id = 682, MimeId = 1299, Extension = "m14", IsDefault = true }
                , new MimeType { Id = 1022, MimeId = 1814, Extension = "m1v", IsDefault = true }
                , new MimeType { Id = 61, MimeId = 190, Extension = "m21", IsDefault = true }
                , new MimeType { Id = 779, MimeId = 1449, Extension = "m2a", IsDefault = true }
                , new MimeType { Id = 1023, MimeId = 1814, Extension = "m2v", IsDefault = true }
                , new MimeType { Id = 780, MimeId = 1449, Extension = "m3a", IsDefault = true }
                , new MimeType { Id = 813, MimeId = 1533, Extension = "m3u", IsDefault = true }
                , new MimeType { Id = 182, MimeId = 392, Extension = "m3u8", IsDefault = true }
                , new MimeType { Id = 777, MimeId = 1445, Extension = "m4a", IsDefault = false }
                , new MimeType { Id = 811, MimeId = 1531, Extension = "m4a", IsDefault = true }
                , new MimeType { Id = 63, MimeId = 191, Extension = "m4p", IsDefault = true }
                , new MimeType { Id = 1042, MimeId = 1851, Extension = "m4u", IsDefault = true }
                , new MimeType { Id = 1052, MimeId = 1869, Extension = "m4v", IsDefault = true }
                , new MimeType { Id = 51, MimeId = 160, Extension = "ma", IsDefault = true }
                , new MimeType { Id = 47, MimeId = 156, Extension = "mads", IsDefault = true }
                , new MimeType { Id = 236, MimeId = 501, Extension = "mag", IsDefault = true }
                , new MimeType { Id = 256, MimeId = 555, Extension = "maker", IsDefault = true }
                , new MimeType { Id = 946, MimeId = 1727, Extension = "man", IsDefault = true }
                , new MimeType { Id = 912, MimeId = 1681, Extension = "manifest", IsDefault = true }
                , new MimeType { Id = 40, MimeId = 137, Extension = "map", IsDefault = true }
                , new MimeType { Id = 84, MimeId = 209, Extension = "mar", IsDefault = true }
                , new MimeType { Id = 988, MimeId = 1771, Extension = "markdown", IsDefault = true }
                , new MimeType { Id = 54, MimeId = 161, Extension = "mathml", IsDefault = true }
                , new MimeType { Id = 52, MimeId = 160, Extension = "mb", IsDefault = true }
                , new MimeType { Id = 370, MimeId = 726, Extension = "mbk", IsDefault = true }
                , new MimeType { Id = 55, MimeId = 175, Extension = "mbox", IsDefault = true }
                , new MimeType { Id = 361, MimeId = 711, Extension = "mc1", IsDefault = true }
                , new MimeType { Id = 360, MimeId = 710, Extension = "mcd", IsDefault = true }
                , new MimeType { Id = 959, MimeId = 1736, Extension = "mcurl", IsDefault = true }
                , new MimeType { Id = 989, MimeId = 1771, Extension = "md", IsDefault = true }
                , new MimeType { Id = 671, MimeId = 1293, Extension = "mdb", IsDefault = true }
                , new MimeType { Id = 860, MimeId = 1589, Extension = "mdi", IsDefault = true }
                , new MimeType { Id = 947, MimeId = 1727, Extension = "me", IsDefault = true }
                , new MimeType { Id = 894, MimeId = 1644, Extension = "mesh", IsDefault = true }
                , new MimeType { Id = 58, MimeId = 181, Extension = "meta4", IsDefault = true }
                , new MimeType { Id = 57, MimeId = 180, Extension = "metalink", IsDefault = true }
                , new MimeType { Id = 59, MimeId = 182, Extension = "mets", IsDefault = true }
                , new MimeType { Id = 364, MimeId = 715, Extension = "mfm", IsDefault = true }
                , new MimeType { Id = 128, MimeId = 268, Extension = "mft", IsDefault = true }
                , new MimeType { Id = 460, MimeId = 986, Extension = "mgp", IsDefault = true }
                , new MimeType { Id = 474, MimeId = 1014, Extension = "mgz", IsDefault = true }
                , new MimeType { Id = 774, MimeId = 1443, Extension = "mid", IsDefault = true }
                , new MimeType { Id = 775, MimeId = 1443, Extension = "midi", IsDefault = true }
                , new MimeType { Id = 663, MimeId = 1285, Extension = "mie", IsDefault = true }
                , new MimeType { Id = 367, MimeId = 721, Extension = "mif", IsDefault = true }
                , new MimeType { Id = 891, MimeId = 1636, Extension = "mime", IsDefault = true }
                , new MimeType { Id = 1016, MimeId = 1808, Extension = "mj2", IsDefault = true }
                , new MimeType { Id = 1017, MimeId = 1808, Extension = "mjp2", IsDefault = true }
                , new MimeType { Id = 1053, MimeId = 1870, Extension = "mk3d", IsDefault = true }
                , new MimeType { Id = 812, MimeId = 1532, Extension = "mka", IsDefault = true }
                , new MimeType { Id = 990, MimeId = 1771, Extension = "mkd", IsDefault = true }
                , new MimeType { Id = 1054, MimeId = 1870, Extension = "mks", IsDefault = true }
                , new MimeType { Id = 1055, MimeId = 1870, Extension = "mkv", IsDefault = true }
                , new MimeType { Id = 229, MimeId = 466, Extension = "mlp", IsDefault = true }
                , new MimeType { Id = 191, MimeId = 416, Extension = "mmd", IsDefault = true }
                , new MimeType { Id = 502, MimeId = 1076, Extension = "mmf", IsDefault = true }
                , new MimeType { Id = 926, MimeId = 1704, Extension = "mml", IsDefault = true }
                , new MimeType { Id = 858, MimeId = 1583, Extension = "mmr", IsDefault = true }
                , new MimeType { Id = 1056, MimeId = 1871, Extension = "mng", IsDefault = true }
                , new MimeType { Id = 688, MimeId = 1301, Extension = "mny", IsDefault = true }
                , new MimeType { Id = 664, MimeId = 1286, Extension = "mobi", IsDefault = true }
                , new MimeType { Id = 60, MimeId = 185, Extension = "mods", IsDefault = true }
                , new MimeType { Id = 1028, MimeId = 1821, Extension = "mov", IsDefault = true }
                , new MimeType { Id = 1065, MimeId = 1879, Extension = "movie", IsDefault = true }
                , new MimeType { Id = 781, MimeId = 1449, Extension = "mp2", IsDefault = true }
                , new MimeType { Id = 62, MimeId = 190, Extension = "mp21", IsDefault = true }
                , new MimeType { Id = 782, MimeId = 1449, Extension = "mp2a", IsDefault = true }
                , new MimeType { Id = 783, MimeId = 1449, Extension = "mp3", IsDefault = true }
                , new MimeType { Id = 1019, MimeId = 1812, Extension = "mp4", IsDefault = true }
                , new MimeType { Id = 778, MimeId = 1445, Extension = "mp4a", IsDefault = true }
                , new MimeType { Id = 64, MimeId = 191, Extension = "mp4s", IsDefault = true }
                , new MimeType { Id = 1020, MimeId = 1812, Extension = "mp4v", IsDefault = true }
                , new MimeType { Id = 376, MimeId = 732, Extension = "mpc", IsDefault = true }
                , new MimeType { Id = 14, MimeId = 64, Extension = "mpd", IsDefault = true }
                , new MimeType { Id = 1024, MimeId = 1814, Extension = "mpe", IsDefault = true }
                , new MimeType { Id = 1025, MimeId = 1814, Extension = "mpeg", IsDefault = true }
                , new MimeType { Id = 1026, MimeId = 1814, Extension = "mpg", IsDefault = true }
                , new MimeType { Id = 1021, MimeId = 1812, Extension = "mpg4", IsDefault = true }
                , new MimeType { Id = 784, MimeId = 1449, Extension = "mpga", IsDefault = true }
                , new MimeType { Id = 181, MimeId = 391, Extension = "mpkg", IsDefault = true }
                , new MimeType { Id = 187, MimeId = 405, Extension = "mpm", IsDefault = true }
                , new MimeType { Id = 375, MimeId = 731, Extension = "mpn", IsDefault = true }
                , new MimeType { Id = 405, MimeId = 772, Extension = "mpp", IsDefault = true }
                , new MimeType { Id = 406, MimeId = 772, Extension = "mpt", IsDefault = true }
                , new MimeType { Id = 303, MimeId = 623, Extension = "mpy", IsDefault = true }
                , new MimeType { Id = 371, MimeId = 727, Extension = "mqy", IsDefault = true }
                , new MimeType { Id = 49, MimeId = 158, Extension = "mrc", IsDefault = true }
                , new MimeType { Id = 50, MimeId = 159, Extension = "mrcx", IsDefault = true }
                , new MimeType { Id = 948, MimeId = 1727, Extension = "ms", IsDefault = true }
                , new MimeType { Id = 56, MimeId = 178, Extension = "mscml", IsDefault = true }
                , new MimeType { Id = 248, MimeId = 546, Extension = "mseed", IsDefault = true }
                , new MimeType { Id = 415, MimeId = 788, Extension = "mseq", IsDefault = true }
                , new MimeType { Id = 239, MimeId = 512, Extension = "msf", IsDefault = true }
                , new MimeType { Id = 895, MimeId = 1644, Extension = "msh", IsDefault = true }
                , new MimeType { Id = 680, MimeId = 1298, Extension = "msi", IsDefault = false }
                , new MimeType { Id = 85, MimeId = 209, Extension = "msi", IsDefault = true }
                , new MimeType { Id = 372, MimeId = 728, Extension = "msl", IsDefault = true }
                , new MimeType { Id = 86, MimeId = 209, Extension = "msm", IsDefault = true }
                , new MimeType { Id = 87, MimeId = 209, Extension = "msp", IsDefault = true }
                , new MimeType { Id = 417, MimeId = 794, Extension = "msty", IsDefault = true }
                , new MimeType { Id = 901, MimeId = 1653, Extension = "mts", IsDefault = true }
                , new MimeType { Id = 416, MimeId = 793, Extension = "mus", IsDefault = true }
                , new MimeType { Id = 485, MimeId = 1041, Extension = "musicxml", IsDefault = true }
                , new MimeType { Id = 683, MimeId = 1299, Extension = "mvb", IsDefault = true }
                , new MimeType { Id = 363, MimeId = 714, Extension = "mwf", IsDefault = true }
                , new MimeType { Id = 67, MimeId = 200, Extension = "mxf", IsDefault = true }
                , new MimeType { Id = 484, MimeId = 1040, Extension = "mxl", IsDefault = true }
                , new MimeType { Id = 762, MimeId = 1369, Extension = "mxml", IsDefault = true }
                , new MimeType { Id = 541, MimeId = 1126, Extension = "mxs", IsDefault = true }
                , new MimeType { Id = 1043, MimeId = 1851, Extension = "mxu", IsDefault = true }
                , new MimeType { Id = 426, MimeId = 817, Extension = "n-gage", IsDefault = true }
                , new MimeType { Id = 927, MimeId = 1706, Extension = "n3", IsDefault = true }
                , new MimeType { Id = 53, MimeId = 160, Extension = "nb", IsDefault = true }
                , new MimeType { Id = 560, MimeId = 1173, Extension = "nbp", IsDefault = true }
                , new MimeType { Id = 694, MimeId = 1306, Extension = "nc", IsDefault = true }
                , new MimeType { Id = 627, MimeId = 1246, Extension = "ncx", IsDefault = true }
                , new MimeType { Id = 991, MimeId = 1772, Extension = "nfo", IsDefault = true }
                , new MimeType { Id = 425, MimeId = 816, Extension = "ngdat", IsDefault = true }
                , new MimeType { Id = 420, MimeId = 803, Extension = "nitf", IsDefault = true }
                , new MimeType { Id = 419, MimeId = 800, Extension = "nlu", IsDefault = true }
                , new MimeType { Id = 237, MimeId = 508, Extension = "nml", IsDefault = true }
                , new MimeType { Id = 422, MimeId = 804, Extension = "nnd", IsDefault = true }
                , new MimeType { Id = 423, MimeId = 805, Extension = "nns", IsDefault = true }
                , new MimeType { Id = 424, MimeId = 806, Extension = "nnw", IsDefault = true }
                , new MimeType { Id = 862, MimeId = 1591, Extension = "npx", IsDefault = true }
                , new MimeType { Id = 611, MimeId = 1238, Extension = "nsc", IsDefault = true }
                , new MimeType { Id = 355, MimeId = 698, Extension = "nsf", IsDefault = true }
                , new MimeType { Id = 421, MimeId = 803, Extension = "ntf", IsDefault = true }
                , new MimeType { Id = 696, MimeId = 1308, Extension = "nzb", IsDefault = true }
                , new MimeType { Id = 261, MimeId = 560, Extension = "oa2", IsDefault = true }
                , new MimeType { Id = 262, MimeId = 561, Extension = "oa3", IsDefault = true }
                , new MimeType { Id = 260, MimeId = 559, Extension = "oas", IsDefault = true }
                , new MimeType { Id = 672, MimeId = 1294, Extension = "obd", IsDefault = true }
                , new MimeType { Id = 729, MimeId = 1335, Extension = "obj", IsDefault = true }
                , new MimeType { Id = 90, MimeId = 210, Extension = "oda", IsDefault = true }
                , new MimeType { Id = 434, MimeId = 833, Extension = "odb", IsDefault = true }
                , new MimeType { Id = 432, MimeId = 831, Extension = "odc", IsDefault = true }
                , new MimeType { Id = 435, MimeId = 834, Extension = "odf", IsDefault = true }
                , new MimeType { Id = 436, MimeId = 835, Extension = "odft", IsDefault = true }
                , new MimeType { Id = 437, MimeId = 836, Extension = "odg", IsDefault = true }
                , new MimeType { Id = 439, MimeId = 838, Extension = "odi", IsDefault = true }
                , new MimeType { Id = 446, MimeId = 845, Extension = "odm", IsDefault = true }
                , new MimeType { Id = 441, MimeId = 840, Extension = "odp", IsDefault = true }
                , new MimeType { Id = 443, MimeId = 842, Extension = "ods", IsDefault = true }
                , new MimeType { Id = 445, MimeId = 844, Extension = "odt", IsDefault = true }
                , new MimeType { Id = 785, MimeId = 1452, Extension = "oga", IsDefault = true }
                , new MimeType { Id = 786, MimeId = 1452, Extension = "ogg", IsDefault = true }
                , new MimeType { Id = 1027, MimeId = 1818, Extension = "ogv", IsDefault = true }
                , new MimeType { Id = 92, MimeId = 213, Extension = "ogx", IsDefault = true }
                , new MimeType { Id = 93, MimeId = 214, Extension = "omdoc", IsDefault = true }
                , new MimeType { Id = 94, MimeId = 215, Extension = "onepkg", IsDefault = true }
                , new MimeType { Id = 95, MimeId = 215, Extension = "onetmp", IsDefault = true }
                , new MimeType { Id = 96, MimeId = 215, Extension = "onetoc", IsDefault = true }
                , new MimeType { Id = 97, MimeId = 215, Extension = "onetoc2", IsDefault = true }
                , new MimeType { Id = 91, MimeId = 212, Extension = "opf", IsDefault = true }
                , new MimeType { Id = 992, MimeId = 1773, Extension = "opml", IsDefault = true }
                , new MimeType { Id = 463, MimeId = 993, Extension = "oprc", IsDefault = true }
                , new MimeType { Id = 356, MimeId = 699, Extension = "org", IsDefault = true }
                , new MimeType { Id = 569, MimeId = 1194, Extension = "osf", IsDefault = true }
                , new MimeType { Id = 570, MimeId = 1195, Extension = "osfpvg", IsDefault = true }
                , new MimeType { Id = 433, MimeId = 832, Extension = "otc", IsDefault = true }
                , new MimeType { Id = 828, MimeId = 1549, Extension = "otf", IsDefault = false }
                , new MimeType { Id = 636, MimeId = 1258, Extension = "otf", IsDefault = true }
                , new MimeType { Id = 438, MimeId = 837, Extension = "otg", IsDefault = true }
                , new MimeType { Id = 448, MimeId = 847, Extension = "oth", IsDefault = true }
                , new MimeType { Id = 440, MimeId = 839, Extension = "oti", IsDefault = true }
                , new MimeType { Id = 442, MimeId = 841, Extension = "otp", IsDefault = true }
                , new MimeType { Id = 444, MimeId = 843, Extension = "ots", IsDefault = true }
                , new MimeType { Id = 447, MimeId = 846, Extension = "ott", IsDefault = true }
                , new MimeType { Id = 98, MimeId = 216, Extension = "oxps", IsDefault = true }
                , new MimeType { Id = 451, MimeId = 905, Extension = "oxt", IsDefault = true }
                , new MimeType { Id = 993, MimeId = 1774, Extension = "p", IsDefault = true }
                , new MimeType { Id = 105, MimeId = 228, Extension = "p10", IsDefault = true }
                , new MimeType { Id = 701, MimeId = 1311, Extension = "p12", IsDefault = true }
                , new MimeType { Id = 703, MimeId = 1312, Extension = "p7b", IsDefault = true }
                , new MimeType { Id = 106, MimeId = 230, Extension = "p7c", IsDefault = true }
                , new MimeType { Id = 107, MimeId = 230, Extension = "p7m", IsDefault = true }
                , new MimeType { Id = 705, MimeId = 1313, Extension = "p7r", IsDefault = true }
                , new MimeType { Id = 108, MimeId = 231, Extension = "p7s", IsDefault = true }
                , new MimeType { Id = 109, MimeId = 232, Extension = "p8", IsDefault = true }
                , new MimeType { Id = 695, MimeId = 1307, Extension = "pac", IsDefault = true }
                , new MimeType { Id = 994, MimeId = 1774, Extension = "pas", IsDefault = true }
                , new MimeType { Id = 466, MimeId = 997, Extension = "paw", IsDefault = true }
                , new MimeType { Id = 472, MimeId = 1006, Extension = "pbd", IsDefault = true }
                , new MimeType { Id = 882, MimeId = 1614, Extension = "pbm", IsDefault = true }
                , new MimeType { Id = 538, MimeId = 1121, Extension = "pcap", IsDefault = true }
                , new MimeType { Id = 637, MimeId = 1259, Extension = "pcf", IsDefault = true }
                , new MimeType { Id = 300, MimeId = 615, Extension = "pcl", IsDefault = true }
                , new MimeType { Id = 301, MimeId = 616, Extension = "pclxl", IsDefault = true }
                , new MimeType { Id = 879, MimeId = 1612, Extension = "pct", IsDefault = true }
                , new MimeType { Id = 214, MimeId = 449, Extension = "pcurl", IsDefault = true }
                , new MimeType { Id = 878, MimeId = 1611, Extension = "pcx", IsDefault = true }
                , new MimeType { Id = 699, MimeId = 1310, Extension = "pdb", IsDefault = false }
                , new MimeType { Id = 464, MimeId = 993, Extension = "pdb", IsDefault = true }
                , new MimeType { Id = 995, MimeId = 1775, Extension = "pde", IsDefault = true }
                , new MimeType { Id = 100, MimeId = 220, Extension = "pdf", IsDefault = true }
                , new MimeType { Id = 735, MimeId = 1340, Extension = "pem", IsDefault = true }
                , new MimeType { Id = 642, MimeId = 1264, Extension = "pfa", IsDefault = true }
                , new MimeType { Id = 643, MimeId = 1264, Extension = "pfb", IsDefault = true }
                , new MimeType { Id = 644, MimeId = 1264, Extension = "pfm", IsDefault = true }
                , new MimeType { Id = 23, MimeId = 102, Extension = "pfr", IsDefault = true }
                , new MimeType { Id = 702, MimeId = 1311, Extension = "pfx", IsDefault = true }
                , new MimeType { Id = 883, MimeId = 1615, Extension = "pgm", IsDefault = true }
                , new MimeType { Id = 608, MimeId = 1234, Extension = "pgn", IsDefault = true }
                , new MimeType { Id = 101, MimeId = 222, Extension = "pgp", IsDefault = true }
                , new MimeType { Id = 653, MimeId = 1275, Extension = "php", IsDefault = true }
                , new MimeType { Id = 880, MimeId = 1612, Extension = "pic", IsDefault = true }
                , new MimeType { Id = 88, MimeId = 209, Extension = "pkg", IsDefault = true }
                , new MimeType { Id = 114, MimeId = 237, Extension = "pki", IsDefault = true }
                , new MimeType { Id = 113, MimeId = 236, Extension = "pkipath", IsDefault = true }
                , new MimeType { Id = 183, MimeId = 393, Extension = "pkpass", IsDefault = true }
                , new MimeType { Id = 697, MimeId = 1309, Extension = "pl", IsDefault = true }
                , new MimeType { Id = 155, MimeId = 348, Extension = "plb", IsDefault = true }
                , new MimeType { Id = 373, MimeId = 729, Extension = "plc", IsDefault = true }
                , new MimeType { Id = 471, MimeId = 1005, Extension = "plf", IsDefault = true }
                , new MimeType { Id = 115, MimeId = 238, Extension = "pls", IsDefault = true }
                , new MimeType { Id = 698, MimeId = 1309, Extension = "pm", IsDefault = true }
                , new MimeType { Id = 211, MimeId = 440, Extension = "pml", IsDefault = true }
                , new MimeType { Id = 838, MimeId = 1563, Extension = "png", IsDefault = true }
                , new MimeType { Id = 881, MimeId = 1613, Extension = "pnm", IsDefault = true }
                , new MimeType { Id = 359, MimeId = 702, Extension = "portpkg", IsDefault = true }
                , new MimeType { Id = 397, MimeId = 763, Extension = "pot", IsDefault = true }
                , new MimeType { Id = 404, MimeId = 768, Extension = "potm", IsDefault = true }
                , new MimeType { Id = 455, MimeId = 934, Extension = "potx", IsDefault = true }
                , new MimeType { Id = 400, MimeId = 764, Extension = "ppam", IsDefault = true }
                , new MimeType { Id = 212, MimeId = 444, Extension = "ppd", IsDefault = true }
                , new MimeType { Id = 884, MimeId = 1616, Extension = "ppm", IsDefault = true }
                , new MimeType { Id = 398, MimeId = 763, Extension = "pps", IsDefault = true }
                , new MimeType { Id = 403, MimeId = 767, Extension = "ppsm", IsDefault = true }
                , new MimeType { Id = 454, MimeId = 929, Extension = "ppsx", IsDefault = true }
                , new MimeType { Id = 399, MimeId = 763, Extension = "ppt", IsDefault = true }
                , new MimeType { Id = 401, MimeId = 765, Extension = "pptm", IsDefault = true }
                , new MimeType { Id = 452, MimeId = 922, Extension = "pptx", IsDefault = true }
                , new MimeType { Id = 465, MimeId = 993, Extension = "pqa", IsDefault = true }
                , new MimeType { Id = 700, MimeId = 1310, Extension = "prc", IsDefault = false }
                , new MimeType { Id = 665, MimeId = 1286, Extension = "prc", IsDefault = true }
                , new MimeType { Id = 354, MimeId = 697, Extension = "pre", IsDefault = true }
                , new MimeType { Id = 104, MimeId = 225, Extension = "prf", IsDefault = true }
                , new MimeType { Id = 118, MimeId = 240, Extension = "ps", IsDefault = true }
                , new MimeType { Id = 156, MimeId = 349, Extension = "psb", IsDefault = true }
                , new MimeType { Id = 845, MimeId = 1572, Extension = "psd", IsDefault = true }
                , new MimeType { Id = 635, MimeId = 1257, Extension = "psf", IsDefault = true }
                , new MimeType { Id = 120, MimeId = 252, Extension = "pskcxml", IsDefault = true }
                , new MimeType { Id = 476, MimeId = 1016, Extension = "ptid", IsDefault = true }
                , new MimeType { Id = 689, MimeId = 1302, Extension = "pub", IsDefault = true }
                , new MimeType { Id = 157, MimeId = 350, Extension = "pvb", IsDefault = true }
                , new MimeType { Id = 159, MimeId = 361, Extension = "pwn", IsDefault = true }
                , new MimeType { Id = 797, MimeId = 1508, Extension = "pya", IsDefault = true }
                , new MimeType { Id = 1044, MimeId = 1852, Extension = "pyv", IsDefault = true }
                , new MimeType { Id = 240, MimeId = 513, Extension = "qam", IsDefault = true }
                , new MimeType { Id = 318, MimeId = 651, Extension = "qbo", IsDefault = true }
                , new MimeType { Id = 319, MimeId = 652, Extension = "qfx", IsDefault = true }
                , new MimeType { Id = 475, MimeId = 1015, Extension = "qps", IsDefault = true }
                , new MimeType { Id = 1029, MimeId = 1821, Extension = "qt", IsDefault = true }
                , new MimeType { Id = 477, MimeId = 1020, Extension = "qwd", IsDefault = true }
                , new MimeType { Id = 478, MimeId = 1020, Extension = "qwt", IsDefault = true }
                , new MimeType { Id = 479, MimeId = 1020, Extension = "qxb", IsDefault = true }
                , new MimeType { Id = 480, MimeId = 1020, Extension = "qxd", IsDefault = true }
                , new MimeType { Id = 481, MimeId = 1020, Extension = "qxl", IsDefault = true }
                , new MimeType { Id = 482, MimeId = 1020, Extension = "qxt", IsDefault = true }
                , new MimeType { Id = 816, MimeId = 1536, Extension = "ra", IsDefault = false }
                , new MimeType { Id = 819, MimeId = 1538, Extension = "ra", IsDefault = true }
                , new MimeType { Id = 817, MimeId = 1536, Extension = "ram", IsDefault = true }
                , new MimeType { Id = 706, MimeId = 1314, Extension = "rar", IsDefault = true }
                , new MimeType { Id = 867, MimeId = 1604, Extension = "ras", IsDefault = true }
                , new MimeType { Id = 320, MimeId = 660, Extension = "rcprofile", IsDefault = true }
                , new MimeType { Id = 121, MimeId = 256, Extension = "rdf", IsDefault = true }
                , new MimeType { Id = 216, MimeId = 453, Extension = "rdz", IsDefault = true }
                , new MimeType { Id = 189, MimeId = 409, Extension = "rep", IsDefault = true }
                , new MimeType { Id = 629, MimeId = 1248, Extension = "res", IsDefault = true }
                , new MimeType { Id = 885, MimeId = 1617, Extension = "rgb", IsDefault = true }
                , new MimeType { Id = 122, MimeId = 257, Extension = "rif", IsDefault = true }
                , new MimeType { Id = 801, MimeId = 1517, Extension = "rip", IsDefault = true }
                , new MimeType { Id = 708, MimeId = 1316, Extension = "ris", IsDefault = true }
                , new MimeType { Id = 124, MimeId = 261, Extension = "rl", IsDefault = true }
                , new MimeType { Id = 859, MimeId = 1584, Extension = "rlc", IsDefault = true }
                , new MimeType { Id = 125, MimeId = 262, Extension = "rld", IsDefault = true }
                , new MimeType { Id = 488, MimeId = 1045, Extension = "rm", IsDefault = true }
                , new MimeType { Id = 776, MimeId = 1443, Extension = "rmi", IsDefault = true }
                , new MimeType { Id = 818, MimeId = 1537, Extension = "rmp", IsDefault = true }
                , new MimeType { Id = 325, MimeId = 673, Extension = "rms", IsDefault = true }
                , new MimeType { Id = 489, MimeId = 1046, Extension = "rmvb", IsDefault = true }
                , new MimeType { Id = 123, MimeId = 258, Extension = "rnc", IsDefault = true }
                , new MimeType { Id = 753, MimeId = 1360, Extension = "rng", IsDefault = true }
                , new MimeType { Id = 129, MimeId = 269, Extension = "roa", IsDefault = true }
                , new MimeType { Id = 949, MimeId = 1727, Extension = "roff", IsDefault = true }
                , new MimeType { Id = 194, MimeId = 421, Extension = "rp9", IsDefault = true }
                , new MimeType { Id = 707, MimeId = 1315, Extension = "rpm", IsDefault = true }
                , new MimeType { Id = 428, MimeId = 822, Extension = "rpss", IsDefault = true }
                , new MimeType { Id = 427, MimeId = 821, Extension = "rpst", IsDefault = true }
                , new MimeType { Id = 144, MimeId = 306, Extension = "rq", IsDefault = true }
                , new MimeType { Id = 126, MimeId = 266, Extension = "rs", IsDefault = true }
                , new MimeType { Id = 130, MimeId = 271, Extension = "rsd", IsDefault = true }
                , new MimeType { Id = 131, MimeId = 272, Extension = "rss", IsDefault = true }
                , new MimeType { Id = 132, MimeId = 273, Extension = "rtf", IsDefault = true }
                , new MimeType { Id = 938, MimeId = 1718, Extension = "rtf", IsDefault = false }
                , new MimeType { Id = 937, MimeId = 1717, Extension = "rtx", IsDefault = true }
                , new MimeType { Id = 662, MimeId = 1284, Extension = "run", IsDefault = true }
                , new MimeType { Id = 972, MimeId = 1762, Extension = "s", IsDefault = true }
                , new MimeType { Id = 788, MimeId = 1467, Extension = "s3m", IsDefault = true }
                , new MimeType { Id = 571, MimeId = 1197, Extension = "saf", IsDefault = true }
                , new MimeType { Id = 996, MimeId = 1776, Extension = "sass", IsDefault = true }
                , new MimeType { Id = 133, MimeId = 278, Extension = "sbml", IsDefault = true }
                , new MimeType { Id = 308, MimeId = 626, Extension = "sc", IsDefault = true }
                , new MimeType { Id = 690, MimeId = 1303, Extension = "scd", IsDefault = true }
                , new MimeType { Id = 357, MimeId = 700, Extension = "scm", IsDefault = true }
                , new MimeType { Id = 134, MimeId = 281, Extension = "scq", IsDefault = true }
                , new MimeType { Id = 135, MimeId = 282, Extension = "scs", IsDefault = true }
                , new MimeType { Id = 997, MimeId = 1777, Extension = "scss", IsDefault = true }
                , new MimeType { Id = 960, MimeId = 1737, Extension = "scurl", IsDefault = true }
                , new MimeType { Id = 509, MimeId = 1088, Extension = "sda", IsDefault = true }
                , new MimeType { Id = 508, MimeId = 1087, Extension = "sdc", IsDefault = true }
                , new MimeType { Id = 510, MimeId = 1089, Extension = "sdd", IsDefault = true }
                , new MimeType { Id = 504, MimeId = 1081, Extension = "sdkd", IsDefault = true }
                , new MimeType { Id = 505, MimeId = 1081, Extension = "sdkm", IsDefault = true }
                , new MimeType { Id = 138, MimeId = 285, Extension = "sdp", IsDefault = true }
                , new MimeType { Id = 512, MimeId = 1091, Extension = "sdw", IsDefault = true }
                , new MimeType { Id = 709, MimeId = 1317, Extension = "sea", IsDefault = true }
                , new MimeType { Id = 492, MimeId = 1066, Extension = "see", IsDefault = true }
                , new MimeType { Id = 250, MimeId = 547, Extension = "seed", IsDefault = true }
                , new MimeType { Id = 493, MimeId = 1067, Extension = "sema", IsDefault = true }
                , new MimeType { Id = 494, MimeId = 1068, Extension = "semd", IsDefault = true }
                , new MimeType { Id = 495, MimeId = 1069, Extension = "semf", IsDefault = true }
                , new MimeType { Id = 36, MimeId = 131, Extension = "ser", IsDefault = true }
                , new MimeType { Id = 139, MimeId = 290, Extension = "setpay", IsDefault = true }
                , new MimeType { Id = 140, MimeId = 292, Extension = "setreg", IsDefault = true }
                , new MimeType { Id = 302, MimeId = 618, Extension = "sfd-hdstx", IsDefault = true }
                , new MimeType { Id = 507, MimeId = 1083, Extension = "sfs", IsDefault = true }
                , new MimeType { Id = 999, MimeId = 1779, Extension = "sfv", IsDefault = true }
                , new MimeType { Id = 840, MimeId = 1567, Extension = "sgi", IsDefault = true }
                , new MimeType { Id = 514, MimeId = 1092, Extension = "sgl", IsDefault = true }
                , new MimeType { Id = 939, MimeId = 1722, Extension = "sgm", IsDefault = true }
                , new MimeType { Id = 940, MimeId = 1722, Extension = "sgml", IsDefault = true }
                , new MimeType { Id = 710, MimeId = 1318, Extension = "sh", IsDefault = true }
                , new MimeType { Id = 711, MimeId = 1319, Extension = "shar", IsDefault = true }
                , new MimeType { Id = 141, MimeId = 295, Extension = "shf", IsDefault = true }
                , new MimeType { Id = 922, MimeId = 1697, Extension = "shtml", IsDefault = true }
                , new MimeType { Id = 876, MimeId = 1609, Extension = "sid", IsDefault = true }
                , new MimeType { Id = 103, MimeId = 224, Extension = "sig", IsDefault = true }
                , new MimeType { Id = 789, MimeId = 1468, Extension = "sil", IsDefault = true }
                , new MimeType { Id = 896, MimeId = 1644, Extension = "silo", IsDefault = true }
                , new MimeType { Id = 530, MimeId = 1110, Extension = "sis", IsDefault = true }
                , new MimeType { Id = 531, MimeId = 1110, Extension = "sisx", IsDefault = true }
                , new MimeType { Id = 715, MimeId = 1323, Extension = "sit", IsDefault = true }
                , new MimeType { Id = 716, MimeId = 1324, Extension = "sitx", IsDefault = true }
                , new MimeType { Id = 344, MimeId = 689, Extension = "skd", IsDefault = true }
                , new MimeType { Id = 345, MimeId = 689, Extension = "skm", IsDefault = true }
                , new MimeType { Id = 346, MimeId = 689, Extension = "skp", IsDefault = true }
                , new MimeType { Id = 347, MimeId = 689, Extension = "skt", IsDefault = true }
                , new MimeType { Id = 402, MimeId = 766, Extension = "sldm", IsDefault = true }
                , new MimeType { Id = 453, MimeId = 925, Extension = "sldx", IsDefault = true }
                , new MimeType { Id = 941, MimeId = 1723, Extension = "slim", IsDefault = true }
                , new MimeType { Id = 942, MimeId = 1723, Extension = "slm", IsDefault = true }
                , new MimeType { Id = 241, MimeId = 514, Extension = "slt", IsDefault = true }
                , new MimeType { Id = 516, MimeId = 1094, Extension = "sm", IsDefault = true }
                , new MimeType { Id = 511, MimeId = 1090, Extension = "smf", IsDefault = true }
                , new MimeType { Id = 142, MimeId = 302, Extension = "smi", IsDefault = true }
                , new MimeType { Id = 143, MimeId = 302, Extension = "smil", IsDefault = true }
                , new MimeType { Id = 1066, MimeId = 1880, Extension = "smv", IsDefault = true }
                , new MimeType { Id = 515, MimeId = 1093, Extension = "smzip", IsDefault = true }
                , new MimeType { Id = 772, MimeId = 1388, Extension = "snd", IsDefault = true }
                , new MimeType { Id = 638, MimeId = 1260, Extension = "snf", IsDefault = true }
                , new MimeType { Id = 89, MimeId = 209, Extension = "so", IsDefault = true }
                , new MimeType { Id = 704, MimeId = 1312, Extension = "spc", IsDefault = true }
                , new MimeType { Id = 572, MimeId = 1198, Extension = "spf", IsDefault = true }
                , new MimeType { Id = 646, MimeId = 1267, Extension = "spl", IsDefault = true }
                , new MimeType { Id = 966, MimeId = 1746, Extension = "spot", IsDefault = true }
                , new MimeType { Id = 137, MimeId = 284, Extension = "spp", IsDefault = true }
                , new MimeType { Id = 136, MimeId = 283, Extension = "spq", IsDefault = true }
                , new MimeType { Id = 787, MimeId = 1452, Extension = "spx", IsDefault = true }
                , new MimeType { Id = 714, MimeId = 1322, Extension = "sql", IsDefault = true }
                , new MimeType { Id = 731, MimeId = 1337, Extension = "src", IsDefault = true }
                , new MimeType { Id = 717, MimeId = 1325, Extension = "srt", IsDefault = true }
                , new MimeType { Id = 148, MimeId = 312, Extension = "sru", IsDefault = true }
                , new MimeType { Id = 145, MimeId = 307, Extension = "srx", IsDefault = true }
                , new MimeType { Id = 149, MimeId = 313, Extension = "ssdl", IsDefault = true }
                , new MimeType { Id = 348, MimeId = 690, Extension = "sse", IsDefault = true }
                , new MimeType { Id = 242, MimeId = 515, Extension = "ssf", IsDefault = true }
                , new MimeType { Id = 150, MimeId = 314, Extension = "ssml", IsDefault = true }
                , new MimeType { Id = 491, MimeId = 1051, Extension = "st", IsDefault = true }
                , new MimeType { Id = 518, MimeId = 1098, Extension = "stc", IsDefault = true }
                , new MimeType { Id = 520, MimeId = 1100, Extension = "std", IsDefault = true }
                , new MimeType { Id = 563, MimeId = 1177, Extension = "stf", IsDefault = true }
                , new MimeType { Id = 522, MimeId = 1102, Extension = "sti", IsDefault = true }
                , new MimeType { Id = 29, MimeId = 113, Extension = "stk", IsDefault = true }
                , new MimeType { Id = 396, MimeId = 761, Extension = "stl", IsDefault = true }
                , new MimeType { Id = 467, MimeId = 999, Extension = "str", IsDefault = true }
                , new MimeType { Id = 526, MimeId = 1106, Extension = "stw", IsDefault = true }
                , new MimeType { Id = 943, MimeId = 1724, Extension = "styl", IsDefault = true }
                , new MimeType { Id = 944, MimeId = 1724, Extension = "stylus", IsDefault = true }
                , new MimeType { Id = 961, MimeId = 1740, Extension = "sub", IsDefault = true }
                , new MimeType { Id = 852, MimeId = 1577, Extension = "sub", IsDefault = false }
                , new MimeType { Id = 527, MimeId = 1107, Extension = "sus", IsDefault = true }
                , new MimeType { Id = 528, MimeId = 1107, Extension = "susp", IsDefault = true }
                , new MimeType { Id = 718, MimeId = 1326, Extension = "sv4cpio", IsDefault = true }
                , new MimeType { Id = 719, MimeId = 1327, Extension = "sv4crc", IsDefault = true }
                , new MimeType { Id = 234, MimeId = 495, Extension = "svc", IsDefault = true }
                , new MimeType { Id = 529, MimeId = 1108, Extension = "svd", IsDefault = true }
                , new MimeType { Id = 841, MimeId = 1568, Extension = "svg", IsDefault = true }
                , new MimeType { Id = 842, MimeId = 1568, Extension = "svgz", IsDefault = true }
                , new MimeType { Id = 624, MimeId = 1244, Extension = "swa", IsDefault = true }
                , new MimeType { Id = 712, MimeId = 1320, Extension = "swf", IsDefault = true }
                , new MimeType { Id = 184, MimeId = 395, Extension = "swi", IsDefault = true }
                , new MimeType { Id = 517, MimeId = 1097, Extension = "sxc", IsDefault = true }
                , new MimeType { Id = 519, MimeId = 1099, Extension = "sxd", IsDefault = true }
                , new MimeType { Id = 525, MimeId = 1105, Extension = "sxg", IsDefault = true }
                , new MimeType { Id = 521, MimeId = 1101, Extension = "sxi", IsDefault = true }
                , new MimeType { Id = 523, MimeId = 1103, Extension = "sxm", IsDefault = true }
                , new MimeType { Id = 524, MimeId = 1104, Extension = "sxw", IsDefault = true }
                , new MimeType { Id = 950, MimeId = 1727, Extension = "t", IsDefault = true }
                , new MimeType { Id = 720, MimeId = 1328, Extension = "t3", IsDefault = true }
                , new MimeType { Id = 418, MimeId = 795, Extension = "taglet", IsDefault = true }
                , new MimeType { Id = 535, MimeId = 1120, Extension = "tao", IsDefault = true }
                , new MimeType { Id = 722, MimeId = 1330, Extension = "tar", IsDefault = true }
                , new MimeType { Id = 158, MimeId = 359, Extension = "tcap", IsDefault = true }
                , new MimeType { Id = 723, MimeId = 1331, Extension = "tcl", IsDefault = true }
                , new MimeType { Id = 503, MimeId = 1078, Extension = "teacher", IsDefault = true }
                , new MimeType { Id = 151, MimeId = 327, Extension = "tei", IsDefault = true }
                , new MimeType { Id = 152, MimeId = 327, Extension = "teicorpus", IsDefault = true }
                , new MimeType { Id = 725, MimeId = 1332, Extension = "tex", IsDefault = true }
                , new MimeType { Id = 727, MimeId = 1334, Extension = "texi", IsDefault = true }
                , new MimeType { Id = 728, MimeId = 1334, Extension = "texinfo", IsDefault = true }
                , new MimeType { Id = 934, MimeId = 1709, Extension = "text", IsDefault = true }
                , new MimeType { Id = 153, MimeId = 328, Extension = "tfi", IsDefault = true }
                , new MimeType { Id = 726, MimeId = 1333, Extension = "tfm", IsDefault = true }
                , new MimeType { Id = 886, MimeId = 1618, Extension = "tga", IsDefault = true }
                , new MimeType { Id = 394, MimeId = 757, Extension = "thmx", IsDefault = true }
                , new MimeType { Id = 843, MimeId = 1570, Extension = "tif", IsDefault = true }
                , new MimeType { Id = 844, MimeId = 1570, Extension = "tiff", IsDefault = true }
                , new MimeType { Id = 724, MimeId = 1331, Extension = "tk", IsDefault = true }
                , new MimeType { Id = 539, MimeId = 1124, Extension = "tmo", IsDefault = true }
                , new MimeType { Id = 594, MimeId = 1226, Extension = "torrent", IsDefault = true }
                , new MimeType { Id = 290, MimeId = 601, Extension = "tpl", IsDefault = true }
                , new MimeType { Id = 540, MimeId = 1125, Extension = "tpt", IsDefault = true }
                , new MimeType { Id = 951, MimeId = 1727, Extension = "tr", IsDefault = true }
                , new MimeType { Id = 542, MimeId = 1127, Extension = "tra", IsDefault = true }
                , new MimeType { Id = 691, MimeId = 1304, Extension = "trm", IsDefault = true }
                , new MimeType { Id = 1018, MimeId = 1811, Extension = "ts", IsDefault = true }
                , new MimeType { Id = 154, MimeId = 331, Extension = "tsd", IsDefault = true }
                , new MimeType { Id = 945, MimeId = 1726, Extension = "tsv", IsDefault = true }
                , new MimeType { Id = 639, MimeId = 1263, Extension = "ttc", IsDefault = true }
                , new MimeType { Id = 640, MimeId = 1263, Extension = "ttf", IsDefault = true }
                , new MimeType { Id = 952, MimeId = 1728, Extension = "ttl", IsDefault = true }
                , new MimeType { Id = 500, MimeId = 1074, Extension = "twd", IsDefault = true }
                , new MimeType { Id = 501, MimeId = 1074, Extension = "twds", IsDefault = true }
                , new MimeType { Id = 269, MimeId = 573, Extension = "txd", IsDefault = true }
                , new MimeType { Id = 374, MimeId = 730, Extension = "txf", IsDefault = true }
                , new MimeType { Id = 935, MimeId = 1709, Extension = "txt", IsDefault = true }
                , new MimeType { Id = 587, MimeId = 1221, Extension = "u32", IsDefault = true }
                , new MimeType { Id = 615, MimeId = 1242, Extension = "udeb", IsDefault = true }
                , new MimeType { Id = 543, MimeId = 1130, Extension = "ufd", IsDefault = true }
                , new MimeType { Id = 544, MimeId = 1130, Extension = "ufdl", IsDefault = true }
                , new MimeType { Id = 648, MimeId = 1269, Extension = "ulx", IsDefault = true }
                , new MimeType { Id = 546, MimeId = 1132, Extension = "umj", IsDefault = true }
                , new MimeType { Id = 547, MimeId = 1133, Extension = "unityweb", IsDefault = true }
                , new MimeType { Id = 548, MimeId = 1134, Extension = "uoml", IsDefault = true }
                , new MimeType { Id = 953, MimeId = 1730, Extension = "uri", IsDefault = true }
                , new MimeType { Id = 954, MimeId = 1730, Extension = "uris", IsDefault = true }
                , new MimeType { Id = 955, MimeId = 1730, Extension = "urls", IsDefault = true }
                , new MimeType { Id = 730, MimeId = 1336, Extension = "ustar", IsDefault = true }
                , new MimeType { Id = 545, MimeId = 1131, Extension = "utz", IsDefault = true }
                , new MimeType { Id = 1001, MimeId = 1781, Extension = "uu", IsDefault = true }
                , new MimeType { Id = 790, MimeId = 1490, Extension = "uva", IsDefault = true }
                , new MimeType { Id = 217, MimeId = 455, Extension = "uvd", IsDefault = true }
                , new MimeType { Id = 218, MimeId = 455, Extension = "uvf", IsDefault = true }
                , new MimeType { Id = 846, MimeId = 1575, Extension = "uvg", IsDefault = true }
                , new MimeType { Id = 1030, MimeId = 1831, Extension = "uvh", IsDefault = true }
                , new MimeType { Id = 847, MimeId = 1575, Extension = "uvi", IsDefault = true }
                , new MimeType { Id = 1032, MimeId = 1832, Extension = "uvm", IsDefault = true }
                , new MimeType { Id = 1034, MimeId = 1834, Extension = "uvp", IsDefault = true }
                , new MimeType { Id = 1036, MimeId = 1835, Extension = "uvs", IsDefault = true }
                , new MimeType { Id = 221, MimeId = 456, Extension = "uvt", IsDefault = true }
                , new MimeType { Id = 1045, MimeId = 1862, Extension = "uvu", IsDefault = true }
                , new MimeType { Id = 1038, MimeId = 1836, Extension = "uvv", IsDefault = true }
                , new MimeType { Id = 791, MimeId = 1490, Extension = "uvva", IsDefault = true }
                , new MimeType { Id = 219, MimeId = 455, Extension = "uvvd", IsDefault = true }
                , new MimeType { Id = 220, MimeId = 455, Extension = "uvvf", IsDefault = true }
                , new MimeType { Id = 848, MimeId = 1575, Extension = "uvvg", IsDefault = true }
                , new MimeType { Id = 1031, MimeId = 1831, Extension = "uvvh", IsDefault = true }
                , new MimeType { Id = 849, MimeId = 1575, Extension = "uvvi", IsDefault = true }
                , new MimeType { Id = 1033, MimeId = 1832, Extension = "uvvm", IsDefault = true }
                , new MimeType { Id = 1035, MimeId = 1834, Extension = "uvvp", IsDefault = true }
                , new MimeType { Id = 1037, MimeId = 1835, Extension = "uvvs", IsDefault = true }
                , new MimeType { Id = 222, MimeId = 456, Extension = "uvvt", IsDefault = true }
                , new MimeType { Id = 1046, MimeId = 1862, Extension = "uvvu", IsDefault = true }
                , new MimeType { Id = 1039, MimeId = 1836, Extension = "uvvv", IsDefault = true }
                , new MimeType { Id = 223, MimeId = 457, Extension = "uvvx", IsDefault = true }
                , new MimeType { Id = 225, MimeId = 458, Extension = "uvvz", IsDefault = true }
                , new MimeType { Id = 224, MimeId = 457, Extension = "uvx", IsDefault = true }
                , new MimeType { Id = 226, MimeId = 458, Extension = "uvz", IsDefault = true }
                , new MimeType { Id = 956, MimeId = 1731, Extension = "vcard", IsDefault = true }
                , new MimeType { Id = 605, MimeId = 1231, Extension = "vcd", IsDefault = true }
                , new MimeType { Id = 1003, MimeId = 1783, Extension = "vcf", IsDefault = true }
                , new MimeType { Id = 291, MimeId = 602, Extension = "vcg", IsDefault = true }
                , new MimeType { Id = 1002, MimeId = 1782, Extension = "vcs", IsDefault = true }
                , new MimeType { Id = 549, MimeId = 1150, Extension = "vcx", IsDefault = true }
                , new MimeType { Id = 554, MimeId = 1157, Extension = "vis", IsDefault = true }
                , new MimeType { Id = 1047, MimeId = 1863, Extension = "viv", IsDefault = true }
                , new MimeType { Id = 1059, MimeId = 1873, Extension = "vob", IsDefault = true }
                , new MimeType { Id = 513, MimeId = 1091, Extension = "vor", IsDefault = true }
                , new MimeType { Id = 588, MimeId = 1221, Extension = "vox", IsDefault = true }
                , new MimeType { Id = 903, MimeId = 1660, Extension = "vrml", IsDefault = true }
                , new MimeType { Id = 550, MimeId = 1156, Extension = "vsd", IsDefault = true }
                , new MimeType { Id = 555, MimeId = 1159, Extension = "vsf", IsDefault = true }
                , new MimeType { Id = 551, MimeId = 1156, Extension = "vss", IsDefault = true }
                , new MimeType { Id = 552, MimeId = 1156, Extension = "vst", IsDefault = true }
                , new MimeType { Id = 553, MimeId = 1156, Extension = "vsw", IsDefault = true }
                , new MimeType { Id = 970, MimeId = 1761, Extension = "vtt", IsDefault = true }
                , new MimeType { Id = 902, MimeId = 1659, Extension = "vtu", IsDefault = true }
                , new MimeType { Id = 577, MimeId = 1205, Extension = "vxml", IsDefault = true }
                , new MimeType { Id = 625, MimeId = 1244, Extension = "w3d", IsDefault = true }
                , new MimeType { Id = 626, MimeId = 1245, Extension = "wad", IsDefault = true }
                , new MimeType { Id = 35, MimeId = 130, Extension = "war", IsDefault = true }
                , new MimeType { Id = 820, MimeId = 1540, Extension = "wav", IsDefault = false }
                , new MimeType { Id = 802, MimeId = 1524, Extension = "wav", IsDefault = false }
                , new MimeType { Id = 803, MimeId = 1525, Extension = "wav", IsDefault = true }
                , new MimeType { Id = 814, MimeId = 1534, Extension = "wax", IsDefault = true }
                , new MimeType { Id = 863, MimeId = 1599, Extension = "wbmp", IsDefault = true }
                , new MimeType { Id = 210, MimeId = 439, Extension = "wbs", IsDefault = true }
                , new MimeType { Id = 556, MimeId = 1162, Extension = "wbxml", IsDefault = true }
                , new MimeType { Id = 409, MimeId = 784, Extension = "wcm", IsDefault = true }
                , new MimeType { Id = 410, MimeId = 784, Extension = "wdb", IsDefault = true }
                , new MimeType { Id = 861, MimeId = 1590, Extension = "wdp", IsDefault = true }
                , new MimeType { Id = 804, MimeId = 1526, Extension = "weba", IsDefault = true }
                , new MimeType { Id = 732, MimeId = 1338, Extension = "webapp", IsDefault = true }
                , new MimeType { Id = 1048, MimeId = 1865, Extension = "webm", IsDefault = true }
                , new MimeType { Id = 48, MimeId = 157, Extension = "webmanifest", IsDefault = true }
                , new MimeType { Id = 865, MimeId = 1602, Extension = "webp", IsDefault = true }
                , new MimeType { Id = 470, MimeId = 1003, Extension = "wg", IsDefault = true }
                , new MimeType { Id = 578, MimeId = 1210, Extension = "wgt", IsDefault = true }
                , new MimeType { Id = 411, MimeId = 784, Extension = "wks", IsDefault = true }
                , new MimeType { Id = 1060, MimeId = 1874, Extension = "wm", IsDefault = true }
                , new MimeType { Id = 815, MimeId = 1535, Extension = "wma", IsDefault = true }
                , new MimeType { Id = 668, MimeId = 1290, Extension = "wmd", IsDefault = true }
                , new MimeType { Id = 686, MimeId = 1300, Extension = "wmf", IsDefault = true }
                , new MimeType { Id = 968, MimeId = 1759, Extension = "wml", IsDefault = true }
                , new MimeType { Id = 557, MimeId = 1163, Extension = "wmlc", IsDefault = true }
                , new MimeType { Id = 969, MimeId = 1760, Extension = "wmls", IsDefault = true }
                , new MimeType { Id = 558, MimeId = 1164, Extension = "wmlsc", IsDefault = true }
                , new MimeType { Id = 1061, MimeId = 1875, Extension = "wmv", IsDefault = true }
                , new MimeType { Id = 1062, MimeId = 1876, Extension = "wmx", IsDefault = true }
                , new MimeType { Id = 687, MimeId = 1300, Extension = "wmz", IsDefault = false }
                , new MimeType { Id = 669, MimeId = 1291, Extension = "wmz", IsDefault = true }
                , new MimeType { Id = 24, MimeId = 103, Extension = "woff", IsDefault = true }
                , new MimeType { Id = 25, MimeId = 104, Extension = "woff2", IsDefault = true }
                , new MimeType { Id = 561, MimeId = 1174, Extension = "wpd", IsDefault = true }
                , new MimeType { Id = 413, MimeId = 785, Extension = "wpl", IsDefault = true }
                , new MimeType { Id = 412, MimeId = 784, Extension = "wps", IsDefault = true }
                , new MimeType { Id = 562, MimeId = 1175, Extension = "wqd", IsDefault = true }
                , new MimeType { Id = 692, MimeId = 1305, Extension = "wri", IsDefault = true }
                , new MimeType { Id = 904, MimeId = 1660, Extension = "wrl", IsDefault = true }
                , new MimeType { Id = 580, MimeId = 1214, Extension = "wsdl", IsDefault = true }
                , new MimeType { Id = 581, MimeId = 1215, Extension = "wspolicy", IsDefault = true }
                , new MimeType { Id = 559, MimeId = 1165, Extension = "wtb", IsDefault = true }
                , new MimeType { Id = 1063, MimeId = 1877, Extension = "wvx", IsDefault = true }
                , new MimeType { Id = 589, MimeId = 1221, Extension = "x32", IsDefault = true }
                , new MimeType { Id = 909, MimeId = 1664, Extension = "x3d", IsDefault = true }
                , new MimeType { Id = 905, MimeId = 1661, Extension = "x3db", IsDefault = true }
                , new MimeType { Id = 906, MimeId = 1661, Extension = "x3dbz", IsDefault = true }
                , new MimeType { Id = 907, MimeId = 1663, Extension = "x3dv", IsDefault = true }
                , new MimeType { Id = 908, MimeId = 1663, Extension = "x3dvz", IsDefault = true }
                , new MimeType { Id = 910, MimeId = 1664, Extension = "x3dz", IsDefault = true }
                , new MimeType { Id = 748, MimeId = 1348, Extension = "xaml", IsDefault = true }
                , new MimeType { Id = 713, MimeId = 1321, Extension = "xap", IsDefault = true }
                , new MimeType { Id = 564, MimeId = 1182, Extension = "xar", IsDefault = true }
                , new MimeType { Id = 670, MimeId = 1292, Extension = "xbap", IsDefault = true }
                , new MimeType { Id = 267, MimeId = 568, Extension = "xbd", IsDefault = true }
                , new MimeType { Id = 887, MimeId = 1619, Extension = "xbm", IsDefault = true }
                , new MimeType { Id = 749, MimeId = 1351, Extension = "xdf", IsDefault = true }
                , new MimeType { Id = 534, MimeId = 1113, Extension = "xdm", IsDefault = true }
                , new MimeType { Id = 169, MimeId = 371, Extension = "xdp", IsDefault = true }
                , new MimeType { Id = 18, MimeId = 78, Extension = "xdssc", IsDefault = true }
                , new MimeType { Id = 266, MimeId = 567, Extension = "xdw", IsDefault = true }
                , new MimeType { Id = 750, MimeId = 1357, Extension = "xenc", IsDefault = true }
                , new MimeType { Id = 99, MimeId = 219, Extension = "xer", IsDefault = true }
                , new MimeType { Id = 170, MimeId = 372, Extension = "xfdf", IsDefault = true }
                , new MimeType { Id = 565, MimeId = 1183, Extension = "xfdl", IsDefault = true }
                , new MimeType { Id = 751, MimeId = 1358, Extension = "xht", IsDefault = true }
                , new MimeType { Id = 752, MimeId = 1358, Extension = "xhtml", IsDefault = true }
                , new MimeType { Id = 763, MimeId = 1369, Extension = "xhvml", IsDefault = true }
                , new MimeType { Id = 864, MimeId = 1600, Extension = "xif", IsDefault = true }
                , new MimeType { Id = 380, MimeId = 747, Extension = "xla", IsDefault = true }
                , new MimeType { Id = 386, MimeId = 748, Extension = "xlam", IsDefault = true }
                , new MimeType { Id = 381, MimeId = 747, Extension = "xlc", IsDefault = true }
                , new MimeType { Id = 737, MimeId = 1342, Extension = "xlf", IsDefault = true }
                , new MimeType { Id = 382, MimeId = 747, Extension = "xlm", IsDefault = true }
                , new MimeType { Id = 383, MimeId = 747, Extension = "xls", IsDefault = true }
                , new MimeType { Id = 387, MimeId = 749, Extension = "xlsb", IsDefault = true }
                , new MimeType { Id = 388, MimeId = 750, Extension = "xlsm", IsDefault = true }
                , new MimeType { Id = 456, MimeId = 951, Extension = "xlsx", IsDefault = true }
                , new MimeType { Id = 384, MimeId = 747, Extension = "xlt", IsDefault = true }
                , new MimeType { Id = 389, MimeId = 751, Extension = "xltm", IsDefault = true }
                , new MimeType { Id = 457, MimeId = 957, Extension = "xltx", IsDefault = true }
                , new MimeType { Id = 385, MimeId = 747, Extension = "xlw", IsDefault = true }
                , new MimeType { Id = 821, MimeId = 1541, Extension = "xm", IsDefault = true }
                , new MimeType { Id = 754, MimeId = 1360, Extension = "xml", IsDefault = true }
                , new MimeType { Id = 1004, MimeId = 1784, Extension = "xml", IsDefault = false }
                , new MimeType { Id = 449, MimeId = 861, Extension = "xo", IsDefault = true }
                , new MimeType { Id = 758, MimeId = 1365, Extension = "xop", IsDefault = true }
                , new MimeType { Id = 738, MimeId = 1343, Extension = "xpi", IsDefault = true }
                , new MimeType { Id = 759, MimeId = 1366, Extension = "xpl", IsDefault = true }
                , new MimeType { Id = 888, MimeId = 1621, Extension = "xpm", IsDefault = true }
                , new MimeType { Id = 322, MimeId = 662, Extension = "xpr", IsDefault = true }
                , new MimeType { Id = 414, MimeId = 786, Extension = "xps", IsDefault = true }
                , new MimeType { Id = 315, MimeId = 647, Extension = "xpw", IsDefault = true }
                , new MimeType { Id = 316, MimeId = 647, Extension = "xpx", IsDefault = true }
                , new MimeType { Id = 755, MimeId = 1360, Extension = "xsd", IsDefault = true }
                , new MimeType { Id = 756, MimeId = 1360, Extension = "xsl", IsDefault = true }
                , new MimeType { Id = 760, MimeId = 1367, Extension = "xslt", IsDefault = true }
                , new MimeType { Id = 532, MimeId = 1111, Extension = "xsm", IsDefault = true }
                , new MimeType { Id = 761, MimeId = 1368, Extension = "xspf", IsDefault = true }
                , new MimeType { Id = 377, MimeId = 741, Extension = "xul", IsDefault = true }
                , new MimeType { Id = 764, MimeId = 1369, Extension = "xvm", IsDefault = true }
                , new MimeType { Id = 765, MimeId = 1369, Extension = "xvml", IsDefault = true }
                , new MimeType { Id = 889, MimeId = 1622, Extension = "xwd", IsDefault = true }
                , new MimeType { Id = 827, MimeId = 1548, Extension = "xyz", IsDefault = true }
                , new MimeType { Id = 739, MimeId = 1344, Extension = "xz", IsDefault = true }
                , new MimeType { Id = 1005, MimeId = 1786, Extension = "yaml", IsDefault = true }
                , new MimeType { Id = 766, MimeId = 1370, Extension = "yang", IsDefault = true }
                , new MimeType { Id = 767, MimeId = 1371, Extension = "yin", IsDefault = true }
                , new MimeType { Id = 1006, MimeId = 1786, Extension = "yml", IsDefault = true }
                , new MimeType { Id = 1000, MimeId = 1780, Extension = "ymp", IsDefault = true }
                , new MimeType { Id = 740, MimeId = 1345, Extension = "z1", IsDefault = true }
                , new MimeType { Id = 741, MimeId = 1345, Extension = "z2", IsDefault = true }
                , new MimeType { Id = 742, MimeId = 1345, Extension = "z3", IsDefault = true }
                , new MimeType { Id = 743, MimeId = 1345, Extension = "z4", IsDefault = true }
                , new MimeType { Id = 744, MimeId = 1345, Extension = "z5", IsDefault = true }
                , new MimeType { Id = 745, MimeId = 1345, Extension = "z6", IsDefault = true }
                , new MimeType { Id = 746, MimeId = 1345, Extension = "z7", IsDefault = true }
                , new MimeType { Id = 747, MimeId = 1345, Extension = "z8", IsDefault = true }
                , new MimeType { Id = 576, MimeId = 1204, Extension = "zaz", IsDefault = true }
                , new MimeType { Id = 768, MimeId = 1372, Extension = "zip", IsDefault = true }
                , new MimeType { Id = 574, MimeId = 1203, Extension = "zir", IsDefault = true }
                , new MimeType { Id = 575, MimeId = 1203, Extension = "zirz", IsDefault = true }
                , new MimeType { Id = 293, MimeId = 605, Extension = "zmm", IsDefault = true }
          };
        }
        public static Mime[] Mimes
        {
            get { return __mimes.Value; }
        }
        public static MimeType[] MimeTypes
        {
            get { return __mimeTypes.Value; }
        }
        public static string GetExtension(string filenameOrExtension)
        {
            var result = filenameOrExtension?.ToLower();
            var dotIndex = result?.LastIndexOf('.') ?? -1;

            if (dotIndex >= 0)
            {
                result = result.Substring(dotIndex + 1);
            }
            
            return result;
        }
        public static Mime GetFullMime(string filenameOrExtension)
        {
            var result = null as Mime;
            var mimeTypeIndex = GetMimeTypeIndex(filenameOrExtension);

            if (mimeTypeIndex >= 0)
            {
                result = Mimes[MimeTypes[mimeTypeIndex].MimeId - 1];
            }

            return result;
        }
        public static int GetMimeTypeIndex(string filenameOrExtension)
        {
            var result = -1;
            var foe = filenameOrExtension?.ToLower();
            var extension = GetExtension(foe);

            if (!string.IsNullOrEmpty(extension))
            {
                var firstChar = extension[0];
                var startIndex = -1;
                var endIndex = MimeTypes.Length;

                if (char.IsLetterOrDigit(firstChar))
                {
                    var indexPos = char.IsNumber(firstChar) ? ((int)firstChar - 48) : ((int)firstChar - 97 + 10);
                    startIndex = __mimeType_lookup[indexPos];

                    if (indexPos < 35)
                    {
                        endIndex = __mimeType_lookup[indexPos + 1];
                    }
                }

                if (startIndex >= 0)
                {
                    for (var i = startIndex; i < endIndex; i++)
                    {
                        if (string.Compare(MimeTypes[i].Extension, extension, true) == 0)
                        {
                            result = i;
                            break;
                        }
                    }
                }
            }

            return result;
        }
        public static string GetMimeType(string filenameOrExtension)
        {
            var result = "application/octet-stream";
            var mimeTypeIndex = GetMimeTypeIndex(filenameOrExtension);

            if (mimeTypeIndex >= 0)
            {
                result = Mimes[MimeTypes[mimeTypeIndex].MimeId - 1].Value;
            }
            
            return result;
        }
    }
}
