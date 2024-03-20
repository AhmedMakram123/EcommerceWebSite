using EcommerceWebSite.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Domain.DTOs.Comment
{
    public class CreateCommentDto
    {
        public int Id { get; set; }
        public string review { get; set; }
        public decimal quality { get; set; }
        public int ProductId { get; set; }
        
    }
}
