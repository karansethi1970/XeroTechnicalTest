using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XeroTechnicalTest.XeroInvoicing;

namespace XeroInvoicing.Operations
{
    public interface IInvoiceOperations
    {
        void AddInvoiceLine(Invoice invoice, InvoiceLine invoiceLine);

        void RemoveInvoiceLine(int invoiceLineId);

        decimal GetTotal();

        void MergeInvoices(Invoice sourceInvoice);

        Invoice Clone();

        string ToString();
    }
}
