using student.domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace student.application.IRepository
{
    public interface IFileAccessRepository
    {
        Task<List<Student>> Get();
        Task Add(Student student);
    }
}
