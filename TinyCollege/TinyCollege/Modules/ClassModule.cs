using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Ink;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Nito.AsyncEx;
using TinyCollege.DataAccess;
using TinyCollege.DataAccess.Ef;
using TinyCollege.Models;
using TinyCollege.Models.Class;
using TinyCollege.Models.Course;
using TinyCollege.Models.Enrollment;
using TinyCollege.Models.Grade;
using TinyCollege.Models.Professor;
using TinyCollege.Models.Student;
using TinyCollege.Reports.Class;
using TinyCollege.Reports.Professor;
using TinyCollege.Views.Class;
using TinyCollege.Views.Professor;

namespace TinyCollege.Modules
{
    public class ClassModule:ObservableObject
    {
        private IRepository _repository;

        public ClassModule(IRepository repository)
        {
            _repository = repository;
            ClassLoading = NotifyTaskCompletion.Create(() => LoadClassesAsync());

        }
        public ObservableCollection<ClassModel> ClassList { get; } = new ObservableCollection<ClassModel>();
        public ObservableCollection<ClassModel> IdleClassList { get; } = new ObservableCollection<ClassModel>(); 
        public ObservableCollection<ClassModel> ModuleClassList { get; } = new ObservableCollection<ClassModel>();
        

        private ClassModel _selectedModuleClass;

        public ClassModel SelectedModuleClass
        {
            get { return _selectedModuleClass; }
            set
            {
                _selectedModuleClass = value;
                if (value != null)
                {
                    _selectedModuleClass.LoadRelatedInfo();
                }
                RaisePropertyChanged(nameof(SelectedModuleClass));
            }
        }


        private ClassModel _selectedClass;
        public ClassModel SelectedClass
        {
            get { return _selectedClass; }
            set
            {
                _selectedClass = value;
                if (value != null)
                {
                    if (ClassEditModel != null)
                    {
                        ClassEditModel.ClassId = SelectedClass.Model.ClassId;
                        ClassEditModel.ClassName = SelectedClass.Model.ClassName;
                        ClassEditModel.CourseId = SelectedClass.Model.CourseId;
                        ClassEditModel.RoomId = SelectedClass.Model.RoomId;
                        ClassEditModel.ProfessorId = SelectedProfessor.Model.ProfessorId;
                    }

                }
                RaisePropertyChanged(nameof(SelectedClass));
            }
        }

        private ClassNewModel _newClass;
        public ClassNewModel NewClass
        {
            get { return _newClass; }
            set
            {
                _newClass = value;
                RaisePropertyChanged(nameof(NewClass));
            }
        }

        private StudentModel _selectedStudent;

        public StudentModel SelectedStudent
        {
            get { return _selectedStudent; }
            set
            {
                _selectedStudent = value;
                RaisePropertyChanged(nameof(SelectedStudent));
            }
        }


        private ProfessorModel _selectedProfessor;
        public ProfessorModel SelectedProfessor
        {
            get { return _selectedProfessor; }
            set
            {
                _selectedProfessor = value;
                if (value != null)
                {
                    _selectedProfessor.LoadRelatedInfo();
                }
                RaisePropertyChanged(nameof(SelectedProfessor));
            }
        }


        private ProfessorEditModel _professorEditModel;
        public ProfessorEditModel ProfessorEditModel
        {
            get { return _professorEditModel; }
            set
            {
                _professorEditModel = value;
                RaisePropertyChanged(nameof(ProfessorEditModel));
            }
        }

        private ClassEditModel _classEditModel;
        public ClassEditModel ClassEditModel
        {
            get { return _classEditModel; }
            set
            {
                _classEditModel = value;
                RaisePropertyChanged(nameof(ClassEditModel));
            }
        }


        public ICommand PrintClassModuleCommand => new RelayCommand(PrintClassModuleProc);

        private ClassListReportWindow _classListReportWindow;
        private void PrintClassModuleProc()
        {
            _classListReportWindow = new ClassListReportWindow();
            _classListReportWindow.Owner = Application.Current.MainWindow;
            _classListReportWindow.Show();
        }


        public ICommand PrintClassStudentListCommand => new RelayCommand(PrintClassStudentListProc);

