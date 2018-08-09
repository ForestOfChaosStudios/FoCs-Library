using System.Text.RegularExpressions;

namespace ForestOfChaosLib.Extensions
{
	public static class StringExtensions
	{
		private const string INVALID_CHARS            = "([=+{}[]\"'?.<>,\\|()*&^%$#@!;:-])+";
		private const string WHITESPACE               = "\t\n\v\f\r ";
		private const string INVALID_CHARS_WHITESPACE = INVALID_CHARS + WHITESPACE;

		public static bool DoesStringHaveInvalidCharsOrWhiteSpace(this string str)
		{
			return StringRegexMatch(str, INVALID_CHARS_WHITESPACE);
		}

		public static bool DoesStringHaveInvalidChars(this string str)
		{
			return StringRegexMatch(str, INVALID_CHARS);
		}

		public static bool IsNullOrEmpty(this string str)
		{
			return string.IsNullOrEmpty(str);
		}

		public static bool HasContent(this string str)
		{
			return !string.IsNullOrEmpty(str);
		}

		public static bool DoesStringHaveWhiteSpace(this string str)
		{
			return StringRegexMatch(str, WHITESPACE);
		}

		public static string ReplaceWhiteSpace(this string str, string replaceChar = "")
		{
			return str.Replace(" ", replaceChar).Replace("\n", replaceChar).Replace("\t", replaceChar);
		}

		public static string ReplaceStringHaveInvalidCharsOrWhiteSpace(this string str, char replaceChar)
		{
			return StringRegexReplace(str, INVALID_CHARS_WHITESPACE, replaceChar);
		}

		public static string ReplaceStringHaveInvalidCharsOrWhiteSpace(this string str, string replaceChar = "")
		{
			return StringRegexReplace(str, INVALID_CHARS_WHITESPACE, replaceChar);
		}

		public static string ReplaceStringHaveInvalidChars(this string str, char replaceChar)
		{
			return StringRegexReplace(str, INVALID_CHARS, replaceChar);
		}

		public static string ReplaceStringHaveInvalidChars(this string str, string replaceChar = "")
		{
			return StringRegexReplace(str, INVALID_CHARS, replaceChar);
		}

		//From Stack Overflow thread https://stackoverflow.com/questions/5796383/insert-spaces-between-words-on-a-camel-cased-token
		public static string SplitCamelCase(this string str)
		{
			return Regex.Replace(Regex.Replace(str, @"(\P{Ll})(\P{Ll}\p{Ll})", "$1 $2"), @"(\p{Ll})(\P{Ll})", "$1 $2");
		}

		public static string ToUpperAllWords(this string str)
		{
			var array = str.ToCharArray();

			for(var i = 1; i < array.Length; i++)
			{
				if((str[i - 1] == ' ') || (str[i - 1] == '_'))
					array[i] = char.ToUpper(str[i]);
			}

			return new string(array);
		}

		public static string ToUpperAllWordsAfterSpace(this string str)
		{
			var array = str.ToCharArray();

			for(var i = 1; i < array.Length; i++)
			{
				if(str[i - 1] == ' ')
					array[i] = char.ToUpper(str[i]);
			}

			return new string(array);
		}

		public static bool StringRegexMatch(string str, string match)
		{
			var m = Regex.Match(str, match);

			return m.Success;
		}

		public static string StringRegexReplace(string str, string replaceChars, char replaceChar)
		{
			foreach(var @char in replaceChars)
				str = str.Replace(@char, replaceChar);

			return str;
		}

		public static string StringRegexReplace(string str, string replaceChars, string replaceString)
		{
			foreach(var @char in replaceChars)
				str = str.Replace(@char.ToString(), replaceString);

			return str;
		}
	}
}
