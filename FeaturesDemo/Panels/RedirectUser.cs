namespace FeaturesDemo.Panels
{
    /// <summary>
    /// This class is used to demonstrate how to redirect the user to another web address
    /// </summary>
    public class RedirectUser
    {
        /// <summary>
        /// By setting this value, the user is redirected to another web address (the setting causes the current user to navigate to the specified Uri)
        /// </summary>
        internal Uri? Redirect;

        /// <summary>
        /// Redirects the user to the Read Query String panel
        /// </summary>
        public void RedirectUserToReadQueryStringPanel()
        {
            var session = UISupportBlazor.Session.Current(); // get the current session (The user's browsing session)
            var baseUrl = session?.Values["BaseUrl"] as string; // get the base URL of the application (We set this value in NavMenu.razor)
            // Redirect the user to the url of the panel ReadQueryString and add the given query string in the url
            Redirect = new Uri(baseUrl + "/nav/" + typeof(ReadQueryString).GUID + "?Data=" + "Hello_World");
        }
    }
}
