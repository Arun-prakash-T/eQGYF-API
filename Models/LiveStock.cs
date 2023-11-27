using System;
using System.ComponentModel.DataAnnotations;

namespace eQERPGYF_WebAPI.Models
{
    public class LiveStock
    {
        [Key]
        public int lskId { get; set; }
        public string? lskName { get; set; }
        public string? lskNameInTamil { get; set; }
        public string? lskCode { get; set; }
        public string? lskDescription { get; set; }
        public bool? lskActive { get; set; }
        public int lskCreatedBy { get; set; }
        public DateTime lskCreatedOn { get; set; }
        public int? lskModifiedBy { get; set; }
        public DateTime? lskModifiedOn { get; set; }
    }
}
