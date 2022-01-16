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
    ///     Group repository test
    /// </summary>
    public class GroupRepositoryTest
    {
        private readonly DbContextOptions<DatabaseContext>? options;
        private readonly DatabaseContext context;

        public GroupRepositoryTest()
        {
            options = new DbContextOptionsBuilder<DatabaseContext>().UseInMemoryDatabase(databaseName: "TimetableDB").Options;
            context = new DatabaseContext(options);
        }

        [Fact]
        public async Task GetGroups_ShouldReturn_Groups()
        {
            //arange
            ClearDatabase(context);

            var groupsNew = AddDb(context);

            var groupRepository = new GroupRepository(context);

            //act
            var result = await groupRepository.GetGroupsAsync();

            //assert
            groupsNew.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetGroupById_ShouldReturn_Group()
        {
            //arrange
            ClearDatabase(context);

            var groupsNew = AddDb(context);

            var groupRepository = new GroupRepository(context);

            //act
            var result = await groupRepository.GetGroupByIdAsync(groupsNew[0].Id);

            //assert
            groupsNew[0].Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetGroupByNubmer_ShouldReturn_Group()
        {
            //arrange
            ClearDatabase(context);

            var groupsNew = AddDb(context);

            var groupRepository = new GroupRepository(context);

            //act
            var result = await groupRepository.GetGroupByNumberAsync(groupsNew[0].GroupNumber);

            //assert
            groupsNew[0].Should().BeEquivalentTo(result);
            Assert.Equal(groupsNew[0].GroupNumber, result.GroupNumber);
        }

        [Fact]
        public async Task AddGroup_ShouldReturn_Group()
        {
            //arrange
            var group = new Group
            {
                Id = 11,
                GroupNumber = 202011
            };

            var groupRepository = new GroupRepository(context);

            //act
            var result = await groupRepository.CreateGroupAsync(group);

            //assert
            group.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task EditGroup_ShouldReturn_Group()
        {
            //arrange
            ClearDatabase(context);

            var groupsNew = AddDb(context);
            var groupRepository = new GroupRepository(context);

            //act
            var result = await groupRepository.EditGroupAsync(groupsNew[0]);

            //assert
            groupsNew[0].Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task DeleteGroup_ShouldReturn_Group()
        {
            //arrange
            ClearDatabase(context);

            var groupsNew = AddDb(context);
            var groupRepository = new GroupRepository(context);

            //act
            await groupRepository.DeleteGroupAsync(groupsNew[1]);

            //assert
            Assert.True(context.Groups.FirstOrDefault(t => t.Id == groupsNew[1].Id) == null);
        }

        private Group[] AddDb(DatabaseContext database)
        {
            var groupsNew = new[] {

                new Group
               {
                Id = 1,
                GroupNumber = 202011
            },

            new Group
                {
                Id = 2,
                GroupNumber = 303011
            }
        };

            database.Groups.AddRange(groupsNew);
            database.SaveChanges();

            return groupsNew;
        }

        private async void ClearDatabase(DatabaseContext context)
        {
            foreach (var entity in context.Groups)
                context.Groups.Remove(entity);

            await context.SaveChangesAsync();
        }
    }
}
