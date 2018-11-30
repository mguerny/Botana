using System.Text.RegularExpressions;

namespace Botana
{
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