        private ProfessorClassListReportWindow _professorClassListReportWindow;
        private  void PrintClassStudentListProc()
        {
            _professorClassListReportWindow = new ProfessorClassListReportWindow();
            _professorClassListReportWindow.Owner = Application.Current.MainWindow;
            _professorClassListReportWindow.Show();
        }

        public ICommand ViewProfessorStudentsCommand => new RelayCommand(ViewProfessorStudentsProc, ViewProfessorStudentsCondition);

        private bool ViewProfessorStudentsCondition()
        {
            return (SelectedClass != null);
        }

        private void ViewProfessorStudentsProc()
        {
            if (SelectedClass == null) return;

            try
            {
                SelectedProfessor.IsViewingClassList = true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to Generate Stundent List", "View Student", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        public ICommand CancelViewProfessorStudentsCommand => new RelayCommand(CancelViewProfessorStudentsProc);

        private void CancelViewProfessorStudentsProc()
        {
            SelectedProfessor.IsViewingClassList = false;
        }

        public ICommand EditStudentGradeCommand => new RelayCommand(EditStudentGradeProc);

        private void EditStudentGradeProc()
        {
            SelectedClass.IsGradeEditing = true;
            SelectedClass.EditClassesGrades.Clear();
            foreach (var student in SelectedClass.Students)
            {
                SelectedClass.EditClassesGrades.Add(new GradeEditModel(student.Grade.Model));
            }
        }

        public ICommand SaveStudentGradeCommand => new RelayCommand(SaveStudentGradeProc);

        private async Task SaveStudentGradeProcAsync()
        {
            try
            {
                var nextStudent = 0;
                foreach (var grade in SelectedClass.EditClassesGrades)
                {
                    await _repository.Grade.UpdateAsync(grade.ModelCopy, CancellationToken.None);
                    SelectedClass.Students[nextStudent].Grade.Model = grade.ModelCopy;
                    nextStudent++;
                }
                SelectedClass.IsGradeEditing = false;
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to Edit!", "Edit Grades", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void SaveStudentGradeProc()
        {
            await SaveStudentGradeProcAsync();
        }

        public ICommand cancelStudentGradeCommand => new RelayCommand(CancelEditStudentGradesProc);

        private void CancelEditStudentGradesProc()
        {
            throw new NotImplementedException();
        }

        public ICommand AddProfessorClassCommand => new RelayCommand(AddProfessorClassProc);

        private ProfessorClassAddingWindow _addClassWindow;
        private void AddProfessorClassProc()
        {
            SelectedClass = null;
            ProfessorEditModel = new ProfessorEditModel(SelectedProfessor.Model);
            _addClassWindow = new ProfessorClassAddingWindow {Owner = Application.Current.MainWindow};
            _addClassWindow.ShowDialog();
        }

        public ICommand SaveProfessorClassCommand => new RelayCommand(SaveProfessorClassProc, SaveProfessorClassCondition);

        private bool SaveProfessorClassCondition()
        {
            return (SelectedClass != null);
        }

        private async Task SaveProfessorClassProcAsync()
        {
            if (SelectedClass == null) return;

            try
            {
                if (IsProfessorScheduleConflict()) return;
                SelectedClass.Model.ProfessorId = SelectedProfessor.Model.ProfessorId;

                if (ProfessorEditModel.CurrentUnits == null)
                {
                    ProfessorEditModel.CurrentUnits = 0;
                }

                ProfessorEditModel.NoOfSubjects = ProfessorEditModel.NoOfSubjects + 1;

                ProfessorEditModel.CurrentUnits = ProfessorEditModel.CurrentUnits +
                                                  SelectedClass.Course.Model.CourseUnits;

                if (ProfessorEditModel.NoOfSubjects > 4)
                {
                    ProfessorEditModel.NoOfSubjects = ProfessorEditModel.NoOfSubjects - 1;

                    MessageBox.Show("The no. of sujects exceeds the limit!", "Assign Class!", MessageBoxButton.OK,
                        MessageBoxImage.Exclamation);

                    return;
                }

                ClassList.Add(SelectedClass);
                SelectedClass.LoadRelatedInfo();
                await _repository.Class.UpdateAsync(SelectedClass.Model,CancellationToken.None);
                await _repository.Professor.UpdateAsync(ProfessorEditModel.ModelCopy, CancellationToken.None);
                SelectedProfessor.Model = ProfessorEditModel.ModelCopy;
                IdleClassList.Remove(SelectedClass);
                SelectedProfessor.LoadRelatedInfo();
                _addClassWindow.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show("Unable To Save!", "Assign Class", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private async void SaveProfessorClassProc()
        {
            await SaveProfessorClassProcAsync();
        }

        public ICommand DeleteProfessorClassCommand => new RelayCommand(DeleteProfessorClassProc, DeleteProfessorClassCondition);

        private bool DeleteProfessorClassCondition()
        {
            return (SelectedClass != null);
        }

        private async Task DeleteProfessorAsync()
        {
            ProfessorEditModel = new ProfessorEditModel(SelectedProfessor.Model);
            ClassList.Remove(SelectedClass);
            IdleClassList.Add(SelectedClass);
            ClassEditModel = new ClassEditModel(SelectedClass.Model) { ProfessorId = null };
            ProfessorEditModel.CurrentUnits = ProfessorEditModel.CurrentUnits - SelectedClass.Course.Model.CourseUnits;
            ProfessorEditModel.NoOfSubjects = ProfessorEditModel.NoOfSubjects - 1;
            await _repository.Professor.UpdateAsync(ProfessorEditModel.ModelCopy, CancellationToken.None);
            SelectedProfessor.Model = ProfessorEditModel.ModelCopy;
            await _repository.Class.UpdateAsync(ClassEditModel.ModelCopy, CancellationToken.None);
            SelectedClass.Model = ClassEditModel.ModelCopy;
            SelectedProfessor.Classes.Remove(SelectedClass);
        }

        private async void DeleteProfessorClassProc()
        {
            await DeleteProfessorAsync();
        }

        public ICommand CancelProfessorclassCommand => new RelayCommand(CancelProfessorclassProc);

        private void CancelProfessorclassProc()
        {
            SelectedClass = null;
            _addClassWindow.Close();
        }

        public ICommand AddClassCommand => new RelayCommand(AddClassProc);

        private AddingClassWindow _addingClassWindow;
        private void AddClassProc()
        {
            NewClass?.Dispose();
            NewClass = new ClassNewModel {ClassId = GenerateId()};
            NewClass.ScheduleList.Clear();
            NewClass.ScheduleList.Add(new Schedule());
            _addingClassWindow = new AddingClassWindow {Owner = Application.Current.MainWindow};
            _addingClassWindow.ShowDialog();
        }

        public ICommand SaveClassCommand => new RelayCommand(SaveClassProc, SaveClassCondition);

        private bool SaveClassCondition()
        {
            return (NewClass != null) && NewClass.HasChanges && !NewClass.HasErrors;
        }

        private async Task SaveClassProcAsync()
        {
            if (NewClass == null) return;
            if (!NewClass.HasChanges) return;
            try
            {
                GenerateSchedule();
                if (IsThereAConflict()) return;
                await _repository.Class.AddAsync(NewClass.ModelCopy, CancellationToken.None);
                var newclass = new ClassModel(NewClass.ModelCopy, _repository);
                newclass.LoadRelatedInfo();
                ModuleClassList.Add(newclass);
                IdleClassList.Add(newclass);
                _addingClassWindow.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to Save!", "Add Deparmtent");
            }
        }

        private async void SaveClassProc()
        {
            await SaveClassProcAsync();
        }

        private bool IsProfessorScheduleConflict()
        {
            var filteredclassesbyrooms = new ObservableCollection<ClassModel>();
            var classes = SelectedProfessor.Classes;
            var classesCollection = new ObservableCollection<ClassModel>();
            foreach (var item in classes)
            {
                classesCollection.Add(item);
            }

            foreach (var item in classesCollection)
            {
                var classroom = _repository.Class.Get(c => c.ClassId == item.Model.ClassId);
                filteredclassesbyrooms.Add(new ClassModel(classroom, _repository));
            }

            var days = SelectedClass.Model.Day.Split('\n').ToList();
            days.Remove("");
            var filteredclassesbydays = new ObservableCollection<ClassModel>();
            foreach (var day in days)
            {
                foreach (var item in filteredclassesbyrooms.Where(c => c.Model.Day.Contains(day)))
                {
                    filteredclassesbydays.Add(item);
                }
            }

            var timeintervals = SelectedClass.Model.Time.Split('\n').ToList();
            timeintervals.Remove("");
            var daytimeindex = 0;
            var countconflicts = 0;

            foreach (var time in timeintervals)
            {
                foreach (var time2 in filteredclassesbydays)
                {
                    var timeintervalscomparedto = time2.Model.Time.Split('\n').ToList();
                    var dayscomparedto = time2.Model.Day.Split('\n').ToList();
                    dayscomparedto.Remove("");
                    timeintervalscomparedto.Remove("");
                    foreach (var time3 in timeintervalscomparedto)
                    {
                        try
                        {
                            if (!IsTimeInBetween(time.Trim(), time3.Trim()))
                                continue;

                            countconflicts++;
                            break;
                        }
                        catch (Exception e) { }
                    }

                    daytimeindex = 0;
                }
            }

            if (countconflicts > 0)
            {
                MessageBox.Show("Schedule Conflicts with the other Subjects!", "Add Schedule", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return true;
            }

            return false;
        }


        private bool IsThereAConflict()
        {
            var filteredclassesbyrooms = new ObservableCollection<ClassModel>();
            var classesroom = _repository.Class.GetRange(c => c.RoomId == NewClass.ModelCopy.RoomId);
            foreach (var item in classesroom)
            {
                filteredclassesbyrooms.Add(new ClassModel(item, _repository));
            }

            var days = NewClass.Day.Split('\n').ToList();
            days.Remove("");
            var filteredclassesbydays = new ObservableCollection<ClassModel>();
            foreach (var day in days)
            {
                foreach (var item in filteredclassesbyrooms.Where(c => c.Model.Day.Contains(day)))
                {
                    filteredclassesbydays.Add(item);
                }
            }

            var timeintervals = NewClass.Time.Split('\n').ToList();
            timeintervals.Remove("");
            var daytimeindex = 0;
            var countconflicts = 0;

            foreach (var time in timeintervals)
            {
                foreach (var time2 in filteredclassesbydays)
                {
                    var timeintervalscomparedto = time2.Model.Time.Split('\n').ToList();
                    var dayscomparedto = time2.Model.Day.Split('\n').ToList();
                    dayscomparedto.Remove("");
                    timeintervalscomparedto.Remove("");
                    foreach (var time3 in timeintervalscomparedto)
                    {
                        try
                        {
                            if (!IsTimeInBetween(time.Trim(), time3.Trim()))
                            {
                                daytimeindex++;
                                continue;
                            }
                            var times = time.Split('-').ToList();
                            times.Remove("");
                            var timesobservable = new ObservableCollection<string>();
                            foreach (var item in times)
                            {
                                timesobservable.Add(item.Trim());
                            }

                            var schedule = NewClass.ScheduleList.FirstOrDefault(s => s.TimeStart == DateTime.Parse(timesobservable[0].Trim())
                                                                                && s.TimeEnd == DateTime.Parse(timesobservable[1].Trim())
                                                                                && dayscomparedto.Contains(days[daytimeindex]));
                            days.Remove(days[daytimeindex]);
                            NewClass.ScheduleList.Remove(schedule);

                            countconflicts++;
                            break;
                        }
                        catch (Exception e) { }
                    }

                    daytimeindex = 0;
                }
            }

            if (countconflicts > 0)
            {
                MessageBox.Show("Schedule Conflicts with the other Subjects!", "Add Schedule", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                return true;
            }

            return false;
        }

        private bool IsTimeInBetween(string interval, string intervalcomparedto)
        {
            var timescomparedto = intervalcomparedto.Split('-').ToList();
            timescomparedto.Remove("");
            var timescomparedtoobservable = new ObservableCollection<string>();
            foreach (var item in timescomparedto)
            {
                timescomparedtoobservable.Add(item.Trim());
            }

            var times = interval.Split('-').ToList();
            times.Remove("");
            var timesobservable = new ObservableCollection<string>();
            foreach (var item in times)
            {
                timesobservable.Add(item.Trim());
            }

            if ((TimeSpan.Parse(timesobservable[0]) >= TimeSpan.Parse(timescomparedtoobservable[0])
                && (TimeSpan.Parse(timesobservable[1]) >= TimeSpan.Parse(timescomparedtoobservable[0])
                 && TimeSpan.Parse(timesobservable[1]) <= TimeSpan.Parse(timescomparedtoobservable[1]))

                || (TimeSpan.Parse(timesobservable[0]) >= TimeSpan.Parse(timescomparedtoobservable[0])
                    && TimeSpan.Parse(timesobservable[0]) <= TimeSpan.Parse(timescomparedtoobservable[1])
                    && TimeSpan.Parse(timesobservable[1]) >= TimeSpan.Parse(timescomparedtoobservable[1]))

                || (TimeSpan.Parse(timesobservable[0]) <= TimeSpan.Parse(timescomparedtoobservable[0])
                    && TimeSpan.Parse(timesobservable[1]) >= TimeSpan.Parse(timescomparedtoobservable[0])
                    && TimeSpan.Parse(timesobservable[1]) <= TimeSpan.Parse(timescomparedtoobservable[1]))))
                return true;

   
            return false;
        }

        private void GenerateSchedule()
        {
            string time = "";
            string day = "";
            foreach (var schedule in NewClass.ScheduleList)
            {
                time = time + (schedule.TimeStart.ToString("H:mm") + " - " + schedule.TimeEnd.ToString("H:mm")) + '\n';
                day = day + (schedule.SelectedDay) + '\n';
            }
            NewClass.Time = time;
            NewClass.Day = day;
        }

        public ICommand CancelClassCommand => new RelayCommand(CancelClassProc);

        private void CancelClassProc()
        {
            NewClass?.Dispose();
            _addingClassWindow.Close();
        }

        private string GenerateId() // generates the class Id
        {
            var items = _repository.Class.GetRange();

            var lastItem = new Class();
            string lastId = "";
            try
            {
                lastItem = items.Last();
                lastId = lastItem.ClassId;
                var strArray = lastId.ToCharArray();
                var tmp = string.Copy(strArray[0].ToString());
                strArray[0] = '@';
                var extract = strArray.Where(str => char.IsDigit(str)).Aggregate("", (current, str) => current + str);
                var digitalId = int.Parse(extract);
                digitalId++;
                lastId = tmp + "-" + digitalId;
            }
            catch (Exception e)
            {
                lastId = "5-00";
            }

            return lastId;
        }

        private async Task LoadModuleClassAsync()
        {
            var classes = await _repository.Class.GetRangeAsync(CancellationToken.None);

            foreach (var item in classes)
            {
                var itemclass = new ClassModel(item, _repository);
                itemclass.LoadRelatedInfo();
                ModuleClassList.Add(itemclass);
                await Task.Delay(100);
            }
        }

        private async void LoadModuleClass()
        {
            await LoadModuleClassAsync();
        }

        public INotifyTaskCompletion ClassLoading { get; set; }

        public async Task LoadClassesAsync()
        {
            LoadModuleClass();
            var classes = await _repository.Class.GetRangeAsync(CancellationToken.None);
            foreach (var item in classes.Where(i => i.ProfessorId != null))
            {
                var itemclass = new ClassModel(item, _repository);
                itemclass.LoadRelatedInfo();
                ClassList.Add(itemclass);
                await Task.Delay(100);
            } 

            var idleclasses  = await _repository.Class.GetRangeAsync(i => i.ProfessorId == null, CancellationToken.None);
            foreach (var item in idleclasses)
            {
                var itemclass = new ClassModel(item, _repository);
                itemclass.LoadRelatedInfo();
                IdleClassList.Add(itemclass);
                await Task.Delay(100);
            }
        }
    }
}
