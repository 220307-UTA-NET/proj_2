using stpApp.BusinessLogic;
using System.Collections.Generic;
namespace stpAPP.DataLogic
{
    public interface IRepository
    {
        List<UserAcc> GetAllUserAcc();
    }
}