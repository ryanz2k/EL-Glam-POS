namespace ELGlamPOS.Models
{
    /// <summary>
    /// Base class for entities that sync to Firebase Realtime Database.
    /// SQLite is always the source of truth; Firebase is the cloud mirror.
    /// </summary>
    public abstract class SyncableEntity
    {
        /// <summary>Firebase push() key (e.g. "-OtUgqscOk4N-bC4QoIL"). Null until first successful sync.</summary>
        public string? FirebaseKey { get; set; }

        /// <summary>Current sync state with Firebase.</summary>
        public SyncStatus SyncStatus { get; set; } = SyncStatus.Pending;

        /// <summary>UTC timestamp of last successful push to Firebase.</summary>
        public DateTime? LastSyncedAt { get; set; }
    }
}
