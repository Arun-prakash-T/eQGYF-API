using System;
using System.ComponentModel.DataAnnotations;

namespace eQERPGYF_WebAPI.Models
{
    public class Crops
    {
        [Key]
        public int crpId { get; set; }
        public string? crpName { get; set; }
        public string? crpNameInTamil { get; set; }
        public string? crpCode { get; set; }
        public string? crpDescription { get; set; }
        public bool? crpActive { get; set; }
        public int crpCreatedBy { get; set; }
        public DateTime crpCreatedOn { get; set; }
        public int? crpModifiedBy { get; set; }
        public DateTime? crpModifiedOn { get; set; }
    }
}