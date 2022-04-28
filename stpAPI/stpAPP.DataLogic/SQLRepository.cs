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
        public UserAcc? GetUserById(int id)
        {
            return _context.UserAccs.Find(id); 
        }
        public UserAcc? GetUserByUsername(string username)
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
            UserAcc? RetrievedUser = new UserAcc();
            if(Int32.TryParse(input, out intTest))
            {
                RetrievedUser = GetUserById(Int32.Parse(input));
            }
            else
            {
                RetrievedUser = GetUserByUsername(input);
            }
            if(RetrievedUser != null)
            {
                RetrievedUser.Username = changes.Username;
                RetrievedUser.Password = changes.Password;
                RetrievedUser.LastPlace = changes.LastPlace;
                RetrievedUser.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
            }
        }
        public bool InsertOneUser(UserAcc user)
        {
            if(!CheckUsername(user.Username)) // if username is not in database, allow new user creation
                {
                _context.Add(user);
                _context.SaveChanges();
                return true;
                }
            return false;
        }
        public bool CanUserColorChange(int id)
        {
            if(GetUserById(id) == null)
            {
                return false;
            }
            else
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

        }
        public bool DeleteUser(int id)
        {
            UserAcc? user = GetUserById(id);
            if(user != null)
            {
                _context.Remove(user);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        #endregion
        #region // Pixel Methods
        public List<Pixel> GetAllPixels()
        {
            return _context.Pixels.ToList();
        }
        public Pixel? GetPixelById(int id)
        {
            return _context.Pixels.Find(id);
        }
        public Pixel? GetPixelByRow(int row_num)
        {
            return _context.Pixels.FirstOrDefault(x => x.Row == row_num);
        }
        public Pixel? GetPixelByCol(int col_num)
        {
            return _context.Pixels.FirstOrDefault(x => x.Col == col_num);
        }
        public bool ChangePixelColorByUser(int Pid, int Uid, string hexcolor) 
        {
            Pixel? pixel = GetPixelById(Pid);
            // check if pixel object to be changed is not null
            // check if user's 5 minute restriction has passed
            if (pixel != null && CanUserColorChange(Uid))
            {
                pixel.Color = hexcolor;
                pixel.UpdatedAt = DateTime.Now;
                pixel.UpdatedBy = GetUserById(Uid).Username;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool InsertPixel(Pixel pixel)
        {
            // check if column and row are occupied by a pixel already
            // if one of the spaces are empty, then allow pixel creation
            if(GetPixelByCol(pixel.Col) == null && GetPixelByRow(pixel.Row) == null)
            {
                _context.Add(pixel);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool DeletePixelById(int id)
        {
            Pixel? pixel = GetPixelById(id);
            if(pixel != null)
            {
                _context.Remove(pixel);
                return true;
            }
            return false;
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