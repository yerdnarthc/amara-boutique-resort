namespace Amara.Models;

public enum ExperienceCategory { Culture, Nature, Adventure }

public sealed record Experience(int Id, string Title, ExperienceCategory Category, string Duration,
    string Description, IReadOnlyList<string> Itinerary, IReadOnlyList<string> Inclusions,
    string Preparation, string Icon);
