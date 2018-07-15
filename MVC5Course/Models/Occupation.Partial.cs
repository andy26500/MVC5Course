using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC5Course.Models
{
    [MetadataType(typeof(OccupationMetaData))]
    public partial class Occupation
    {
    }
    
    public class OccupationMetaData
    {
        [Required]
        public int OccupationId { get; set; }
        
        [StringLength(60, ErrorMessage="欄位長度不得大於 60 個字元")]
        public string OccupationName { get; set; }
    
        public virtual ICollection<Client> Client { get; set; }
    }
}
