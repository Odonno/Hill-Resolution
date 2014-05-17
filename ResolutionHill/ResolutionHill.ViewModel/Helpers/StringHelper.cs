using System.Text.RegularExpressions;

namespace ResolutionHill.ViewModel.Helpers
{
    public static class StringHelper
    {
        public static string OnlyAToZ(this string text)
        {
            var regex = new Regex("[^A-Z]");
            return regex.Replace(text.ToUpper(), "");
        }

        public static int CharToIntModulo26(this char letter)
        {
            return ValueHelper.Modulo26(letter - 'A');
        }

        public static char IntToCharModulo26(this int value)
        {
            int moduloValue = ValueHelper.Modulo26(value);
            return (char)(moduloValue + 'A');
        } 
    }
}
