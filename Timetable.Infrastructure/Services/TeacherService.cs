using Mapster;
using Timetable.Database.Models;
using Timetable.Database.Repositories.Interfaces;
using Timetable.Infrastructure.Enums;
using Timetable.Infrastructure.Models;
using Timetable.Infrastructure.ServiceModels.Teacher;
using Timetable.Infrastructure.Services.Interfaces;

namespace Timetable.Infrastructure.Services
{
    /// <summary>
    ///     Teacher service
    /// </summary>
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IBoardRepository _boardRepository;

        public TeacherService(ITeacherRepository teacherRepository, IBoardRepository boardRepository)
        {
            _teacherRepository = teacherRepository;
            _boardRepository = boardRepository;
        }

        /// <summary>
        ///     Get teachers async
        /// </summary>
        /// <returns></returns>
        public async Task<List<TeacherDto>> GetTeachersAsync()
        {
            List<Teacher> teachers = await _teacherRepository.GetTeachersAsync();
            return teachers.Adapt<List<TeacherDto>>();
        }

        /// <summary>
        ///     Get teacher by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TeacherDto> GetTeacherByIdAsync(int id)
        {
            Teacher teacher = await _teacherRepository.GetTeacherByIdAsync(id);
            return teacher.Adapt<TeacherDto>();
        }

        /// <summary>
        ///  Create teacher async
        /// </summary>
        /// <param name="teacherDto"></param>
        /// <returns></returns>
        public async Task<CreateTeacherResponseModel> CreateTeacherAsync(TeacherDto teacherDto)
        {
            Teacher teacher = teacherDto.Adapt<Teacher>();
            Teacher teacherCreated = await _teacherRepository.CreateTeacherAsync(teacher);

            return new CreateTeacherResponseModel()
            {
                Type = TeacherResponseType.Success,
                Teacher = teacherCreated.Adapt<TeacherDto>()
            };
        }

        /// <summary>
        ///  Edit teacher async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="teacherDto"></param>
        /// <returns></returns>
        public async Task<EditTeacherResponseModel> EditTeacherAsync(int id, TeacherDto teacherDto)
        {
            Teacher teacher = await _teacherRepository.GetTeacherByIdAsync(id);

            if (teacher == null)
            {
                return new EditTeacherResponseModel()
                {
                    Type = TeacherResponseType.TeacherNotFound
                };
            }

            teacherDto.Id = teacher.Id;

            Teacher teacherModel = teacherDto.Adapt<Teacher>();
            Teacher teacherEdited = await _teacherRepository.EditTeacherAsync(teacherModel);

            return new EditTeacherResponseModel()
            {
                Type = TeacherResponseType.Success,
                Teacher = teacherEdited.Adapt<TeacherDto>()
            };

        }

        /// <summary>
        ///  Delete teacher async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TeacherResponseType> DeleteTeacherAsync(int id)
        {
            Teacher teacher = await _teacherRepository.GetTeacherByIdAsync(id);

            if (teacher == null)
            {
                return TeacherResponseType.TeacherNotFound;
            }

            Board board = await _boardRepository.GetBoardByTeacherIdAsync(teacher.Id);

            if (board != null)
            {
                return TeacherResponseType.TeacherWorking;
            }

            await _teacherRepository.DeleteTeacherAsync(teacher);

            return TeacherResponseType.Success;
        }
    }
}
