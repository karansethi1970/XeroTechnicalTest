using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XeroInvoicing.Operations;
using XeroInvoicing.Models;
using System.IO;
using XeroInvoicing.Repo;
using System.Linq;

namespace XeroInvoicing.Services
{
    public class InvoiceService : IInvoiceService
    {
        private IInvoiceOperations _invoiceOperations;

        public InvoiceService(IInvoiceOperations invoiceOperations)
        {
            _invoiceOperations = invoiceOperations;
        }

        public async Task CreateInvoiceWithOneItem()
        {
            var invoice = new Invoice
            {
                LineItems = new List<InvoiceLine>()
            };

            await _invoiceOperations.AddInvoiceLines(invoice,
                new List<InvoiceLine>
                {
                    InvoiceLinesRepo.InvoiceLines.First()
                });

            Console.WriteLine($"Total: {_invoiceOperations.GetTotal(invoice)}");
        }

        public async Task CreateInvoiceWithMultipleItemsAndQuantities()
        {
            var invoice = new Invoice
            {
                LineItems = new List<InvoiceLine>()
            };

            await _invoiceOperations.AddInvoiceLines(invoice, InvoiceLinesRepo.InvoiceLines);
            Console.WriteLine($"Total: {_invoiceOperations.GetTotal(invoice)}");
        }

        public async Task RemoveItem()
        {
            var invoice = new Invoice
            {
                LineItems = new List<InvoiceLine>()
            };

            await _invoiceOperations.AddInvoiceLines(invoice, InvoiceLinesRepo.InvoiceLines);
            _invoiceOperations.RemoveInvoiceLine(invoice, 1);
            Console.WriteLine($"Total: {_invoiceOperations.GetTotal(invoice)}");
        }

        public void MergeInvoices()
        {
            var invoice1 = new Invoice
            {
                LineItems = new List<InvoiceLine>()
            };

            _invoiceOperations.AddInvoiceLines(invoice1, new List<InvoiceLine>
                 {
                     InvoiceLinesRepo.InvoiceLines.First()
                 });

            var invoice2 = new Invoice
            {
                LineItems = new List<InvoiceLine>()
            };

            _invoiceOperations.AddInvoiceLines(invoice2,
                InvoiceLinesRepo.InvoiceLines
                .Where(x => x.InvoiceLineId == 2 || x.InvoiceLineId == 3)
                .ToList());

            _invoiceOperations.MergeInvoices(invoice1, invoice2);
            Console.WriteLine($"Total: {_invoiceOperations.GetTotal(invoice1)}");
        }

        public async Task CloneInvoice()
        {
            try
            {
                var invoice = new Invoice
                {
                    LineItems = new List<InvoiceLine>()
                };

                await _invoiceOperations.AddInvoiceLines(invoice, InvoiceLinesRepo.InvoiceLines);

                var clonedInvoice = await _invoiceOperations.Clone(invoice);
                Console.WriteLine($"Total: {_invoiceOperations.GetTotal(clonedInvoice)}");
            }
            catch (EndOfStreamException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Invoice cloning failed. Details: {ex.Message}");
            }
        }

        public void InvoiceToString()
        {
            var invoice = new Invoice()
            {
                InvoiceDate = DateTime.Now,
                InvoiceNumber = 1000,
                LineItems = new List<InvoiceLine>()
                {
                    InvoiceLinesRepo.InvoiceLines.First()
                }
            };

            Console.WriteLine(_invoiceOperations.ToString(invoice));
        }
    }
}
