using System.Collections.Generic;
using XeroInvoicing.Models;

namespace XeroInvoicing.Repo
{
    public static class InvoiceLinesRepo
    {
        public static List<InvoiceLine> InvoiceLines = new List<InvoiceLine>
        {
            new InvoiceLine()
            {
                InvoiceLineId = 1,
                Cost = 6.99m,
                Quantity = 1,
                Description = "Apple"
            },
            new InvoiceLine()
            {
                InvoiceLineId = 2,
                Cost = 5.21m,
                Quantity = 1,
                Description = "Orange"
            },
            new InvoiceLine()
            {
                InvoiceLineId = 3,
                Cost = 5.21m,
                Quantity = 5,
                Description = "Pineapple"
            }
        };
    }
}
