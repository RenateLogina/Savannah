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
        int boardsizeX = 30;
        int boardsizeY = 10;
        int ID;

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
            if(animalList.Animals != null)
            {
                foreach (var animal in animalList.Animals)
                {
                    animal.CheckRange(animalList);
                    if (animal.Health != 0)
                    {
                        if (animal.isEnemyDetected == true)
                        {
                            animal.Interaction(animal.EnemyX, animal.EnemyY, boardsizeX, boardsizeY);
                        }
                        else if (animal.isEnemyDetected == false)
                        {
                            RandomMovement(animal);
                        }

                        animal.Health--;
                    }
                    else
                    {
                        animalList.Animals.Remove(animal);
                    }
                }

                uI.PrintArray(animalList, boardsizeX, boardsizeY);
            }
            else
            {
                uI.PrintMenu();
            }
           
        }

        /// <summary>
        /// All animals move randomly within the bounds of Savannah.
        /// This probably should be made into an animal method and be a part of a larger method that calculates all movement.
        /// </summary>
        private void RandomMovement(Animal animal)
        {
            // Else random movement

            bool isNotInSavannah = false;
            do
            {
                int randomNumberX = random.Next(-1, 2);
                int randomNumberY = random.Next(-1, 2);
                int newPositionX = animal.Position[0] + (randomNumberX);
                int newPositionY = animal.Position[1] + (randomNumberY);

                // Checks for borders.
                if (newPositionX < 0 || newPositionX > boardsizeX || newPositionY < 4 || newPositionY > boardsizeY)
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
                int xPosition = random.Next(0, boardsizeX);
                int yPosition = random.Next(4, boardsizeY);
                int[] randomPosition = new int[] { xPosition, yPosition };
                bool spotIsTaken = false;


                if (animalList.Animals.Where(a => a.Position[0] == xPosition && a.Position[1] == yPosition).Any())
                {
                    spotIsTaken = true;
                }

                if (!spotIsTaken)
                {
                    count++;

                    // Adds a Lion to AnimalList
                    if (input == "l")
                    {
                        lion.Position = new int[2] { xPosition, yPosition };
                        ID++;
                        lion.ID = ID;
                        lion.Health = 40;


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
                        ID++;
                        antelope.ID = ID;
                        antelope.Health = 40;

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
    }
}
