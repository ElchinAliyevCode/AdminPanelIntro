namespace AdminPanelIntro.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string MainImagePath { get; set; }
    public string HoverImagePath { get; set; }
    public string SKU { get; set; }
    public Category? Category { get; set; }
    public int CategoryId { get; set; }
}
