using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM
{
    public class DialogWindowViewModel :BaseViewModel
    {
        public event EventHandler Ok;
        public event EventHandler Cancel;

        public DialogWindowViewModel()
        {
            this.OkCommand = new DelegateCommand((o) => this.Ok?.Invoke(this, EventArgs.Empty));
            this.CancelCommand = new DelegateCommand((o) => 
            {
                Input = "";
                this.Cancel?.Invoke(this, EventArgs.Empty);
            });
        }

        private string input;
        public string Input
        {
            get => input;
            set
            {
                if (input != value)
                {
                    input = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ICommand OkCommand { get; set; }
        public ICommand CancelCommand { get; set; }
    }
}
