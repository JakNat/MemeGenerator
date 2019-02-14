using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemeGenerator.Client.Extensions
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string word)
            => String.IsNullOrWhiteSpace(word);
    }
}
