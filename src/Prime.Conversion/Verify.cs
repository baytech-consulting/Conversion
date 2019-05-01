namespace Baytech.Conversion
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text.RegularExpressions;

    public static partial class Verify
    {
        /// <summary>
        ///     Converts a string to Int32? or returns defaultValue if can not convert
        /// </summary>
        /// <param name="value">The value to be converted</param>
        /// <param name="defaultValue">The default value if conversion fails</param>
        /// <returns>The value as a Int32?</returns>
        public static Int32? ToInt32N(this string value, Int32? defaultValue)
        {
            Int32 newValue;

            return Int32.TryParse(value, out newValue)
                ? newValue
                : defaultValue;
        }

        /// <summary>
        ///     Converts a string to DateTime? or returns null if can not convert
        /// </summary>
        /// <param name="value">The value to be converted</param>
        /// <returns>The value as a DateTime?</returns>
        public static DateTime? ToDateTimeN(this string value)
        {
            return ToDateTimeN(value, null);
        }

        /// <summary>
        ///     Converts a string to DateTime? or returns defaultValue if can not convert
        /// </summary>
        /// <param name="value">The value to be converted</param>
        /// <param name="defaultValue">The default value if conversion fails</param>
        /// <returns>The value as a DateTime?</returns>
        public static DateTime? ToDateTimeN(this string value, DateTime? defaultValue)
        {
            DateTime newValue;

            if (DateTime.TryParse(value, out newValue))
            {
                return newValue == DateTime.MinValue
                    ? defaultValue
                    : newValue;
            }

            return defaultValue;
        }

        /// <summary>
        ///     Converts a string to decimal? or returns defaultValue if can not convert
        /// </summary>
        /// <param name="value">The value to be converted</param>
        /// <param name="defaultValue">The default value if conversion fails</param>
        /// <returns>The value as a decimal?</returns>
        public static decimal? ToDecimalN(this string value, decimal? defaultValue)
        {
            decimal newValue;

            var strippedValue = value.StripNonDecimal();

            return decimal.TryParse(strippedValue, out newValue)
                ? newValue
                : defaultValue;
        }

        public static bool IsGuid(this string value)
        {
            if (value.IsEmpty())
                return false;

            return Regex.IsMatch(value,
                "^(\\{){0,1}[0-9a-fA-F]{8}\\-[0-9a-fA-F]{4}\\-[0-9a-fA-F]{4}\\-[0-9a-fA-F]{4}\\-[0-9a-fA-F]{12}(\\}){0,1}$");
        }

        public static bool IsGuid(object value)
        {
            if (IsNull(value))
                return false;
            if (value is Guid)
                return true;
            return Convert.ToString(value).IsGuid();
        }

        public static bool IsNumeric(this string value)
        {
            //return Microsoft.VisualBasic.Information.IsNumeric(value);

            double retNum;
            return Double.TryParse(value, NumberStyles.Any, NumberFormatInfo.InvariantInfo, out retNum);
        }

        public static bool IsNumeric(object value)
        {
            return IsNumeric(Convert.ToString(value));
        }

        public static bool IsDate(this string value)
        {
            return Fix.ParseStringToDate(value) != null;
        }

        public static bool IsDate(object value)
        {
            return IsDate(Convert.ToString(value));
        }

        public static string IfInvalidSsn(this string value, string defaultValue)
        {
            return IsSsn(value) ? value : defaultValue.IfEmpty("");
        }

        public static string IfInvalidEin(this string value, string defaultValue)
        {
            return IsEin(value) ? value : defaultValue.IfEmpty("");
        }

        public static string IfInvalidDuns(this string value, string defaultValue)
        {
            return IsDuns(value) ? value : defaultValue.IfEmpty("");
        }

        public static string IfInvalidUsaPhone(this string value, string defaultValue)
        {
            return IsUsaPhone(value) ? Fix.ScrubNumber(value.IfEmpty("")) : defaultValue.IfEmpty("");
        }

        public static string IfInvalidUsaZipcode(this string value, string defaultValue)
        {
            return IsUsaZipcode(value) ? value : defaultValue.IfEmpty("");
        }

        public static string IfInvalidEmail(this string value, string defaultValue)
        {
            return IsEmail(value) ? value : defaultValue.IfEmpty("");
        }

        public static bool IsSsn(this string value)
        {
            if (IsEmpty(value))
                return false;

            return Regex.IsMatch(value, Fix.SsnRegex);
        }

        public static bool IsEin(this string value)
        {
            if (IsEmpty(value))
                return false;

            return Regex.IsMatch(value, Fix.EinRegex);
        }

        public static bool IsDuns(this string value)
        {
            if (IsEmpty(value))
                return false;

            return Regex.IsMatch(value, Fix.DunsRegex);
        }

        public static bool IsEmail(this string value)
        {
            if (IsEmpty(value))
                return false;

            return Regex.IsMatch(value,
                @"\A(?:(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\]))\Z",
                RegexOptions.IgnoreCase);
        }

        public static bool IsUsaPhone(this string value)
        {
            if (IsEmpty(value))
                return false;

            return Regex.IsMatch(value, Fix.UsaPhoneRegex);
        }

        public static bool IsUsaZipcode(this string value)
        {
            if (IsEmpty(value))
                return false;

            return Regex.IsMatch(value, Fix.UsaZipcodeRegex);
        }

        public static bool IsNotSsn(this string value)
        {
            return !value.IsSsn();
        }

        public static bool IsNotEin(this string value)
        {
            return !value.IsEin();
        }

        public static bool IsNotDuns(this string value)
        {
            return !value.IsDuns();
        }

        public static bool IsNotEmail(this string value)
        {
            return !value.IsEmail();
        }

        public static bool IsNotUsaPhone(this string value)
        {
            return !value.IsUsaPhone();
        }

        public static bool IsNotUsaZipcode(this string value)
        {
            return !value.IsUsaZipcode();
        }

        public static bool IsTrue(this bool? value)
        {
            return value != null && value.Value;
        }

        public static bool IsFalse(this bool? value)
        {
            return value == null || !value.Value;
        }

        public static TValue Get<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
        {
            if (dictionary.ContainsKey(key))
                return dictionary[key];

            return defaultValue;
        }
    }
}