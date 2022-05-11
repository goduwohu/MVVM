using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    public class CalculatorViewModel : BaseViewModel
    {
        public CalculatorViewModel()
        {
            this.NumberCommand = new DelegateCommand((value) => 
            {
                int val = int.Parse(value.ToString());
                CurrentValue = val;
            });

            this.OperatorCommand = new DelegateCommand((o) =>
            {
                string op = o.ToString();
            });
        }

        int currValue;
        public int CurrentValue
        {
            get => currValue;
            set
            {
                if (currValue != value)
                {
                    currValue = value;
                    RaisePropertyChanged();
                }
            }
        }

        public DelegateCommand NumberCommand { get; set; }
        public DelegateCommand OperatorCommand { get; set; }
    }

    
}
