using Xunit;
using System;
using stpApp.BusinessLogic;
using Moq;
using stpAPP.DataLogic;
using stpAPP.API;
using System.Collections;
using System.Collections.Generic;

namespace stpAPP.UnitTest
{
    public class UnitTest1
    {

        #region   // Basic Testing: Test Classes Properties
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

        
        [Fact]
        public void TestPixelProperties()
        {
            // ARRANGE
            int id = 234;
            string color = "red";
            DateTime createdAt = DateTime.Now;
            DateTime updatedAt = DateTime.Now;
            string updatedBy = "Donald";

            // ACT
            Pixel pixel = new Pixel();
            pixel.Id = id;
            pixel.Color = color;
            pixel.CreatedAt = createdAt;
            pixel.UpdatedAt = updatedAt;
            pixel.UpdatedBy = updatedBy;

            // ASSERT
            Assert.Equal(pixel.Id, id);
            Assert.Equal(pixel.Color, color);
            Assert.Equal(pixel.CreatedAt, createdAt);
            Assert.Equal(updatedBy, pixel.UpdatedBy);
            Assert.Equal(pixel.UpdatedAt, updatedAt);
        }

        
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
        #endregion


        #region   // Mock Testing UserAcc Methods
        [Fact]
        public void Test_GetAllUserAcc_Mock() {
            // ARRANGE
            List<UserAcc> userAccList = new List<UserAcc>();
            userAccList.Add(new UserAcc(123, "Charles", "pw123", DateTime.Now, DateTime.Now, DateTime.Now));
            userAccList.Add(new UserAcc(24, "John", "pw234", DateTime.Now, DateTime.Now, DateTime.Now));
            Mock<IRepository> mockRepo = new();
            mockRepo.Setup(x => x.GetAllUserAcc()).Returns(userAccList);
            STP stp = new STP(mockRepo.Object);

            // ACT
            List<UserAcc> list = stp.GetAllUserAcc();

            // ASSERT
            //Check for collection is not empty
            Assert.NotEmpty(list);

            //Check for collection count
            Assert.Equal(2, list.Count);

            //Check for collection contain some specific values
            Assert.Contains(userAccList[0], list);
            Assert.Contains(userAccList[1], list);

            //Check if list object contains a value
            string actualUsername1 = list[0].Username;
            string actualPassword1 = list[0].Password;
            string actualUsername2 = list[1].Username;
            string actualPassword2 = list[1].Password;
            Assert.Equal("Charles", actualUsername1);
            Assert.Equal("pw123", actualPassword1);
            Assert.Equal("John", actualUsername2);
            Assert.Equal("pw234", actualPassword2);
        }


        [Fact]
        public void Test_GetUserById_Mock()
        {
            // ARRANGE
            DateTime expectedLastPlace = DateTime.Now;
            DateTime expectedCreatedAt = DateTime.Now;
            DateTime expectedUpdatedAt = DateTime.Now;
            Mock<IRepository> mockRepo = new();
            mockRepo.Setup(x => x.GetUserById(567)).Returns(new UserAcc(123, "Charles", "pw123", expectedLastPlace, expectedCreatedAt, expectedUpdatedAt));
            STP stp = new STP(mockRepo.Object);

            // ACT
            UserAcc? userAcc = stp.GetUserById(567);
            int actualId = userAcc.Id;
            string actualUsername = userAcc.Username;
            string actualPassword = userAcc.Password;
            DateTime? actualLastPlace = userAcc.LastPlace;
            DateTime? actualCreatedAt = userAcc.CreatedAt;
            DateTime? actualUpdatedAt = userAcc.UpdatedAt;

            // ASSERT
            Assert.Equal(123, actualId);
            Assert.Equal("Charles", actualUsername);
            Assert.Equal("pw123", actualPassword);
            Assert.Equal(expectedLastPlace, actualLastPlace);
            Assert.Equal(expectedCreatedAt, actualCreatedAt);
            Assert.Equal(expectedUpdatedAt, actualUpdatedAt);
        }


