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

       
        private void SetWaveform(object sender, RoutedEventArgs e)
        {
            var selector = sender as RadioButton;

            if (_viewModel != null)
            {
                switch (selector.Name)
                {
                    case "Sine":
                        _viewModel.WaveType = SignalGeneratorType.Sin;
                        break;
                    case "SawTooth":
                        _viewModel.WaveType = SignalGeneratorType.SawTooth;
                        break;
                    case "Square":
                        _viewModel.WaveType = SignalGeneratorType.Square;
                        break;
                    case "Triangle":
                        _viewModel.WaveType = SignalGeneratorType.Triangle;
                        break;
                    case "White":
                        _viewModel.WaveType = SignalGeneratorType.Pink;
                        break;
                }
            }
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

        private void LowPassFilter_Checked(object sender, RoutedEventArgs e)
        {
            if (_viewModel != null)
            {
                _viewModel.EnableLpf = true;
            }
        }
        private void On_Checked(object sender, RoutedEventArgs e)
        {
            if (_viewModel != null)
            {
                _viewModel.Start();
            }
        }

        private void On_Unchecked(object sender, RoutedEventArgs e)
        {
            if (_viewModel != null)
            {
                _viewModel.Stop();
            }
        }

        private void LowPassFilter_Unchecked(object sender, RoutedEventArgs e)
        {
            if (_viewModel != null)
            {
                _viewModel.EnableLpf = false;
            }
        }

        private void SubOscillator_Checked(object sender, RoutedEventArgs e)
        {
            if (_viewModel != null)
            {
                _viewModel.EnableSubOsc = true;
            }
        }

        private void SubOscillator_Unchecked(object sender, RoutedEventArgs e)
        {
            if (_viewModel != null)
            {
                _viewModel.EnableSubOsc = false;
            }
        }

        private void Vibrato_Checked(object sender, RoutedEventArgs e)
        {
            if (_viewModel != null)
            {
                _viewModel.EnableVibrato = true;
            }
        }

        private void Vibrato_Unchecked(object sender, RoutedEventArgs e)
        {
            if (_viewModel != null)
            {
                _viewModel.EnableVibrato = false;
            }
        }
        private void Tremolo_Checked(object sender, RoutedEventArgs e)
        {
            if (_viewModel != null)
            {
                _viewModel.TremoloGain = 0.2f;
            }
        }

        private void Tremolo_Unchecked(object sender, RoutedEventArgs e)
        {
            if (_viewModel != null)
            {
                _viewModel.TremoloGain = 0.0f;
            }
        }

    
    }
}
