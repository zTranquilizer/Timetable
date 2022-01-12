using Microsoft.AspNetCore.Mvc;
using Timetable.Database.Models;
using Timetable.Infrastructure.Enums;
using Timetable.Infrastructure.Models;
using Timetable.Infrastructure.ServiceModels.Group;
using Timetable.Infrastructure.Services.Interfaces;

namespace Timetable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet("GetGroups")]
        public async Task<IActionResult> GetGroups()
        {
            List<GroupDto> groups = await _groupService.GetGroupsAsync();

            return Ok(groups);
        }

        [HttpGet("GetGroup/{id}")]
        public async Task<IActionResult> GetGroup(int id)
        {
            GroupDto group = await _groupService.GetGroupByIdAsync(id);

            return Ok(group);
        }

        [HttpGet("GetGroupNum/{id}")]
        public async Task<IActionResult> GetGroupNum(int id)
        {
            GroupDto group = await _groupService.GetGroupByNumberAsync(id);

            return Ok(group);
        }

        [HttpPost]
        public async Task<IActionResult> Post(GroupDto group)
        {
            CreateGroupResponseModel createGroupResponse = await _groupService.CreateGroupAsync(group);

            if (createGroupResponse.Type == GroupResponseType.Success)
            {
                return Ok(createGroupResponse);
            }

            return BadRequest(createGroupResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, GroupDto group)
        {
            EditGroupResponseModel editGroupResponse = await _groupService.EditGroupAsync(id, group);

            if (editGroupResponse.Type == GroupResponseType.Success)
            {
                return Ok(editGroupResponse);
            }

            return BadRequest(editGroupResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            GroupResponseType groupResponse = await _groupService.DeleteGroupAsync(id);

            if (groupResponse == GroupResponseType.Success)
            {
                return Ok(groupResponse);
            }

            return BadRequest(groupResponse);
        }
    }
}
