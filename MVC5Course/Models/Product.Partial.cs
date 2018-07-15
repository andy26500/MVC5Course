using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC5Course.Models
{
    [MetadataType(typeof(ProductMetaData))]
    public partial class Product
    {
    }
    
    public class ProductMetaData
    {
        [Required]
        public int ProductId { get; set; }
        
        [StringLength(80, ErrorMessage="欄位長度不得大於 80 個字元")]
        [Required]
        public string ProductName { get; set; }
       
        [Required]
        public decimal? Price { get; set; }
        
        [Required]
        public bool? Active { get; set; }
        
        [Required]
        public decimal? Stock { get; set; }
    
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