        [Fact]
        public void Test_GetUserByUsername_Mock()
        {
            // ARRANGE
            DateTime expectedLastPlace = DateTime.Now;
            DateTime expectedCreatedAt = DateTime.Now;
            DateTime expectedUpdatedAt = DateTime.Now;
            Mock<IRepository> mockRepo = new();
            mockRepo.Setup(x => x.GetUserByUsername("John")).Returns(new UserAcc(24, "John", "pw234", expectedLastPlace, expectedCreatedAt, expectedUpdatedAt));
            STP stp = new STP(mockRepo.Object);

            // ACT
            UserAcc? userAcc = stp.GetUserByUsername("John");
            int actualId = userAcc.Id;
            string actualUsername = userAcc.Username;
            string actualPassword = userAcc.Password;
            DateTime? actualLastPlace = userAcc.LastPlace;
            DateTime? actualCreatedAt = userAcc.CreatedAt;
            DateTime? actualUpdatedAt = userAcc.UpdatedAt;

            // ASSERT
            Assert.Equal(24, actualId);
            Assert.Equal("John", actualUsername);
            Assert.Equal("pw234", actualPassword);
            Assert.Equal(expectedLastPlace, actualLastPlace);
            Assert.Equal(expectedCreatedAt, actualCreatedAt);
            Assert.Equal(expectedUpdatedAt, actualUpdatedAt);
        }

        [Fact]
        public void Test_CheckUsername_Mock()
        {
            // ARRANGE
            Mock<IRepository> mockRepo = new();
            mockRepo.Setup(x => x.CheckUsername("Charles")).Returns(true);
            STP stp = new STP(mockRepo.Object);
            //CheckUsername

            // ACT
            bool actual = stp.CheckUsername("Charles");

            // ASSERT
            Assert.True(actual);
        }

        [Fact]
        public void Test_InsertOneUser_Mock()
        {
            // ARRANGE
            UserAcc userAcc = new UserAcc(45, "Williams", "pw89", DateTime.Now, DateTime.Now, DateTime.Now);
            Mock<IRepository> mockRepo = new();
            mockRepo.Setup(x => x.InsertOneUser(userAcc)).Returns(false);
            STP stp = new STP(mockRepo.Object);
            //CheckUsername

            // ACT
            bool actual = stp.InsertOneUser(userAcc);

            // ASSERT
            Assert.False(actual);
        }


        [Fact]
        public void Test_DeleteUser_Mock() 
        { 
            // ARRANGE
            Mock<IRepository> mockRepo = new();
            mockRepo.Setup(x => x.DeleteUser(45)).Returns(true);
            STP stp = new STP(mockRepo.Object);

            // ACT
            bool actual = stp.DeleteUser(45);

            // ASSERT
            Assert.True(actual);
        }


        [Fact]
        public void Test_CanUserColorChange_Mock()
        {
            // ARRANGE
            Mock<IRepository> mockRepo = new();
            mockRepo.Setup(x => x.CanUserColorChange(45)).Returns(true);
            STP stp = new STP(mockRepo.Object);

            // ACT
            bool actual = stp.CanUserColorChange(45);

            // ASSERT
            Assert.True(actual);

        }
        #endregion


        #region   // Mock Testing Pixel Methods
        [Fact]
        public void Test_GetAllPixels_Mock()
        {
            // ARRANGE
            List<Pixel> pixelList = new List<Pixel>();
            pixelList.Add(new Pixel(12, "yellow", DateTime.Now, DateTime.Now, "Charles"));
            pixelList.Add(new Pixel(24, "red", DateTime.Now, DateTime.Now, "Williams"));
            Mock<IRepository> mockRepo = new();
            mockRepo.Setup(x => x.GetAllPixels()).Returns(pixelList);
            STP stp = new STP(mockRepo.Object);

            // ACT
            List<Pixel> list = stp.GetAllPixels();

            // ASSERT
            //Check for collection is not empty
            Assert.NotEmpty(list);

            //Check for collection count
            Assert.Equal(2, list.Count);

            //Check for collection contain some specific values
            Assert.Contains(pixelList[0], list);
            Assert.Contains(pixelList[1], list);

            //Check if list object contains a value
            int actualId1 = list[0].Id;
            string actualColor1 = list[0].Color;
            string? actualUpdatedBy1 = list[0].UpdatedBy;
            int actualId2 = list[1].Id;
            string actualColor2 = list[1].Color;
            string? actualUpdatedBy2 = list[1].UpdatedBy;
            Assert.Equal(12, actualId1);
            Assert.Equal("yellow", actualColor1);
            Assert.Equal("Charles", actualUpdatedBy1);
            Assert.Equal(24, actualId2);
            Assert.Equal("red", actualColor2);
            Assert.Equal("Williams", actualUpdatedBy2);
        }

