namespace ScryfallApi.Models;

public record ScryfallTagging
{
    public Guid? IllustrationId { get; init; }
    public Guid? OracleId { get; init; }
    public Weight Weight { get; init; }
    public string? Annotation { get; init; }
}
