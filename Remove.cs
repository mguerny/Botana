using System.Collections.Generic;
using System.Text;

namespace Botana
{
    public static class Remove
    {
        
        public static string removeAccents(string input)
        {
            var list = new List<KeyValuePair<char, List<char>>>();

            List<char> listA = new List<char>();
            listA.Add('à');
            listA.Add('â');

            List<char> listE = new List<char>();
            listE.Add('é');
            listE.Add('è');
            listE.Add('ê');
            listE.Add('ë');

            List<char> listI = new List<char>();
            listI.Add('î');
            listI.Add('ï');

            List<char> listO = new List<char>();
            listO.Add('ô');

            List<char> listU = new List<char>();
            listU.Add('ù');
            listU.Add('ü');
            listU.Add('û');

            List<char> listC = new List<char>();
            listC.Add('ç');

            list.Add(new KeyValuePair<char, List<char>>('a', listA));
            list.Add(new KeyValuePair<char, List<char>>('e', listE));
            list.Add(new KeyValuePair<char, List<char>>('i', listI));
            list.Add(new KeyValuePair<char, List<char>>('o', listO));
            list.Add(new KeyValuePair<char, List<char>>('u', listU));
            list.Add(new KeyValuePair<char, List<char>>('c', listC));


            StringBuilder strBuilder = new StringBuilder(input);
            for (int i = 0; i < input.Length; i++)
            {
                foreach (KeyValuePair<char, List<char>> listKeyValue in list)
                {
                    foreach (char c in listKeyValue.Value)
                    {
                        if (input[i] == c)
                        {
                            strBuilder[i] = listKeyValue.Key;
                        }
                    }
                }
            }
            string output = strBuilder.ToString();
            return output;
        }
    }
}