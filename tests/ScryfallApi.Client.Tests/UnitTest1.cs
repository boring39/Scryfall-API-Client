using System.ComponentModel;
using System.Text.Json;

namespace ScryfallApi.Client.Tests;

[TestClass]
public sealed class CardObjectTests
{
    private readonly string _json = /*lang=json,strict*/ """
        {
            "object": "card",
            "id": "4f04188d-9a76-495d-b3a7-ee44810cf671",
            "oracle_id": "bc71ebf6-2056-41f7-be35-b2e5c34afa99",
            "multiverse_ids": [
                668548
            ],
            "mtgo_id": 129793,
            "arena_id": 91813,
            "tcgplayer_id": 558418,
            "cardmarket_id": 777713,
            "name": "Plains",
            "lang": "en",
            "released_at": "2024-08-02",
            "uri": "https://api.scryfall.com/cards/4f04188d-9a76-495d-b3a7-ee44810cf671",
            "scryfall_uri": "https://scryfall.com/card/blb/264/plains?utm_source=api",
            "layout": "normal",
            "highres_image": true,
            "image_status": "highres_scan",
            "image_uris": {
                "small": "https://cards.scryfall.io/small/front/4/f/4f04188d-9a76-495d-b3a7-ee44810cf671.jpg?1721427379",
                "normal": "https://cards.scryfall.io/normal/front/4/f/4f04188d-9a76-495d-b3a7-ee44810cf671.jpg?1721427379",
                "large": "https://cards.scryfall.io/large/front/4/f/4f04188d-9a76-495d-b3a7-ee44810cf671.jpg?1721427379",
                "png": "https://cards.scryfall.io/png/front/4/f/4f04188d-9a76-495d-b3a7-ee44810cf671.png?1721427379",
                "art_crop": "https://cards.scryfall.io/art_crop/front/4/f/4f04188d-9a76-495d-b3a7-ee44810cf671.jpg?1721427379",
                "border_crop": "https://cards.scryfall.io/border_crop/front/4/f/4f04188d-9a76-495d-b3a7-ee44810cf671.jpg?1721427379"
            },
            "mana_cost": "",
            "cmc": 0,
            "type_line": "Basic Land — Plains",
            "oracle_text": "({T}: Add {W}.)",
            "colors": [],
            "color_identity": [
                "W"
            ],
            "keywords": [],
            "produced_mana": [
                "W"
            ],
            "legalities": {
                "standard": "legal",
                "future": "legal",
                "historic": "legal",
                "timeless": "legal",
                "gladiator": "legal",
                "pioneer": "legal",
                "modern": "legal",
                "legacy": "legal",
                "pauper": "legal",
                "vintage": "legal",
                "penny": "legal",
                "commander": "legal",
                "oathbreaker": "legal",
                "standardbrawl": "legal",
                "brawl": "legal",
                "alchemy": "legal",
                "paupercommander": "legal",
                "duel": "legal",
                "oldschool": "not_legal",
                "premodern": "legal",
                "predh": "legal"
            },
            "games": [
                "paper",
                "mtgo",
                "arena"
            ],
            "reserved": false,
            "game_changer": false,
            "foil": true,
            "nonfoil": true,
            "finishes": [
                "nonfoil",
                "foil"
            ],
            "oversized": false,
            "promo": false,
            "reprint": true,
            "variation": false,
            "set_id": "a2f58272-bba6-439d-871e-7a46686ac018",
            "set": "blb",
            "set_name": "Bloomburrow",
            "set_type": "expansion",
            "set_uri": "https://api.scryfall.com/sets/a2f58272-bba6-439d-871e-7a46686ac018",
            "set_search_uri": "https://api.scryfall.com/cards/search?order=set&q=e%3Ablb&unique=prints",
            "scryfall_set_uri": "https://scryfall.com/sets/blb?utm_source=api",
            "rulings_uri": "https://api.scryfall.com/cards/4f04188d-9a76-495d-b3a7-ee44810cf671/rulings",
            "prints_search_uri": "https://api.scryfall.com/cards/search?order=released&q=oracleid%3Abc71ebf6-2056-41f7-be35-b2e5c34afa99&unique=prints",
            "collector_number": "264",
            "digital": false,
            "rarity": "common",
            "card_back_id": "0aeebaf5-8c7d-4636-9e82-8c27447861f7",
            "artist": "Carlos Palma Cruchaga",
            "artist_ids": [
                "f0c43e1b-1853-4abc-8a1b-d7dda6c1d592"
            ],
            "illustration_id": "381a8778-bcab-4847-95df-8eabf7dd858d",
            "border_color": "black",
            "frame": "2015",
            "full_art": true,
            "textless": false,
            "booster": true,
            "story_spotlight": false,
            "prices": {
                "usd": "0.33",
                "usd_foil": "0.40",
                "usd_etched": null,
                "eur": "0.28",
                "eur_foil": "0.51",
                "tix": "0.03"
            },
            "related_uris": {
                "gatherer": "https://gatherer.wizards.com/Pages/Card/Details.aspx?multiverseid=668548&printed=false",
                "tcgplayer_infinite_articles": "https://partner.tcgplayer.com/c/4931599/1830156/21018?subId1=api&trafcat=tcgplayer.com%2Fsearch%2Farticles&u=https%3A%2F%2Fwww.tcgplayer.com%2Fsearch%2Farticles%3FproductLineName%3Dmagic%26q%3DPlains",
                "tcgplayer_infinite_decks": "https://partner.tcgplayer.com/c/4931599/1830156/21018?subId1=api&trafcat=tcgplayer.com%2Fsearch%2Fdecks&u=https%3A%2F%2Fwww.tcgplayer.com%2Fsearch%2Fdecks%3FproductLineName%3Dmagic%26q%3DPlains",
                "edhrec": "https://edhrec.com/route/?cc=Plains"
            },
            "purchase_uris": {
                "tcgplayer": "https://partner.tcgplayer.com/c/4931599/1830156/21018?subId1=api&u=https%3A%2F%2Fwww.tcgplayer.com%2Fproduct%2F558418%3Fpage%3D1",
                "cardmarket": "https://www.cardmarket.com/en/Magic/Products?idProduct=777713&referrer=scryfall&utm_campaign=card_prices&utm_medium=text&utm_source=scryfall",
                "cardhoarder": "https://www.cardhoarder.com/cards/129793?affiliate_id=scryfall&ref=card-profile&utm_campaign=affiliate&utm_medium=card&utm_source=scryfall"
            }
        }
        """;

