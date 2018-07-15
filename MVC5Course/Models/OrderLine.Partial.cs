using System.ComponentModel.DataAnnotations;

namespace MVC5Course.Models
{
    [MetadataType(typeof(OrderLineMetaData))]
    public partial class OrderLine
    {
    }
    
    public class OrderLineMetaData
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int LineNumber { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public decimal Qty { get; set; }
        [Required]
        public decimal LineTotal { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
