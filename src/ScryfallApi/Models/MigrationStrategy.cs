namespace ScryfallApi.Models;

public enum MigrationStrategy
{
    /// <summary>
    /// You should update your records to replace the given old Scryfall ID with the new ID. The old ID is being
    /// discarded, and an existing record should be used to replace all instances of it.
    /// </summary>
    Merge,

    /// <summary>
    /// The given UUID is being discarded, and no replacement data is being provided. This likely means the old records
    /// are fully invalid. This migration exists to provide evidence that cards were removed from Scryfall’s database.
    /// </summary>
    Delete
}