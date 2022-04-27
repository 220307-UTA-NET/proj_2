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
        #region // User Methods
        public List<UserAcc> GetAllUserAcc()
        {
            return _context.UserAccs.ToList();
        }
        public UserAcc GetOneUser(int id)
        {
            return _context.UserAccs.Find(id);
        }
        public void UpdateOneUser(UserAcc changes, int id)
        {
            UserAcc RetrievedUser = GetOneUser(id);
            RetrievedUser.Username = changes.Username;
            RetrievedUser.Password = changes.Password;
            RetrievedUser.LastPlace = changes.LastPlace;
            RetrievedUser.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
        }
        public void InsertOneUser(UserAcc user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }
        public void PlaceColorUser(int id)
        {
            UserAcc RetrievedUser = GetOneUser(id);
            RetrievedUser.LastPlace = DateTime.Now;
            _context.SaveChanges();
        }

        #endregion
        #region // Pixel Methods
        public List<Pixel> GetAllPixels()
        {
            return _context.Pixels.ToList();
        }
        #endregion
        #region // Guest Methods
        public List<Guest> GetAllGuests()
        {
            return _context.Guests.ToList();
        }
        #endregion
    }
}