using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Book
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Title { get; set; }

    [Range(1450, 2100)]
    public int Year { get; set; }

    [Required]
    [StringLength(13, MinimumLength = 10)]
    public string ISBN { get; set; }

    [Range(1, 10000)]
    public int Pages { get; set; }

    [StringLength(1000)]
    public string Description { get; set; }

    [ForeignKey("Author")]
    public int AuthorId { get; set; }

    [ForeignKey("Genre")]
    public int GenreId { get; set; }


    // Навигационное свойство
    public Author Author { get; set; }
    public Genre Genre { get; set; }
}
