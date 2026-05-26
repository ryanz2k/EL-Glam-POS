using System.Text.Json.Serialization;

namespace ELGlamPOS.Models.Firebase
{
    /// <summary>
    /// Mirrors the /appointments/{key} node structure in Firebase Realtime Database.
    /// Written by the Booking system, read by POS.
    /// </summary>
    public class FirebaseAppointment
    {
        [JsonPropertyName("branchId")]
        public string BranchId { get; set; } = string.Empty;

        [JsonPropertyName("branchName")]
        public string BranchName { get; set; } = string.Empty;

        /// <summary>Unix timestamp in milliseconds (JavaScript Date.now()).</summary>
        [JsonPropertyName("createdAt")]
        public long CreatedAt { get; set; }

        [JsonPropertyName("customerName")]
        public string CustomerName { get; set; } = string.Empty;

        [JsonPropertyName("phone")]
        public string Phone { get; set; } = string.Empty;

        [JsonPropertyName("notes")]
        public string Notes { get; set; } = string.Empty;

        [JsonPropertyName("preferredDate")]
        public string PreferredDate { get; set; } = string.Empty;

        [JsonPropertyName("preferredTime")]
        public string PreferredTime { get; set; } = string.Empty;

        /// <summary>Values: "pending", "confirmed", "completed", "cancelled"</summary>
        [JsonPropertyName("status")]
        public string Status { get; set; } = "pending";

        [JsonPropertyName("totalAmount")]
        public decimal TotalAmount { get; set; }

        [JsonPropertyName("totalCommission")]
        public decimal TotalCommission { get; set; }

        [JsonPropertyName("services")]
        public List<FirebaseAppointmentService> Services { get; set; } = new();

        [JsonPropertyName("stylists")]
        public List<FirebaseStylist> Stylists { get; set; } = new();

        [JsonPropertyName("serviceStylistAssignments")]
        public List<FirebaseServiceStylistAssignment> ServiceStylistAssignments { get; set; } = new();

        /// <summary>Converts Unix ms timestamp to UTC DateTime.</summary>
        public DateTime GetCreatedAtUtc() =>
            DateTimeOffset.FromUnixTimeMilliseconds(CreatedAt).UtcDateTime;

        /// <summary>Parses preferredDate + preferredTime into a DateTime. Returns null if invalid.</summary>
        public DateTime? GetPreferredDateTime()
        {
            if (DateTime.TryParse($"{PreferredDate} {PreferredTime}", out var dt))
                return dt;
            return null;
        }

        /// <summary>Maps Firebase branchId string to local Branch.Id.</summary>
        public static readonly Dictionary<string, int> BranchIdMap = new(StringComparer.OrdinalIgnoreCase)
        {
            { "mandaue", 1 },
            { "pajac", 2 },
            { "pusok", 3 },
            { "cebu", 4 }
        };
    }

    public class FirebaseAppointmentService
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; } = "service";

        [JsonPropertyName("totalServiceCommission")]
        public decimal TotalServiceCommission { get; set; }

        [JsonPropertyName("assignedStylists")]
        public List<FirebaseAssignedStylist> AssignedStylists { get; set; } = new();
    }

    public class FirebaseAssignedStylist
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("position")]
        public string Position { get; set; } = string.Empty;

        [JsonPropertyName("commissionRate")]
        public double CommissionRate { get; set; }

        [JsonPropertyName("commissionAmount")]
        public double CommissionAmount { get; set; }

        [JsonPropertyName("share")]
        public double Share { get; set; }
    }

    public class FirebaseStylist
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("position")]
        public string Position { get; set; } = string.Empty;

        [JsonPropertyName("specialty")]
        public string Specialty { get; set; } = string.Empty;
    }

    public class FirebaseServiceStylistAssignment
    {
        [JsonPropertyName("serviceName")]
        public string ServiceName { get; set; } = string.Empty;

        [JsonPropertyName("servicePrice")]
        public string ServicePrice { get; set; } = string.Empty;

        [JsonPropertyName("stylist")]
        public FirebaseStylist? Stylist { get; set; }
    }
}
