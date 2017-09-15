using Demo.Domain.Dtos;

namespace Demo.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }

        public Product(string name, Category category, decimal price, int stockQtd)
        {
            Name = name;
            Category = category;
            Price = price;
            StockQuantity = stockQtd;
        }    

    }
}