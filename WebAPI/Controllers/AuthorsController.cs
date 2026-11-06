using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController(IAuthorService authorService) : ControllerBase
{
    private IAuthorService service = authorService;

    [HttpGet]
    public async Task<ApiResponse<List<Author>>> GetAuthors()
    {
        return await service.GetAuthorsAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<Author>> GetAuthor(int id)
    {
        return await service.GetAuthorAsync(id);
    }

    [HttpPost]
    public async Task<ApiResponse<bool>> AddAuthor(Author author)
    {
        return await service.AddAuthorAsync(author);
    }

    [HttpPut]
    public async Task<ApiResponse<bool>> UpdateAuthor(Author author)
    {
        return await service.UpdateAuthorAsync(author);
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