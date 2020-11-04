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

        // Antelope's vision range is always 2.
        public int AntelopeRange = 4;
        public override int Range { get { return AntelopeRange; } set { AntelopeRange = value; } }

        // Antelope is always the prey.
        public bool IsAntelopePredator = false;
        public override bool IsPredator { get { return IsAntelopePredator; } set { IsAntelopePredator = value; } }

        /// <summary>
        /// Runs away from enemy.
        /// </summary>
        public override void Interaction()
        {
            int newPositionX = Position[0];
            int newPositionY = Position[1];

            // Just runs away with no console size constraints.
            if (Position[0] < EnemyPosition[0])
            {
                newPositionX--;
            }
            if (Position[0] > EnemyPosition[0])
            {
                newPositionX++;
            }
            if (Position[1] < EnemyPosition[1])
            {
                newPositionY--;
            }
            if (Position[1] > EnemyPosition[1])
            {
                newPositionY++;
            }

            Position[0] = newPositionX;
            Position[1] = newPositionY;
        }
    }
}
