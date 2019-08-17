using System.Linq;

namespace server.Util
{
    public static class Extensions
    {
        public static string ToHexString(this byte[] byteArray)
        {
            return byteArray.Aggregate("", (current, b) => current + b.ToString("X2"));
        }
    }
}
