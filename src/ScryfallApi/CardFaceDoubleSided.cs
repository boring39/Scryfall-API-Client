namespace ScryfallApi.Models;

/// <summary>
/// This card face is only for parent layouts of "transform," "modal_dfc", "double_faced_token", "art_series", and "reverible_card"
/// </summary>
public record CardFaceDoubleSided : CardFaceObject
{
    /// double-sided only

    /// <summary>
    /// An object providing URIs to imagery for this face, if this is a double-sided card. If this card
    /// is not double-sided, then the image_uris property will be part of the parent object instead.
    /// </summary>
    public Dictionary<string, Uri>? ImageUris { get; init; } // TODO: Create an image_uris class
}
