using Application.DTOs.Books;
using Application.Responses;

namespace Application.Interfaces;

public interface IBookService
{
    Task<ApiResponse<bool>> AddBookAsync(CreateBookDto dto);
    Task<ApiResponse<bool>> UpdateBookAsync(UpdateBookDto dto);
    Task<ApiResponse<bool>> DeleteBookAsync(int id);
    Task<ApiResponse<GetBookDto>> GetBookAsync(int id);
    Task<ApiResponse<List<GetBookDto>>> GetBooksAsync();
    Task<ApiResponse<int>> GetBookAmountAsync();
    Task<ApiResponse<int>> GetMinPublishedYearByAuthorAsync(int authorId);
    Task<ApiResponse<int>> GetMaxPublishedYearByAuthorAsync(int authorId);
    Task<ApiResponse<int>> GetMinPublishedYearByGenreAsync(int genreId);
    Task<ApiResponse<int>> GetMaxPublishedYearByGenreAsync(int genreId);
    Task<ApiResponse<int>> GetAmountByPublishedYearAsync(int year);
    Task<ApiResponse<int>> GetAmountByGenreAsync(int genreId);
}