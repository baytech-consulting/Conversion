namespace Baytech.Conversion
{
    using System;

    public static partial class Fix
    {
        // Numeric
        public static string ToStringIfEmpty(this short value, string defaultValue)
        {
            if (value.IsEmpty())
                return defaultValue;
            return value.ToString();
        }

        public static string ToStringIfEmpty(this short? value, string defaultValue)
        {
            if (value.IsEmpty())
                return defaultValue;
            return value.Value.ToString();
        }

        public static string ToStringIfEmpty(this int value, string defaultValue)
        {
            if (value.IsEmpty())
                return defaultValue;
            return value.ToString();
        }

        public static string ToStringIfEmpty(this int? value, string defaultValue)
        {
            if (value.IsEmpty())
                return defaultValue;
            return value.Value.ToString();
        }

        public static string ToStringIfEmpty(this long value, string defaultValue)
        {
            if (value.IsEmpty())
                return defaultValue;
            return value.ToString();
        }

        public static string ToStringIfEmpty(this long? value, string defaultValue)
        {
            if (value.IsEmpty())
                return defaultValue;
            return value.Value.ToString();
        }

        public static string ToStringIfEmpty(this double value, string defaultValue)
        {
            if (value.IsEmpty())
                return defaultValue;
            return value.ToString();
        }

        public static string ToStringIfEmpty(this double? value, string defaultValue)
        {
            if (value.IsEmpty())
                return defaultValue;
            return value.Value.ToString();
        }

        public static string ToStringIfEmpty(this float value, string defaultValue)
        {
            if (value.IsEmpty())
                return defaultValue;
            return value.ToString();
        }

        public static string ToStringIfEmpty(this float? value, string defaultValue)
        {
            if (value.IsEmpty())
                return defaultValue;
            return value.Value.ToString();
        }

        public static string ToStringIfEmpty(this decimal value, string defaultValue)
        {
            if (value.IsEmpty())
                return defaultValue;
            return value.ToString();
        }

        public static string ToStringIfEmpty(this decimal? value, string defaultValue)
        {
            if (value.IsEmpty())
                return defaultValue;
            return value.Value.ToString();
        }

        // Other
        public static string ToStringIfEmpty(this bool? value, string defaultValue)
        {
            if (value.IsEmpty())
                return defaultValue;
            return value.Value.ToString();
        }

        public static string ToStringIfEmpty(this char value, string defaultValue)
        {
            if (value.IsEmpty())
                return defaultValue;
            return value.ToString();
        }

        public static string ToStringIfEmpty(this char? value, string defaultValue)
        {
            if (value.IsEmpty())
                return defaultValue;
            return value.Value.ToString();
        }

        public static string ToStringIfEmpty(this Guid value, string defaultValue)
        {
            if (value.IsEmpty())
                return defaultValue;
            return value.ToString();
        }

        public static string ToStringIfEmpty(this Guid? value, string defaultValue)
        {
            if (value.IsEmpty())
                return defaultValue;
            return value.Value.ToString();
        }

        public static string ToStringIfEmpty(this DateTime value, string defaultValue)
        {
            if (value.IsEmpty())
                return defaultValue;
            return value.ToString();
        }

        public static string ToStringIfEmpty(this DateTime? value, string defaultValue)
        {
            if (value.IsEmpty())
                return defaultValue;
            return value.Value.ToString();
        }

        public static string ToShortDateStringIfEmpty(this DateTime value, string defaultValue)
        {
            if (value.IsEmpty())
                return defaultValue;
            return value.ToString("d");
        }

        public static string ToShortDateStringIfEmpty(this DateTime? value, string defaultValue)
        {
            if (value.IsEmpty())
                return defaultValue;
            return value.Value.ToString("d");
        }
    }
}