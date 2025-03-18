
# UISupportManual

This guide is very short because the goal of this project is to automate the creation of the GUI (user interface) without changing the programming methodology with which developers create their works. The precautions to be taken will therefore be minimal and all in line with the "best practice". What does all this mean? It means that if you are a developer already attentive to the use of the "best practice", then you are already able to use this powerful and miraculous development tool!
The simplicity at the base of this innovative technique is impressive for its simplicity, and as a demonstration of all this we have attached to this document some projects that you can open, run and modify in order to become familiar with this exciting and surprising technology.

## Multi Panels (Basic logic)

The purpose of the automatic generator of graphical interfaces for **Blazor** is to create graphical interfaces without changing the programming style of the back-end. Developers will be able to use this tool immediately by simply developing the back-end following the best programming practices.
This is a simple example of how the UI is automatically created starting from a class. In practice, the only thing to know is that the public methods and properties will have a graphical correspondence created automatically in the UI. Some tricks allow you to intervene finely on how the graphics will be created.
If you want to have multiple pages/panels, just create multiple classes, each specific to the functionality that will belong to the automatically generated page.
Insert the classes that will represent the panels, in the Panels folder of the project, these classes will be examined in real time by the assembly analyzer which will create their user interface to interact with them. For each class a menu item will appear in the left side panel of the web interface.
Static classes are for global use and the values ​​set in them will remain unchanged even after the application is restarted (without the need to save them).
Non-static classes will instead be assigned to users, each user will have his own instance of the non-static class which will be associated with his browsing session.

### Multiple panelsIn this example we have multiple panels, each related to a class located in the Panels directory, and each generates a menu item in the user interface.
As an exercise try to modify existing classes, add properties and create new classes, you will see that everything will be reflected in the GUI.
Ricardo: Only public properties and public methods are visually represented in the GUI.
Properties that are public for reading but private for writing in the user interface will be represented as read-only (you cannot edit them)., example:

```csharp
        /// <summary>
        /// Your legal name (This property being private for writing, it is not editable from GUI)
        /// </summary>
        public string? Name { get; private set; }
```

Remember, only properties are visible in the GUI and allow user interaction:
```csharp
        /// <summary>
        /// This element is a public property, so it will be editable from GUI
        /// </summary>
        public string? Field1 { get; set; }

        /// <summary>
        /// This element is public, but it is not a property, so it will not be visible in the GUI.
        /// </summary>
        public string? Field2;
```

As you have seen everything is intuitive and simple and you do not have to add anything to your software developer skills! You are immediately ready to use this revolutionary technology!

An important thing to keep in mind is that the GUI generation system works exactly following the concept of "access level" used in programming. This means that everything we want to be rendered in the GUI must be declared as Public. Everything that is declared as private or for internal use will not have any type of rendering in the GUI.
This is exactly the same concept that is used when developing libraries, where you want to make public only the properties and methods that can be interacted with from the outside.
Since the technique adopted is identical to the one adopted to create libraries, and since libraries are the heart of the back-end of a program, it is appropriate that the automatic creation of the front-end made through this tool, comes from a back-end built in a very similar if not identical way to how it would normally be done following programming standards.
The properties and methods, if public, will be rendered in the GUI, while the fields will not be rendered even if public.
For properties, these will be editable from GUI if the Set method is also public.
This table summarizes the rendering logic of the components:

| Element  | GUI rendering    | Editable         | Statement example                         |
|----------|------------------|------------------|-------------------------------------------|
| Property | if Get is public | If Set is public | public string? Name { get; private set; } |
| Method   | if it's public   | none             | public  int AddNumbers(int a, int b) {...}|                                   |
| Field    | none             | name             | public string? Field2;                    |

Another thing to keep in mind is that **Reference Types** create sub-panels, as they are collectors of properties and methods.
With these little notions you have learned the fundamentals of this exciting technology!

## Special Words (Basic logic)

Our concept is to create a powerful tool for the automatic front end dinner of applications without having to add the burden for the developer of having to learn convoluted and complicated mechanisms.
In practice, our tool allows anyone to speed up their work by 70% without having to acquire new professional skills.
Our implementation of special words also falls within this perspective, which are commonly used words that, if inserted in the description or in the name of the properties, make them take on particular characteristics.

### Special Words:

| Special Words  | type             | Placement           |
|----------------|------------------|---------------------|
| date           | DateTime, String | name or description |
| time           | DateTime, String | name or description |
| password       | String           | name or description |
| color          | String           | name or description |
| email, e-mail  | String           | name or description |
| tel, phone     | String           | name or description |
| qr             | String           | description         |
           
