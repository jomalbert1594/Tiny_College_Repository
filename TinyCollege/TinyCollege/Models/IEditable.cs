using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TinyCollege.Models
{
    public interface IEditable<T>
    {
        bool IsEditing { get; }
        EditModelBase<T> EditModel { get; }
        ICommand SaveCommand { get; }
        ICommand EditCommand { get; }
        ICommand CancelCommand { get; }
    }
}
