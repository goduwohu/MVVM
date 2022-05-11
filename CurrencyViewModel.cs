using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    class CurrencyViewModel : BaseViewModel
    {
        decimal val;

        public decimal Value
        {
            get => val;
            set
            {
                if (val != value)
                {
                    val = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(HasNonZeroValue));
                }
            }
        }

        public bool HasNonZeroValue => Value != 0.0m;
    }
}
