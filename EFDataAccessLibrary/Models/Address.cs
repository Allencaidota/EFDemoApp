using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFDataAccessLibrary
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string StreetAddress { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        [Required]
        [MaxLength(50)]
        public string State { get; set; }

        [Required]
        [MaxLength(10)] //1235-0000
        [Column(TypeName = "varchar(10)")]
        public string ZipCode { get; set; }

    }
}
