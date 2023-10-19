using Moq;
using student.application.IRepository;
using student.application.IService;
using student.application.Services;
using student.domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student.test
{
    public class StudentTest
    {
        private readonly Mock<IFileAccessRepository> _fileAccessMockRepo =  new Mock<IFileAccessRepository>();
        private readonly IStudentService _studentService;

        public StudentTest()
        {
            _studentService = new StudentService(_fileAccessMockRepo.Object);
        }

        [Fact]
        public async Task Get()
        {
            var dataSet = new List<Student>() { 
            
                new Student()
                {
                    Id = 6,
                    Name = "Foo",
                },
                new Student()
                {
                    Id = 7,
                    Name = "Bar",
                }
            
            };

           _fileAccessMockRepo.Setup(s=> s.Get()).ReturnsAsync(dataSet);

           var result = await _studentService.Get();

        }
    }
}
