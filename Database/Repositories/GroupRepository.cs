using Microsoft.EntityFrameworkCore;
using Timetable.Database.Models;
using Timetable.Database.Repositories.Interfaces;

namespace Timetable.Database.Repositories
{
    /// <summary>
    ///     Group repository
    /// </summary>
    public class GroupRepository : IGroupRepository
    {
        private readonly DatabaseContext _databaseContext;

        public GroupRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        /// <summary>
        ///     Get groups async
        /// </summary>
        /// <returns></returns>
        public async Task<List<Group>> GetGroupsAsync()
        {
            return await _databaseContext.Groups.ToListAsync();
        }

        /// <summary>
        ///     Get group by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Group> GetGroupByIdAsync(int id)
        {
            return await _databaseContext.Groups.FirstOrDefaultAsync(g => g.Id == id);
        }

        /// <summary>
        ///     Get group by number async
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public async Task<Group> GetGroupByNumberAsync(int number)
        {
            return await _databaseContext.Groups.FirstOrDefaultAsync(g => g.GroupNumber == number);
        }

        /// <summary>
        ///  Create group async
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public async Task<Group> CreateGroupAsync(Group group)
        {
            _databaseContext.Groups.Add(group);
            await _databaseContext.SaveChangesAsync();

            return group;
        }

        /// <summary>
        ///  Edit group async
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public async Task<Group> EditGroupAsync(Group group)
        {
            _databaseContext.Groups.Update(group);
            await _databaseContext.SaveChangesAsync();

            return group;
        }

        /// <summary>
        ///  Delete group async
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        public async Task DeleteGroupAsync(Group group)
        {
            _databaseContext.Groups.Remove(group);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
