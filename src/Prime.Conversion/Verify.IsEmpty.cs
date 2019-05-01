namespace Prime.Conversion
{
    using System;
    using System.Text.RegularExpressions;

    public static partial class Verify
    {
        public static bool IsEmpty(this bool? value)
        {
            return value == null;
        }

        public static bool IsEmptyOrFalse(this bool? value)
        {
            return value == null || !value.Value;
        }

        public static bool IsEmptyOrTrue(this bool? value)
        {
            return value == null || value.Value;
        }

        public static bool IsEmpty(this char value)
        {
            return value == Char.MinValue;
        }

        public static bool IsEmpty(this char? value)
        {
            return value == null || value == Char.MinValue;
        }

        public static bool IsEmpty(this DateTime value)
        {
            return value == DateTime.MinValue;
        }

        public static bool IsEmpty(this DateTime? value)
        {
            return value == null || value.Value.IsEmpty();
        }

        public static bool IsEmptyDate(object value)
        {
            if (IsNull(value))
                return true;
            if (value is string)
                return Fix.ParseStringToDate(value as string).IsEmpty();
            return Fix.ParseStringToDate(value.ToString()).IsEmpty();
        }

        public static bool IsEmpty(this TimeSpan value)
        {
            return value.TotalSeconds.Equals(0);
        }

        public static bool IsEmpty(this TimeSpan? value)
        {
            return value == null || value.Value.IsEmpty();
        }

        public static bool IsEmpty(this Guid value)
        {
            return value == Guid.Empty;
        }

        public static bool IsEmpty(this Guid? value)
        {
            return value == null || value.Value == Guid.Empty;
        }

        public static bool IsEmptyGuid(object value)
        {
            if (IsNull(value))
                return true;
            if (value is Guid)
                return ((Guid) value).IsEmpty();
            if (value is string)
            {
                var valueStr = value as string;
                if (valueStr.IsGuid())
                    return new Guid(valueStr).IsEmpty();
            }
            return true;
        }

        public static bool IsEmpty(this short value)
        {
            return value == 0;
        }

        public static bool IsEmpty(this short? value, bool allowZero = false)
        {
            return value == null || value.Value.Equals(0) && !allowZero;
        }

        public static bool IsEmpty(this int value)
        {
            return value == 0;
        }

        public static bool IsEmpty(this int? value, bool allowZero = false)
        {
            return value == null || value.Value.Equals(0) && !allowZero;
        }

        public static bool IsEmpty(this long value)
        {
            return value == 0L;
        }

        public static bool IsEmpty(this long? value, bool allowZero = false)
        {
            return value == null || value.Value.Equals(0L) && !allowZero;
        }

        public static bool IsEmpty(this float value)
        {
            return value.Equals(0.0F);
        }

        public static bool IsEmpty(this float? value, bool allowZero = false)
        {
            return value == null || value.Value.Equals(0.0F) && !allowZero;
        }

        public static bool IsEmpty(this double value)
        {
            return double.IsNaN(value) || value.Equals(0.0D);
        }

        public static bool IsEmpty(this double? value, bool allowZero = false)
        {
            return value == null || double.IsNaN(value.Value) || value.Value.Equals(0D) && !allowZero;
        }

        public static bool IsEmpty(this decimal value)
        {
            return value == 0.0M;
        }

        public static bool IsEmpty(this decimal? value, bool allowZero = false)
        {
            return value == null || value.Value.Equals(0M) && !allowZero;
        }

        public static bool IsEmpty(this string value, bool allowWhitespace = false)
        {
            return allowWhitespace ? string.IsNullOrEmpty(value) : string.IsNullOrWhiteSpace(value);
        }

        public static bool IsEmptyString(object value, bool allowWhitespace = false)
        {
            if (IsNull(value))
                return true;
            if (!(value is string))
                return true;
            return value.ToString().IsEmpty(allowWhitespace);
        }

        public static bool IsEmptyOrZero(this string value, bool allowWhitespace = false)
        {
            if (value.IsEmpty(allowWhitespace))
                return true;
            if (!Regex.Match(value, "[^0.]").Success)
                return true;
            return false;
        }

        public static bool IsEmptyOrZeroString(object value, bool allowWhitespace = false)
        {
            if (IsNull(value))
                return true;
            if (!(value is string))
                return true;
            return value.ToString().IsEmptyOrZero(allowWhitespace);
        }

        public static bool IsEmpty(this byte[] value)
        {
            return value == null || value.Length < 1;
        }

        public static bool IsNull(object value)
        {
            return value == null ;
        }

        public static bool IsEmptyAny(object value, bool allowZero = false)
        {
            if (value == null)
                return true;
            if (value is string)
                return (value as string).IsEmpty();
            if (value is Guid?)
                return (value as Guid?).IsEmpty();
            if (value is DateTime)
                return (value as DateTime?).IsEmpty();
            if (value is long?)
                return (value as long?).IsEmpty(allowZero);
            if (value is int?)
                return (value as int?).IsEmpty(allowZero);
            if (value is double?)
                return (value as double?).IsEmpty(allowZero);
            if (value is decimal?)
                return (value as decimal?).IsEmpty(allowZero);
            if (value is bool?)
                return (value as bool?).IsEmpty();
            if (value is float?)
                return (value as float?).IsEmpty(allowZero);
            if (value is short?)
                return (value as short?).IsEmpty(allowZero);
            if (value is Char?)
                return (value as Char?).IsEmpty();
            if (value is byte[])
                return (value as byte[]).IsEmpty();
            return true;
        }
    }
}