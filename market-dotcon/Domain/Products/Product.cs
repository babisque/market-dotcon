namespace market_dotcon.Domain.Products;

public class Product : Entity
{
    public string Name { get; set; }
    public bool Active { get; set; } = true;
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public string Description { get; set; }
    public int Stock { get; set; }
}
