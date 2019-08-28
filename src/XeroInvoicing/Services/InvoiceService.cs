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
            var invoice = new Invoice();

            _invoiceOperations.AddInvoiceLine(invoice, new InvoiceLine()
            {
                InvoiceLineId = 1,
                Cost = 6.99m,
                Quantity = 1,
                Description = "Apple"
            });

            Console.WriteLine(_invoiceOperations.GetTotal());
        }

        public void CreateInvoiceWithMultipleItemsAndQuantities()
        {
            var invoice = new Invoice();

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

            Console.WriteLine(_invoiceOperations.GetTotal());
        }

        public void RemoveItem()
        {
            var invoice = new Invoice();

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

            _invoiceOperations.RemoveInvoiceLine(1);
            Console.WriteLine(_invoiceOperations.GetTotal());
        }

        public void MergeInvoices()
        {
            var invoice1 = new Invoice();

            _invoiceOperations.AddInvoiceLine(invoice1, new InvoiceLine()
            {
                InvoiceLineId = 1,
                Cost = 10.33m,
                Quantity = 4,
                Description = "Banana"
            });

            //var invoice2 = new Invoice();

            //invoice2.AddInvoiceLine(new InvoiceLine()
            //{
            //    InvoiceLineId = 2,
            //    Cost = 5.22m,
            //    Quantity = 1,
            //    Description = "Orange"
            //});

            //invoice2.AddInvoiceLine(new InvoiceLine()
            //{
            //    InvoiceLineId = 3,
            //    Cost = 6.27m,
            //    Quantity = 3,
            //    Description = "Blueberries"
            //});

            //invoice1.MergeInvoices(invoice2);
            Console.WriteLine(_invoiceOperations.GetTotal());
        }

        public void CloneInvoice()
        {
            var invoice = new Invoice();

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

            var clonedInvoice = _invoiceOperations.Clone();
            Console.WriteLine(_invoiceOperations.GetTotal());
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

            Console.WriteLine(invoice.ToString());
        }
    }
}
