using System.Globalization;
using Amara.Models;

namespace Amara.Services;

public sealed class BookingState
{
    public IReadOnlyList<Room> Rooms { get; } = Array.AsReadOnly<Room>([
        new(1, "Garden Room", RoomType.Standard, 2, 120m, "Queen bed", 28,
            "A compact room for two, with a reading corner and a private garden-facing patio.",
            "images/room-garden.jpg", "A bright bedroom with a bed beside a window",
            ["Wi-Fi", "Air conditioning", "Garden patio", "Tea & coffee"]),
        new(2, "Courtyard Twin", RoomType.Standard, 2, 135m, "Twin beds", 32,
            "Separate beds and a shared sitting area make this an easy base for traveling together.",
            "images/room-twin.jpg", "An illustrative hotel bedroom with light bedding",
            ["Wi-Fi", "Air conditioning", "Sitting area", "Tea & coffee"]),
        new(3, "Terrace Deluxe", RoomType.Deluxe, 3, 185m, "King bed + daybed", 42,
            "A little more space, with a daybed for a third guest and a terrace for open-air mornings.",
            "images/room-terrace.jpg", "An illustrative spacious bedroom with a large bed",
            ["Wi-Fi", "Air conditioning", "Private terrace", "Daybed"]),
        new(4, "Family Deluxe", RoomType.Deluxe, 4, 220m, "Two queen beds", 48,
            "Room for four, with space to unpack and a dining nook for a quiet evening together.",
            "images/room-family.jpg", "An illustrative warm hotel bedroom interior",
            ["Wi-Fi", "Air conditioning", "Dining nook", "Mini fridge"]),
        new(5, "Palm Suite", RoomType.Suite, 4, 290m, "King bed + sofa bed", 64,
            "A separate lounge gives early risers and late sleepers a little space of their own.",
            "images/room-suite.jpg", "An illustrative furnished hotel suite interior",
            ["Wi-Fi", "Air conditioning", "Separate lounge", "Balcony"]),
        new(6, "Gathering Suite", RoomType.Suite, 6, 340m, "Two bedrooms", 86,
            "Two bedrooms and a shared lounge for a larger family or a small group of friends.",
            "images/room-group.jpg", "An illustrative bedroom in a spacious hotel interior",
            ["Wi-Fi", "Air conditioning", "Two bedrooms", "Shared lounge"])
    ]);

    // Illustrative existing stays make date-based availability observable.
    // Integrate actual in-memory reservations here in the reservation increment.
    private readonly List<RoomHold> _sampleHolds =
    [
        new(1, DateOnly.FromDateTime(DateTime.Today).AddDays(2), DateOnly.FromDateTime(DateTime.Today).AddDays(4)),
        new(4, DateOnly.FromDateTime(DateTime.Today).AddDays(5), DateOnly.FromDateTime(DateTime.Today).AddDays(7))
    ];

    public Room? FindRoom(int id) => Rooms.FirstOrDefault(room => room.Id == id);

    public bool IsAvailable(int roomId, DateOnly checkIn, DateOnly checkOut) =>
        FindRoom(roomId) is not null && checkOut > checkIn &&
        !_sampleHolds.Any(stay => stay.RoomId == roomId &&
            checkIn < stay.CheckOut && checkOut > stay.CheckIn);

    public static string Money(decimal amount) => $"USD {amount.ToString("N2", CultureInfo.InvariantCulture)}";

    private sealed record RoomHold(int RoomId, DateOnly CheckIn, DateOnly CheckOut);
}