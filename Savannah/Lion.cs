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
        public override string Trigger { get { return LionTrigger; } }

        // Lion's vision range is always 3.
        public int LionRange = 3;
        public override int Range { get { return LionRange; } }

        // Lion is always the predator.
        public bool IsLionPredator = true;
        public override bool IsPredator { get { return IsLionPredator; } }
    }
}
