using System;
using System.ComponentModel.DataAnnotations;

namespace eQERPGYF_WebAPI.Models
{
    public class Blocks
    {
        [Key]
        public int blkId { get; set; }
        public int blkTalukId { get; set; }
        public string? blkName { get; set; }
        public string? blkNameInTamil { get; set; }
        public string? blkCode { get; set; }
        public bool? blkActive { get; set; }
        public int blkCreatedBy { get; set; }
        public DateTime blkCreatedOn { get; set; }
        public int? blkModifiedBy { get; set; }
        public DateTime? blkModifiedOn { get; set; }
    }
}