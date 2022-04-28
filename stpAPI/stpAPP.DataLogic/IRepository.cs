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
        /* 
            <summary>

        Queries database for one record of a user in database dependent on id
        
            </summary>
        */
        UserAcc? GetUserById(int id);
        /* 
            <summary>

        Queries database for one record of a user in database dependent on username
        
            </summary>
        */
        UserAcc? GetUserByUsername(string username);
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
        If username, is taken by another user in the table, method will return false. Otherwise,
        insertion will succeed and create new entry. 
        
            </summary>
         */
        bool InsertOneUser(UserAcc user);
        /* 
            <summary>

        Delete a user by their id. Returns true if user was found and could be deleted.
        Returns false, if user with id is not in database.
        
            </summary>
         */
        bool DeleteUser(int id);
        /* 
            <summary>

        Insert the user's id to check if they can change a color. Check if the DateTime on
        the lastPlace is null. If null, then a check is done if request greater than 5 minutes.

        This method is to be nested in a Pixel method to change a color. See Pixel Methods region for functionality details. 
        
            </summary>
         */
        bool CanUserColorChange(int id);
        #endregion
        #region // Pixel Methods
        /* 
            <summary>

            Queries database for ALL records of users in database into list.

            </summary>
        */
        List<Pixel> GetAllPixels();
        /* 
            <summary>

            Queries database for one record of a user dependent on id

            </summary>
        */
        Pixel? GetPixelById(int id);
        /* 
            <summary>

            Queries database for one record of a user dependent on Row number

            </summary>
        */
        Pixel? GetPixelByRow(int row_num);
        /* 
            <summary>

            Queries database for one record of a user dependent on Column number

            </summary>
        */
        Pixel? GetPixelByCol(int col_num);
        /* 
            <summary>

            Changes the given pixel's id to another color along with the user who updated
            the pixel. Uses CanUserColorChange method in User methods to check if enough
            time has passed according to 5 minute rule.

            </summary>
        */
        bool ChangePixelColorByUser(int Pid, int Uid, string hexcolor);
        /* 
            <summary>

            Inserts a new pixel which is dependent on if the given row and column number are empty

            </summary>
        */
        bool InsertPixel(Pixel pixel);
        /* 
            <summary>

            Deletes a pixel by the given id. Returns false if no record was found. 

            </summary>
        */
        bool DeletePixelById(int id);
        #endregion
        #region // Guest Methods
        List<Guest> GetAllGuests();
        #endregion
    }
}