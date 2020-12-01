using System;
using Xunit;
using Moq;
using API.Interfaces;
using API.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace XUnitTestKeena
{
    public class DoctorControllerTest
    {
        private Mock<IUnitOfWork> unitOfWorkMock;        
        private IEnumerable<Doctor> doctors;
        private DoctorController controller;
        public DoctorControllerTest()
        {
            unitOfWorkMock = new Mock<IUnitOfWork>();
            controller = new DoctorController(unitOfWorkMock.Object);
            doctors = new List<Doctor>
            {
                new Doctor("San", "Bui", true, "Seattle", "san@gmail.com", "2067474685"),
                new Doctor("Duc", "Bui", false, "Denver", "duc@gmail.com"),
                new Doctor("Tien", "Nguyen", true, "HaNoi", "tien@gmail.com", "206206026", null),

            };          
        }      

        [Fact]
        public async Task GetByIdAsync_ShouldReturnDoctor_WhenDoctorExits()
        {
            //Arrange
            int docId = 1;
            Doctor newDoc = new Doctor { FirstName = "San", LastName = "Bui" };            
            unitOfWorkMock.Setup(x => x.Doctor.GetByIdAsync(docId))
                .ReturnsAsync(newDoc);
            //Act
            var result = await controller.GetDoctorById(1);

            //Assert
            var actionResult = Assert.IsType<ActionResult<Doctor>>(result);
            var returnValue = Assert.IsType<Doctor>(actionResult.Value);
            Assert.Equal("San", returnValue.FirstName);
        }
        [Fact]
        public async Task GetByIdAsync_ShouldReturnNotihng_WhenDoctorDoesNotExits()
        {
            //Arrange
            unitOfWorkMock.Setup(x => x.Doctor.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            //Act
            Doctor testProduct = await unitOfWorkMock.Object.Doctor.GetByIdAsync(1);
            //Assert
            Assert.Null(testProduct);
            
        }
                
        [Fact]
        public async Task GetAll_ShouldReturnAllDoctor()
        {            
            //Arrange            
            unitOfWorkMock.Setup(a => a.Doctor.GetAllAsync()).ReturnsAsync(doctors);

            //Act
            var result = await controller.GetAll();

            //Assert            
            var objectResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom <IEnumerable<Doctor>> (objectResult.Value);
            Assert.Equal(3, model.Count());

        }             

        [Fact]
        public async Task Delete_ReturnsOkResult_IfDeleteSuccess()
        {
            //Arrange 
            Doctor doctorRemove = new Doctor { Id = 1, FirstName = "San", LastName = "Bui" };
            var controller = new DoctorController(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(x => x.Doctor.DeleteAsync(doctorRemove.Id)).ReturnsAsync(doctorRemove);
            //Act
            var result = await controller.Delete(doctorRemove.Id);
            //Assert
            var actionResult = Assert.IsType<ActionResult<Doctor>>(result);
            var returnValue = Assert.IsType<Doctor>(actionResult.Value);
            Assert.Equal("San", returnValue.FirstName);
            
        }
        [Fact]
        public async Task Delete_returnsNotFound_IfIdNotFound()
        {
            //Arrange
            Doctor doctorRemove = new Doctor { Id = 1, FirstName = "San", LastName = "Hip" };
            var controller = new DoctorController(unitOfWorkMock.Object);
            unitOfWorkMock.Setup(x => x.Doctor.DeleteAsync(doctorRemove.Id)).ReturnsAsync(doctorRemove);
            //Act
            var result = await controller.Delete(It.IsAny<int>());
            //Assert
            var statusCodeResult = result.Result as StatusCodeResult;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }
        //[Fact]
        //public async Task Delete_ThrowsException_IfIdNotFound()
        //{            
        //    var controller = new DoctorController(unitOfWorkMock.Object);
        //    unitOfWorkMock.Setup(x => x.Doctor.DeleteAsync(It.IsAny<int>())).ThrowsAsync(new HttpRequestException());
        //    // Act
        //    var result = await controller.Delete(It.IsAny<int>());
        ////    // Assert                       
        //    var statusCodeResult = result.Result as StatusCodeResult;            
        //    Assert.Equal(400, statusCodeResult.StatusCode);
        ///}
        [Fact]
        public async Task Insert_ReturnsOkResult()
        {
            //Arrange
            var controller = new DoctorController(unitOfWorkMock.Object);
            Doctor doc = new Doctor() { FirstName = "San", LastName = "Bui", Email = "san@gmail.com", Address = "1203 SW 349th ST", Gender = true };
            unitOfWorkMock.Setup(x => x.Doctor.InsertAsync(doc)).ReturnsAsync(doc);
            //Act
            var result = await controller.Insert(doc);
            //Assert
            //var actionResult = Assert.IsType<ActionResult<Doctor>>(result.Result.Value);
            var objectResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnValue = Assert.IsType<Doctor>(objectResult.Value);
            //var returnValue = Assert.IsType<Doctor>(result.Result);
            Assert.Equal("San", returnValue.FirstName);
            Assert.Equal("Bui", returnValue.LastName);
        }
        [Fact]
        public async Task Update_ReturnOkResult()
        {
            var controller = new DoctorController(unitOfWorkMock.Object);
            Doctor doc = new Doctor() { FirstName = "San", LastName = "Bui", Email = "san@gmail.com", Address = "1203 SW 349th ST", Gender = true };
            unitOfWorkMock.Setup(x => x.Doctor.UpdateAsync(doc)).ReturnsAsync(doc);
            //Act
            var result = await controller.Update(doc);
            //Assert
            var objectResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnValue = Assert.IsType<Doctor>(objectResult.Value);
            Assert.Equal("San", returnValue.FirstName);
            Assert.Equal("Bui", returnValue.LastName);
        }
    }
}
