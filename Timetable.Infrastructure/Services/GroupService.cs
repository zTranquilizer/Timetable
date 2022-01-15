using Mapster;
using Timetable.Database.Models;
using Timetable.Database.Repositories.Interfaces;
using Timetable.Infrastructure.Enums;
using Timetable.Infrastructure.Models.Database;
using Timetable.Infrastructure.Models.Service.Group;
using Timetable.Infrastructure.Services.Interfaces;

namespace Timetable.Infrastructure.Services
{
    /// <summary>
    ///     Group service
    /// </summary>
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IBoardRepository _boardRepository;

        public GroupService(IGroupRepository groupRepository, IBoardRepository boardRepository)
        {
            _groupRepository = groupRepository;
            _boardRepository = boardRepository;
        }

        /// <summary>
        ///     Get groups async
        /// </summary>
        /// <returns></returns>
        public async Task<List<GroupDto>> GetGroupsAsync()
        {
            List<Group> groups = await _groupRepository.GetGroupsAsync();
            return groups.Adapt<List<GroupDto>>();
        }

        /// <summary>
        ///     Get group by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GroupDto> GetGroupByIdAsync(int id)
        {
            Group group = await _groupRepository.GetGroupByIdAsync(id);
            return group.Adapt<GroupDto>();
        }

        /// <summary>
        ///     Get group by number async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GroupDto> GetGroupByNumberAsync(int id)
        {
            Group group = await _groupRepository.GetGroupByNumberAsync(id);
            return group.Adapt<GroupDto>();
        }

        /// <summary>
        ///     Create group async
        /// </summary>
        /// <param name="groupDto"></param>
        /// <returns></returns>
        public async Task<CreateGroupResponseModel> CreateGroupAsync(GroupDto groupDto)
        {
            Group group = groupDto.Adapt<Group>();
            Group groupCreated = await _groupRepository.CreateGroupAsync(group);

            return new CreateGroupResponseModel()
            {
                Type = GroupResponseType.Success,
                Group = groupCreated.Adapt<GroupDto>()
            };
        }

        /// <summary>
        ///     Edit group async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="groupDto"></param>
        /// <returns></returns>
        public async Task<EditGroupResponseModel> EditGroupAsync(int id, GroupDto groupDto)
        {
            Group group = await _groupRepository.GetGroupByIdAsync(id);

            if (group == null)
            {
                return new EditGroupResponseModel()
                {
                    Type = GroupResponseType.GroupNotFound
                };
            }

            groupDto.Id = group.Id;

            Group groupModel = groupDto.Adapt<Group>();
            Group groupEdited = await _groupRepository.EditGroupAsync(groupModel);

            return new EditGroupResponseModel()
            {
                Type = GroupResponseType.Success,
                Group = groupEdited.Adapt<GroupDto>()
            };

        }

        /// <summary>
        ///     Delete group async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GroupResponseType> DeleteGroupAsync(int id)
        {
            Group group = await _groupRepository.GetGroupByIdAsync(id);

            if (group == null)
            {
                return GroupResponseType.GroupNotFound;
            }

            Board board = await _boardRepository.GetBoardByGroupIdAsync(group.Id);

            if (board != null)
            {
                return GroupResponseType.GroupStudying;
            }

            await _groupRepository.DeleteGroupAsync(group);

            return GroupResponseType.Success;
        }
    }
}
