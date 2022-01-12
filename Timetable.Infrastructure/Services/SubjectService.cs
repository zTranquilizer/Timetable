using Mapster;
using Timetable.Database.Models;
using Timetable.Database.Repositories.Interfaces;
using Timetable.Infrastructure.Enums;
using Timetable.Infrastructure.Models;
using Timetable.Infrastructure.ServiceModels.Subject;
using Timetable.Infrastructure.Services.Interfaces;

namespace Timetable.Infrastructure.Services
{
    /// <summary>
    ///     Subject service
    /// </summary>
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IBoardRepository _boardRepository;

        public SubjectService(ISubjectRepository subjectRepository, IBoardRepository boardRepository)
        {
            _subjectRepository = subjectRepository;
            _boardRepository = boardRepository;
        }

        /// <summary>
        ///     Get subjects async
        /// </summary>
        /// <returns></returns>
        public async Task<List<SubjectDto>> GetSubjectsAsync()
        {
            List<Subject> subjects = await _subjectRepository.GetSubjectsAsync();
            return subjects.Adapt<List<SubjectDto>>();
        }

        /// <summary>
        ///     Get subject by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SubjectDto> GetSubjectByIdAsync(int id)
        {
            Subject subject = await _subjectRepository.GetSubjectByIdAsync(id);
            return subject.Adapt<SubjectDto>();
        }

        /// <summary>
        ///     Get subject by name async
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public async Task<SubjectDto> GetSubjectByNameAsync(string name)
        {
            Subject subject = await _subjectRepository.GetSubjectByNameAsync(name);
            return subject.Adapt<SubjectDto>();
        }

        /// <summary>
        ///  Create subject async
        /// </summary>
        /// <param name="subjectDto"></param>
        /// <returns></returns>
        public async Task<CreateSubjectResponseModel> CreateSubjectAsync(SubjectDto subjectDto)
        {
            Subject subject = subjectDto.Adapt<Subject>();
            Subject subjectCreated = await _subjectRepository.CreateSubjectAsync(subject);

            return new CreateSubjectResponseModel()
            {
                Type = SubjectResponseType.Success,
                Subject = subjectCreated.Adapt<SubjectDto>()
            };
        }

        /// <summary>
        ///  Edit subject async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="subjectDto"></param>
        /// <returns></returns>
        public async Task<EditSubjectResponseModel> EditSubjectAsync(int id, SubjectDto subjectDto)
        {
            Subject subject = await _subjectRepository.GetSubjectByIdAsync(id);

            if (subject == null)
            {
                return new EditSubjectResponseModel()
                {
                    Type = SubjectResponseType.SubjectNotFound
                };
            }

            subjectDto.Id = subject.Id;

            Subject subjectModel = subjectDto.Adapt<Subject>();
            Subject subjectEdited = await _subjectRepository.EditSubjectAsync(subjectModel);

            return new EditSubjectResponseModel()
            {
                Type = SubjectResponseType.Success,
                Subject = subjectEdited.Adapt<SubjectDto>()
            };

        }

        /// <summary>
        ///  Delete subject async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<SubjectResponseType> DeleteSubjectAsync(int id)
        {
            Subject subject = await _subjectRepository.GetSubjectByIdAsync(id);

            if (subject == null)
            {
                return SubjectResponseType.SubjectNotFound;
            }

            Board board = await _boardRepository.GetBoardBySubjectIdAsync(subject.Id);

            if (board != null)
            {
                return SubjectResponseType.SubjectUse;
            }

            await _subjectRepository.DeleteSubjectAsync(subject);

            return SubjectResponseType.Success;
        }
    }
}
