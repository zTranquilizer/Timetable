using Mapster;
using Timetable.Database.Models;
using Timetable.Database.Repositories.Interfaces;
using Timetable.Infrastructure.Enums;
using Timetable.Infrastructure.Models.Database;
using Timetable.Infrastructure.Models.Service.Board;
using Timetable.Infrastructure.Services.Interfaces;

namespace Timetable.Infrastructure.Services
{
    /// <summary>
    ///     Board service
    /// </summary>
    public class BoardService : IBoardService
    {
        private readonly IBoardRepository _boardRepository;
        private readonly IGroupRepository _groupRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly ITeacherRepository _teacherRepository;

        public BoardService(IBoardRepository boardRepository, IGroupRepository groupRepository, ISubjectRepository subjectRepository, ITeacherRepository teacherRepository)
        {
            _boardRepository = boardRepository;
            _groupRepository = groupRepository;
            _subjectRepository = subjectRepository;
            _teacherRepository = teacherRepository;

        }

        /// <summary>
        ///     Get boards async
        /// </summary>
        /// <returns></returns>
        public async Task<List<BoardDto>> GetBoardsAsync()
        {
            List<Board> boards = await _boardRepository.GetBoardsAsync();
            return boards.Adapt<List<BoardDto>>();
        }

        /// <summary>
        ///     Get board by id async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BoardDto> GetBoardByIdAsync(int id)
        {
            Board board = await _boardRepository.GetBoardByIdAsync(id);
            return board.Adapt<BoardDto>();
        }

        /// <summary>
        ///     Create board async
        /// </summary>
        /// <param name="boardDto"></param>
        /// <returns></returns>
        public async Task<CreateBoardResponseModel> CreateBoardAsync(BoardDto boardDto)
        {
            Board board = boardDto.Adapt<Board>();

            Group group = await _groupRepository.GetGroupByIdAsync(boardDto.GroupId);

            if (group == null)
            {
                return new CreateBoardResponseModel()
                {
                    Type = BoardResponseType.GroupNotFound,
                };
            }

            Subject subject = await _subjectRepository.GetSubjectByIdAsync(boardDto.SubjectId);

            if (subject == null)
            {
                return new CreateBoardResponseModel()
                {
                    Type = BoardResponseType.SubjectNotFound,
                };
            }

            Teacher teacher = await _teacherRepository.GetTeacherByIdAsync(boardDto.TeacherId);

            if (teacher == null)
            {
                return new CreateBoardResponseModel()
                {
                    Type = BoardResponseType.TeacherNotFound,
                };
            }

            List<Board> boards = await _boardRepository.GetBoardsAsync();

            if (boards != null && boards.Any(x => x.Day == board.Day && x.Time == board.Time && x.TeacherId == teacher.Id))
            {
                return new CreateBoardResponseModel()
                {
                    Type = BoardResponseType.TimeOrDayIsBusy
                };
            }

            if (boards != null && boards.Any(x => x.Day == board.Day && x.Time == board.Time && x.GroupId == group.Id))
            {
                return new CreateBoardResponseModel()
                {
                    Type = BoardResponseType.TimeOrDayIsBusy
                };
            }

            Board boardCreated = await _boardRepository.CreateBoardAsync(board);

            return new CreateBoardResponseModel()
            {
                Type = BoardResponseType.Success,
                Board = boardCreated.Adapt<BoardDto>()
            };
        }

        /// <summary>
        ///     Edit board async
        /// </summary>
        /// <param name="id"></param>
        /// <param name="boardDto"></param>
        /// <returns></returns>
        public async Task<EditBoardResponseModel> EditBoardAsync(int id, BoardDto boardDto)
        {
            Board board = await _boardRepository.GetBoardByIdAsync(id);

            if (board == null)
            {
                return new EditBoardResponseModel()
                {
                    Type = BoardResponseType.BoardNotFound
                };
            }

            Group group = await _groupRepository.GetGroupByIdAsync(boardDto.GroupId);

            if (group == null)
            {
                return new EditBoardResponseModel()
                {
                    Type = BoardResponseType.GroupNotFound,
                };
            }

            Subject subject = await _subjectRepository.GetSubjectByIdAsync(boardDto.SubjectId);

            if (subject == null)
            {
                return new EditBoardResponseModel()
                {
                    Type = BoardResponseType.SubjectNotFound,
                };
            }

            Teacher teacher = await _teacherRepository.GetTeacherByIdAsync(boardDto.TeacherId);

            if (teacher == null)
            {
                return new EditBoardResponseModel()
                {
                    Type = BoardResponseType.TeacherNotFound,
                };
            }

            boardDto.Id = board.Id;

            Board boardModel = boardDto.Adapt<Board>();
            Board boardEdited = await _boardRepository.EditBoardAsync(boardModel);

            return new EditBoardResponseModel()
            {
                Type = BoardResponseType.Success,
                Board = boardEdited.Adapt<BoardDto>()
            };

        }

        /// <summary>
        ///     Delete board async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<BoardResponseType> DeleteBoardAsync(int id)
        {
            Board board = await _boardRepository.GetBoardByIdAsync(id);

            if (board == null)
            {
                return BoardResponseType.BoardNotFound;
            }

            Group group = await _groupRepository.GetGroupByIdAsync(board.GroupId);

            if (group != null)
            {
                return BoardResponseType.GroupStudying;
            }

            Subject subject = await _subjectRepository.GetSubjectByIdAsync(board.SubjectId);

            if (group != null)
            {
                return BoardResponseType.SubjectUse;
            }

            Teacher teacher = await _teacherRepository.GetTeacherByIdAsync(board.TeacherId);

            if (group != null)
            {
                return BoardResponseType.TeacherWorking;
            }

            await _boardRepository.DeleteBoardAsync(board);

            return BoardResponseType.Success;
        }
    }
}
