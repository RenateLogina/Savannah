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
        Lion lion = new Lion();
        Antelope antelope = new Antelope();
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

        /// <summary>
        /// Listens for user input.
        /// </summary>
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

                    case "q":
                        break;

                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// List of actions in a single game loop.
        /// </summary>
        public void SavannahLoop(Object source, ElapsedEventArgs e)
        {
            if (animalList.Animals != null)
            {
                Movement();
                uI.PrintArray(animalList);
            }
        }

        /// <summary>
        /// All animals move randomly within the bounds of Savannah.
        /// This probably should be made into an animal method and be a part of a larger method that calculates all movement.
        /// </summary>
        private void Movement()
        {
            // Check if any other animal in vicinity

            // Else random movement
            foreach (var animal in animalList.Animals)
            {
                bool isNotInSavannah = false;

                // If any enemy in range, run from or chase enemy.
                if (animal.CheckRange(animalList))
                {
                    animal.Interaction();
                }
                // Move randomly.
                else
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
                            animal.RandomMovement(randomNumberX, randomNumberY);
                            isNotInSavannah = false;
                        }

                    } while (isNotInSavannah == true);
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
            Animal animal = null;

            while (animalList.Animals.Count < 121)
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

                    // Adds a Lion to AnimalList
                    if (input == "l")
                    {
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

                    }

                    // Adds an Antelope to AnimalList
                    else
                    {
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
                    }

                    break;
                }              
            }            

            return animal;
        }

        private Array CheckRange()
        {
            int[] enemyPosition = new int[2];
            foreach (var animal in animalList.Animals)
            {
                for (int yDimension = -animal.Range; yDimension <= animal.Range+2; yDimension++)
                {
                    for (int xDimension = -animal.Range; xDimension <= animal.Range + 2; xDimension++)
                    {
                        // Checks if there is any animal of different species in range
                        if(animalList.Animals.Where(a => a.Position[0] == animal.Position[0] + xDimension && a.Position[1] == animal.Position[0] + yDimension && a.Trigger != animal.Trigger).Any())
                        {
                            enemyPosition[0] = animal.Position[0] + xDimension;
                            enemyPosition[1] = animal.Position[1] + yDimension;
                        }
                    }
                }
            }

            return enemyPosition;
        }

    }
}
