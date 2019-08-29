using System.Collections.Generic;
using System.Threading.Tasks;
using XeroInvoicing.Models;

namespace XeroInvoicing.Operations
{
    public interface IInvoiceOperations
    {
        Task AddInvoiceLines(Invoice invoice, List<InvoiceLine> invoiceLine);

        void RemoveInvoiceLine(Invoice invoice, int invoiceLineId);

        decimal GetTotal(Invoice invoice);

        void MergeInvoices(Invoice sourceInvoice, Invoice currentInvoice);

        Task<Invoice> Clone(Invoice invoice);

        string ToString(Invoice invoice);
    }
}
