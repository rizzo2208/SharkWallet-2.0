using SharkWallet_2._0.Entidades;
using SharkWallet_2._0.Genericos;

namespace SharkWallet_2._0.Repositorios.IRespositorio
{
    public interface ILogInR : IGenericosRepositorio<LogIn>
    {
        LogIn GetByEmail(string Email);
        bool ExisteUsuario(string Email);
    }
}
