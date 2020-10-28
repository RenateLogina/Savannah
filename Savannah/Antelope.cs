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
        public int AntelopeRange = 2;
        public override int Range { get { return AntelopeRange; } set { AntelopeRange = value; } }

        // Antelope is always the prey.
        public bool IsAntelopePredator = false;
        public override bool IsPredator { get { return IsAntelopePredator; } set { IsAntelopePredator = value; } }
    }
}
