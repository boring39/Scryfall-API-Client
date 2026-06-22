using System.Text.Json;
namespace ScryfallApi.Models;

public abstract record ScryfallMigration : ScryfallObject
{
    /// <summary> A link to the current <see cref="ScryfallObject">object</see> Scryfall's API. </summary>
    public required Uri Uri { get; init; }

    /// <summary> This migration's unique UUID. </summary>
    public Guid Id { get; init; }

    /// <summary> The date this migration was performed. </summary>
    public DateOnly PerformedAt { get; init; }

    /// <summary> A computer-readable indicator of the migration strategy. See <seealso cref="MigrationStrategy"/>.  </summary>
    public MigrationStrategy MigrationStrategy { get; init; } // TODO: How do I remove this field but allow it to serialize back correctly?

    /// <summary> The id of the affected API Card object. </summary>
    public Guid OldScryfallId { get; init; }

    /// <summary> The replacement id of the API Card object if this is a <seealso cref="MigrationStrategy.Merge"/>. </summary>
    public Guid? NewScryfallId { get; init; }

    /// <summary> A note left by the Scryfall team about this migration. </summary>
    public string? Note { get; init; }

    /// <summary> Additional context Scryfall has provided for this migration, designed to be human-read only. </summary>
    public JsonElement? Metadata { get; init; } // TODO: Scryfall returns arbitrary JSON here — preserve it as JsonElement replace later
}