namespace Demo.Domain.Dtos
{
    public class ProductDto : Entity
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
    }
}