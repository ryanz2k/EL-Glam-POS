using ELGlamPOS.Models;
using System.Diagnostics;

namespace ELGlamPOS.Services
{
    public class MockReceiptPrinterService : IReceiptPrinterService
    {
        public Task PrintCustomNoteAsync(string note)
        {
            Debug.WriteLine($"[Mock Printer] Printing Note: {note}");
            return Task.CompletedTask;
        }

        public Task PrintLogoAsync()
        {
            Debug.WriteLine($"[Mock Printer] Printing Logo...");
            return Task.CompletedTask;
        }

        public Task PrintReceiptAsync(Transaction transaction)
        {
            Debug.WriteLine($"[Mock Printer] --- RECEIPT ---");
            Debug.WriteLine($"[Mock Printer] Transaction #{transaction.Id}");
            Debug.WriteLine($"[Mock Printer] Date: {transaction.TransactionDate}");
            Debug.WriteLine($"[Mock Printer] Total: ${transaction.TotalAmount}");
            Debug.WriteLine($"[Mock Printer] Payment: {transaction.PaymentType}");
            Debug.WriteLine($"[Mock Printer] -----------------");
            return Task.CompletedTask;
        }
    }
}
