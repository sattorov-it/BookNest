using Application.DTOs.Genres;
using Application.Interfeces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenreController(
    IGenreService genreService,
    ILogger<GenreController> logger) : ControllerBase
{
    private IGenreService service = genreService;
    private ILogger<GenreController> _logger = logger;

    [HttpGet]
    public async Task<ApiResponse<List<GetGenreDto>>> GetGenresAsync()
    {
        _logger.LogInformation("GET api/Genre {date}", DateTime.Now);
        return await service.GetGenresAsync();
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddGenreAsync(CreateGenreDto dto)
    {
        _logger.LogInformation("POST api/Genre {date}", DateTime.Now);
        return await service.AddGenreAsync(dto);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateGenreAsync(UpdateGenreDto dto)
    {
        _logger.LogInformation("PUT api/Genre {date}", DateTime.Now);
        return await service.UpdateGenreAsync(dto);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteGenreAsync(int id)
    {
        _logger.LogInformation("DELETE api/Genre {id} {date}", id, DateTime.Now);
        return await service.DeleteGenreAsync(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<GetGenreDto>> GetGenreAsync(int id)
    {
        _logger.LogInformation("GET api/Genre/{id} {date}", id, DateTime.Now);
        return await service.GetGenreAsync(id);
    }

    [HttpGet("amount")]
    public async Task<ApiResponse<int>> GetGenresAmountAsync()
    {
        _logger.LogInformation("GET api/Genre/amount {date}", DateTime.Now);
        return await service.GetGenresAmountAsync();
    }
}