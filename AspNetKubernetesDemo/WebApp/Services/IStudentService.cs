using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> Get();

        Task<Student> Get(int id);

        Task Post(Student student);

        Task Delete(int id);
    }
}