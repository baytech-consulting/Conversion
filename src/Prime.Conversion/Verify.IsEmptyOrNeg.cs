namespace Prime.Conversion
{
    public static partial class Verify
    {
        public static bool IsEmptyOrNeg(this short value)
        {
            return value <= 0;
        }

        public static bool IsEmptyOrNeg(this short? value)
        {
            return value == null || value.Value <= 0;
        }

        public static bool IsEmptyOrNeg(this int value)
        {
            return value <= 0;
        }

        public static bool IsEmptyOrNeg(this int? value)
        {
            return value == null || value.Value <= 0;
        }

        public static bool IsEmptyOrNeg(this long value)
        {
            return value <= 0L;
        }

        public static bool IsEmptyOrNeg(this long? value)
        {
            return value == null || value.Value <= 0L;
        }

        public static bool IsEmptyOrNeg(this float value)
        {
            return value <= 0.0F;
        }

        public static bool IsEmptyOrNeg(this float? value)
        {
            return value == null || value.Value <= 0.0F;
        }

        public static bool IsEmptyOrNeg(this double value)
        {
            return value.Equals(0.0D);
        }

        public static bool IsEmptyOrNeg(this double? value)
        {
            return value == null || value.Value <= 0D;
        }

        public static bool IsEmptyOrNeg(this decimal value)
        {
            return value == 0.0M;
        }

        public static bool IsEmptyOrNeg(this decimal? value)
        {
            return value == null || value.Value <= 0M;
        }
    }
}