## Invoice in Cloud (Demo project of the automatic GUI generation tool for Blazor)

The InvoiceInCloud project, unlike the other example projects in the repository, is made according to a more correct programming logic and shows off the great and amazing potential of the GUI auto-generation tool:
For this demo we chose to completely separate the software logic from the GUI rendering engine, creating two separate projects: InvoiceInCloudBackEnd and InvoiceInCloud. The first project is simply a library and contains everything needed for the back end to create the application without any reference to graphic elements of user interaction (this is typical of libraries). The front end (InvoiceInCloud) is essentially an empty project, which contains only the assembly analyzer and the Html rendering engine, and the entire graphic interface part is automatically generated "on the fly": Any change to the back-end will be automatically reflected in the front-end without the need to intervene to draw GUI elements. The InvoiceInCloud front end could be used as a rendering engine for other back end projects, as there is nothing specific to the work we are doing, it is simply an automatic GUI generator.
This example is a demonstration of the creation of minimalist software in the back end, which was written in just 25 minutes, of about 1 Kb of code, which is complete and functional in all its parts. The implementation of the technology for the automatic creation of the front end gives an acceleration to the creation of the product that is not comparable to that of any other tool.
In addition to this, by simply changing the rendering engine of the front-end, we can obtain the same application for mobile or desktop devices: You write the code only once, focusing only on the logic of the back-end and you find the finished application with the front-end for web, mobile and desktop applications! All this is fantastic!

[The source code of the back-end and front-end (auto-generated) are published Online](https://github.com/Andrea-Bruno/Blazor-Auto-GUI-generator-samples/tree/master/InvoicesInCloud)

### Main Classes in the Back-end

- **Company**: Represents a company and contains information such as name, address, and VAT number.
- **Customer**: Manages customer data, including name, contacts, and address.
- **Invoice**: Models an invoice, with details such as number, date, customer, and list of items.
- **InvoiceItem**: Represents a single item within an invoice, with description, quantity, and price.
- **InvoiceHtmlGenerator**: Generates the HTML code to display an invoice.
- **Setup**: Contains the initial setup logic for the system.

### Panels

Panels are components that manage specific functionalities of the application:

- **BusinessEntity**: Manages business entities.
- **InvoiceArchive**: Manages the invoice archive.
- **InvoiceComposer**: Allows creating and editing invoices.
- **CustomerList**: Displays and manages the list of customers.

### Front-end Auto-Generation Technology

The magic of this project is due to the technology that allows automating the entire front-end generation. The front-end project analyzes the assemblies of the back-end and automatically generates the user interface (GUI) based on the classes and their attributes. This approach drastically reduces development time and ensures that the GUI is always synchronized with the back-end logic.

For example, the `ClassInfo` class in the front-end project uses reflection to analyze the back-end classes and dynamically create the UI components. This includes generating forms for data entry, tables for displaying lists, and much more.

In summary, "Invoice In Cloud" demonstrates how it is possible to create a complete invoicing and customer management application with minimal front-end development effort, thanks to the power of the GUI auto-generation technology.