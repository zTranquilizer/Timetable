using Timetable.Database.Models;
using Timetable.Infrastructure.Enums;
using Timetable.Infrastructure.Models;
using Timetable.Infrastructure.ServiceModels.Teacher;

namespace Timetable.Infrastructure.Services.Interfaces
{
    /// <summary>
    ///     Interface for teacher service
    /// </summary>
    public interface ITeacherService
    {
        /// <summary>
        ///     Get teachers async
        /// </summary>
        /// <returns></returns>
        Task<List<TeacherDto>> GetTeachersAsync();

        /// <summary>
        ///     Get teacher by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TeacherDto> GetTeacherByIdAsync(int id);

        /// <summary>
        ///  Create teacher async
        /// </summary>
        /// <param name="teacherDto"></param>
        /// <returns></returns>
        Task<CreateTeacherResponseModel> CreateTeacherAsync(TeacherDto teacherDto);

        /// <summary>
        ///  Edit teacher async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="teacherDto"></param>
        /// <returns></returns>
        Task<EditTeacherResponseModel> EditTeacherAsync(int id, TeacherDto teacherDto);

        /// <summary>
        ///  Delete teacher async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TeacherResponseType> DeleteTeacherAsync(int id);
    }
}
