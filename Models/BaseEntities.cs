using System.ComponentModel.DataAnnotations;

namespace InventoryAPIs.Models
{
    public abstract class BaseEntities
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime? ModiefiedDateTime { get; set; }

        public bool IsActive { get; set; }
    }
}