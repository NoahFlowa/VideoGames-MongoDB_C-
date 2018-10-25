using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo_FileIO_NTier.DataAccessLayer;
using Demo_FileIO_NTier.BusinessLogicLayer;
using Demo_FileIO_NTier.PresentationLayer;
using Demo_FileIO_NTier.Models;

namespace Demo_FileIO_NTier
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataService dataService = new MongoDBDataService();

            //
            // Required to test the MongoDB data service
            // refresh MongoDB collection 
            //

            dataService.WriteAll(GenerateListOfGames());

            VGBLL vgBLL = new VGBLL(dataService);
            Presenter presenter = new Presenter(vgBLL);
        }

        private static List<Videogames> GenerateListOfGames()
        {
            List<Videogames> videogames = new List<Videogames>()
            {
                new Videogames()
                {
                    Id = 1,
                    GameName = "Halo: Combat Evolved",
                    Developer = "Bungie",
                    ReleaseDate = new DateTime(2001, 11, 15),
                    Price = 60,
                    Rating = Videogames.MSRPRating.M,
                    VGType = Videogames.Genre.FPS,
                    Platform = Videogames.PlatformType.PC,
                },
                new Videogames()
                {
                    Id = 2,
                    GameName = "Civilization VI",
                    Developer = "2K | Firaxis",
                    ReleaseDate = new DateTime(2016, 10, 16),
                    Price = 60,
                    Rating = Videogames.MSRPRating.M,
                    VGType = Videogames.Genre.RTS,
                    Platform = Videogames.PlatformType.PC,
                },
                new Videogames()
                {
                    Id = 3,
                    GameName = "Destiny 2",
                    Developer = "Bungie",
                    ReleaseDate = new DateTime(2017, 9, 5),
                    Price = 60,
                    Rating = Videogames.MSRPRating.M,
                    VGType = Videogames.Genre.FPSMMO,
                    Platform = Videogames.PlatformType.PC,
                }

            };

            return videogames;
        }
    }
}