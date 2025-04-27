using System.Diagnostics;

namespace PayPalIntegration
{
    static internal class Events
    {
        /// <summary>
        /// This method is called when a payment is completed.
        /// </summary>
        /// <param name="instantPaymentNotificationData"></param>
        static internal void OnPaymentCompleted(Dictionary<string, string> instantPaymentNotificationData)
        {
            // If the payment is completed, extract transaction details
            var transactionId = instantPaymentNotificationData["txn_id"]; // Transaction ID from PayPal
            var id = instantPaymentNotificationData["custom"]; // Custom field set in the payment link
            var amount = instantPaymentNotificationData["mc_gross"]; // Gross amount of the transaction
            Debug.WriteLine($"Payment completed. Transaction ID: {transactionId}, Custom ID: {id}, Amount: {amount}");
            Debugger.Break(); //You have received a payment notification! You have then successfully configured the IPN notification URL from your PayPal SandBox account

            // enter the code here to execute for successfully completed purchases!

        }
    }
}
