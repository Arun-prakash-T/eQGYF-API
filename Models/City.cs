using System;
using System.ComponentModel.DataAnnotations;

namespace eQERPGYF_WebAPI.Models
{
    public partial class City
    {
        [Key]
        public int ctyId { get; set; }
        public string? ctyName { get; set; }
        public int ctyStateId { get; set; }
        public string? ctyCode { get; set; }
        public bool? ctyActive { get; set; }
        public int ctyCreatedBy { get; set; }
        public DateTime ctyCreatedOn { get; set; }
        public int? ctyModifiedBy { get; set; }
        public DateTime? ctyModifiedOn { get; set; }
        public string? ctyNameInTamil { get; set; }
    }
}