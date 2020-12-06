using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PayslipMaker.Entity
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string EmployeeCode { get; set; }

        [Required, MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string MiddleName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DateJoined { get; set; }
        public string Designation { get; set; }

        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required, MaxLength(50)]
        public string PancardNo { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public UnionMember UnionMember { get; set; }

        [Required, MaxLength(150)]
        public string Address { get; set; }
        public string City { get; set; }

        [Required, MaxLength(6)]
        public string Pincode { get; set; }

        //relation with PaymentRecord class in one to many 
        public IEnumerable<PaymentRecord> paymentRecords { get; set; }


    }
}
