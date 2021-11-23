using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOSDelivery.Data
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(Customer))]
        public int CustomerID { get; set; }
        //public List<int> ProductId { get; set; }
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public Guid OwnerId { get; set; }
    }
}
