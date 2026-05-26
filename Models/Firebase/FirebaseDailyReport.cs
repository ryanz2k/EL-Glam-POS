using System.Text.Json.Serialization;

namespace ELGlamPOS.Models.Firebase
{
    /// <summary>
    /// EOD daily report pushed to /pos_daily_reports/{key} in Firebase.
    /// </summary>
    public class FirebaseDailyReport
    {
        [JsonPropertyName("branchId")]
        public string BranchId { get; set; } = string.Empty;

        [JsonPropertyName("branchName")]
        public string BranchName { get; set; } = string.Empty;

        [JsonPropertyName("localId")]
        public int LocalId { get; set; }

        [JsonPropertyName("startDate")]
        public string StartDate { get; set; } = string.Empty;

        [JsonPropertyName("endDate")]
        public string EndDate { get; set; } = string.Empty;

        [JsonPropertyName("submittedAt")]
        public string SubmittedAt { get; set; } = string.Empty;

        [JsonPropertyName("openingCashOnHand")]
        public decimal OpeningCashOnHand { get; set; }

        [JsonPropertyName("cashAdvance")]
        public decimal CashAdvance { get; set; }

        [JsonPropertyName("expenses")]
        public decimal Expenses { get; set; }

        [JsonPropertyName("pullOut")]
        public decimal PullOut { get; set; }

        [JsonPropertyName("totalCashOnHand")]
        public decimal TotalCashOnHand { get; set; }

        [JsonPropertyName("denominations")]
        public FirebaseDenominations Denominations { get; set; } = new();

        public static FirebaseDailyReport FromDailyReport(Models.DailyReport r, string branchName)
        {
            return new FirebaseDailyReport
            {
                BranchId = GetBranchSlug(r.BranchId),
                BranchName = branchName,
                LocalId = r.Id,
                StartDate = r.StartDate.ToString("o"),
                EndDate = r.EndDate.ToString("o"),
                SubmittedAt = r.SubmittedAt?.ToString("o") ?? DateTime.UtcNow.ToString("o"),
                OpeningCashOnHand = r.OpeningCashOnHand,
                CashAdvance = r.CashAdvance,
                Expenses = r.Expenses,
                PullOut = r.PullOut,
                TotalCashOnHand = r.ComputeTotalCashOnHand(),
                Denominations = new FirebaseDenominations
                {
                    D1000 = r.Denom1000,
                    D500 = r.Denom500,
                    D200 = r.Denom200,
                    D100 = r.Denom100,
                    D50 = r.Denom50,
                    D20 = r.Denom20,
                    D10 = r.Denom10,
                    D5 = r.Denom5,
                    D1 = r.Denom1
                }
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

    public class FirebaseDenominations
    {
        [JsonPropertyName("1000")] public int D1000 { get; set; }
        [JsonPropertyName("500")]  public int D500  { get; set; }
        [JsonPropertyName("200")]  public int D200  { get; set; }
        [JsonPropertyName("100")]  public int D100  { get; set; }
        [JsonPropertyName("50")]   public int D50   { get; set; }
        [JsonPropertyName("20")]   public int D20   { get; set; }
        [JsonPropertyName("10")]   public int D10   { get; set; }
        [JsonPropertyName("5")]    public int D5    { get; set; }
        [JsonPropertyName("1")]    public int D1    { get; set; }
    }
}
