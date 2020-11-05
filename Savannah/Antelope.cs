using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savannah
{
    public class Antelope : Animal
    {
        // Antelope is always created by pressing A.
        public string AntelopeTrigger = "a";
        public override string Trigger { get { return AntelopeTrigger; } set { AntelopeTrigger = value; } }

        public int AntelopeHealth;
        public override int Health { get { return AntelopeHealth; } set { AntelopeHealth = value; } }

        // Antelope's vision range is always 2.
        public int AntelopeRange = 5;
        public override int Range { get { return AntelopeRange; } set { AntelopeRange = value; } }

        // Antelope is always the prey.
        public bool IsAntelopePredator = false;
        public override bool IsPredator { get { return IsAntelopePredator; } set { IsAntelopePredator = value; } }

        /// <summary>
        /// Checks if there are any enemies (animals with different trigger) in range.
        /// </summary>
        /// <param name="animals"></param>
        /// <returns></returns>
        public override bool CheckRange(AnimalList animals)
        {
            isEnemyDetected = false;

            for (int line = -Range; line <= Range; line++)
            {
                for (int col = -Range; col <= Range; col++)
                {
                    // Checks if there is any animal of different species in range
                    if (animals.Animals.Where(a => a.Position[0] == Position[0] + col && a.Position[1] == Position[1] + line && a.Trigger != Trigger).Any())
                    {
                        EnemyX = Position[0] + col;
                        EnemyY = Position[1] + line;
                        isEnemyDetected = true;

                        break;
                    }
                }
            }

            // Looses all health if the enemy is in the same spot.
            if (EnemyX == Position[0] && EnemyY == Position[1])
            {
                Health = 0;
            }


            return isEnemyDetected;
        }
        /// <summary>
        /// Runs away from enemy.
        /// </summary>
        public override Array EnemyInteraction(int enemyX, int enemyY, int boardsizeX, int boardsizeY)
        {
            Random random = new Random();
            int newPositionX = 0;
            int newPositionY = 0;
            

            // Just runs away with no console size constraints.
            if ((Position[0] < enemyX) && (Position[0] != 0))
            {
                newPositionX = Position[0] - 1;
            }
            else if ((Position[0] > enemyX) && (Position[0] != boardsizeX))
            {
                newPositionX = Position[0] + 1;
            }
            else
            {
                newPositionX = Position[0];
            }
            if ((Position[1] < enemyY) && (Position[1] != 0))
            {
                newPositionY = Position[1] - 1;
            }
            else if ((Position[1] > enemyY) && (Position[1] != boardsizeY))
            {
                newPositionY = Position[1] + 1;
            }
            else
            {
                newPositionY = Position[1];
            }


            Position[0] = newPositionX;
            Position[1] = newPositionY;

            return Position;
        }
    }
}
