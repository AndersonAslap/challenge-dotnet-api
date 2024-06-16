namespace ManageLibrary.Model;

public class Book
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Genrer { get; set; } = string.Empty;
    public double Price { get; set; }
    public int Quantity { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set;} = null;
    public DateTime? DeletedAt { get; set; } = null;
}
