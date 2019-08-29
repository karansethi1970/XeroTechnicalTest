using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using XeroInvoicing.Models;
using XeroInvoicing.Operations;
using XeroInvoicing.Repo;

namespace XeroInvoicing.Services.Tests
{
    [TestClass()]
    public class InvoiceServiceTests
    {
        private readonly InvoiceOperations _invoiceOperations;

        public InvoiceServiceTests()
        {
            _invoiceOperations = new InvoiceOperations();
        }

        // Note: Test method names are following the pattern: MethodName_InputCondition_ExpectedOutcome

        [TestMethod()]
        public async Task CreateInvoiceWithMultipleItemsAndQuantitiesTest_MultipleInvoiceLines_InvoiceLineCountIsSameAsSupplied()
        {
            var invoice = new Invoice
            {
                LineItems = new List<InvoiceLine>()
            };

            await _invoiceOperations.AddInvoiceLines(invoice, InvoiceLinesRepo.InvoiceLines);

            var expectedInvoiceLinesCount = InvoiceLinesRepo.InvoiceLines.Count;
            var actualInvoiceLinesCount = invoice.LineItems.Count;

            Assert.AreEqual(expectedInvoiceLinesCount, actualInvoiceLinesCount);
        }
    }
}