        [Fact]
        public void Test_GetPixelById_Mock()
        {
            // ARRANGE
            DateTime expectedCreatedAt = DateTime.Now;
            DateTime expectedUpdatedAt = DateTime.Now;
            Mock<IRepository> mockRepo = new();
            mockRepo.Setup(x => x.GetPixelById(56)).Returns(new Pixel(56, "blue", expectedCreatedAt, expectedUpdatedAt, "Bibi"));
            STP stp = new STP(mockRepo.Object);

            // ACT
            Pixel? pixel = stp.GetPixelById(56);
            int actualId = pixel.Id;
            string actualColor = pixel.Color;
            DateTime? actualCreatedAt = pixel.CreatedAt;
            DateTime? actualUpdatedAt = pixel.UpdatedAt;
            string? actualUpdatedBy = pixel.UpdatedBy; ;

            // ASSERT
            Assert.Equal(56, actualId);
            Assert.Equal("blue", actualColor);
            Assert.Equal(expectedCreatedAt, actualCreatedAt);
            Assert.Equal(expectedUpdatedAt, actualUpdatedAt);
            Assert.Equal("Bibi", actualUpdatedBy);
        }


        [Fact]
        public void Test_ChangePixelColorByUser_Mock()
        {
            // ARRANGE
            Mock<IRepository> mockRepo = new();
            mockRepo.Setup(x => x.ChangePixelColorByUser(56, 123, "#1cfc03")).Returns(true);
            STP stp = new STP(mockRepo.Object);

            // ACT
            bool actual = stp.ChangePixelColorByUser(56, 123, "#1cfc03");

            // ASSERT
            Assert.True(actual);
        }

        [Fact]
        public void Test_ChangePixelColorByGuest_Mock()
        {
            // ARRANGE
            Mock<IRepository> mockRepo = new();
            mockRepo.Setup(x => x.ChangePixelColorByGuest(44, 12, "#0341fc")).Returns(false);
            STP stp = new STP(mockRepo.Object);

            // ACT
            bool actual = stp.ChangePixelColorByGuest(44, 12, "#0341fc");

            // ASSERT
            Assert.False(actual);
        }

        [Fact]
        public void Test_InsertPixel_Mock()
        {
            // ARRANGE
            Pixel pixel = new Pixel(45, "black", DateTime.Now, DateTime.Now, "user");
            Mock<IRepository> mockRepo = new();
            mockRepo.Setup(x => x.InsertPixel(pixel)).Returns(true);
            STP stp = new STP(mockRepo.Object);
            //CheckUsername

            // ACT
            bool actual = stp.InsertPixel(pixel);

            // ASSERT
            Assert.True(actual);
        }

        [Fact]
        public void Test_DeletePixelById_Mock()
        {
            // DeletePixelById(int id)
            // ARRANGE
            Mock<IRepository> mockRepo = new();
            mockRepo.Setup(x => x.DeletePixelById(45)).Returns(true);
            STP stp = new STP(mockRepo.Object);

            // ACT
            bool actual = stp.DeletePixelById(45);

            // ASSERT
            Assert.True(actual);
        }

        #endregion


        #region   // Mock Testing Guest Methods

