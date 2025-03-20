namespace FeaturesDemo.Panels
{
    /// <summary>
    /// Demonstration of how to hide fields dynamically
    /// </summary>
    public class HiddenAttribute
    {
        /// <summary>
        /// Demo field
        /// </summary>
        [HiddenBind("IsHidden")] // Associate the display of this with the value of the IsHidden field
        public string Currency { get; set; } = "USD";

        internal bool IsHidden; // This element is the hidden field of the element above because it is associated with the HiddenBind attribute

        /// <summary>
        /// Invert the display state
        /// </summary>
        public void ChangeHiddenStatusOfCurrencyField() => IsHidden = !IsHidden;

        /// <summary>
        /// Demo field
        /// </summary>
        public string CryptoCyrrency { get; set; } = "Bitcoin";


        private bool CryptoCyrrency_Hidden = false; // This element is the hidden field of the element above because it has the same name plus the suffix _hidden

        /// <summary>
        /// Invert the display state
        /// </summary>
        public void ChangeHiddenStatusOfCryptoCyrrencyField() => CryptoCyrrency_Hidden = !CryptoCyrrency_Hidden;

        /// <summary>
        /// Permanently hidden field
        /// </summary>
        [HiddenFromGUI]
        public string HiddenFRonGUI = "Permanently hidden field";

        /// <summary>
        /// This field, if present, controls the graphical representation of the class in the GUI.
        /// </summary>
        private bool Hidden;

        /// <summary>
        /// This button hides/shows the item related to this panel from the right side menu.
        /// </summary>
        public void ToggleFromMenu() => Hidden = !Hidden;
    }
}
