using System.Net;
using Application.Interfaces;
using Application.Interfeces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;
namespace Application.Services;

public class GenreService(IGenreRepository genreRepository) : IGenreService
{
    private IGenreRepository repository = genreRepository;
    public async Task<ApiResponse<bool>> AddGenreAsync(Genre genre)
    {
        var res = await repository.AddGenreAsync(genre);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not added.", res);
    }

    public async Task<ApiResponse<bool>> UpdateGenreAsync(Genre genre)
    {
        var res = await repository.UpdateGenreAsync(genre);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updeted", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not updeted", res);
    }
    public async Task<ApiResponse<bool>> DeleteGenreAsync(int id)
    {
        var res = await repository.DeleteGenreAsync(id);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not deleted.", res);
    }

    public async Task<ApiResponse<Genre>> GetGenreAsync(int id)
    {
        var res = await repository.GetGenreAsync(id);
        return res != null
        ? new ApiResponse<Genre>(HttpStatusCode.OK, "Genre with given id.", res)
        : new ApiResponse<Genre>(HttpStatusCode.NotFound, "No genre with given id.", res!);
    }


    public async Task<ApiResponse<List<Genre>>> GetGenresAsync()
    {
        var res = await repository.GetGenresAsync();
        return new ApiResponse<List<Genre>>(HttpStatusCode.OK, "List of genres.", res);
    }
    public async Task<ApiResponse<int>> GetGenresAmountAsync()
    {
        var res = await repository.GetGenresAmountAsync();
        return new ApiResponse<int>(HttpStatusCode.OK, "Amount of genres.", res);
    }
}
