using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace okta_aspnet_mvc_example.Models
{
    public class Policy
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PolicyID { get; set; }
        public string PolicyName { get; set; }
        public string PolicyDescription { get; set; }
        public string  RuleType { get; set; }
        public string PolicyCreatedDateTime { get; set; }
        public string PolicyModifiedDateTime { get; set; }
        public string PolicyCreatedBy { get; set; }
        public string PolicyModifiedBy { get; set; }
        public string PolicyText { get; set; }
        public string PolicyOriginalFileName { get; set; }
    }
}