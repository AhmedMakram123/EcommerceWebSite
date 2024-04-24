using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Domain.DTOs.Comment
{
    public class GetCommentDto
    {
        public int Id { get; set; }
        public string review { get; set; }
        public decimal quality { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
        public string UserName { get; set; }
    }
}
