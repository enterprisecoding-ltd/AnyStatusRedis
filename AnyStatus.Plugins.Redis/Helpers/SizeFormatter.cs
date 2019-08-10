using System;

namespace AnyStatus.Plugins.Redis.Helpers
{
    //Please refer for the original implementation : https://www.c-sharpcorner.com/article/csharp-convert-bytes-to-kb-mb-gb/
    internal class SizeFormatter
    {
        static readonly string[] suffixes = { "Bytes", "KB", "MB", "GB", "TB", "PB" };

        internal static string FormatSize(double bytes)
        {
            int counter = 0;
            double number = bytes;
            while (Math.Round(number / 1024) >= 1)
            {
                number /= 1024;
                counter++;
            }
            return string.Format("{0:n1} {1}", number, suffixes[counter]);
        }
    }
}
