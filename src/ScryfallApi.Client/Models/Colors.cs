namespace ScryfallApi.Client.Models;

[Flags]
public enum Colors
{
    None = 0,
    White = 1,
    Blue = 2,
    Black = 4,
    Red = 8,
    Green = 16,
    Colorless = 32,
    Tap = 64, // Only exists for one un-card (Sole Performer) which producess "tap" mana
}
