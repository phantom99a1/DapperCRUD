using Domain.Entities;
using Domain.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IGenericRepository<Student> _genericRepository;
        public StudentController(IGenericRepository<Student> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllAsync()
        {
            var result = await _genericRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<Student?>> GetStudentById(int id)
        {
            var student = await _genericRepository.GetByIdAsync(id);
            return student == null ? NotFound() : Ok(student);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateStudent([FromBody] Student student)
        {
            try
            {
                if (student == null)
                    return BadRequest("Enter the informations to create student");
                student.UpdatedDate = DateTime.Now;
                student.CreatedDate = DateTime.Now;
                student.Deleted = false;
                student.Version = 1;
                var result = await _genericRepository.AddAsync(student);
                return result ? Ok("Student Created Successfully!") : BadRequest("Student Created Failed!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Student student)
        {
            try
            {
                if (student == null)
                    return BadRequest("Enter the informations to update student");
                var updateStudent = await _genericRepository.GetByIdAsync(id);
                if (updateStudent == null)
                    return NotFound();
                updateStudent.FirstName = student.FirstName;
                updateStudent.LastName = student.LastName;
                updateStudent.EmailAddress = student.EmailAddress;
                updateStudent.Version++;
                updateStudent.UpdatedDate = DateTime.Now;
                updateStudent.Major = student.Major;

                var result = await _genericRepository.UpdateAsync(updateStudent);
                return result ? Ok("Student Updated Successfully!") : BadRequest("Student Updated Failed!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        //[HttpDelete]
        //[Route("Delete")]
        //public async Task<IActionResult> DeleteStudent(int id)
        //{

        //}
    }
}
