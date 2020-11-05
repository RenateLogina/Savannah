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
        public abstract int Health { get; set; }

        // Stores current animal position on board.
        public int[] Position { get; set; }

        // Stores enemyPosition X if there is one within range.
        public int EnemyX { get; set; }

        // Stores enemyPosition Y if there is one within range.
        public int EnemyY { get; set; }

        // stores if enemy has been detected.
        public bool isEnemyDetected;

        // Set true for Lions. Might be the same as AvoidPredator.
        public abstract bool IsPredator { get; set; }

        // False by default. Sets to true if same species in range for 3 turns. True triggers birth.
        public bool IsMateAvailable { get; set; }

        /// <summary>
        /// Checks if there are any enemies (animals with different trigger) in range.
        /// </summary>
        /// <param name="animals"></param>
        /// <returns></returns>
        public abstract bool CheckRange(AnimalList animals);

        /// <summary>
        /// If animal encounters an enemy, it either pursues or flees.
        /// </summary>
        /// <param name="enemyX"> Enemy coordinate col. </param>
        /// <param name="enemyY"> Enemy coordinate line. </param>
        /// <returns> new position of the animal. </returns>
        public abstract Array EnemyInteraction(int enemyX, int enemyY, int boardsizeX, int boardsizeY);

        /// <summary>
        /// Changes animal position using random numbers generated in Manager.
        /// </summary>
        /// <param name="randomX"> Random number for col coordinate </param>
        /// <param name="randomY"> Random number for line coordinate </param>
        public void RandomMovement(int randomX, int randomY)
        {
            int newPositionX = Position[0] + (randomX);
            int newPositionY = Position[1] + (randomY);

            Position[0] = newPositionX;
            Position[1] = newPositionY;
        }
    }
}
