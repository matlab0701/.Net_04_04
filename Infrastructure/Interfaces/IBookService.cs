using Domain.Entities;
using Domain.Responses;

namespace Infrastructure.Interfaces;

public interface IBookService
{
    Task<Response<List<Book>>> GetAllAsync();
    Task<Response<Book>> GetByIdAsync(int id);
    Task<Response<Book>> CreateAsync(Book book);
    Task<Response<Book>> UpdateAsync(Book book);
    Task<Response<string>> DeleteAsync(int id);

}
