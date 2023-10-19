using student.application.IRepository;
using student.application.IService;
using student.domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student.application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IFileAccessRepository _fileAccessRepository;
        public StudentService(IFileAccessRepository fileAccessRepository)
        {
            _fileAccessRepository = fileAccessRepository;
        }

        public async Task Add(Student student)
        {
          await _fileAccessRepository.Add(student);

        }

        public async Task<List<Student>> Get()
        {
            var data = await _fileAccessRepository.Get().ConfigureAwait(true);
            return data;
        }
    }
}
