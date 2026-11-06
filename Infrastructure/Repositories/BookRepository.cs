using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class BookRepository(AppDbContext appDbContext) : IBookRepository
{
    private AppDbContext context = appDbContext;
    public async Task<bool> AddBookAsync(Book book)
    {
        using var connection = context.Connection();
        // await connection.OpenAsync();
        var query = "insert into books (title, publishedyear, totalcopies, authorid, genreid) values (@title, @publishedyear, @totalcopies, @authorid, @genreid)";
        var res = await connection.ExecuteAsync(query, book);
        return res > 0;

    }

    public async Task<bool> DeleteBookAsync(int id)
    {
        using var connection = context.Connection();
        // await connection.OpenAsync();
        var query = "delete from books where id=@id";
        var res = await connection.ExecuteAsync(query, new { id });
        return res > 0;
    }

    public async Task<bool> UpdateBookAsync(Book book)
    {
        using var connection = context.Connection();
        // await connection.OpenAsync();
        var query = "update books set title=@title, publishedyear=@publishedyear, totalcopies=@totalcopies where id=@id";
        var res = await connection.ExecuteAsync(query, book);
        return res > 0;
    }
    public async Task<Book> GetBookAsync(int id)
    {
        using var connection = context.Connection();
        // await connection.OpenAsync();
        var query = "select * from books where id=@id";
        var book = await connection.QuerySingleAsync<Book>(query, new { id });
        return book;
    }

    public async Task<List<Book>> GetBooksAsync()
    {
        using var connection = context.Connection();
        // await connection.OpenAsync();
        var books = await connection.QueryAsync<Book>("select * from books");
        return books.ToList();
    }


    public async Task<int> GetBookAmountAsync()
    {
        using var connection = context.Connection();
        // await connection.OpenAsync();
        var query = "select count(*) from books";
        return await connection.ExecuteScalarAsync<int>(query);
    }

    public async Task<int> GetMinPublishedYearByAuthorAsync(int authorId)
    {
        using var connection = context.Connection();
        // await connection.OpenAsync();
        var query = "select min(publishedyear) from books where authorid=@authorId";
        return await connection.ExecuteScalarAsync<int>(query, new { authorId });
    }

    public async Task<int> GetMaxPublishedYearByAuthorAsync(int authorId)
    {
        using var connection = context.Connection();
        // await connection.OpenAsync();
        var query = "select max(publishedyear) from books where authorid=@authorId";
        return await connection.ExecuteScalarAsync<int>(query, new { authorId });
    }

    public async Task<int> GetMinPublishedYearByGenreAsync(int genreId)
    {
        using var connection = context.Connection();
        // await connection.OpenAsync();
        var query = "select min(publishedyear) from books where genreid=@genreId";
        return await connection.ExecuteScalarAsync<int>(query, new { genreId });
    }

    public async Task<int> GetMaxPublishedYearByGenreAsync(int genreId)
    {
        using var connection = context.Connection();
        // await connection.OpenAsync();
        var query = "select max(publishedyear) from books where genreid=@genreId";
        return await connection.ExecuteScalarAsync<int>(query, new { genreId });
    }

    public async Task<int> GetAmountByPublishedYearAsync(int year)
    {
        using var connection = context.Connection();
        // await connection.OpenAsync();
        var query = "select count(*) from books where publishedyear=@year";
        return await connection.ExecuteScalarAsync<int>(query, new { year });
    }

    public async Task<int> GetAmountByGenreAsync(int genreId)
    {
        using var connection = context.Connection();
        // await connection.OpenAsync();
        var query = "select count(*) from books where genreid=@genreId";
        return await connection.ExecuteScalarAsync<int>(query, new { genreId });
    }
}