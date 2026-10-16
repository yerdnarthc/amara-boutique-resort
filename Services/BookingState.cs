using System.Globalization;
using System.ComponentModel.DataAnnotations;
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

    // Illustrative holds remain separate from guest-created session reservations.
    private readonly List<RoomHold> _sampleHolds =
    [
        new(1, DateOnly.FromDateTime(DateTime.Today).AddDays(2), DateOnly.FromDateTime(DateTime.Today).AddDays(4)),
        new(4, DateOnly.FromDateTime(DateTime.Today).AddDays(5), DateOnly.FromDateTime(DateTime.Today).AddDays(7))
    ];
    private readonly object _reservationLock = new();
    private readonly List<Reservation> _reservations = [];
    private readonly Dictionary<Guid, Reservation> _submissions = [];
    public IReadOnlyList<Reservation> Reservations
    {
        get { lock (_reservationLock) return _reservations.ToArray(); }
    }
    public Reservation? FindReservation(string reference)
    {
        lock (_reservationLock) return _reservations.FirstOrDefault(item => item.Reference == reference);
    }
    public Room? FindRoom(int id) => Rooms.FirstOrDefault(room => room.Id == id);
    public bool IsAvailable(int roomId, DateOnly checkIn, DateOnly checkOut)
    {
        lock (_reservationLock)
            return FindRoom(roomId) is not null && checkOut > checkIn &&
                !_sampleHolds.Any(stay => stay.RoomId == roomId && checkIn < stay.CheckOut && checkOut > stay.CheckIn) &&
                !_reservations.Any(stay => stay.RoomId == roomId && stay.Status == ReservationStatus.Confirmed && checkIn < stay.CheckOut && checkOut > stay.CheckIn);
    }
    public bool TryReserve(Guid submissionId, int roomId, ReservationForm form, out Reservation? reservation, out string? error)
    {
        lock (_reservationLock)
        {
            reservation = null;
            error = null;
            // Idempotency: repeated events from one form return its original receipt.
            if (_submissions.TryGetValue(submissionId, out var previous))
            {
                reservation = _reservations.First(item => item.Reference == previous.Reference);
                return true;
            }
            var issues = new List<ValidationResult>();
            if (!Validator.TryValidateObject(form, new ValidationContext(form), issues, validateAllProperties: true))
            {
                error = issues.First().ErrorMessage ?? "Check your guest details and dates, then try again.";
                return false;
            }
            var room = FindRoom(roomId);
            if (room is null || form.Guests > room.Capacity)
            {
                error = "The selected room cannot accommodate this guest count. Choose another room or fewer guests.";
                return false;
            }
            // Availability recheck and insertion are atomic within this session.
            if (!IsAvailable(roomId, form.CheckIn, form.CheckOut))
            {
                error = "This room is no longer available for those dates. Change your dates or choose another room.";
                return false;
            }
            reservation = new Reservation("AMR-" + Guid.NewGuid().ToString("N")[..12].ToUpperInvariant(),
                room.Id, room.Name, form.GuestName.Trim(), form.Email.Trim(), form.Phone.Trim(), (form.SpecialRequests ?? string.Empty).Trim(),
                form.CheckIn, form.CheckOut, form.Guests, room.NightlyRate, room.NightlyRate * form.Nights, DateTimeOffset.UtcNow);
            _reservations.Add(reservation);
            _submissions.Add(submissionId, reservation);
            return true;
        }
    }
    public bool TryCancel(string reference, out string? error)
    {
        lock (_reservationLock)
        {
            error = null;
            var index = _reservations.FindIndex(item => item.Reference == reference);
            if (index < 0) { error = "That reservation is no longer in this session."; return false; }
            var current = _reservations[index];
            if (current.Status == ReservationStatus.Cancelled)
            {
                error = "This reservation is already cancelled. No further change was made.";
                return false;
            }
            // Retain the original quote and guest details; only confirmed stays block availability.
            _reservations[index] = current with { Status = ReservationStatus.Cancelled };
            return true;
        }
    }

    public static string Money(decimal amount) => $"USD {amount.ToString("N2", CultureInfo.InvariantCulture)}";
    private sealed record RoomHold(int RoomId, DateOnly CheckIn, DateOnly CheckOut);
}