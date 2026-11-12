namespace Application.DTOs.Books;

public class CreateBookDto
{
    public string Title { get; set; } = null!;
    public int PublishedYear { get; set; }
    public int TotalCopies { get; set; } = 1;
    public int AuthorId { get; set; }
    public int GenreId { get; set; }
}