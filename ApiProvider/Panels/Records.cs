namespace ApiProvider.Panels
{
    /// <summary>
    /// These records can only be added via API through the ApiConsumer application
    /// </summary>
    static public class Records
    {
        /// <summary>
        /// Records stored in a CSV file
        /// </summary>
        public static List<(string, string)> UserList => API.Records;
    }




}
