namespace HackerExperienceBot.Model
{
    public class IpAdress
    {
        public int P1 { get; }

        public int P2 { get; }

        public int P3 { get; }

        public int P4 { get; }

        public IpAdress(int p1, int p2, int p3, int p4)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
            P4 = p4;
        }

        protected bool Equals(IpAdress other)
        {
            return P1 == other.P1 && P2 == other.P2 && P3 == other.P3 && P4 == other.P4;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((IpAdress) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = P1;
                hashCode = (hashCode * 397) ^ P2;
                hashCode = (hashCode * 397) ^ P3;
                hashCode = (hashCode * 397) ^ P4;
                return hashCode;
            }
        }

        public static bool operator ==(IpAdress left, IpAdress right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(IpAdress left, IpAdress right)
        {
            return !Equals(left, right);
        }

        public override string ToString()
        {
            return $"{P1}.{P2}.{P3}.{P4}";
        }
    }
}