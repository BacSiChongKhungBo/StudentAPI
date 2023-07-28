using Microsoft.EntityFrameworkCore;
using Shared;
using StudentAPI.Data;
using StudentAPI.IServices;

namespace StudentAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly MyStudentDbContext _context;

        //cctor tab
        public StudentService(MyStudentDbContext context)
        {
            _context = context;
        }

        public async Task<Student> AddStudent(Student student)
        {
            var result = await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Student> DeleteStudent(int id)
        {
            var result = await _context.Students.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if(result == null)
            {
                return null;
            }
            _context.Students.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<Student> GetStudent(int id)
        {
            return await _context.Students.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _context.Students.ToArrayAsync();
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            var result = await _context.Students.FirstOrDefaultAsync(x => x.Id.Equals(student.Id));
            if(result == null)
            {
                return null;
            } 
            else
            {
                result.MaSV = student.MaSV;
                result.Ten = student.Ten;
                result.lop = student.lop;

                await _context.SaveChangesAsync();
                return result;
            }
        }
    }
}
