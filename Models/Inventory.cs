using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAPIs.Models
{
    public class Inventory
    {
        [Key] public int id { get; set; }

        [ForeignKey("Name")]
        public string? Name { get; set; }
      
        public int Quantity { get; set; }

        public DateTime DateofPurchase {get; set; }
    }

}
