using System.Diagnostics;

namespace ApiConsumer.Panels
{
    /// <summary>
    /// This panel is used to manage the API code
    /// </summary>
    static public class Utility
    {
        /// <summary>
        /// Show this panel only in debug mode!
        /// </summary>
        static internal bool Hidden => !Debugger.IsAttached;

        /// <summary>
        /// This is the URL of the API to be used for the application
        /// </summary>
        static internal string? ApiEntryPoint;

        /// <summary>
        /// This method is used to update the API code: If the API provider has changed the API specification or added new commands, this will update the client user code!
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        [DebuggerHidden]
        static public void UpdateApiCode()
        {
            var codePath = Path.Combine(new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName, "API.cs");
            if (!File.Exists(codePath))
            {
                throw new Exception($"The API code is not available in the given path: {codePath}");
            }
            try
            {
                using var httpClient = new HttpClient();
                var response = httpClient.GetStringAsync(ApiEntryPoint).Result;
                if (!response.Contains("API", StringComparison.OrdinalIgnoreCase))
                    throw new Exception($"The API code is not available at {ApiEntryPoint}");
                File.WriteAllText(codePath, response);
            }
            catch (Exception)
            {
                throw new Exception($"The server API provider is not available at {ApiEntryPoint}");
            }
  
        }

    }
}
