# Demo project of the automatic GUI generation tool for Blazor

The purpose of the automatic generator of graphical interfaces for **Blazor** is to create graphical interfaces without changing the programming style of the back-end. Developers will be able to use this tool immediately by simply developing the back-end following the best programming practices.
This is a simple example of how the UI is automatically created starting from a class. In practice, the only thing to know is that the public methods and properties will have a graphical correspondence created automatically in the UI. Some tricks allow you to intervene finely on how the graphics will be created.
If you want to have multiple pages/panels, just create multiple classes, each specific to the functionality that will belong to the automatically generated page.

## In this project a page/panel is automatically created that allows the user to interact with the following class:

```csharp
using System.Text;
using System.Text.Json;
using System.Diagnostics;
namespace CloudSubscription.Panels
{
    public class CreateNewSubscription
    {
        /// <summary>
        /// This element is only useful to insert as a json parameter, it will be hidden from the GUI thanks to the attribute: [HiddenFromGUI]
        /// You can use [HiddenFromGUI] to hide public properties that should not be displayed in the GUI.
        /// </summary>
        [HiddenFromGUI]
        public string Method => nameof(CreateNewSubscription);

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
            string jsonString = JsonSerializer.Serialize(this);
            using var client = new HttpClient();
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = client.PostAsync(Settings.ApiEndpoint, content); // Send POST request
            return response.Result.ToString();
        }
    }
}
```

This class (CreateNewSubscription) represents the back-end useful for managing a user who wants to purchase a cloud storage space. The operation is concluded by sending an instruction to a hypothetical server via API.

As you can see some properties have values ​​with the same name and suffixes **_Min _Max _Step**. These values ​​with these suffixes allow you to limit the value assumed by a property within a certain range.

The "CreateNewSubscription" class in this project is located in the panneli folder, its UI is automatically generated and you can find it in the left side menu of the application web page. Edit this class as you like to understand how it works: Remember, only the public property and methods have a visual correspondence in the GUI.

The developer focuses on writing the back-end functionality, and the GUI with its iteration tools is automatically generated, complete with validations, automations, user session management, and everything else needed to have a finished product right away.