using Timetable.Database.Models;

namespace Timetable.Database.Repositories.Interfaces
{
    /// <summary>
    ///     Interface for teacher repository
    /// </summary>
    public interface ITeacherRepository
    {
        /// <summary>
        ///     Get teachers async
        /// </summary>
        /// <returns></returns>
        Task<List<Teacher>> GetTeachersAsync();

        /// <summary>
        ///     Get teacher by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Teacher> GetTeacherByIdAsync(int id);

        /// <summary>
        ///     Create teacher async
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        Task<Teacher> CreateTeacherAsync(Teacher teacher);

        /// <summary>
        ///     Edit teacher async
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        Task<Teacher> EditTeacherAsync(Teacher teacher);

        /// <summary>
        ///     Delete teacher async
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        Task DeleteTeacherAsync(Teacher teacher);
    }
}
