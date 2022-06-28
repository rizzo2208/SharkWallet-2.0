using SharkWallet_2._0.Repositorios.IRespositorio;

namespace SharkWallet_2._0.UOWork
{
    public interface IUOWork : IDisposable
    {
        IUsuarioR UsuarioRepo { get; }
        IBilleteraR BilleteraRepo { get; }
        IMonedasR MonedaRepo { get; }
        IBalanceR BalanceRepo { get; }
        ILogInR LogInRepo { get; }

        void Save();
    }
}
