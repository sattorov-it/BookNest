using Application.DTOs.Authors;
using Application.Responses;

namespace Application.Interfaces;

public interface IAuthorService
{
    Task<ApiResponse<bool>> AddAuthorAsync(CreateAuthorDto dto);
    Task<ApiResponse<bool>> UpdateAuthorAsync(UpdateAuthorDto dto);
    Task<ApiResponse<bool>> DeleteAuthorAsync(int id);
    Task<ApiResponse<GetAuthorDto>> GetAuthorAsync(int id);
    Task<ApiResponse<List<GetAuthorDto>>> GetAuthorsAsync();
    Task<ApiResponse<int>> GetAuthorsAmountAsync();
}