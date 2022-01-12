using Timetable.Database.Models;

namespace Timetable.Database.Repositories.Interfaces
{
    /// <summary>
    ///     Interface for group repository
    /// </summary>
    public interface IGroupRepository
    {
        /// <summary>
        ///     Get groups async
        /// </summary>
        /// <returns></returns>
        Task<List<Group>> GetGroupsAsync();

        /// <summary>
        ///     Get group by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Group> GetGroupByIdAsync(int id);

        /// <summary>
        ///     Get group by number async
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        Task<Group> GetGroupByNumberAsync(int number);

        /// <summary>
        ///  Create group async
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        Task<Group> CreateGroupAsync(Group group);

        /// <summary>
        ///  Edit group async
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        Task<Group> EditGroupAsync(Group group);

        /// <summary>
        ///  Delete group async
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        Task DeleteGroupAsync(Group group);
    }
}
