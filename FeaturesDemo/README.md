# Demo project of the automatic GUI generation tool for Blazor

The purpose of the automatic generator of graphical interfaces for **Blazor** is to create graphical interfaces without changing the programming style of the back-end. Developers will be able to use this tool immediately by simply developing the back-end following the best programming practices.
This is a simple example of how the UI is automatically created starting from a class. In practice, the only thing to know is that the public methods and properties will have a graphical correspondence created automatically in the UI. Some tricks allow you to intervene finely on how the graphics will be created.
If you want to have multiple pages/panels, just create multiple classes, each specific to the functionality that will belong to the automatically generated page.
Insert the classes that will represent the panels, in the Panels folder of the project, these classes will be examined in real time by the assembly analyzer which will create their user interface to interact with them. For each class a menu item will appear in the left side panel of the web interface.
Static classes are for global use and the values ​​set in them will remain unchanged even after the application is restarted (without the need to save them).
Non-static classes will instead be assigned to users, each user will have his own instance of the non-static class which will be associated with his browsing session.

## Multiple panelsIn this example we have multiple panels, each related to a class located in the Panels directory, and each generates a menu item in the user interface.
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


