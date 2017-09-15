using Demo.Domain.Dtos;

namespace Demo.Domain.Entities
{
    public class Category : Entity
    {
        public string Name { get; set; }
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