using Supremes;
using Supremes.Nodes;

namespace Botana
{
    internal class Humor
    {

        public string image{get; private set;}

        public Humor(){
            setHumor();
        }

        private void setHumor (){
            
                System.Net.WebClient wc = new System.Net.WebClient();

                // get html at given url
                string totalHtml = wc.DownloadString("http://devhumor.com/random");
                Document doc = Dcsoup.Parse(totalHtml);

                // select an 'img' element, with 'class=single-media' attribute
                Element result = doc.Select("img.single-media").First;

                // get the 'src' attribute
                image = result.Attr("src");

        }
    }
}