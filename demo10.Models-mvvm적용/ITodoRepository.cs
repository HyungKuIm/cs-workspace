using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo10.Models
{
    public interface ITodoRepository
    {
        void Add(Todo todo);
        List<Todo> GetAll();

        //ObservableCollection<Todo> Todos { get; }
    }
}
