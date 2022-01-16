using FluentAssertions;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timetable.Database.Models;
using Timetable.Database.Repositories.Interfaces;
using Timetable.Infrastructure.Models.Database;
using Timetable.Infrastructure.Models.Service.Board;
using Timetable.Infrastructure.Services;
using Xunit;

namespace Timetable.Tests.Services
{
    /// <summary>
    ///     Board service test
    /// </summary>
    public class BoardServiceTest
    {
        Mock<IBoardRepository> boardRepositoryMock;
        Mock<IGroupRepository> groupRepositoryMock;
        Mock<ISubjectRepository> subjectRepositoryMock;
        Mock<ITeacherRepository> teacherRepositoryMock;

        public BoardServiceTest()
        {
            boardRepositoryMock = new Mock<IBoardRepository>();
            groupRepositoryMock = new Mock<IGroupRepository>();
            subjectRepositoryMock = new Mock<ISubjectRepository>();
            teacherRepositoryMock = new Mock<ITeacherRepository>();
        }

        [Fact]
        public async Task GetBoards_ShouldReturn_Boards()
        {
            //arrange
            var boards = GetTestBoards();

            boardRepositoryMock.Setup(r => r.GetBoardsAsync()).Returns(Task.FromResult(boards.Adapt<List<Board>>()));

            BoardService service = new BoardService(boardRepositoryMock.Object, groupRepositoryMock.Object, subjectRepositoryMock.Object, teacherRepositoryMock.Object);

            //act
            List<BoardDto> result = await service.GetBoardsAsync();

            //assert
            boards.Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task GetBoardById_ShouldReturn_Board()
        {
            //arrange
            var boards = GetTestBoards();

            boardRepositoryMock.Setup(r => r.GetBoardByIdAsync(boards[0].Id)).Returns(Task.FromResult(boards[0].Adapt<Board>()));

            BoardService service = new BoardService(boardRepositoryMock.Object, groupRepositoryMock.Object, subjectRepositoryMock.Object, teacherRepositoryMock.Object);

            //act
            BoardDto result = await service.GetBoardByIdAsync(boards[0].Id);

            //assert
            boards[0].Should().BeEquivalentTo(result);
        }

        [Fact]
        public async Task AddBoard_ShouldReturn_Board()
        {
            //arrange
            var groups = GetTestGroups();
            var subjects = GetTestSubjects();
            var teachers = GetTestTeachers();

            BoardDto board = new BoardDto()
            {
                Id = 11,
                GroupId = groups[0].Id,
                SubjectId = subjects[0].Id,
                TeacherId = teachers[0].Id,
                Day = DateTime.Now,
                Time = DateTime.Now
            };

            boardRepositoryMock.Setup(r => r.CreateBoardAsync(board.Adapt<Board>())).Returns(Task.FromResult(board.Adapt<Board>()));
            groupRepositoryMock.Setup(r => r.GetGroupByIdAsync(groups[0].Id)).Returns(Task.FromResult(groups[0].Adapt<Group>()));
            subjectRepositoryMock.Setup(r => r.GetSubjectByIdAsync(subjects[0].Id)).Returns(Task.FromResult(subjects[0].Adapt<Subject>()));
            teacherRepositoryMock.Setup(r => r.GetTeacherByIdAsync(teachers[0].Id)).Returns(Task.FromResult(teachers[0].Adapt<Teacher>()));

            BoardService service = new BoardService(boardRepositoryMock.Object, groupRepositoryMock.Object, subjectRepositoryMock.Object, teacherRepositoryMock.Object);

            //act
            CreateBoardResponseModel result = await service.CreateBoardAsync(board);

            //assert
            Assert.True(result.Type == Infrastructure.Enums.BoardResponseType.Success);
        }

        private List<BoardDto> GetTestBoards()
        {
            List<BoardDto> boards = new List<BoardDto>
            {
                new BoardDto
                {
                    Id = 1,
                    GroupId = 1,
                    SubjectId = 1,
                    TeacherId = 1,
                    Day = DateTime.Now,
                    Time = DateTime.Now
                },

                new BoardDto
                {
                    Id = 2,
                    GroupId = 1,
                    SubjectId = 1,
                    TeacherId = 1,
                    Day = DateTime.Now.AddDays(1),
                    Time = DateTime.Now.AddHours(1)
                }
            };

            return boards;
        }

        private List<GroupDto> GetTestGroups()
        {
            List<GroupDto> groups = new List<GroupDto>
            {
                new GroupDto
                {
                    Id = 1,
                    GroupNumber = 202011
                },
                new GroupDto{
                    Id = 2,
                    GroupNumber = 202022
                }
            };

            return groups;
        }

        private List<SubjectDto> GetTestSubjects()
        {
            List<SubjectDto> subjects = new List<SubjectDto>
            {
                new SubjectDto
                {
                    Id = 1,
                    SubjectName = "Math"
                },
                new SubjectDto{
                    Id = 2,
                    SubjectName = "History"
                }
            };

            return subjects;
        }

        private List<TeacherDto> GetTestTeachers()
        {
            List<TeacherDto> teachers = new List<TeacherDto>
            {
                new TeacherDto
                {
                    Id = 1,
                    FirstName = "Jora",
                    LastName = "Coreto",
                },
                new TeacherDto{
                    Id = 2,
                    FirstName = "Mikkle",
                    LastName = "Poiskov",
                }
            };

            return teachers;
        }
    }
}
