using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Havbruksloggen.CodingChallenge.Api.Utils
{
    public static class StringUtils
    {
        public static string RemovePostFix(this string str, params string[] postFixes)
        {
            return str.RemovePostFix(postFixes);
        }
    }
}
