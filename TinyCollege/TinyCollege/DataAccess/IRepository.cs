using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyCollege.DataAccess.Ef;

namespace TinyCollege.DataAccess
{
    public interface IRepository
    {
        IDataService<Student> Student { get; }
        IDataService<School> School { get; }
        IDataService<Room> Room { get; }
        IDataService<Professor> Professor { get; }
        IDataService<Enrollment> Enrollment { get; }
        IDataService<Department> Department { get; }
        IDataService<Course> Course { get; }
        IDataService<Class> Class { get; }
        IDataService<Building> Building { get; }
        IDataService<Grade> Grade { get; } 
          
    }

    public class EfRepository : IRepository
    {
        public IDataService<Student> Student { get; } = new EfDataService<Student>();
        public IDataService<School> School { get; } = new EfDataService<School>();
        public IDataService<Room> Room { get; } = new EfDataService<Room>();
        public IDataService<Professor> Professor { get; } = new EfDataService<Professor>();
        public IDataService<Enrollment> Enrollment { get; } = new EfDataService<Enrollment>();
        public IDataService<Department> Department { get; } = new EfDataService<Department>();
        public IDataService<Course> Course { get; } = new EfDataService<Course>();
        public IDataService<Class> Class { get; } = new EfDataService<Class>();
        public IDataService<Building> Building { get; } = new EfDataService<Building>();
        public IDataService<Grade> Grade { get; } = new EfDataService<Grade>();
    }
}
