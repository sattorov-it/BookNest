using Application.DTOs.Genres;
using Application.Responses;

namespace Application.Interfeces;

public interface IGenreService
{
    Task<ApiResponse<bool>> AddGenreAsync(CreateGenreDto dto);
    Task<ApiResponse<bool>> UpdateGenreAsync(UpdateGenreDto dto);
    Task<ApiResponse<bool>> DeleteGenreAsync(int id);
    Task<ApiResponse<GetGenreDto>> GetGenreAsync(int id);
    Task<ApiResponse<List<GetGenreDto>>> GetGenresAsync();
    Task<ApiResponse<int>> GetGenresAmountAsync();
}