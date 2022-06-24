using SharkWallet_2._0.DBcontext;
using SharkWallet_2._0.Entidades;
using SharkWallet_2._0.Genericos;
using SharkWallet_2._0.Repositorios.IRespositorio;

namespace SharkWallet_2._0.Repositorios.Clases
{
    public class LogInR : GenericosRepositorio<LogIn>, ILogInR
    {
        public LogInR(DBContext db) : base(db)
        {
        }
        public LogIn GetByEmail(string email)
        {
            return _db.LogIn.FirstOrDefault(a => a.Email == email);
        }
        public bool ExisteUsuario(string email)
        {
            
            return _db.LogIn.Any(a => a.Email == email);
        }
    }
}
