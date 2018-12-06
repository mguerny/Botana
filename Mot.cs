using System.Text.RegularExpressions;

namespace Botana
{
    /// <summary>
    /// When we create an instance of this class, it takes a word created by the page "www.motsqui.com" and put it into value.
    /// </summary>
    internal class Mot
    {
        public string value {get; set;}

        public Mot(){
            fetchMot();
        }

        private void fetchMot()
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            string totalHtml = wc.DownloadString("https://www.motsqui.com/mots-aleatoires.php?Submit=Nouveau+mot");

            value = Regex.Split(Regex.Split(totalHtml, "<b>")[1], "</b>")[0];
        }

    }
}