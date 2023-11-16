using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace APKToolGUI.Utils
{
    public static class StringExt
    {
        static readonly Random random = new Random();

        public static string Regex(string text, string match)
        {
            Regex myRegex = new Regex(text);
            Match matched = myRegex.Match(match);
            return matched.ToString();
        }

        public static string RandStr(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandStrWithCaps(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Method that limits the length of text to a defined length.
        /// </summary>
        /// <param name="source">The source text.</param>
        /// <param name="maxLength">The maximum limit of the string to return.</param>
        // string limit5 = "The quick brown fox jumped over the lazy dog.".LimitLength(5);
        public static string LimitLength(this string source, int maxLength)
        {
            if (source.Length <= maxLength)
            {
                return source;
            }

            return source.Substring(0, maxLength);
        }

        public static IEnumerable<string> SplitByLength(this string str, int maxLength)
        {
            for (int index = 0; index < str.Length; index += maxLength)
            {
                yield return str.Substring(index, Math.Min(maxLength, str.Length - index));
            }
        }

        public static string RemoveLast(this string text, string character)
        {
            try
            {
                if (text.Length < 1) return text;
                return text.Remove(text.ToString().LastIndexOf(character), character.Length);
            }
            catch
            {
                return text;
            }
        }

        public static bool ContainsAny(this string haystack, params string[] needles)
        {
            foreach (string needle in needles)
            {
                if (haystack.Contains(needle))
                    return true;
            }

            return false;
        }
    }
}
