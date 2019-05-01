namespace Prime.Conversion
{
    using System;

    public static partial class Fix
    {
        // short
        public static short IfEmptyOrNeg(this short value, short defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : value;
        }

        public static short IfEmptyOrNeg(this short? value, short defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : value.Value;
        }

        public static short IfEmptyOrNeg(this string value, short defaultValue)
        {
            return IfEmptyOrNeg(value, (short?) defaultValue) ?? defaultValue;
        }

        public static short IfEmptyOrNeg(object value, short defaultValue)
        {
            return IfEmptyOrNeg(value, (short?) defaultValue) ?? defaultValue;
        }

        // short?
        public static short? IfEmptyOrNeg(this short value, short? defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : value;
        }

        public static short? IfEmptyOrNeg(this short? value, short? defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : value;
        }

        public static short? IfEmptyOrNeg(this string value, short? defaultValue)
        {
            return IfEmptyOrNeg(value as object, defaultValue);
        }

        public static short? IfEmptyOrNeg(object value, short? defaultValue)
        {
            if (Verify.IsNull(value))
                return defaultValue;
            if (!Verify.IsNumeric(value))
                return defaultValue;
            return (Convert.ToInt16(value) as Int16?).IfEmptyOrNeg(defaultValue);
        }

        // int
        public static int IfEmptyOrNeg(this int value, int defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : value;
        }

        public static int IfEmptyOrNeg(this int? value, int defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : value.Value;
        }

        public static int IfEmptyOrNeg(this long value, int defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : (int) value;
        }

        public static int IfEmptyOrNeg(this long? value, int defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : (int) value.Value;
        }

        public static int IfEmptyOrNeg(this double value, int defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : (int) value;
        }

        public static int IfEmptyOrNeg(this double? value, int defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : (int) value.Value;
        }

        public static int IfEmptyOrNeg(this float value, int defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : (int) value;
        }

        public static int IfEmptyOrNeg(this float? value, int defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : (int) value.Value;
        }

        public static int IfEmptyOrNeg(this decimal value, int defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : (int) value;
        }

        public static int IfEmptyOrNeg(this decimal? value, int defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : (int) value.Value;
        }

        public static int IfEmptyOrNeg(this string value, int defaultValue)
        {
            return IfEmptyOrNeg(value, (int?) defaultValue) ?? defaultValue;
        }

        public static int IfEmptyOrNeg(object value, int defaultValue)
        {
            return IfEmptyOrNeg(value, (int?) defaultValue) ?? defaultValue;
        }

        // int?
        public static int? IfEmptyOrNeg(this int value, int? defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : value;
        }

        public static int? IfEmptyOrNeg(this int? value, int? defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : value;
        }

        public static int? IfEmptyOrNeg(this string value, int? defaultValue)
        {
            return IfEmptyOrNeg(value as object, defaultValue);
        }

        public static int? IfEmptyOrNeg(object value, int? defaultValue)
        {
            if (Verify.IsNull(value))
                return defaultValue;
            if (!Verify.IsNumeric(value))
                return defaultValue;
            return (Convert.ToInt32(value) as int?).IfEmptyOrNeg(defaultValue);
        }

        // long
        public static long IfEmptyOrNeg(this long value, long defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : value;
        }

        public static long IfEmptyOrNeg(this long? value, long defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : value.Value;
        }

        public static long IfEmptyOrNeg(this string value, long defaultValue)
        {
            return IfEmptyOrNeg(value, (long?) defaultValue) ?? defaultValue;
        }

        public static long IfEmptyOrNeg(object value, long defaultValue)
        {
            return IfEmptyOrNeg(value, (long?) defaultValue) ?? defaultValue;
        }

        // long?
        public static long? IfEmptyOrNeg(this long value, long? defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : value;
        }

        public static long? IfEmptyOrNeg(this long? value, long? defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : value;
        }

        public static long? IfEmptyOrNeg(this string value, long? defaultValue)
        {
            return IfEmptyOrNeg(value as object, defaultValue);
        }

        public static long? IfEmptyOrNeg(object value, long? defaultValue)
        {
            if (Verify.IsNull(value))
                return defaultValue;
            if (!Verify.IsNumeric(value))
                return defaultValue;
            return (Convert.ToInt64(value) as long?).IfEmptyOrNeg(defaultValue);
        }

        // double
        public static double IfEmptyOrNeg(this short value, double defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : value;
        }

        public static double IfEmptyOrNeg(this short? value, double defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : value.Value;
        }

        public static double IfEmptyOrNeg(this int value, double defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : value;
        }

        public static double IfEmptyOrNeg(this int? value, double defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : value.Value;
        }

        public static double IfEmptyOrNeg(this long value, double defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : value;
        }

        public static double IfEmptyOrNeg(this long? value, double defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : value.Value;
        }

        public static double IfEmptyOrNeg(this double value, double defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : value;
        }

        public static double IfEmptyOrNeg(this double? value, double defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : value.Value;
        }

        public static double IfEmptyOrNeg(this float value, double defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : value;
        }

        public static double IfEmptyOrNeg(this float? value, double defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : value.Value;
        }

        public static double IfEmptyOrNeg(this decimal value, double defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : (double) value;
        }

        public static double IfEmptyOrNeg(this decimal? value, double defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : (double) value.Value;
        }

        public static double IfEmptyOrNeg(this string value, double defaultValue)
        {
            return IfEmptyOrNeg(value, (double?) defaultValue) ?? defaultValue;
        }

        public static double IfEmptyOrNeg(object value, double defaultValue)
        {
            return IfEmptyOrNeg(value, (double?) defaultValue) ?? defaultValue;
        }

        // double?
        public static double? IfEmptyOrNeg(this double value, double? defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : value;
        }

        public static double? IfEmptyOrNeg(this double? value, double? defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : value;
        }

        public static double? IfEmptyOrNeg(this string value, double? defaultValue)
        {
            return IfEmptyOrNeg(value as object, defaultValue);
        }

        public static double? IfEmptyOrNeg(object value, double? defaultValue)
        {
            if (Verify.IsNull(value))
                return defaultValue;
            if (!Verify.IsNumeric(value))
                return defaultValue;
            return (Convert.ToDouble(value) as double?).IfEmptyOrNeg(defaultValue);
        }

        // float
        public static float IfEmptyOrNeg(this float value, float defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : value;
        }

        public static float IfEmptyOrNeg(this float? value, float defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : value.Value;
        }

        public static float IfEmptyOrNeg(this string value, float defaultValue)
        {
            return IfEmptyOrNeg(value, (float?) defaultValue) ?? defaultValue;
        }

        public static float IfEmptyOrNeg(object value, float defaultValue)
        {
            return IfEmptyOrNeg(value, (float?) defaultValue) ?? defaultValue;
        }

        // float?
        public static float? IfEmptyOrNeg(this float value, float? defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : value;
        }

        public static float? IfEmptyOrNeg(this float? value, float? defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : value;
        }

        public static float? IfEmptyOrNeg(this string value, float? defaultValue)
        {
            return IfEmptyOrNeg(value as object, defaultValue);
        }

        public static float? IfEmptyOrNeg(object value, float? defaultValue)
        {
            if (Verify.IsNull(value))
                return defaultValue;
            if (!Verify.IsNumeric(value))
                return defaultValue;
            return (Convert.ToSingle(value) as float?).IfEmptyOrNeg(defaultValue);
        }

        // decimal
        public static decimal IfEmptyOrNeg(this decimal value, decimal defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : value;
        }

        public static decimal IfEmptyOrNeg(this decimal? value, decimal defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : value.Value;
        }

        public static decimal IfEmptyOrNeg(this string value, decimal defaultValue)
        {
            return IfEmptyOrNeg(value, (decimal?) defaultValue) ?? defaultValue;
        }

        public static decimal IfEmptyOrNeg(object value, decimal defaultValue)
        {
            return IfEmptyOrNeg(value, (decimal?) defaultValue) ?? defaultValue;
        }

        // decimal?
        public static decimal? IfEmptyOrNeg(this decimal value, decimal? defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : value;
        }

        public static decimal? IfEmptyOrNeg(this decimal? value, decimal? defaultValue)
        {
            return value.IsEmptyOrNeg() ? defaultValue : value;
        }

        public static decimal? IfEmptyOrNeg(this string value, decimal? defaultValue)
        {
            return IfEmptyOrNeg(value as object, defaultValue);
        }

        public static decimal? IfEmptyOrNeg(object value, decimal? defaultValue)
        {
            if (Verify.IsNull(value))
                return defaultValue;
            if (!Verify.IsNumeric(value))
                return defaultValue;
            return (Convert.ToDecimal(value) as decimal?).IfEmptyOrNeg(defaultValue);
        }
    }
}