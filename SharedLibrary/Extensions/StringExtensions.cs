using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace SharedLibrary
{
    public static class StringExtensions
    {
        //public static string RegexReplace(this string input, string pattern, RegexOptions options = RegexOptions.IgnoreCase)
        //{
        //    return Regex.Replace(input ?? "", pattern, "", options);
        //}
        public static string RegexReplace(this string input, string pattern, string replace, RegexOptions options = RegexOptions.IgnoreCase)
        {
            return Regex.Replace(input ?? "", pattern, replace, options);
        }

		public static bool JFIsNull(this string str)
		{
			if (string.IsNullOrEmpty(str)
				|| string.IsNullOrWhiteSpace(str)
				|| str.Equals(" ")
				|| str.ToLower().Equals("null")) {
				return true;
			}
			return false;
		}

        public static bool JFIsNotNull(this string str) => !str.JFIsNull();

        public static string JFNullToEmptyString(this string str)
		{
			if (str.JFIsNull()) {
				return "";
			}
			return str;
		}

		public static DateTime JFStringToDate(this string str)
		{
			DateTime dt;
			if (DateTime.TryParse(str, out dt)) {
				return dt;
			}
			throw new Exception($"Unable to parse string as a date: {str}");
		}

		public static DateTime? JFStringToDateAllowNull(this string str)
		{
			DateTime dt;
			if (DateTime.TryParse(str, out dt)) {
				return dt;
			}
			return null;
		}

		public static bool JFStringToBool(this string str) => str.JFStringToInt() > 0 ? true : false;

		public static int JFStringToInt(this string str)
		{
			int d;
			if (Int32.TryParse(str, out d)) {
				return d;
			}
			return 0;
		}

		public static string JFDigitsOnly(this string str)
		{
			return Regex.Replace(str.JFNullToEmptyString(), @"[^\d+]", "");
		}

        public static string FormatPhoneStandard(this string phone)
        {
            phone = Regex.Replace(phone, @"[\.|-|\(|\(|\)|\s+]", "").Trim();
            if (phone.Length == 10) {
                phone = $"({phone.Substring(0, 3)}) {phone.Substring(3, 3)}-{phone.Substring(6, 4)}";
            } else if (phone.Length == 7) {
                phone = $"{phone.Substring(0, 3)}-{phone.Substring(3, 4)}";
            }
            return phone;
        }
    }
}
