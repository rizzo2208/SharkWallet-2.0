using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharkWallet_2._0.entidades
{
    public class Monedas
    {
        [Key]
        public int MonedasID { get; set; }

        public string? MonedasNombre { get; set; }

        [ForeignKey("Balance")]
        public Balance? balance { get; set; }
    }
}
