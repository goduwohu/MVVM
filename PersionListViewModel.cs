using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    public class PersionListViewModel : BaseViewModel
    {
        public EventHandler MissingData;

        public PersionListViewModel()
        {
            AddPersonCommand = new DelegateCommand((o) =>
            {
                if (string.IsNullOrWhiteSpace(NewPerson.Firstname) || string.IsNullOrWhiteSpace(NewPerson.Lastname))
                {
                    MissingData?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    Persons.Add(NewPerson);
                    NewPerson = new Person();
                }
            });

            listData.Add(new Person() { Firstname = "Max", Lastname = "Muster", Department = "Sales" });
            listData.Add(new Person() { Firstname = "Susi", Lastname = "Müller", Department = "Backoffice" });
            listData.Add(new Person() { Firstname = "Dave", Lastname = "Dev", Department = "Development" });

            foreach (Person person in listData)
                Persons.Add(person);
        }


        ObservableCollection<Person> listData = new ObservableCollection<Person>();

        string filter;

        public string Filter
        {
            get => filter;
            set
            {
                if (filter != value)
                {
                    filter = value;
                    RaisePropertyChanged();
                    DoFilter();
                }
            }
        }

        ObservableCollection<Person> persons = new ObservableCollection<Person>();

        public ObservableCollection<Person> Persons { get => persons;
            set
            {
                if(persons != value)
                {
                    persons = value;
                    RaisePropertyChanged();
                }
            }
        }

        public Person newPerson = new Person();

        public Person NewPerson { get => newPerson;
            set
            {
                if (newPerson != value)
                {
                    newPerson = value;
                    RaisePropertyChanged();
                }
            }
        }

        public DelegateCommand AddPersonCommand { get; set; }


        private void DoFilter()
        {
            if (!string.IsNullOrWhiteSpace(Filter))
            {
                Persons.Clear();
                foreach(Person person in listData)
                {
                    if (person.Fullname.ToLower().Contains(Filter))
                        Persons.Add(person);
                        
                }
            }
            else
            {
                Persons.Clear();
                foreach (Person person in listData)
                    Persons.Add(person);
            }
        }
    }
}
