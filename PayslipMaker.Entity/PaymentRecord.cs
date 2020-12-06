using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PayslipMaker.Entity
{
    public class PaymentRecord
    {
        public int Id { get; set; }

        //Relation with Employee class with many to one
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } //Navigation property

        [MaxLength(100)]
        public string FullName { get; set; }

        [Required, MaxLength(50)]
        public string PancardNo { get; set; }
        public DateTime PayDate { get; set; }
        public string PayMonth { get; set; }

        [ForeignKey("TaxYear")]
        public int TaxYearId { get; set; }
        public TaxYear TaxYear { get; set; }

        [Column(TypeName = "money")]
        public decimal HourlyRate { get; set; }

        [DataType(DataType.Currency)]
        public decimal HoursWorked { get; set; }

        [DataType(DataType.Currency)]
        public decimal ContractualHours { get; set; }

        [DataType(DataType.Currency)]
        public decimal OvertimeHours { get; set; }

        [Column(TypeName = "money")]
        public decimal ContractualEarnings { get; set; }

        [Column(TypeName = "money")]
        public decimal OvertimeEarnings { get; set; }

        [Column(TypeName = "money")]
        public decimal Tax { get; set; }

        [Column(TypeName = "money")]
        public decimal? UnionFee { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalEarnings { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalDeduction { get; set; }

        [Column(TypeName ="money")]
        public decimal NetPayment { get; set; }




    }
}
