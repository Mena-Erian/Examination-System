using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Helpers
{
    public class Range<T> where T : IComparable<T>
    {
        public T Minimum { get; set; }
        public T Maximum { get; set; }
        public Range(T minimum, T maximum)
        {
            Minimum = minimum; // 5
            Maximum = maximum; // 10
        }

        public bool IsInRange(T value)//7
        {
            var min = value.CompareTo(Minimum);
            if (min == -1) return false;
            var max = value.CompareTo(Maximum);
            if (max == 1) return false;
            if (min >= 0 && max <= 0) return true;
            return false;
        }
        public T Length(Func<T, T, T> func)
        {
            return func(Maximum, Minimum);
        }
        public T Length()
        {
            return RangeExtensions.Length(this);
        }

    }

    public static class RangeExtensions
    {
        internal static T Length<T>(this Range<T> range) where T : IComparable<T>
        {
            if (IsNumericType(typeof(T)))
            {
                return (dynamic)range.Maximum - (dynamic)range.Minimum;
            }
            throw new InvalidOperationException($"Type {typeof(T)} is not numeric use this `T Length(Func<T, T, T> func)`");
        }

        private static bool IsNumericType(Type type)
        {
            return Type.GetTypeCode(type) switch
            {
                TypeCode.Byte or TypeCode.SByte or TypeCode.UInt16 or TypeCode.UInt32 or TypeCode.UInt64
                or TypeCode.Int16 or TypeCode.Int32 or TypeCode.Int64
                or TypeCode.Decimal or TypeCode.Double or TypeCode.Single => true,
                _ => false
            };
        }
    }
}
