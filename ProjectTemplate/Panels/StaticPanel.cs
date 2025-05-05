namespace ProjectTemplate.Panels
{
    /// <summary>
    /// Example of a static panel (it is shared between all users and the value of the fields is persistent, i.e. it remains set even after the application is restarted)
    /// </summary>
    static public class StaticPanel
    {
        /// <summary>
        /// Static a numeric value
        /// </summary>
        static public int NumericPersistentValue { get; set; } = 10;

        /// <summary>
        /// Static a string value
        /// </summary>
        static public string TextPersistent { get; set; } = "Hello World";

        internal static (string Username, string Password)[] UserCredentials =>
            [
                ("demo", "password"),
                ("catlover42", "Meow123!"),
                ("spaceExplorer", "ToTheMoon2025"),
                ("pastaFan99", "SpaghettiForever")
            ];
    }
}
