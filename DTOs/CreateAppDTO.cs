using System.ComponentModel.DataAnnotations;

namespace WebApplication2.DTOs;

public record class CreateAppDTO(
	[Required][StringLenght(50)] string Name,
    [Required][StringLenght(20)] string Genre,
	[Range(1, 100)] decimal Price,
	DateOnly ReleaseDate
);	