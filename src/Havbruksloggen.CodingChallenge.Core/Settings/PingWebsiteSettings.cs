using System;

namespace Havbruksloggen.CodingChallenge.Core.Settings
{
    public class PingWebsiteSettings
    {
        public Uri Url { get; set; }
        public int TimeIntervalInMinutes { get; set; }
    }
}
