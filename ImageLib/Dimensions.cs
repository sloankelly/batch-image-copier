using System;

namespace ImageLib
{
    public struct Dimensions : IComparable, IComparable<Dimensions>
    {
        public int Width;
        public int Height;

        public int CompareTo(object obj)
        {
            if (!(obj is Dimensions))
                return 0;

            var other = (Dimensions)obj;

            var tmp = other.Width * other.Height;

            return (Width * Height) - tmp;
        }

        public static bool operator ==(Dimensions obj, Dimensions other)
        {
            return obj.CompareTo(other) == 0;
        }

        public static bool operator !=(Dimensions obj, Dimensions other)
        {
            return obj.CompareTo(other) != 0;
        }

        public static bool operator >(Dimensions obj, Dimensions other)
        {
            return obj.CompareTo(other) > 0;
        }

        public static bool operator >=(Dimensions obj, Dimensions other)
        {
            return obj.CompareTo(other) >= 0;
        }

        public static bool operator <(Dimensions obj, Dimensions other)
        {
            return obj.CompareTo(other) < 0;
        }

        public static bool operator <=(Dimensions obj, Dimensions other)
        {
            return obj.CompareTo(other) <= 0;
        }

        int IComparable<Dimensions>.CompareTo(Dimensions other)
        {
            return CompareTo(other);
        }

        public override bool Equals(object obj)
        {
            return CompareTo(obj) == 0;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}