using System;
using System.Collections.Generic;
using System.Linq;
using Demo_FileIO_NTier.BusinessLogicLayer;
using Demo_FileIO_NTier.Models;
using System.Text;
using System.Threading.Tasks;

namespace Demo_FileIO_NTier.PresentationLayer
{
    class Presenter
    {
        static VGBLL _vgBLL;

        public Presenter(VGBLL vgBLL)
        {
            _vgBLL = vgBLL;
            ManageApplicationLoop();
        }

        private void ManageApplicationLoop()
        {
            DisplayWelcomeScreen();
            DisplayListOfVideoGames();
            DisplayClosingScreen();
        }

        /// <summary>
        /// display a list of character ids and full name
        /// </summary>
        private void DisplayListOfVideoGames()
        {
            bool success;
            string message;

            List<Videogames> videogames = _vgBLL.GetVideoGames(out success, out message) as List<Videogames>;
            videogames = videogames.OrderBy(c => c.Id).ToList();

            DisplayHeader("List of Video Games");

            if (success)
            {
                DisplayVideoGameTable(videogames);
            }
            else
            {
                Console.WriteLine(message);
            }

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a table with id and full name columns
        /// </summary>
        /// <param name="videogames">characters</param>
        private void DisplayVideoGameTable(List<Videogames> videogames)
        {
            StringBuilder columnHeader = new StringBuilder();

            columnHeader.Append("Id".PadRight(8));
            columnHeader.Append("Game Name".PadRight(25));

            Console.WriteLine(columnHeader.ToString());

            videogames = videogames.OrderBy(c => c.Id).ToList();

            foreach (Videogames videogame in videogames)
            {
                StringBuilder videogameInfo = new StringBuilder();

                videogameInfo.Append(videogame.Id.ToString().PadRight(8));
                videogameInfo.Append(videogame.GameName.PadRight(25));

                Console.WriteLine(videogameInfo.ToString());
            }
        }

        /// <summary>
        /// display page header
        /// </summary>
        /// <param name="headerText">text for header</param>
        static void DisplayHeader(string headerText)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"\t\t{headerText}");
            Console.WriteLine();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        /// <summary>
        /// display Welcome Screen
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tWelcome to the Flintstone Viewer");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// Display Closing Screen
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t\tGood Bye");

            DisplayContinuePrompt();
        }

    }
}
