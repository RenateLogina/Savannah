using System;

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
            animal.PositionX = random.Next(0, 100);
            animal.PositionY = random.Next(6, 30);
            animal.Health = 20;
            animal.IsMateAvailable = false;

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

            animalList.Animals.Add(new Animal()
            {
                ID = animalList.Animals.Count + 1,
                Species = animal.Species,
                Range = animal.Range,
                Health = animal.Health,
                PositionX = animal.PositionX,
                PositionY = animal.PositionY,
                SeekPrey = animal.SeekPrey,
                IsMateAvailable = animal.IsMateAvailable,
            });

            uI.PrintAnimal(animal.PositionX, animal.PositionY, animal.Species);

            return animal;
        }
    }
}
