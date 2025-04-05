using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Author
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; }

    [Range(1990, 2025)]
    public int BirthYear { get; set; }

    [StringLength(100)]
    public string Country { get; set; }

    [StringLength(1000)]
    public string Biography { get; set; }

    // Навигационное свойство
    public List<Book> Books { get; set; }
}
