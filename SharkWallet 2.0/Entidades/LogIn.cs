using SharkWallet_2._0.entidades;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharkWallet_2._0.Entidades
{
    public class LogIn
    {
        [Key]
        public int LogInID { get; set; }

        public string Email { get; set; }

        public string Contraseña { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        [ForeignKey("Usuario")]
        public Usuario usuario { get; set; }

    }
}
