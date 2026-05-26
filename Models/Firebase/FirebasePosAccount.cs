namespace ELGlamPOS.Models.Firebase
{
    /// <summary>
    /// Represents a POS user account record stored in Firebase /pos_accounts.
    /// Used to sync receptionist credentials across devices.
    /// The password is never stored here — only metadata. Devices create/update
    /// local Identity users when they pull this data and prompt for a password reset if new.
    /// </summary>
    public class FirebasePosAccount
    {
        /// <summary>Encoded email used as the Firebase node key (@ and . replaced).</summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>Full display name of the receptionist.</summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>Local Employee.Id on the device that created this account.</summary>
        public int EmployeeId { get; set; }

        /// <summary>Branch Id the receptionist is assigned to.</summary>
        public int BranchId { get; set; }

        /// <summary>Role string, always "Receptionist" for now.</summary>
        public string Role { get; set; } = "Receptionist";

        /// <summary>
        /// A device-agnostic password token. Admin sets this when creating/resetting.
        /// Each device reads it once, creates/updates the local Identity user with this
        /// password, then clears it from local state (not from Firebase — admin controls it).
        /// </summary>
        public string? PasswordToken { get; set; }

        /// <summary>UTC timestamp when this record was last updated.</summary>
        public string UpdatedAt { get; set; } = DateTime.UtcNow.ToString("o");
    }
}
