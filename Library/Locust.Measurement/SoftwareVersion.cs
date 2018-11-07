using Locust.Conversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Measurement
{
    public class SoftwareVersion : ICloneable, IComparable, IComparable<SoftwareVersion>, IEquatable<SoftwareVersion>
    {
        private int? _major;
        public int Major
        {
            get
            {
                if (!_major.HasValue)
                {
                    _major = SafeClrConvert.ToInt32(MajorVersion);
                }

                return _major.Value;
            }
        }
        private string _majorVersion;
        public string MajorVersion
        {
            get { return _majorVersion; }
            set
            {
                _majorVersion = value;
                _major = null;
            }
        }
        private int? _minor;
        public int Minor
        {
            get
            {
                if (!_minor.HasValue)
                {
                    _minor = SafeClrConvert.ToInt32(MinorVersion);
                }

                return _minor.Value;
            }
        }
        private string _minorVersion;
        public string MinorVersion
        {
            get { return _minorVersion; }
            set
            {
                _minorVersion = value;
                _minor = null;
            }
        }
        private int? _revision;
        public int Revision
        {
            get
            {
                if (!_revision.HasValue)
                {
                    _revision = SafeClrConvert.ToInt32(RevisionNumber);
                }

                return _revision.Value;
            }
        }
        private string _revisionVersion;
        public string RevisionNumber
        {
            get { return _revisionVersion; }
            set
            {
                _revisionVersion = value;
                _revision = null;
            }
        }
        public int Patch { get { return Revision; } }
        public string PatchNumber { get { return RevisionNumber; } }
        private int? _build;
        public int Build
        {
            get
            {
                if (!_build.HasValue)
                {
                    _build = SafeClrConvert.ToInt32(BuildNumber);
                }

                return _build.Value;
            }
        }
        private string _buildVersion;
        public string BuildNumber
        {
            get { return _buildVersion; }
            set
            {
                _buildVersion = value;
                _build = null;
            }
        }
        public bool RC { get; set; }
        public bool Alpha { get; set; }
        public bool Beta { get; set; }
        public byte Stage { get; set; }
        private string _originalVersion;
        public string OriginalVersion
        {
            get { return _originalVersion; }
            set
            {
                _originalVersion = value;
                Parse(_originalVersion);
            }
        }
        public SoftwareVersion()
        {
        }
        public SoftwareVersion(string version)
        {
            OriginalVersion = version;
        }
        public void Parse(string version)
        {
            if (!string.IsNullOrEmpty(version))
            {
                var firstDotindex = version.IndexOf(".");
                var dashIndex = -1;
                var lastPart = "";
                var alphaIndex = -1;
                var hasAlpha = false;

                if (firstDotindex > 0)
                {
                    MajorVersion = version.Substring(0, firstDotindex);

                    var secondDotindex = version.IndexOf(".", firstDotindex + 1);
                    if (secondDotindex > 0)
                    {
                        MinorVersion = version.Substring(firstDotindex + 1, secondDotindex - firstDotindex - 1);

                        var revisionrpart = version.Substring(secondDotindex + 1);
                        var thirdDotIndex = revisionrpart.IndexOf('.');

                        if (thirdDotIndex >= 0)
                        {
                            RevisionNumber = revisionrpart.Substring(0, thirdDotIndex);
                            var buildPart = revisionrpart.Substring(thirdDotIndex + 1);

                            if (buildPart.Length > 0)
                            {
                                dashIndex = buildPart.IndexOf('-');

                                if (dashIndex >= 0)
                                {
                                    BuildNumber = buildPart.Substring(0, dashIndex);
                                    lastPart = buildPart.Substring(dashIndex + 1).ToLower();
                                }
                                else
                                {
                                    foreach (var ch in buildPart)
                                    {
                                        alphaIndex++;

                                        if (Char.IsLetter(ch))
                                        {
                                            hasAlpha = true;
                                            break;
                                        }
                                    }

                                    if (hasAlpha)
                                    {
                                        BuildNumber = buildPart.Substring(0, alphaIndex);
                                        lastPart = buildPart.Substring(alphaIndex).ToLower();
                                    }
                                    else
                                    {
                                        BuildNumber = buildPart;
                                    }
                                }
                            }
                        }
                        else
                        {
                            dashIndex = revisionrpart.IndexOf('-');

                            if (dashIndex >= 0)
                            {
                                RevisionNumber = revisionrpart.Substring(0, dashIndex);
                                lastPart = revisionrpart.Substring(dashIndex + 1).ToLower();
                            }
                            else
                            {
                                foreach (var ch in revisionrpart)
                                {
                                    alphaIndex++;

                                    if (Char.IsLetter(ch))
                                    {
                                        hasAlpha = true;
                                        break;
                                    }
                                }

                                if (hasAlpha)
                                {
                                    RevisionNumber = revisionrpart.Substring(0, alphaIndex);
                                    lastPart = revisionrpart.Substring(alphaIndex).ToLower();
                                }
                                else
                                {
                                    RevisionNumber = revisionrpart;
                                }
                            }
                        }
                    }
                    else
                    {
                        var minorPart = version.Substring(firstDotindex + 1);

                        dashIndex = minorPart.IndexOf('-');

                        if (dashIndex >= 0)
                        {
                            MinorVersion = minorPart.Substring(0, dashIndex);
                            lastPart = minorPart.Substring(dashIndex + 1).ToLower();
                        }
                        else
                        {
                            foreach (var ch in minorPart)
                            {
                                alphaIndex++;

                                if (Char.IsLetter(ch))
                                {
                                    hasAlpha = true;
                                    break;
                                }
                            }

                            if (hasAlpha)
                            {
                                MinorVersion = minorPart.Substring(0, alphaIndex);
                                lastPart = minorPart.Substring(alphaIndex).ToLower();
                            }
                            else
                            {
                                MinorVersion = minorPart;
                            }
                        }
                    }

                    if (!string.IsNullOrEmpty(lastPart))
                    {
                        Alpha = (lastPart.Contains("alpha") || lastPart[0] == 'a');
                        Beta = (lastPart.Contains("beta") || lastPart[0] == 'b');
                        RC = (lastPart.Contains("rc"));

                        lastPart = lastPart.Replace("alpha", "").Replace("beta", "").Replace("a", "").Replace("b", "").Replace("rc", "");

                        if (!string.IsNullOrEmpty(lastPart))
                        {
                            Stage = SafeClrConvert.ToByte(lastPart);
                        }
                    }
                }
            }
        }
        public static implicit operator SoftwareVersion(string version)
        {
            var result = new SoftwareVersion(version);

            return result;
        }
        public static implicit operator string(SoftwareVersion version)
        {
            return version.ToString();
        }
        public static bool operator ==(SoftwareVersion v1, SoftwareVersion v2)
        {
            if ((object)v1 == null)
            {
                return (object)v2 == null;
            }

            return v1.Equals(v2);
        }
        public static bool operator !=(SoftwareVersion v1, SoftwareVersion v2)
        {
            return !(v1 == v2);
        }
        public override string ToString()
        {
            if (string.IsNullOrEmpty(_originalVersion))
                return
                    MajorVersion + "." +
                    MinorVersion +
                    (Revision > 0 ? "." + RevisionNumber : "") +
                    (Build > 0 ? "." + BuildNumber : "") +
                    (Alpha || Beta || RC ? "-" : "") +
                    (Alpha ? "a" : "") +
                    (Beta ? "b" : "") +
                    (RC ? "rc" : "") +
                    (Stage > 0 ? Stage.ToString() : "");
            else
                return _originalVersion;
        }

        public object Clone()
        {
            return new SoftwareVersion
            {
                MajorVersion = this.MajorVersion,
                MinorVersion = this.MinorVersion,
                RevisionNumber = this.RevisionNumber,
                BuildNumber = this.BuildNumber,
                Alpha = this.Alpha,
                Beta = this.Beta,
                RC = this.RC,
                Stage = this.Stage
            };
        }

        public int CompareTo(object version)
        {
            if (version == null)
            {
                return 1;
            }

            var _version = version as SoftwareVersion;

            if (_version == null)
            {
                throw new ArgumentException("Argument must be SoftwareVersion");
            }

            if (this.Major != _version.Major)
            {
                if (this.Major > _version.Major)
                {
                    return 1;
                }
                return -1;
            }
            else
            {
                if (this.Minor != _version.Minor)
                {
                    if (this.Minor > _version.Minor)
                    {
                        return 1;
                    }
                    return -1;
                }
                else
                {
                    if (this.Revision != _version.Revision)
                    {
                        if (this.Revision > _version.Revision)
                        {
                            return 1;
                        }

                        return -1;
                    }
                    else
                    {
                        if (this.Build != _version.Build)
                        {
                            if (this.Build > _version.Build)
                            {
                                return 1;
                            }

                            return -1;
                        }

                        var s1 = (this.RC ? "1" : "0") + (this.Alpha ? "1" : "0") + (this.Beta ? "1" : "0") + Stage;
                        var s2 = (_version.RC ? "1" : "0") + (_version.Alpha ? "1" : "0") + (_version.Beta ? "1" : "0") + _version.Stage;

                        if (s1 != s2)
                        {
                            return string.Compare(s1, s2);
                        }

                        return 0;
                    }
                }
            }
        }

        public int CompareTo(SoftwareVersion version)
        {
            return CompareTo((object)version);
        }
        public override bool Equals(object obj)
        {
            var version = obj as SoftwareVersion;

            return !(version == null)
                && this.Major == version.Major
                && this.Minor == version.Minor
                && this.Revision == version.Revision
                && this.Build == version.Build
                && this.Revision == version.Revision
                && this.Alpha == version.Alpha
                && this.Beta == version.Beta
                && this.RC == version.RC
                && this.Stage == version.Stage;
        }
        public bool Equals(SoftwareVersion version)
        {
            return !(version == null)
                && this.Major == version.Major
                && this.Minor == version.Minor
                && this.Revision == version.Revision
                && this.Build == version.Build
                && this.Revision == version.Revision
                && this.Alpha == version.Alpha
                && this.Beta == version.Beta
                && this.RC == version.RC
                && this.Stage == version.Stage;
        }
        public static bool operator <(SoftwareVersion v1, SoftwareVersion v2)
        {
            if (v1 == null)
            {
                throw new ArgumentNullException("v1");
            }
            return v1.CompareTo(v2) < 0;
        }
        public static bool operator <=(SoftwareVersion v1, SoftwareVersion v2)
        {
            if (v1 == null)
            {
                throw new ArgumentNullException("v1");
            }
            return v1.CompareTo(v2) <= 0;
        }
        public static bool operator >(SoftwareVersion v1, SoftwareVersion v2)
        {
            return v2 < v1;
        }
        public static bool operator >=(SoftwareVersion v1, SoftwareVersion v2)
        {
            return v2 <= v1;
        }
        public override int GetHashCode()
        {
            int num = 0;

            num |= (this.Major & 127) << 22;
            num |= (this.Minor & 255) << 14;
            num |= (this.Revision & 255) << 6;
            num |= (this.Build & 63);
            num |= (this.RC ? 1 : 0) * 4 + (this.Alpha ? 1 : 0) * 2 + (this.Beta ? 1 : 0) + Stage;

            return num;
        }
    }
}
