using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Certificate")]
    public class Certificate
    {
        [Key]
        public int CertId { get; set; }

        [Column("StudentId")]
        public int StudentId { get; set; }

        [Column("CertName")]
        public string CertName { get; set; } = string.Empty;

        [Column("CertCode")]
        public string CertCode { get; set; } = string.Empty;
    }
}
