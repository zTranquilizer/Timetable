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
    ///     Teacher repository test
    /// </summary>
    public class TeacherRepositoryTest
    {
        private readonly DbContextOptions<DatabaseContext>? options;
        private readonly DatabaseContext context;

        public TeacherRepositoryTest()
        {
            options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "TimetableDB").Options;
            context = new DatabaseContext(options);
        }

        [Fact]
        public async Task GetTeachers_ShouldReturn_Teachers()
        {
            //arange
            ClearDatabase(context);

            var teachersNew = AddDb(context);

            var teacherRepository = new TeacherRepository(context);

            //act
            var result = await teacherRepository.GetTeachersAsync();

            //assert
            teachersNew.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetTeacherById_ShouldReturn_Teacher()
        {
            //arrange
            ClearDatabase(context);

            var teachersNew = AddDb(context);

            var teacherRepository = new TeacherRepository(context);

            //act
            var result = await teacherRepository.GetTeacherByIdAsync(teachersNew[0].Id);

            //assert
            teachersNew[0].Should().BeEquivalentTo(result);
        }


        [Fact]
        public async Task AddTeacher_ShouldReturn_Teacher()
        {
            //arrange
            var teacher = new Teacher
            {
                Id = 11,
                FirstName = "Kolya",
                LastName = "Ternov"
            };

            var teacherRepository = new TeacherRepository(context);

            //act
            var result = await teacherRepository.CreateTeacherAsync(teacher);

            //assert
            teacher.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task EditTeacher_ShouldReturn_Teacher()
        {
            //arrange
            ClearDatabase(context);

            var teachersNew = AddDb(context);
            var teacherRepository = new TeacherRepository(context);

            //act
            var result = await teacherRepository.EditTeacherAsync(teachersNew[0]);

            //assert
            teachersNew[0].Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task DeleteTeacher_ShouldReturn_Teacher()
        {
            //arrange
            ClearDatabase(context);

            var teachersNew = AddDb(context);
            var teacherRepository = new TeacherRepository(context);

            //act
            await teacherRepository.DeleteTeacherAsync(teachersNew[1]);

            //assert
            Assert.True(context.Teachers.FirstOrDefault(t => t.Id == teachersNew[1].Id) == null);
        }

        private Teacher[] AddDb(DatabaseContext database)
        {
            var teachersNew = new[] {

                new Teacher
                {
                    Id = 1,
                    FirstName = "Jora",
                    LastName = "Coreto",
                },

                new Teacher
                {
                    Id = 2,
                    FirstName = "Mikkle",
                    LastName = "Poiskov",
                }
            };

            database.Teachers.AddRange(teachersNew);
            database.SaveChanges();

            return teachersNew;
        }
        private async void ClearDatabase(DatabaseContext context)
        {
            foreach (var entity in context.Teachers)
                context.Teachers.Remove(entity);

            await context.SaveChangesAsync();
        }
    }
}
