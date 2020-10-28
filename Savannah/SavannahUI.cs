namespace Savannah
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Executes console commands.
    /// </summary>
    public class SavannahUI
    {
        /// <summary>
        /// Sets console size. Welcome and instructions to play.
        /// </summary>
        /// <returns> Welcome text and instructions. </returns>
        public void StartGameMenu()
        {
            Console.Clear();
            Console.SetWindowSize(100, 30);

            //string menu = "\n                                        WELCOME TO SAVANNAH!\n" +
            //              "                           L - Create a Lion \u25B2     A - Create an Antelope \u25CB\n" +
            //              "____________________________________________________________________________________________________";
            Console.Write ("\n                                        WELCOME TO SAVANNAH!\n" +
                           "                           L - Create a ");

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Lion     ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("A - Create an ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Antelope");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("____________________________________________________________________________________________________");


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
        public string PrintAnimal(int positionX, int positionY, string trigger, int count)
        {
            string animalExists = null;
            //Console.SetCursorPosition(positionX, positionY);
            //Console.CursorVisible = false;

            if (trigger == "l")
            {
                animalExists = "lion";
                Console.ForegroundColor = ConsoleColor.DarkRed;
                //Console.Write("\u25B2");
                Animal(positionX, positionY);
            }
            else
            {
                animalExists = "antelope";
                Console.ForegroundColor = ConsoleColor.Yellow;
                //Console.Write("\u25CB");
                Animal(positionX, positionY);
            }

            // Test how many animals
            Console.SetCursorPosition(0,0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Animals in Savannah: {0}   ", count);

            return animalExists;
        }

        /// <summary>
        /// Error message if savannah population is getting too big.
        /// </summary>
        /// <returns></returns>
        public bool BoardOverPopulated()
        {
            bool population = true;
            Console.SetCursorPosition(0, 0);
            Console.Write("Pls,savannah is overpopulated!");
            return population;
        }

        /// <summary>
        /// Clears up messages if any are printed on top of the console.
        /// </summary>
        public void ClearErrorMessage()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("                                 ");
        }

        /// <summary>
        /// Print Animal shape
        /// </summary>
        /// <param name="positionX"> Initial animal position dimension X. Equals to animal nose. </param>
        /// <param name="positionY"> Initial animal position dimension Y. Equals to animal nose. </param>
        public void Animal(int positionX, int positionY)
        {
            List<int> printX = new List<int> { 0, 1, 1, 2, 3, 1, 3 };
            List<int> printY = new List<int> { 0, 0, 1, 1, 1, 2, 2 };
            // string life = "\u2588\u2588\u2588\u2588";

            for (int i = 0; i < printX.Count; i++)
            {
                Console.SetCursorPosition(printX[i] + positionX, printY[i] + positionY);
                if ((printX[i] == 1 && printY[i] == 2) || (printX[i] == 3 && printY[i] == 2))
                {
                    Console.Write("\u2580");
                }
                else if ((printX[i] == 0 && printY[i] == 0))
                {
                    Console.Write("\u2584");
                }
                else
                {
                    Console.Write("\u2588");
                }

                Console.CursorVisible = false;
            }

            // Console.ForegroundColor = ConsoleColor.Green;
            // Console.SetCursorPosition(positionX, positionY + 3);
            // Console.Write(life);
        }

        /// <summary>
        /// A test of printing animal shape and it's life indicator together
        /// </summary>
        public void PrintTest()
        {
            List<int> printX = new List<int> { 0,1,1,2,3,1,3 };
            List<int> printY = new List<int> { 0,0,1,1,1,2,2 };
            int[] animalPosition = new int[] { 10, 10 };
            string life = "\u2588\u2588\u2588\u2588";

            for (int i = 0; i < printX.Count; i ++)
            {
                Console.SetCursorPosition(printX[i] + animalPosition[0], printY[i]+animalPosition[0]);
                if((printX[i] == 1 && printY[i] == 2) || (printX[i] == 3 && printY[i] == 2))
                {
                    Console.Write("\u2580");
                }
                else if ((printX[i] == 0 && printY[i] == 0))
                {
                    Console.Write("\u2584");
                }
                else
                {
                    Console.Write("\u2588");
                }
                
                Console.CursorVisible = false;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(animalPosition[0], animalPosition[0] + 3);
            Console.Write(life);
        }
    }
}
