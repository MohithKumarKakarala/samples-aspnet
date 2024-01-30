using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace okta_aspnet_mvc_example.Models
{
    public class Rule
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int RuleID { get; set; }
        public string RuleName { get; set; }
        public string RuleDescription { get; set; }
        public double  RuleType { get; set; }
        public string RuleVersion { get; set; }
        public string PreConditionTemplateID { get; set; }
        public int TriggerTemplateID { get; set; }
        public int CheckTemplateID { get; set; }
        public int FixTemplateID { get; set; }
        public DateTime RuleCreatedDateTime { get; set; }
        public DateTime RuleModifiedDateTime { get; set; }
        public string RuleCreatedBy { get; set; }
        public string RuleModifiedBy { get; set; }
        public string RuleText { get; set; }
        public string RuleOriginalFileName { get; set; }
    }
}