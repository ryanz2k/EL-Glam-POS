using System;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading.Tasks;
using ELGlamPOS.Models;
using System.Diagnostics;

namespace ELGlamPOS.Services
{
    public class BluetoothReceiptPrinterService : IReceiptPrinterService
    {
        private readonly string _comPort;

        public BluetoothReceiptPrinterService(string comPort = "COM3")
        {
            _comPort = comPort;
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

        private Task SendBytesAsync(byte[] data)
        {
#if WINDOWS
            return Task.Run(() =>
            {
                try
                {
                    using var serialPort = new SerialPort(_comPort, 9600, Parity.None, 8, StopBits.One);
                    serialPort.Open();
                    serialPort.Write(data, 0, data.Length);
                    serialPort.Close();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Bluetooth (COM) Printer Error: {ex.Message}");
                }
            });
#else
            Debug.WriteLine("Native Bluetooth SPP is required for Android. Please map Xprinter via an Android Print Service or MAUI Bluetooth plugin.");
            return Task.CompletedTask;
#endif
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
            writer.Write(Encoding.ASCII.GetBytes("Mandaue City, Cebu\n\n"));

            writer.Write(GetEscPosCommand("ALIGN_LEFT"));
            writer.Write(Encoding.ASCII.GetBytes($"Date: {transaction.TransactionDate.ToLocalTime():yyyy-MM-dd HH:mm}\n"));
            writer.Write(Encoding.ASCII.GetBytes($"Receipt #: {transaction.Id.ToString().PadLeft(6, '0')}\n"));
            writer.Write(Encoding.ASCII.GetBytes(new string('-', 32) + "\n"));

            // Items (Adjusted for 58mm printer which is usually 32 chars wide)
            foreach (var item in transaction.Items)
            {
                string itemName = item.ServiceItem.Name;
                if (itemName.Length > 16) itemName = itemName.Substring(0, 16);
                
                string qtyAndPrice = $"{item.Quantity}x @{item.PriceAtTimeOfSale:N0}";
                string line1 = $"{itemName.PadRight(17)} {qtyAndPrice.PadLeft(14)}\n";
                writer.Write(Encoding.ASCII.GetBytes(line1));

                if (item.AssignedEmployee != null)
                {
                    writer.Write(Encoding.ASCII.GetBytes($"  Provider: {item.AssignedEmployee.Name}\n"));
                }
            }

            writer.Write(Encoding.ASCII.GetBytes(new string('-', 32) + "\n"));
            
            // Totals
            writer.Write(GetEscPosCommand("ALIGN_RIGHT"));
            writer.Write(GetEscPosCommand("BOLD_ON"));
            writer.Write(Encoding.ASCII.GetBytes($"TOTAL: PHP {transaction.TotalAmount:N2}\n"));
            writer.Write(GetEscPosCommand("BOLD_OFF"));
            
            writer.Write(GetEscPosCommand("ALIGN_CENTER"));
            writer.Write(Encoding.ASCII.GetBytes("\nThank you for choosing EL Glam!\n\n\n\n\n"));
            
            // Cut paper (Many 58mm don't have auto-cutter, but sending it is safe)
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

        public Task PrintLogoAsync()
        {
            return Task.CompletedTask;
        }
    }
}
