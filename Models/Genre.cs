using System.ComponentModel.DataAnnotations;

public class Genre
{
    [Required]
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "You have to insert the name")]
    [StringLength(40)]
    public string Name { get; set; }
}
