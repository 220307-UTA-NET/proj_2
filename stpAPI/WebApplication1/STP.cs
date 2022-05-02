using stpApp.BusinessLogic;
using stpAPP.DataLogic;

namespace stpAPP.API
{
    public class STP
    {
        private readonly IRepository _repo;

        public STP(IRepository repo)
        {
            this._repo = repo;
        }


        #region   //  UserAcc Methods
        public List<UserAcc> GetAllUserAcc() { return _repo.GetAllUserAcc(); }

        public UserAcc? GetUserById(int id) { return _repo.GetUserById(id); }

        public UserAcc? GetUserByUsername(string username) { return _repo.GetUserByUsername(username); }

        public bool CheckUsername(string username) { return _repo.CheckUsername(username); }

        public void UpdateUser(UserAcc changes, string input) { this._repo.UpdateOneUser(changes, input); }

        public bool InsertOneUser(UserAcc user) { return _repo.InsertOneUser(user); }

        public bool DeleteUser(int id) { return _repo.DeleteUser(id); }

        public bool CanUserColorChange(int id) { return _repo.CanUserColorChange(id); }
        #endregion


        #region   // Pixel Methods
        public List<Pixel> GetAllPixels() { return _repo.GetAllPixels(); }

        public Pixel? GetPixelById(int id) { return _repo.GetPixelById(id); }

        public bool ChangePixelColorByUser(int Pid, int Uid, string hexcolor) { return _repo.ChangePixelColorByUser(Pid, Uid, hexcolor); } 

        public bool ChangePixelColorByGuest(int Pid, int Gid, string hexcolor) { return _repo.ChangePixelColorByGuest(Pid, Gid, hexcolor); }   
        
        public bool InsertPixel(Pixel pixel) { return _repo.InsertPixel(pixel); }
        public bool DeletePixelById(int id) { return _repo.DeletePixelById(id); }
        #endregion


        #region   //   Guest Methods

        public List<Guest> GetAllGuests() { return _repo.GetAllGuests(); }

        public Guest? GetGuestById(int id) { return _repo.GetGuestById(id); }

        public bool CreateGuestbyIp(string ip) { return _repo.CreateGuestbyIp(ip); }

        public bool CanGuestColorChange(int id) { return _repo.CanGuestColorChange(id);}

        public bool UpdateGuestById(Guest changes, int id) { return _repo.UpdateGuestById(changes, id); }

        public bool DeleteGuestById(int id) { return _repo.DeleteGuestById(id); }

        #endregion

    }
}
