using Microsoft.AspNetCore.Mvc;
using Timetable.Database.Models;
using Timetable.Infrastructure.Enums;
using Timetable.Infrastructure.Models;
using Timetable.Infrastructure.ServiceModels.Subject;
using Timetable.Infrastructure.Services.Interfaces;

namespace Timetable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;

        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet("GetSubjects")]
        public async Task<IActionResult> GetSubjects()
        {
            List<SubjectDto> subjects = await _subjectService.GetSubjectsAsync();

            return Ok(subjects);
        }

        [HttpGet("GetSubject/{id}")]
        public async Task<IActionResult> GetSubject(int id)
        {
            SubjectDto subject = await _subjectService.GetSubjectByIdAsync(id);

            return Ok(subject);
        }
        [HttpGet("GetSubjectByName/{name}")]
        public async Task<IActionResult> GetSubject(string name)
        {
            SubjectDto subject = await _subjectService.GetSubjectByNameAsync(name);

            return Ok(subject);
        }


        [HttpPost]
        public async Task<IActionResult> Post(SubjectDto subject)
        {
            CreateSubjectResponseModel createSubjectResponse = await _subjectService.CreateSubjectAsync(subject);

            if (createSubjectResponse.Type == SubjectResponseType.Success)
            {
                return Ok(createSubjectResponse);
            }

            return BadRequest(createSubjectResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, SubjectDto subject)
        {
            EditSubjectResponseModel editSubjectResponse = await _subjectService.EditSubjectAsync(id, subject);

            if (editSubjectResponse.Type == SubjectResponseType.Success)
            {
                return Ok(editSubjectResponse);
            }

            return BadRequest(editSubjectResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            SubjectResponseType subjectResponse = await _subjectService.DeleteSubjectAsync(id);

            if (subjectResponse == SubjectResponseType.Success)
            {
                return Ok(subjectResponse);
            }

            return BadRequest(subjectResponse);
        }
    }
}
