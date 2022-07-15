using System.ComponentModel.DataAnnotations;

namespace InventoryAPIs.Models
{
    public class Category : BaseEntities
    {       
        public string? CategoryName { get;  set; }
        public ICollection<Inventory> Inventories { get; set; }
    }
}