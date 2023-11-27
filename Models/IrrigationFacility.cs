using System;
using System.ComponentModel.DataAnnotations;

namespace eQERPGYF_WebAPI.Models
{
    public partial class IrrigationFacility
    {

        [Key]
        public int igfId { get; set; }
        public string? igfName { get; set; }
        public string? igfNameInTamil { get; set; }
        public string? igfCode { get; set; }
        public string? igfDescription { get; set; }
        public bool? igfActive { get; set; }
        public int igfCreatedBy { get; set; }
        public DateTime igfCreatedOn { get; set; }
        public int? igfModifiedBy { get; set; }
        public DateTime? igfModifiedOn { get; set; }
    }
}