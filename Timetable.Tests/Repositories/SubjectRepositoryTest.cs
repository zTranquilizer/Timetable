using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Timetable.Database;
using Timetable.Database.Models;
using Timetable.Database.Repositories;
using Xunit;

namespace Timetable.Tests.Repositories
{
    /// <summary>
    ///     Subject repository test
    /// </summary>
    public class SubjectRepositoryTest
    {

        private readonly DbContextOptions<DatabaseContext>? options;
        private readonly DatabaseContext context;

        public SubjectRepositoryTest()
        {
            options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "TimetableDB").Options;
            context = new DatabaseContext(options);
        }

        [Fact]
        public async Task GetSubjects_ShouldReturn_Subjects()
        {
            //arange
            ClearDatabase(context);

            var subjectsNew = AddDb(context);

            var subjectRepository = new SubjectRepository(context);

            //act
            var result = await subjectRepository.GetSubjectsAsync();

            //assert
            subjectsNew.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetSubjectById_ShouldReturn_Subject()
        {
            //arrange
            ClearDatabase(context);

            var subjectsNew = AddDb(context);

            var subjectRepository = new SubjectRepository(context);

            //act
            var result = await subjectRepository.GetSubjectByIdAsync(subjectsNew[0].Id);

            //assert
            subjectsNew[0].Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetSubjectByName_ShouldReturn_Subject()
        {
            //arrange
            ClearDatabase(context);

            var subjectsNew = AddDb(context);

            var subjectRepository = new SubjectRepository(context);

            //act
            var result = await subjectRepository.GetSubjectByNameAsync(subjectsNew[0].SubjectName);

            //assert
            subjectsNew[0].Should().BeEquivalentTo(result);
            Assert.Equal(subjectsNew[0].SubjectName, result.SubjectName);

        }


        [Fact]
        public async Task AddSubject_ShouldReturn_Subject()
        {
            //arrange
            var subject = new Subject
            {
                Id = 11,
                SubjectName = "Math"
            };

            var subjectRepository = new SubjectRepository(context);

            //act
            var result = await subjectRepository.CreateSubjectAsync(subject);

            //assert
            subject.Should().BeEquivalentTo(result);
        }


        [Fact]
        public async Task EditSubject_ShouldReturn_Subject()
        {
            //arrange
            ClearDatabase(context);

            var subjectsNew = AddDb(context);
            var subjectRepository = new SubjectRepository(context);

            //act
            var result = await subjectRepository.EditSubjectAsync(subjectsNew[0]);

            //assert
            subjectsNew[0].Should().BeEquivalentTo(result);
        }


        [Fact]
        public async Task DeleteSubject_ShouldReturn_Subject()
        {
            //arrange
            ClearDatabase(context);

            var subjectsNew = AddDb(context);
            var subjectRepository = new SubjectRepository(context);

            //act
            await subjectRepository.DeleteSubjectAsync(subjectsNew[1]);

            //assert
            Assert.True(context.Subjects.FirstOrDefault(t => t.Id == subjectsNew[1].Id) == null);
        }

        private Subject[] AddDb(DatabaseContext database)
        {
            var subjectsNew = new[] {

                new Subject
               {
                Id = 1,
                SubjectName = "Geometry"
            },

            new Subject
                {
                Id = 2,
                SubjectName = "Geography"
            }
        };

            database.Subjects.AddRange(subjectsNew);
            database.SaveChanges();

            return subjectsNew;
        }

        private async void ClearDatabase(DatabaseContext context)
        {
            foreach (var entity in context.Subjects)
                context.Subjects.Remove(entity);

            await context.SaveChangesAsync();
        }
    }
}
