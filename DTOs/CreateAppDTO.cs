
namespace WebApplication2.DTOs;

public record class CreateAppDTO(
	string Name,
	string Genre,
	double Price,
	DateOnly ReleaseDate
);