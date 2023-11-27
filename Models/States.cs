using System;
using System.ComponentModel.DataAnnotations;

namespace eQERPGYF_WebAPI.Models
{
    public partial class States
    {
        [Key]
        public int steId { get; set; }
        public string? steName { get; set; }
        public string? steCode { get; set; }
        public bool? steActive { get; set; }
        public int steCreatedBy { get; set; }
        public DateTime steCreatedOn { get; set; }
        public int? steModifiedBy { get; set; }
        public DateTime? steModifiedOn { get; set; }
        public string? steNameInTamil { get; set; }
    }
}