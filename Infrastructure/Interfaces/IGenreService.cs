using Domain.Entities;
using Domain.Responses;

namespace Infrastructure.Interfaces;

public interface IGenreService
{
    Task<Response<List<Genre>>> GetAllAsync();
    Task<Response<Genre>> GetByIdAsync(int id);
    Task<Response<Genre>> CreateAsync(Genre genre);
    Task<Response<Genre>> UpdateAsync(Genre genre);
    Task<Response<string>> DeleteAsync(int id);

}
