using System.ComponentModel;

namespace FieldSetting.Panels
{
    /// <summary>
    /// Demonstration of the ReadOnly attribute
    /// The [ReadOnly(true)] attribute forces properties with the public setter to be read-only as well.
    /// </summary>
    public class ReadonlyAttribute
    {
        /// <summary>
        /// Array of strings with public setter
        /// </summary>
        public string[] StringsArray { get; set; } = ["one", "two", "three"];

        /// <summary>
        /// Array of strings with public setter and ReadOnly attribute
        /// </summary>
        [ReadOnly(true)]
        public string[] StringArrayReadonly { get; set; } = ["one", "two", "three"];
    }
}
