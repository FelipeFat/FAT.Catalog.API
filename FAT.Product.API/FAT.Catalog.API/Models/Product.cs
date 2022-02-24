using FAT.Catalog.API.Models.Interfaces;

namespace FAT.Catalog.API.Models
{
    public class Product : Entity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public decimal Value { get; set; }
        public DateTime InserDate { get; set; }
        public string Image { get; set; }
        public int QtdStock { get; set; }
    }
}
