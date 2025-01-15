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
    }
}
