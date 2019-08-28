using System;
using System.Collections.Generic;
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
        public void RemoveInvoiceLine(int invoiceLineId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// GetTotal should return the sum of (Cost * Quantity) for each line item
        /// </summary>
        public decimal GetTotal()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// MergeInvoices appends the items from the sourceInvoice to the current invoice
        /// </summary>
        /// <param name="sourceInvoice">Invoice to merge from</param>
        public void MergeInvoices(Invoice sourceInvoice)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a deep clone of the current invoice (all fields and properties)
        /// </summary>
        public Invoice Clone()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Outputs string containing the following (replace [] with actual values):
        /// Invoice Number: [InvoiceNumber], InvoiceDate: [DD/MM/YYYY], LineItemCount: [Number of items in LineItems] 
        /// </summary>
        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
