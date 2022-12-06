using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAPIClient.Models
{

    public class SalesOrders
    {
        public string odatacontext { get; set; }
        public SalesOrder[] value { get; set; }
    }

    public class SalesOrder
    {
        public string? odataetag { get; set; }
        public string? id { get; set; }
        public string? number { get; set; }
        public string? externalDocumentNumber { get; set; }
        public string? orderDate { get; set; }
        public string? postingDate { get; set; }
        public string? customerId { get; set; }
        public string? customerNumber { get; set; }
        public string? customerName { get; set; }
        public string? billToName { get; set; }
        public string? billToCustomerId { get; set; }
        public string? billToCustomerNumber { get; set; }
        public string? shipToName { get; set; }
        public string? shipToContact { get; set; }
        public string? sellToAddressLine1 { get; set; }
        public string? sellToAddressLine2 { get; set; }
        public string? sellToCity { get; set; }
        public string? sellToCountry { get; set; }
        public string? sellToState { get; set; }
        public string? sellToPostCode { get; set; }
        public string? billToAddressLine1 { get; set; }
        public string? billToAddressLine2 { get; set; }
        public string? billToCity { get; set; }
        public string? billToCountry { get; set; }
        public string? billToState { get; set; }
        public string? billToPostCode { get; set; }
        public string? shipToAddressLine1 { get; set; }
        public string? shipToAddressLine2 { get; set; }
        public string? shipToCity { get; set; }
        public string? shipToCountry { get; set; }
        public string? shipToState { get; set; }
        public string? shipToPostCode { get; set; }
        public string? shortcutDimension1Code { get; set; }
        public string? shortcutDimension2Code { get; set; }
        public string? currencyId { get; set; }
        public string? currencyCode { get; set; }
        public bool? pricesIncludeTax { get; set; }
        public string? paymentTermsId { get; set; }
        public string? shipmentMethodId { get; set; }
        public string? salesperson { get; set; }
        public bool? partialShipping { get; set; }
        public string? requestedDeliveryDate { get; set; }
        public float? discountAmount { get; set; }
        public bool? discountAppliedBeforeTax { get; set; }
        public float? totalAmountExcludingTax { get; set; }
        public float? totalTaxAmount { get; set; }
        public float? totalAmountIncludingTax { get; set; }
        public bool? fullyShipped { get; set; }
        public string? status { get; set; }
        public DateTime? lastModifiedDateTime { get; set; }
        public string? phoneNumber { get; set; }
        public string? email { get; set; }
        public SalesOrderLine[] salesOrderLines { get; set; }
    }

    public class SalesOrderLine
    {
        public string? odataetag { get; set; }
        public string? id { get; set; }
        public string? documentId { get; set; }
        public int? sequence { get; set; }
        public string? itemId { get; set; }
        public string? accountId { get; set; }
        public string? lineType { get; set; }
        public string? lineObjectNumber { get; set; }
        public string? description { get; set; }
        public string? unitOfMeasureId { get; set; }
        public string? unitOfMeasureCode { get; set; }
        public int? quantity { get; set; }
        public float? unitPrice { get; set; }
        public float? discountAmount { get; set; }
        public int? discountPercent { get; set; }
        public bool? discountAppliedBeforeTax { get; set; }
        public float? amountExcludingTax { get; set; }
        public string? taxCode { get; set; }
        public int? taxPercent { get; set; }
        public float? totalTaxAmount { get; set; }
        public float? amountIncludingTax { get; set; }
        public float? invoiceDiscountAllocation { get; set; }
        public float? netAmount { get; set; }
        public float? netTaxAmount { get; set; }
        public float?    netAmountIncludingTax { get; set; }
        public string? shipmentDate { get; set; }
        public int? shippedQuantity { get; set; }
        public int? invoicedQuantity { get; set; }
        public int? invoiceQuantity { get; set; }
        public int? shipQuantity { get; set; }
        public string? itemVariantId { get; set; }
        public string? locationId { get; set; }
    }

}
