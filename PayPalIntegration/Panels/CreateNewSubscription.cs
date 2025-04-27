using System.Text;
using System.Text.Json;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System;
namespace PayPalIntegration.Panels
{
    public class CreateNewSubscription
    {
        /// <summary>
        /// Standard cost in Euro (Monthly cost for Gigabyte)
        /// </summary>
        public double MonthlyCostPerGB { get; } = 0.030;

        /// <summary>
        /// Gigabytes of space required
        /// </summary>
        public int StorageSpaceGb { get; set; } = 16;

        private int StorageSpaceGb_Min = 16;

        private int StorageSpaceGb_Max = 4096;

        private int StorageSpaceGb_Step = 16;


        /// <summary>
        /// Total monthly cost in Euro
        /// </summary>
        public double CostInEuro => Math.Round(MonthlyCostPerGB * StorageSpaceGb, 2);


        /// <summary>
        /// Subscriber's email address
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Redirect the user to specific web address;
        /// </summary>
        internal Uri? Redirect = null;

        /// <summary>
        /// Confirm your subscription to the cloud service, as per your settings
        /// </summary>
        /// <returns></returns>
        [DebuggerHidden]
        public string Submit()
        {
            if (Email == null || !Regex.IsMatch(Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) // validate Email address
            {
                throw new ArgumentException("Invalid email address!");
            }
            var session = UISupportBlazor.Session.Current();
            var baseUrl = session.Values["BaseUrl"] as string;
            var returnUrl = baseUrl + "/return/";
            var cancelUrl = baseUrl + "/cancel/";

            var ProductName = "Cloud Storage monthly subscription" + StorageSpaceGb + " GB";
            var id = BitConverter.ToUInt64([.. Guid.NewGuid().ToByteArray().Take(8)]).ToString("X"); // generate a random hex id

            // Create payment link and redirect user to link
            var paypalLink = PayPal.Util.GeneratePayPalLink(Settings.PayPalBusinessEmail, ProductName, CostInEuro, "EUR", id, returnUrl, cancelUrl, true);                       
            Redirect = new Uri(paypalLink);
            return "Redirection to the payment platform";
        }
    }
}
