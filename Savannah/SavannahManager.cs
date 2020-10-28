using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Savannah
{
    /// <summary>
    /// Executes actions and connects UI, Logic and other classes.
    /// </summary>
    public class SavannahManager
    {
        SavannahLogic logic = new SavannahLogic();
        SavannahUI uI = new SavannahUI();
        AnimalList animalList = new AnimalList();
        Random random = new Random();

        /// <summary>
        /// Starts game by showing welcome message and instructions.
        /// Awaits for user input.
        /// </summary>
        public void StartGame()
        {
            uI.StartGameMenu();
            while(true)
            {
                var input = uI.ToggleInput().ToString().ToLower();
                switch (input)
                {
                    case "l":
                    case "a":
                        if (animalList.Animals.Count == 220)
                        {
                            uI.IsBoardOverPopulated();
                        }
                        else
                        {
                            uI.ClearErrorMessage();
                            CreateAnimal(input);
                        }

                        break;

                    case "q":

                        break;

                    default:

                        break;
                }
            }
        }

        /// <summary>
        /// Adds a new animal to list based on user input.
        /// Prints it on a random position on gameboard.
        /// </summary>
        /// <param name="input"> user inputs L or A </param>
        private Animal CreateAnimal(string input)
        {
            Lion lion = new Lion();
            while (animalList.Animals.Count < 221)
            {
                int X = random.Next(0, 100);
                int Y = random.Next(4, 30);
                int[] randomPosition = new int[2];
                randomPosition[0] = X;
                randomPosition[1] = Y;

                if (animalList.Animals.Where(a => a.Position[0] == X && a.Position[1] == Y).Any())
                {
                    // Continue.
                }
                else
                {
                    if (input == "l")
                    {
                        lion = new Lion();
                    }
                    else
                    {
                        animal = new Lion();
                    }
                    if (animalList.Animals != null)
                    {
                        animal.ID = animalList.Animals.Count + 1;
                    }
                    animalList.Animals.Add(animal);

                    uI.PrintAnimal(animal.Position[0], animal.Position[1], animal.Trigger);
                    break;
                }
            }            

            return animal;
        }
    }
}
