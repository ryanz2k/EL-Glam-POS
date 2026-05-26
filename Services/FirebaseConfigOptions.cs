namespace ELGlamPOS.Services
{
    public class FirebaseConfigOptions
    {
        public const string SectionName = "Firebase";

        public string DatabaseUrl { get; set; } = string.Empty;
        public string ApiKey { get; set; } = string.Empty;
        public string AuthDomain { get; set; } = string.Empty;
        public string ProjectId { get; set; } = string.Empty;
        public string StorageBucket { get; set; } = string.Empty;
        public string MessagingSenderId { get; set; } = string.Empty;
        public string AppId { get; set; } = string.Empty;

        /// <summary>
        /// Email of the dedicated Firebase Auth user for the POS system.
        /// Create this user in Firebase Console and grant write access in RTDB rules.
        /// </summary>
        public string PosEmail { get; set; } = string.Empty;

        /// <summary>Password for the POS Firebase Auth user.</summary>
        public string PosPassword { get; set; } = string.Empty;

        public bool IsConfigured =>
            !string.IsNullOrWhiteSpace(DatabaseUrl) &&
            !string.IsNullOrWhiteSpace(ApiKey) &&
            !string.IsNullOrWhiteSpace(PosEmail) &&
            !string.IsNullOrWhiteSpace(PosPassword) &&
            !PosEmail.StartsWith("REPLACE_");
    }
}
