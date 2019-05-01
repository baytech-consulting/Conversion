namespace Prime.Conversion
{
    using System;

    public static partial class Fix
    {
        // struct
        public static T IfNull<T>(this T? value, T defaultValue) where T : struct
        {
            if (value == null)
                return defaultValue;

            return value.Value;
        }

        public static T? IfNull<T>(this T? value, T? defaultValue) where T : struct
        {
            if (value == null)
                return defaultValue;

            return value.Value;
        }

        // bool
        public static bool IfNull(object value, bool defaultValue)
        {
            return IfNull(value, defaultValue as bool?).Value;
        }

        // bool?
        public static bool? IfNull(object value, bool? defaultValue)
        {
            if (Verify.IsNull(value))
                return defaultValue;
            if (value is bool)
                return (bool) value;
            return defaultValue;
        }

        // char
        public static char IfNull(object value, char defaultValue)
        {
            return IfNull(value, defaultValue as char?).Value;
        }

        // char?
        public static char? IfNull(object value, char? defaultValue)
        {
            if (Verify.IsNull(value))
                return defaultValue;
            if (value is char)
                return (char) value;
            if (value is string)
            {
                var valueStr = value as string;
                if (valueStr.Length == 1 && !valueStr[0].IsEmpty())
                    return valueStr[0];
            }
            return defaultValue;
        }

        // DateTime
        public static DateTime IfNull(object value, DateTime defaultValue)
        {
            return IfNull(value, defaultValue as DateTime?).Value;
        }

        // DateTime?
        public static DateTime? IfNull(object value, DateTime? defaultValue)
        {
            if (Verify.IsNull(value))
                return defaultValue;
            if (Verify.IsDate(value))
                return Convert.ToDateTime(value);
            return defaultValue;
        }

        // Guid
        public static Guid IfNull(object value, Guid defaultValue)
        {
            return IfNull(value, defaultValue as Guid?).Value;
        }

        // Guid?
        public static Guid? IfNull(object value, Guid? defaultValue)
        {
            if (Verify.IsNull(value))
                return defaultValue;
            if (value is Guid)
                return (Guid) value;
            var valueStr = value as string;
            if (valueStr != null && valueStr.IsGuid())
                return new Guid(valueStr);
            return defaultValue;
        }

        // short
        public static short IfNull(object value, short defaultValue)
        {
            return IfNull(value, defaultValue as short?).Value;
        }

        // short?
        public static short? IfNull(object value, short? defaultValue)
        {
            if (Verify.IsNull(value))
                return defaultValue;
            if (Verify.IsNumeric(value))
                return Convert.ToInt16(value);
            return defaultValue;
        }

        // int
        public static int IfNull(this string value, int defaultValue)
        {
            return IfNull(value, defaultValue as int?).Value;
        }

        public static int IfNull(object value, int defaultValue)
        {
            return IfNull(value, defaultValue as int?).Value;
        }

        // int?
        public static int? IfNull(this string value, int? defaultValue)
        {
            if (Verify.IsNull(value))
                return defaultValue;
            if (value.IsNumeric())
                return Convert.ToInt32(value);
            return defaultValue;
        }

        public static int? IfNull(object value, int? defaultValue)
        {
            if (Verify.IsNull(value))
                return defaultValue;
            if (Verify.IsNumeric(value))
                return Convert.ToInt32(value);
            return defaultValue;
        }

        // long
        public static long IfNull(this string value, long defaultValue)
        {
            return IfNull(value, defaultValue as long?).Value;
        }

        public static long IfNull(object value, long defaultValue)
        {
            return IfNull(value, defaultValue as long?).Value;
        }

        // long?
        public static long? IfNull(this string value, long? defaultValue)
        {
            if (Verify.IsNull(value))
                return defaultValue;
            if (value.IsNumeric())
                return Convert.ToInt64(value);
            return defaultValue;
        }

        public static long? IfNull(object value, long? defaultValue)
        {
            if (Verify.IsNull(value))
                return defaultValue;
            if (Verify.IsNumeric(value))
                return Convert.ToInt64(value);
            return defaultValue;
        }

        // float
        public static float IfNull(this string value, float defaultValue)
        {
            return IfNull(value, defaultValue as float?).Value;
        }

        public static float IfNull(object value, float defaultValue)
        {
            return IfNull(value, defaultValue as float?).Value;
        }

        // float?
        public static float? IfNull(this string value, float? defaultValue)
        {
            if (Verify.IsNull(value))
                return defaultValue;
            if (value.IsNumeric())
                return Convert.ToSingle(value);
            return defaultValue;
        }

        public static float? IfNull(object value, float? defaultValue)
        {
            if (Verify.IsNull(value))
                return defaultValue;
            if (Verify.IsNumeric(value))
                return Convert.ToSingle(value);
            return defaultValue;
        }

        // double
        public static double IfNull(this string value, double defaultValue)
        {
            return IfNull(value, defaultValue as double?).Value;
        }

        public static double IfNull(object value, double defaultValue)
        {
            return IfNull(value, defaultValue as double?).Value;
        }

        // double?
        public static double? IfNull(this string value, double? defaultValue)
        {
            if (Verify.IsNull(value))
                return defaultValue;
            if (value.IsNumeric())
                return Convert.ToDouble(value);
            return defaultValue;
        }

        public static double? IfNull(object value, double? defaultValue)
        {
            if (Verify.IsNull(value))
                return defaultValue;
            if (Verify.IsNumeric(value))
                return Convert.ToDouble(value);
            return defaultValue;
        }

        // decimal
        public static decimal IfNull(this string value, decimal defaultValue)
        {
            return IfNull(value, defaultValue as decimal?).Value;
        }

        public static decimal IfNull(object value, decimal defaultValue)
        {
            return IfNull(value, defaultValue as decimal?).Value;
        }

        // decimal?
        public static decimal? IfNull(this string value, decimal? defaultValue)
        {
            if (Verify.IsNull(value))
                return defaultValue;
            if (value.IsNumeric())
                return Convert.ToDecimal(value);
            return defaultValue;
        }

        public static decimal? IfNull(object value, decimal? defaultValue)
        {
            if (Verify.IsNull(value))
                return defaultValue;
            if (Verify.IsNumeric(value))
                return Convert.ToDecimal(value);
            return defaultValue;
        }

        // string
        public static string IfNull(this string value, string defaultValue)
        {
            return value ?? defaultValue;
        }

        public static string IfNull(object value, string defaultValue)
        {
            if (Verify.IsNull(value))
                return defaultValue;
            if (value is string)
                return Convert.ToString(value);
            return defaultValue;
        }
    }
}