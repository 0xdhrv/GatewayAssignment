using Moq;
using Newtonsoft.Json;
using Passenger_Management_App.Controllers;
using Passenger_Management_App.Models;
using Passenger_Management_App.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Xunit;

namespace xUnitTestProject
{
    
    public class PassengerControllerTest
    {
        private readonly Mock<IPassengerRepository> mockPassengerRepository = new Mock<IPassengerRepository>();
        private readonly ApiPassengerController _passengerController;

        public PassengerControllerTest()
        {
            _passengerController = new ApiPassengerController(mockPassengerRepository.Object);
        }

        [Fact]
        public void Test_GetPassengers_Positive()
        {
            var resultObj = mockPassengerRepository.Setup(x => x.GetPassengers()).Returns(GetPassengers());

            var response = _passengerController.Get();

            Assert.Equal(3, response.Count);

        }

        [Fact]
        public void Test_GetPassengers_Negative()
        {
            var resultObj = mockPassengerRepository.Setup(x => x.GetPassengers()).Returns(GetPassengers());

            var response = _passengerController.Get();

            Assert.Equal(4, response.Count);

        }

        [Fact]
        public void Test_GetPassengeryId_Positive()
        {
            var passenger = new Passenger() { Id = 1, PassengerNo = "PX53512", FirstName = "Faizan", LastName = "Sharma", Phone = "9696969696" };
            var resultObj = mockPassengerRepository.Setup(x => x.GetPassenger(passenger.Id)).Returns(passenger);

            //Act
            var response = _passengerController.Get(passenger.Id);
            var isNull = Assert.IsType<OkNegotiatedContentResult<Passenger>>(response);

            //Assert
            Assert.NotNull(isNull);

        }

        [Fact]
        public void Test_GetPassengeryId_Negative()
        {
            //Arrange
            var passenger = new Passenger() { Id = 1, PassengerNo = "PX53512", FirstName = "Faizan", LastName = "Sharma", Phone = "9696969696" };
            var resultObj = mockPassengerRepository.Setup(x => x.GetPassenger(passenger.Id)).Returns(passenger);

            //Act
            var response = _passengerController.Get(passenger.Id);
            var isNull = Assert.IsType<OkNegotiatedContentResult<Passenger>>(response);

            //Assert
            Assert.Null(isNull);

        }

        [Fact]
        public void Test_AddUser_Positive()
        {
            //Arrange
            var passenger = new Passenger() { Id = 0, PassengerNo = "PX53512", FirstName = "Ramesh", LastName = "Sharma", Phone = "9696969696" };
            var resultObj = mockPassengerRepository.Setup(x => x.AddorEditPassenger(passenger)).Returns(passenger);

            //Act
            var response = _passengerController.Post(passenger);

            //Assert
            Assert.Equal("Ramesh",response.FirstName);
        }
        [Fact]
        public void Test_AddUser_Negative()
        {
            //Arrange
            var passenger = new Passenger() { Id = 0, PassengerNo = "PX53512", FirstName = "Ramesh", LastName = "Sharma", Phone = "9696969696" };
            var resultObj = mockPassengerRepository.Setup(x => x.AddorEditPassenger(passenger)).Returns(passenger);

            //Act
            var response = _passengerController.Post(passenger);

            //Assert
            Assert.Equal("Ramesh", response.FirstName);
        }

        [Fact]
        public void Test_UpdateUser_Positive()
        {
            //Arrange
            var passenger = new Passenger() { Id = 1, PassengerNo = "PX53512", FirstName = "Ramesh", LastName = "Sharma", Phone = "9696969696" };

            //Act
            var resultObj = mockPassengerRepository.Setup(x => x.AddorEditPassenger(passenger)).Returns(passenger);
            var response = _passengerController.Put(passenger);
           
            //Assert
            Assert.Equal(passenger.FirstName,response.FirstName);
        }
        [Fact]
        public void Test_UpdateUser_Negative()
        {
            //Arrange
            var passenger = new Passenger() { Id = 1, PassengerNo = "PX53512", FirstName = "Ramesh", LastName = "Sharma", Phone = "9696969696" };

            //Act
            var resultObj = mockPassengerRepository.Setup(x => x.AddorEditPassenger(passenger)).Returns(passenger);
            var response = _passengerController.Put(passenger);

            //Assert
            Assert.Equal("Ramesh", response.FirstName);
        }

        [Fact]
        public void Test_DeleteUser_Positive()
        {
            //Arrange
            var passenger = new Passenger() { Id = 1, PassengerNo = "PX53512", FirstName = "Ramesh", LastName = "Sharma", Phone = "9696969696" };

            //Act
            var resultObj = mockPassengerRepository.Setup(x => x.DeletePassenger(passenger.Id)).Returns(passenger);
            var response = _passengerController.Delete(passenger.Id);

            //Assert
            Assert.NotNull(response);
        }
        [Fact]
        public void Test_DeleteUser_Negative()
        {
            //Arrange
            var passenger = new Passenger() { Id = 1, PassengerNo = "PX53512", FirstName = "Ramesh", LastName = "Sharma", Phone = "9696969696" };

            //Act
            var resultObj = mockPassengerRepository.Setup(x => x.DeletePassenger(passenger.Id)).Returns(passenger);
            var response = _passengerController.Delete(passenger.Id);

            //Assert
            Assert.Null(response);
        }



        private static List<Passenger> GetPassengers()
        {
            List<Passenger> passengers = new List<Passenger>()
            {
                new Passenger(){Id=1,PassengerNo="PX53512",FirstName="Faizan",LastName="Sharma",Phone="9696969696"},
                new Passenger(){Id=2,PassengerNo="PX23214",FirstName="Jay",LastName="Smith",Phone="8484848484"},
                new Passenger(){Id=3,PassengerNo="PX45129",FirstName="Brethel",LastName="Khan",Phone="9191949191"}
            };
            return passengers;
        }

        private static Passenger AddPassenger()
        {

            var passenger = new Passenger() { Id = 0, PassengerNo = "PX53512", FirstName = "Ramesh", LastName = "Sharma", Phone = "9696969696" };
               
            return passenger;
        }
    }
}
