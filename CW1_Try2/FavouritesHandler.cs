using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace CW1_Try2
{
    class FavouritesHandler
    {

        private List<FavouriteItem> favourites;

        static string APP_DIR = Path.GetFullPath(System.AppDomain.CurrentDomain.BaseDirectory); // the directory that your program is installed in  
        static string SAVE_FILE_PATH = Path.Combine(APP_DIR, "favourites.txt");

        public FavouritesHandler()
        {
            this.favourites = loadFavourites();
        }

        public void addFavourite(FavouriteItem item)
        {
            favourites.Add(item);
        }

        public void removeFavourite(FavouriteItem item)
        {
            favourites.Remove(item);
        }

        public List<FavouriteItem> getFavourites()
        {
            return this.favourites;
        }

        // Overwrite save file with all new favourites (Can be optimised to only save new favourites)
        public void saveFavourites()
        {
            using (StreamWriter writer = new StreamWriter(SAVE_FILE_PATH))
            {
                foreach (var favourite in favourites)
                {
                    writer.WriteLine($"{favourite.Url}|{favourite.Name}");
                }
            }
        }

        public List<FavouriteItem> loadFavourites()
        {
            favourites = new List<FavouriteItem>();

            if (!File.Exists(SAVE_FILE_PATH))
                return favourites;

            using (StreamReader reader = new StreamReader(SAVE_FILE_PATH))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split('|');
                    if (parts.Length == 2)
                    {
                        var url = parts[0];
                        var name = parts[1];
                        favourites.Add(new FavouriteItem(url, name));
                    }
                }
                return favourites;
            }
        }


    }
}
