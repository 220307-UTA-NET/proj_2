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
        public UserAcc GetUserById(int id)
        {
            return _context.UserAccs.Find(id);
        }
        public UserAcc GetUserByUsername(string username)
        {
            return _context.UserAccs.FirstOrDefault(x => x.Username == username);
        }
        public bool CheckUsername(string username)
        {
            UserAcc? user = _context.UserAccs.FirstOrDefault(u => u.Username == username);
            if(user != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void UpdateOneUser(UserAcc changes, string input)
        {
            int intTest;
            UserAcc RetrievedUser = new UserAcc();
            if(Int32.TryParse(input, out intTest))
            {
                RetrievedUser = GetUserById(Int32.Parse(input));
            }
            else
            {
                RetrievedUser = GetUserByUsername(input);
            }
            RetrievedUser.Username = changes.Username;
            RetrievedUser.Password = changes.Password;
            RetrievedUser.LastPlace = changes.LastPlace;
            RetrievedUser.UpdatedAt = DateTime.Now;
            _context.SaveChanges();
        }
        public bool InsertOneUser(UserAcc user)
        {
            if(CheckUsername(user.Username))
                {
                _context.Add(user);
                _context.SaveChanges();
                return true;
                }
            return false;
        }
        public bool PlaceColorUser(int id)
        {
            
            UserAcc RetrievedUser = GetUserById(id);
            if(RetrievedUser.LastPlace == null)
            {
                RetrievedUser.LastPlace = DateTime.Now;
                _context.SaveChanges();
                return true;
            }
            else
            {
                if (RetrievedUser.LastPlace.Value.AddMinutes(5) >= DateTime.Now)
                {
                    RetrievedUser.LastPlace = DateTime.Now;
                    return true;
                }
                else
                {
                    return false;
                }
            }
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