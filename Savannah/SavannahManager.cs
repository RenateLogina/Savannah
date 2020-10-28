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
            //Lion lion = new Lion();
            //Antelope antelope = new Antelope();
            Animal animal = null;
            ////Animal animal = new Animal();

            while (animalList.Animals.Count < 221)
            {
                int xPosition = random.Next(0, 100);
                int yPosition = random.Next(4, 30);
                int[] randomPosition = new int[] { xPosition, yPosition };

                if (animalList.Animals.Where(a => a.Position[0] == xPosition && a.Position[1] == yPosition).Any())
                {
                    // Continue.
                }
                else
                {
                    
                    if (input == "l")
                    {
                        Lion lion = new Lion();
                        lion.Position = new int[2] { xPosition, yPosition };

                        if (animalList.Animals != null)
                        {
                            lion.ID = animalList.Animals.Count + 1;
                        }
                        else
                        {
                            lion.ID = 1;
                        }

                        animal = lion;
                        animalList.Animals.Add(new Lion()
                        {
                            ID = animal.ID,
                            Trigger = animal.Trigger,
                            LionRange = animal.Range,
                            Health = animal.Health,
                            Position = animal.Position,
                            IsPredator = animal.IsPredator,
                            IsMateAvailable = animal.IsMateAvailable,

                        }) ;
                        uI.PrintAnimal(animal.Position[0], animal.Position[1], animal.Trigger);
                    }
                    else
                    {
                        Antelope antelope = new Antelope();
                        if (animalList.Animals != null)
                        {
                            antelope.ID = animalList.Animals.Count + 1;
                        }
                        else
                        {
                            antelope.ID = 1;
                        }

                        animal = antelope;
                        animalList.Animals.Add(new Antelope());
                        uI.PrintAnimal(antelope.Position[0], antelope.Position[1], antelope.Trigger);
                    }                                     

                    break;
                }
            }            

            return animal;
        }
    }
}
