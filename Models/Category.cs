using System.ComponentModel.DataAnnotations;

namespace InventoryAPIs.Models
{
    public abstract class Category
    {
        public int id { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime ModiefiedDateTime { get; set; }

        public bool isActive { get; set; }
    }

    public class categoryname : Category
    {
        [Key]
        public int Id { get; set; }
        
        public string? CategoryName { get;  set; }
    }
}
