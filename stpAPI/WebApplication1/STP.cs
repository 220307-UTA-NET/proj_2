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


        #endregion
    }
}
