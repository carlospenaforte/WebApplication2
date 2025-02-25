
namespace WebApplication2.DTOs;

public record class UpdateAppDTO(
    string Name,
    string Genre,
    double Price,
    DateOnly ReleaseDate
);
