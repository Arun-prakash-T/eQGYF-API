using System;
using System.ComponentModel.DataAnnotations;

namespace eQERPGYF_WebAPI.Models
{
    public partial class PinCode
    {

        [Key]
        public int pinId { get; set; }
        public string? pinName { get; set; }
        public int pinCityId { get; set; }
        public string? pinCode { get; set; }
        public bool? pinActive { get; set; }
        public int pinCreatedBy { get; set; }
        public DateTime pinCreatedOn { get; set; }
        public int? pinModifiedBy { get; set; }
        public DateTime? pinModifiedOn { get; set; }
    }
}