    // ------------------------------------------------------------
    // BASELINE TEST
    // ------------------------------------------------------------
    [TestMethod]
    public void Card_ShouldDeserialize()
    {
        var card = JsonSerializer.Deserialize<Models.Card>(_json);

        Assert.IsNotNull(card);
        Assert.AreEqual("4f04188d-9a76-495d-b3a7-ee44810cf671", card!.Id.ToString());
        Assert.AreEqual("Plains", card.Name);
    }

    // ------------------------------------------------------------
    // IMAGE URIS
    // ------------------------------------------------------------
    [TestMethod]
    public void Card_ShouldDeserialize_ImageUris()
    {
        var card = JsonSerializer.Deserialize<Models.Card>(_json);

        Assert.IsNotNull(card!.ImageUris);
        Assert.AreEqual(new Uri("https://cards.scryfall.io/small/front/4/f/4f04188d-9a76-495d-b3a7-ee44810cf671.jpg?1721427379", UriKind.Absolute), card.ImageUris["small"]);
        Assert.AreEqual(new Uri("https://cards.scryfall.io/normal/front/4/f/4f04188d-9a76-495d-b3a7-ee44810cf671.jpg?1721427379", UriKind.Absolute), card.ImageUris["normal"]);
    }

    // ------------------------------------------------------------
    // LEGALITIES
    // ------------------------------------------------------------
    [TestMethod]
    public void Card_ShouldDeserialize_Legalities()
    {
        var card = JsonSerializer.Deserialize<Models.Card>(_json);

        Assert.IsNotNull(card!.Legalities);
        Assert.AreEqual("legal", card.Legalities!["modern"]);
        Assert.AreEqual("legal", card.Legalities["legacy"]);
        Assert.AreEqual("not_legal", card.Legalities["oldschool"]);
    }

    // ------------------------------------------------------------
    // PRICES
    // ------------------------------------------------------------
    [TestMethod]
    public void Card_ShouldDeserialize_Prices()
    {
        var card = JsonSerializer.Deserialize<Models.Card>(_json);

        Assert.IsNotNull(card!.Prices);
        Assert.IsNull(card.Prices.UsdEtched);
        Assert.AreEqual(decimal.Parse("0.28"), card.Prices.Eur);
        Assert.AreEqual(decimal.Parse("0.03"), card.Prices.Tix);
    }

    // ------------------------------------------------------------
    // ARRAYS
    // ------------------------------------------------------------
    [TestMethod]
    public void Card_ShouldDeserialize_Arrays()
    {
        var card = JsonSerializer.Deserialize<Models.Card>(_json);

        Assert.AreEqual(Models.Colors.None, card!.Colors);
        Assert.AreEqual(Models.Colors.White, card.ColorIdentity);
        Assert.AreEqual([], card.Keywords);
        Assert.AreEqual([668548], card.MultiverseIds);
    }

