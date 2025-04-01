
using System.Text.Json;

namespace InvoicesInCloudBackEnd
{
    /// <summary>
    /// The data of the company that issues the invoices
    /// </summary>
    public class Company
    {
        /// <summary>
        /// The unique identifier of the company
        /// </summary>
        public string? CompanyId { get; set; }

        /// <summary>
        /// The name of the company
        /// </summary>
        public string? CompanyName { get; set; }

        /// <summary>
        /// The address of the company
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// The tax identification number of the company
        /// </summary>
        public string? TaxId { get; set; }

        /// <summary>
        /// The email address of the company
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// The phone number of the company
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// The website of the company
        /// </summary>
        public string? Website { get; set; }

        private string CompanyData()
        {
            var json = JsonSerializer.Serialize(this);
            var dictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
            return string.Join(" ", dictionary.Values);
        }

        internal bool Find(string filter)
        {
            if (string.IsNullOrEmpty(filter))
                return true;

            var keywords = filter.Split([' '], StringSplitOptions.RemoveEmptyEntries);
            var companyData = CompanyData();
            return keywords.All(keyword => companyData.Contains(keyword, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
