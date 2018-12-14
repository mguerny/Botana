using System.Text;
using System.Text.RegularExpressions;

namespace Botana
{
    /// <summary>
    /// Fetches a word created by the page "www.motsqui.com".
    /// </summary>
    internal class Mot
    {
        public string value {get; set;}

        public Mot(){
            fetchMot();
        }

        private void fetchMot()
        {
            value = HtmlString.getHtmlString("https://www.motsqui.com/mots-aleatoires.php?Submit=Nouveau+mot", "<b>", "</b>");
        }

    }
}