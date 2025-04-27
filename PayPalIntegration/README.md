## PayPal Integration

 This project (PayPalIntegration) is a small example of a site for online shopping of a service, and management of payments via PayPal. In this tutorial we will see how to redirect the user to the PayPal site by setting the "Redirect" field.

The purpose of the automatic generator of graphical interfaces for **Blazor** is to create graphical interfaces without changing the programming style of the back-end. Developers will be able to use this tool immediately by simply developing the back-end following the best programming practices.
This is a simple example of how the UI is automatically created starting from a class. In practice, the only thing to know is that the public methods and properties will have a graphical correspondence created automatically in the UI. Some tricks allow you to intervene finely on how the graphics will be created.
If you want to have multiple pages/panels, just create multiple classes, each specific to the functionality that will belong to the automatically generated pageThis project is a demonstration of how to implement quickly and very easily, payments via PayPal (we receive online payment with credit cards thanks to the PayPal service)

This project uses the **PayPal.Easy** library (NuGet package) to create a payment link and create payment notifications.
This library simplifies the process of integrating PayPal payments into your .NET applications. It allows you to generate payment links, handle payment notifications, and manage payment events with minimal code.

This project is part of the collection of examples of use from UIsupportBlazor, a powerful and amazing tool that automatically generates the graphical interfaces of Web applications created with Blazor by analyzing the BackEnd assembly. This tutorial is also a demonstration of how easy and immediate it is to create the UI of your website, automatically without the need for razor files.

### Prerequisites

To run the sample project correctly, you must first obtain a PayPal sandbox account, and enter the business email that is assigned to you in the appsettings.json configuration file in the PayPalBusinessEmail field.
You will also need to configure IPN notifications to send a notification to your site, and configure your firewall and router to additionally use the port your web application is running on.
If you are having trouble doing this, ask any AI agent "how to set up PayPal IPN notification URL" (for testing do it with the SandBox account and not with the real account).

### Useful code for managing payments:

As a first step we create a method in our project, which will be executed upon successful payment.

```csharp
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
        }

        internal static Dictionary<string, string> EncryptedKeyIdHexDictionary = [];
    }
}
```
In program.cs we set up the middleware, so that IPN notifications will trigger the OnPaymentCompleted event:

```csharp
	var app = builder.Build();

	// Here we configure the event that should be executed when a payment with has been completed (Events.OnPaymentCompleted)
	app.UseMiddleware<PayPal.PayPalIpnMiddleware>(Events.OnPaymentCompleted);

```
### How to Configure IPN Notifications
1. Log in to your PayPal account (Use the Sandbox account for testing).
2. Navigate to **Account Settings > Instant Payment Notifications (IPN)**.
3. Set the notification URL to point to your endpoint (your website e.g., `https://yourdomain.com`, if you are in debug mode also set the port used e.g., `http://yourdomain.com:5444`).
4. Save the changes.

For more details, refer to the [official PayPal documentation](https://developer.paypal.com/docs/api-basics/notifications/ipn/).

The following steps are mandatory if you are testing the application in debug mode with your PC:

5. Make sure you have a static IP and that the site domain points to your IP
6. Make sure that the firewall is not blocking calls to the port where the web application runs.
7. If necessary, configure the Router to route calls to your PC


### Generate Payment Links with GeneratePayPalLink

We can create a payment link by calling GeneratePayPalLink from the PayPal.Easy library (this method has several parameters, you can consult the documentation for this purpose)
In our example project the link is created in the CreateNewSubscription file (Submit method) under the Panels directory (this would be the class that is automatically transformed into a panel and allows the user to interact)

```csharp
    var info = "Cloud Storage monthly subscription" + StorageSpaceGb + " GB";
    var id = BitConverter.ToUInt64([.. Guid.NewGuid().ToByteArray().Take(8)]).ToString("X"); // generate a random hex id

    // Create payment link and redirect user to link
    var paypalLink = PayPal.Util.GeneratePayPalLink(Settings.PayPalBusinessEmail, info, CostInEuro, "EUR", id, true);                       
    Redirect = new Uri(paypalLink);
```

A very interesting feature of UISupportBlazor, is to redirect users to other pages simply by setting the redirect field of type Uri.
You just need to add the field to the class:  **private Uri? Redirect = null;**
And set it during execution to redirect the user.
In our case we redirected the user to the PayPal link to make the payment.

### Event Handling

You can handle the payment success event by subscribing to the `OnPaymentCompleted` event. This allows you to perform actions like updating order status, sending confirmation emails, etc.
