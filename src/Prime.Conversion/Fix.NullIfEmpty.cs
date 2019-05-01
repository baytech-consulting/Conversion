namespace Prime.Conversion
{
    using System;

    public static partial class Fix
    {
        public static char? NullIfEmpty(this char value)
        {
            return (value as char?).IfEmpty(null);
        }

        public static char? NullIfEmpty(this char? value)
        {
            return value.IfEmpty(null);
        }

        // DateTime
        public static DateTime? NullIfEmpty(this DateTime value)
        {
            return (value as DateTime?).IfEmpty(null);
        }

        public static DateTime? NullIfEmpty(this DateTime? value)
        {
            return value.IfEmpty(null);
        }

        // DateTime
        public static Guid? NullIfEmpty(Guid value)
        {
            return (value as Guid?).IfEmpty(null);
        }

        public static Guid? NullIfEmpty(Guid? value)
        {
            return value.IfEmpty(null);
        }

        // short
        public static short? NullIfEmpty(this short value)
        {
            return (value as short?).IfEmpty(null);
        }

        public static short? NullIfEmpty(this short? value)
        {
            return value.IfEmpty(null);
        }

        // int
        public static int? NullIfEmpty(this int value)
        {
            return (value as int?).IfEmpty(null as int?);
        }

        public static int? NullIfEmpty(this int? value)
        {
            return value.IfEmpty(null as int?);
        }

        // long
        public static long? NullIfEmpty(this long value)
        {
            return (value as long?).IfEmpty(null as long?);
        }

        public static long? NullIfEmpty(this long? value)
        {
            return value.IfEmpty(null as long?);
        }

        // float
        public static float? NullIfEmpty(this float value)
        {
            return (value as float?).IfEmpty(null as float?);
        }

        public static float? NullIfEmpty(this float? value)
        {
            return value.IfEmpty(null as float?);
        }

        // double
        public static double? NullIfEmpty(this double value)
        {
            return (value as double?).IfEmpty(null as double?);
        }

        public static double? NullIfEmpty(this double? value)
        {
            return value.IfEmpty(null as double?);
        }

        // decimal
        public static decimal? NullIfEmpty(this decimal value)
        {
            return (value as decimal?).IfEmpty(null as decimal?);
        }

        public static decimal? NullIfEmpty(this decimal? value)
        {
            return value.IfEmpty(null as decimal?);
        }

        // string - NullIfEmptyString
        public static string NullIfEmpty(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;
            return value;
        }

        public static string NullIfEmptyString(string value)
        {
            return value.NullIfEmpty();
        }

        public static string NullIfEmptyString(object value)
        {
            if (value == null)
                return null;

            return Convert.ToString(value).NullIfEmpty();
        }
    }
}