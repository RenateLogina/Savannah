namespace Savannah
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <summary>
    /// Executes console commands.
    /// </summary>
    public class SavannahUI
    {
        /// <summary>
        /// Sets console size.
        /// </summary>
        public void StartGameMenu()
        {
            Console.Clear();
            Console.SetWindowSize(101, 34);
            //StringBuilder sb = new StringBuilder();

            //sb.AppendLine();
            //sb.AppendLine("                                        WELCOME TO SAVANNAH!");
            //sb.AppendLine("                           L - Create a Lion \u25B2     A - Create an Antelope \u25CB");
            //sb.AppendLine("_____________________________________________________________________________________________________");


            //var result = sb.ToString();
            //Console.CursorVisible = false;
            //Console.SetCursorPosition(0, 0);
            //Console.Write(result);
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
        /// Prints the entire list of animals in their corresponding locations, also the instructions.
        /// </summary>
        /// <param name="animals"> Uses list of all animals created in the manager. </param>
        public void PrintArray(AnimalList animals, int boardsizeX, int boardsizeY, bool isGameSet)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine("                                        WELCOME TO SAVANNAH!");
            if (!isGameSet)
            {
                sb.AppendLine("       L - Create a Lion \u25B2     A - Create an Antelope \u25CB     ENTER - start game");
            }
            else
            {
                sb.AppendLine("                                                                                                    ");
            }

            sb.AppendLine("_____________________________________________________________________________________________________");

            for (int line = 0; line <= boardsizeY - 4; line++)
            {
                for (int col = 0; col <= boardsizeX; col++)
                {
                    if (animals.Animals.Where(x => x.Position[0] == col && x.Position[1] == line + 4 && x.Trigger == "l").Any())
                    {

                        sb.Append("\u25B2");
                    }
                    else if (animals.Animals.Where(x => x.Position[0] == col && x.Position[1] == line + 4 && x.Trigger == "a").Any())
                    {

                        sb.Append("\u25CB");
                    }
                    else
                    {
                        sb.Append(" ");
                    }
                }

                sb.AppendLine();
            }

            var result = sb.ToString();
            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.Write(result);
        }
    }
}
