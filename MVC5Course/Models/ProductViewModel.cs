using System.ComponentModel.DataAnnotations;

namespace MVC5Course.Models
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "商品名稱必填")]
        [StringLength(10, ErrorMessage = "商品名稱不得大於10個字元")]
        public string ProductName { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal? Price { get; set; }
        
        [Required]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal? Stock { get; set; }
    }
}