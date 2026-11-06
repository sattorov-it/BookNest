using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class AuthorRepository(AppDbContext appDbContext) : IAuthorRepository
{
    private AppDbContext context = appDbContext;
    public async Task<bool> AddAuthorAsync(Author author)
    {
        var connection = context.Connection();
        var query = "insert into authors (fullname, country, birthyear) values (@fullname, @country, @birthyear)";
        var res = await connection.ExecuteAsync(query, author);
        return res > 0;
    }

    public async Task<bool> DeleteAuthorAsync(int id)
    {
        var connection = context.Connection();
        var query = $"delete from authors where id = @id";
        var res = await connection.ExecuteAsync(query, new { id });
        return res > 0;
    }

    public async Task<bool> UpdateAuthorAsync(Author author)
    {
        var connection = Database.Connection();
        var query = $"update authors set fullname = @fullname, country = @country, birthyear = @birthyear where id = @id";
        var res = await connection.ExecuteAsync(query, author);
        return res > 0;
    }
    public async Task<Author> GetAuthorAsync(int id)
    {
        var connection = context.Connection();
        var query = $"select * from authors where id = @id";
        var res = await connection.QuerySingleOrDefaultAsync<Author>(query, new { id });
        return res!;
    }

    public async Task<List<Author>> GetAuthorsAsync()
    {
        var connection = context.Connection();
        var query = $"select * from authors";
        var res = await connection.QueryAsync<Author>(query);
        return res.ToList();
    }

    public async Task<int> GetAuthorsAmountAsync()
    {
        var connection = Database.Connection();
        var query = "select count(*) from authors";
        return await connection.ExecuteScalarAsync<int>(query);
    }
}