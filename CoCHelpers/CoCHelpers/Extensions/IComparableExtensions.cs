using System;

namespace CoCHelpers.Extensions
{
    public static class IComparableExtensions
    {
        public static bool IsBetween<T>(this T t, T min, T max) where T : IComparable
        {
            return t.CompareTo(min) >= 0 && t.CompareTo(max) <= 0;
        }
    }
}
