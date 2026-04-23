public record BaseQuery
{
    public bool? Pretty {get; init;}
    public string? Format {get; init;} = "json"; // TODO: Json or CSV
}