using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timetable.Controllers;
using Timetable.Infrastructure.Models.Database;
using Timetable.Infrastructure.ServiceModels.Teacher;
using Timetable.Infrastructure.Services.Interfaces;
using Xunit;

namespace Timetable.Tests.Controllers
{
    /// <summary>
    ///     Teacher controller test
    /// </summary>
    public class TeacherControllerTest
    {
        Mock<ITeacherService> teacherServiceMock;

        public TeacherControllerTest()
        {
            teacherServiceMock = new Mock<ITeacherService>();
        }

        [Fact]
        public async Task GetTeachers_ShouldReturn_Teachers()
        {
            //arrange
            List<TeacherDto> teachers = GetTestTeachers();

            teacherServiceMock.Setup(r => r.GetTeachersAsync()).Returns(Task.FromResult(teachers));

            TeacherController controller = new TeacherController(teacherServiceMock.Object);

            //act
            IActionResult? result = await controller.GetTeachers();
            OkObjectResult? okResult = result as OkObjectResult;

            //assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task GetTeacherById_ShouldReturn_Teacher()
        {
            //arrange
            var teachers = GetTestTeachers();

            teacherServiceMock.Setup(r => r.GetTeacherByIdAsync(teachers[0].Id)).Returns(Task.FromResult(teachers[0]));

            TeacherController controller = new TeacherController(teacherServiceMock.Object);

            //act
            IActionResult? result = await controller.GetTeacher(teachers[0].Id);
            OkObjectResult? okResult = result as OkObjectResult;

            //assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task AddTeacher_ShouldReturn_Teacher()
        {
            //arrange
            TeacherDto teacher = new TeacherDto()
            {
                Id = 11,
                FirstName = "Terentiy",
                LastName = "Korobkov"
            };

            teacherServiceMock.Setup(r => r.CreateTeacherAsync(teacher)).Returns(Task.FromResult(new CreateTeacherResponseModel() {Teacher = teacher, Type = Infrastructure.Enums.TeacherResponseType.Success }));

            TeacherController controller = new TeacherController(teacherServiceMock.Object);

            //act
            IActionResult? result = await controller.Post(teacher);
            OkObjectResult? okResult = result as OkObjectResult;

            //assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        private List<TeacherDto> GetTestTeachers()
        {
            List<TeacherDto> teachers = new List<TeacherDto>
            {
                new TeacherDto
                {
                    Id = 1,
                    FirstName = "Jora",
                    LastName = "Coreto",
                },
                new TeacherDto{
                    Id = 2,
                    FirstName = "Mikkle",
                    LastName = "Poiskov",
                }
            };

            return teachers;
        }
    }
}
