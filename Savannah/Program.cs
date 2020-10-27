namespace Savannah
{
    using System;

    /// <summary>
    /// App entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Starts program.
        /// </summary>
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            SavannahManager manager = new SavannahManager();
            manager.StartGame();
            Console.ReadKey(true);
        }
    }
}
