namespace Amara.Models;
public enum ReservationStatus { Confirmed, Cancelled }

// Store an immutable snapshot of the quoted price and guest details.
public sealed record Reservation(string Reference, int RoomId, string RoomName,
    string GuestName, string Email, string Phone, string SpecialRequests,
    DateOnly CheckIn, DateOnly CheckOut, int Guests, decimal NightlyRate,
    decimal Total, DateTimeOffset CreatedAt, ReservationStatus Status = ReservationStatus.Confirmed)
{
    public int Nights => CheckOut.DayNumber - CheckIn.DayNumber;
}