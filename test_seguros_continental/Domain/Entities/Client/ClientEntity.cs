using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using test_seguros_continental.Domain.Entities.TypeClient;

namespace test_seguros_continental.Domain.Entities.Client
{
    public class ClientEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientId { get; set; }
        [Required]
        public int TypeClientId { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(50)]
        public string LastName { get; set; }
        [Required, StringLength(13)]
        public string Dni {  get; set; }
        [StringLength(100), EmailAddress(ErrorMessage = "The email is not correct.")]
        public string Email { get; set; }
        [Required]
        public DateTime BirthDate {  get; set; }
        [Required, StringLength(13)]
        public string PhoneNumber { get; set; }
        [Required]
        public bool Status { get; set; }

        [ForeignKey(nameof(TypeClientId))]
        public virtual TypeClientEntity TypeClientEntity { get; set; }

    }
}
