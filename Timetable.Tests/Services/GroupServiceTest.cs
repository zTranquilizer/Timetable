using FluentAssertions;
using Mapster;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timetable.Database.Models;
using Timetable.Database.Repositories.Interfaces;
using Timetable.Infrastructure.Models.Database;
using Timetable.Infrastructure.Models.Service.Group;
using Timetable.Infrastructure.Services;
using Xunit;

namespace Timetable.Tests.Services
{
    /// <summary>
    ///     Group service test
    /// </summary>
    public class GroupServiceTest
    {
        Mock<IGroupRepository> groupRepositoryMock;
        Mock<IBoardRepository> boardRepositoryMock;

        public GroupServiceTest()
        {
            groupRepositoryMock = new Mock<IGroupRepository>();
            boardRepositoryMock = new Mock<IBoardRepository>();
        }

        [Fact]
        public async Task GetGroups_ShouldReturn_Groups()
        {
            //arrange
            var groups = GetTestGroups();

            groupRepositoryMock.Setup(r => r.GetGroupsAsync()).Returns(Task.FromResult(groups.Adapt<List<Group>>()));

            GroupService service = new GroupService(groupRepositoryMock.Object, boardRepositoryMock.Object);

            //act
            List<GroupDto> result = await service.GetGroupsAsync();

            //assert
            groups.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetGroupById_ShouldReturn_Group()
        {
            //arrange
            var groups = GetTestGroups();

            groupRepositoryMock.Setup(r => r.GetGroupByIdAsync(groups[0].Id)).Returns(Task.FromResult(groups[0].Adapt<Group>()));

            GroupService service = new GroupService(groupRepositoryMock.Object, boardRepositoryMock.Object);

            //act
            GroupDto result = await service.GetGroupByIdAsync(groups[0].Id);

            //assert
            groups[0].Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetGroupByNumber_ShouldReturn_Group()
        {
            //arrange
            var groups = GetTestGroups();

            groupRepositoryMock.Setup(r => r.GetGroupByNumberAsync(groups[0].GroupNumber)).Returns(Task.FromResult(groups[0].Adapt<Group>()));

            GroupService service = new GroupService(groupRepositoryMock.Object, boardRepositoryMock.Object);

            //act
            GroupDto result = await service.GetGroupByNumberAsync(groups[0].GroupNumber);

            //assert
            groups[0].Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task AddGroup_ShouldReturn_Group()
        {
            //arrange
            GroupDto group = new GroupDto()
            {
                Id = 11,
                GroupNumber = 1120,
            };

            groupRepositoryMock.Setup(r => r.CreateGroupAsync(group.Adapt<Group>())).Returns(Task.FromResult(group.Adapt<Group>()));

            GroupService service = new GroupService(groupRepositoryMock.Object, boardRepositoryMock.Object);

            //act
            CreateGroupResponseModel result = await service.CreateGroupAsync(group);

            //assert
            Assert.True(result.Type == Infrastructure.Enums.GroupResponseType.Success);
        }

        private List<GroupDto> GetTestGroups()
        {
            List<GroupDto> groups = new List<GroupDto>
            {
                new GroupDto
                {
                    Id = 1,
                    GroupNumber = 202011
                },
                new GroupDto{
                    Id = 2,
                    GroupNumber = 202022
                }
            };

            return groups;
        }
    }
}
