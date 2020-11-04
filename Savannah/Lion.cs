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

        // Lion's vision range is always 3.
        public int LionRange = 5;
        public override int Range { get { return LionRange; } set { LionRange = value; } }

        // Lion is always the predator.
        public bool IsLionPredator = true;
        public override bool IsPredator { get { return IsLionPredator; } set { IsLionPredator = value; } }

        /// <summary>
        /// Runs after enemy.
        /// </summary>
        public override void Interaction()
        {
            // Just runs after enemy with no console size constraints.
            int newPositionX = Position[0];
            int newPositionY = Position[1];

            // Just runs away with no console size constraints.
            if (Position[0] < EnemyPosition[0])
            {
                newPositionX++;
            }
            if (Position[0] > EnemyPosition[0])
            {
                newPositionX--;
            }
            if (Position[1] < EnemyPosition[1])
            {
                newPositionY++;
            }
            if (Position[1] > EnemyPosition[1])
            {
                newPositionY--;
            }

            Position[0] = newPositionX;
            Position[1] = newPositionY;
        }
    }
}
