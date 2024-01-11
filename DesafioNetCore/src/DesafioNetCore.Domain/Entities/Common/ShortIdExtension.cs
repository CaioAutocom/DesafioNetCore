using System.Text;

namespace DesafioNetCore.Domain.Entities.Common
{
    public static class ShortIdExtension
    {
        internal static string ToBase64(this string text)
        {
            string base64 = Convert.ToBase64String(Encoding.ASCII.GetBytes(text));
            return new string(base64.Where(x => Char.IsLetterOrDigit(x)).ToArray()[..10]);
        }
    }
}
