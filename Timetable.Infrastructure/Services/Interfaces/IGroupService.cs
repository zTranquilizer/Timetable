using Timetable.Database.Models;
using Timetable.Infrastructure.Enums;
using Timetable.Infrastructure.Models;
using Timetable.Infrastructure.ServiceModels.Group;

namespace Timetable.Infrastructure.Services.Interfaces
{
    /// <summary>
    ///     Interface for group service
    /// </summary>
    public interface IGroupService
    {
        /// <summary>
        ///     Get groups async
        /// </summary>
        /// <returns></returns>
        Task<List<GroupDto>> GetGroupsAsync();

        /// <summary>
        ///     Get group by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GroupDto> GetGroupByIdAsync(int id);

        /// <summary>
        ///     Get group by number async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GroupDto> GetGroupByNumberAsync(int id);

        /// <summary>
        ///  Create group async
        /// </summary>
        /// <param name="groupDto"></param>
        /// <returns></returns>
        Task<CreateGroupResponseModel> CreateGroupAsync(GroupDto groupDto);

        /// <summary>
        ///  Edit group async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="groupDto"></param>
        /// <returns></returns>
        Task<EditGroupResponseModel> EditGroupAsync(int id, GroupDto groupDto);

        /// <summary>
        ///  Delete group async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<GroupResponseType> DeleteGroupAsync(int id);
    }
}
