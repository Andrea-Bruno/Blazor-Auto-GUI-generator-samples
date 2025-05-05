namespace ProjectTemplate.Panels
{
    /// <summary>
    /// Example of a class whose user interface will be usable for automatic calculation
    /// </summary>
    public class Panel1
    {
        /// <summary>
        /// First numerical factor
        /// </summary>
        public long Multiplier { get; set; } = 6;

        /// <summary>
        /// Second numerical factor
        /// </summary>
        public long Multiplicand { get; set; } = 8;

        /// <summary>
        /// Multiplication result
        /// </summary>
        public long Product => Multiplier * Multiplicand;

        /// <summary>
        /// It's an even number
        /// </summary>
        public bool EvenNumber => Product % 2 == 0;
    }
}
