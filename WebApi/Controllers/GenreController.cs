using Domain.Entities;
using Domain.Responses;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class GenreController(IGenreService genreService)
{
     [HttpGet]
    public async Task<Response<List<Genre>>> GetAllAsync()
    {
        var Genres = genreService.GetAllAsync();
        return await Genres;
    }
    [HttpGet("{id:int}")]
    public async Task<Response<Genre>> GetByIdAsync(int id)
    {
        var genre = genreService.GetByIdAsync(id);
        return await genre;
    }

    [HttpPost]
    public async Task<Response<Genre>> CreateAsync(Genre genre)
    {
        var result = genreService.CreateAsync(genre);
        return await result;
    }
    [HttpPut]
    public async Task<Response<Genre>> UpdateAsync(Genre genre)
    {
        var result = genreService.UpdateAsync(genre);
        return await result;
    }
    [HttpDelete("{id:int}")]
    public async Task<Response<string>> DeleteAsync(int id)
    {
        var genre = genreService.DeleteAsync(id);
        return await genre;
    }

}
