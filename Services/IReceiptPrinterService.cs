using ELGlamPOS.Models;

namespace ELGlamPOS.Services
{
    public interface IReceiptPrinterService
    {
        Task PrintReceiptAsync(Transaction transaction);
        Task PrintCustomNoteAsync(string note);
        Task PrintLogoAsync();
    }
}
