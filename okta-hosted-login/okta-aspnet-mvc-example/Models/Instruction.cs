using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace okta_aspnet_mvc_example.Models
{
    public class Instruction
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int InstructionID { get; set; }

        [Display(Name = "Instruction Name")]
        public string InstructionName { get; set; }

        [Display(Name = "Readable Payload")]
        public string ReadablePayload { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Category")]
        public string Type { get; set; }

        public int TtlMinutes { get; set; }

        public int ResponseTtlMinutes { get; set; }

        [Display(Name = "Version")]
        public string Version { get; set; }

        [Display(Name = "Instruction Author")]
        public string Author { get; set; }

        public string Payload { get; set; }

        public string Comments { get; set; }

        public string SchemaJson { get; set; }

        public string TaskGroups { get; set; }

        public string AggregationJson { get; set; }

        public string Signature { get; set; }

        public string CreatedDateTime { get; set; }

        public string ModifiedDateTime { get; set; }

        public bool IsActive { get; set; }

        public bool IsDownloadable { get; set; }
    }
}