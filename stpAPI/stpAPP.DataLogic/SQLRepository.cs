using stpApp.BusinessLogic;

namespace stpAPP.DataLogic
{
    public class SQLRepository : IRepository
    {
        private readonly Context _context;
        public SQLRepository(Context context)
        {
            _context = context;
        }

        public List<UserAcc> GetAllUserAcc()
        {
            return _context.UserAccs.ToList();
        }
    }
}