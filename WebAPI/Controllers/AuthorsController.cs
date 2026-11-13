using Application.DTOs.Authors;
using Application.Interfaces;
using Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController(IAuthorService authorService) : ControllerBase
{
    private IAuthorService service = authorService;

    [HttpGet]
    public async Task<ApiResponse<List<GetAuthorDto>>> GetAuthors()
    {
        return await service.GetAuthorsAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<GetAuthorDto>> GetAuthor(int id)
    {
        return await service.GetAuthorAsync(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddAuthor(CreateAuthorDto dto)
    {
        return await service.AddAuthorAsync(dto);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateAuthor(UpdateAuthorDto dto)
    {
        return await service.UpdateAuthorAsync(dto);
    }

    [HttpDelete]
    public async Task<ApiResponse<bool>> DeleteAuthor(int id)
    {
        return await service.DeleteAuthorAsync(id);
    }

    [HttpGet("amount")]
    public async Task<ApiResponse<int>> GetAuthorsAmount()
    {
        return await service.GetAuthorsAmountAsync();
    }
}