using Xunit;
using System;
using stpApp.BusinessLogic;

namespace stpAPP.UnitTest
{
    public class UnitTest1
    {
        #region
        [Fact]
        public void TestGuestProperties()
        {
            // ARRANGE - any set up that is required to perform the test.
            int id = 123;
            DateTime lastPlace = DateTime.Now;
            string ipAddress = "123.1.1.1.1";
            DateTime createdAt = DateTime.Now;
            DateTime updatedAt = DateTime.Now;

            // ACT - where we invoke the behavior to test.
            // Guest guest = new Guest(id, lastPlace, ipAddress, createdAt, updatedAt);
            Guest guest = new Guest();
            guest.Id = id;
            guest.LastPlace = lastPlace;
            guest.IpAddress = ipAddress;
            guest.CreatedAt = createdAt;
            guest.UpdatedAt = updatedAt;

            // ASSERT - compare the result of the ACT to an expected value.
            Assert.Equal(guest.Id, id);
            Assert.Equal(guest.LastPlace, lastPlace);
            Assert.Equal(guest.IpAddress, ipAddress);
            Assert.Equal(guest.CreatedAt, createdAt);
            Assert.Equal(guest.UpdatedAt, updatedAt);
        }
        #endregion

        #region
        [Fact]
        public void TestPixelProperties()
        {
            // ARRANGE
            int id = 234;
            short row = 5;
            short col = 6;
            string color = "red";
            DateTime createdAt = DateTime.Now;
            DateTime updatedAt = DateTime.Now;
            string updatedBy = "Donald";

            // ACT
            Pixel pixel = new Pixel();
            pixel.Id = id;
            pixel.Row = row;
            pixel.Col = col;
            pixel.Color = color;
            pixel.CreatedAt = createdAt;
            pixel.UpdatedAt = updatedAt;
            pixel.UpdatedBy = updatedBy;

            // ASSERT
            Assert.Equal(pixel.Id, id);
            Assert.Equal(pixel.Row, row);
            Assert.Equal(pixel.Col, col);
            Assert.Equal(pixel.Color, color);
            Assert.Equal(pixel.CreatedAt, createdAt);
            Assert.Equal(updatedBy, pixel.UpdatedBy);
            Assert.Equal(pixel.UpdatedAt, updatedAt);
        }
        #endregion

        #region
        [Fact]
        public void TestUserAccProperties()
        {
            // ARRANGE
            int id = 345;
            string username = "DonaldK";
            string password = "password123";
            DateTime lastPlace = DateTime.Now;
            DateTime createdAt = DateTime.Now;
            DateTime lastUpdatedAt = DateTime.Now;

            // ACT
            UserAcc userAcc = new UserAcc();
            userAcc.Id = id;
            userAcc.Username = username;
            userAcc.Password = password;
            userAcc.LastPlace = lastPlace;
            userAcc.CreatedAt = createdAt;
            userAcc.UpdatedAt = lastUpdatedAt;

            // ASSERT
            Assert.Equal(userAcc.Id, id);
            Assert.Equal(userAcc.Username, username);
            Assert.Equal(userAcc.Password, password);
            Assert.Equal(userAcc.LastPlace, lastPlace);
            Assert.Equal(userAcc.CreatedAt, createdAt);
            Assert.Equal(userAcc.UpdatedAt, lastUpdatedAt);
        }
        #endregion

        [Fact]
        public void TestMessageProperties() {
            // ARRANGE
            int id = 456;
            string msgContents = "success";
            int userID = 567;
            DateTime createdAt = DateTime.Now;
            DateTime updatedAt = DateTime.Now;

            // ACT
            Message message = new Message();
            message.CreatedAt = createdAt;
            message.UpdatedAt = updatedAt;
            message.Id = id;
            message.UserId = userID;
            message.messageContents = msgContents;

            // ASSERT
            Assert.Equal(message.Id, id);
            Assert.Equal(message.messageContents, msgContents);
            Assert.Equal(message.CreatedAt, createdAt);
            Assert.Equal(message.UserId, userID);
            Assert.Equal(message.UpdatedAt, updatedAt);
        }
    }
}