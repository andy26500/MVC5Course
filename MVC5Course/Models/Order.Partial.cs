using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC5Course.Models
{
    [MetadataType(typeof(OrderMetaData))]
    public partial class Order
    {
    }
    
    public class OrderMetaData
    {
        [Required]
        public int OrderId { get; set; }
        public int? ClientId { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal? OrderTotal { get; set; }
        
        [StringLength(1, ErrorMessage="欄位長度不得大於 1 個字元")]
        public string OrderStatus { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
