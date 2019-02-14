using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string word) =>
            String.IsNullOrEmpty(word);
    }
}
