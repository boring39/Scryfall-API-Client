namespace ScryfallApi.Models;

public record ScryfallError : ScryfallObject
{
    /// <summary> An integer HTTP status code for this error. </summary>
    public int Status { get; init; }

    /// <summary> A computer-friendly string representing the appropriate HTTP status code. </summary>
    public required string Code { get; init; }

    /// <summary> A human-readable string explaining the error. </summary>
    public required string Details { get; init; }

    /// <summary>
    /// A computer-friendly string that provides additional context for the main error. For
    /// example, an endpoint many generate HTTP 404 errors for different kinds of input. This
    /// field will provide a label for the specific kind of 404 failure, such as ambiguous.
    /// </summary>
    public string? Type { get; init; }

    /// <summary>
    /// If your input also generated non-failure warnings, they will be provided as
    /// human-readable strings in this array.
    /// </summary>
    public string[]? Warnings { get; init; }
}
