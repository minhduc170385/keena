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
    public class PatientControllerTest
    {
        private Mock<IUnitOfWork> unitOfWorkMock;
        private IEnumerable<Patient> Patients;
        private PatientController controller;

        public PatientControllerTest()
        {
            unitOfWorkMock = new Mock<IUnitOfWork>();
            controller = new PatientController(unitOfWorkMock.Object);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnPatient_WhenPatientExits()
        {
            //Arrange
            int docId = 1;
            Patient patient = new Patient { FirstName = "San", LastName = "Bui" };
            unitOfWorkMock.Setup(x => x.Patient.GetByIdAsync(docId))
                .ReturnsAsync(patient);
            //Act
            var result = await controller.GetPatientById(1);

            //Assert
            var actionResult = Assert.IsType<ActionResult<Patient>>(result);
            var returnValue = Assert.IsType<Patient>(actionResult.Value);
            Assert.Equal("San", returnValue.FirstName);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNotihng_WhenPatientDoesNotExits()
        {
            //Arrange
            unitOfWorkMock.Setup(x => x.Patient.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(() => null);
            //Act
            Patient testProduct = await unitOfWorkMock.Object.Patient.GetByIdAsync(1);
            //Assert
            Assert.Null(testProduct);
        }

        [Fact]
        public async Task Delete_ReturnsOkResult_IfDeleteSuccess()
        {
            //Arrange 
            Patient patientRemove = new Patient { Id = 1, FirstName = "San", LastName = "Bui" };            
            unitOfWorkMock.Setup(x => x.Patient.DeleteAsync(patientRemove.Id)).ReturnsAsync(patientRemove);
            //Act
            var result = await controller.Delete(patientRemove.Id);
            //Assert
            var actionResult = Assert.IsType<ActionResult<Patient>>(result);
            var returnValue = Assert.IsType<Patient>(actionResult.Value);
            Assert.Equal("San", returnValue.FirstName);
        }

        [Fact]
        public async Task Delete_returnsNotFound_IfIdNotFound()
        {
            //Arrange
            Patient patientRemove = new Patient { Id = 1, FirstName = "San", LastName = "Hip" };            
            unitOfWorkMock.Setup(x => x.Patient.DeleteAsync(patientRemove.Id)).ReturnsAsync(patientRemove);
            //Act
            var result = await controller.Delete(It.IsAny<int>());
            //Assert
            var statusCodeResult = result.Result as StatusCodeResult;
            Assert.Equal(404, statusCodeResult.StatusCode);
        }
        [Fact]
        public async Task Insert_ReturnsOkResult()
        {
            //Arrange            
            Patient patient = new Patient() { FirstName = "San", LastName = "Bui", Age=4};
            unitOfWorkMock.Setup(x => x.Patient.InsertAsync(patient)).ReturnsAsync(patient);
            //Act
            var result = await controller.Insert(patient);
            //Assert            
            var objectResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            var returnValue = Assert.IsType<Patient>(objectResult.Value);            
            Assert.Equal("San", returnValue.FirstName);
            Assert.Equal("Bui", returnValue.LastName);
        }

    }
}
