﻿using System.Collections.Generic;

namespace DefaultDocumentation.Helper
{
    internal static class StringExtension
    {
        private static readonly IReadOnlyDictionary<char, char> _invalidChars = new Dictionary<char, char>
        {
            [':'] = '-',
            ['.'] = '-',
            [','] = '-',
            ['#'] = '-',
            ['['] = '-',
            [']'] = '-',
            ['`'] = '-',
            ['@'] = '-',
        };

        private static string CleanForDotNetApiLink(this string value) => value.Replace('`', '-');

        public static string Clean(this string value)
        {
            foreach (KeyValuePair<char, char> pair in _invalidChars)
            {
                value = value.Replace(pair.Key, pair.Value);
            }

            return value;
        }

        public static string AsDotNetApiLink(this string value)
        {
            string name = value;
            if (name.Contains("`"))
            {
                name = $"{name.Substring(0, name.IndexOf('`'))}&lt;&gt;";
            }

            return $"[{name}](https://docs.microsoft.com/en-us/dotnet/api/{value.CleanForDotNetApiLink()} '{name}')";
        }
    }
}
