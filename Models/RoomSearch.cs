using System.ComponentModel.DataAnnotations;

namespace Amara.Models;

public sealed class RoomSearch : IValidatableObject
{
    public DateOnly CheckIn { get; set; } = DateOnly.FromDateTime(DateTime.Today).AddDays(1);
    public DateOnly CheckOut { get; set; } = DateOnly.FromDateTime(DateTime.Today).AddDays(3);
    [Range(1, 6, ErrorMessage = "Choose between 1 and 6 guests.")]
    public int Guests { get; set; } = 2;
    public RoomType? Type { get; set; }
    public string Search { get; set; } = string.Empty;
    public bool AvailableOnly { get; set; }
    public int Nights => CheckOut.DayNumber - CheckIn.DayNumber;
    public RoomSearch Copy() => (RoomSearch)MemberwiseClone();

    public IEnumerable<ValidationResult> Validate(ValidationContext context)
    {
        if (CheckIn < DateOnly.FromDateTime(DateTime.Today))
            yield return new("Check-in cannot be in the past.", [nameof(CheckIn)]);
        if (CheckOut <= CheckIn)
            yield return new("Check-out must be after check-in.", [nameof(CheckOut)]);
    }
}