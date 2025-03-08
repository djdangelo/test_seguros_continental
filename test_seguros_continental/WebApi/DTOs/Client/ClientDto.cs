
namespace test_seguros_continental.WebApi.DTOs.Client
{
    public class ClientDto
    {
        public int? ClientId { get; set; }
        public int TypeClientId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public bool? Status { get; set; }
    }
}
