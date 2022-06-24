using SharkWallet_2._0.Autenticacion.request;
using SharkWallet_2._0.Autenticacion.response;

namespace SharkWallet_2._0.Servicios
{
    public interface IUserServices
    {
        UserResponse Registrar(UserRequest usuario, string password);
        UserResponse Login(string usuario, string password);
        string GetToken(UserResponse usuario);
    }
}
