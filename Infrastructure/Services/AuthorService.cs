using System.Net;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AuthorService(DataContext context) : IAuthorService
{
    public async Task<Response<Author>> CreateAsync(Author author)
    {
        await context.Authors.AddAsync(author);
        var result = await context.SaveChangesAsync();
        return result == 0 ?
        new Response<Author>(HttpStatusCode.BadRequest, "Author not added")
        : new Response<Author>(author);
    }

    public async Task<Response<string>> DeleteAsync(int id)
    {
        var authors = await context.Authors.FindAsync(id);
        if (authors == null)
        {
            return new Response<string>("Id is not found");
        }
        context.Remove(authors);
        var result = await context.SaveChangesAsync();
        return result == 0 ?
        new Response<string>(HttpStatusCode.BadRequest, "Author Doesn`t deleted")
        : new Response<string>("Author deleted succesfuly");

    }

    public async Task<Response<List<Author>>> GetAllAsync()
    {
        var authors = await context.Authors.ToListAsync();
        return new Response<List<Author>>(authors);
    }

    public async Task<Response<Author>> GetByIdAsync(int id)
    {
        var result = await context.Authors.FindAsync(id);
        await context.SaveChangesAsync();
        return result == null ?
        new Response<Author>(HttpStatusCode.BadRequest, "Author can`t find")
        : new Response<Author>(result);
    }

    public async Task<Response<Author>> UpdateAsync(Author author)
    {
        context.Authors.Update(author);
        var result = await context.SaveChangesAsync();
        return result == 0 ?
        new Response<Author>(HttpStatusCode.BadRequest, "Author can`t update")
        : new Response<Author>(author);

    }


}
