using System.Reflection;
using System.Text;

namespace InvoicesInCloudBackEnd
{
    /// <summary>
    /// Generates invoice documents in HTML format from embedded templates
    /// </summary>
    public static class InvoiceHtmlGenerator
    {
        /// <summary>
        /// Generates an HTML invoice document
        /// </summary>
        /// <param name="invoice">Invoice data</param>
        /// <returns>Path to the generated HTML file</returns>
        public static string GenerateInvoiceDocument(Invoice invoice)
        {
            if (invoice == null)
                throw new ArgumentNullException(nameof(invoice));

            string template = LoadEmbeddedTemplate();
            string htmlContent = ReplacePlaceholders(template, invoice);

            string outputPath = GetOutputPath(invoice);
            File.WriteAllText(outputPath, htmlContent);

            return outputPath;
        }

        private static string LoadEmbeddedTemplate()
        {
            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = assembly.GetManifestResourceNames().FirstOrDefault(name => name.EndsWith("InvoiceTemplate.html"));

            if (string.IsNullOrEmpty(resourceName))
                throw new FileNotFoundException("Embedded HTML template not found");

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        private static string ReplacePlaceholders(string template, Invoice invoice)
        {
            var replacements = new Dictionary<string, string>
            {
                {"{{Invoice.Id}}", invoice.Id.ToString()},
                {"{{Invoice.Date}}", invoice.Date.ToString("dd/MM/yyyy")},
                {"{{Invoice.InvoiceIssuedBy}}", invoice.InvoiceIssuedBy},
                {"{{Invoice.InvoiceIssuedTo.CompanyName}}", invoice.InvoiceIssuedTo.CompanyName},
                {"{{Invoice.InvoiceIssuedTo.Address}}", invoice.InvoiceIssuedTo.Address},
                {"{{Invoice.InvoiceIssuedTo.TaxId}}", invoice.InvoiceIssuedTo.TaxId},
                {"{{Invoice.TotalOnInvoice}}", invoice.TotalOnInvoice.ToString("0.00")},
                {"{{Invoice.TotalVat}}", invoice.TotalVat.ToString("0.00")},
                {"{{Invoice.TotalWithVat}}", (invoice.TotalOnInvoice + invoice.TotalVat).ToString("0.00")},
                {"{{Items}}", GenerateItemsHtml(invoice.InvoiceItems)}
            };

            StringBuilder builder = new StringBuilder(template);
            foreach (var replacement in replacements)
            {
                builder.Replace(replacement.Key, replacement.Value);
            }

            return builder.ToString();
        }

        private static string GenerateItemsHtml(List<InvoiceItem> items)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var item in items)
            {
                builder.AppendLine("<tr>");
                builder.AppendLine($"<td>{item.Description}</td>");
                builder.AppendLine($"<td>{item.Quantity} {item.UnitOfMeasurement}</td>");
                builder.AppendLine($"<td>{item.Price.ToString("0.00")}</td>");
                builder.AppendLine($"<td>{item.TotalPrice.ToString("0.00")}</td>");
                builder.AppendLine($"<td>{item.VatRate}%</td>");
                builder.AppendLine("</tr>");
            }

            return builder.ToString();
        }

        private static string GetOutputPath(Invoice invoice)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return Path.Combine(documentsPath, $"{invoice.Id}.html");
        }
    }
}