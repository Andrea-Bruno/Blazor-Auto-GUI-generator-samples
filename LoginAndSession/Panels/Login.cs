
namespace LoginAndSession.Panels
{
    /// <summary>
    /// Login panel
    /// This example is a working demonstration of a login panel, which exposes a method that receives the user name and password and performs the validation. If the password is correct it sets a flag to true (in our case the property named "loggedIn") and the login is completed.
    /// Some clarifications are needed: Session management is completely automated.It is important to know that each user has their own instance of each panel, here are the ones based on static states that are common to all users.What does this mean? It means that any user accessing the application will be able to interact with their panels without interfering with others, while instead for static panels, being in common they are reserved for things that could be shared and in common between all users: For example, general settings regarding the application and settings can be static, while instead personal and specific settings for a user must not be represented by static classes: The system for each user will create an instance of the object derived from the class and associate it with the user's browsing session. In our example the login class is not static so it will be associated with the session of the current user. Since the class has a property called "loggedIn", it is possible to access it through the browsing session for the current user. In general, from the front-end side, I can get the browsing session of the current user and from it access any panel created for the current user and see the values ​​of fields and properties.
    /// One last consideration to make, the properties of the static classes used for the panels are persistent (their values ​​persist even after the application is restarted), this avoids having to write additional code to manage the saving of data and settings, or to add databases to save various configurations, this allows for further speeding up of the programming.
    /// </summary>
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
}
