using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium.Models
{
    public class Album
    {
        public int IdAlbum { get; set; }
        public int AlbumName { get; set; }
        public DateTime PublishDate { get; set; }
        public int IdMusicLabel { get; set; }
        public virtual MusicLabel MusicLabel { get; set; }
        public virtual IEnumerable<Track> Tracks { get; set; }

    }
}