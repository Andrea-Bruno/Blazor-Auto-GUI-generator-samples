
# UI Support Blazor Manual
## A quick primer on the UISupportBlazor approach

This guide is very short because the goal of this project is to automate the creation of the GUI (user interface) without changing the programming methodology with which developers create their works. The precautions to be taken will therefore be minimal and all in line with the "best practice". What does all this mean? It means that if you are a developer already attentive to the use of the "best practice", then you are already able to use this powerful and miraculous development tool!
The simplicity at the base of this innovative technique is impressive for its simplicity, and as a demonstration of all this we have attached to this document some projects that you can open, run and modify in order to become familiar with this exciting and surprising technology.

## Multi Panels (Basic logic)

The purpose of the automatic generator of graphical interfaces for **Blazor** is to create graphical interfaces without changing the programming style of the back-end. Developers will be able to use this tool immediately by simply developing the back-end following the best programming practices.
This is a simple example of how the UI is automatically created starting from a class. In practice, the only thing to know is that the public methods and properties will have a graphical correspondence created automatically in the UI. Some tricks allow you to intervene finely on how the graphics will be created.
If you want to have multiple pages/panels, just create multiple classes, each specific to the functionality that will belong to the automatically generated page.
Insert the classes that will represent the panels, in the Panels folder of the project, these classes will be examined in real time by the assembly analyzer which will create their user interface to interact with them. For each class a menu item will appear in the left side panel of the web interface.
Static classes are for global use and the values ​​set in them will remain unchanged even after the application is restarted (without the need to save them).
Non-static classes will instead be assigned to users, each user will have his own instance of the non-static class which will be associated with his browsing session.

### In this example we have multiple panels, each related to a class located in the Panels directory, and each generates a menu item in the user interface.
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
| Method   | if it's public   | none             | public  int AddNumbers(int a, int b) {...}|
| Field    | none             | none             | public string? Field2;                    |

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

### ReadOnly attribute

The [ReadOnly(true)] attribute forces properties with the public setter to be read-only as well.

```csharp
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
```

In this example we see two arrays formally identical with the only difference that one has applied the read only attribute. The array without the ReadOnly attribute, having the public setter will be editable by the user in the GUI.
Normally, to make an element uneditable, it would be enough to set the setter as private, but if this is not possible, you can use the RaedOnly attribute.

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

## Invoice in Cloud (Demo project of the automatic GUI generation tool for Blazor)

The InvoiceInCloud project, unlike the other example projects in the repository, is made according to a more correct programming logic and shows off the great and amazing potential of the GUI auto-generation tool:
For this demo we chose to completely separate the software logic from the GUI rendering engine, creating two separate projects: InvoiceInCloudBackEnd and InvoiceInCloud. The first project is simply a library and contains everything needed for the back end to create the application without any reference to graphic elements of user interaction (this is typical of libraries). The front end (InvoiceInCloud) is essentially an empty project, which contains only the assembly analyzer and the Html rendering engine, and the entire graphic interface part is automatically generated "on the fly": Any change to the back-end will be automatically reflected in the front-end without the need to intervene to draw GUI elements. The InvoiceInCloud front end could be used as a rendering engine for other back end projects, as there is nothing specific to the work we are doing, it is simply an automatic GUI generator.
This example is a demonstration of the creation of minimalist software in the back end, which was written in just 25 minutes, of about 1 Kb of code, which is complete and functional in all its parts. The implementation of the technology for the automatic creation of the front end gives an acceleration to the creation of the product that is not comparable to that of any other tool.
In addition to this, by simply changing the rendering engine of the front-end, we can obtain the same application for mobile or desktop devices: You write the code only once, focusing only on the logic of the back-end and you find the finished application with the front-end for web, mobile and desktop applications! All this is fantastic!

