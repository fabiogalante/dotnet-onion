using System.Text.RegularExpressions;

namespace Dotnet.Onion.Template.Crosscutting.Common.Helpers
{
    public static class StringHelper
    {
        public static string RemoveEspeciais(this string text)
        {
            Regex rgxA = new Regex(@"[ÃÂÀÁÄãâàáä]");
            text = rgxA.Replace(text, "a");

            Regex rgxE = new Regex(@"[ÊÈÉËêèéë]");
            text = rgxE.Replace(text, "e");

            Regex rgxI = new Regex(@"[ÎÌÍÏîìíï]");
            text = rgxI.Replace(text, "i");

            Regex rgxO = new Regex(@"[ÕÔÒÓÖõôòóö]");
            text = rgxO.Replace(text, "o");

            Regex rgxU = new Regex(@"[ÛÙÚÜûúùü]");
            text = rgxU.Replace(text, "u");

            text = text.Replace('ç', 'c');
            text = text.Replace('Ç', 'C');
            text = text.Replace('ñ', 'n');
            text = text.Replace('Ñ', 'N');

            return text;

        }
    }
}
