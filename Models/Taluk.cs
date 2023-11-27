using System;
using System.ComponentModel.DataAnnotations;

namespace eQERPGYF_WebAPI.Models
{
    public partial class Taluk
    {
        [Key]
        public int tlkId { get; set; }
        public string? tlkName { get; set; }
        public string? tlkNameInTamil { get; set; }
        public string? tlkCode { get; set; }
        public int tlkCityId { get; set; }
        public bool? tlkActive { get; set; }
        public int tlkCreatedBy { get; set; }
        public DateTime tlkCreatedOn { get; set; }
        public int? tlkModifiedBy { get; set; }
        public DateTime? tlkModifiedOn { get; set; }
    }
}