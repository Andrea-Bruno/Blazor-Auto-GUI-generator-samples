using System.ComponentModel;
using System.Text.Json;

namespace InvoicesInCloudBackEnd.Panels
{
    /// <summary>
    /// Archive of all invoices
    /// </summary>
    public class InvoiceArchive
    {
        /// <summary>
        /// List of all invoices emitted
        /// </summary>
        [ReadOnly(true)]
        public List<Invoice> InvoiceList
        {
            get
            {
                lock (typeof(InvoiceArchive))
                {
                    if (FullInvoiceList == null)
                        LoadAll();
                    if (string.IsNullOrEmpty(FilterKeywords))
                        return FullInvoiceList;
                    else
                    {
                        var keywords = FilterKeywords.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        var filteredList = new List<Invoice>();
                        foreach (var invoice in FullInvoiceList)
                        {
                            var json = JsonSerializer.Serialize(invoice);
                            var dictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
                            var invoiceData = string.Join(" ", dictionary.Values);
                            if (keywords.All(keyword => invoiceData.Contains(keyword, StringComparison.InvariantCultureIgnoreCase)))
                                filteredList.Add(invoice);
                        }
                        return filteredList;
                    }
                }
            }
        }

        /// <summary>
        /// Filter the list of invoices
        /// </summary>
        /// <param name="filterKeyword"></param>
        public void Filter(string filterKeyword)
        {
            EditInvoice = null;
            FilterKeywords = filterKeyword;
        }
        private string? FilterKeywords;


        /// <summary>
        /// Select an invoice to edit
        /// </summary>
        public List<Invoice> InvoicesSelector => InvoiceList;

        private void OnSelectInvoicesSelector(int selected)
        {
            EditInvoice = InvoicesSelector[selected];
        }

        /// <summary>
        /// Edit invoice in archive
        /// </summary>
        public Invoice? EditInvoice { get; set; }

        internal bool EditInvoiceHidden => EditInvoice == null;

        static internal List<Invoice>? FullInvoiceList;

        static internal void LoadAll()
        {
            FullInvoiceList = [];
            var files = new DirectoryInfo(Util.AppData()).GetFiles("*." + nameof(Invoice));
            foreach (var file in files)
            {
                try
                {
                    Invoice invoice = Invoice.Load(file.FullName);
                    FullInvoiceList.Add(invoice);
                }
                catch (Exception ex)
                {
                    File.Delete(file.FullName);
                }
            }
        }
    }
}