        [Fact]
        public void Test_GetAllGuests_Mock()
        {
            // ARRANGE
            List<Guest> guestList = new List<Guest>();
            guestList.Add(new Guest(01, DateTime.Now, "123.0.0.5", DateTime.Now, DateTime.Now));
            guestList.Add(new Guest(05, DateTime.Now, "124.0.0.7", DateTime.Now, DateTime.Now));
            Mock<IRepository> mockRepo = new();
            mockRepo.Setup(x => x.GetAllGuests()).Returns(guestList);
            STP stp = new STP(mockRepo.Object);

            // ACT
            List<Guest> list = stp.GetAllGuests();

            // ASSERT
            //Check for collection is not empty
            Assert.NotEmpty(list);

            //Check for collection count
            Assert.Equal(2, list.Count);

            //Check for collection contain some specific values
            Assert.Contains(guestList[0], list);
            Assert.Contains(guestList[1], list);

            //Check if list object contains a value
            int actualId1 = list[0].Id;
            string actualIpAdress1 = list[0].IpAddress;
            int actualId2 = list[1].Id;
            string actualIpAdress2 = list[1].IpAddress;

            // ASSERT
            Assert.Equal(01, actualId1);
            Assert.Equal("123.0.0.5", actualIpAdress1);
            Assert.Equal(05, actualId2);
            Assert.Equal("124.0.0.7", actualIpAdress2);
        }

        [Fact]
        public void Test_GetGuestById_Mock()
        {
            // ARRANGE
            DateTime expectedLastPlace = DateTime.Now;
            DateTime expectedCreatedAt = DateTime.Now;
            DateTime expectedUpdatedAt = DateTime.Now;
            Mock<IRepository> mockRepo = new();
            mockRepo.Setup(x => x.GetGuestById(10)).Returns(new Guest(10, expectedLastPlace, "123. 0.0.0.3", expectedCreatedAt, expectedUpdatedAt));
            STP stp = new STP(mockRepo.Object);

            // ACT
            Guest? guest = stp.GetGuestById(10);
            int actualId = guest.Id;
            DateTime? actualLasPlace = guest.LastPlace;
            string actualIpAdress = guest.IpAddress;
            DateTime? actualCreatedAt = guest.CreatedAt;
            DateTime? actualUpdatedAt = guest.UpdatedAt;

            // ASSERT
            Assert.Equal(10, actualId);
            Assert.Equal(expectedLastPlace, actualLasPlace);
            Assert.Equal("123. 0.0.0.3", actualIpAdress);
            Assert.Equal(expectedCreatedAt, actualCreatedAt);
            Assert.Equal(expectedUpdatedAt, actualUpdatedAt);
        }

        [Fact]
        public void Test_CreateGuestbyIp_Mock()
        {
            // ARRANGE
            Mock<IRepository> mockRepo = new();
            mockRepo.Setup(x => x.CreateGuestbyIp(null)).Returns(true);
            STP stp = new STP(mockRepo.Object);

            // ACT
            bool actual = stp.CreateGuestbyIp(null);

            // ASSERT
            Assert.True(actual);
        }

        [Fact]
        public void Test_CanGuestColorChange_Mock()
        {
            // ARRANGE
            Mock<IRepository> mockRepo = new();
            mockRepo.Setup(x => x.CanGuestColorChange(11)).Returns(true);
            STP stp = new STP(mockRepo.Object);

            // ACT
            bool actual = stp.CanGuestColorChange(11);

            // ASSERT
            Assert.True(actual);
        }

        [Fact]
        public void Test_UpdateGuestById_Mock()
        {
            // ARRANGE
            Guest changes = new Guest();
            changes.IpAddress = "234.0.0.0.1";
            changes.LastPlace = DateTime.Now;
            Mock<IRepository> mockRepo = new();
            mockRepo.Setup(x => x.UpdateGuestById(changes, 12)).Returns(true);
            STP stp = new STP(mockRepo.Object);

            // ACT
            bool actual = stp.UpdateGuestById(changes, 12);

            // ASSERT
            Assert.True(actual);
        }

        [Fact]
        public void Test_DeleteGuestById_Mock()
        {
            // ARRANGE
            Mock<IRepository> mockRepo = new();
            mockRepo.Setup(x => x.DeleteGuestById(10)).Returns(true);
            STP stp = new STP(mockRepo.Object);

            // ACT
            bool actual = stp.DeleteGuestById(10);

            // ASSERT
            Assert.True(actual);
        }

        #endregion


