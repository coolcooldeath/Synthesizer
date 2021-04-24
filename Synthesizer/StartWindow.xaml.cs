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

namespace Synthesizer
{
    /// <summary>
    /// Логика взаимодействия для StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        private readonly StartWindowViewModel _viewModel;
        public StartWindow()
        {

            InitializeComponent();
            _viewModel = new StartWindowViewModel();
            DataContext = _viewModel;
            

        }
        
       
    }
}
