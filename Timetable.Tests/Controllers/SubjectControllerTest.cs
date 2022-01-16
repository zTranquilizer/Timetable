using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timetable.Controllers;
using Timetable.Infrastructure.Models.Database;
using Timetable.Infrastructure.Models.Service.Subject;
using Timetable.Infrastructure.Services.Interfaces;
using Xunit;

namespace Timetable.Tests.Controllers
{
    /// <summary>
    ///     Subject controller test
    /// </summary>
    public class SubjectControllerTest
    {
        Mock<ISubjectService> subjectServiceMock;

        public SubjectControllerTest()
        {
            subjectServiceMock = new Mock<ISubjectService>();
        }

        [Fact]
        public async Task GetSubjects_ShouldReturn_Subjects()
        {
            //arrange
            List<SubjectDto> subjects = GetTestSubjects();

            subjectServiceMock.Setup(r => r.GetSubjectsAsync()).Returns(Task.FromResult(subjects));

            SubjectController controller = new SubjectController(subjectServiceMock.Object);

            //act
            IActionResult? result = await controller.GetSubjects();
            OkObjectResult? okResult = result as OkObjectResult;

            //assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task GetSubjectById_ShouldReturn_Subject()
        {
            //arrange
            var subjects = GetTestSubjects();

            subjectServiceMock.Setup(r => r.GetSubjectByIdAsync(subjects[0].Id)).Returns(Task.FromResult(subjects[0]));

            SubjectController controller = new SubjectController(subjectServiceMock.Object);

            //act
            IActionResult? result = await controller.GetSubject(subjects[0].Id);
            OkObjectResult? okResult = result as OkObjectResult;

            //assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task AddSubject_ShouldReturn_Subject()
        {
            //arrange
            SubjectDto subject = new SubjectDto()
            {
                Id = 11,
                SubjectName = "Math"
            };

            subjectServiceMock.Setup(r => r.CreateSubjectAsync(subject)).Returns(Task.FromResult(new CreateSubjectResponseModel() {Subject = subject, Type = Infrastructure.Enums.SubjectResponseType.Success }));

            SubjectController controller = new SubjectController(subjectServiceMock.Object);

            //act
            IActionResult? result = await controller.Post(subject);
            OkObjectResult? okResult = result as OkObjectResult;

            //assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        private List<SubjectDto> GetTestSubjects()
        {
            List<SubjectDto> subjects = new List<SubjectDto>
            {
                new SubjectDto
                {
                    Id = 1,
                    SubjectName = "Biography"
                },

                new SubjectDto
                {
                    Id = 2,
                    SubjectName = "History"
                }
            };

            return subjects;
        }
    }
}
