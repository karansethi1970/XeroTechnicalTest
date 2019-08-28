using System;
using System.Collections.Generic;
using XeroInvoicing.Operations;
using XeroTechnicalTest.XeroInvoicing;

namespace XeroInvoicing.Services
{
    public class InvoiceService: IInvoiceService
    {
        private IInvoiceOperations _invoiceOperations;

        public InvoiceService(IInvoiceOperations invoiceOperations)
        {
            _invoiceOperations = invoiceOperations;
        }

        public void CreateInvoiceWithOneItem()
        {
            var invoice = new Invoice
            {
                LineItems = new List<InvoiceLine>()
            };

            _invoiceOperations.AddInvoiceLine(invoice, new InvoiceLine()
            {
                InvoiceLineId = 1,
                Cost = 6.99m,
                Quantity = 1,
                Description = "Apple"
            });

            Console.WriteLine($"Total: {_invoiceOperations.GetTotal(invoice)}");
        }

        public void CreateInvoiceWithMultipleItemsAndQuantities()
        {
            var invoice = new Invoice
            {
                LineItems = new List<InvoiceLine>()
            };

            _invoiceOperations.AddInvoiceLine(invoice, new InvoiceLine()
            {
                InvoiceLineId = 1,
                Cost = 10.21m,
                Quantity = 4,
                Description = "Banana"
            });

            _invoiceOperations.AddInvoiceLine(invoice, new InvoiceLine()
            {
                InvoiceLineId = 2,
                Cost = 5.21m,
                Quantity = 1,
                Description = "Orange"
            });

            _invoiceOperations.AddInvoiceLine(invoice, new InvoiceLine()
            {
                InvoiceLineId = 3,
                Cost = 5.21m,
                Quantity = 5,
                Description = "Pineapple"
            });

            Console.WriteLine($"Total: {_invoiceOperations.GetTotal(invoice)}");
        }

        public void RemoveItem()
        {
            var invoice = new Invoice
            {
                LineItems = new List<InvoiceLine>()
            };

            _invoiceOperations.AddInvoiceLine(invoice, new InvoiceLine()
            {
                InvoiceLineId = 1,
                Cost = 5.21m,
                Quantity = 1,
                Description = "Orange"
            });

            _invoiceOperations.AddInvoiceLine(invoice, new InvoiceLine()
            {
                InvoiceLineId = 2,
                Cost = 10.99m,
                Quantity = 4,
                Description = "Banana"
            });

            _invoiceOperations.RemoveInvoiceLine(invoice, 1);
            Console.WriteLine($"Total: {_invoiceOperations.GetTotal(invoice)}");
        }

        public void MergeInvoices()
        {
            var invoice1 = new Invoice
            {
                LineItems = new List<InvoiceLine>()
            };

            _invoiceOperations.AddInvoiceLine(invoice1, new InvoiceLine()
            {
                InvoiceLineId = 1,
                Cost = 10.33m,
                Quantity = 4,
                Description = "Banana"
            });

            var invoice2 = new Invoice
            {
                LineItems = new List<InvoiceLine>()
            };

            _invoiceOperations.AddInvoiceLine(invoice2, new InvoiceLine()
            {
                InvoiceLineId = 2,
                Cost = 5.22m,
                Quantity = 1,
                Description = "Orange"
            });

            _invoiceOperations.AddInvoiceLine(invoice2, new InvoiceLine()
            {
                InvoiceLineId = 3,
                Cost = 6.27m,
                Quantity = 3,
                Description = "Blueberries"
            });

            _invoiceOperations.MergeInvoices(invoice1, invoice2);
            Console.WriteLine($"Total: {_invoiceOperations.GetTotal(invoice1)}");
        }

        public void CloneInvoice()
        {
            var invoice = new Invoice
            {
                LineItems = new List<InvoiceLine>()
            };

            _invoiceOperations.AddInvoiceLine(invoice, new InvoiceLine()
            {
                InvoiceLineId = 1,
                Cost = 6.99m,
                Quantity = 1,
                Description = "Apple"
            });

            _invoiceOperations.AddInvoiceLine(invoice, new InvoiceLine()
            {
                InvoiceLineId = 2,
                Cost = 6.27m,
                Quantity = 3,
                Description = "Blueberries"
            });

            var clonedInvoice = _invoiceOperations.Clone(invoice);
            Console.WriteLine($"Total: {_invoiceOperations.GetTotal(clonedInvoice)}");
        }

        public void InvoiceToString()
        {
            var invoice = new Invoice()
            {
                InvoiceDate = DateTime.Now,
                InvoiceNumber = 1000,
                LineItems = new List<InvoiceLine>()
                {
                    new InvoiceLine()
                    {
                        InvoiceLineId = 1,
                        Cost = 6.99m,
                        Quantity = 1,
                        Description = "Apple"
                    }
                }
            };

            Console.WriteLine(_invoiceOperations.ToString(invoice));
        }
    }
}
