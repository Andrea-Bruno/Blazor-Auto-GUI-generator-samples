
namespace ApiProvider.Panels
{
    /// <summary>
    /// This class is used to generate a client code that can be used to access the API.
    /// </summary>
    static public class CodeGenerator
    {
        /// <summary>
        /// This method is used to generate a client code that can be used to access the API.
        /// </summary>
        /// <returns>C# code</returns>
        /// <exception cref="Exception"></exception>
        static public string ShowClientCode()
        {
            var baseUrls = Environment.GetEnvironmentVariable("ASPNETCORE_URLS")?.Split(';');
            if (baseUrls != null)
            {
                // Find the first URL that starts with "https"
                var httpsUrl = baseUrls.FirstOrDefault(url => url.StartsWith("https"));

                if (!string.IsNullOrEmpty(httpsUrl))
                {
                    // Replace "*" with "localhost"
                    httpsUrl = httpsUrl.Replace("*", "localhost") + "/api";
                }
                using var httpClient = new HttpClient();
                var response = httpClient.GetStringAsync(httpsUrl).Result;
                return response;
            }
            else
            {
                throw new Exception("ASPNETCORE_URLS variable not set or empty.");
            }
        }
    }
}
