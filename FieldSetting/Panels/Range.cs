namespace FieldSetting.Panels
{
    /// <summary>
    /// Example of range definition for numeric properties. The range allows to limit the value of the property within a certain range of values: Setting a range will then be reflected in the UI preventing the insertion of data outside a pre-established range.
    /// </summary>
    public class Range
    {
        /// <summary>
        /// Set the selling price
        /// </summary>
        [Range(1.0, 100.0, 0.5)]
        public double Price { get; set; } = 50.5;

        /// <summary>
        /// Set up purchase of Bitcoin at the set price of one USD
        /// </summary>
        public int LimitOrder { get; set; } = 100000;
        internal int LimitOrder_Min = 50000;
        internal int LimitOrder_Max = 1500000;
        internal int LimitOrder_Step = 10000;
    }
}
