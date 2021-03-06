using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MVC5Course.Models.Attributes;

namespace MVC5Course.Models
{
    [MetadataType(typeof(ClientMetaData))]
    public partial class Client : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Longitude.HasValue != Latitude.HasValue)
            {
                yield return new ValidationResult("經緯度必須同時設定", new[] { "Longitude", "Latitude" });
            }
        }
    }
    
    public class ClientMetaData
    {
        [Required]
        public int ClientId { get; set; }
        
        [StringLength(40, ErrorMessage="欄位長度不得大於 40 個字元")]
        [Required]
        public string FirstName { get; set; }
        
        [StringLength(40, ErrorMessage="欄位長度不得大於 40 個字元")]
        public string MiddleName { get; set; }
        
        [StringLength(40, ErrorMessage="欄位長度不得大於 40 個字元")]
        [Required]
        public string LastName { get; set; }
        
        [StringLength(1, ErrorMessage="欄位長度不得大於 1 個字元")]
        [Required]
        public string Gender { get; set; }
        
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }
        
        public double? CreditRating { get; set; }
        
        [StringLength(7, ErrorMessage="欄位長度不得大於 7 個字元")]
        public string XCode { get; set; }
        public int? OccupationId { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        public string TelephoneNumber { get; set; }
        
        [StringLength(100, ErrorMessage="欄位長度不得大於 100 個字元")]
        public string Street1 { get; set; }
        
        [StringLength(100, ErrorMessage="欄位長度不得大於 100 個字元")]
        public string Street2 { get; set; }
        
        [StringLength(100, ErrorMessage="欄位長度不得大於 100 個字元")]
        public string City { get; set; }
        
        [StringLength(15, ErrorMessage="欄位長度不得大於 15 個字元")]
        public string ZipCode { get; set; }
        
        public double? Longitude { get; set; }
        
        public double? Latitude { get; set; }
        
        public string Notes { get; set; }
        
        [DisplayName("身分證字號")]
        [PersonalIDFormat_Taiwan]
        public string IDNumber { get; set; }
        
        public virtual Occupation Occupation { get; set; }
        
        public virtual ICollection<Order> Order { get; set; }
    }
}
