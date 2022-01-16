using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timetable.Controllers;
using Timetable.Infrastructure.Models.Database;
using Timetable.Infrastructure.Models.Service.Group;
using Timetable.Infrastructure.Services.Interfaces;
using Xunit;

namespace Timetable.Tests.Controllers
{
    /// <summary>
    ///     Group controller test
    /// </summary>
    public class GroupControllerTest
    {
        Mock<IGroupService> groupServiceMock;

        public GroupControllerTest()
        {
            groupServiceMock = new Mock<IGroupService>();
        }

        [Fact]
        public async Task GetGroups_ShouldReturn_Groups()
        {
            //arrange
            List<GroupDto> groups = GetTestGroups();

            groupServiceMock.Setup(r => r.GetGroupsAsync()).Returns(Task.FromResult(groups));

            GroupController controller = new GroupController(groupServiceMock.Object);

            //act
            IActionResult? result = await controller.GetGroups();
            OkObjectResult? okResult = result as OkObjectResult;

            //assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task GetGroupById_ShouldReturn_Group()
        {
            //arrange
            var groups = GetTestGroups();

            groupServiceMock.Setup(r => r.GetGroupByIdAsync(groups[0].Id)).Returns(Task.FromResult(groups[0]));

            GroupController controller = new GroupController(groupServiceMock.Object);

            //act
            IActionResult? result = await controller.GetGroup(groups[0].Id);
            OkObjectResult? okResult = result as OkObjectResult;

            //assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task AddGroup_ShouldReturn_Group()
        {
            //arrange
            GroupDto group = new GroupDto()
            {
                Id = 11,
               GroupNumber = 2222
            };

            groupServiceMock.Setup(r => r.CreateGroupAsync(group)).Returns(Task.FromResult(new CreateGroupResponseModel() {Group = group, Type = Infrastructure.Enums.GroupResponseType.Success }));

            GroupController controller = new GroupController(groupServiceMock.Object);

            //act
            IActionResult? result = await controller.Post(group);
            OkObjectResult? okResult = result as OkObjectResult;

            //assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        private List<GroupDto> GetTestGroups()
        {
            List<GroupDto> groups = new List<GroupDto>
            {
                new GroupDto
                {
                    Id = 1,
                    GroupNumber = 1111
                },

                new GroupDto
                {
                    Id = 2,
                    GroupNumber = 1112
                }
            };

            return groups;
        }
    }
}
