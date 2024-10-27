using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace CW1_Try2
{
    class FavouritesHandler
    {

        private List<FavouriteItem> favourites;

        static string APP_DIR = Path.GetFullPath(System.AppDomain.CurrentDomain.BaseDirectory); // base directory 
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
            try
            {
                // Serialize the favourites list to JSON format
                string jsonString = System.Text.Json.JsonSerializer.Serialize(favourites);
                File.WriteAllText(SAVE_FILE_PATH, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving favourites: {ex.Message}");
            }
        }

        public List<FavouriteItem> loadFavourites()
        {
            if (!File.Exists(SAVE_FILE_PATH)) //if not exists make new empty file and return empty
                return new List<FavouriteItem>();

            try
            {
                string jsonString = File.ReadAllText(SAVE_FILE_PATH);
                return JsonSerializer.Deserialize<List<FavouriteItem>>(jsonString) ?? new List<FavouriteItem>(); // deserialize json - use ?? operator to check if null and return empty list if so
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading favourites: {ex.Message}");
                return new List<FavouriteItem>(); // return empty list if error
            }
        }

    }
}
