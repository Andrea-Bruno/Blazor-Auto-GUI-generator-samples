namespace LoginAndSession.Panels
{
    /// <summary>
    /// Example of a class whose user interface will be usable for automatic calculation
    /// </summary>
    public class AutoCalculation
    {
        /// <summary>
        /// First numerical addend
        /// </summary>
        public long FirstAddend { get; set; } = 6;

        /// <summary>
        /// Second numerical addend
        /// </summary>
        public long SecondAddend { get; set; } = 8;

        /// <summary>
        /// Sum result
        /// </summary>
        public long Sum => FirstAddend + SecondAddend;

        /// <summary>
        /// Does the sum give an even result?
        /// </summary>
        public bool EvenNumber => Sum % 2 == 0;
    }
}
