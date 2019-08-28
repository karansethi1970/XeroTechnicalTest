using System.Threading.Tasks;

namespace XeroInvoicing.Services
{
    public interface IInvoiceService
    {
        Task CreateInvoiceWithOneItem();

        Task CreateInvoiceWithMultipleItemsAndQuantities();

        void RemoveItem();

        void MergeInvoices();

        Task CloneInvoice();

        void InvoiceToString();
    }
}
