using SampleAPIClient;
using SampleAPIClient.Models;

const bool WinAuth = false;
const string Domain = "";
const string UserName = "admin";
const string Password = "P@ssw0rd";
const string serviceUrl = "http://<server>:<odataport>/<instance>/api/v2.0/"; // substitute your service details here
const string companyId = "21226525-2a0f-ed11-b845-6045bd8e5eb4"; // Your companyId here
HttpClient httpClient;

var client = new SvcClient(WinAuth, Domain, UserName, Password, serviceUrl, companyId);

SalesOrders salesOrders = await client.SendAsync<SalesOrders>(HttpMethod.Get, "salesOrders", null);

Console.WriteLine("HEADERS ONLY");
foreach (var header in salesOrders.value)
{
    Console.WriteLine($"{header.number}, {header.customerNumber}, {header.customerName}, {header.totalAmountIncludingTax}");
}
Console.WriteLine();

Console.WriteLine("HEADERS WITH LINES");
salesOrders = await client.SendAsync<SalesOrders>(HttpMethod.Get, "salesOrders",null,  "", "salesOrderLines");

foreach (var header in salesOrders.value)
{
    Console.WriteLine($"{header.number}, {header.customerNumber}, {header.customerName}, {header.totalAmountIncludingTax}");

    foreach (var line in header.salesOrderLines)
    {
        Console.WriteLine($"\t\t{line.sequence}, {line.lineObjectNumber}, {line.description}, {line.quantity}");
    }
}

// Create a sales order
var salesOrder = new SalesOrder
{
    externalDocumentNumber = "YourOwnRefNo-001",
    orderDate = "2024-01-26",
    postingDate = "2024-01-26",
    customerNumber = "10000",
    salesOrderLines = new SalesOrderLine[] {
        new SalesOrderLine{
            sequence= 10000,
            lineType= "Item",
            lineObjectNumber= "70061",
            description= "Aluminium",
            unitOfMeasureCode= "TON",
            quantity= 10,
            unitPrice= 11000
        },
        new SalesOrderLine {
            sequence= 20000,
            lineType= "Resource",
            lineObjectNumber= "MARTY",
            description= "Marty McFly",
            quantity= 8,
            unitPrice= 1445
        }
    }
};

Console.WriteLine("CREATE RESULT");
var salesOrderResult = await client.SendAsync<SalesOrder>(HttpMethod.Post, "salesOrders", salesOrder);

salesOrders = await client.SendAsync<SalesOrders>(HttpMethod.Get, "salesOrders", null, $"number eq '{salesOrderResult.number}'", "salesOrderLines");
foreach (var header in salesOrders.value)
{
    Console.WriteLine($"{header.number}, {header.customerNumber}, {header.customerName}, {header.totalAmountIncludingTax}");

    foreach (var line in header.salesOrderLines)
    {
        Console.WriteLine($"\t\t{line.sequence}, {line.lineObjectNumber}, {line.description}, {line.quantity}");
    }
}