using System;
using System.Linq;

namespace Savannah
{
    /// <summary>
    /// Stores all properties of an animal object.
    /// </summary>
    public abstract class Animal
    {
        // Animal ID
        public int ID { get; set; }

        // Keystroke converted to string that triggers the creation. L for animals, A for antelopes.
        public abstract string Trigger { get; set; }

        // Different Ranges for Lion and Antelopes.
        public abstract int Range { get; set; }

        // Stores current health of animal.
        public int Health { get; set; }

        // Stores current animal position on board.
        public int[] Position { get; set; }

        // Stores enemyPosition if there is one within range.
        public int[] EnemyPosition { get; set; }

        // Set true for Lions. Might be the same as AvoidPredator.
        public abstract bool IsPredator { get; set; }

        // False by default. Sets to true if same species in range for 3 turns. True triggers birth.
        public bool IsMateAvailable { get; set; }

        public void RandomMovement(int randomX, int randomY)
        {
            int newPositionX = Position[0] + (randomX);
            int newPositionY = Position[1] + (randomY);

            Position[0] = newPositionX;
            Position[1] = newPositionY;
        }

        /// <summary>
        /// Checks if there are any enemies (animals with different trigger) in range.
        /// </summary>
        /// <param name="animals"></param>
        /// <returns></returns>
        public bool CheckRange(AnimalList animals)
        {
            bool isEnemyDetected = false;
            for (int yDimension = -Range; yDimension <= Range + 2; yDimension++)
            {
                for (int xDimension = -Range; xDimension <= Range + 2; xDimension++)
                {
                    // Checks if there is any animal of different species in range
                    if (animals.Animals.Where(a => a.Position[0] == Position[0] + xDimension && a.Position[1] == Position[1] + yDimension && a.Trigger != Trigger).Any())
                    {
                        if(EnemyPosition == null)
                        {
                            int xPosition = Position[0] + xDimension;
                            int yPosition = Position[1] + yDimension;
                            EnemyPosition = new int[2] { xPosition, yPosition };
                            isEnemyDetected = true;
                        }
                        else
                        {
                            EnemyPosition[0] = Position[0] + xDimension;
                            EnemyPosition[1] = Position[1] + yDimension;
                        }
                        
                    }
                }
            }
            return isEnemyDetected;
        }

        public abstract void Interaction();
    }
}
