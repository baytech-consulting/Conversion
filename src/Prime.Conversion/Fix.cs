namespace Baytech.Conversion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Text.RegularExpressions;

    public static partial class Fix
    {
        public const string EmailRegex =
            @"^(?:(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\]))$";

        public static int MonthDifference(this DateTime lValue, DateTime rValue)
        {
            return lValue.Month - rValue.Month + 12 * (lValue.Year - rValue.Year);
        }

        public const string SsnRegex = @"^[0-9]{3}-{0,1}[0-9]{2}-{0,1}[0-9]{4}$";
        public const string EinRegex = @"^[0-9]{2}-{0,1}[0-9]{7}$";
        public const string DunsRegex = @"^[0-9]{2}-{0,1}[0-9]{3}-{0,1}[0-9]{4}$";
        public const string NameRegex = @"^[A-Za-z '\.]*$";
        public const string StreetRegex = @"^[A-Za-z0-9 '\._/-]*$";
        public const string CityRegex = @"^[A-Za-z0-9 '\._/-]*$";
        public const string UsaPhoneRegex_OLD = @"^\(?[2-9][0-9]{2}(?:\) |[\)\-\.])?[2-9][0-9]{2}[\)\-\.]?[0-9]{4}$";
        public const string UsaPhoneRegex = @"\(?\d{3}\)?[-\.]? *\d{3}[-\.]? *[-\.]?\d{4}";
        
        public const string UsaZipcodeRegex = @"^[0-9]{0,2}[0-9]{3}(?:(?: - |-)[0-9]{4})?$";

        public static string RemoveNonStreetCharacters(this string value)
        {
            return Regex.Replace(value.IfEmpty(""), @"[^A-Za-z0-9 '\._/-]", "").NullIfEmpty();
        }

        public static string RemoveNonCityCharacters(this string value)
        {
            return Regex.Replace(value.IfEmpty(""), @"[^A-Za-z0-9 '\._/-]", "").NullIfEmpty();
        }

        public static string RemoveNonNameCharacters(this string value)
        {
            return Regex.Replace(value.IfEmpty(""), @"[^A-Za-z '\.]", "").NullIfEmpty();
        }

        public static string CamelCaseToDisplayName(string value)
        {
            if (value.IsEmpty())
                return "";

            var final = new StringBuilder();

            var matches = Regex.Match(value, "[A-Z]|[0-9][0-9]*");
            var matchIndexes = new List<int>();

            while (matches.Success)
            {
                matchIndexes.Add(matches.Index);
                matches = matches.NextMatch();
            }

            for (var i = 0; i < matchIndexes.Count; i++)
            {
                if (i > 0)
                    final.Append(" ");

                if (i + 1 < matchIndexes.Count)
                    final.Append(value.Substring(matchIndexes[i], matchIndexes[i + 1] - matchIndexes[i]));
                else
                    final.Append(value.Substring(matchIndexes[i]));
            }

            return final.ToString();
        }

        public static string Truncate(this string value, Int32 length, string continuedPhrase = "")
        {
            if (value == null)
                return null;

            if (value.IsEmpty() || length == 0)
                return String.Empty;

            if (length < 0 || value.Length <= length)
                return value;

            if (continuedPhrase.IsEmpty() || length - continuedPhrase.Length < 0)
                return value.Substring(0, length);
            return value.Substring(0, length - continuedPhrase.Length) + continuedPhrase;
        }

        public static DateTime? IfInvalidDate(this string dateString, DateTime? elsedate)
        {
            DateTime? dtReturn;

            if (dateString.IsEmpty())
                return elsedate;

            bool bSeperators;
            int iTemp;

            //First check that it is at least 6 characters or more.
            if (!(dateString.Length > 5))
                return elsedate;

            // Next, see if the framework can parse it.
            try
            {
                dtReturn = DateTime.Parse(dateString);
                return dtReturn;
            }
            catch
            {
            }

            //Check to see if it has any seperators. If not, it should parse to a int.
            try
            {
                iTemp = int.Parse(dateString);
                bSeperators = false;
            }
            catch
            {
                bSeperators = true;
            }

            if (!bSeperators)
            {
                int iMonth;
                int iDay;
                int iYear;

                if (dateString.Length == 6)
                {
                    iMonth = int.Parse(dateString.Substring(0, 2));
                    iDay = int.Parse(dateString.Substring(2, 2));
                    iYear = int.Parse(dateString.Substring(4, 2));
                    iTemp = DateTime.Now.Year;
                    iTemp = iTemp / 100;
                    iTemp = iTemp * 100;
                    iYear += iTemp;
                    try
                    {
                        return new DateTime(iYear, iMonth, iDay);
                    }
                    catch
                    {
                        return elsedate;
                    }
                }

                if (dateString.Length == 8)
                {
                    iMonth = int.Parse(dateString.Substring(0, 2));
                    iDay = int.Parse(dateString.Substring(2, 2));
                    iYear = int.Parse(dateString.Substring(4, 4));
                    try
                    {
                        return new DateTime(iYear, iMonth, iDay);
                    }
                    catch
                    {
                        return elsedate;
                    }
                }
                // Not a 6 or 8 digit number that was passed in. Any other
                // combination would have ambiguity, therefor it is an error.
                return elsedate;
            }
            // Looks like it is seperated by characters the framework doesn't support.
            // Next version will take this and parse it, but for now it is an error.
            return elsedate;
        }

        public static DateTime? ParseStringToDate(string dateString)
        {
            DateTime? dtReturn;

            if (dateString.IsEmpty())
                return null;

            bool bSeperators;

            //First check that it is at least 6 characters or more.
            if (!(dateString.Length > 5))
                throw new Exception("Date string not in correct format.");

            // Next, see if the framework can parse it.
            try
            {
                dtReturn = DateTime.Parse(dateString);
                return dtReturn;
            }
            catch
            {
            }

            int iTemp;

            //Check to see if it has any seperators. If not, it should parse to a int.
            try
            {
                iTemp = int.Parse(dateString);
                bSeperators = false;
            }
            catch
            {
                bSeperators = true;
            }

            if (!bSeperators)
            {
                int iMonth;
                int iDay;
                int iYear;

                if (dateString.Length == 6)
                {
                    iMonth = int.Parse(dateString.Substring(0, 2));
                    iDay = int.Parse(dateString.Substring(2, 2));
                    iYear = int.Parse(dateString.Substring(4, 2));

                    var yearParts = DateTime.Now.Year.ToString("D4").ToList();
                    var currYearBig = yearParts.GetFirst(2).Combine().IfEmpty(20);
                    var currYearSmall = yearParts.GetLast(2).Combine().IfEmpty(00);

                    if (iYear <= currYearSmall + 1)
                        iYear = currYearBig * 100 + iYear;
                    else
                        iYear = (currYearBig - 1) * 100 + iYear;

                    try
                    {
                        return new DateTime(iYear, iMonth, iDay);
                    }
                    catch
                    {
                        throw new Exception("Date string not in correct format.");
                    }
                }

                if (dateString.Length == 8)
                {
                    iMonth = int.Parse(dateString.Substring(0, 2));
                    iDay = int.Parse(dateString.Substring(2, 2));
                    iYear = int.Parse(dateString.Substring(4, 4));
                    try
                    {
                        return new DateTime(iYear, iMonth, iDay);
                    }
                    catch
                    {
                        throw new Exception("Date string not in correct format.");
                    }
                }
                // Not a 6 or 8 digit number that was passed in. Any other
                // combination would have ambiguity, therefor it is an error.
                throw new Exception("Date string not in correct format.");
            }
            // Looks like it is seperated by characters the framework doesn't support.
            // Next version will take this and parse it, but for now it is an error.
            throw new Exception("Date string not in correct format.");
        }

        public static string ScrubNumber(string phoneNumber)
        {
            return phoneNumber.StripNonNumbers().TrimStart('0', '1');
        }

        public static string StripNonNumbers(this string value, bool preserveNull = false)
        {
            if (value == null)
                return preserveNull ? null : "";

            return Regex.Replace(value, "[^0-9]", "");
        }

        public static string StripNumbers(this string value)
        {
            if (value == null)
                return "";
            return Regex.Replace(value, "[0-9]", "");
        }

        public static string StripNonLetters(this string value)
        {
            if (value == null)
                return "";

            return Regex.Replace(value, "[^A-Za-z]", "");
        }

        public static string StripNonDecimal(this string value)
        {
            if (value == null)
                return "";
            return Regex.Replace(value, "[^.0-9]", "");
        }

        public static int ToSecondsCheckForUnix(string value)
        {
            int lengthInSeconds;
            if (!int.TryParse(value, out lengthInSeconds))
            {
                // Check if Unix time
                var parts = value.Split(':');
                if (parts.Length == 3)
                {
                    var hours = Empty(parts[0], 0);
                    var mins = Empty(parts[1], 0);
                    var secs = Empty(parts[2], 0);

                    lengthInSeconds = hours * 60 * 60 + mins * 60 + secs;
                }
            }
            return lengthInSeconds;
        }

        public static DateTime CopyToTheMillisecond(this DateTime value)
        {
            if (value.IsEmpty())
                return DateTime.MinValue;

            return new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, value.Second,
                value.Millisecond);
        }

        public static DateTime CopyToTheMinute(this DateTime value)
        {
            if (value.IsEmpty())
                return DateTime.MinValue;

            return new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, 0);
        }

        public static DateTime? CopyToTheMillisecond(this DateTime? value)
        {
            if (value.IsEmpty())
                return null;

            return value.Value.CopyToTheMillisecond();
        }

        public static DateTime? CopyToTheMinute(this DateTime? value)
        {
            if (value.IsEmpty())
                return null;

            return value.Value.CopyToTheMinute();
        }

        public static string JoinPhoneAndExt(string phone, string ext)
        {
            if (phone == null && ext == null)
                return null;

            var joined = phone.IfEmpty("");

            if (ext.IsNotEmpty())
            {
                if (joined.Length > 0)
                    joined = joined + " ";

                joined = joined + ext;
            }

            return joined;
        }

        public static void SplitPhoneAndExt(string phoneAndExt, out string phone, out string ext)
        {
            phone = null;
            ext = null;

            if (phoneAndExt.IsEmpty())
                return;

            var splits = Regex.Replace(phoneAndExt, "[^0-9x]", "", RegexOptions.IgnoreCase).ToLower().Split(new[]
            {
                'x'
            }, StringSplitOptions.RemoveEmptyEntries);

            if (!splits.Any())
                return;

            phone = splits[0].TrimStart('0', '1');

            if (splits.Count() > 1)
            {
                ext = splits[1];
                return;
            }

            if (phone.Length <= 10)
                return;

            ext = phone.Substring(10);
            phone = phone.Substring(0, 10);
        }

        public static string ToFormattedSsn(this string value)
        {
            if (value == null)
                return null;

            var striped = value.StripNonNumbers();

            if (striped.Length != 9)
                return value;

            return striped.Substring(0, 3) + "-" + striped.Substring(3, 2) + "-" + striped.Substring(5);
        }

        public static string ToFormattedEin(this string value)
        {
            if (value == null)
                return null;

            var striped = value.StripNonNumbers();

            if (striped.Length != 9)
                return value;

            return striped.Substring(0, 2) + "-" + striped.Substring(2);
        }

        public static string ToFormattedDuns(this string value)
        {
            if (value == null)
                return null;

            var striped = value.StripNonNumbers();

            if (striped.Length != 9)
                return value;

            return striped.Substring(0, 2) + "-" + striped.Substring(2, 3) + "-" + striped.Substring(5);
        }

        public static string ToFormatedUsaPhone(this string value, bool useParens = false)
        {
            if (value == null)
                return null;

            var striped = value.StripNonNumbers().TrimStart('0', '1');

            if (striped.Length != 10)
                return value;

            if (useParens)
                return "(" + striped.Substring(0, 3) + ") " + striped.Substring(3, 3) + "-" + striped.Substring(6);

            return striped.Substring(0, 3) + "-" + striped.Substring(3, 3) + "-" + striped.Substring(6);
        }

        public static string[] Split(this string value, char seperator,
            StringSplitOptions splitOptions = StringSplitOptions.None)
        {
            return value.Split(new[]
            {
                seperator
            }, splitOptions);
        }

        public static string[] Split(this string value, string seperator,
            StringSplitOptions splitOptions = StringSplitOptions.None)
        {
            return value.Split(new[]
            {
                seperator
            }, splitOptions);
        }

        public static string[] SplitFirst(this string value, char seperator, int count = 1,
            StringSplitOptions splitOptions = StringSplitOptions.None)
        {
            return SplitFirst(value, new[]
            {
                seperator
            }, count, splitOptions);
        }

        public static string[] SplitFirst(this string value, char[] seperator, int count = 1,
            StringSplitOptions splitOptions = StringSplitOptions.None)
        {
            if (value == null)
                return new string[0];

            return SplitFirst(value.Split(seperator, splitOptions), count);
        }

        public static string[] SplitFirst(this string value, string seperator, int count = 1,
            StringSplitOptions splitOptions = StringSplitOptions.None)
        {
            return SplitFirst(value, new[]
            {
                seperator
            }, count, splitOptions);
        }

        public static string[] SplitFirst(this string value, string[] seperator, int count = 1,
            StringSplitOptions splitOptions = StringSplitOptions.None)
        {
            if (value == null)
                return new string[0];

            return SplitFirst(value.Split(seperator, splitOptions), count);
        }

        private static string[] SplitFirst(string[] splits, int count)
        {
            if (count < 1 || splits.Count() < count + 1)
                return splits;

            var splitList = splits.ToList();
            var adjusted = splitList.GetFirst(count);

            adjusted.Add(splitList.GetRange(count).Combine());

            return adjusted.ToArray();
        }

        public static string[] SplitLast(this string value, char seperator, int count = 1,
            StringSplitOptions splitOptions = StringSplitOptions.None)
        {
            return SplitLast(value, new[]
            {
                seperator
            }, count, splitOptions);
        }

        public static string[] SplitLast(this string value, char[] seperator, int count = 1,
            StringSplitOptions splitOptions = StringSplitOptions.None)
        {
            if (value == null)
                return new string[0];

            return SplitLast(value.Split(seperator, splitOptions), count);
        }

        public static string[] SplitLast(this string value, string seperator, int count = 1,
            StringSplitOptions splitOptions = StringSplitOptions.None)
        {
            return SplitLast(value, new[]
            {
                seperator
            }, count, splitOptions);
        }

        public static string[] SplitLast(this string value, string[] seperator, int count = 1,
            StringSplitOptions splitOptions = StringSplitOptions.None)
        {
            if (value == null)
                return new string[0];

            return SplitLast(value.Split(seperator, splitOptions), count);
        }

        private static string[] SplitLast(string[] splits, int count)
        {
            if (count < 1 || splits.Count() < count + 1)
                return splits;

            var splitList = splits.ToList();
            var adjusted = splitList.GetLast(count);

            adjusted.Insert(0, splitList.GetFirst(splitList.Count - count).Combine());

            return adjusted.ToArray();
        }

        public static string Combine(this ICollection<char> value, char seperator)
        {
            if (value == null)
                return null;

            return value.Aggregate(new StringBuilder(), (seed, item) =>
                {
                    if (seed.Length > 0 && seperator.IsNotEmpty())
                        seed.Append(seperator);
                    return seed.Append(item);
                },
                seed => seed.ToString());
        }

        public static string Combine(this ICollection<char> value, string seperator = null)
        {
            if (value == null)
                return null;

            return value.Aggregate(new StringBuilder(), (seed, item) =>
                {
                    if (seed.Length > 0 && seperator.IsNotEmpty())
                        seed.Append(seperator);
                    return seed.Append(item);
                },
                seed => seed.ToString());
        }

        public static string Combine(this ICollection<char> value, int index, int count, char seperator)
        {
            if (value == null)
                return null;

            return value.ToList().GetRange(index, count).Aggregate(new StringBuilder(), (seed, item) =>
                {
                    if (seed.Length > 0 && seperator.IsNotEmpty())
                        seed.Append(seperator);
                    return seed.Append(item);
                },
                seed => seed.ToString());
        }

        public static string Combine(this ICollection<char> value, int index, int count, string seperator = null)
        {
            if (value == null)
                return null;

            return value.ToList().GetRange(index, count).Aggregate(new StringBuilder(), (seed, item) =>
                {
                    if (seed.Length > 0 && seperator.IsNotEmpty())
                        seed.Append(seperator);
                    return seed.Append(item);
                },
                seed => seed.ToString());
        }

        public static string Combine(this ICollection<string> value, char seperator)
        {
            if (value == null)
                return null;

            return value.Aggregate(new StringBuilder(), (seed, item) =>
                {
                    if (seed.Length > 0 && seperator.IsNotEmpty())
                        seed.Append(seperator);
                    return seed.Append(item);
                },
                seed => seed.ToString());
        }

        public static string Combine(this ICollection<string> value, string seperator = null)
        {
            if (value == null)
                return null;

            return value.Aggregate(new StringBuilder(), (seed, item) =>
                {
                    if (seed.Length > 0 && seperator.IsNotEmpty())
                        seed.Append(seperator);
                    return seed.Append(item);
                },
                seed => seed.ToString());
        }

        public static string Combine(this ICollection<string> value, int index, int count, char seperator)
        {
            if (value == null)
                return null;

            return value.ToList().GetRange(index, count).Aggregate(new StringBuilder(), (seed, item) =>
                {
                    if (seed.Length > 0 && seperator.IsNotEmpty())
                        seed.Append(seperator);
                    return seed.Append(item);
                },
                seed => seed.ToString());
        }

        public static string Combine(this ICollection<string> value, int index, int count, string seperator = null)
        {
            if (value == null)
                return null;

            return value.ToList().GetRange(index, count).Aggregate(new StringBuilder(), (seed, item) =>
                {
                    if (seed.Length > 0 && seperator.IsNotEmpty())
                        seed.Append(seperator);
                    return seed.Append(item);
                },
                seed => seed.ToString());
        }

        public static List<T> GetRange<T>(this List<T> value, int index)
        {
            return value.GetRange(index, value.Count - index);
        }

        public static List<T> GetFirst<T>(this List<T> value, int count)
        {
            return value.GetRange(0, count);
        }

        public static List<T> GetLast<T>(this List<T> value, int count)
        {
            return value.GetRange(value.Count - count, count);
        }

        public static void RemoveRange<T>(this List<T> value, int index)
        {
            value.RemoveRange(index, value.Count - index);
        }

        // decimal
        public static decimal DirtyEmpty(string value, decimal defaultValue)
        {
            if (value == null)
                return defaultValue;
            var clean = Regex.Replace(value, "[^0-9.]", String.Empty);
            if (clean.Length == 0)
                return defaultValue;
            return Convert.ToDecimal(clean);
        }

        public static decimal DirtyEmpty(object value, decimal defaultValue)
        {
            if (value == null)
                return defaultValue;
            if (value is string)
                return DirtyEmpty(value as string, defaultValue);
            if (!Verify.IsNumeric(value))
                return defaultValue;
            return Empty(Convert.ToDecimal(value), defaultValue);
        }


        public static bool TryParseEnum<T>(this int value, out T result) where T : struct
        {
            var tryResult = TryParseEnum<T>(value);

            if (tryResult == null)
            {
                result = (T) Activator.CreateInstance(typeof(T));
                return false;
            }

            result = tryResult.Value;
            return true;
        }

        public static bool TryParseEnum<T>(this int? value, out T result) where T : struct
        {
            if (value == null)
            {
                result = (T) Activator.CreateInstance(typeof(T));
                return false;
            }

            var tryResult = TryParseEnum<T>(value);

            if (tryResult == null)
            {
                result = (T) Activator.CreateInstance(typeof(T));
                return false;
            }

            result = tryResult.Value;
            return true;
        }

        public static bool TryParseEnum<T>(this string value, out T result) where T : struct
        {
            return TryParseEnum(value, false, out result);
        }

        public static bool TryParseEnum<T>(this string value, bool ignoreCase, out T result) where T : struct
        {
            var tryResult = TryParseEnum<T>(value, ignoreCase);

            if (tryResult == null)
            {
                result = (T) Activator.CreateInstance(typeof(T));
                return false;
            }

            result = tryResult.Value;
            return true;
        }

        public static T? TryParseEnum<T>(this int value) where T : struct
        {
            var enumType = typeof(T);

            if (!enumType.GetTypeInfo().IsEnum)
                return null;

            if (!Enum.IsDefined(enumType, value))
                return null;

            return (T) Enum.ToObject(enumType, value);
        }

        public static T? TryParseEnum<T>(this int? value) where T : struct
        {
            if (value == null)
                return null;

            var enumType = typeof(T);

            if (!enumType.GetTypeInfo().IsEnum)
                return null;

            if (!Enum.IsDefined(enumType, value))
                return null;

            return (T) Enum.ToObject(enumType, value);
        }

        public static T? TryParseEnum<T>(this string value, bool ignoreCase = false) where T : struct
        {
            if (value.IsEmpty())
                return null;

            var enumType = typeof(T);

            if (!enumType.GetTypeInfo().IsEnum)
                return null;

            if (Char.IsDigit(value[0]) || value[0] == '-' || value[0] == '+')
            {
                int intValue;

                if (!int.TryParse(value, out intValue))
                    return null;

                return TryParseEnum<T>(intValue);
            }

            if (!Enum.IsDefined(enumType, value))
                return null;

            return (T) Enum.Parse(enumType, value, true);
        }

        public static string ToShortenedDisplayValue(this double value, int? maxPrecision = 1, string prefix = null)
        {
            var isNeg = value < 0;
            var shortenedDisplayValue = value;
            var suffix = string.Empty;

            if (maxPrecision < 0)
                maxPrecision = 0;

            value = Math.Abs(value);

            if (value < 1000)
            {
                maxPrecision = null;
                shortenedDisplayValue = Math.Floor(value);
            }
            else if (value < 1000000)
            {
                suffix = "k";
                shortenedDisplayValue = value / 1000;
            }
            else if (value < 1000000000)
            {
                suffix = "m";
                shortenedDisplayValue = value / 1000000;
            }
            else if (value < 1000000000000)
            {
                suffix = "b";
                shortenedDisplayValue = value / 1000000000;
            }
            else if (value >= 1000000000)
            {
                suffix = "t";
                shortenedDisplayValue = value / 1000000000000;
            }

            if (maxPrecision != null)
            {
                //Moves the decimal place over to the right based on the value of maxPrecision
                shortenedDisplayValue = shortenedDisplayValue * Math.Pow(10, maxPrecision.Value);

                //Gets rid of any decimal place for the shortenedDisplayValue
                shortenedDisplayValue = Math.Floor(shortenedDisplayValue);

                //Moves the decimal place over to the left based on the value of maxPrecision
                shortenedDisplayValue = shortenedDisplayValue / Math.Pow(10, maxPrecision.Value);
                //2.6
            }

            if (isNeg)
            {
                if (prefix == "%")
                    return string.Format("({0}{1}{2})", shortenedDisplayValue, suffix, prefix);
                return string.Format("({0}{1}{2})", prefix, shortenedDisplayValue, suffix);
            }

            if (prefix == "%")
                return string.Format("{0}{1}{2}", shortenedDisplayValue, suffix, prefix);
            return string.Format("{0}{1}{2}", prefix, shortenedDisplayValue, suffix);
        }

        public static string ToShortenedDisplayValue(this decimal value, int? maxPrecision = 1, string prefix = null)
        {
            return ToShortenedDisplayValue(Convert.ToDouble(value), maxPrecision, prefix);
        }

        public static string ToShortenedDisplayValue(this long value, int? maxPrecision = 1, string prefix = null)
        {
            return ToShortenedDisplayValue(Convert.ToDouble(value), maxPrecision, prefix);
        }

        public static string ToShortenedDisplayValue(this int value, int? maxPrecision = 1, string prefix = null)
        {
            return ToShortenedDisplayValue(Convert.ToDouble(value), maxPrecision, prefix);
        }

        public static string ToShortenedDisplayValue(this float value, int? maxPrecision = 1, string prefix = null)
        {
            return ToShortenedDisplayValue(Convert.ToDouble(value), maxPrecision, prefix);
        }

        public static string ToShortenedDisplayValue(this short value, int? maxPrecision = 1, string prefix = null)
        {
            return ToShortenedDisplayValue(Convert.ToDouble(value), maxPrecision, prefix);
        }

        public static string ToShortenedDisplayValue(this double? value, int? maxPrecision = 1, string prefix = null)
        {
            return ToShortenedDisplayValue(Convert.ToDouble(value), maxPrecision, prefix);
        }

        public static string ToShortenedDisplayValue(this decimal? value, int? maxPrecision = 1, string prefix = null)
        {
            return ToShortenedDisplayValue(Convert.ToDouble(value), maxPrecision, prefix);
        }

        public static string ToShortenedDisplayValue(this long? value, int? maxPrecision = 1, string prefix = null)
        {
            return ToShortenedDisplayValue(Convert.ToDouble(value), maxPrecision, prefix);
        }

        public static string ToShortenedDisplayValue(this int? value, int? maxPrecision = 1, string prefix = null)
        {
            return ToShortenedDisplayValue(Convert.ToDouble(value), maxPrecision, prefix);
        }

        public static string ToShortenedDisplayValue(this float? value, int? maxPrecision = 1, string prefix = null)
        {
            return ToShortenedDisplayValue(Convert.ToDouble(value), maxPrecision, prefix);
        }

        public static string ToShortenedDisplayValue(this short? value, int? maxPrecision = 1, string prefix = null)
        {
            return ToShortenedDisplayValue(Convert.ToDouble(value), maxPrecision, prefix);
        }

        public static string ToShortenedDisplayValue(this string value, int? maxPrecision = 1, string prefix = null)
        {
            double Number;
            var isNum = double.TryParse(value, out Number);

            if (isNum)
                return ToShortenedDisplayValue(Convert.ToDouble(value), maxPrecision, prefix);

            return ToShortenedDisplayValue(0D, maxPrecision, prefix);
        }

        public static string IfValueAppend(this string value, string append, bool returnNullIfEmpty = false)
        {
            if (value.IsEmpty())
                return returnNullIfEmpty ? null : "";

            return value + append;
        }

        public static string IfValueAppend(this string value, string seperator, string secondValue,
            bool returnNullIfEmpty = false)
        {
            if (value.IsEmpty() && secondValue.IsEmpty())
                return returnNullIfEmpty ? null : "";

            if (secondValue.IsEmpty())
                return value;

            if (value.IsEmpty())
                return secondValue;

            return value + seperator.IfEmpty("") + secondValue;
        }

        public static string IfValueAppend(this string value, string preSeperator, string firstValue, string seperator,
            string secondValue, bool returnNullIfEmpty = false)
        {
            if (value.IsEmpty() && firstValue.IsEmpty() && secondValue.IsEmpty())
                return returnNullIfEmpty ? null : "";

            var combined = "";

            if (value.IsNotEmpty())
            {
                if (firstValue.IsEmpty() && secondValue.IsEmpty())
                    return value;

                combined = value + preSeperator.IfEmpty("");
            }

            if (firstValue.IsEmpty())
                return combined + secondValue;

            if (secondValue.IsEmpty())
                return combined + firstValue;

            return combined + firstValue + seperator.IfEmpty("") + secondValue;
        }
    }
}
