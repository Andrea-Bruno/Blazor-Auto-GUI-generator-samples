

namespace InvoicesInCloudBackEnd
{
    /// <summary>
    /// Global setting parameters for the application
    /// </summary>
    static class Setup
    {
        private static string LastIdFile = Path.Combine(Util.AppData(), "LastId");

        /// <summary>
        /// Invoices have a progressive ID, the next one will have the value set here
        /// </summary>
        static public int NextInvoiceId
        {
            get
            {
                return !File.Exists(LastIdFile) ? 1 : int.TryParse(File.ReadAllText(LastIdFile), out var id) ? id + 1 : 1;
            }
            set { File.WriteAllText(LastIdFile, (value + -1).ToString()); }
        }
    }
}
