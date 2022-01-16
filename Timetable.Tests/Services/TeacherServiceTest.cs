using FluentAssertions;
using Mapster;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timetable.Database.Models;
using Timetable.Database.Repositories.Interfaces;
using Timetable.Infrastructure.Models.Database;
using Timetable.Infrastructure.Models.Service.Teacher;
using Timetable.Infrastructure.Services;
using Xunit;

namespace Timetable.Tests.Services
{
    /// <summary>
    ///     Teacher service test
    /// </summary>
    public class TeacherServiceTest
    {
        Mock<ITeacherRepository> teacherRepositoryMock;
        Mock<IBoardRepository> boardRepositoryMock;

        public TeacherServiceTest()
        {
            teacherRepositoryMock = new Mock<ITeacherRepository>();
            boardRepositoryMock = new Mock<IBoardRepository>();
        }

        [Fact]
        public async Task GetTeachers_ShouldReturn_Teachers()
        {
            //arrange
            var teachers = GetTestTeachers();

            teacherRepositoryMock.Setup(r => r.GetTeachersAsync()).Returns(Task.FromResult(teachers.Adapt<List<Teacher>>()));

            TeacherService service = new TeacherService(teacherRepositoryMock.Object, boardRepositoryMock.Object);

            //act
            List<TeacherDto> result = await service.GetTeachersAsync();

            //assert
            teachers.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetTeacherById_ShouldReturn_Teacher()
        {
            //arrange
            var teachers = GetTestTeachers();

            teacherRepositoryMock.Setup(r => r.GetTeacherByIdAsync(teachers[0].Id)).Returns(Task.FromResult(teachers[0].Adapt<Teacher>()));

            TeacherService service = new TeacherService(teacherRepositoryMock.Object, boardRepositoryMock.Object);

            //act
            TeacherDto result = await service.GetTeacherByIdAsync(teachers[0].Id);

            //assert
            teachers[0].Should().BeEquivalentTo(result);
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

            teacherRepositoryMock.Setup(r => r.CreateTeacherAsync(teacher.Adapt<Teacher>())).Returns(Task.FromResult(teacher.Adapt<Teacher>()));

            TeacherService service = new TeacherService(teacherRepositoryMock.Object, boardRepositoryMock.Object);

            //act
            CreateTeacherResponseModel result = await service.CreateTeacherAsync(teacher);

            //assert
            Assert.True(result.Type == Infrastructure.Enums.TeacherResponseType.Success);
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

                new TeacherDto
                {
                    Id = 2,
                    FirstName = "Mikkle",
                    LastName = "Poiskov",
                }
            };

            return teachers;
        }
    }
}
