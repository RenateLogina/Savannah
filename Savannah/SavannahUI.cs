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
            Console.SetWindowSize(101, 32);
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
        public void PrintArray(AnimalList animals)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            if(animals.Animals.Count >118)
            {
                sb.AppendLine("Pls, savannah is overpopulated!         WELCOME TO SAVANNAH!");
            }
            else
            {
                sb.AppendLine("                                        WELCOME TO SAVANNAH!");
            }
            
            sb.AppendLine("                           L - Create a Lion \u25B2     A - Create an Antelope \u25CB");
            sb.AppendLine("_____________________________________________________________________________________________________");

            for (int yDimension = 0; yDimension <= 26; yDimension++)
            {
                for (int xDimension = 0; xDimension <= 100; xDimension++)
                {
                   #region animal painter
                    if (animals.Animals.Where(x => x.Position[0] == xDimension && x.Position[1] == yDimension + 4).Any())
                    {

                            // Appends head character.
                            //sb.Append("\u2584");
                            sb.AppendFormat("{0}", animals.Animals.FirstOrDefault(x => x.Position[0] == xDimension && x.Position[1] == yDimension + 4).Trigger);
                    }
                    else if (animals.Animals.Where(a => (a.Position[0] == xDimension && a.Position[1] == yDimension + 2) ||
                                                        (a.Position[0] == xDimension - 2 && a.Position[1] == yDimension + 2)).Any())
                    {
                        // Appends legs.
                        // sb.Append("\u2580");
                        sb.Append("/");

                    }
                    else if (animals.Animals.Where(x => (x.Position[0] == xDimension && x.Position[1] == yDimension + 3) ||
                                                        (x.Position[0] == xDimension - 1 && x.Position[1] == yDimension + 3) ||
                                                        (x.Position[0] == xDimension - 2 && x.Position[1] == yDimension + 3)).Any())
                    {
                        // Appends Body
                        sb.Append("\u2588");

                    }
                    else
                    {
                        // Appends blank space.
                        sb.Append(" ");
                    }
                    #endregion

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
