using Application.DTOs.Genres;
using Application.Interfeces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenreController(IGenreService genreService) : ControllerBase
{
    private IGenreService service = genreService;

    [HttpGet]
    public async Task<ApiResponse<List<GetGenreDto>>> GetGenresAsync()
    {
        return await service.GetGenresAsync();
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddGenreAsync(CreateGenreDto dto)
    {
        return await service.AddGenreAsync(dto);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateGenreAsync(UpdateGenreDto dto)
    {
        return await service.UpdateGenreAsync(dto);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteGenreAsync(int id)
    {
        return await service.DeleteGenreAsync(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<GetGenreDto>> GetGenreAsync(int id)
    {
        return await service.GetGenreAsync(id);
    }

    [HttpGet("amount")]
    public async Task<ApiResponse<int>> GetGenresAmountAsync()
    {
        return await service.GetGenresAmountAsync();
    }
}