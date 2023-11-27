using System;
using System.ComponentModel.DataAnnotations;

namespace eQERPGYF_WebAPI.Models
{
    public class Village
    {
        [Key]
        public int vlgId { get; set; }
        public string? vlgName { get; set; }
        public int vlgBlockId { get; set; }
        public string? vlgCode { get; set; }
        public bool? vlgActive { get; set; }
        public int vlgCreatedBy { get; set; }
        public DateTime vlgCreatedOn { get; set; }
        public int? vlgModifiedBy { get; set; }
        public DateTime? vlgModifiedOn { get; set; }
    }
}