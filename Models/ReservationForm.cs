using System.ComponentModel.DataAnnotations;
namespace Amara.Models;

public sealed class ReservationForm : IValidatableObject
{
    [Required(ErrorMessage = "Enter the lead guest's full name.")]
    [StringLength(80, ErrorMessage = "Keep the name within 80 characters.")]
    public string GuestName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Enter a contact email.")]
    [EmailAddress(ErrorMessage = "Enter a valid email address.")]
    [StringLength(120)]
    public string Email { get; set; } = string.Empty;
    [Required(ErrorMessage = "Enter a contact phone number.")]
    [Phone(ErrorMessage = "Enter a valid phone number, including the country code if needed.")]
    [StringLength(30)]
    public string Phone { get; set; } = string.Empty;
    [StringLength(500, ErrorMessage = "Keep special requests within 500 characters.")]
    public string SpecialRequests { get; set; } = string.Empty;
    public DateOnly CheckIn { get; set; }
    public DateOnly CheckOut { get; set; }
    [Range(1, 6, ErrorMessage = "Choose between 1 and 6 guests.")]
    public int Guests { get; set; } = 2;
    public int Nights => CheckOut.DayNumber - CheckIn.DayNumber;
    public IEnumerable<ValidationResult> Validate(ValidationContext context)
    {
        if (CheckIn < DateOnly.FromDateTime(DateTime.Today))
            yield return new("Check-in cannot be in the past.", [nameof(CheckIn)]);
        if (CheckOut <= CheckIn)
            yield return new("Check-out must be after check-in.", [nameof(CheckOut)]);
    }
}