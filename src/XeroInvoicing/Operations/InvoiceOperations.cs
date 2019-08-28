﻿using System.Linq;
using System.Threading.Tasks;
using XeroInvoicing.Utilities;
using XeroTechnicalTest.XeroInvoicing;

namespace XeroInvoicing.Operations
{
    public class InvoiceOperations: IInvoiceOperations
    {
        /// <summary>
        /// Add new invoice using Invoice Line details
        /// </summary>
        /// <param name="invoice">Invoice to modify</param>
        /// <param name="invoiceLine">Invoice Line to add</param>
        public async Task AddInvoiceLine(Invoice invoice, InvoiceLine invoiceLine)
        {
            invoice.LineItems.Add(invoiceLine);
            await Task.Delay(100);
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
        /// <param name="invoice">Invoice to get total tally for</param>
        public decimal GetTotal(Invoice invoice)
        {
            return invoice.LineItems.Sum(x => x.Cost * x.Quantity);
        }

        /// <summary>
        /// MergeInvoices appends the items from the sourceInvoice to the current invoice
        /// </summary>
        /// <param name="sourceInvoice">Invoice to merge from</param>
        /// <param name="currentInvoice">Invoice to merge to</param>
        public void MergeInvoices(Invoice sourceInvoice, Invoice currentInvoice)
        {
            currentInvoice.LineItems.AddRange(sourceInvoice.LineItems);
        }

        /// <summary>
        /// Creates a deep clone of the current invoice (all fields and properties)
        /// </summary>
        /// <param name="invoice">Invoice to clone</param>
        public async Task<Invoice> Clone(Invoice invoice)
        {
            var clonedInvoice = await Task.FromResult<Invoice>(CloneUtility.DeepClone(invoice));
            return clonedInvoice != null ?(Invoice)clonedInvoice: null;
        }

        /// <summary>
        /// Outputs string containing the following (replace [] with actual values):
        /// Invoice Number: [InvoiceNumber], InvoiceDate: [DD/MM/YYYY], LineItemCount: [Number of items in LineItems] 
        /// </summary>
        /// <param name="invoice">Invoice to get string from</param>
        public string ToString(Invoice invoice)
        {
            return $"Invoice Number: {invoice.InvoiceNumber}, " +
                $"InvoiceDate: {invoice.InvoiceDate.ToString("dd/MM/yyyy")}, " +
                $"LineItemCount: {invoice.LineItems.Count}";
        }
    }
}
