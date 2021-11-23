using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSDelivery.Data
{
    public class Restraunt
    {
        [Key]
        public int RestrauntId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public Guid OwnerId { get; set; }
        public virtual List<Product> products { get; set; }

    }
}
