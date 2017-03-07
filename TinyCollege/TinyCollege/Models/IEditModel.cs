using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace TinyCollege.Models
{
    public interface IEditModel<out T>:INotifyDataErrorInfo
    {
        T ModelCopy { get; }
        T ModelOriginal { get; }
        bool HasChanges { get; }
        bool TopMostError { get; }
    }

    public class EditModelBase<T> : ObservableObject, IEditModel<T>, IDisposable
    {

        public EditModelBase(T model)
        {
            ModelOriginal = model;
            PropertyChanged += OnModelPropertyChanged;
        } 
       
        public bool HasChanges { get; set; }

        private void OnModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if ((e.PropertyName == nameof(HasChanges) || (e.PropertyName == nameof(ModelCopy))))
            {
                return;
            }

            HasChanges = true;
        }

        protected T _ModelCopy ;
        public T ModelCopy
        {
            get { return _ModelCopy; }
            set
            {
                _ModelCopy = value;
                RaisePropertyChanged(nameof(ModelCopy));
            }
        }

        protected T _ModelOriginal;
        public T ModelOriginal
        {
            get { return _ModelOriginal; }
            set
            {
                _ModelOriginal = value;
                RaisePropertyChanged(nameof(ModelOriginal));
            }
        }


        public bool TopMostError { get; protected set; }

        // Dictionary ==> Dictionary(T Key, T Value)
        private Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
                return _errors.Values;

            // provide the error collection for the requested property, if it has errors

            return _errors.ContainsKey(propertyName) ? _errors[propertyName] : null;
        }

        public bool HasErrors => _errors.Count > 0;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        protected void SetErrors(string propertyName, string propertyError)
        {
            if (_errors.ContainsKey(propertyName))
                _errors[propertyName].Add(propertyError);
            else
            {
                var propertyErrors = new List<string> { propertyError };
                _errors.Add(propertyName, propertyErrors);
            }

            RaisePropertyChanged(nameof(TopMostError));
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        protected void ClearError(string propertyName)
        {
            // Remove the the error list for this property
            _errors.Remove(propertyName);

            RaisePropertyChanged(nameof(TopMostError));
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        protected TField ValidateInputAndAddErrors<TField>(ref TField field, TField value, string propertyName,
            Func<bool> invalidInputFilter, string errorMessage, bool storeInvalidInput = true)
        {
            bool isValid = !invalidInputFilter();
            if (isValid)
            {
                ClearError(propertyName);
                field = value;
                RaisePropertyChanged(nameof(propertyName));
                return value;
            }
            else
            {
                SetErrors(propertyName, errorMessage);

                if (!storeInvalidInput) return field;
                field = value;

                RaisePropertyChanged(nameof(propertyName));
                return value;
            }
        }

        public void Dispose()
        {
            if (ModelOriginal == null) return;
            PropertyChanged -= OnModelPropertyChanged;
        }
    }
}
