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
        public abstract string Trigger { get;}

        // Different Ranges for Lion and Antelopes.
        public abstract int Range { get;}

        // Stores current health of animal.
        public int Health { get; set; }

        // Stores current animal position on board.
        public int[] Position { get; set; }

        // Set true for Lions. Might be the same as AvoidPredator.
        public abstract bool IsPredator { get;}

        // False by default. Sets to true if same species in range for 3 turns. True triggers birth.
        public bool IsMateAvailable { get; set; }
    }
}
