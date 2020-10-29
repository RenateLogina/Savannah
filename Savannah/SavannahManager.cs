using System;
using System.Linq;
using System.Timers;

namespace Savannah
{
    /// <summary>
    /// Executes actions and connects UI, Logic and other classes.
    /// </summary>
    public class SavannahManager
    {
        SavannahUI uI = new SavannahUI();
        AnimalList animalList = new AnimalList();
        Random random = new Random();
        public Timer MyTimer;
        int count;

        /// <summary>
        /// Starts game by showing welcome message and instructions.
        /// Awaits for user input.
        /// </summary>
        public void StartGame()
        {
            uI.StartGameMenu();
            SetGameTimer();
            Toggler();
        }

        /// <summary>
        /// Sets timer to 1 sek. Animals move each second.
        /// </summary>
        private void SetGameTimer()
        {
            MyTimer = new System.Timers.Timer(500);
            MyTimer.Elapsed += SavannahLoop;
            MyTimer.AutoReset = true;
            MyTimer.Enabled = true;
        }
        private void Toggler()
        {
            while (MyTimer.Enabled)
            {
                var input = uI.ToggleInput().ToString().ToLower();
                switch (input)
                {
                    case "l":
                    case "a":
                        if (animalList.Animals.Count < 120)
                        {
                            CreateAnimal(input);
                        }

                        break;

                    case "u":
                        uI.PrintTest();

                        break;

                    case "q":
                        break;

                    default:
                        break;
                }
            }
        }

        public void SavannahLoop(Object source, ElapsedEventArgs e)
        {
            if (animalList.Animals != null)
            {
                uI.ClearAnimals();
                RandomMovement();
                uI.PrintArray(animalList);
            }
        }

        /// <summary>
        /// All animals move randomly within the bounds of Savannah.
        /// This probably should be made into an animal method and be a part of a larger method that calculates all movement.
        /// </summary>
        private void RandomMovement()
        {
            bool isNotInSavannah = false;
            foreach (var animal in animalList.Animals)
            {
                do
                {
                    int randomNumberX = random.Next(-1, 2);
                    int randomNumberY = random.Next(-1, 2);
                    int newPositionX = animal.Position[0] + (randomNumberX);
                    int newPositionY = animal.Position[1] + (randomNumberY);

                    // Checks for borders.
                    if (newPositionX < 0 || newPositionX > 98 || newPositionY < 4 || newPositionY > 28)
                    {
                        isNotInSavannah = true;
                    }
                    else
                    {
                        //uI.ClearAnimal(animal.Position[0], animal.Position[1]);
                        animal.Position[0] = newPositionX;
                        animal.Position[1] = newPositionY;

                        //uI.PrintAnimal(newPositionX, newPositionY, animal.Trigger, count);
                        isNotInSavannah = false;
                    }

                } while (isNotInSavannah == true);
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

            while (animalList.Animals.Count < 120)
            {
                int xPosition = random.Next(0, 98);
                int yPosition = random.Next(4, 28);
                int[] randomPosition = new int[] { xPosition, yPosition };
                bool spotIsTaken = false;

                for(int sizeY = -2 ; sizeY < 3; sizeY ++)
                {
                    for (int sizeX = -2; sizeX < 3; sizeX++)
                    {
                        if (animalList.Animals.Where(a => a.Position[0] + sizeX == xPosition && a.Position[1] + sizeY == yPosition).Any())
                        {
                            spotIsTaken = true;
                        }
                    }
                }
                if (!spotIsTaken)
                {
                    count++;

                    // Adds a Lion to AnimalList and prints it too
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

                        animalList.Animals.Add(new Lion()
                        {
                            ID = lion.ID,
                            Trigger = lion.Trigger,
                            LionRange = lion.Range,
                            Health = lion.Health,
                            Position = lion.Position,
                            IsPredator = lion.IsPredator,
                            IsMateAvailable = lion.IsMateAvailable,

                        });

                        //uI.PrintAnimal(lion.Position[0], lion.Position[1], lion.Trigger, count);
                        //uI.PrintArray(animalList);
                    }

                    // Adds an Antelope to AnimalList and prints it too
                    else
                    {
                        Antelope antelope = new Antelope();
                        antelope.Position = new int[2] { xPosition, yPosition };

                        if (animalList.Animals != null)
                        {
                            antelope.ID = animalList.Animals.Count + 1;
                        }
                        else
                        {
                            antelope.ID = 1;
                        }

                        animalList.Animals.Add(new Antelope()
                        {
                            ID = antelope.ID,
                            Trigger = antelope.Trigger,
                            Range = antelope.Range,
                            Health = antelope.Health,
                            Position = antelope.Position,
                            IsPredator = antelope.IsPredator,
                            IsMateAvailable = antelope.IsMateAvailable,

                        });
                        //uI.PrintAnimal(antelope.Position[0], antelope.Position[1], antelope.Trigger, count);
                    }

                    break;
                }              
            }            

            return animal;
        }

    }
}
