using System.ComponentModel;
using System.Text.Json;

namespace InvoicesInCloudBackEnd.Panels
{
    /// <summary>
    /// Form for entering companies for invoicing (customer list management)
    /// </summary>
    public class CustomerList
    {
        /// <summary>
        /// constructor
        /// </summary>
        public CustomerList()
        {
            if (FullCompanyList.Count == 0)
                Customer.LoadAll(this);
            Customer = new Customer(this);
            CurrentInstance = this;
        }

        internal static CustomerList? CurrentInstance; 

        /// <summary>
        /// Search for a company in the list (pres TAB to execute)
        /// </summary>
        public string CompanySearch { get; set; }

        /// <summary>
        /// Select a company from the list to edit
        /// </summary>
        [ReadOnly(true)] // If there was no readOnly since the properties of the entries were public, they would be editable from the GUI
        internal List<Company> FullCompanyList { get; private set; } = [];

        /// <summary>
        /// Select a company to edit
        /// </summary>
        public string[] CompanyList
        {
            get
            {
                var companyList = new List<Company>();
                foreach (var company in FullCompanyList)
                {
                    if (company.Find(CompanySearch))
                        companyList.Add(company);
                }
                if (companyList.Count == 1)
                    EditCompany(companyList[0]);
                return companyList.Select(company => company.CompanyName).ToArray();
            }
        }

        internal void OnSelectCompanyList(int item)
        {
            var companyName = CompanyList[item];
            var company = FullCompanyList.FirstOrDefault(company => company.CompanyName == companyName);
            EditCompany(company);
        }


        private void EditCompany(Company company)
        {
            var jsonString = JsonSerializer.Serialize(company);
            Customer = JsonSerializer.Deserialize<Customer>(jsonString);
            Customer.Context = this;
        }


        /// <summary>
        /// Edit and manage clients
        /// </summary>
        public Customer Customer { get; set; }

    }
}
