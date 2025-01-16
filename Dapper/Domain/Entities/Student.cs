using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Student")]
    public class Student
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("FirstName")]
        public string FirstName { get; set; } = string.Empty;

        [Column("LastName")]
        public string LastName { get; set; } = string.Empty;

        [Column("EmailAddress")]
        public string EmailAddress { get; set; } = string.Empty;

        [Column("Major")]
        public string Major { get; set; } = string.Empty;

        [Column("Deleted")]
        public bool Deleted { get; set; }

        [Column("Version")]
        public int Version { get; set; }

        [Column("CreatedDate")]
        public DateTime? CreatedDate { get; set; }

        [Column("CreatedUser")]
        public string CreatedUser { get; set; } = string.Empty;

        [Column("UpdatedDate")]
        public DateTime? UpdatedDate { get; set; }

        [Column("UpdatedUser")]
        public string UpdatedUser { get; set; } = string.Empty;
    }
}
