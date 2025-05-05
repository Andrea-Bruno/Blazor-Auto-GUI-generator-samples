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
        if (login?.IsLogged == false)
        {
            // If not logged in, set the login panel to be the only one visible
            login.OnLoginSuccess = () => InvokeAsync(StateHasChanged); // Refresh the menu on login success
            panels = panels?.FindAll(panel => panel.Id.Equals(typeof(Panels.Login).GUID)); // Show only the login panel if not logged in
        }
    }
    @* Component to add for dynamic rendering of AI-generated content *@
    <UISupportBlazor.Menu ClassInfoEnumerable="@panels"></UISupportBlazor.Menu>
</div>
```
As you can see from the code, through the session object for the current user, we get the instance of the login panel and check if he is logged in through the IsLogged property.
If the user is not logged in, we remove all panels except the login one from the items that appear in the GUI side menu.
Finally, remember that it is possible to use different approaches, for example the panels can be hidden by assigning them a boolean field "Hidden" which, when set to true, hides them from the GUI.