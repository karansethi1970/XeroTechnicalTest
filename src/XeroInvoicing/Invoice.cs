using System;
using System.Collections.Generic;

namespace XeroTechnicalTest.XeroInvoicing
{
    public class Invoice
    {
        public int InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }

        public List<InvoiceLine> LineItems { get; set; }
    }
}