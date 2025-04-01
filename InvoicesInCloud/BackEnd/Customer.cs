using InvoicesInCloudBackEnd.Panels;
using System.Text.Json;
using static InvoicesInCloudBackEnd.Util;
namespace InvoicesInCloudBackEnd
{
    /// <summary>
    /// Single customer profile
    /// </summary>
    public class Customer : Company
    {
        /// <summary>
        /// Constructor for deserialization purposes
        /// </summary>
        public Customer()
        {

        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public Customer(CustomerList context)
        {
            Context = context;
        }
        internal CustomerList Context;

        /// <summary>
        /// Save current customer
        /// </summary>
        public void Save()
        {
            string jsonString = JsonSerializer.Serialize((Company)this);
            File.WriteAllText(NameFile(CompanyName), jsonString);
            Remove();
            Context.FullCompanyList.Add(this);
            Context.Customer = new Customer(Context);
        }
        private void Remove()
        {
            var duplicate = Context.FullCompanyList.FindIndex(c => c.CompanyName == CompanyName);
            if (duplicate >= 0)
                Context.FullCompanyList.RemoveAt(duplicate);
        }
        private static string NameFile(string CompanyName) => Path.Combine(AppData(), CompanyName?.ToNameFile() + "." + nameof(Customer));

        /// <summary>
        /// Delete current customer
        /// </summary>
        public void Delete()
        {
            Remove();
            File.Delete(CompanyName);
        }

        static internal void LoadAll(CustomerList context)
        {
            foreach (var file in new DirectoryInfo(AppData()).GetFiles("*." + nameof(Customer)))
            {
                Company company = Load<Company>(file.FullName);
                context.FullCompanyList.Add(company);
            }
        }

        private static T Load<T>(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(jsonString);
        }

    }
}