    // ------------------------------------------------------------
    // ROUND TRIP
    // ------------------------------------------------------------
    [TestMethod]
    public void Card_ShouldRoundTrip_SerializeDeserialize()
    {
        var card = JsonSerializer.Deserialize<Models.Card>(_json);
        var json = JsonSerializer.Serialize(card);
        var card2 = JsonSerializer.Deserialize<Models.Card>(json);

        Assert.AreEqual(card!.Id, card2!.Id);
        Assert.AreEqual(card.Name, card2.Name);
        Assert.AreEqual(card.Prices!.Usd, card2.Prices!.Usd);
    }

    // ------------------------------------------------------------
    // MISSING FIELDS
    // ------------------------------------------------------------
    // [TestMethod]
    // public void Card_ShouldHandle_MissingOptionalFields()
    // {
    //     const string testName = "Test Card";
    //     const string testId = "f3a3a218-4cbe-4ab0-91f5-04133ea9e9bc";
    //     const string json = $@"{{ ""id"": ""{testId}"", ""name"": ""{testName}"" }}";

    //     var card = JsonSerializer.Deserialize<Models.Card>(json);

    //     Assert.IsNotNull(card);
    //     Assert.AreEqual(testId, card!.Id.ToString());
    //     Assert.AreEqual(testName, card.Name);
    //     Assert.IsNull(card.Prices);
    //     Assert.IsNull(card.ImageUris);
    // }

