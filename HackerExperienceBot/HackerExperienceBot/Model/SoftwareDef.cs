using System;

namespace HackerExperienceBot.Model
{
    public enum SoftwareType
    {
        Unknown,
        Cracker,
        Hasher,
        SshExploit,
        FtpExploit,
        Seeker
    }

    public class SoftwareDef
    {
        public SoftwareType Type { get; }
        public SoftwareVersion Version { get; }

        public SoftwareDef(SoftwareType type, SoftwareVersion version)
        {
            Type = type;
            Version = version;
        }

        public override string ToString()
        {
            return $"{Type} v{Version}";
        }
    }

    public class SoftwareVersion : IComparable<SoftwareVersion>
    {
        public int Major { get; }
        public int Minor { get; }

        public SoftwareVersion(int major, int minor)
        {
            Major = major;
            Minor = minor;
        }

        protected bool Equals(SoftwareVersion other)
        {
            return Major == other.Major && Minor == other.Minor;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SoftwareVersion) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Major * 397) ^ Minor;
            }
        }

        public static bool operator ==(SoftwareVersion left, SoftwareVersion right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SoftwareVersion left, SoftwareVersion right)
        {
            return !Equals(left, right);
        }

        public int CompareTo(SoftwareVersion other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var majorComparison = Major.CompareTo(other.Major);
            if (majorComparison != 0) return majorComparison;
            return Minor.CompareTo(other.Minor);
        }

        public override string ToString()
        {
            return $"{Major}.{Minor}";
        }
    }
}