[The source code of the back-end and front-end (auto-generated) are published Online](https://github.com/Andrea-Bruno/Blazor-Auto-GUI-generator-samples/tree/master/InvoicesInCloud)

### Main Classes in the Back-end

- **Company**: Represents a company and contains information such as name, address, and VAT number.
- **Customer**: Manages customer data, including name, contacts, and address.
- **Invoice**: Models an invoice, with details such as number, date, customer, and list of items.
- **InvoiceItem**: Represents a single item within an invoice, with description, quantity, and price.
- **InvoiceHtmlGenerator**: Generates the HTML code to display an invoice.
- **Setup**: Contains the initial setup logic for the system.

### Panels

Panels are components that manage specific functionalities of the application:

- **BusinessEntity**: Manages business entities.
- **InvoiceArchive**: Manages the invoice archive.
- **InvoiceComposer**: Allows creating and editing invoices.
- **CustomerList**: Displays and manages the list of customers.

### Front-end Auto-Generation Technology

The magic of this project is due to the technology that allows automating the entire front-end generation. The front-end project analyzes the assemblies of the back-end and automatically generates the user interface (GUI) based on the classes and their attributes. This approach drastically reduces development time and ensures that the GUI is always synchronized with the back-end logic.

For example, the `ClassInfo` class in the front-end project uses reflection to analyze the back-end classes and dynamically create the UI components. This includes generating forms for data entry, tables for displaying lists, and much more.

In summary, "Invoice In Cloud" demonstrates how it is possible to create a complete invoicing and customer management application with minimal front-end development effort, thanks to the power of the GUI auto-generation technology.

## Login and Session

This example is a working demonstration of a login panel, which exposes a method that receives the user name and password and performs the validation. If the password is correct it sets a flag to true (in our case the property named "loggedIn") and the login is completed.
Some clarifications are needed: Session management is completely automated.It is important to know that each user has their own instance of each panel, here are the ones based on static states that are common to all users.What does this mean? It means that any user accessing the application will be able to interact with their panels without interfering with others, while instead for static panels, being in common they are reserved for things that could be shared and in common between all users: For example, general settings regarding the application and settings can be static, while instead personal and specific settings for a user must not be represented by static classes: The system for each user will create an instance of the object derived from the class and associate it with the user's browsing session. In our example the login class is not static so it will be associated with the session of the current user. Since the class has a property called "loggedIn", it is possible to access it through the browsing session for the current user. In general, from the front-end side, I can get the browsing session of the current user and from it access any panel created for the current user and see the values ​​of fields and properties.
One last consideration to make, the properties of the static classes used for the panels are persistent (their values ​​persist even after the application is restarted), this avoids having to write additional code to manage the saving of data and settings, or to add databases to save various configurations, this allows for further speeding up of the programming.

Simple class for creating a login panel:

```csharp
    public class Login
    {
        /// <summary>
        /// Enter your username and password to authenticate (In this example you can use "demo" and "password")
        /// </summary>
        /// <param name="username">Your username</param>
        /// <param name="password">Password used at registration</param>
        public void UserLogin(string username, string password)
        {
            var users = StaticPanel.UserCredentials;            
            var user = users.FirstOrDefault(u => u.Username == username);
            if (user == default)
            {
                throw new Exception("User not found");
            }
            if (user.Password != password)
            {
                throw new Exception("Invalid password");
            }
            IsLogged = true;
            OnLoginSuccess?.Invoke();
        }

        /// <summary>
        /// Hidden UserLogin element from GUI after login
        /// </summary>
        internal bool UserLogin_Hidden => IsLogged;

        /// <summary>
        /// Logged in status of current user
        /// </summary>
        public bool IsLogged;

        /// <summary>
        /// Action to be called when the user logs in successfully
        /// </summary>
        public Action? OnLoginSuccess;
    }
```

As you can see it is very simple, just expose a method that validates the user name and password parameters passed in input. The login panel rendering will show this method in the GUI and allow the user to interact with it.
In our example, if the login was successful we set the IsLogged property to true (we can read this property at any time on the front end via the User Session).

```csharp
@inject IHttpContextAccessor HttpContextAccessor

<div class="top-row ps-3 navbar navbar-dark">
    <div class="container-fluid">
        <a class="navbar-brand" href="">LoginAndSession</a>
    </div>
</div>

<input type="checkbox" title="Navigation menu" class="navbar-toggler" />

<div class="nav-scrollable" onclick="document.querySelector('.navbar-toggler').click()">
    <nav class="nav flex-column">
        <div class="nav-item px-3">
            <NavLink class="nav-link" href="" Match="NavLinkMatch.All">
                <span class="bi bi-house-door-fill-nav-menu" aria-hidden="true"></span> Home
            </NavLink>
        </div>
    </nav>
    @{
        // Get all class info for the panels in the current assembly (If the back-end is external you can indicate the namespace for which you want to generate the panels)
        var panels = UISupportBlazor.Support.GetAllClassInfo(HttpContextAccessor.HttpContext);

        // Get the session object
        var session = UISupportBlazor.Session.Sessions.GetSession(HttpContextAccessor.HttpContext);

        // Get the login panel from the session
        var login = (Panels.Login)session.GetPanelValue(nameof(Panels.Login));
        if (!login.IsLogged)
        {
            // If not logged in, set the login panel to be the only one visible
            login.OnLoginSuccess = () => InvokeAsync(StateHasChanged); // Refresh the menu on login success
            panels = panels.FindAll(panel => panel.Label == nameof(Panels.Login)); // Show only the login panel if not logged in
        }
    }
    @* Component to add for dynamic rendering of AI-generated content *@
    <UISupportBlazor.Menu ClassInfoEnumerable="@panels"></UISupportBlazor.Menu>
</div>
```
As you can see from the code, through the session object for the current user, we get the instance of the login panel and check if he is logged in through the IsLogged property.
If the user is not logged in, we remove all panels except the login one from the items that appear in the GUI side menu.
Finally, remember that it is possible to use different approaches, for example the panels can be hidden by assigning them a boolean field "Hidden" which, when set to true, hides them from the GUI.