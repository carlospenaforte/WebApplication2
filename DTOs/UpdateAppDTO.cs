
namespace WebApplication2.DTOs;

public record class UpdateAppDTO(
    Id,
    string Name,
    string Genre,
    double Price,
    DateOnly ReleaseDate
);
