using CloudSubscription.Panels;
using System.Diagnostics.Contracts;

namespace CloudSubscription
{
    public class Menu
    {
        /// <summary>
        /// Subscription Configuration panel
        /// </summary>
        public CreateNewSubscription Subscription { get; set; } = new();
    }
}
