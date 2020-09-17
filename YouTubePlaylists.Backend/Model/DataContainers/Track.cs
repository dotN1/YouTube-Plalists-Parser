using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace YouTubePlaylists.Backend.Model
{
    public class Track
    {
        public string ThumbnailUri { get; set; }

        public string SongName { get; set; }

        public string ArtistName { get; set; }

        public string Duration { get; set; }
    }
}