These keywords, if inserted in the description or in the name of the property, make the field in the GUI take on the connotation and appearance of the term they describe, which also determines its validation and the forcing of the user to insert the specific data type.

Notes on this example project: The code file that is rendered in the panel, whose entry appears in the side menu, is the one in the project folder called Panels. The example demonstrates several properties with one of the special words in the description. As you can see, the display of the property on the page takes on appropriate characteristics based on the context, thanks to the presence of the special word.
You can add other classes in the Panels folder to add new menu items and panels in the GUI that is the web page.

## Field settings

### Attributes applicable to properties

For the most common types, field validation and formatting is automatically detected. For specific fields, it is possible to set validation by adding an attribute to the property.
The supported attributes are:
**[Email] [InternationalPhone] [ZipCode] [AlphanumericPostalCode] [Url] [StrongPassword] [LettersOnly] [NumbersOnly] [Alphanumeric] [Date] [IPv4] [IPv6] [CreditCard] [ProperName] [PositiveDecimal] [FileName] [ItalianTaxCode] [ItalianLicensePlate] [Time24HourFormat] [ISBN10] [ISBN13] [HexColorCode] [MACAddress] [USSocialSecurityNumber] [USPhoneNumber] [CurrencyFormat] [LatinLettersAndSpaces] [HTMLTag] [BinaryNumber] [HexadecimalNumber] [Slug] [Percentage] [UUID] [NonEmptyStrings] [DigitsWithThousandsSeparator] [MultilingualText] [FloatingPointNumber] [PositiveIntegersOnly] [NegativeIntegersOnly] [AlphaNumericWithSpaces] [UppercaseOnly] [LowercaseOnly] [TwoDecimalFloatingPoint] [USZipPlus4Code] [FilePath] [HTMLComment] [CreditCardExpirationDate] [CanadianPostalCode] [HTMLColor] [EuropeanDate] [Base64String] [YouTubeVideoID] [IPv4CIDRBlock] [TwitterUsername] [InstagramUsername] [LinkedInProfileURL] [UUIDWithBraces]**

Here is an example of how to assign an attribute to a property:

```csharp

    public static class FieldAttributes
    {
        /// <summary>
        /// Field validation using the [Url] attribute
        /// </summary>
        [Url]
        public static string? WebAddress { get; set; }
    }

```

In the example above the [url] attribute has been assigned to the WebAddress property, this will make this field validate as a url.

We can create a public method to validate a form created by the GUI representation of the class. Inside the method, just insert the code as in the example:

```csharp

        /// <summary>
        /// Press to validate all the form fields and execute and process the submission
        /// </summary>
        [DebuggerHidden] //Prevent debugging from breaking on invalid fields
        public static void Submit()
        {
            if (!UISupportGeneric.Util.ValidateClass(typeof(FieldAttributes), out var report))
            {
                string ValidationErrorsLeteral = string.Join(Environment.NewLine, report.Select(kvp => $"{kvp.Key}: {kvp.Value}"));
                throw new Exception(ValidationErrorsLeteral);
            }

            // I put here the code that will be executed when the validation is successful!
            ...
        }
```
If the class is not static, validation occurs by passing the value of the class instance using the keyword **this**:

```csharp

            if (!UISupportGeneric.Util.ValidateClass(this, out var report))
```

It is also possible to create custom attributes by setting a regular expression:

```csharp

    public class CustomFields
    {
        /// <summary>
        /// Validates that the age is an integer between 18 and 75.
        /// </summary>
        [Regex(@"^(1[89]|[2-6][0-9]|7[0-5])$")]
        public string? Age { get; set; }

        /// <summary>
        /// Validates that the email is in a standard email format.
        /// </summary>
        [Regex(@"^[\w.-]+@[\w.-]+\.[a-zA-Z]{2,}$")]
        public string? Email { get; set; }
    }
```
In this case the validation will be based on the regular expression assigned as an attribute of the property.

In most cases setting validation is not necessary, this is also thanks to the use of special words used in the property name or in its comment, however it is possible to intervene to create fields with custom validation both through a regular expression contained in the property attributes and through particular attributes.

### Range setting

The range allows to limit the value of the property within a certain range of values: Setting a range will then be reflected in the UI preventing the insertion of data outside a pre-established range.

Example of range definition for numeric properties:

```csharp
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
```

As you can see from the example, there are two ways to set a range, the first by assigning an attribute to the property that defines its min, max, and step values ​​(**[Range(1.0, 100.0, 0.5)]**), and the second by using variables with the same name as the property with the addition of the suffixes **_Min, _Max, and _Step**. The second way is useful in all those cases where you need to change the range values ​​on the fly from the program, because since these are variables, they can be modified during the execution of the program.


