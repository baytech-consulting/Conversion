namespace Baytech.Conversion
{
    using System;
    using System.Reflection;

    public static partial class Fix
    {
        // bool
        public static bool IfEmpty(this bool? value, bool defaultValue)
        {
            return value ?? defaultValue;
        }

        public static bool IfEmpty(this string value, bool defaultValue)
        {
            return value.IfEmpty(defaultValue as bool?).Value;
        }

        public static bool IfEmpty(object value, bool defaultValue)
        {
            return IfEmpty(value, defaultValue as bool?).Value;
        }

        // bool?
        public static bool? IfEmpty(this bool? value, bool? defaultValue)
        {
            return value ?? defaultValue;
        }

        public static bool? IfEmpty(this string value, bool? defaultValue)
        {
            if (value.IsEmpty())
                return defaultValue;
            var clean = value.Trim().ToLower();
            if (clean == "true" || clean == "yes" || clean == "y")
                return true;
            if (clean == "false" || clean == "no" || clean == "n")
                return false;
            return defaultValue;
        }

        public static bool? IfEmpty(object value, bool? defaultValue)
        {
            if (Verify.IsNull(value))
                return defaultValue;
            if (value is string)
                return IfEmpty(value as string, defaultValue);
            if (value is bool)
                return Convert.ToBoolean(value);
            return defaultValue;
        }

        // bool - IfEmptyOrFalse
        public static bool IfEmptyOrFalse(this bool? value, bool defaultValue)
        {
            return value.IsNotEmpty() && value.Value ? true : defaultValue;
        }

        public static bool IfEmptyOrFalse(this string value, bool defaultValue)
        {
            return IfEmptyOrFalse(value, defaultValue as bool?).Value;
        }

        public static bool IfEmptyOrFalse(object value, bool defaultValue)
        {
            return IfEmptyOrFalse(value, defaultValue as bool?).Value;
        }

        // bool? - IfEmptyOrFalse
        public static bool? IfEmptyOrFalse(this bool? value, bool? defaultValue)
        {
            return value.IsNotEmpty() && value.Value ? true : defaultValue;
        }

        public static bool? IfEmptyOrFalse(this string value, bool? defaultValue)
        {
            if (value.IsEmpty())
                return defaultValue;
            var clean = value.Trim().ToLower();
            if (clean == "true")
                return true;
            return defaultValue;
        }

        public static bool? IfEmptyOrFalse(object value, bool? defaultValue)
        {
            if (Verify.IsNull(value))
                return defaultValue;
            if (value is string)
                return (value as string).IfEmptyOrFalse(defaultValue);
            if (value is bool)
                return (value as bool?).IfEmptyOrFalse(defaultValue);
            return defaultValue;
        }

        // char
        public static char IfEmpty(this char value, char defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static char IfEmpty(this char? value, char defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value.Value;
        }

        public static char IfEmpty(this string value, char defaultValue)
        {
            return IfEmpty(value, (char?) defaultValue) ?? defaultValue;
        }

        public static char IfEmpty(object value, char defaultValue)
        {
            return IfEmpty(value, (char?) defaultValue) ?? defaultValue;
        }

        // char?
        public static char? IfEmpty(this char value, char? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static char? IfEmpty(this char? value, char? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static char? IfEmpty(this string value, char? defaultValue)
        {
            if (value.IsEmpty())
                return defaultValue;
            if (value.Length == 1 && !value[0].IsEmpty())
                return value[0];
            return defaultValue;
        }

        public static char? IfEmpty(object value, char? defaultValue)
        {
            if (Verify.IsNull(value))
                return defaultValue;
            if (value is char)
                return ((char?) value).IfEmpty(defaultValue);
            if (value is string)
                return IfEmpty(value as string, defaultValue);
            return defaultValue;
        }

        // DateTime
        public static DateTime IfEmpty(this DateTime value, DateTime defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static DateTime IfEmpty(this DateTime? value, DateTime defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value.Value;
        }

        public static DateTime IfEmpty(this string value, DateTime defaultValue)
        {
            return IfEmpty(value, (DateTime?) defaultValue) ?? defaultValue;
        }

        public static DateTime IfEmpty(object value, DateTime defaultValue)
        {
            return IfEmpty(value, (DateTime?) defaultValue) ?? defaultValue;
        }

        // DateTime?
        public static DateTime? IfEmpty(this DateTime value, DateTime? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static DateTime? IfEmpty(this DateTime? value, DateTime? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static DateTime? IfEmpty(this string value, DateTime? defaultValue)
        {
            if (value.IsEmpty())
                return defaultValue;
            return ParseStringToDate(value).IfEmpty(defaultValue);
        }

        public static DateTime? IfEmpty(object value, DateTime? defaultValue)
        {
            if (Verify.IsNull(value))
                return defaultValue;
            return ParseStringToDate(value.ToString()).IfEmpty(defaultValue);
        }

        // Guid
        public static Guid IfEmpty(this Guid value, Guid defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static string IfEmpty(this Guid value, string defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value.ToString();
        }

        public static Guid IfEmpty(this Guid? value, Guid defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value.Value;
        }

        public static Guid IfEmpty(this string value, Guid defaultValue)
        {
            return IfEmpty(value, (Guid?) defaultValue) ?? defaultValue;
        }

        public static Guid IfEmpty(object value, Guid defaultValue)
        {
            return IfEmpty(value, (Guid?) defaultValue) ?? defaultValue;
        }

        // Guid?
        public static Guid? IfEmpty(this Guid value, Guid? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static Guid? IfEmpty(this Guid? value, Guid? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static Guid? IfEmpty(this string value, Guid? defaultValue)
        {
            if (value.IsEmpty())
                return defaultValue;
            if (value.IsGuid())
                return (new Guid(value) as Guid?).IfEmpty(defaultValue);
            return defaultValue;
        }

        public static Guid? IfEmpty(object value, Guid? defaultValue)
        {
            if (Verify.IsNull(value))
                return defaultValue;
            if (value is Guid)
                return IfEmpty((Guid) value, defaultValue);
            if (value is string)
                return IfEmpty(value as string, defaultValue);
            return defaultValue;
        }

        // short
        public static short IfEmpty(this short value, short defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static short IfEmpty(this short? value, short defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value.Value;
        }

        public static short IfEmpty(this int value, short defaultValue)
        {
            return value.IsEmpty() ? defaultValue : (short) value;
        }

        public static short IfEmpty(this int? value, short defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : (short) value.Value;
        }

        public static short IfEmpty(this long value, short defaultValue)
        {
            return value.IsEmpty() ? defaultValue : (short) value;
        }

        public static short IfEmpty(this long? value, short defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : (short) value.Value;
        }

        public static short IfEmpty(this double value, short defaultValue)
        {
            return value.IsEmpty() ? defaultValue : (short) value;
        }

        public static short IfEmpty(this double? value, short defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : (short) value.Value;
        }

        public static short IfEmpty(this float value, short defaultValue)
        {
            return value.IsEmpty() ? defaultValue : (short) value;
        }

        public static short IfEmpty(this float? value, short defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : (short) value.Value;
        }

        public static short IfEmpty(this decimal value, short defaultValue)
        {
            return value.IsEmpty() ? defaultValue : (short) value;
        }

        public static short IfEmpty(this decimal? value, short defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : (short) value.Value;
        }

        public static short IfEmpty(this string value, short defaultValue)
        {
            return IfEmpty(value, (short?) defaultValue) ?? defaultValue;
        }

        public static short IfEmpty(object value, short defaultValue)
        {
            return IfEmpty(value, (short?) defaultValue) ?? defaultValue;
        }

        // short?
        public static short? IfEmpty(this short value, short? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static short? IfEmpty(this short? value, short? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static short? IfEmpty(this int value, short? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : (short?) value;
        }

        public static short? IfEmpty(this int? value, short? defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : (short?) value;
        }

        public static short? IfEmpty(this long value, short? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : (short?) value;
        }

        public static short? IfEmpty(this long? value, short? defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : (short?) value;
        }

        public static short? IfEmpty(this double value, short? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : (short?) value;
        }

        public static short? IfEmpty(this double? value, short? defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : (short?) value;
        }

        public static short? IfEmpty(this float value, short? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : (short?) value;
        }

        public static short? IfEmpty(this float? value, short? defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : (short?) value;
        }

        public static short? IfEmpty(this decimal value, short? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : (short?) value;
        }

        public static short? IfEmpty(this decimal? value, short? defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : (short?) value;
        }

        public static short? IfEmpty(this string value, short? defaultValue)
        {
            return IfEmpty(value as object, defaultValue);
        }

        public static short? IfEmpty(object value, short? defaultValue)
        {
            if (Verify.IsNull(value))
                return defaultValue;
            if (!Verify.IsNumeric(value))
                return defaultValue;

            short valueConverted;

            if (value is string && (value as string).Contains("."))
                valueConverted = Convert.ToInt16(Convert.ToDouble(value));
            else
                valueConverted = Convert.ToInt16(value);

            return (valueConverted as short?).IfEmpty(defaultValue);
        }

        // int
        public static int IfEmpty(this short value, int defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static int IfEmpty(this short? value, int defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value.Value;
        }

        public static int IfEmpty(this int value, int defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static int IfEmpty(this int? value, int defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value.Value;
        }

        public static int IfEmpty(this long value, int defaultValue)
        {
            return value.IsEmpty() ? defaultValue : (int) value;
        }

        public static int IfEmpty(this long? value, int defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : (int) value.Value;
        }

        public static int IfEmpty(this double value, int defaultValue)
        {
            return value.IsEmpty() ? defaultValue : (int) value;
        }

        public static int IfEmpty(this double? value, int defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : (int) value.Value;
        }

        public static int IfEmpty(this float value, int defaultValue)
        {
            return value.IsEmpty() ? defaultValue : (int) value;
        }

        public static int IfEmpty(this float? value, int defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : (int) value.Value;
        }

        public static int IfEmpty(this decimal value, int defaultValue)
        {
            return value.IsEmpty() ? defaultValue : (int) value;
        }

        public static int IfEmpty(this decimal? value, int defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : (int) value.Value;
        }

        public static int IfEmpty(this string value, int defaultValue)
        {
            return IfEmpty(value, (int?) defaultValue) ?? defaultValue;
        }

        public static int IfEmpty(object value, int defaultValue)
        {
            return IfEmpty(value, (int?) defaultValue) ?? defaultValue;
        }

        // int?
        public static int? IfEmpty(this short value, int? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static int? IfEmpty(this short? value, int? defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value;
        }

        public static int? IfEmpty(this int value, int? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static int? IfEmpty(this int? value, int? defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value;
        }

        public static int? IfEmpty(this long value, int? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : (int?) value;
        }

        public static int? IfEmpty(this long? value, int? defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : (int?) value;
        }

        public static int? IfEmpty(this double value, int? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : (int?) value;
        }

        public static int? IfEmpty(this double? value, int? defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : (int?) value;
        }

        public static int? IfEmpty(this float value, int? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : (int?) value;
        }

        public static int? IfEmpty(this float? value, int? defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : (int?) value;
        }

        public static int? IfEmpty(this decimal value, int? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : (int?) value;
        }

        public static int? IfEmpty(this decimal? value, int? defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : (int?) value;
        }

        public static int? IfEmpty(this string value, int? defaultValue)
        {
            return IfEmpty(value as object, defaultValue);
        }

        public static int? IfEmpty(object value, int? defaultValue)
        {
            if (Verify.IsNull(value))
                return defaultValue;

            if (!Verify.IsNumeric(value))
                return defaultValue;

            int valueConverted;

            if (value is string && (value as string).Contains("."))
                valueConverted = Convert.ToInt32(Convert.ToDouble(value));
            else
                valueConverted = Convert.ToInt32(value);

            return (valueConverted as int?).IfEmpty(defaultValue);
        }

        // long
        public static long IfEmpty(this short value, long defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static long IfEmpty(this short? value, long defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value.Value;
        }

        public static long IfEmpty(this int value, long defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static long IfEmpty(this int? value, long defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value.Value;
        }

        public static long IfEmpty(this long value, long defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static long IfEmpty(this long? value, long defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value.Value;
        }

        public static long IfEmpty(this double value, long defaultValue)
        {
            return value.IsEmpty() ? defaultValue : (long) value;
        }

        public static long IfEmpty(this double? value, long defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : (long) value.Value;
        }

        public static long IfEmpty(this float value, long defaultValue)
        {
            return value.IsEmpty() ? defaultValue : (long) value;
        }

        public static long IfEmpty(this float? value, long defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : (long) value.Value;
        }

        public static long IfEmpty(this decimal value, long defaultValue)
        {
            return value.IsEmpty() ? defaultValue : (long) value;
        }

        public static long IfEmpty(this decimal? value, long defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : (long) value.Value;
        }

        public static long IfEmpty(this string value, long defaultValue)
        {
            return IfEmpty(value, (long?) defaultValue) ?? defaultValue;
        }

        public static long IfEmpty(object value, long defaultValue)
        {
            return IfEmpty(value, (long?) defaultValue) ?? defaultValue;
        }

        // long?
        public static long? IfEmpty(this short value, long? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static long? IfEmpty(this short? value, long? defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value;
        }

        public static long? IfEmpty(this int value, long? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static long? IfEmpty(this int? value, long? defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value;
        }

        public static long? IfEmpty(this long value, long? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static long? IfEmpty(this long? value, long? defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value;
        }

        public static long? IfEmpty(this double value, long? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : (long?) value;
        }

        public static long? IfEmpty(this double? value, long? defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : (long?) value;
        }

        public static long? IfEmpty(this float value, long? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : (long?) value;
        }

        public static long? IfEmpty(this float? value, long? defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : (long?) value;
        }

        public static long? IfEmpty(this decimal value, long? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : (long?) value;
        }

        public static long? IfEmpty(this decimal? value, long? defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : (long?) value;
        }

        public static long? IfEmpty(this string value, long? defaultValue)
        {
            return IfEmpty(value as object, defaultValue);
        }

        public static long? IfEmpty(object value, long? defaultValue)
        {
            if (Verify.IsNull(value))
                return defaultValue;
            if (!Verify.IsNumeric(value))
                return defaultValue;
            return (Convert.ToDouble(value) as double?).IfEmpty(defaultValue);
        }

        // double
        public static double IfEmpty(this short value, double defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static double IfEmpty(this short? value, double defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value.Value;
        }

        public static double IfEmpty(this int value, double defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static double IfEmpty(this int? value, double defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value.Value;
        }

        public static double IfEmpty(this long value, double defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static double IfEmpty(this long? value, double defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value.Value;
        }

        public static double IfEmpty(this double value, double defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static double IfEmpty(this double? value, double defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value.Value;
        }

        public static double IfEmpty(this float value, double defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static double IfEmpty(this float? value, double defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value.Value;
        }

        public static double IfEmpty(this decimal value, double defaultValue)
        {
            return value.IsEmpty() ? defaultValue : (double) value;
        }

        public static double IfEmpty(this decimal? value, double defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : (double) value.Value;
        }

        public static double IfEmpty(this string value, double defaultValue)
        {
            return IfEmpty(value, (double?) defaultValue) ?? defaultValue;
        }

        public static double IfEmpty(object value, double defaultValue)
        {
            return IfEmpty(value, (double?) defaultValue) ?? defaultValue;
        }

        // double?
        public static double? IfEmpty(this short value, double? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static double? IfEmpty(this short? value, double? defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value;
        }

        public static double? IfEmpty(this int value, double? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static double? IfEmpty(this int? value, double? defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value;
        }

        public static double? IfEmpty(this long value, double? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static double? IfEmpty(this long? value, double? defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value;
        }

        public static double? IfEmpty(this double value, double? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static double? IfEmpty(this double? value, double? defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value;
        }

        public static double? IfEmpty(this float value, double? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static double? IfEmpty(this float? value, double? defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value;
        }

        public static double? IfEmpty(this decimal value, double? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : (double?) value;
        }

        public static double? IfEmpty(this decimal? value, double? defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : (double?) value;
        }

        public static double? IfEmpty(this string value, double? defaultValue)
        {
            return IfEmpty(value as object, defaultValue);
        }

        public static double? IfEmpty(object value, double? defaultValue)
        {
            if (Verify.IsNull(value))
                return defaultValue;
            if (!Verify.IsNumeric(value))
                return defaultValue;
            return (Convert.ToDouble(value) as double?).IfEmpty(defaultValue);
        }

        // float
        public static float IfEmpty(this short value, float defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static float IfEmpty(this short? value, float defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value.Value;
        }

        public static float IfEmpty(this int value, float defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static float IfEmpty(this int? value, float defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value.Value;
        }

        public static float IfEmpty(this long value, float defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static float IfEmpty(this long? value, float defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value.Value;
        }

        public static float IfEmpty(this double value, float defaultValue)
        {
            return value.IsEmpty() ? defaultValue : (float) value;
        }

        public static float IfEmpty(this double? value, float defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : (float) value.Value;
        }

        public static float IfEmpty(this float value, float defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static float IfEmpty(this float? value, float defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value.Value;
        }

        public static float IfEmpty(this decimal value, float defaultValue)
        {
            return value.IsEmpty() ? defaultValue : (float) value;
        }

        public static float IfEmpty(this decimal? value, float defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : (float) value.Value;
        }

        public static float IfEmpty(this string value, float defaultValue)
        {
            return IfEmpty(value, (float?) defaultValue) ?? defaultValue;
        }

        public static float IfEmpty(object value, float defaultValue)
        {
            return IfEmpty(value, (float?) defaultValue) ?? defaultValue;
        }

        // float?
        public static float? IfEmpty(this short value, float? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static float? IfEmpty(this short? value, float? defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value;
        }

        public static float? IfEmpty(this int value, float? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static float? IfEmpty(this int? value, float? defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value;
        }

        public static float? IfEmpty(this long value, float? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static float? IfEmpty(this long? value, float? defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value;
        }

        public static float? IfEmpty(this double value, float? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : (float?) value;
        }

        public static float? IfEmpty(this double? value, float? defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : (float?) value;
        }

        public static float? IfEmpty(this float value, float? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static float? IfEmpty(this float? value, float? defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value;
        }

        public static float? IfEmpty(this decimal value, float? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : (float?) value;
        }

        public static float? IfEmpty(this decimal? value, float? defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : (float?) value;
        }

        public static float? IfEmpty(this string value, float? defaultValue)
        {
            return IfEmpty(value as object, defaultValue);
        }

        public static float? IfEmpty(object value, float? defaultValue)
        {
            if (Verify.IsNull(value))
                return defaultValue;
            if (!Verify.IsNumeric(value))
                return defaultValue;
            return (Convert.ToSingle(value) as float?).IfEmpty(defaultValue);
        }

        // decimal
        public static decimal IfEmpty(this short value, decimal defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static decimal IfEmpty(this short? value, decimal defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value.Value;
        }

        public static decimal IfEmpty(this int value, decimal defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static decimal IfEmpty(this int? value, decimal defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value.Value;
        }

        public static decimal IfEmpty(this long value, decimal defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static decimal IfEmpty(this long? value, decimal defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value.Value;
        }

        public static decimal IfEmpty(this double value, decimal defaultValue)
        {
            return value.IsEmpty() ? defaultValue : (decimal) value;
        }

        public static decimal IfEmpty(this double? value, decimal defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : (decimal) value.Value;
        }

        public static decimal IfEmpty(this float value, decimal defaultValue)
        {
            return value.IsEmpty() ? defaultValue : (decimal) value;
        }

        public static decimal IfEmpty(this float? value, decimal defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : (decimal) value.Value;
        }

        public static decimal IfEmpty(this decimal value, decimal defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static decimal IfEmpty(this decimal? value, decimal defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value.Value;
        }

        public static decimal IfEmpty(this string value, decimal defaultValue)
        {
            return IfEmpty(value, (decimal?) defaultValue) ?? defaultValue;
        }

        public static decimal IfEmpty(object value, decimal defaultValue)
        {
            return IfEmpty(value, (decimal?) defaultValue) ?? defaultValue;
        }

        // decimal?
        public static decimal? IfEmpty(this short value, decimal? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static decimal? IfEmpty(this short? value, decimal? defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value;
        }

        public static decimal? IfEmpty(this int value, decimal? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static decimal? IfEmpty(this int? value, decimal? defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value;
        }

        public static decimal? IfEmpty(this long value, decimal? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static decimal? IfEmpty(this long? value, decimal? defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value;
        }

        public static decimal? IfEmpty(this double value, decimal? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : (decimal?) value;
        }

        public static decimal? IfEmpty(this double? value, decimal? defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : (decimal?) value;
        }

        public static decimal? IfEmpty(this float value, decimal? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : (decimal?) value;
        }

        public static decimal? IfEmpty(this float? value, decimal? defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : (decimal?) value;
        }

        public static decimal? IfEmpty(this decimal value, decimal? defaultValue)
        {
            return value.IsEmpty() ? defaultValue : value;
        }

        public static decimal? IfEmpty(this decimal? value, decimal? defaultValue, bool allowZero = false)
        {
            return value.IsEmpty(allowZero) ? defaultValue : value;
        }

        public static decimal? IfEmpty(this string value, decimal? defaultValue)
        {
            return IfEmpty(value as object, defaultValue);
        }

        public static decimal? IfEmpty(object value, decimal? defaultValue, bool allowZero = false)
        {
            if (Verify.IsNull(value))
                return defaultValue;
            if (!Verify.IsNumeric(value))
                return defaultValue;
            return (Convert.ToDecimal(value) as decimal?).IfEmpty(defaultValue);
        }

        // string
        public static string IfEmpty(this string value, string defaultValue, bool allowWhitespace = false)
        {
            return value.IsEmpty(allowWhitespace) ? defaultValue : value;
        }

        public static string IfEmpty(object value, string defaultValue, bool allowWhitespace = false)
        {
            if (Verify.IsNull(value))
                return defaultValue;
            if (value is string)
                return (value as string).IfEmpty(defaultValue, allowWhitespace);
            return defaultValue;
        }

        // string - IfEmptyOrZero
        public static string IfEmptyOrZero(this string value, string defaultValue, bool allowWhitespace = false)
        {
            return value.IsEmptyOrZero(allowWhitespace) ? defaultValue : value;
        }

        public static string IfEmptyOrZero(object value, string defaultValue, bool allowWhitespace = false)
        {
            if (Verify.IsNull(value))
                return defaultValue;
            if (value is string)
                return (value as string).IfEmptyOrZero(defaultValue, allowWhitespace);
            return defaultValue;
        }

        // Enum
        public static T IfEmptyEnum<T>(this int value, T defaultValue) where T : struct
        {
            var enumValue = value.TryParseEnum<T>();

            if (enumValue.HasValue)
                return enumValue.Value;

            return defaultValue;
        }

        public static T IfEmptyEnum<T>(this int? value, T defaultValue) where T : struct
        {
            var enumValue = value.TryParseEnum<T>();

            if (enumValue.HasValue)
                return enumValue.Value;

            return defaultValue;
        }

        public static T IfEmptyEnum<T>(this string value, T defaultValue) where T : struct
        {
            return IfEmptyEnum(value, false, defaultValue);
        }

        public static T IfEmptyEnum<T>(this string value, bool ignoreCase, T defaultValue) where T : struct
        {
            var enumValue = value.TryParseEnum<T>(ignoreCase);

            if (enumValue.HasValue)
                return enumValue.Value;

            return defaultValue;
        }

        // Enum?
        public static T? IfEmptyEnum<T>(this int value, T? defaultValue) where T : struct
        {
            var enumValue = value.TryParseEnum<T>();

            if (enumValue.HasValue)
                return enumValue.Value;

            return defaultValue;
        }

        public static T? IfEmptyEnum<T>(this int? value, T? defaultValue) where T : struct
        {
            var enumValue = value.TryParseEnum<T>();

            if (enumValue.HasValue)
                return enumValue.Value;

            return defaultValue;
        }

        public static T? IfEmptyEnum<T>(this string value, T? defaultValue) where T : struct
        {
            return IfEmptyEnum(value, false, defaultValue);
        }

        public static T? IfEmptyEnum<T>(this string value, bool ignoreCase, T? defaultValue) where T : struct
        {
            var enumValue = value.TryParseEnum<T>(ignoreCase);

            if (enumValue.HasValue)
                return enumValue.Value;

            return defaultValue;
        }

        // If Value
        public static void IfValue<T>(this T value, Action<T> action)
        {
            var type = typeof(T);

            if (!type.GetTypeInfo().IsClass && !type.GetTypeInfo().IsInterface || value == null)
                return;

            action(value);
        }

        public static TReturn IfValue<T, TReturn>(this T value, Func<T, TReturn> returnValue, TReturn defaultValue)
        {
            var type = typeof(T);


            if (!type.GetTypeInfo().IsClass && !type.GetTypeInfo().IsInterface || value == null)
                return defaultValue;

            return returnValue(value);
        }

        public static void IfValue<T, TTarget>(this T value, Func<T, TTarget> returnValue, ref TTarget targetValue)
        {
            var type = typeof(T);

            if (!type.GetTypeInfo().IsClass && value == null)
                return;

            targetValue = returnValue(value);
        }
    }
}