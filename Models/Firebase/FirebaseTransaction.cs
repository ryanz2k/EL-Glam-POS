using System.Text.Json.Serialization;

namespace ELGlamPOS.Models.Firebase
{
    /// <summary>
    /// Represents a completed POS transaction pushed to /transactions/{key} in Firebase.
    /// Read by the Analytics system.
    /// </summary>
    public class FirebaseTransaction
    {
        [JsonPropertyName("branchId")]
        public string BranchId { get; set; } = string.Empty;

        [JsonPropertyName("branchName")]
        public string BranchName { get; set; } = string.Empty;

        [JsonPropertyName("localId")]
        public int LocalId { get; set; }

        [JsonPropertyName("transactionDate")]
        public string TransactionDate { get; set; } = string.Empty;

        [JsonPropertyName("totalAmount")]
        public decimal TotalAmount { get; set; }

        [JsonPropertyName("discountAmount")]
        public decimal DiscountAmount { get; set; }

        [JsonPropertyName("discountDescription")]
        public string? DiscountDescription { get; set; }

        [JsonPropertyName("paymentType")]
        public string PaymentType { get; set; } = string.Empty;

        [JsonPropertyName("cashAmount")]
        public decimal CashAmount { get; set; }

        [JsonPropertyName("gcashAmount")]
        public decimal GCashAmount { get; set; }

        [JsonPropertyName("mayaAmount")]
        public decimal MayaAmount { get; set; }

        [JsonPropertyName("bankTransferAmount")]
        public decimal BankTransferAmount { get; set; }

        [JsonPropertyName("customerName")]
        public string? CustomerName { get; set; }

        [JsonPropertyName("customerContactNo")]
        public string? CustomerContactNo { get; set; }

        [JsonPropertyName("note")]
        public string? Note { get; set; }

        [JsonPropertyName("receptionistName")]
        public string ReceptionistName { get; set; } = string.Empty;

        [JsonPropertyName("sourceAppointmentKey")]
        public string? SourceAppointmentKey { get; set; }

        [JsonPropertyName("syncedAt")]
        public string SyncedAt { get; set; } = DateTime.UtcNow.ToString("o");

        [JsonPropertyName("items")]
        public List<FirebaseTransactionItem> Items { get; set; } = new();

        public static FirebaseTransaction FromTransaction(Models.Transaction t, string branchName)
        {
            return new FirebaseTransaction
            {
                BranchId = GetBranchSlug(t.BranchId),
                BranchName = branchName,
                LocalId = t.Id,
                TransactionDate = t.TransactionDate.ToString("o"),
                TotalAmount = t.TotalAmount,
                DiscountAmount = t.DiscountAmount,
                DiscountDescription = t.DiscountDescription,
                PaymentType = t.PaymentType.ToString(),
                CashAmount = t.CashAmount,
                GCashAmount = t.GCashAmount,
                MayaAmount = t.MayaAmount,
                BankTransferAmount = t.BankTransferAmount,
                CustomerName = t.CustomerName,
                CustomerContactNo = t.CustomerContactNo,
                Note = t.Note,
                ReceptionistName = t.Receptionist?.Name ?? string.Empty,
                SourceAppointmentKey = t.SourceAppointmentKey,
                SyncedAt = DateTime.UtcNow.ToString("o"),
                Items = t.Items.Select(FirebaseTransactionItem.FromTransactionItem).ToList()
            };
        }

        private static string GetBranchSlug(int branchId) => branchId switch
        {
            1 => "mandaue",
            2 => "pajac",
            3 => "pusok",
            4 => "cebu",
            _ => branchId.ToString()
        };
    }

    public class FirebaseTransactionItem
    {
        [JsonPropertyName("serviceName")]
        public string ServiceName { get; set; } = string.Empty;

        [JsonPropertyName("category")]
        public string Category { get; set; } = string.Empty;

        [JsonPropertyName("type")]
        public string Type { get; set; } = "service";

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("priceAtTimeOfSale")]
        public decimal PriceAtTimeOfSale { get; set; }

        [JsonPropertyName("calculatedCommission")]
        public decimal CalculatedCommission { get; set; }

        [JsonPropertyName("assignedEmployeeName")]
        public string AssignedEmployeeName { get; set; } = string.Empty;

        public static FirebaseTransactionItem FromTransactionItem(Models.TransactionItem ti)
        {
            return new FirebaseTransactionItem
            {
                ServiceName = ti.ServiceItem?.Name ?? string.Empty,
                Category = ti.ServiceItem?.Category?.Name ?? string.Empty,
                Type = ti.ServiceItem?.Type.ToString().ToLower() ?? "service",
                Quantity = ti.Quantity,
                PriceAtTimeOfSale = ti.PriceAtTimeOfSale,
                CalculatedCommission = ti.CalculatedCommission,
                AssignedEmployeeName = ti.AssignedEmployee?.Name ?? string.Empty
            };
        }
    }
}
