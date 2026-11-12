using Application.DTOs.Authors;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController(
    IAuthorService authorService,
    ILogger<AuthorsController> logger) : ControllerBase
{
    private IAuthorService service = authorService;
    private ILogger<AuthorsController> _logger = logger;

    [HttpGet]
    public async Task<ApiResponse<List<GetAuthorDto>>> GetAuthors()
    {
        _logger.LogInformation("GET api/Authors {date}", DateTime.Now);
        return await service.GetAuthorsAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<GetAuthorDto>> GetAuthor(int id)
    {
        _logger.LogInformation("GET api/Authors/{id} {date}", id, DateTime.Now);
        return await service.GetAuthorAsync(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddAuthor(CreateAuthorDto dto)
    {
        _logger.LogInformation("POST api/Authors {date}", DateTime.Now);
        return await service.AddAuthorAsync(dto);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateAuthor(UpdateAuthorDto dto)
    {
        _logger.LogInformation("PUT api/Authors {date}", DateTime.Now);
        return await service.UpdateAuthorAsync(dto);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteAuthor(int id)
    {
        _logger.LogInformation("DELETE api/Authors {id} {date}", id, DateTime.Now);
        return await service.DeleteAuthorAsync(id);
    }

    [HttpGet("amount")]
    public async Task<ApiResponse<int>> GetAuthorsAmount()
    {
        _logger.LogInformation("GET api/Authors/amount {date}", DateTime.Now);
        return await service.GetAuthorsAmountAsync();
    }
}