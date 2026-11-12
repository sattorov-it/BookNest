using System.Net;
using Application.DTOs.Authors;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class AuthorService(IAuthorRepository authorRepository) : IAuthorService
{
    private IAuthorRepository repository = authorRepository;

    public async Task<ApiResponse<bool>> AddAuthorAsync(CreateAuthorDto dto)
    {
        var author = new Author()
        {
            Fullname = dto.Fullname,
            Country = dto.Country,
            BirthYear = dto.BirthYear
        };
        var res = await repository.AddAuthorAsync(author);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not added.", res);
    }

    public async Task<ApiResponse<bool>> UpdateAuthorAsync(UpdateAuthorDto dto)
    {
        var author = new Author()
        {
            Id = dto.Id,
            Fullname = dto.Fullname,
            Country = dto.Country,
            BirthYear = dto.BirthYear
        };
        var res = await repository.UpdateAuthorAsync(author);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not updated.", res);
    }

    public async Task<ApiResponse<bool>> DeleteAuthorAsync(int id)
    {
        var res = await repository.DeleteAuthorAsync(id);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not deleted.", res);
    }

    public async Task<ApiResponse<GetAuthorDto>> GetAuthorAsync(int id)
    {
        var res = await repository.GetAuthorAsync(id);
        return res != null
        ? new ApiResponse<GetAuthorDto>(HttpStatusCode.OK, "Author with given id.", new GetAuthorDto()
        {
            Id = res.Id,
            Fullname = res.Fullname,
            Country = res.Country,
            BirthYear = res.BirthYear
        })
        : new ApiResponse<GetAuthorDto>(HttpStatusCode.NotFound, "No author with given id.");
    }

    public async Task<ApiResponse<List<GetAuthorDto>>> GetAuthorsAsync()
    {
        var authors = await repository.GetAuthorsAsync();
        var res = authors.Select(v => new GetAuthorDto()
        {
            Id = v.Id,
            Fullname = v.Fullname,
            Country = v.Country,
            BirthYear = v.BirthYear
        }).ToList();
        return new ApiResponse<List<GetAuthorDto>>(HttpStatusCode.OK, "List of authors.", res);
    }

    public async Task<ApiResponse<int>> GetAuthorsAmountAsync()
    {
        var res = await repository.GetAuthorsAmountAsync();
        return new ApiResponse<int>(HttpStatusCode.OK, "Amount of authors.", res);
    }
}