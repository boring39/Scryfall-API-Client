namespace ScryfallApi.Models;

public abstract record ScryfallObject
{
    public required string Object { get; init; } // TODO: This should not be string but should be an enum
}
