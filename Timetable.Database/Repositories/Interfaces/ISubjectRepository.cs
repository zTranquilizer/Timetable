using Timetable.Database.Models;

namespace Timetable.Database.Repositories.Interfaces
{
    /// <summary>
    ///     Interface for subject repository
    /// </summary>
    public interface ISubjectRepository
    {
        /// <summary>
        ///     Get subjects async
        /// </summary>
        /// <returns></returns>
        Task<List<Subject>> GetSubjectsAsync();

        /// <summary>
        ///     Get subject by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Subject> GetSubjectByIdAsync(int id);

        /// <summary>
        ///     Get subject by last name async
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<Subject> GetSubjectByNameAsync(string name);

        /// <summary>
        ///     Create subject async
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        Task<Subject> CreateSubjectAsync(Subject subject);

        /// <summary>
        ///     Edit subject async
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        Task<Subject> EditSubjectAsync(Subject subject);

        /// <summary>
        ///     Delete subject async
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        Task DeleteSubjectAsync(Subject subject);
    }
}
