using System.ComponentModel.DataAnnotations;

namespace Havbruksloggen.CodingChallenge.Core.Dtos
{
    public class EmployeePutDto
    {
        [Required]
        public string LastName { get; set; }
    }
}
