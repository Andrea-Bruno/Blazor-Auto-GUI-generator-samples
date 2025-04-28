using System.Diagnostics;

namespace FeaturesDemo.Panels
{
    /// <summary>
    /// This class is used to demonstrate how to read the query string in the url
    /// </summary>
    public class ReadQueryString
    {

        /// <summary>
        /// This value, thanks to the AsQueryString attribute, will be set to the query string "Data" of the url.
        /// The field name is case sensitive (pay attention to lowercase and uppercase letters)
        /// </summary>
        [AsQueryString]
        private string? Data;

        /// <summary>
        /// Press this button to read the Data value of the query string in the url (if set);
        /// </summary>
        [DebuggerHidden]
        public string? ReadDataValue()
        {
            if (Data == null)
                throw new Exception("The query string in the url is not set");
            return Data;
        }
    }
}
