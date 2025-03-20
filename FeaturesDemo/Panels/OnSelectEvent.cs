namespace FeaturesDemo.Panels
{
    /// <summary>
    /// Demonstration of the OnSelect event on arrays
    /// OnSelect is an event that can be associated with array properties, in order to create a GUI-side selector that does something when the user selects an element in the list.
    /// To create the event, you need to set a method with a single parameter of type int, with the suffix OnSelect + the name of the array you want to cook the interaction with the user.
    /// For example, for the Persons array, the name of the selection event will be OnSelectPersons(the prefix OnSelect + Persons, which is the name of the array).
    /// Since the array is not editable, it must have public only for Get, while for Set it must not be public.
    /// The following is an example of a selector of elements in an array, which executes some code when the user has made the selection.    
    /// </summary>
    public class OnSelectEvent
    {

        /// <summary>
        /// Select a user from list
        /// </summary>
        public string[] Persons { get; } = ["John Smith", "Emily Johnson", "Michael Brown", "Sarah Davis", "James Miller"]; // We want this property to be public but not editable by the user, basically read-only. So we just set Get (Set is omitted, or we can add it as private if we need)

        /// <summary>
        /// Event that fires when the user selects an element of Persons in the GUI
        /// This happens because we have created a function with an int parameter called "OnSelect" + the name of the array for which we want to create the event.
        /// </summary>
        /// <param name="item"></param>
        internal void OnSelectPersons(int item) // Method name  = OnSelect + Person
        {
            SelectedPerson = Persons[item];
            // Here, you can add some code that runs automatically when the item is selected!
        }

        /// <summary>
        /// Selected Person
        /// </summary>
        public string? SelectedPerson { get; private set; }

    }
}
