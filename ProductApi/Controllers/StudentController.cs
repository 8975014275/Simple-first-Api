using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Model;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public StudentController(ApplicationDbContext db)
        {
            _db = db;


        }
        [HttpGet]
        public List<Student> getStudent()
        {
            var studentlist = _db.Students.ToList();
            return studentlist;
        }
        [HttpPost]
        public IActionResult InsertStudent(Student std)
        {
            _db.Students.Add(std);
            _db.SaveChanges();
            return NoContent();
        }
        [HttpPut]
        public IActionResult UpdateStudent(Student p)
        {
            var stud = _db.Students.Where(i => i.StudentID == p.StudentID).First();
            stud.StudentID = p.StudentID;
            stud.Name = p.Name;
            stud.ContactNumber = p.ContactNumber;
            stud.Age = p.Age;
            _db.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var stud = _db.Students.Where(i => i.StudentID == id).First();
            _db.Students.Remove(stud);
            _db.SaveChanges();
            return NoContent();
        }
        [HttpGet("{id}")]
        public Student getStudentby(int id)
        {
            var stud = _db.Students.Where(i => i.StudentID == id).First();

           return stud;
        }

    }
}
