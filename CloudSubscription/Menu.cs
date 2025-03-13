using CloudSubscription.Panels;
using System.Linq.Expressions;

namespace CloudSubscription
{
    public class Menu
    {
        /// <summary>
        /// Subscription Configurator
        /// </summary>
        public CreateNewSubscription Subscription { get; set; } = new();
    }
}
