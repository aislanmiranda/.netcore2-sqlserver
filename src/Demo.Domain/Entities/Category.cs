using System.Collections.Generic;

namespace Demo.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public Category()
        {
            
        }
        public Category(string name)
        {
            Name = name;
        }

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}