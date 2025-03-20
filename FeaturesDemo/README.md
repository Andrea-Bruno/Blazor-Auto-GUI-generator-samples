## Features

### OnSelect (Event)

OnSelect is an event that can be associated with array properties, in order to create a GUI-side selector that does something when the user selects an element in the list.
To create the event, you need to set a method with a single parameter of type int, with the suffix OnSelect + the name of the array you want to cook the interaction with the user.
For example, for the Persons array, the name of the selection event will be OnSelectPersons (the prefix OnSelect + Persons, which is the name of the array).
Since the array is not editable, it must have public only for Get, while for Set it must not be public.
The following is an example of a selector of elements in an array, which executes some code when the user has made the selection.

```csharp
    /// <summary>
    /// Demonstration of the OnSelect event on arrays
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
```

## Hidden a element dynamically

There are two ways to dynamically hide and show elements from the GUI:
The first is to assign the attribute [HiddenBind("BindBoolNameField")] to the element, indicating the name of a bool field in the same class. From our example, replace "BindBoolNameField" with the name of the field you use in your class.
The second is to create a boolean field with the name of the element to hide, plus the suffix "_hidden". This field will automatically become the hidden property for the field specified in the initial part of the name.
It is important to keep in mind that in both the first and second cases, you need to refer to a bool field, and not to a property. The visibility of the boolean field (public, private, etc.) is irrelevant.
To hide public elements from the GUI, you can simply use the attribute [HiddenFromGUI].
In this example class, all these cases are considered:

```csharp
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
```

As we have seen, the class represents a panel, whose menu item to access it appears in the GUI sidebar. To hide the panel, simply add a bool field called Hidden and set it to true. This can be done dynamically during the operation of the app.

As you may have noticed, hiding and showing an element is very simple and intuitive!