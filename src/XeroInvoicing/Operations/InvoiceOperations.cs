using System.Linq;
using XeroInvoicing.Utilities;
using XeroTechnicalTest.XeroInvoicing;

namespace XeroInvoicing.Operations
{
    public class InvoiceOperations: IInvoiceOperations
    {
        /// <summary>
        /// Add new invoice using Invoice Line details
        /// </summary>
        /// <param name="invoiceLine"></param>
        public void AddInvoiceLine(Invoice invoice, InvoiceLine invoiceLine)
        {
            invoice.LineItems.Add(invoiceLine);
        }

        /// <summary>
        /// Remove invoice using Invoice Line ID
        /// </summary>
        /// <param name="invoiceLineId"></param>
        public void RemoveInvoiceLine(Invoice invoice, int invoiceLineId)
        {
            var item = invoice.LineItems.FirstOrDefault(x => x.InvoiceLineId == invoiceLineId);
            invoice.LineItems.Remove(item);
        }

        /// <summary>
        /// GetTotal should return the sum of (Cost * Quantity) for each line item
        /// </summary>
        public decimal GetTotal(Invoice invoice)
        {
            return invoice.LineItems.Sum(x => x.Cost * x.Quantity);
        }

        /// <summary>
        /// MergeInvoices appends the items from the sourceInvoice to the current invoice
        /// </summary>
        /// <param name="sourceInvoice">Invoice to merge from</param>
        public void MergeInvoices(Invoice sourceInvoice, Invoice currentInvoice)
        {
            currentInvoice.LineItems.AddRange(sourceInvoice.LineItems);
        }

        /// <summary>
        /// Creates a deep clone of the current invoice (all fields and properties)
        /// </summary>
        public Invoice Clone(Invoice invoice)
        {
            var clonedInvoice = CloneUtility.CloneObject(invoice);
            return clonedInvoice != null ?(Invoice)clonedInvoice: null;
        }

        /// <summary>
        /// Outputs string containing the following (replace [] with actual values):
        /// Invoice Number: [InvoiceNumber], InvoiceDate: [DD/MM/YYYY], LineItemCount: [Number of items in LineItems] 
        /// </summary>
        public string ToString(Invoice invoice)
        {
            return $"Invoice Number: {invoice.InvoiceNumber}, " +
                $"InvoiceDate: {invoice.InvoiceDate.ToString("DD/MM/YYYY")}, " +
                $"LineItemCount: {invoice.LineItems.Count}";
        }
    }
}
