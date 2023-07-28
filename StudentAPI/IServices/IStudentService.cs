using Shared;

namespace StudentAPI.IServices
{
    public interface IStudentService
    {
        //list all
        Task<IEnumerable<Student>> GetStudents();
        //1 doi tuong
        Task<Student> GetStudent(int id);
        //them
        Task<Student> AddStudent(Student student);
        //sua
        Task<Student> UpdateStudent(Student student);
        //xoa
        Task<Student> DeleteStudent(int id);
    }
}
