using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharkWallet_2._0.entidades
{
    public class Billetera
    {
        [Key]
        public int BilleteraID { get; set; }

        /*[ForeignKey("Monedas")]
        public IEnumerable<Monedas>? Moneda { get; set; }*/

        [ForeignKey("Monedas")]
        public double Moneda { get; set; }

    }
}
