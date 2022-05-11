using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MVVM
{
    /// <summary>
    /// Interaction logic for PersonList.xaml
    /// </summary>
    public partial class PersonList : Window
    {
        public PersonList()
        {
            InitializeComponent();
            ((PersionListViewModel)DataContext).MissingData += (sender, EventArgs) => ShowError();
            //((PersionListViewModel)DataContext).MissingData += EventNoneAnynm;
        }

        //private void EventNoneAnynm(object sender, EventArgs e)
        //{
        //    ShowError();
        //}

        private void ShowError()
        {
            MessageBox.Show("At least set Firstname and Lastname");
        }
    }
}
