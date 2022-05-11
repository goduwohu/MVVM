using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM
{
    class MainWindowViewModel : BaseViewModel
    {
        public event EventHandler OpenDialog;
        public ICommand OpenDialogCommand { get; set; }
        public DelegateCommand ClearCommand { get; set; }

        public MainWindowViewModel()
        {
            this.OpenDialogCommand = new DelegateCommand((o) => 
            {
                this.OpenDialog?.Invoke(this, EventArgs.Empty);
                //if (this.OpenDialog != null)
                //    this.OpenDialog(this, EventArgs.Empty);
            });

            this.ClearCommand = new DelegateCommand(
                (o) => !string.IsNullOrEmpty(firstname) || !string.IsNullOrEmpty(lastname),
                (o) => { Firstname = ""; Lastname = ""; }
            );
            
            Firstname = "Jane";
            Lastname = "Doe";
        }

        public string firstname;
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
                    //this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Firstname)));
                    //this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Fullname)));
                    ClearCommand.RaiseCanExecuteChanged();
                }
            }
        }


        public string lastname;
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
                    //this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Lastname)));
                    //this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Fullname)));
                    ClearCommand.RaiseCanExecuteChanged();

                }
            }
        }

        public string Fullname => $"{Firstname} {Lastname}";
        

        private string modalResult;
        public string ModalResult
        {
            get => modalResult;
            set
            {
                if (modalResult != value)
                {
                    modalResult = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
