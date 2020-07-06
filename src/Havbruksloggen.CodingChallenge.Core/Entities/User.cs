using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text;
using Newtonsoft.Json;

namespace Havbruksloggen.CodingChallenge.Core.Entities
{
    [Table("users")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(63)]
        public string FirstName { get; set; }

        [MaxLength(63)]
        public string Username { get; set; }

        [MaxLength(63)]
        public string LastName { get; set; }

        [JsonIgnore]
        public byte[] PasswordHash { get; set; }

        [JsonIgnore]
        public byte[] PasswordSalt { get; set; }
        public virtual ICollection<Boat> Boats { get; set; } = new HashSet<Boat>();
    }
}
