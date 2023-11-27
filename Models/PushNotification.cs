using System;
using System.ComponentModel.DataAnnotations;

namespace eQERPGYF_WebAPI.Models
{
    public class PushNotification
    {
        [Key]
        public int pnfId { get; set; }
        public string? pnfName { get; set; }
        public string? pnfDescription { get; set; }
        public DateTime pnfDateandTime { get; set; }
        public string? pnfStatus { get; set; }
        public bool? pnfActive { get; set; }
        public int pnfCreatedBy { get; set; }
        public DateTime pnfCreatedOn { get; set; }
        public int? pnfModifiedBy { get; set; }
        public DateTime? pnfModifiedOn { get; set; }

    }
}
