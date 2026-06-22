namespace ScryfallApi.Models;

public record ScryfallTag : ScryfallObject
{
    public Guid Id { get; init; }
    public required string Slug { get; init; }
    public required string Label { get; init; }
    public required Uri Uri { get; init; }
    public TagType Type { get; init; }
    public string? Description { get; init; }
    public Guid[]? ParentIds { get; init; }
    public Guid[]? ChildIds { get; init; }
    public string[]? Aliases { get; init; }
    public required ScryfallTagging[] Taggings { get; init; }
}
