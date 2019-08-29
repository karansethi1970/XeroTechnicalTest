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
            try
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
            catch (NullReferenceException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Invoice creation failed. Details: {ex.Message}");
            }
        }

        public async Task CreateInvoiceWithMultipleItemsAndQuantities()
        {
            try
            {
                var invoice = new Invoice
                {
                    LineItems = new List<InvoiceLine>()
                };

                await _invoiceOperations.AddInvoiceLines(invoice, InvoiceLinesRepo.InvoiceLines);
                Console.WriteLine($"Total: {_invoiceOperations.GetTotal(invoice)}");
            }
            catch (NullReferenceException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Invoice creation failed. Details: {ex.Message}");
            }
        }

        public async Task RemoveItem()
        {
            try
            {
                var invoice = new Invoice
                {
                    LineItems = new List<InvoiceLine>()
                };

                await _invoiceOperations.AddInvoiceLines(invoice, InvoiceLinesRepo.InvoiceLines);
                _invoiceOperations.RemoveInvoiceLine(invoice, 1);
                Console.WriteLine($"Total: {_invoiceOperations.GetTotal(invoice)}");
            }
            catch (NullReferenceException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Invoice line removal failed. Details: {ex.Message}");
            }
        }

        public async Task MergeInvoices()
        {
            try
            {
                var invoice1 = new Invoice
                {
                    LineItems = new List<InvoiceLine>()
                };

                await _invoiceOperations.AddInvoiceLines(invoice1, new List<InvoiceLine>
                 {
                     InvoiceLinesRepo.InvoiceLines.First()
                 });

                var invoice2 = new Invoice
                {
                    LineItems = new List<InvoiceLine>()
                };

                await _invoiceOperations.AddInvoiceLines(invoice2,
                    InvoiceLinesRepo.InvoiceLines
                    .Where(x => x.InvoiceLineId == 2 || x.InvoiceLineId == 3)
                    .ToList());

                _invoiceOperations.MergeInvoices(invoice2, invoice1);
                Console.WriteLine($"Total: {_invoiceOperations.GetTotal(invoice1)}");
            }
            catch (NullReferenceException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception($"Invoice merging failed. Details: {ex.Message}");
            }
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
