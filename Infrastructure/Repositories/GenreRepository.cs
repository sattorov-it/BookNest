using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class GenreRepository(AppDbContext appDbContext) : IGenreRepository
{
    private AppDbContext context = appDbContext;
    public async Task<bool> AddGenreAsync(Genre genre)
    {
        var connection = context.Connection();
        var query = "insert into genres (name) values (@name)";
        var res = await connection.ExecuteAsync(query, genre);
        return res > 0;
    }

    public async Task<bool> DeleteGenreAsync(int id)
    {
        var connection = context.Connection();
        var query = "delete from genres where id=@id";
        var res = await connection.ExecuteAsync(query, new { id });
        return res > 0;
    }

    public async Task<bool> UpdateGenreAsync(Genre genre)
    {
        var connection = context.Connection();
        var query = "update genres set name = @name where id=@id";
        var res = await connection.ExecuteAsync(query, genre);
        return res > 0;
    }
    public async Task<Genre> GetGenreAsync(int id)
    {
        var connection = context.Connection();
        var query = "select * from genres where id=@id";
        var genre = await connection.QuerySingleAsync<Genre>(query, new { id });
        return genre;
    }

    public async Task<List<Genre>> GetGenresAsync()
    {
        var connection = context.Connection();
        var query = "select * from genres";
        return (await connection.QueryAsync<Genre>(query)).ToList();
    }

    public async Task<int> GetGenresAmountAsync()
    {
        var connection = context.Connection();
        var query = "select count(*) from genres";
        return await connection.ExecuteScalarAsync<int>(query);
    }
}