using System.ComponentModel.DataAnnotations;

namespace test_seguros_continental.WebApi.DTOs.TypeClient
{
    public class TypeClientDto
    {
        public int TypeClientId { get; set; }
        public string TypeName { get; set; }
        public bool Status { get; set; }
    }
}
