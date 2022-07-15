using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAPIs.Models
{
    public class Inventory : BaseEntities
    {
        public string? InventoryName { get; set; }
        public Category Category { get; set; }
        public int Quantity { get; set; }
        public DateTime DateofPurchase { get; set; }
    }
}