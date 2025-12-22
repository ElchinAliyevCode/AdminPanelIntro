using System.ComponentModel.DataAnnotations;

namespace AdminPanelIntro.Models;

public class ShippingItem
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MinLength(3)]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    [MaxLength(256)]
    public string Description { get; set; }
    [Required]
    [MinLength(3)]
    [MaxLength(512)]
    public string ImageUrl { get; set; }
}
