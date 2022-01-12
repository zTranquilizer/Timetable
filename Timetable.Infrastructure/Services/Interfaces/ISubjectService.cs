using Timetable.Database.Models;
using Timetable.Infrastructure.Enums;
using Timetable.Infrastructure.Models;
using Timetable.Infrastructure.ServiceModels.Subject;

namespace Timetable.Infrastructure.Services.Interfaces
{
    /// <summary>
    ///     Interface for subject service
    /// </summary>
    public interface ISubjectService
    {
        /// <summary>
        ///     Get subjects async
        /// </summary>
        /// <returns></returns>
        Task<List<SubjectDto>> GetSubjectsAsync();

        /// <summary>
        ///     Get subject by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<SubjectDto> GetSubjectByIdAsync(int id);

        /// <summary>
        ///     Get subject by name async
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<SubjectDto> GetSubjectByNameAsync(string name);

        /// <summary>
        ///  Create subject async
        /// </summary>
        /// <param name="subjectDto"></param>
        /// <returns></returns>
        Task<CreateSubjectResponseModel> CreateSubjectAsync(SubjectDto subjectDto);

        /// <summary>
        ///  Edit subject async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="subjectDto"></param>
        /// <returns></returns>
        Task<EditSubjectResponseModel> EditSubjectAsync(int id, SubjectDto subjectDto);

        /// <summary>
        ///  Delete subject async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<SubjectResponseType> DeleteSubjectAsync(int id);
    }
}
