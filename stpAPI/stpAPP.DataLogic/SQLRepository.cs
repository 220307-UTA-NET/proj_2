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
        public UserAcc? Login(string username, string password)
        {
            UserAcc? user = _context.UserAccs.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
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
                        _context.SaveChanges();
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
        public bool ChangePixelColorByGuest(int Pid, int Gid, string hexcolor)
        {
            Pixel? pixel = GetPixelById(Pid);
            // check if pixel object to be changed is not null
            // check if guest's 2 minute restriction has passed
            if (pixel != null && CanGuestColorChange(Gid))
            {
                pixel.Color = hexcolor;
                pixel.UpdatedAt = DateTime.Now;
                pixel.UpdatedBy = "Guest";
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool InsertPixel(Pixel pixel)
        {
            try
            {
                _context.Add(pixel);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool DeletePixelById(int id)
        {
            Pixel? pixel = GetPixelById(id);
            if(pixel != null)
            {
                _context.Remove(pixel);
                _context.SaveChanges();
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
        public Guest? GetGuestById(int id)
        {
            return _context.Guests.FirstOrDefault(x => x.Id == id);
        }
        public Guest? GetGuestByIp(string ip)
        {
            return _context.Guests.FirstOrDefault(x => x.IpAddress == ip);
        }
        public bool CanGuestColorChange(int id)
        {
            Guest? RetrievedGuest = GetGuestById(id);
            if (RetrievedGuest == null)
            {
                return false;
            }
            else
            {
                if (RetrievedGuest.LastPlace == null)
                {
                    RetrievedGuest.LastPlace = DateTime.Now;
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    if (RetrievedGuest.LastPlace.Value.AddSeconds(5) <= DateTime.Now)
                    {
                        RetrievedGuest.LastPlace = DateTime.Now;
                        _context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        public bool CreateGuestbyIp(string ip)
        {
            if(GetGuestByIp(ip) == null)
            {
                Guest guest = new Guest();
                guest.IpAddress = ip;
                guest.LastPlace = DateTime.Now;
                _context.Guests.Add(guest);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool UpdateGuestById(Guest changes, int id)
        {
            Guest? guest = GetGuestById(id);
            if(guest != null)
            {
                guest.IpAddress = changes.IpAddress;
                guest.LastPlace = changes.LastPlace;
                guest.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool DeleteGuestById(int id)
        {
            Guest? guest = GetGuestById(id);
            if(guest != null)
            {
                _context.Guests.Remove(guest);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion
        #region // Message Methods
        public List<Message> GetAllMessages()
        {
            return _context.Messages.ToList();
        }
        public Message? GetMessagebyId(int id)
        {
            return _context.Messages.FirstOrDefault(m => m.Id == id);
        }
        public bool InsertMessage(Message message)
        {
            try
            {
                _context.Messages.Add(message);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateMessage(Message changes)
        {
            Message? original = GetMessagebyId(changes.Id);
            if(original != null)
            {
                original.UserId = changes.UserId;
                original.UpdatedAt = DateTime.Now;
                original.messageContents = changes.messageContents;
                _context.Update(original);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool DeleteMessagebyId(int id)
        {
            Message? message = GetMessagebyId(id);
            if(message != null)
            {
                _context.Remove(message);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion
    }
}