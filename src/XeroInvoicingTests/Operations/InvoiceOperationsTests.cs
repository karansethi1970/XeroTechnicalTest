using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XeroInvoicing.Models;
using XeroInvoicing.Repo;

namespace XeroInvoicing.Operations.Tests
{
    [TestClass()]
    public class InvoiceOperationsTests
    {
        private readonly InvoiceOperations _invoiceOperations;

        public InvoiceOperationsTests()
        {
            _invoiceOperations = new InvoiceOperations();
        }

        // Note: Test method names are following the pattern: MethodName_InputCondition_ExpectedOutcome

        [TestMethod()]
        public async Task AddInvoiceLinesTest_AddOneInvoiceLine_CostAreEqual()
        {
            var invoice = new Invoice
            {
                LineItems = new List<InvoiceLine>()
            };

            await _invoiceOperations.AddInvoiceLines(invoice, new List<InvoiceLine>
            {
                InvoiceLinesRepo.InvoiceLines.First()
            });

            var expectedCost = InvoiceLinesRepo.InvoiceLines.First().Cost;
            var actualCost = invoice.LineItems.First().Cost;

            Assert.AreEqual(expectedCost, actualCost);
        }

        [TestMethod()]
        public async Task RemoveInvoiceLineTest_RemoveOneInvoiceLine_InvoiceLineIsRemoved()
        {
            var invoice = new Invoice
            {
                LineItems = new List<InvoiceLine>()
            };

            await _invoiceOperations.AddInvoiceLines(invoice, new List<InvoiceLine>
            {
                InvoiceLinesRepo.InvoiceLines.First()
            });

            _invoiceOperations.RemoveInvoiceLine(invoice, 1);

            Assert.IsTrue(invoice.LineItems.Count.Equals(0));
        }

        [TestMethod()]
        public async Task CloneTest_CopyInvoice_CopiedInvoiceHasSameTotal()
        {
            var invoice = new Invoice
            {
                LineItems = new List<InvoiceLine>()
            };

            await _invoiceOperations.AddInvoiceLines(invoice, InvoiceLinesRepo.InvoiceLines);

            var clonedInvoice = await _invoiceOperations.Clone(invoice);

            var expectedTotal = _invoiceOperations.GetTotal(invoice);
            var actualTotal = _invoiceOperations.GetTotal(clonedInvoice);

            Assert.AreEqual(expectedTotal, actualTotal);
        }

        [TestMethod()]
        public void ToStringTest_Invoice_InvoiceIsConvertedToExpectedStringFormat()
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

            var expectedString = $"Invoice Number: 1000, " +
                $"InvoiceDate: {DateTime.Now.ToString("dd/MM/yyyy")}, " +
                $"LineItemCount: 1";

            var actualString = _invoiceOperations.ToString(invoice);

            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod()]
        public async Task MergeInvoicesTest_TwoUniqueInvoices_UniqueInvoicesAreMergedToOne()
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

            var expectedInvoiceTotal = 38.25M;
            var actualInvoiceTotal = _invoiceOperations.GetTotal(invoice1);

            Assert.AreEqual(expectedInvoiceTotal, actualInvoiceTotal);
        }

        [TestMethod()]
        public async Task GetTotalTest_ThreeInvoiceLines_InvoiceTotalMatchesInvoiceLinesTotal()
        {
            var invoice = new Invoice
            {
                LineItems = new List<InvoiceLine>()
            };

            await _invoiceOperations.AddInvoiceLines(invoice, InvoiceLinesRepo.InvoiceLines);

            var expectedInvoiceTotal = 38.25M;
            var actualInvoiceTotal = _invoiceOperations.GetTotal(invoice);

            Assert.AreEqual(expectedInvoiceTotal, actualInvoiceTotal);
        }
    }
}