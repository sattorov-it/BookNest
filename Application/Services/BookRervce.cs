using System.Net;
using Application.DTOs.Books;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class BookService(IBookRepository bookRepository) : IBookService
{
    private IBookRepository repository = bookRepository;

    public async Task<ApiResponse<bool>> AddBookAsync(CreateBookDto dto)
    {
        var book = new Book()
        {
            Title = dto.Title,
            PublishedYear = dto.PublishedYear,
            TotalCopies = dto.TotalCopies,
            AuthorId = dto.AuthorId,
            GenreId = dto.GenreId
        };
        var res = await repository.AddBookAsync(book);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not added.", res);
    }

    public async Task<ApiResponse<bool>> DeleteBookAsync(int id)
    {
        var res = await repository.DeleteBookAsync(id);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not deleted.", res);
    }

    public async Task<ApiResponse<GetBookDto>> GetBookAsync(int id)
    {
        var res = await repository.GetBookAsync(id);
        return res != null
        ? new ApiResponse<GetBookDto>(HttpStatusCode.OK, "Book with given id.", new GetBookDto()
        {
            Id = res.Id,
            Title = res.Title,
            PublishedYear = res.PublishedYear,
            TotalCopies = res.TotalCopies,
            AuthorId = res.AuthorId,
            GenreId = res.GenreId
        })
        : new ApiResponse<GetBookDto>(HttpStatusCode.NotFound, "No book with given id.");
    }

    public async Task<ApiResponse<List<GetBookDto>>> GetBooksAsync()
    {
        var books = await repository.GetBooksAsync();
        var res = books.Select(v => new GetBookDto()
        {
            Id = v.Id,
            Title = v.Title,
            PublishedYear = v.PublishedYear,
            TotalCopies = v.TotalCopies,
            AuthorId = v.AuthorId,
            GenreId = v.GenreId
        }).ToList();
        return new ApiResponse<List<GetBookDto>>(HttpStatusCode.OK, "List of books.", res);
    }

    public async Task<ApiResponse<bool>> UpdateBookAsync(UpdateBookDto dto)
    {
        var book = new Book()
        {
            Id = dto.Id,
            Title = dto.Title,
            PublishedYear = dto.PublishedYear,
            TotalCopies = dto.TotalCopies,
            AuthorId = dto.AuthorId,
            GenreId = dto.GenreId
        };
        var res = await repository.UpdateBookAsync(book);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not updated.", res);
    }

    public async Task<ApiResponse<int>> GetBookAmountAsync()
    {
        var res = await repository.GetBookAmountAsync();
        return new ApiResponse<int>(HttpStatusCode.OK, "Amount of books.", res);
    }

    public async Task<ApiResponse<int>> GetMinPublishedYearByAuthorAsync(int authorId)
    {
        var res = await repository.GetMinPublishedYearByAuthorAsync(authorId);
        return new ApiResponse<int>(HttpStatusCode.OK, "Min published year by author.", res);
    }

    public async Task<ApiResponse<int>> GetMaxPublishedYearByAuthorAsync(int authorId)
    {
        var res = await repository.GetMaxPublishedYearByAuthorAsync(authorId);
        return new ApiResponse<int>(HttpStatusCode.OK, "Max published year by author.", res);
    }

    public async Task<ApiResponse<int>> GetMinPublishedYearByGenreAsync(int genreId)
    {
        var res = await repository.GetMinPublishedYearByGenreAsync(genreId);
        return new ApiResponse<int>(HttpStatusCode.OK, "Min published year by genre.", res);
    }

    public async Task<ApiResponse<int>> GetMaxPublishedYearByGenreAsync(int genreId)
    {
        var res = await repository.GetMaxPublishedYearByGenreAsync(genreId);
        return new ApiResponse<int>(HttpStatusCode.OK, "Max published year by genre.", res);
    }

    public async Task<ApiResponse<int>> GetAmountByPublishedYearAsync(int year)
    {
        var res = await repository.GetAmountByPublishedYearAsync(year);
        return new ApiResponse<int>(HttpStatusCode.OK, "Amount of books by published year.", res);
    }

    public async Task<ApiResponse<int>> GetAmountByGenreAsync(int genreId)
    {
        var res = await repository.GetAmountByGenreAsync(genreId);
        return new ApiResponse<int>(HttpStatusCode.OK, "Amount of books by genre.", res);
    }
}