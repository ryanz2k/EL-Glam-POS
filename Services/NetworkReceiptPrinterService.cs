using ELGlamPOS.Models;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;

namespace ELGlamPOS.Services
{
    public class NetworkReceiptPrinterService : IReceiptPrinterService
    {
        private readonly string _printerIp;
        private readonly int _printerPort;

        // Default ESC/POS port is 9100
        public NetworkReceiptPrinterService(string printerIp = "192.168.1.200", int printerPort = 9100)
        {
            _printerIp = printerIp;
            _printerPort = printerPort;
        }

        private byte[] GetEscPosCommand(string command)
        {
            return command switch
            {
                "INIT" => new byte[] { 27, 64 }, // ESC @
                "ALIGN_CENTER" => new byte[] { 27, 97, 1 }, // ESC a 1
                "ALIGN_LEFT" => new byte[] { 27, 97, 0 }, // ESC a 0
                "ALIGN_RIGHT" => new byte[] { 27, 97, 2 }, // ESC a 2
                "BOLD_ON" => new byte[] { 27, 69, 1 }, // ESC E 1
                "BOLD_OFF" => new byte[] { 27, 69, 0 }, // ESC E 0
                "CUT" => new byte[] { 29, 86, 65, 0 }, // GS V A 0
                _ => Array.Empty<byte>()
            };
        }

        private async Task SendBytesAsync(byte[] data)
        {
            try
            {
                using var client = new TcpClient();
                var cancelSource = new CancellationTokenSource(TimeSpan.FromSeconds(2));
                await client.ConnectAsync(_printerIp, _printerPort, cancelSource.Token);
                using var stream = client.GetStream();
                await stream.WriteAsync(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Printer Error: {ex.Message}");
                // In a production app, we would surface this to the UI
            }
        }

        public async Task PrintReceiptAsync(Transaction transaction)
        {
            using var ms = new MemoryStream();
            using var writer = new BinaryWriter(ms);

            // Initialize printer
            writer.Write(GetEscPosCommand("INIT"));
            
            // Header
            writer.Write(GetEscPosCommand("ALIGN_CENTER"));
            writer.Write(GetEscPosCommand("BOLD_ON"));
            writer.Write(Encoding.ASCII.GetBytes("EL Glamorous Face and Body Clinic\n"));
            writer.Write(GetEscPosCommand("BOLD_OFF"));
            writer.Write(Encoding.ASCII.GetBytes("Mandaue City, Cebu\n\n")); // Could be dynamic from Branch

            writer.Write(GetEscPosCommand("ALIGN_LEFT"));
            writer.Write(Encoding.ASCII.GetBytes($"Date: {transaction.TransactionDate.ToLocalTime():yyyy-MM-dd HH:mm}\n"));
            writer.Write(Encoding.ASCII.GetBytes($"Receipt #: {transaction.Id.ToString().PadLeft(6, '0')}\n"));
            writer.Write(Encoding.ASCII.GetBytes(new string('-', 42) + "\n"));

            // Items
            foreach (var item in transaction.Items)
            {
                // Item line
                string itemName = item.ServiceItem.Name;
                if (itemName.Length > 25) itemName = itemName.Substring(0, 25);
                
                string qtyAndPrice = $"{item.Quantity}x @{item.PriceAtTimeOfSale:N2}";
                string line1 = $"{itemName.PadRight(26)} {qtyAndPrice.PadLeft(15)}\n";
                writer.Write(Encoding.ASCII.GetBytes(line1));

                // Provider line
                if (item.AssignedEmployee != null)
                {
                    writer.Write(Encoding.ASCII.GetBytes($"  Provider: {item.AssignedEmployee.Name}\n"));
                }
            }

            writer.Write(Encoding.ASCII.GetBytes(new string('-', 42) + "\n"));
            
            // Totals
            writer.Write(GetEscPosCommand("ALIGN_RIGHT"));
            writer.Write(GetEscPosCommand("BOLD_ON"));
            writer.Write(Encoding.ASCII.GetBytes($"TOTAL: PHP {transaction.TotalAmount:N2}\n"));
            writer.Write(GetEscPosCommand("BOLD_OFF"));
            
            writer.Write(GetEscPosCommand("ALIGN_CENTER"));
            writer.Write(Encoding.ASCII.GetBytes("\nThank you for choosing EL Glam!\n\n\n\n\n"));
            
            // Cut paper
            writer.Write(GetEscPosCommand("CUT"));

            await SendBytesAsync(ms.ToArray());
        }

        public async Task PrintCustomNoteAsync(string note)
        {
            using var ms = new MemoryStream();
            using var writer = new BinaryWriter(ms);
            
            writer.Write(GetEscPosCommand("INIT"));
            writer.Write(GetEscPosCommand("ALIGN_LEFT"));
            writer.Write(Encoding.ASCII.GetBytes(note + "\n\n\n\n"));
            writer.Write(GetEscPosCommand("CUT"));
            
            await SendBytesAsync(ms.ToArray());
        }

        public async Task PrintLogoAsync()
        {
            // Logo printing in ESC/POS requires sending the bitmap data.
            // Placeholder for now.
            await Task.CompletedTask;
        }
    }
}
