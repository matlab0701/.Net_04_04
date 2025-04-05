using Domain.Entities;
using Domain.Responses;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BookController(IBookService bookService)
{
     [HttpGet]
    public async Task<Response<List<Book>>> GetAllAsync()
    {
        var Books = bookService.GetAllAsync();
        return await Books;
    }
    [HttpGet("{id:int}")]
    public async Task<Response<Book>> GetByIdAsync(int id)
    {
        var Book = bookService.GetByIdAsync(id);
        return await Book;
    }

    [HttpPost]
    public async Task<Response<Book>> CreateAsync(Book book)
    {
        var result = bookService.CreateAsync(book);
        return await result;
    }
    [HttpPut]
    public async Task<Response<Book>> UpdateAsync(Book book)
    {
        var result = bookService.UpdateAsync(book);
        return await result;
    }
    [HttpDelete("{id:int}")]
    public async Task<Response<string>> DeleteAsync(int id)
    {
        var book = bookService.DeleteAsync(id);
        return await book;
    }

}
