using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using TinyCollege.DataAccess;

namespace TinyCollege.Modules
{
    public class ViewModelLocator:ObservableObject
    {
        private static readonly IRepository Repository = new EfRepository();

        public ViewModelLocator()
        {
            StudentModule = new StudentModule(Repository);
            SchoolModule = new SchoolModule(Repository);
            RoomModule = new RoomModule(Repository);
            ProfessorModule = new ProfessorModule(Repository);
            EnrollmentModule = new EnrollmentModule(Repository);
            DepartmentModule = new DepartmentModule(Repository);
            CourseModule = new CourseModule(Repository);
            ClassModule = new ClassModule(Repository);
            BuildingModule = new BuildingModule(Repository);
        }

        public StudentModule StudentModule { get; set; }
        public SchoolModule SchoolModule { get; set; }
        public RoomModule RoomModule { get; set; }
        public ProfessorModule ProfessorModule { get; set; }
        public EnrollmentModule EnrollmentModule { get; set; }
        public DepartmentModule DepartmentModule { get; set; }
        public CourseModule CourseModule { get; set; }
        public ClassModule ClassModule { get; set; }
        public BuildingModule BuildingModule { get; set; }
    }

    public class ViewModelLocatorStatic
    {
        public static ViewModelLocator Locator { get; } = Application.Current.Resources["Locator"] as ViewModelLocator;
    }
}
