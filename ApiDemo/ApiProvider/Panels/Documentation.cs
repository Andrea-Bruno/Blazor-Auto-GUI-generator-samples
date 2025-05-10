namespace ApiProvider.Panels
{
    /// <summary>
    /// Documentation panel
    /// </summary>
    static public class Documentation
    {
        /// <summary>
        /// Project documentation
        /// </summary>
        static public string Readme => File.ReadAllText("README.md");
    }
}
