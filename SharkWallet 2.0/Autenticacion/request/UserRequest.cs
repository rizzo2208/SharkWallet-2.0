using System.ComponentModel.DataAnnotations;

namespace SharkWallet_2._0.Autenticacion.request
{
    public class UserRequest
    {

        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Contraseña { get; set; }
    }
}
