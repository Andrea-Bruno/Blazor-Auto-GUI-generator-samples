# API Provider - Dynamic Command-Based API Generation

## Overview
**API Provider** is an example project that dynamically and automatically creates command-based APIs.  
The action to execute is identified in the **URL segment** or in the **`method` parameter** within the JSON request.  
This model enables **dynamic and scalable management** of all available server operations.

## Easy Integration
Implementing APIs for web accessibility is extremely simple:  
Just add **a single line of code** during application initialization in `Program.cs`:

```csharp
var app = builder.Build();

// Enable APIs that allow a client application to remotely execute methods contained in the class
app.UseMiddleware<UISupportBlazor.ApiMiddleware>(typeof(ApiProvider.API));
```

## Middleware Integration
In this example, the middleware is added to support APIs within the `ApiProvider.API` class.  
All methods defined in this class **will be automatically exposed** and accessible to external clients.

## API Request Structure
Clients can interact with the APIs using **POST** requests, where parameters are sent in **JSON format**.  
The parameter names in the JSON request **must match** those defined in the method to be invoked.

### Method Identification
The method name can be specified in two ways:
1. **Final segment of the URL**  
2. **An element named `"method"` inside the JSON request**

## Why This Model?
Unlike traditional REST APIs, which limit actions to standard HTTP methods (`GET`, `POST`, `PUT`, `DELETE`),  
this approach **allows unlimited flexibility**, as any server-side command can be invoked dynamically.

By structuring API requests in this way, the system achieves:
- 🔹 **Universal command execution**
- 🔹 **Better scalability** for complex operations
- 🔹 **Simplified integration with client applications**
- 🔹 **Clean, self-contained API design without unnecessary complexity**

API Provider is a powerful **automation tool for API exposure**, designed to maximize flexibility without sacrificing simplicity.

## Automatic Client Code Generation
The API system offers an **astonishing feature**: it **automatically generates all client-side code** needed to communicate and interact with the APIs, **dramatically accelerating software development**.  
This not only **speeds up** implementation but also **reduces production costs** significantly.

Once the middleware is activated, the client-side code can be instantly generated **by simply accessing the API service entry point URL**.  
If not otherwise specified during middleware initialization, this URL corresponds to the **site's base URL with the final segment `/api`**—for example, in our case:  
➡️ **[`https://localhost:7107/api`](https://localhost:7107/api)**

Visiting this address **automatically provides the C# source code**, enabling **remote interaction** with all methods implemented in the class specified during middleware initialization (in this example: `ApiProvider.API`).

## The Fastest Way to Implement Web-Accessible APIs
This is the **most intuitive and rapid** system ever designed for creating web-accessible APIs, allowing developers to be **instantly operational** without needing to write any additional code! 🚀

## Example Application: APIProvider & APIConsumer
In this example application, we have a class (`ApiProvider.API`) that exposes methods for **adding, deleting, and querying records** in the backend.  
Through the **"Records" panel** in the user interface, we can see the records that have been added.

To insert new records, we need to **run the `ApiConsumer` application**, which leverages the **automatically generated client-side code** to interact with the API.  
Using the **"Test API" panel**, we can perform operations such as **adding, deleting, and querying records** dynamically.

As demonstrated in previous tutorials, even **GUI panels are generated automatically**, making application development **extremely fast and efficient**.

