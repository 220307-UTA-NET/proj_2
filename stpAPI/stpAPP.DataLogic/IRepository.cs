using stpApp.BusinessLogic;
using System.Collections.Generic;
namespace stpAPP.DataLogic
{
    public interface IRepository
    {
        #region // User Methods
        /* 
            <summary>

        Queries database for ALL records of users in database into list.
        
            </summary>
        */
        List<UserAcc> GetAllUserAcc();
        UserAcc GetUserById(int id);
        /* 
            <summary>

        Queries database to see if a username is in the UserAcc table. False, if no records.
        True, if found. 
        
            </summary>
        */
        bool CheckUsername(string username);

        /* 
            <summary>

        Allows to put in a UserAcc object and a input string to find the user to update.
        Input string can either be the username of the individual to be altered or their Id.
        
            </summary>
        */
        void UpdateOneUser(UserAcc changes, string input);

        /* 
            <summary>

        Allows to insert on user object. This will check the database if there is an existing user
        If username, 
        
            </summary>
         */
        bool InsertOneUser(UserAcc user);
        /* 
            <summary>

        Delete a user by their id
        
            </summary>
         */
        void DeleteUser(int id);
        /* 
            <summary>

        Insert the user's id to check if they can change a color. Check if the DateTime on
        the lastPlace is null. If null, then a check is done if request greater than 5 minutes.

        This method is to be nested in a Pixel method to change a color.
        
            </summary>
         */
        bool PlaceColorUser(int id);
        #endregion
        #region // Pixel Methods
        List<Pixel> GetAllPixels();
        #endregion
        #region // Guest Methods
        List<Guest> GetAllGuests();
        #endregion
    }
}