As you can see this tool automatically creates the GUI, without writing additional code to the back-end functions, all in the simplest and most natural way possible!

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

## Cloud Subscription (Demo project of the automatic GUI generation tool for Blazor)

The purpose of the automatic generator of graphical interfaces for **Blazor** is to create graphical interfaces without changing the programming style of the back-end. Developers will be able to use this tool immediately by simply developing the back-end following the best programming practices.
This is a simple example of how the UI is automatically created starting from a class. In practice, the only thing to know is that the public methods and properties will have a graphical correspondence created automatically in the UI. Some tricks allow you to intervene finely on how the graphics will be created.
If you want to have multiple pages/panels, just create multiple classes, each specific to the functionality that will belong to the automatically generated page.

### In this project a page/panel is automatically created that allows the user to interact with the following class:

```csharp
using System.Text;
using System.Text.Json;
using System.Diagnostics;
namespace CloudSubscription.Panels
{
    public class CreateNewSubscription
    {
        /// <summary>
        /// This element is only useful to insert as a json parameter, it will be hidden from the GUI thanks to the attribute: [HiddenFromGUI]
        /// You can use [HiddenFromGUI] to hide public properties that should not be displayed in the GUI.
        /// </summary>
        [HiddenFromGUI]
        public string Method => nameof(CreateNewSubscription);

        /// <summary>
        /// Standard cost in Euro (daily cost for Gigabyte)
        /// </summary>
        public double DailyCostForGb { get; set; } = 0.005;


        /// <summary>
        /// Gigabytes of space required
        /// </summary>
        public int StorageSpaceGb { get; set; } = 16;

        private int StorageSpaceGb_Min = 16;

        private int StorageSpaceGb_Max = 4096;

        private int StorageSpaceGb_Step = 16;

        /// <summary>
        /// Subscription duration in days
        /// </summary>
        public int DurationOfSubscriptionInDays { get; set; } = 30;

        private int DurationOfSubscriptionInDays_Min = 30;

        private int DurationOfSubscriptionInDays_Max = 365;

        private int Coefficient => StorageSpaceGb * DurationOfSubscriptionInDays;

        /// <summary>
        /// Coefficient discount
        /// </summary>
        private double CoefficientDiscount => DiscountCoeficent(Coefficient);

        /// <summary>
        /// Coefficient discount
        /// </summary>
        private string CoefficientDiscountString => Math.Round(CoefficientDiscount, 2).ToString();

        /// <summary>
        /// Full cost not discounted
        /// </summary>
        public int FullCostInEuro => (int)(DailyCostForGb * Coefficient);


        /// <summary>
        /// Automatic discount that increases as the subscription features increase
        /// </summary>
        public string DiscountApplied => (int)((1 - CoefficientDiscount) * 100) + "% (discount of €" + Math.Round(FullCostInEuro - CostInEuro, 2) + ")"  ;


        /// <summary>
        /// Total cost in Euro, discounted
        /// </summary>
        public double CostInEuro => Math.Round(FullCostInEuro * CoefficientDiscount, 2);

        static double DiscountCoeficent(double x)
        {
            return 0.2 + 0.8 * Math.Exp(-0.00001 * x);
        }

        /// <summary>
        /// Subscriber's email address
        /// </summary>
        public string? Email { get; set; } 

        /// <summary>
        /// Confirm your subscription to the cloud service, as per your settings
        /// </summary>
        /// <returns></returns>
        [DebuggerHidden]
        public string Submit()
        {
            string jsonString = JsonSerializer.Serialize(this);
            using var client = new HttpClient();
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = client.PostAsync(Settings.ApiEndpoint, content); // Send POST request
            return response.Result.ToString();
        }
    }
}
```

This class (CreateNewSubscription) represents the back-end useful for managing a user who wants to purchase a cloud storage space. The operation is concluded by sending an instruction to a hypothetical server via API.

As you can see some properties have values with the same name and suffixes **_Min _Max _Step**. These values with these suffixes allow you to limit the value assumed by a property within a certain range.

The "CreateNewSubscription" class in this project is located in the Panel folder, its UI is automatically generated and you can find it in the left side menu of the application web page. Edit this class as you like to understand how it works: Remember, only the public property and methods have a visual correspondence in the GUI.

The developer focuses on writing the back-end functionality, and the GUI with its iteration tools is automatically generated, complete with validations, automations, user session management, and everything else needed to have a finished product right away.