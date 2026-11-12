namespace Application.DTOs.Authors;

public class CreateAuthorDto
{
    public string Fullname { get; set; } = null!;
    public string Country { get; set; } = null!;
    public int BirthYear { get; set; }
}