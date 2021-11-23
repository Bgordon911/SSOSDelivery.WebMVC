using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSDelivery.Data
{
   public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Name { get; set; }
        [ForeignKey(nameof(Restraunt))]
        public int? RestrauntID { get; set; }
        public virtual  Restraunt Restraunt { get; set; }
        public Guid OwnerId { get; set; }

      
    }
}
