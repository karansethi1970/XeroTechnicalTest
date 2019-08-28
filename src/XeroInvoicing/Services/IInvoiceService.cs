namespace XeroInvoicing.Services
{
    public interface IInvoiceService
    {
        void CreateInvoiceWithOneItem();

        void CreateInvoiceWithMultipleItemsAndQuantities();

        void RemoveItem();

        void MergeInvoices();

        void CloneInvoice();

        void InvoiceToString();
    }
}
