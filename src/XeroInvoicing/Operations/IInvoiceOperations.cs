using System.Threading.Tasks;
using XeroInvoicing.Models;

namespace XeroInvoicing.Operations
{
    public interface IInvoiceOperations
    {
        Task AddInvoiceLine(Invoice invoice, InvoiceLine invoiceLine);

        void RemoveInvoiceLine(Invoice invoice, int invoiceLineId);

        decimal GetTotal(Invoice invoice);

        void MergeInvoices(Invoice sourceInvoice, Invoice currentInvoice);

        Task<Invoice> Clone(Invoice invoice);

        string ToString(Invoice invoice);
    }
}
