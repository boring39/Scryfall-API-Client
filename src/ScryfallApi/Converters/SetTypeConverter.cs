using System.Text.Json;
using System.Text.Json.Serialization;
using ScryfallApi.Models;

namespace ScryfallApi.Converters;

internal class SetTypeConverter : JsonConverter<SetType>
{
    public override SetType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        return value?.ToLowerInvariant() switch
        {
            "core" => SetType.Core,
            "expansion" => SetType.Expansion,
            "masters" => SetType.Masters,
            "eternal" => SetType.Eternal,
            "alchemy" => SetType.Alchemy,
            "masterpiece" => SetType.Masterpiece,
            "arsenal" => SetType.Arsenal,
            "from_the_vault" => SetType.FromTheVault,
            "spellbook" => SetType.Spellbook,
            "premium_deck" => SetType.PremiumDeck,
            "duel_deck" => SetType.DuelDeck,
            "draft_innovation" => SetType.DraftInnovation,
            "treasure_chest" => SetType.TreasureChest,
            "commander" => SetType.Commander,
            "planechase" => SetType.Planechase,
            "archenemy" => SetType.Archenemy,
            "vanguard" => SetType.Vanguard,
            "funny" => SetType.Funny,
            "starter" => SetType.Starter,
            "box" => SetType.Box,
            "promo" => SetType.Promo,
            "token" => SetType.Token,
            "memorabilia" => SetType.Memorabilia,
            "minigame" => SetType.Minigame,
            _ => throw new JsonException($"Unknown set type '{value}' detected.")
        };
    }
    public override void Write(Utf8JsonWriter writer, SetType value, JsonSerializerOptions options)
    {
        var str = value switch
        {
            SetType.Core => "core"u8,
            SetType.Expansion => "expansion"u8,
            SetType.Masters => "masters"u8,
            SetType.Eternal => "eternal"u8,
            SetType.Alchemy => "alchemy"u8,
            SetType.Masterpiece => "masterpiece"u8,
            SetType.Arsenal => "arsenal"u8,
            SetType.FromTheVault => "from_the_vault"u8,
            SetType.Spellbook => "spellbook"u8,
            SetType.PremiumDeck => "premium_deck"u8,
            SetType.DuelDeck => "duel_deck"u8,
            SetType.DraftInnovation => "draft_innovation"u8,
            SetType.TreasureChest => "treasure_chest"u8,
            SetType.Commander => "commander"u8,
            SetType.Planechase => "planechase"u8,
            SetType.Archenemy => "archenemy"u8,
            SetType.Vanguard => "vanguard"u8,
            SetType.Funny => "funny"u8,
            SetType.Starter => "starter"u8,
            SetType.Box => "box"u8,
            SetType.Promo => "promo"u8,
            SetType.Token => "token"u8,
            SetType.Memorabilia => "memorabilia"u8,
            SetType.Minigame => "minigame"u8,
            _ => throw new NotImplementedException() // TODO: proper error handling
        };

        writer.WriteStringValue(str);
    }
}