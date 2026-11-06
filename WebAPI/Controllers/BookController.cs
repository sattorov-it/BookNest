using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController(IBookService bookService) : ControllerBase
{
    private IBookService service = bookService;

    [HttpGet]
    public async Task<ApiResponse<List<Book>>> GetBooks()
    {
        return await service.GetBooksAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Book>> GetBook(int id)
    {
        return await service.GetBookAsync(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddBook(Book book)
    {
        return await service.AddBookAsync(book);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteBook(int id)
    {
        return await service.DeleteBookAsync(id);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateBook(Book book)
    {
        return await service.UpdateBookAsync(book);
    }

    [HttpGet("amount")]
    public async Task<ApiResponse<int>> GetBookAmount()
    {
        return await service.GetBookAmountAsync();
    }

    [HttpGet("min-year-by-author/{authorId:int}")]
    public async Task<ApiResponse<int>> GetMinPublishedYearByAuthor(int authorId)
    {
        return await service.GetMinPublishedYearByAuthorAsync(authorId);
    }

    [HttpGet("max-year-by-author/{authorId:int}")]
    public async Task<ApiResponse<int>> GetMaxPublishedYearByAuthor(int authorId)
    {
        return await service.GetMaxPublishedYearByAuthorAsync(authorId);
    }

    [HttpGet("min-year-by-genre/{genreId:int}")]
    public async Task<ApiResponse<int>> GetMinPublishedYearByGenre(int genreId)
    {
        return await service.GetMinPublishedYearByGenreAsync(genreId);
    }

    [HttpGet("max-year-by-genre/{genreId:int}")]
    public async Task<ApiResponse<int>> GetMaxPublishedYearByGenre(int genreId)
    {
        return await service.GetMaxPublishedYearByGenreAsync(genreId);
    }

    [HttpGet("amount-by-year/{year:int}")]
    public async Task<ApiResponse<int>> GetAmountByPublishedYear(int year)
    {
        return await service.GetAmountByPublishedYearAsync(year);
    }

    [HttpGet("amount-by-genre/{genreId:int}")]
    public async Task<ApiResponse<int>> GetAmountByGenre(int genreId)
    {
        return await service.GetAmountByGenreAsync(genreId);
    }
}