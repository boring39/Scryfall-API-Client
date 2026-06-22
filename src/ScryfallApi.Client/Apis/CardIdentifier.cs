namespace ScryfallApi.Client.Apis;

public sealed class CardIdentifier
{
    public Guid? Id { get; init; }
    public int? MtgoId { get; init; }
    public int? MultiverseId { get; init; }
    public Guid? OracleId { get; init; }
    public Guid? IllustrationId { get; init; }
    public string? Name { get; init; }
    public string? Set { get; init; }
    public string? CollectorNumber { get; init; }
}