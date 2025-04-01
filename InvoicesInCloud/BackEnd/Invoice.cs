using InvoicesInCloudBackEnd.Panels;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InvoicesInCloudBackEnd
{
    /// <summary>
    /// Edit and compose the invoice
    /// </summary>
    public class Invoice
    {
        /// <summary>
        /// Class instance initializer
        /// </summary>
        public Invoice()
        {
            ItemComposer = new InvoiceItem(this);
            Date = DateTime.Now.Date;
            InvoiceIssuedTo = new Customer();
        }

        /// <summary>
        /// Find the invoice company recipient
        /// </summary>
        /// <param name="searchText">Free text search.</param>
        public void FindCompany(string searchText)
        {
            var all = searchText == null ? null : CustomerList.CurrentInstance.FullCompanyList.FindAll(Company => Company.Find(searchText));
            if (all != null)
            {
                if (all.Count == 1)
                {
                    InvoiceIssuedTo = all[0];
                    return;
                }
                else if (all.Count > 1)
                    throw new Exception("More companies found with this search key: " + string.Join("; ", all.Select(x => x.CompanyName)));
            }
            throw new Exception("Company not found");
        }

        /// <summary>
        /// Company name o billing recipient
        /// </summary>
        public string? BillingRecipient => InvoiceIssuedTo?.CompanyName;

        /// <summary>
        /// The company to which the invoice is issued
        /// </summary>
        public Company InvoiceIssuedTo { get; set; }

        /// <summary>
        /// Automatically assigned ID
        /// </summary>
        [ReadOnly(true)]
        public int Id { get; set; }

        /// <summary>
        /// Date of the invoice
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Tax data relating to the company issuing the invoice
        /// </summary>
        public string InvoiceIssuedBy => BusinessEntity.Company.CompanyName + " (" + BusinessEntity.Company.TaxId + ")";

        /// <summary>
        /// Add a new item to the invoice
        /// </summary>
        [JsonIgnore]
        public InvoiceItem ItemComposer { get; set; }

        /// <summary>
        /// Select the item to be editing
        /// </summary>
        [JsonIgnore]
        public List<InvoiceItem> SelectInvoiceItem => InvoiceItems;

        internal void OnSelectSelectInvoiceItem(int item)
        {
            ItemComposer = InvoiceItems[item];
        }

        /// <summary>
        /// Items
        /// </summary>
        [ReadOnly(true)] // If there was no readOnly since the properties of the entries were public, they would be editable from the GUI
        public List<InvoiceItem> InvoiceItems { get; set; } = [];

        /// <summary>
        /// The sum of all items in the invoice
        /// </summary>
        public double TotalOnInvoice => InvoiceItems.Sum(item => item.TotalPrice);

        /// <summary>
        /// The total amount of VAT in the invoice
        /// </summary>
        public double TotalVat => InvoiceItems.Sum(item => item.Vat);

        private void AssignId()
        {
            Id = Setup.NextInvoiceId;
            Setup.NextInvoiceId++;
        }

        static private string NameFile(int id) => Path.Combine(Util.AppData(), id.ToString() + "." + nameof(Invoice));

        /// <summary>
        /// Save the invoice
        /// </summary>
        public void Save()
        {
            AssignId();
            if (InvoiceArchive.FullInvoiceList == null)
            {
                InvoiceArchive.LoadAll();
            }
            string json = JsonSerializer.Serialize(this);
            File.WriteAllText(NameFile(Id), json);
#if DEBUG
            var x = Load(NameFile(Id)); // test deserialization
#endif
            lock (typeof(InvoiceArchive))
            {
                InvoiceArchive.FullInvoiceList.Add(this);
            }
        }

        /// <summary>
        /// Generate the invoice document
        /// </summary>
        public void GenerateDocument()
        {
            var appDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var filePath = InvoiceHtmlGenerator.GenerateInvoiceDocument(this);
            Process.Start(new ProcessStartInfo
            {
                FileName = filePath,
                UseShellExecute = true
            });
        }

        static internal Invoice Load(string file)
        {
            var result = JsonSerializer.Deserialize<Invoice>(File.ReadAllText(file));
            foreach (var item in result.InvoiceItems)
            {
                item.Context = result;
            }
            return result;
        }
        /// <summary>
        /// Delete the invoice
        /// </summary>
        public void Delete()
        {
            InvoiceArchive.FullInvoiceList?.Remove(this);
            File.Delete(Path.Combine(Util.AppData(), Id.ToString() + "." + nameof(Invoice)));
        }
    }
}
