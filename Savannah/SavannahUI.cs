namespace Savannah
{
    using System;

    /// <summary>
    /// Executes console commands.
    /// </summary>
    public class SavannahUI
    {
        /// <summary>
        /// Sets console size. Welcome and instructions to play.
        /// </summary>
        /// <returns> Welcome text and instructions. </returns>
        public string StartGameMenu()
        {
            Console.Clear();
            Console.SetWindowSize(100, 30);

            string menu = "\n                                        WELCOME TO SAVANNAH!\n" +
                          "                           L - Create a Lion \u25B2     A - Create an Antelope \u25CB\n" +
                          "____________________________________________________________________________________________________";
            
            Console.Write(menu);

            return menu;
        }

        /// <summary>
        /// Listens for user input during the game.
        /// </summary>
        /// <returns> Returns user input value. </returns>
        public ConsoleKey ToggleInput()
        {
            ConsoleKey input = Console.ReadKey(true).Key;

            return input;
        }

        /// <summary>
        /// Prints current animal location
        /// </summary>
        /// <returns> Animal Character </returns>
        public string PrintAnimal(int positionX, int positionY, string species)
        {
            string animalExists = null;
            Console.SetCursorPosition(positionX, positionY);
            Console.CursorVisible = false;

            if (species == "lion")
            {
                animalExists = "lion";
                Console.Write("\u25B2");
            }
            else
            {
                animalExists = "antelope";
                //Console.Write("\u25CF");
                Console.Write("\u25CB");
            }

            return animalExists;
        }

        public bool IsBoardOverPopulated()
        {
            bool population = true;
            Console.SetCursorPosition(0, 0);
            Console.Write("Pls,savannah is overpopulated!");
            return population;
        }

        public void ClearErrorMessage()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("                                 ");
        }
    }
}
