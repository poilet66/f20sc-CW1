using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW1_Try2
{
    class FavouritesHandler
    {

        private List<string> favourites;

        static string APP_DIR = Path.GetFullPath(System.AppDomain.CurrentDomain.BaseDirectory); // the directory that your program is installed in  
        static string SAVE_FILE_PATH = Path.Combine(APP_DIR, "favourites.txt");

        public FavouritesHandler()
        {
            this.favourites = loadFavourites();
        }

        public void addFavourite(string name)
        {
            favourites.Add(name);
        }

        public void removeFavourite(string name)
        {
            favourites.Remove(name);
        }

        // Overwrite save file with all new favourites (Can be optimised to only save new favourites)
        public void saveFavourites()
        {
            using (StreamWriter writer = new StreamWriter(SAVE_FILE_PATH))
            {
                foreach (string fave in this.favourites)
                {
                    writer.WriteLine(fave);
                }
            }
        }

        public List<string> loadFavourites()
        {
            using (StreamReader reader = new StreamReader(SAVE_FILE_PATH))
            {
                List<string> savedFaves = new List<string>();
                String line;

                // Read file line by line, adding lines (favourites) to favourite list
                while ((line = reader.ReadLine()) != null)
                {
                    savedFaves.Add(line);
                }

                return savedFaves;
            }
        }


    }
}
