using System.Net;
using Application.DTOs.Genres;
using Application.Interfeces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class GenreService(IGenreRepository genreRepository) : IGenreService
{
    private IGenreRepository repository = genreRepository;

    public async Task<ApiResponse<bool>> AddGenreAsync(CreateGenreDto dto)
    {
        var genre = new Genre()
        {
            Name = dto.Name
        };
        var res = await repository.AddGenreAsync(genre);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not added.", res);
    }

    public async Task<ApiResponse<bool>> UpdateGenreAsync(UpdateGenreDto dto)
    {
        var genre = new Genre()
        {
            Id = dto.Id,
            Name = dto.Name
        };
        var res = await repository.UpdateGenreAsync(genre);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not updated.", res);
    }

    public async Task<ApiResponse<bool>> DeleteGenreAsync(int id)
    {
        var res = await repository.DeleteGenreAsync(id);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not deleted.", res);
    }

    public async Task<ApiResponse<GetGenreDto>> GetGenreAsync(int id)
    {
        var res = await repository.GetGenreAsync(id);
        return res != null
        ? new ApiResponse<GetGenreDto>(HttpStatusCode.OK, "Genre with given id.", new GetGenreDto()
        {
            Id = res.Id,
            Name = res.Name
        })
        : new ApiResponse<GetGenreDto>(HttpStatusCode.NotFound, "No genre with given id.");
    }

    public async Task<ApiResponse<List<GetGenreDto>>> GetGenresAsync()
    {
        var genres = await repository.GetGenresAsync();
        var res = genres.Select(v => new GetGenreDto()
        {
            Id = v.Id,
            Name = v.Name
        }).ToList();
        return new ApiResponse<List<GetGenreDto>>(HttpStatusCode.OK, "List of genres.", res);
    }

    public async Task<ApiResponse<int>> GetGenresAmountAsync()
    {
        var res = await repository.GetGenresAmountAsync();
        return new ApiResponse<int>(HttpStatusCode.OK, "Amount of genres.", res);
    }
}