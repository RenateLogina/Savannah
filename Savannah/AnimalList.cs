namespace Savannah
{
    using System.Collections.Generic;
    /// <summary>
    /// Stores all live animals.
    /// </summary>
    public class AnimalList
    {
        /// <summary>
        /// List of live animals containing animal objects.
        /// </summary>
        public List<Animal> Animals { get; set; }
        public AnimalList()
        {
            Animals = new List<Animal>();
        }
    }
}
