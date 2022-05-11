using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    public class Person : BaseViewModel
    {
        private string firstname;
        public string Firstname
        {
            get => firstname;
            set 
            {
                if (firstname != value)
                {
                    firstname = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(Fullname));
                }
            }
        }

        private string lastname;
        public string Lastname 
        { 
            get => lastname; 
            set 
            { 
                if (lastname != value)
                {
                    lastname = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(Fullname));
                }
            } 
        }
        public string Fullname => $"{Firstname} {Lastname}";

        private string department;
        public string Department 
        { get => department;
            set
            {
                if (department != value)
                {
                    department = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
