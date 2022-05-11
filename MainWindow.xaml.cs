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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            var vm = (MainWindowViewModel)DataContext;
            ((MainWindowViewModel)DataContext).OpenDialog += (s, ev) =>
            {
                DialogWindow dialog = new DialogWindow();
                dialog.ShowDialog();
                var dialogVM = (DialogWindowViewModel)dialog.DataContext;
                vm.ModalResult = dialogVM.Input;
            };
        }
    }
}
