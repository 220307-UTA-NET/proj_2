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

        //[Fact]
        //public void Test_UpdateOneUserAcc_Mock()
        //{
        //    // ARRANGE
        //    UserAcc userAcc = new UserAcc();
        //    string input = "JohnW";
        //    Mock<IRepository> mockRepo = new();
        //    mockRepo.Setup(x => x.UpdateOneUser(userAcc, input)).Returns();
        //    STP stp = new STP(mockRepo.Object);

        //    // ACT
        //    stp.UpdateUser(userAcc, input);

        //    // ASSERT
        //}


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
    }
}