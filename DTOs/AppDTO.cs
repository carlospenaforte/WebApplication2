
namespace WebApplication2.DTOs;

public record class AppDTO(
    int Id, 
    string Name, 
    string Genre, 
    decimal Price,
    DateOnly ReleaseDate);
