using SharkWallet_2._0.DBcontext;
using SharkWallet_2._0.entidades;
using SharkWallet_2._0.Genericos;
using SharkWallet_2._0.Repositorios.IRespositorio;

namespace SharkWallet_2._0.Repositorios.Clases
{
    public class UsuarioR : GenericosRepositorio<Usuario>, IUsuarioR
    {
        public UsuarioR(DBContext db) : base(db)
        {
        }
    }
}
