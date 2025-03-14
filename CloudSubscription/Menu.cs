using CloudSubscription.Panels;

namespace CloudSubscription
{
    public class Menu
    {
        /// <summary>
        /// Subscription Configurator panel
        /// </summary>
        public CreateNewSubscription Subscription { get; set; } = new();
    }
}
