using SharkWallet_2._0.entidades;
using System.ComponentModel.DataAnnotations;

namespace SharkWallet_2._0.Autenticacion.response
{
    public class UserResponse
    {
        [Key]
        public Usuario? UsuarioID { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Contraseña { get; set; }
    }
}
