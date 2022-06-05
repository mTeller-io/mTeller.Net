using System.Text;

namespace Common.Helpers
{
    public static class Helpers
    {
        public static string EncodeCodeBase64(this string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(bytes);
        }

        public static string DecodeBase64String(this string value)
        {
            var bytes = Convert.FromBase64String(value);

            return Encoding.UTF8.GetString(bytes);
        }
    }
}