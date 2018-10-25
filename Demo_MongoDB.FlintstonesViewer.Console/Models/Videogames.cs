using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_FileIO_NTier.Models
{
    public class Videogames
    {
        public enum PlatformType { XBOX, PS4, SWITCH, PC }
        public enum Genre { FPS, MMO, RTS, BUILDER, FIGHTER, FPSMMO  }
        public enum MSRPRating { E, EPlus, T, M, A }

        public int Id { get; set; }
        public string GameName { get; set; }
        public string Developer { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Price { get; set; }
        public MSRPRating Rating { get; set; }
        public Genre VGType { get; set; }
        public PlatformType Platform { get; set; }
    }
}
