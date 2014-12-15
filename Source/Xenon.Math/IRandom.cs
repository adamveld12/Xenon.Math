namespace Xenon.Math
{
    /// <summary>
    /// An interface for random generator
    /// </summary>
    public interface IRandom
    {
        /// <summary>
        /// Generates and returns a random number
        /// </summary>
        /// <returns></returns>
        int Next();

        /// <summary>
        /// Generates and returns a random number
        /// </summary>
        /// <param name="max">The highest value that can be returned</param>
        /// <returns></returns>
        int Next(int max);

        /// <summary>
        /// Generates and returns a random number
        /// </summary>
        /// <param name="min">The lowest value returned</param>
        /// <param name="max">The highest value returned</param>
        /// <returns></returns>
        int Next(int min, int max);
    }
}