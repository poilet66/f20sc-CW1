using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW1_Try2
{
    [Serializable]
    class FavouriteItem
    {
        public string Url { get; }
        public string Name { get; }

        public FavouriteItem(string url, string name)
        {
            Url = url;
            Name = name;
        }
    }
}
