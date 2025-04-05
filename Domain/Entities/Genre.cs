using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Genre
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [MaxLength(500)]
    public string Description { get; set; }

    public bool IsFiction { get; set; }

    [Range(0, 100)]
    public int Popularity { get; set; }

    // Навигационное свойство
    public List<Book> Books { get; set; }
}
