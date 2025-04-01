
namespace InvoicesInCloudBackEnd.Panels
{

    /// <summary>
    /// Create a new invoice
    /// </summary>
    public class InvoiceComposer
    {
        /// <summary>
        /// Invoice
        /// </summary>
        public Invoice Invoice { get; set; } = new Invoice();

        /// <summary>
        /// Create a new invoice
        /// </summary>
        public void NewInvoice()
        {
            Invoice = new Invoice();
        }
    }
}
