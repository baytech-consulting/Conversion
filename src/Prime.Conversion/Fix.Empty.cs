namespace Baytech.Conversion
{
    using System;

    public static partial class Fix
    {
        //bool
        public static bool Empty(object value, bool defaultValue)
        {
            return IfEmpty(value, defaultValue);
        }

        // bool - EmptyOrFalse
        public static bool EmptyOrFalse(object value, bool defaultValue)
        {
            return IfEmpty(value, defaultValue);
        }

        // char
        public static char Empty(char value, char defaultValue)
        {
            return value.IfEmpty(defaultValue);
        }

        public static char Empty(object value, char defaultValue)
        {
            return IfEmpty(value, defaultValue);
        }

        // DateTime
        public static DateTime Empty(DateTime value, DateTime defaultValue)
        {
            return value.IfEmpty(defaultValue);
        }

        public static DateTime Empty(object value, DateTime defaultValue)
        {
            return IfEmpty(value, defaultValue);
        }

        // DateTime?
        public static DateTime? Empty(DateTime? value, DateTime? defaultValue)
        {
            return value.IfEmpty(defaultValue);
        }

        public static DateTime? Empty(object value, DateTime? defaultValue)
        {
            return IfEmpty(value, defaultValue);
        }

        // Guid
        public static Guid Empty(Guid value, Guid defaultValue)
        {
            return value.IfEmpty(defaultValue);
        }

        public static Guid Empty(object value, Guid defaultValue)
        {
            return IfEmpty(value, defaultValue);
        }

        // Guid?
        public static Guid? Empty(Guid? value, Guid? defaultValue)
        {
            return value.IfEmpty(defaultValue);
        }

        public static Guid? Empty(object value, Guid? defaultValue)
        {
            return IfEmpty(value, defaultValue);
        }

        // short
        public static short Empty(short value, short defaultValue)
        {
            return value.IfEmpty(defaultValue);
        }

        public static short Empty(object value, short defaultValue)
        {
            return IfEmpty(value, defaultValue);
        }

        // int
        public static int Empty(int value, int defaultValue)
        {
            return value.IfEmpty(defaultValue);
        }

        public static int Empty(object value, int defaultValue)
        {
            return IfEmpty(value, defaultValue);
        }

        // long
        public static long Empty(long value, long defaultValue)
        {
            return value.IfEmpty(defaultValue);
        }

        public static long Empty(object value, long defaultValue)
        {
            return IfEmpty(value, defaultValue);
        }

        // double
        public static double Empty(double value, double defaultValue)
        {
            return value.IfEmpty(defaultValue);
        }

        public static double Empty(object value, double defaultValue)
        {
            return IfEmpty(value, defaultValue);
        }

        // decimal
        public static decimal Empty(decimal value, decimal defaultValue)
        {
            return value.IfEmpty(defaultValue);
        }

        public static decimal Empty(object value, decimal defaultValue)
        {
            return IfEmpty(value, defaultValue);
        }

        // string
        public static string Empty(string value, string defaultValue, bool allowWhitespace = false)
        {
            return value.IfEmpty(defaultValue);
        }

        public static string Empty(object value, string defaultValue, bool allowWhitespace = false)
        {
            return IfEmpty(value, defaultValue);
        }

        // string - EmptyOrZero
        public static string EmptyOrZero(string value, string defaultValue, bool allowWhitespace = false)
        {
            return value.IfEmptyOrZero(defaultValue, allowWhitespace);
        }

        public static string EmptyOrZero(object value, string defaultValue, bool allowWhitespace = false)
        {
            return IfEmptyOrZero(value, defaultValue, allowWhitespace);
        }
    }
}