    // ------------------------------------------------------------
    // NULL FIELDS
    // ------------------------------------------------------------
    // [TestMethod]
    // public void Card_ShouldHandle_NullFields()
    // {
    //     var json = """
    //         {
    //             "object": "card",
    //             "id": "33ea0b6a-c0f1-49f8-bbd1-fed61ef0c0f3",
    //             "name": "Wild Dogs",
    //             "lang": "en",
    //             "released_at": "2023-01-13",
    //             "uri": "https://api.scryfall.com/cards/33ea0b6a-c0f1-49f8-bbd1-fed61ef0c0f3",
    //             "scryfall_uri": "https://scryfall.com/card/dmr/351/wild-dogs?utm_source=api",
    //             "layout": "normal",
    //             "highres_image": true,
    //             "image_status": "highres_scan",
    //             "image_uris": {
    //                 "small": "https://cards.scryfall.io/small/front/3/3/33ea0b6a-c0f1-49f8-bbd1-fed61ef0c0f3.jpg?1675202151",
    //                 "normal": "https://cards.scryfall.io/normal/front/3/3/33ea0b6a-c0f1-49f8-bbd1-fed61ef0c0f3.jpg?1675202151",
    //                 "large": "https://cards.scryfall.io/large/front/3/3/33ea0b6a-c0f1-49f8-bbd1-fed61ef0c0f3.jpg?1675202151",
    //                 "png": "https://cards.scryfall.io/png/front/3/3/33ea0b6a-c0f1-49f8-bbd1-fed61ef0c0f3.png?1675202151",
    //                 "art_crop": "https://cards.scryfall.io/art_crop/front/3/3/33ea0b6a-c0f1-49f8-bbd1-fed61ef0c0f3.jpg?1675202151",
    //                 "border_crop": "https://cards.scryfall.io/border_crop/front/3/3/33ea0b6a-c0f1-49f8-bbd1-fed61ef0c0f3.jpg?1675202151"
    //             },
    //             "mana_cost": "{G}",
    //             "cmc": 1,
    //             "type_line": "Creature — Dog",
    //             "oracle_text": "At the beginning of your upkeep, if a player has more life than each other player, the player with the most life gains control of this creature.\nCycling {2} ({2}, Discard this card: Draw a card.)",
    //             "power": "2",
    //             "toughness": "1",
    //             "color_identity": [
    //                 "G"
    //             ],
    //             "keywords": [
    //                 "Cycling"
    //             ],
    //             "legalities": {
    //                 "standard": "not_legal",
    //                 "future": "not_legal",
    //                 "historic": "not_legal",
    //                 "timeless": "not_legal",
    //                 "gladiator": "not_legal",
    //                 "pioneer": "not_legal",
    //                 "modern": "not_legal",
    //                 "legacy": "legal",
    //                 "pauper": "legal",
    //                 "vintage": "legal",
    //                 "penny": "not_legal",
    //                 "commander": "legal",
    //                 "oathbreaker": "legal",
    //                 "standardbrawl": "not_legal",
    //                 "brawl": "not_legal",
    //                 "alchemy": "not_legal",
    //                 "paupercommander": "legal",
    //                 "duel": "legal",
    //                 "oldschool": "not_legal",
    //                 "premodern": "legal",
    //                 "predh": "legal"
    //             },
    //             "games": [
    //                 "paper",
    //                 "mtgo"
    //             ],
    //             "reserved": false,
    //             "game_changer": false,
    //             "foil": true,
    //             "nonfoil": true,
    //             "finishes": [
    //                 "nonfoil",
    //                 "foil"
    //             ],
    //             "oversized": false,
    //             "promo": false,
    //             "reprint": true,
    //             "variation": false,
    //             "set_id": "ca4c2884-e539-4b7f-980d-5d6a50220f2a",
    //             "set": "dmr",
    //             "set_name": "Dominaria Remastered",
    //             "set_type": "masters",
    //             "set_uri": "https://api.scryfall.com/sets/ca4c2884-e539-4b7f-980d-5d6a50220f2a",
    //             "set_search_uri": "https://api.scryfall.com/cards/search?order=set&q=e%3Admr&unique=prints",
    //             "scryfall_set_uri": "https://scryfall.com/sets/dmr?utm_source=api",
    //             "rulings_uri": "https://api.scryfall.com/cards/33ea0b6a-c0f1-49f8-bbd1-fed61ef0c0f3/rulings",
    //             "prints_search_uri": "https://api.scryfall.com/cards/search?order=released&q=oracleid%3A711cda97-bf57-4b22-b9c1-854ef448d27a&unique=prints",
    //             "collector_number": "351",
    //             "digital": false,
    //             "rarity": "common",
    //             "card_back_id": "0aeebaf5-8c7d-4636-9e82-8c27447861f7",
    //             "artist": "Randy Vargas",
    //             "artist_ids": [
    //                 "d20672ca-0555-4238-a984-fd171d36b247"
    //             ],
    //             "illustration_id": "69cda361-c50d-4ac8-a48a-f1c76de24af9",
    //             "border_color": "black",
    //             "frame": "1997",
    //             "full_art": false,
    //             "textless": false,
    //             "booster": false,
    //             "story_spotlight": false,
    //             "promo_types": [
    //                 "boosterfun"
    //             ],
    //             "prices": {
    //                 "usd": "0.10",
    //                 "usd_foil": "0.17",
    //                 "usd_etched": null,
    //                 "eur": "0.11",
    //                 "eur_foil": "0.17",
    //                 "tix": "0.04"
    //             },
    //             "related_uris": {
    //                 "gatherer": "https://gatherer.wizards.com/Pages/Card/Details.aspx?multiverseid=601420&printed=false",
    //                 "tcgplayer_infinite_articles": "https://partner.tcgplayer.com/c/4931599/1830156/21018?subId1=api&trafcat=tcgplayer.com%2Fsearch%2Farticles&u=https%3A%2F%2Fwww.tcgplayer.com%2Fsearch%2Farticles%3FproductLineName%3Dmagic%26q%3DWild%2BDogs",
    //                 "tcgplayer_infinite_decks": "https://partner.tcgplayer.com/c/4931599/1830156/21018?subId1=api&trafcat=tcgplayer.com%2Fsearch%2Fdecks&u=https%3A%2F%2Fwww.tcgplayer.com%2Fsearch%2Fdecks%3FproductLineName%3Dmagic%26q%3DWild%2BDogs",
    //                 "edhrec": "https://edhrec.com/route/?cc=Wild+Dogs"
    //             },
    //             "purchase_uris": {
    //                 "tcgplayer": "https://partner.tcgplayer.com/c/4931599/1830156/21018?subId1=api&u=https%3A%2F%2Fwww.tcgplayer.com%2Fproduct%2F463000%3Fpage%3D1",
    //                 "cardmarket": "https://www.cardmarket.com/en/Magic/Products?idProduct=688867&referrer=scryfall&utm_campaign=card_prices&utm_medium=text&utm_source=scryfall",
    //                 "cardhoarder": "https://www.cardhoarder.com/cards/107387?affiliate_id=scryfall&ref=card-profile&utm_campaign=affiliate&utm_medium=card&utm_source=scryfall"
    //             }
    //         }
    //         """;

    //     var card = JsonSerializer.Deserialize<Models.Card>(json);

    //     Assert.IsNotNull(card);
    //     Assert.IsNull(card!.Prices);
    //     Assert.IsNull(card.ImageUris);
    // }

    // ------------------------------------------------------------
    // DEEP VALIDATION
    // ------------------------------------------------------------
    // [TestMethod]
    // public void Card_ShouldDeserialize_AllMajorFields()
    // {
    //     var card = JsonSerializer.Deserialize<Models.Card>(_json);

    //     Assert.IsNotNull(card);

    //     Assert.AreEqual("Creature — Wall", card!.TypeLine);
    //     Assert.AreEqual("{1}{U}{U}", card.ManaCost);
    //     Assert.AreEqual("1", card.Power);
    //     Assert.AreEqual("5", card.Toughness);
    //     Assert.AreEqual("uncommon", card.Rarity);
    //     Assert.AreEqual("10e", card.Set);
    //     Assert.AreEqual("124", card.CollectorNumber);
    //     Assert.IsFalse(card.Digital);
    // }
}