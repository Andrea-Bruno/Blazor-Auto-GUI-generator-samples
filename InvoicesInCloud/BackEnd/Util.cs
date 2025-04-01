using System.Reflection;
using System.Text.RegularExpressions;

namespace InvoicesInCloudBackEnd
{
    internal class Util
    {
        /// <summary>
        /// Path to save application data
        /// </summary>
        /// <returns></returns>
        static public string AppData()
        {
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string appDirectory = Path.Combine(appDataPath, Assembly.GetExecutingAssembly().GetName().Name);
            Directory.CreateDirectory(appDirectory);
            return appDirectory;
        }
    }
}

public static class StringExtensions
{
    /// <summary>
    /// Converts the string into a valid file name by removing invalid characters and dots.
    /// </summary>
    /// <param name="input">The input string to be converted.</param>
    /// <returns>A sanitized string suitable for use as a file name.</returns>
    public static string ToNameFile(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        // Define invalid characters for file names
        string invalidChars = new string(System.IO.Path.GetInvalidFileNameChars());

        // Remove invalid characters using Regex
        string sanitized = Regex.Replace(input, $"[{Regex.Escape(invalidChars)}.]", "");

        return sanitized;
    }
}

