using SharkWallet_2._0.DBcontext;
using SharkWallet_2._0.entidades;
using SharkWallet_2._0.Genericos;
using SharkWallet_2._0.Repositorios.IRespositorio;

namespace SharkWallet_2._0.Repositorios.Clases
{
    public class BalanceR : GenericosRepositorio<Balance>, IBalanceR
    {
        public BalanceR(DBContext db) : base(db)
        {

        }
    }
}
