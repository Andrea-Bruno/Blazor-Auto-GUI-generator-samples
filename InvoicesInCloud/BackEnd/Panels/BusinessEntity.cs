
namespace InvoicesInCloudBackEnd.Panels
{
    /// <summary>
    /// The data of the company that issues the invoices
    /// </summary>
    static public class BusinessEntity
    {
        /// <summary>
        /// Business Entity Company (The company that issues the invoices)
        /// </summary>
        static public Company Company { get; set; } = new Company();
    }
}
