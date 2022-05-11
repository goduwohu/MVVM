
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM
{
    public class PersonGridViewModel : BaseViewModel
    {
        public ObservableCollection<DataGrid.Person> Persons { get; set; } = new ObservableCollection<DataGrid.Person>();
        public ObservableCollection<DataGrid.Department> Departments { get; set; } = new ObservableCollection<DataGrid.Department>();
        
        public ICommand RemoveCommand { get; set; }
        public PersonGridViewModel()
        {
            var svc = new DataGrid.PersonService();
            
            foreach (var person in svc.GetPersons())
                this.Persons.Add(person);

            foreach (var department in svc.GetDepartments())
                this.Departments.Add(department);

            this.RemoveCommand = new DelegateCommand((o) =>
            {
                if (o as DataGrid.Person != null)
                    this.Persons.Remove((DataGrid.Person)o);
            });
        }
    }
}
