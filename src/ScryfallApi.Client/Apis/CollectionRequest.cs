namespace ScryfallApi.Client.Apis;

public sealed class CollectionRequest
{
    public required List<CardIdentifier> Identifiers { get; init; }
    public bool? Pretty { get; init; }
}