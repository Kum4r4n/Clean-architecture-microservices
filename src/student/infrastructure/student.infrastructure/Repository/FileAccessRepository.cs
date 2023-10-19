using student.application.IRepository;
using student.domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace student.infrastructure.Repository
{
    public class FileAccessRepository : IFileAccessRepository
    {
        private readonly string _path;

        public FileAccessRepository()
        {
            var basePath = Directory.GetCurrentDirectory();
            var projectLocation = Path.Combine(basePath, "../../", "infrastructure", "student.infrastructure");

            _path = Path.Combine(projectLocation, "Application.json");

        }

        public async Task Add(Student student)
        {
            var data = await ReadJson() ?? new List<Student>();
            int nextId = data.Select(s => s.Id).Max() + 1;
            student.Id = nextId;
            data.Add(student);
            await Store(data);
        }


        public async Task<List<Student>> Get()
        {
            var data = await ReadJson();
            return data;
        }


        private async Task Store(List<Student> students)
        {
            var stream = new StreamWriter(_path);
            var data = JsonSerializer.Serialize(students);
            await stream.WriteAsync(data);
            stream.Close();
        }


        private async Task<List<Student>> ReadJson()
        {

            var stream = new StreamReader(_path);
            var dataString = await stream.ReadToEndAsync();
            
            var data = JsonSerializer.Deserialize<List<Student>>(dataString);
            stream.Close();
            return data;
        }
    }
}
