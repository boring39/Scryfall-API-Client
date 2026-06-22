// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: UnconditionalSuppressMessage("AotAnalysis", "SYSLIB1030", Justification = "ScryfallObject intentionally uses the open generic ScryfallList<> polymorphic type; the concrete list variants are registered in the source-generated JSON context.")]
[assembly: SuppressMessage("Design", "CA1720:Identifier 'Object' contains type name", Justification = "The 'Object' property matches the Scryfall API contract and should remain unchanged.", Scope = "member", Target = "~P:ScryfallApi.Models.ScryfallObject.Object")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "member", Target = "~P:ScryfallApi.Models.ScryfallTag.Aliases")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "member", Target = "~P:ScryfallApi.Models.ScryfallTag.ChildIds")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "member", Target = "~P:ScryfallApi.Models.ScryfallTag.ParentIds")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "member", Target = "~P:ScryfallApi.Models.ScryfallTag.Taggings")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "member", Target = "~P:ScryfallApi.Models.ScryfallList`1.Warnings")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "member", Target = "~P:ScryfallApi.Models.ScryfallError.Warnings")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "member", Target = "~P:ScryfallApi.Models.ScryfallCatalog.Data")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "member", Target = "~P:ScryfallApi.Models.ScryfallCardSymbol.Colors")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "member", Target = "~P:ScryfallApi.Models.ScryfallCardFace.Colors")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "member", Target = "~P:ScryfallApi.Models.ScryfallCardFace.ColorIndicator")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "member", Target = "~P:ScryfallApi.Models.ScryfallCard.MultiverseIds")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "member", Target = "~P:ScryfallApi.Models.ScryfallCard.AllParts")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "member", Target = "~P:ScryfallApi.Models.ScryfallCard.CardFaces")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "member", Target = "~P:ScryfallApi.Models.ScryfallCard.ColorIdentity")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "member", Target = "~P:ScryfallApi.Models.ScryfallCard.ColorIndicator")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "member", Target = "~P:ScryfallApi.Models.ScryfallCard.Colors")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "member", Target = "~P:ScryfallApi.Models.ScryfallCard.Keywords")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "member", Target = "~P:ScryfallApi.Models.ScryfallCard.ProducedMana")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "member", Target = "~P:ScryfallApi.Models.ScryfallCard.ArtistIds")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "member", Target = "~P:ScryfallApi.Models.ScryfallCard.AttractionLights")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "member", Target = "~P:ScryfallApi.Models.ScryfallCard.Finishes")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "member", Target = "~P:ScryfallApi.Models.ScryfallCard.FrameEffects")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "member", Target = "~P:ScryfallApi.Models.ScryfallCard.Games")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "member", Target = "~P:ScryfallApi.Models.ScryfallCard.PromoTypes")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "member", Target = "~P:ScryfallApi.Models.ManaCost.Colors")]
[assembly: SuppressMessage("Performance", "CA1819:Properties should not return arrays", Justification = "<Pending>", Scope = "type", Target = "~T:ScryfallApi.Models.ManaCost")]