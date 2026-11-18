using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BookRepository(ApplicationDbContext appDbContext) : IBookRepository
{
    private readonly ApplicationDbContext _context = appDbContext;

    public async Task<bool> AddBookAsync(Book book)
    {
        _context.Books.Add(book);
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> DeleteBookAsync(int id)
    {
        var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
        if (book != null)
        {
            _context.Books.Remove(book);
        }
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<bool> UpdateBookAsync(Book book)
    {
        var b = await _context.Books.FirstOrDefaultAsync(x => x.Id == book.Id);
        if (b != null)
        {
            b.Title = book.Title;
            b.PublishedYear = book.PublishedYear;
            b.TotalCopies = book.TotalCopies;
        }
        var res = await _context.SaveChangesAsync();
        return res > 0;
    }

    public async Task<Book> GetBookAsync(int id)
    {
        var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
        return book ?? new();
    }

    public async Task<List<Book>> GetBooksAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task<int> GetBookAmountAsync()
    {
        return await _context.Books.CountAsync();
    }

    public async Task<int> GetMinPublishedYearByAuthorAsync(int authorId)
    {
        return await _context.Books.Where(x => x.AuthorId == authorId).MinAsync(x => (int?)x.PublishedYear) ?? 0;
    }

    public async Task<int> GetMaxPublishedYearByAuthorAsync(int authorId)
    {
        return await _context.Books.Where(x => x.AuthorId == authorId).MaxAsync(x => (int?)x.PublishedYear) ?? 0;
    }

    public async Task<int> GetMinPublishedYearByGenreAsync(int genreId)
    {
        return await _context.Books.Where(x => x.GenreId == genreId).MinAsync(x => (int?)x.PublishedYear) ?? 0;
    }

    public async Task<int> GetMaxPublishedYearByGenreAsync(int genreId)
    {
        return await _context.Books.Where(x => x.GenreId == genreId).MaxAsync(x => (int?)x.PublishedYear) ?? 0;
    }

    public async Task<int> GetAmountByPublishedYearAsync(int year)
    {
        return await _context.Books.CountAsync(x => x.PublishedYear == year);
    }

    public async Task<int> GetAmountByGenreAsync(int genreId)
    {
        return await _context.Books.CountAsync(x => x.GenreId == genreId);
    }
}