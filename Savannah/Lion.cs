using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Savannah
{
    public class Lion : Animal
    {
        // Lion is always created by pressing L.
        public string LionTrigger = "l";
        public override string Trigger { get { return LionTrigger; } set { LionTrigger = value; } }

        public int LionHealth;
        public override int Health { get { return LionHealth; } set { LionHealth = value; } }

        // Lion's vision range is always 3.
        public int LionRange = 7;
        public override int Range { get { return LionRange; } set { LionRange = value; } }

        // Lion is always the predator.
        public bool IsLionPredator = true;
        public override bool IsPredator { get { return IsLionPredator; } set { IsLionPredator = value; } }
        public int SpecialAction = 2;

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

            // Lion sits on the same spot (executes interaction) for 1 extra turn to eat.
            if (EnemyX == Position[0] && EnemyY == Position[1])
            {
                SpecialAction--;
                if(SpecialAction == 0)
                {
                    isEnemyDetected = false;
                    SpecialAction = 2;
                }
            }

            return isEnemyDetected;
        }

        /// <summary>
        /// Runs after enemy.
        /// </summary>
        public override Array  Interaction(int enemyX, int enemyY, int boardsizeX, int boardsizeY)
        {
            // Just runs after enemy with no console size constraints.
            int newPositionX = 0;
            int newPositionY = 0;

            // Just runs away with no console size constraints.
            if (Position[0] < enemyX)
            {
                newPositionX = Position[0] + 1;
            }
            else if (Position[0] > enemyX)
            {
                newPositionX = Position[0] - 1;
            }
            else
            {
                newPositionX = Position[0];
            }

            if (Position[1] < enemyY)
            {
                newPositionY = Position[1] + 1;
            }
            else if (Position[1] > enemyY)
            {
                newPositionY = Position[0] - 1;
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
