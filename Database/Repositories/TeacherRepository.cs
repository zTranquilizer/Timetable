using Microsoft.EntityFrameworkCore;
using Timetable.Database.Models;
using Timetable.Database.Repositories.Interfaces;

namespace Timetable.Database.Repositories
{
    /// <summary>
    ///     Teacher repository
    /// </summary>
    public class TeacherRepository : ITeacherRepository
    {
        private readonly DatabaseContext _databaseContext;

        public TeacherRepository(DatabaseContext databaseContext)
        {
              _databaseContext = databaseContext;
        }

        /// <summary>
        ///     Get teachers async
        /// </summary>
        /// <returns></returns>
        public async Task<List<Teacher>> GetTeachersAsync()
        {
            return await _databaseContext.Teachers.ToListAsync();
        }

        /// <summary>
        ///     Get teacher by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Teacher> GetTeacherByIdAsync(int id)
        {
            return await _databaseContext.Teachers.FirstOrDefaultAsync(t => t.Id == id);
        }

        /// <summary>
        ///  Create teacher async
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public async Task<Teacher> CreateTeacherAsync(Teacher teacher)
        {
            _databaseContext.Teachers.Add(teacher);
            await _databaseContext.SaveChangesAsync();

            return teacher;
        }

        /// <summary>
        ///  Edit teacher async
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public async Task<Teacher> EditTeacherAsync(Teacher teacher)
        {
            _databaseContext.Teachers.Update(teacher);
            await _databaseContext.SaveChangesAsync();

            return teacher;
        }

        /// <summary>
        ///  Delete teacher async
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        public async Task DeleteTeacherAsync(Teacher teacher)
        {
            _databaseContext.Teachers.Remove(teacher);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
