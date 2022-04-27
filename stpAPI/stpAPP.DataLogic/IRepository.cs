using stpApp.BusinessLogic;
using System.Collections.Generic;
namespace stpAPP.DataLogic
{
    public interface IRepository
    {
        #region // User Methods
        List<UserAcc> GetAllUserAcc();
        UserAcc GetOneUser(int id);
        void UpdateOneUser(UserAcc changes, int id);
        void InsertOneUser(UserAcc user);
        void PlaceColorUser(int id);
        #endregion
        #region // Pixel Methods
        List<Pixel> GetAllPixels();
        #endregion
        #region // Guest Methods
        List<Guest> GetAllGuests();
        #endregion
    }
}