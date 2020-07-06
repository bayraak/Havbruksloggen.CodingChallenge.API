using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Havbruksloggen.CodingChallenge.Core.Entities
{
    [Table("employees")]
    public class Employee
    {
        [Key]
        public int EmpNo { get; set; }

        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(14)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(16)]
        public string LastName { get; set; }

        public string DeptNo { get; set; }
    }
}
