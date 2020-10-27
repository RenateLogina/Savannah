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
        Animal animal = new Animal();
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
                        CreateAnimal(input);

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
            while(animalList.Animals.Count < 9)
            {
                int X = random.Next(0, 4);
                int Y = random.Next(4, 6);
                int[] randomPosition = new int[2];
                randomPosition[0] = X;
                randomPosition[1] = Y;
                //if(animalList.Animals.Contains(a => a.Position == randomPosition))
                //if(animalList.Animals.Where(a => a.Position[0] == X && a.Position[1] == Y).Any())
                //{

                //}
                //{
                //    // Continue loop.
                //}

            animal.Position = randomPosition;
            animal.PositionX = X;
            animal.PositionY = Y;
            animal.Health = 20;
            animal.IsMateAvailable = false;
            animal.ID = 1;

            if (input == "l")
            {
                animal.Species = "lion";
                animal.Range = 3;
                animal.SeekPrey = true;

            }
            else
            {
                animal.Species = "antelope";
                animal.Range = 2;
                animal.SeekPrey = false;
            }
            if(animalList.Animals != null)
            {
                animal.ID = animalList.Animals.Count + 1;
            }
            animalList.Animals.Add(new Animal()
            {
                ID = animal.ID,
                Species = animal.Species,
                Range = animal.Range,
                Health = animal.Health,
                PositionX = animal.PositionX,
                PositionY = animal.PositionY,
                Position = animal.Position,
                SeekPrey = animal.SeekPrey,
                IsMateAvailable = animal.IsMateAvailable,
            });

            uI.PrintAnimal(animal.PositionX, animal.PositionY, animal.Species);

            return animal;
        }
    }
}
