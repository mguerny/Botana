using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Botana
{
    public static class Remove
    {

        public static string removeAccents(string input)
        {
            return new string(
                input
                .Normalize(System.Text.NormalizationForm.FormD)
                .ToCharArray()
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray());
            // the normalization to FormD splits accented letters in accents+letters
            // the rest removes those accents (and other non-spacing characters)
        }
    }
}