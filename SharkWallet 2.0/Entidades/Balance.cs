using System.ComponentModel.DataAnnotations;

namespace SharkWallet_2._0.entidades
{
    public class Balance
    {
        [Key]
        public int BalanceID { get; set; }

        public double Cantidad { get; set; }

        public double Valor { get; set; }
    }
}
