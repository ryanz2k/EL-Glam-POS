using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ELGlamPOS.Models;
using System.Diagnostics;

namespace ELGlamPOS.Services
{
    public class UsbReceiptPrinterService : IReceiptPrinterService
    {
        private readonly string _printerName;

        public UsbReceiptPrinterService(string printerName = "")
        {
#if WINDOWS
            if (string.IsNullOrWhiteSpace(printerName))
            {
                int bufferSize = 256;
                var sb = new StringBuilder(bufferSize);
                if (RawPrinterHelper.GetDefaultPrinter(sb, ref bufferSize))
                {
                    _printerName = sb.ToString();
                }
                else
                {
                    _printerName = "Receipt Printer";
                }
            }
            else
            {
                _printerName = printerName;
            }
#else
            _printerName = "Unsupported on this platform";
#endif
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
                    RawPrinterHelper.SendBytesToPrinter(_printerName, data);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"USB Printer Error: {ex.Message}");
                }
            });
#else
            Debug.WriteLine("USB Printing is not supported on Android. Ignored.");
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
            writer.Write(Encoding.ASCII.GetBytes(new string('-', 42) + "\n"));

            // Items
            foreach (var item in transaction.Items)
            {
                string itemName = item.ServiceItem.Name;
                if (itemName.Length > 25) itemName = itemName.Substring(0, 25);
                
                string qtyAndPrice = $"{item.Quantity}x @{item.PriceAtTimeOfSale:N2}";
                string line1 = $"{itemName.PadRight(26)} {qtyAndPrice.PadLeft(15)}\n";
                writer.Write(Encoding.ASCII.GetBytes(line1));

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

        public Task PrintLogoAsync()
        {
            return Task.CompletedTask;
        }
    }

#if WINDOWS
    public static class RawPrinterHelper
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public class DOCINFOA
        {
            [MarshalAs(UnmanagedType.LPStr)] public string pDocName = "Document";
            [MarshalAs(UnmanagedType.LPStr)] public string pOutputFile = null!;
            [MarshalAs(UnmanagedType.LPStr)] public string pDataType = "RAW";
        }

        [DllImport("winspool.Drv", EntryPoint = "GetDefaultPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool GetDefaultPrinter(StringBuilder pszBuffer, ref int pcchBuffer);

        [DllImport("winspool.Drv", EntryPoint = "OpenPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool OpenPrinter([MarshalAs(UnmanagedType.LPStr)] string szPrinter, out IntPtr hPrinter, IntPtr pd);

        [DllImport("winspool.Drv", EntryPoint = "ClosePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool ClosePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartDocPrinterA", SetLastError = true, CharSet = CharSet.Ansi, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartDocPrinter(IntPtr hPrinter, int level, [In, MarshalAs(UnmanagedType.LPStruct)] DOCINFOA di);

        [DllImport("winspool.Drv", EntryPoint = "EndDocPrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndDocPrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "StartPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool StartPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "EndPagePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool EndPagePrinter(IntPtr hPrinter);

        [DllImport("winspool.Drv", EntryPoint = "WritePrinter", SetLastError = true, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern bool WritePrinter(IntPtr hPrinter, IntPtr pBytes, int dwCount, out int dwWritten);

        public static bool SendBytesToPrinter(string szPrinterName, byte[] data)
        {
            var pBytes = Marshal.AllocCoTaskMem(data.Length);
            Marshal.Copy(data, 0, pBytes, data.Length);

            var di = new DOCINFOA
            {
                pDocName = "POS Receipt",
                pDataType = "RAW"
            };

            bool success = false;
            if (OpenPrinter(szPrinterName.Normalize(), out IntPtr hPrinter, IntPtr.Zero))
            {
                if (StartDocPrinter(hPrinter, 1, di))
                {
                    if (StartPagePrinter(hPrinter))
                    {
                        success = WritePrinter(hPrinter, pBytes, data.Length, out int dwWritten);
                        EndPagePrinter(hPrinter);
                    }
                    EndDocPrinter(hPrinter);
                }
                ClosePrinter(hPrinter);
            }

            Marshal.FreeCoTaskMem(pBytes);
            return success;
        }
    }
#endif
}
