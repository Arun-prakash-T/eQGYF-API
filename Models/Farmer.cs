using System;
using System.ComponentModel.DataAnnotations;

namespace eQERPGYF_WebAPI.Models
{
    public partial class Farmer
    {
        [Key]
        public int fmrId { get; set; }
        public Int64 fmrMobileNo { get; set; }
        public string? fmrName { get; set; }
        public int? fmrStateId { get; set; }
        public int? fmrCityId { get; set; }
        public int? fmrTalukId { get; set; }
        public int? fmrBlockId { get; set; }
        public Int64? fmrWhatsAppNo { get; set; }
        public string? fmrFarmerId { get; set; }
        public int? fmrFarmerIdNo { get; set; }
        public string? fmrVillageId { get; set; }
        public string? fmrAddress1 { get; set; }
        public string? fmrAddress2 { get; set; }
        public string? fmrAddress3 { get; set; }
        public int? fmrPincodeId { get; set; }
        public bool? fmrActive { get; set; }
        public int? fmrCreatedBy { get; set; }
        public DateTime fmrCreatedOn { get; set; }
        public int? fmrModifiedBy { get; set; }
        public DateTime? fmrModifiedOn { get; set; }
        public string? fmrDeviceId { get; set; }
    }
}