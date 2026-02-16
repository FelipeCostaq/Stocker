namespace Stocker.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int Amount { get; set; }
    }
}
