using Microsoft.EntityFrameworkCore;
using Timetable.Database.Models;
using Timetable.Database.Repositories.Interfaces;

namespace Timetable.Database.Repositories
{
    /// <summary>
    ///     Subject repository
    /// </summary>
    public class SubjectRepository : ISubjectRepository
    {
        private readonly DatabaseContext _databaseContext;

        public SubjectRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        /// <summary>
        ///     Get subjects async
        /// </summary>
        /// <returns></returns>
        public async Task<List<Subject>> GetSubjectsAsync()
        {
            return await _databaseContext.Subjects.ToListAsync();
        }

        /// <summary>
        ///     Get subject by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Subject> GetSubjectByIdAsync(int id)
        {
            return await _databaseContext.Subjects.FirstOrDefaultAsync(t => t.Id == id);
        }

        /// <summary>
        ///     Get subject by last name async
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<Subject> GetSubjectByNameAsync(string name)
        {
            return await _databaseContext.Subjects.FirstOrDefaultAsync(t => t.SubjectName == name);
        }

        /// <summary>
        ///     Create subject async
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        public async Task<Subject> CreateSubjectAsync(Subject subject)
        {
            _databaseContext.Subjects.Add(subject);
            await _databaseContext.SaveChangesAsync();

            return subject;
        }

        /// <summary>
        ///     Edit subject async
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        public async Task<Subject> EditSubjectAsync(Subject subject)
        {
            _databaseContext.Subjects.Update(subject);
            await _databaseContext.SaveChangesAsync();

            return subject;
        }

        /// <summary>
        ///     Delete subject async
        /// </summary>
        /// <param name="subject"></param>
        /// <returns></returns>
        public async Task DeleteSubjectAsync(Subject subject)
        {
            _databaseContext.Subjects.Remove(subject);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
