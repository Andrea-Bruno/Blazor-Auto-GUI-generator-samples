using System.Text.Json;
using System.Diagnostics;
namespace MultiPanels.Panels
{
    public class NewSubscription
    {
        /// <summary>
        /// This element is only useful to insert as a json parameter, it will be hidden from the GUI thanks to the attribute: [HiddenFromGUI]
        /// You can use [HiddenFromGUI] to hide public properties that should not be displayed in the GUI.
        /// </summary>
        [HiddenFromGUI]
        public string Method => nameof(NewSubscription);

        /// <summary>
        /// Standard cost in Euro (daily cost for Gigabyte)
        /// </summary>
        public double DailyCostForGb { get; set; } = 0.005;


        /// <summary>
        /// Gigabytes of space required
        /// </summary>
        public int StorageSpaceGb { get; set; } = 16;

        private int StorageSpaceGb_Min = 16;

        private int StorageSpaceGb_Max = 4096;

        private int StorageSpaceGb_Step = 16;

        /// <summary>
        /// Subscription duration in days
        /// </summary>
        public int DurationOfSubscriptionInDays { get; set; } = 30;

        private int DurationOfSubscriptionInDays_Min = 30;

        private int DurationOfSubscriptionInDays_Max = 365;

        private int Coefficient => StorageSpaceGb * DurationOfSubscriptionInDays;

        /// <summary>
        /// Coefficient discount
        /// </summary>
        private double CoefficientDiscount => DiscountCoeficent(Coefficient);

        /// <summary>
        /// Coefficient discount
        /// </summary>
        private string CoefficientDiscountString => Math.Round(CoefficientDiscount, 2).ToString();

        /// <summary>
        /// Full cost not discounted
        /// </summary>
        public int FullCostInEuro => (int)(DailyCostForGb * Coefficient);


        /// <summary>
        /// Automatic discount that increases as the subscription features increase
        /// </summary>
        public string DiscountApplied => (int)((1 - CoefficientDiscount) * 100) + "% (discount of €" + Math.Round(FullCostInEuro - CostInEuro, 2) + ")"  ;


        /// <summary>
        /// Total cost in Euro, discounted
        /// </summary>
        public double CostInEuro => Math.Round(FullCostInEuro * CoefficientDiscount, 2);

        static double DiscountCoeficent(double x)
        {
            return 0.2 + 0.8 * Math.Exp(-0.00001 * x);
        }

        /// <summary>
        /// Subscriber's email address
        /// </summary>
        public string? Email { get; set; } 

        /// <summary>
        /// Confirm your subscription to the cloud service, as per your settings
        /// </summary>
        /// <returns></returns>
        [DebuggerHidden]
        public string Submit()
        {
            string json = JsonSerializer.Serialize(this);
            File.WriteAllText(nameof(NewSubscription) + ".json", json);
            return "Operation completed";
        }
    }
}
