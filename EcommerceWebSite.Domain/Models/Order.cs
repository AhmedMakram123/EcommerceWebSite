using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceWebSite.Domain.Enum;

namespace EcommerceWebSite.Domain.Models
{
    public class Order : BaseEntity
    {
        public decimal FinalPrice { get; set; }
        public DateTime Date { get; set; }
        public OrderState State { get; set; }
        public string Address { get; set; }

        //Relation
        [ForeignKey("User")]
        public string UserID { get; set; }
       
        public ApplicationUser User { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }

}
