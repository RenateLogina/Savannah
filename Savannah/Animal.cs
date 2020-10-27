namespace Savannah
{
    /// <summary>
    /// Stores all properties of an animal object.
    /// </summary>
    public class Animal
    {
        // Animal ID
        public int ID { get; set; }

        // Lion or Antelope.
        public string Species { get; set; }

        // Different Ranges for Lion and Antelopes.
        public int Range { get; set; }

        // Stores current health of animal.
        public int Health { get; set; }

        // Stores current animal position X on board.
        public int PositionX { get; set; }

        // Stores current animal position Y on board.
        public int PositionY { get; set; }

        // Set true for Lions. Might be the same as AvoidPredator.
        public bool SeekPrey { get; set; }

        // False by default. Sets to true if same species in range for 3 turns. True triggers birth.
        public bool IsMateAvailable { get; set; }
    }
}
