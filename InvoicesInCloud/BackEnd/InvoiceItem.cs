using System;
using System.Diagnostics;

namespace InvoicesInCloudBackEnd
{
    /// <summary>
    /// New invoice item
    /// </summary>
    public class InvoiceItem
    {
        /// <summary>
        /// For deserialization purposes
        /// </summary>
        public InvoiceItem()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context">NewInvoice object</param>
        public InvoiceItem(Invoice context)
        {
            Context = context;
        }

        internal Invoice Context;

        /// <summary>
        /// Class instance initializer
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Unit price
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Unit of measurement used for this element
        /// </summary>
        public string UnitOfMeasurement { get; set; } = "Pz.";

        /// <summary>
        /// Quantity in this invoice item for the item in description
        /// </summary>
        public double Quantity { get; set; } = 1;

        /// <summary>
        /// Total price for the current item
        /// </summary>
        public double TotalPrice => Math.Round(Price * Quantity, 2);

        /// <summary>
        /// VAT expressed as a percentage value
        /// </summary>
        public double VatRate { get; set; } = 22;

        /// <summary>
        /// VAT in current currency
        /// </summary>
        public double Vat => Math.Round(TotalPrice / 100 * 22, 2);

        /// <summary>
        /// Confirm the insertion of the item in the invoice
        /// </summary>
        [DebuggerHidden]
        public void AddNewItem()
        {
            Validation();
            if (!Context.InvoiceItems.Contains(this))
                Context.InvoiceItems.Add(this);
            Context.ItemComposer = new InvoiceItem(Context);
        }
        [DebuggerHidden]
        private void Validation()
        {
            if (string.IsNullOrEmpty(Description))
                throw new Exception("Description is required");
            if (Price <= 0)
                throw new Exception("Price must be greater than 0");
            if (Quantity <= 0)
                throw new Exception("Quantity must be greater than 0");
            if (VatRate < 0)
                throw new Exception("VAT rate must be greater than or equal to 0");
        }

        /// <summary>
        /// Remove the item from the invoice
        /// </summary>
        public void RemoveItem()
        {
            Context.InvoiceItems.Remove(this);
            Context.ItemComposer = new InvoiceItem(Context);
        }

        /// <summary>
        /// Hides the button associated with RemoveItem() from the GUI if the current invoice cannot be removed
        /// </summary>
        internal bool RemoveItem_Hidden => !Context.InvoiceItems.Contains(this);
    }
}