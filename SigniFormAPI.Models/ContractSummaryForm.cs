using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigniFormAPI.Models
{
    public class ContractSummaryForm
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ContractId { get; set; }
        [Required]
        public string ContractDate { get; set; }
        [Required]
        public string InitiatedPerson { get; set; }
        [Required]
        public string RelevantDirector { get; set; }
        [Required]
        public string ContractorName { get; set; }
        [Required]
        public string ContractorId { get; set; }
        [Required]
        public string SigneePosition { get; set; }
        [Required]
        public string SigneeName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Iban { get; set; }
        [Required]
        public string Service { get; set; }
        [Required]
        public string Place { get; set; }
        [Required]
        public string DedlineDate { get; set; }
        [Required]
        public string VarPayer { get; set; }
        [Required]
        public string VatIncluded { get; set; }
        [Required]
        public string Details { get; set; }
        [Required]
        public string Amount { get; set; }
        [Required]
        public string PaymentTerm { get; set; }
        [Required]
        public string PaymentType { get; set; }
        [Required]
        public string ValidityPeriod { get; set; }
        [Required]
        public string RelevantDirectorEmail { get; set; }
        [Required]
        public string LegalEmail { get; set; }
    }
}
