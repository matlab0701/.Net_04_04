using Domain.Entities;
using Domain.Responses;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AuthorController(IAuthorService authorService)
{
     [HttpGet]
    public async Task<Response<List<Author>>> GetAllAsync()
    {
        var authors = authorService.GetAllAsync();
        return await authors;
    }
    [HttpGet("{id:int}")]
    public async Task<Response<Author>> GetByIdAsync(int id)
    {
        var author = authorService.GetByIdAsync(id);
        return await author;
    }

    [HttpPost]
    public async Task<Response<Author>> CreateAsync(Author author)
    {
        var result = authorService.CreateAsync(author);
        return await result;
    }
    [HttpPut]
    public async Task<Response<Author>> UpdateAsync(Author author)
    {
        var result = authorService.UpdateAsync(author);
        return await result;
    }
    [HttpDelete("{id:int}")]
    public async Task<Response<string>> DeleteAsync(int id)
    {
        var author = authorService.DeleteAsync(id);
        return await author;
    }

}
