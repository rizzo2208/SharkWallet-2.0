using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharkWallet_2._0.entidades
{
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }

        public string UsuarioNombre { get; set; }

        [ForeignKey("Billetera")]
        public Billetera? billetera { get; set; }
    }
}
