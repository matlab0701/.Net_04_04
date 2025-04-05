using Domain.Entities;
using Domain.Responses;

namespace Infrastructure.Interfaces;

public interface IAuthorService
{
    Task<Response<List<Author>>> GetAllAsync();
    Task<Response<Author>> GetByIdAsync(int id);
    Task<Response<Author>> CreateAsync(Author author);
    Task<Response<Author>> UpdateAsync(Author author);
    Task<Response<string>> DeleteAsync(int id);

}
