using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSOSDelivery.Model
{
    public class CustomerCreate
    {
        
        [Required]
        public string PhoneNumber { get; set; }

        public string Name { get; set; }

        public int CustomerId { get; set; }

        


    }
}
