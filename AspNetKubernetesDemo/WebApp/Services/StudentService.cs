using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Flurl;
using WebApp.Models;

namespace WebApp.Services
{
    public class StudentService : IStudentService
    {
        private readonly HttpClient _httpClient;

        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Student>> Get() =>
            await JsonSerializer.DeserializeAsync<List<Student>>(
                await _httpClient.GetStreamAsync(
                    string.Empty),
                new JsonSerializerOptions(JsonSerializerDefaults.Web));

        public async Task<Student> Get(int id) =>
            await JsonSerializer.DeserializeAsync<Student>(
                await _httpClient.GetStreamAsync(
                    _httpClient.BaseAddress.AppendPathSegment(id)),
                new JsonSerializerOptions(JsonSerializerDefaults.Web));

        public async Task Post(Student student) =>
            await _httpClient.PostAsync(
                string.Empty,
                JsonContent.Create(student));

        public async Task Delete(int id) =>
            await _httpClient.DeleteAsync(
                _httpClient.BaseAddress.AppendPathSegment(id));
    }
}
