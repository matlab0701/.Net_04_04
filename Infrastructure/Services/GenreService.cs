using System.Net;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class GenreService(DataContext context) : IGenreService
{
    public async Task<Response<Genre>> CreateAsync(Genre genre)
    {
        await context.Genres.AddAsync(genre);
        var result = await context.SaveChangesAsync();
        return result == 0 ?
        new Response<Genre>(HttpStatusCode.BadRequest, "Genre not added")
        : new Response<Genre>(genre);
    }

    public async Task<Response<string>> DeleteAsync(int id)
    {
        var genres = await context.Genres.FindAsync(id);
        if (genres == null)
        {
            return new Response<string>("Id is not found");
        }
        context.Remove(genres);
        var result = await context.SaveChangesAsync();
        return result == 0 ?
        new Response<string>(HttpStatusCode.BadRequest, "Genre Doesn`t deleted")
        : new Response<string>("Genre deleted succesfuly");

    }

    public async Task<Response<List<Genre>>> GetAllAsync()
    {
        var genres = await context.Genres.ToListAsync();
        return new Response<List<Genre>>(genres);
    }

    public async Task<Response<Genre>> GetByIdAsync(int id)
    {
        var result = await context.Genres.FindAsync(id);
        await context.SaveChangesAsync();
        return result == null ?
        new Response<Genre>(HttpStatusCode.BadRequest, "Genre can`t find")
        : new Response<Genre>(result);
    }

    public async Task<Response<Genre>> UpdateAsync(Genre genre)
    {
        context.Genres.Update(genre);
        var result = await context.SaveChangesAsync();
        return result == 0 ?
        new Response<Genre>(HttpStatusCode.BadRequest, "Genre can`t update")
        : new Response<Genre>(genre);

    }


}
