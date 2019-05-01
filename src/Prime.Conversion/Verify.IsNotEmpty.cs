namespace Prime.Conversion
{
    using System;

    public static partial class Verify
    {
        public static bool IsNotEmpty(this bool? value)
        {
            return !IsEmpty(value);
        }

        public static bool IsNotEmpty(this char value)
        {
            return !IsEmpty(value);
        }

        public static bool IsNotEmpty(this char? value)
        {
            return !IsEmpty(value);
        }

        public static bool IsNotEmpty(this DateTime value)
        {
            return !IsEmpty(value);
        }

        public static bool IsNotEmpty(this DateTime? value)
        {
            return !IsEmpty(value);
        }

        public static bool IsNotEmptyDate(object value)
        {
            return !IsNull(value);
        }

        public static bool IsNotEmpty(this TimeSpan value)
        {
            return !IsEmpty(value);
        }

        public static bool IsNotEmpty(this TimeSpan? value)
        {
            return !IsEmpty(value);
        }

        public static bool IsNotEmpty(this Guid value)
        {
            return !IsEmpty(value);
        }

        public static bool IsNotEmpty(this Guid? value)
        {
            return !IsEmpty(value);
        }

        public static bool IsNotEmptyGuid(object value)
        {
            return !IsNull(value);
        }

        public static bool IsNotEmpty(this short value)
        {
            return !IsEmpty(value);
        }

        public static bool IsNotEmpty(this short? value, bool allowZero = false)
        {
            return !IsEmpty(value, allowZero);
        }

        public static bool IsNotEmpty(this int value)
        {
            return !IsEmpty(value);
        }

        public static bool IsNotEmpty(this int? value, bool allowZero = false)
        {
            return !IsEmpty(value, allowZero);
        }

        public static bool IsNotEmpty(this long value)
        {
            return !IsEmpty(value);
        }

        public static bool IsNotEmpty(this long? value, bool allowZero = false)
        {
            return !IsEmpty(value, allowZero);
        }

        public static bool IsNotEmpty(this float value)
        {
            return !IsEmpty(value);
        }

        public static bool IsNotEmpty(this float? value, bool allowZero = false)
        {
            return !IsEmpty(value, allowZero);
        }

        public static bool IsNotEmpty(this double value)
        {
            return !IsEmpty(value);
        }

        public static bool IsNotEmpty(this double? value, bool allowZero = false)
        {
            return !IsEmpty(value, allowZero);
        }

        public static bool IsNotEmpty(this decimal value)
        {
            return !IsEmpty(value);
        }

        public static bool IsNotEmpty(this decimal? value, bool allowZero = false)
        {
            return !IsEmpty(value, allowZero);
        }

        public static bool IsNotEmpty(this string value, bool allowWhitespace = false)
        {
            return !IsEmpty(value, allowWhitespace);
        }

        public static bool IsNotEmptyString(object value, bool allowWhitespace = false)
        {
            return !IsEmptyString(value, allowWhitespace);
        }

        public static bool IsNotEmptyOrZero(this string value, bool allowWhitespace = false)
        {
            return !IsEmptyOrZero(value, allowWhitespace);
        }

        public static bool IsNotEmptyOrZeroString(object value, bool allowWhitespace = false)
        {
            return !IsEmptyOrZeroString(value, allowWhitespace);
        }

        public static bool IsNotEmpty(this byte[] value)
        {
            return !IsEmpty(value);
        }

        public static bool IsNotEmpty(object value)
        {
            return !IsNull(value);
        }

        public static bool IsNotEmptyAny(object value, bool allowZero = false)
        {
            return !IsEmptyAny(allowZero);
        }
    }
}