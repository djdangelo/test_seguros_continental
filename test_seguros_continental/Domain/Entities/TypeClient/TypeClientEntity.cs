using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace test_seguros_continental.Domain.Entities.TypeClient
{
    public class TypeClientEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TypeClientId { get; set; }
        [Required, StringLength(50)]
        public string TypeName { get; set; }
        [Required]
        public bool Status { get; set; }
    }
}
