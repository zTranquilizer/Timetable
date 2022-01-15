using FluentAssertions;
using Mapster;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timetable.Database.Models;
using Timetable.Database.Repositories.Interfaces;
using Timetable.Infrastructure.Models.Database;
using Timetable.Infrastructure.Models.Service.Subject;
using Timetable.Infrastructure.Services;
using Xunit;

namespace Timetable.Tests.Services
{
    /// <summary>
    ///     Subject service test
    /// </summary>
    public class SubjectServiceTest
    {
        Mock<ISubjectRepository> subjectRepositoryMock;
        Mock<IBoardRepository> boardRepositoryMock;

        public SubjectServiceTest()
        {
            subjectRepositoryMock = new Mock<ISubjectRepository>();
            boardRepositoryMock = new Mock<IBoardRepository>();
        }

        [Fact]
        public async Task GetSubjects_ShouldReturn_Subjects()
        {
            //arrange
            var subjects = GetTestSubjects();

            subjectRepositoryMock.Setup(r => r.GetSubjectsAsync()).Returns(Task.FromResult(subjects.Adapt<List<Subject>>()));

            SubjectService service = new SubjectService(subjectRepositoryMock.Object, boardRepositoryMock.Object);

            //act
            List<SubjectDto> result = await service.GetSubjectsAsync();

            //assert
            subjects.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetSubjectById_ShouldReturn_Subject()
        {
            //arrange
            var subjects = GetTestSubjects();

            subjectRepositoryMock.Setup(r => r.GetSubjectByIdAsync(subjects[0].Id)).Returns(Task.FromResult(subjects[0].Adapt<Subject>()));

            SubjectService service = new SubjectService(subjectRepositoryMock.Object, boardRepositoryMock.Object);

            //act
            SubjectDto result = await service.GetSubjectByIdAsync(subjects[0].Id);

            //assert
            subjects[0].Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetSubjectByName_ShouldReturn_Subject()
        {
            //arrange
            var subjects = GetTestSubjects();

            subjectRepositoryMock.Setup(r => r.GetSubjectByNameAsync(subjects[0].SubjectName)).Returns(Task.FromResult(subjects[0].Adapt<Subject>()));

            SubjectService service = new SubjectService(subjectRepositoryMock.Object, boardRepositoryMock.Object);

            //act
            SubjectDto result = await service.GetSubjectByNameAsync(subjects[0].SubjectName);

            //assert
            subjects[0].Should().BeEquivalentTo(result);
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

            subjectRepositoryMock.Setup(r => r.CreateSubjectAsync(subject.Adapt<Subject>())).Returns(Task.FromResult(subject.Adapt<Subject>()));

            SubjectService service = new SubjectService(subjectRepositoryMock.Object, boardRepositoryMock.Object);

            //act
            CreateSubjectResponseModel result = await service.CreateSubjectAsync(subject);

            //assert
            Assert.True(result.Type == Infrastructure.Enums.SubjectResponseType.Success);
        }

        private List<SubjectDto> GetTestSubjects()
        {
            List<SubjectDto> subjects = new List<SubjectDto>
            {
                new SubjectDto
                {
                    Id = 1,
                    SubjectName = "Geometry"
                },
                new SubjectDto{
                    Id = 2,
                    SubjectName = "Biography"
                }
            };

            return subjects;
        }
    }
}