        #region  //  Mock Testing Message Methods
        [Fact]
        public void Test_GetAllMessages_Mock()
        {
            // ARRANGE
            List<Message> messageList = new List<Message>();
            messageList.Add(new Message(5, "message1", 43, DateTime.Now, DateTime.Now));
            messageList.Add(new Message(6, "message2", 43, DateTime.Now, DateTime.Now));
            Mock<IRepository> mockRepo = new();
            mockRepo.Setup(x => x.GetAllMessages()).Returns(messageList);
            STP stp = new STP(mockRepo.Object);

            // ACT
            List<Message> list = stp.GetAllMessages();

            // ASSERT
            //Check for collection is not empty
            Assert.NotEmpty(list);

            //Check for collection count
            Assert.Equal(2, list.Count);

            //Check for collection contain some specific values
            Assert.Contains(messageList[0], list);
            Assert.Contains(messageList[1], list);

            //Check if list object contains a value
            int actualId1 = list[0].Id;
            int actualId2 = list[1].Id;
            string actualmsgContent1 = list[0].messageContents;
            string actualmsgContent2 = list[1].messageContents;
            
            Assert.Equal(5, actualId1);
            Assert.Equal(6, actualId2);
            Assert.Equal(list[0].UserId, list[1].UserId);
            Assert.Equal("message1", actualmsgContent1);
            Assert.Equal("message2", actualmsgContent2);
        }

        [Fact]
        public void Test_GetMessagebyId_Mock()
        {
            // ARRANGE
            DateTime expectedUpdatedAt = DateTime.Now;
            DateTime expectedCreatedAt = DateTime.Now;
            Mock<IRepository> mockRepo = new();
            mockRepo.Setup(x => x.GetMessagebyId(6)).Returns(new Message(6, "message2", 43, expectedCreatedAt, expectedUpdatedAt));
            STP stp = new STP(mockRepo.Object);

            // ACT
            Message? message = stp.GetMessagebyId(6);
            int actualId = message.Id;
            string actualMsgContents = message.messageContents;
            int actualUserId = message.UserId;
            DateTime? actualCreatedAt = message.CreatedAt;
            DateTime? actualUpdatedAt = message.UpdatedAt;

            // ASSERT
            Assert.Equal(6, actualId);
            Assert.Equal("message2", actualMsgContents);
            Assert.Equal(43, actualUserId);
            Assert.Equal(expectedCreatedAt, actualCreatedAt);
            Assert.Equal(expectedUpdatedAt, actualUpdatedAt);
        }

        [Fact]
        public void Test_InsertMessage_Mock()
        {
            // ARRANGE
            Message message = new Message(7, "message3", 43, DateTime.Now, DateTime.Now);
            Mock<IRepository> mockRepo = new();
            mockRepo.Setup(x => x.InsertMessage(message)).Returns(true);
            STP stp = new STP(mockRepo.Object);

            // ACT
            bool actual = stp.InsertMessage(message);

            // ASSERT
            Assert.True(actual);
        }

        [Fact]
        public void Test_UpdateMessage_Mock()
        {
            // ARRANGE
            DateTime expectedUpdatedAt = DateTime.Now;
            DateTime expectedCreatedAt = DateTime.Now;
            Mock<IRepository> mockRepo = new();
            mockRepo.Setup(x => x.GetMessagebyId(6)).Returns(new Message(6, "message2", 43, expectedCreatedAt, expectedUpdatedAt));
            STP stp = new STP(mockRepo.Object);

            Message? changes = stp.GetMessagebyId(6);

            Mock<IRepository> mockRepo2 = new();
            mockRepo2.Setup(x => x.UpdateMessage(changes)).Returns(true);
            STP stp2 = new STP(mockRepo2.Object);

            // ACT
            bool actual = stp2.UpdateMessage(changes);

            // ASSERT
            Assert.True(actual);
        }

        [Fact]
        public void Test_DeleteMessagebyId_Mock()
        {
            // ARRANGE
            Mock<IRepository> mockRepo = new();
            mockRepo.Setup(x => x.DeleteMessagebyId(55)).Returns(false);
            STP stp = new STP(mockRepo.Object);

            // ACT
            bool actual = stp.DeleteMessagebyId(55);

            // ASSERT
            Assert.False(actual);
        }

        #endregion
    }
}