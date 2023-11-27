using System;
using System.ComponentModel.DataAnnotations;

namespace eQERPGYF_WebAPI.Models
{
    public partial class FarmingType
    {
        [Key]
        public int fmtId { get; set; }
        public string? fmtName { get; set; }
        public string? fmtNameInTamil { get; set; }
        public string? fmtCode { get; set; }
        public string? fmtDescription { get; set; }
        public bool? fmtActive { get; set; }
        public int fmtCreatedBy { get; set; }
        public DateTime fmtCreatedOn { get; set; }
        public int? fmtModifiedBy { get; set; }
        public DateTime? fmtModifiedOn { get; set; }
    }
}