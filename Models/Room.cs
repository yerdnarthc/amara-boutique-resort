namespace Amara.Models;

public enum RoomType { Standard, Deluxe, Suite }

// Each entry represents one reservable inventory unit, not a pool of rooms.
public sealed record Room(int Id, string Name, RoomType Type, int Capacity,
    decimal NightlyRate, string Bed, int Size, string Description,
    string ImagePath, string ImageAlt, IReadOnlyList<string> Amenities);