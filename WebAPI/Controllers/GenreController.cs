using Application.Interfeces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenreController(IGenreService genreService) : ControllerBase
{
    [HttpGet]
    public async Task<ApiResponse<List<Genre>>> GetGenresAsync()
    {
        return await service.GetGenresAsync();
    }
    private IGenreService service = genreService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddGenreAsync(Genre genre)
    {
        return await service.AddGenreAsync(genre);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateGenreAsync(Genre genre)
    {
        return await service.UpdateGenreAsync(genre);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteGenreAsync(int id)
    {
        return await service.DeleteGenreAsync(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Genre>> GetGenreAsync(int id)
    {
        return await service.GetGenreAsync(id);
    }


    [HttpGet("amount")]
    public async Task<ApiResponse<int>> GetGenresAmountAsync()
    {
        return await service.GetGenresAmountAsync();
    }
}