using System.Net;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class BookService(DataContext context) : IBookService
{
    public async Task<Response<Book>> CreateAsync(Book book)
    {
        await context.Books.AddAsync(book);
        var result = await context.SaveChangesAsync();
        return result == 0 ?
        new Response<Book>(HttpStatusCode.BadRequest, "Book not added")
        : new Response<Book>(book);
    }

    public async Task<Response<string>> DeleteAsync(int id)
    {
        var books = await context.Books.FindAsync(id);
        if (books == null)
        {
            return new Response<string>("Id is not found");
        }
        context.Remove(books);
        var result = await context.SaveChangesAsync();
        return result == 0 ?
        new Response<string>(HttpStatusCode.BadRequest, "Book Doesn`t deleted")
        : new Response<string>("Book deleted succesfuly");

    }

    public async Task<Response<List<Book>>> GetAllAsync()
    {
        var books = await context.Books.ToListAsync();
        return new Response<List<Book>>(books);
    }

    public async Task<Response<Book>> GetByIdAsync(int id)
    {
        var result = await context.Books.FindAsync(id);
        await context.SaveChangesAsync();
        return result == null ?
        new Response<Book>(HttpStatusCode.BadRequest, "book can`t find")
        : new Response<Book>(result);
    }

    public async Task<Response<Book>> UpdateAsync(Book book)
    {
        context.Books.Update(book);
        var result = await context.SaveChangesAsync();
        return result == 0 ?
        new Response<Book>(HttpStatusCode.BadRequest, "Book can`t update")
        : new Response<Book>(book);

    }

}
