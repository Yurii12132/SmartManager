using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SmartManagerServer.Core.Infrastructure.TypeExtensions
{
    public static class StringExtensions
    {
        public static string TrimNullIfEmpty(this string str)
        {
            var result = str.Trim();
            if (result.Length == 0) return null;
            return result;
        }

        public static bool EqualsIgnoreCase(this string str, string value)
        {
            if (str == null) return false;
            return str.Equals(value?.Trim(), StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool StartsWithIgnoreCase(this string str, string value)
        {
            if (str == null) return false;
            return str.StartsWith(value?.Trim(), StringComparison.InvariantCultureIgnoreCase);
        }

        public static bool IsEmpty(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        public static bool IsNotEmpty(this string str)
        {
            return string.IsNullOrWhiteSpace(str) == false;
        }

        public static int ToInt(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return 0;
            if (Int32.TryParse(value, out int result)) return result;
            return 0;
        }

        public static int? ToNullableInt(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return null;
            if (Int32.TryParse(value, out int result)) return result;
            return null;
        }

        public static decimal ToDecimal(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return 0;
            if (Decimal.TryParse(value, NumberStyles.Float, null, out Decimal result)) return result;
            return 0;
        }

        public static double ToDouble(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return 0;
            if (Double.TryParse(value, NumberStyles.Float, null, out Double result)) return result;
            return 0;
        }

        public static decimal? ToNullableDecimal(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return null;
            if (Decimal.TryParse(value, NumberStyles.Float, null, out Decimal result)) return result;
            return null;
        }

        public static decimal ToDecimalWithRound(this string value, int precision = 15)
        {
            var result = value.ToDecimal();
            return Math.Round(result, precision);
        }

        public static decimal? ToNullableDecimalWithRound(this string value, int precision = 15)
        {
            var result = value.ToNullableDecimal();
            if (result == null) return null;
            return Math.Round(result.Value, precision);
        }

        public static bool ToBool(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;
            if (Boolean.TryParse(value, out bool result)) return result;
            return false;
        }

        public static bool? ToNullableBool(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return null;
            if (Boolean.TryParse(value, out bool result)) return result;
            return null;
        }
    }
}
