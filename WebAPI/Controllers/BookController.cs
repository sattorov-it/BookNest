using Application.DTOs.Books;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController(
    IBookService bookService,
    ILogger<BooksController> logger) : ControllerBase
{
    private IBookService service = bookService;
    private ILogger<BooksController> _logger = logger;

    [HttpGet]
    public async Task<ApiResponse<List<GetBookDto>>> GetBooks()
    {
        _logger.LogInformation("GET api/Books {date}", DateTime.Now);
        return await service.GetBooksAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<GetBookDto>> GetBook(int id)
    {
        _logger.LogInformation("GET api/Books/{id} {date}", id, DateTime.Now);
        return await service.GetBookAsync(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddBook(CreateBookDto dto)
    {
        _logger.LogInformation("POST api/Books {date}", DateTime.Now);
        return await service.AddBookAsync(dto);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteBook(int id)
    {
        _logger.LogInformation("DELETE api/Books {id} {date}", id, DateTime.Now);
        return await service.DeleteBookAsync(id);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateBook(UpdateBookDto dto)
    {
        _logger.LogInformation("PUT api/Books {date}", DateTime.Now);
        return await service.UpdateBookAsync(dto);
    }

    [HttpGet("amount")]
    public async Task<ApiResponse<int>> GetBookAmount()
    {
        _logger.LogInformation("GET api/Books/amount {date}", DateTime.Now);
        return await service.GetBookAmountAsync();
    }

    [HttpGet("min-year-by-author/{authorId:int}")]
    public async Task<ApiResponse<int>> GetMinPublishedYearByAuthor(int authorId)
    {
        _logger.LogInformation("GET api/Books/min-year-by-author/{authorId} {date}", authorId, DateTime.Now);
        return await service.GetMinPublishedYearByAuthorAsync(authorId);
    }

    [HttpGet("max-year-by-author/{authorId:int}")]
    public async Task<ApiResponse<int>> GetMaxPublishedYearByAuthor(int authorId)
    {
        _logger.LogInformation("GET api/Books/max-year-by-author/{authorId} {date}", authorId, DateTime.Now);
        return await service.GetMaxPublishedYearByAuthorAsync(authorId);
    }

    [HttpGet("min-year-by-genre/{genreId:int}")]
    public async Task<ApiResponse<int>> GetMinPublishedYearByGenre(int genreId)
    {
        _logger.LogInformation("GET api/Books/min-year-by-genre/{genreId} {date}", genreId, DateTime.Now);
        return await service.GetMinPublishedYearByGenreAsync(genreId);
    }

    [HttpGet("max-year-by-genre/{genreId:int}")]
    public async Task<ApiResponse<int>> GetMaxPublishedYearByGenre(int genreId)
    {
        _logger.LogInformation("GET api/Books/max-year-by-genre/{genreId} {date}", genreId, DateTime.Now);
        return await service.GetMaxPublishedYearByGenreAsync(genreId);
    }

    [HttpGet("amount-by-year/{year:int}")]
    public async Task<ApiResponse<int>> GetAmountByPublishedYear(int year)
    {
        _logger.LogInformation("GET api/Books/amount-by-year/{year} {date}", year, DateTime.Now);
        return await service.GetAmountByPublishedYearAsync(year);
    }

    [HttpGet("amount-by-genre/{genreId:int}")]
    public async Task<ApiResponse<int>> GetAmountByGenre(int genreId)
    {
        _logger.LogInformation("GET api/Books/amount-by-genre/{genreId} {date}", genreId, DateTime.Now);
        return await service.GetAmountByGenreAsync(genreId);
    }
}