using SharkWallet_2._0.DBcontext;
using SharkWallet_2._0.Repositorios.Clases;
using SharkWallet_2._0.Repositorios.IRespositorio;

namespace SharkWallet_2._0.UOWork
{
    public class UOWork : IUOWork
    {
        private readonly DBContext _context;

        public IUsuarioR UsuarioRepo { get; private set; }

        public IMonedasR MonedaRepo { get; private set; }

        public IBilleteraR BilleteraRepo { get; private set; }

        public IBalanceR BalanceRepo { get; private set; }
        public ILogInR LogInRepo { get; private set; }




        public UOWork(DBContext context)
        {
            _context = context;

            UsuarioRepo = new UsuarioR(context);
            MonedaRepo = new MonedasR(context);
            BilleteraRepo = new BilleteraR(context);
            BalanceRepo = new BalanceR(context);
            LogInRepo = new LogInR(context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
