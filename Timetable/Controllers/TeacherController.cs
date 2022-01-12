using Microsoft.AspNetCore.Mvc;
using Timetable.Infrastructure.Enums;
using Timetable.Infrastructure.Models;
using Timetable.Infrastructure.ServiceModels.Teacher;
using Timetable.Infrastructure.Services.Interfaces;

namespace Timetable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet("GetTeachers")]
        public async Task<IActionResult> GetTeachers()
        {
            List<TeacherDto> teachers = await _teacherService.GetTeachersAsync();

            return Ok(teachers);
        }

        [HttpGet("GetTeacher/{id}")]
        public async Task<IActionResult> GetTeacher(int id)
        {
            TeacherDto teacher = await _teacherService.GetTeacherByIdAsync(id);

            return Ok(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TeacherDto teacher)
        {
            CreateTeacherResponseModel createTeacherResponse = await _teacherService.CreateTeacherAsync(teacher);

            if (createTeacherResponse.Type == TeacherResponseType.Success)
            {
                return Ok(createTeacherResponse);
            }

            return BadRequest(createTeacherResponse);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, TeacherDto teacher)
        {
            EditTeacherResponseModel editTeacherResponse = await _teacherService.EditTeacherAsync(id, teacher);

            if (editTeacherResponse.Type == TeacherResponseType.Success)
            {
                return Ok(editTeacherResponse);
            }

            return BadRequest(editTeacherResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            TeacherResponseType teacherResponse = await _teacherService.DeleteTeacherAsync(id);

            if (teacherResponse == TeacherResponseType.Success)
            {
                return Ok(teacherResponse);
            }

            return BadRequest(teacherResponse);
        }
    }
}
