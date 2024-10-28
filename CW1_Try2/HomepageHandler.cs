using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW1_Try2
{
    class HomepageHandler
    {

        // only one singular homepage so can just use a field
        public string HomepageUrl { get; set; }
        static string HOMEPAGE_PATH = Path.Combine(Form1.APP_DIR, "homepage.txt");

        public HomepageHandler()
        {
            HomepageUrl = loadHomepage();
        }

        // overwrite previous save to new one
        public void saveHomepage()
        {
            File.WriteAllText(HOMEPAGE_PATH, HomepageUrl);
        }

        public string loadHomepage()
        {
            if (!File.Exists(HOMEPAGE_PATH)) return "";
            using (StreamReader reader = new StreamReader(HOMEPAGE_PATH))
            {
                return reader.ReadLine();
            }
        }
    }
}
