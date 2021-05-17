using NAudio.Wave.SampleProviders;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Synthesizer
{
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel _viewModel;

        public MainWindow(MainWindowViewModel _viewModel)
        {
            
            InitializeComponent();
             this._viewModel = _viewModel;
             DataContext = _viewModel;
             Closing += _viewModel.OnWindowClosing;
            
        }

       
        

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            _viewModel.KeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            _viewModel.KeyUp(e);
        }

        
       

       
        
       

    
    }
}
