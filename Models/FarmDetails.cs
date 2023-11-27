using System;
using System.ComponentModel.DataAnnotations;

namespace eQERPGYF_WebAPI.Models
{
    public partial class FarmDetails
    {
        [Key]
        public int fmdId { get; set; }
        public int? fmdSno { get; set; }
        public int fmdFarmerId { get; set; }
        public int? fmdStateId { get; set; }
        public int? fmdCityId { get; set; }
        public int? fmdTalukId { get; set; }
        public int? fmdBlockId { get; set; }
        public string? fmdCropId { get; set; }
        public string? fmdLiveStockId { get; set; }
        public string? fmdVillageId { get; set; }
        public string? fmdAddress1 { get; set; }
        public string? fmdAddress2 { get; set; }
        public string? fmdAddress3 { get; set; }
        public int? fmdPincodeId { get; set; }
        public decimal? fmdFarmSize { get; set; }
        public int? fmdNoOfPlots { get; set; }
        public string? fmdIrrigationFacility { get; set; }
        public string? fmdFarmingType { get; set; }
        public bool? fmdActive { get; set; }
        public int? fmdCreatedBy { get; set; }
        public DateTime fmdCreatedOn { get; set; }
        public int? fmdModifiedBy { get; set; }
        public DateTime? fmdModifiedOn { get; set; }
    }
}