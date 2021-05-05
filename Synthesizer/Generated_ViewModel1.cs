using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;




namespace Synthesizer
{
    public partial class MainWindowViewModel : INotifyPropertyChanged
    {
       /* readonly Dispatcher _dispatcher;*/

        public event PropertyChangedEventHandler PropertyChanged;

        Visibility _MidiVisibility = default;

        void Raise_MidiVisibility()
        {
            OnPropertyChanged("MidiVisibility");
        }

        public Visibility MidiVisibility
        {
            get { return _MidiVisibility; }
            set
            {
                if (_MidiVisibility == value)
                {
                    return;
                }

                var prev = _MidiVisibility;

                _MidiVisibility = value;

                Changed_MidiVisibility(prev, _MidiVisibility);

                Raise_MidiVisibility();
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_MidiVisibility(Visibility prev, Visibility current);



        Visibility _OctaveVisibility = default;

        void Raise_OctaveVisibility()
        {
            OnPropertyChanged("OctaveVisibility");
        }

        public Visibility OctaveVisibility
        {
            get { return _OctaveVisibility; }
            set
            {
                if (_OctaveVisibility == value)
                {
                    return;
                }

                var prev = _OctaveVisibility;

                _OctaveVisibility = value;

                Changed_OctaveVisibility(prev, _OctaveVisibility);

                Raise_OctaveVisibility();
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_OctaveVisibility(Visibility prev, Visibility current);

        bool _MidiEnabled = false;

        void Raise_MidiEnabled()
        {
            OnPropertyChanged("MidiEnabled");
        }

        public bool MidiEnabled
        {
            get { return _MidiEnabled; }
            set
            {
                if (_MidiEnabled == value)
                {
                    return;
                }

                var prev = _MidiEnabled;

                _MidiEnabled = value;

                Changed_MidiEnabled(prev, _MidiEnabled);

                Raise_MidiEnabled();
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_MidiEnabled(bool prev, bool current);
        // --------------------------------------------------------------------
        // END_PROPERTY: MidiEnabled (bool)
        // --------------------------------------------------------------------

        // --------------------------------------------------------------------
        // BEGIN_PROPERTY: MidiDevice (string)
        // --------------------------------------------------------------------
        string _MidiDevice = default;

        void Raise_MidiDevice()
        {
            OnPropertyChanged("MidiDevice");
        }

        public string MidiDevice
        {
            get { return _MidiDevice; }
            set
            {
                if (_MidiDevice == value)
                {
                    return;
                }

                var prev = _MidiDevice;

                _MidiDevice = value;

                Changed_MidiDevice(prev, _MidiDevice);

                Raise_MidiDevice();
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_MidiDevice(string prev, string current);
        // --------------------------------------------------------------------
        // END_PROPERTY: MidiDevice (string)
        // --------------------------------------------------------------------

        // --------------------------------------------------------------------
        // BEGIN_COLLECTION_PROPERTY: MidiDevices (string)
        // --------------------------------------------------------------------
        ObservableCollection<string> _MidiDevices = new ObservableCollection<string>();

        void Raise_MidiDevices()
        {
        }

        public ObservableCollection<string> MidiDevices
        {
            get { return _MidiDevices; }
        }





        // --------------------------------------------------------------------
        // BEGIN_PROPERTY: Volume (double)
        // --------------------------------------------------------------------
        double _Volume = default;

        void Raise_Volume ()
        {
          OnPropertyChanged ("Volume");
        }

        public double Volume
        {
            get { return _Volume; }
            set
            {
                if (_Volume == value)
                {
                    return;
                }

                var prev = _Volume;

                _Volume = value;

                Changed_Volume (prev, _Volume);

                Raise_Volume ();
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_Volume (double prev, double current);
        // --------------------------------------------------------------------
        // END_PROPERTY: Volume (double)
        // --------------------------------------------------------------------

        // --------------------------------------------------------------------
        // BEGIN_PROPERTY: VolumeLabel (string)
        // --------------------------------------------------------------------
        string _VolumeLabel = default;

        void Raise_VolumeLabel ()
        {
          OnPropertyChanged ("VolumeLabel");
        }

        public string VolumeLabel
        {
            get { return _VolumeLabel; }
            set
            {
                if (_VolumeLabel == value)
                {
                    return;
                }

                var prev = _VolumeLabel;

                _VolumeLabel = value;

                Changed_VolumeLabel (prev, _VolumeLabel);

                Raise_VolumeLabel ();
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_VolumeLabel (string prev, string current);
        // --------------------------------------------------------------------
        // END_PROPERTY: VolumeLabel (string)
        // --------------------------------------------------------------------

        // --------------------------------------------------------------------
        // BEGIN_PROPERTY: FrequencyAmplitudes (float[])
        // --------------------------------------------------------------------
        float[] _FrequencyAmplitudes = default;

        void Raise_FrequencyAmplitudes ()
        {
          OnPropertyChanged ("FrequencyAmplitudes");
        }

        public float[] FrequencyAmplitudes
        {
            get { return _FrequencyAmplitudes; }
            set
            {
                if (_FrequencyAmplitudes == value)
                {
                    return;
                }

                var prev = _FrequencyAmplitudes;

                _FrequencyAmplitudes = value;

                Changed_FrequencyAmplitudes (prev, _FrequencyAmplitudes);

                Raise_FrequencyAmplitudes ();
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_FrequencyAmplitudes (float[] prev, float[] current);
        // --------------------------------------------------------------------
        // END_PROPERTY: FrequencyAmplitudes (float[])
        // --------------------------------------------------------------------

        // --------------------------------------------------------------------
        // BEGIN_PROPERTY: Waveform (float[])
        // --------------------------------------------------------------------
        float[] _Waveform = default;

        void Raise_Waveform ()
        {
          OnPropertyChanged ("Waveform");
        }

        public float[] Waveform
        {
            get { return _Waveform; }
            set
            {
                if (_Waveform == value)
                {
                    return;
                }

                var prev = _Waveform;

                _Waveform = value;

                Changed_Waveform (prev, _Waveform);

                Raise_Waveform ();
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_Waveform (float[] prev, float[] current);
        // --------------------------------------------------------------------
        // END_PROPERTY: Waveform (float[])
        // --------------------------------------------------------------------

        // --------------------------------------------------------------------
        // BEGIN_PROPERTY: Attack (float)
        // --------------------------------------------------------------------
        float _Attack = default;

        void Raise_Attack ()
        {
          OnPropertyChanged ("Attack");
        }

        public float Attack
        {
            get { return _Attack; }
            set
            {
                if (_Attack == value)
                {
                    return;
                }

                var prev = _Attack;

                _Attack = value;

                Changed_Attack (prev, _Attack);

                Raise_Attack ();
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_Attack (float prev, float current);
        // --------------------------------------------------------------------
        // END_PROPERTY: Attack (float)
        // --------------------------------------------------------------------

        // --------------------------------------------------------------------
        // BEGIN_PROPERTY: AttackLabel (string)
        // --------------------------------------------------------------------
        string _AttackLabel = default;

        void Raise_AttackLabel ()
        {
          OnPropertyChanged ("AttackLabel");
        }

        public string AttackLabel
        {
            get { return _AttackLabel; }
            set
            {
                if (_AttackLabel == value)
                {
                    return;
                }

                var prev = _AttackLabel;

                _AttackLabel = value;

                Changed_AttackLabel (prev, _AttackLabel);

                Raise_AttackLabel ();
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_AttackLabel (string prev, string current);
        // --------------------------------------------------------------------
        // END_PROPERTY: AttackLabel (string)
        // --------------------------------------------------------------------

        // --------------------------------------------------------------------
        // BEGIN_PROPERTY: Decay (float)
        // --------------------------------------------------------------------
        float _Decay = default;

        void Raise_Decay ()
        {
          OnPropertyChanged ("Decay");
        }

        public float Decay
        {
            get { return _Decay; }
            set
            {
                if (_Decay == value)
                {
                    return;
                }

                var prev = _Decay;

                _Decay = value;

                Changed_Decay (prev, _Decay);

                Raise_Decay ();
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_Decay (float prev, float current);
        // --------------------------------------------------------------------
        // END_PROPERTY: Decay (float)
        // --------------------------------------------------------------------

        // --------------------------------------------------------------------
        // BEGIN_PROPERTY: DecayLabel (string)
        // --------------------------------------------------------------------
        string _DecayLabel = default;

        void Raise_DecayLabel ()
        {
          OnPropertyChanged ("DecayLabel");
        }

        public string DecayLabel
        {
            get { return _DecayLabel; }
            set
            {
                if (_DecayLabel == value)
                {
                    return;
                }

                var prev = _DecayLabel;

                _DecayLabel = value;

                Changed_DecayLabel (prev, _DecayLabel);

                Raise_DecayLabel ();
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_DecayLabel (string prev, string current);
        // --------------------------------------------------------------------
        // END_PROPERTY: DecayLabel (string)
        // --------------------------------------------------------------------

        // --------------------------------------------------------------------
        // BEGIN_PROPERTY: Sustain (float)
        // --------------------------------------------------------------------
        float _Sustain = default;

        void Raise_Sustain ()
        {
          OnPropertyChanged ("Sustain");
        }

        public float Sustain
        {
            get { return _Sustain; }
            set
            {
                if (_Sustain == value)
                {
                    return;
                }

                var prev = _Sustain;

                _Sustain = value;

                Changed_Sustain (prev, _Sustain);

                Raise_Sustain ();
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_Sustain (float prev, float current);
        // --------------------------------------------------------------------
        // END_PROPERTY: Sustain (float)
        // --------------------------------------------------------------------

        // --------------------------------------------------------------------
        // BEGIN_PROPERTY: SustainLabel (string)
        // --------------------------------------------------------------------
        string _SustainLabel = default;

        void Raise_SustainLabel ()
        {
          OnPropertyChanged ("SustainLabel");
        }

        public string SustainLabel
        {
            get { return _SustainLabel; }
            set
            {
                if (_SustainLabel == value)
                {
                    return;
                }

                var prev = _SustainLabel;

                _SustainLabel = value;

                Changed_SustainLabel (prev, _SustainLabel);

                Raise_SustainLabel ();
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_SustainLabel (string prev, string current);
        // --------------------------------------------------------------------
        // END_PROPERTY: SustainLabel (string)
        // --------------------------------------------------------------------

        // --------------------------------------------------------------------
        // BEGIN_PROPERTY: Release (float)
        // --------------------------------------------------------------------
        float _Release = default;

        void Raise_Release ()
        {
          OnPropertyChanged ("Release");
        }

        public float Release
        {
            get { return _Release; }
            set
            {
                if (_Release == value)
                {
                    return;
                }

                var prev = _Release;

                _Release = value;

                Changed_Release (prev, _Release);

                Raise_Release ();
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_Release (float prev, float current);
        // --------------------------------------------------------------------
        // END_PROPERTY: Release (float)
        // --------------------------------------------------------------------

        // --------------------------------------------------------------------
        // BEGIN_PROPERTY: ReleaseLabel (string)
        // --------------------------------------------------------------------
        string _ReleaseLabel = default;

        void Raise_ReleaseLabel ()
        {
          OnPropertyChanged ("ReleaseLabel");
        }

        public string ReleaseLabel
        {
            get { return _ReleaseLabel; }
            set
            {
                if (_ReleaseLabel == value)
                {
                    return;
                }

                var prev = _ReleaseLabel;

                _ReleaseLabel = value;

                Changed_ReleaseLabel (prev, _ReleaseLabel);

                Raise_ReleaseLabel ();
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_ReleaseLabel (string prev, string current);
        // --------------------------------------------------------------------
        // END_PROPERTY: ReleaseLabel (string)
        // --------------------------------------------------------------------

        // --------------------------------------------------------------------
        // BEGIN_PROPERTY: CutOff (int)
        // --------------------------------------------------------------------
        int _CutOff = default;

        void Raise_CutOff ()
        {
          OnPropertyChanged ("CutOff");
        }

        public int CutOff
        {
            get { return _CutOff; }
            set
            {
                if (_CutOff == value)
                {
                    return;
                }

                var prev = _CutOff;

                _CutOff = value;

                Changed_CutOff (prev, _CutOff);

                Raise_CutOff ();
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_CutOff (int prev, int current);
        // --------------------------------------------------------------------
        // END_PROPERTY: CutOff (int)
        // --------------------------------------------------------------------

        // --------------------------------------------------------------------
        // BEGIN_PROPERTY: CutOffLabel (string)
        // --------------------------------------------------------------------
        string _CutOffLabel = default;

        void Raise_CutOffLabel ()
        {
          OnPropertyChanged ("CutOffLabel");
        }

        public string CutOffLabel
        {
            get { return _CutOffLabel; }
            set
            {
                if (_CutOffLabel == value)
                {
                    return;
                }

                var prev = _CutOffLabel;

                _CutOffLabel = value;

                Changed_CutOffLabel (prev, _CutOffLabel);

                Raise_CutOffLabel ();
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_CutOffLabel (string prev, string current);
        // --------------------------------------------------------------------
        // END_PROPERTY: CutOffLabel (string)
        // --------------------------------------------------------------------

        // --------------------------------------------------------------------
        // BEGIN_PROPERTY: Q (float)
        // --------------------------------------------------------------------
        float _Q = default;

        void Raise_Q ()
        {
          OnPropertyChanged ("Q");
        }

        public float Q
        {
            get { return _Q; }
            set
            {
                if (_Q == value)
                {
                    return;
                }

                var prev = _Q;

                _Q = value;

                Changed_Q (prev, _Q);

                Raise_Q ();
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_Q (float prev, float current);
        // --------------------------------------------------------------------
        // END_PROPERTY: Q (float)
        // --------------------------------------------------------------------

        // --------------------------------------------------------------------
        // BEGIN_PROPERTY: QLabel (string)
        // --------------------------------------------------------------------
        string _QLabel = default;

        void Raise_QLabel ()
        {
          OnPropertyChanged ("QLabel");
        }

        public string QLabel
        {
            get { return _QLabel; }
            set
            {
                if (_QLabel == value)
                {
                    return;
                }

                var prev = _QLabel;

                _QLabel = value;

                Changed_QLabel (prev, _QLabel);

                Raise_QLabel ();
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_QLabel (string prev, string current);
        // --------------------------------------------------------------------
        // END_PROPERTY: QLabel (string)
        // --------------------------------------------------------------------

        // --------------------------------------------------------------------
        // BEGIN_PROPERTY: TremoloFreq (int)
        // --------------------------------------------------------------------
        int _TremoloFreq = default;

        void Raise_TremoloFreq ()
        {
          OnPropertyChanged ("TremoloFreq");
        }

        public int TremoloFreq
        {
            get { return _TremoloFreq; }
            set
            {
                if (_TremoloFreq == value)
                {
                    return;
                }

                var prev = _TremoloFreq;

                _TremoloFreq = value;

                Changed_TremoloFreq (prev, _TremoloFreq);

                Raise_TremoloFreq ();
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_TremoloFreq (int prev, int current);
        // --------------------------------------------------------------------
        // END_PROPERTY: TremoloFreq (int)
        // --------------------------------------------------------------------

        // --------------------------------------------------------------------
        // BEGIN_PROPERTY: TremoloGain (float)
        // --------------------------------------------------------------------
        float _TremoloGain = default;

        void Raise_TremoloGain ()
        {
          OnPropertyChanged ("TremoloGain");
        }

        public float TremoloGain
        {
            get { return _TremoloGain; }
            set
            {
                if (_TremoloGain == value)
                {
                    return;
                }

                var prev = _TremoloGain;

                _TremoloGain = value;

                Changed_TremoloGain (prev, _TremoloGain);

                Raise_TremoloGain ();
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_TremoloGain (float prev, float current);
        // --------------------------------------------------------------------
        // END_PROPERTY: TremoloGain (float)
        // --------------------------------------------------------------------



        int _TremoloFreqMult = default;

        void Raise_TremoloFreqMult()
        {
            OnPropertyChanged("TremoloFreqMult");
            OnPropertyChanged("TremoloFreqMultLabel");
        }

        public string TremoloFreqMultLabel => $"x{TremoloFreqMult}";

        public int TremoloFreqMult
        {
            get { return _TremoloFreqMult; }
            set
            {
                if (_TremoloFreqMult == value)
                {
                    return;
                }

                var prev = _TremoloFreqMult;

                _TremoloFreqMult = value;

                Changed_TremoloFreqMult(prev, _TremoloFreqMult);

                Raise_TremoloFreqMult();
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_TremoloFreqMult(int prev, int current);

        // --------------------------------------------------------------------
        // BEGIN_PROPERTY: ChorusWidth (float)
        // --------------------------------------------------------------------
        float _ChorusWidth = default;

        void Raise_ChorusWidth()
        {
            OnPropertyChanged("ChorusWidth");
            OnPropertyChanged("ChorusWidthLabel");
        }

        public string ChorusWidthLabel => $"{((int)(ChorusWidth * 100.0f) / 100.0f)}";

        public float ChorusWidth
        {
            get { return _ChorusWidth; }
            set
            {
                if (_ChorusWidth == value)
                {
                    return;
                }

                var prev = _ChorusWidth;

                _ChorusWidth = value;

                Changed_ChorusWidth(prev, _ChorusWidth);

                Raise_ChorusWidth();
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_ChorusWidth(float prev, float current);
        // --------------------------------------------------------------------
        // END_PROPERTY: ChorusWidth (float)
        // --------------------------------------------------------------------

        // --------------------------------------------------------------------
        // BEGIN_PROPERTY: ChorusSweep (float)
        // --------------------------------------------------------------------
        float _ChorusSweep = default;

        void Raise_ChorusSweep()
        {
            OnPropertyChanged("ChorusSweep");
            OnPropertyChanged("ChorusSweepLabel");
        }

        public string ChorusSweepLabel => $"{((int)(ChorusSweep * 100.0f) / 100.0f)}";

        public float ChorusSweep
        {
            get { return _ChorusSweep; }
            set
            {
                if (_ChorusSweep == value)
                {
                    return;
                }

                var prev = _ChorusSweep;

                _ChorusSweep = value;

                Changed_ChorusSweep(prev, _ChorusSweep);

                Raise_ChorusSweep();
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_ChorusSweep(float prev, float current);
        // --------------------------------------------------------------------
        // END_PROPERTY: ChorusSweep (float)
        // --------------------------------------------------------------------

        // --------------------------------------------------------------------
        // BEGIN_PROPERTY: ChorusDelay (float)
        // --------------------------------------------------------------------
        float _ChorusDelay = default;

        void Raise_ChorusDelay()
        {
            OnPropertyChanged("ChorusDelay");
            OnPropertyChanged("ChorusDelayLabel");
        }

        public string ChorusDelayLabel => $"{((int)(ChorusDelay * 100.0f) / 100.0f)}";

        public float ChorusDelay
        {
            get { return _ChorusDelay; }
            set
            {
                if (_ChorusDelay == value)
                {
                    return;
                }

                var prev = _ChorusDelay;

                _ChorusDelay = value;

                Changed_ChorusDelay(prev, _ChorusDelay);

                Raise_ChorusDelay();
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_ChorusDelay(float prev, float current);
        // --------------------------------------------------------------------
        // END_PROPERTY: ChorusDelay (float)
        // --------------------------------------------------------------------
        // --------------------------------------------------------------------
        // BEGIN_PROPERTY: PhaserDry (float)
        // --------------------------------------------------------------------
        float _PhaserDry = default;

        void Raise_PhaserDry()
        {
            OnPropertyChanged("PhaserDry");
            OnPropertyChanged("PhaserDryLabel");
        }

        public string PhaserDryLabel => $"{((int)(PhaserDry * 100.0f) / 100.0f)}";

        public float PhaserDry
        {
            get { return _PhaserDry; }
            set
            {
                if (_PhaserDry == value)
                {
                    return;
                }

                var prev = _PhaserDry;

                _PhaserDry = value;

                Changed_PhaserDry(prev, _PhaserDry);

                Raise_PhaserDry();
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_PhaserDry(float prev, float current);
        // --------------------------------------------------------------------
        // END_PROPERTY: PhaserDry (float)
        // --------------------------------------------------------------------

        // --------------------------------------------------------------------
        // BEGIN_PROPERTY: PhaserWet (float)
        // --------------------------------------------------------------------
        float _PhaserWet = default;

        void Raise_PhaserWet()
        {
            OnPropertyChanged("PhaserWet");
            OnPropertyChanged("PhaserWetLabel");
        }

        public string PhaserWetLabel => $"{((int)(PhaserWet * 100.0f) / 100.0f)}";

        public float PhaserWet
        {
            get { return _PhaserWet; }
            set
            {
                if (_PhaserWet == value)
                {
                    return;
                }

                var prev = _PhaserWet;

                _PhaserWet = value;

                Changed_PhaserWet(prev, _PhaserWet);

                Raise_PhaserWet();
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_PhaserWet(float prev, float current);
        // --------------------------------------------------------------------
        // END_PROPERTY: PhaserWet (float)
        // --------------------------------------------------------------------

        // --------------------------------------------------------------------
        // BEGIN_PROPERTY: PhaserFeedback (float)
        // --------------------------------------------------------------------
        float _PhaserFeedback = default;

        void Raise_PhaserFeedback()
        {
            OnPropertyChanged("PhaserFeedback");
            OnPropertyChanged("PhaserFeedbackLabel");
        }

        public string PhaserFeedbackLabel => $"{((int)(PhaserFeedback * 100.0f) / 100.0f)}";

        public float PhaserFeedback
        {
            get { return _PhaserFeedback; }
            set
            {
                if (_PhaserFeedback == value)
                {
                    return;
                }

                var prev = _PhaserFeedback;

                _PhaserFeedback = value;

                Changed_PhaserFeedback(prev, _PhaserFeedback);

                Raise_PhaserFeedback();
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_PhaserFeedback(float prev, float current);
        // --------------------------------------------------------------------
        // END_PROPERTY: PhaserFeedback (float)
        // --------------------------------------------------------------------

        // --------------------------------------------------------------------
        // BEGIN_PROPERTY: PhaserFreq (float)
        // --------------------------------------------------------------------
        float _PhaserFreq = default;

        void Raise_PhaserFreq()
        {
            OnPropertyChanged("PhaserFreq");
            OnPropertyChanged("PhaserFreqLabel");
        }

        public string PhaserFreqLabel => $"{((int)(PhaserFreq * 100.0f) / 100.0f)}";

        public float PhaserFreq
        {
            get { return _PhaserFreq; }
            set
            {
                if (_PhaserFreq == value)
                {
                    return;
                }

                var prev = _PhaserFreq;

                _PhaserFreq = value;

                Changed_PhaserFreq(prev, _PhaserFreq);

                Raise_PhaserFreq();
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_PhaserFreq(float prev, float current);
        // --------------------------------------------------------------------
        // END_PROPERTY: PhaserFreq (float)
        // --------------------------------------------------------------------

        // --------------------------------------------------------------------
        // BEGIN_PROPERTY: PhaserWidth (float)
        // --------------------------------------------------------------------
        float _PhaserWidth = default;

        void Raise_PhaserWidth()
        {
            OnPropertyChanged("PhaserWidth");
            OnPropertyChanged("PhaserWidthLabel");
        }

        public string PhaserWidthLabel => $"{((int)(PhaserWidth * 100.0f) / 100.0f)}";

        public float PhaserWidth
        {
            get { return _PhaserWidth; }
            set
            {
                if (_PhaserWidth == value)
                {
                    return;
                }

                var prev = _PhaserWidth;

                _PhaserWidth = value;

                Changed_PhaserWidth(prev, _PhaserWidth);

                Raise_PhaserWidth();
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_PhaserWidth(float prev, float current);
        // --------------------------------------------------------------------
        // END_PROPERTY: PhaserWidth (float)
        // --------------------------------------------------------------------

        // --------------------------------------------------------------------
        // BEGIN_PROPERTY: PhaserSweep (float)
        // --------------------------------------------------------------------
        float _PhaserSweep = default;

        void Raise_PhaserSweep()
        {
            OnPropertyChanged("PhaserSweep");
            OnPropertyChanged("PhaserSweepLabel");
        }

        public string PhaserSweepLabel => $"{((int)(PhaserSweep * 100.0f) / 100.0f)}";

        public float PhaserSweep
        {
            get { return _PhaserSweep; }
            set
            {
                if (_PhaserSweep == value)
                {
                    return;
                }

                var prev = _PhaserSweep;

                _PhaserSweep = value;

                Changed_PhaserSweep(prev, _PhaserSweep);

                Raise_PhaserSweep();
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_PhaserSweep(float prev, float current);
        // --------------------------------------------------------------------
        // END_PROPERTY: PhaserSweep (float)
        // --------------------------------------------------------------------


        


        readonly UserCommand _MidiOnCommand;

        bool CanExecuteMidiOnCommand()
        {
            bool result = false;
            CanExecute_MidiOnCommand(ref result);

            return result;
        }

        void ExecuteMidiOnCommand()
        {
            Execute_MidiOnCommand();
        }

        public ICommand MidiOnCommand { get { return _MidiOnCommand; } }
        // --------------------------------------------------------------------
        partial void CanExecute_MidiOnCommand(ref bool result);
        partial void Execute_MidiOnCommand();
        // --------------------------------------------------------------------
        // END_COMMAND: MidiOnCommand
        // --------------------------------------------------------------------

        // --------------------------------------------------------------------
        // BEGIN_COMMAND: MidiOffCommand
        // --------------------------------------------------------------------
        readonly UserCommand _MidiOffCommand;

        bool CanExecuteMidiOffCommand()
        {
            bool result = false;
            CanExecute_MidiOffCommand(ref result);

            return result;
        }

        void ExecuteMidiOffCommand()
        {
            Execute_MidiOffCommand();
        }

        public ICommand MidiOffCommand { get { return _MidiOffCommand; } }
        // --------------------------------------------------------------------
        partial void CanExecute_MidiOffCommand(ref bool result);
        partial void Execute_MidiOffCommand();
        // --------------------------------------------------------------------
        // END_COMMAND: MidiOffCommand
        // --------------------------------------------------------------------

        // --------------------------------------------------------------------
        // BEGIN_COMMAND: LoadPatchCommand
        // -------------------------------------------------------------------- 
        private UserCommandWithParametrs _LoadPatchCommand;
        
        bool CanExecuteLoadPatchCommand(    )
        {
            bool result = false;
            result = true;

            return result;
        }

        void ExecuteLoadPatchCommand(object id)
        {
            Execute_LoadPatchCommand(id);
        }

        public ICommand LoadPatchCommand { get { return _LoadPatchCommand; } }
        // --------------------------------------------------------------------
        partial void CanExecute_LoadPatchCommand(ref bool result);
        partial void Execute_LoadPatchCommand(object id);
        // --------------------------------------------------------------------
        // END_COMMAND: LoadPatchCommand
        // --------------------------------------------------------------------

        // --------------------------------------------------------------------
        // BEGIN_COMMAND: SavePatchCommand
        // --------------------------------------------------------------------
        readonly UserCommand _SavePatchCommand;

        bool CanExecuteSavePatchCommand()
        {
            bool result = false;
            CanExecute_SavePatchCommand(ref result);

            return result;
        }

        void ExecuteSavePatchCommand()
        {
            Execute_SavePatchCommand();
        }

        public ICommand SavePatchCommand { get { return _SavePatchCommand; } }
        // --------------------------------------------------------------------
        partial void CanExecute_SavePatchCommand(ref bool result);
        partial void Execute_SavePatchCommand();
        // --------------------------------------------------------------------
        // END_COMMAND: SavePatchCommand
        // --------------------------------------------------------------------

        private UserCommandWithParametrs _DeletePatchCommand;

        bool CanExecuteDeletePatchCommand()
        {
            bool result = false;
            result = true;

            return result;
        }

        void ExecuteDeletePatchCommand(object id)
        {
            Execute_DeletePatchCommand(id);
        }

        public ICommand DeletePatchCommand { get { return _DeletePatchCommand; } }
        // --------------------------------------------------------------------
        partial void CanExecute_DeletePatchCommand(ref bool result);
        partial void Execute_DeletePatchCommand(object id);

        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            Stop();
        }




        partial void Constructed ();

        public MainWindowViewModel (/*Dispatcher dispatcher*/)
        {
            /*_dispatcher = dispatcher;*/
            /*_MidiOnCommand = new UserCommand(CanExecuteMidiOnCommand, ExecuteMidiOnCommand);
            _MidiOffCommand = new UserCommand(CanExecuteMidiOffCommand, ExecuteMidiOffCommand);*/
            _DeletePatchCommand = new UserCommandWithParametrs(CanExecuteDeletePatchCommand, ExecuteDeletePatchCommand);
            _LoadPatchCommand = new UserCommandWithParametrs(CanExecuteLoadPatchCommand, ExecuteLoadPatchCommand);
            _SavePatchCommand = new UserCommand(CanExecuteSavePatchCommand, ExecuteSavePatchCommand);
            _MidiOnCommand = new UserCommand(CanExecuteMidiOnCommand, ExecuteMidiOnCommand);
            _MidiOffCommand = new UserCommand(CanExecuteMidiOffCommand, ExecuteMidiOffCommand);
           
            Constructed ();
        }

       

        void ResetCanExecute()
        {
            
            _MidiOnCommand.RefreshCanExecute();
            _MidiOffCommand.RefreshCanExecute();
            _LoadPatchCommand.RefreshCanExecute();
            _SavePatchCommand.RefreshCanExecute();
        }

       /* void Dispatch(Action action)
        {
            _dispatcher.BeginInvoke(action);
        }*/
        protected virtual void OnPropertyChanged (string propertyChanged)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyChanged));
        }

        string _Name = default;

        void EditName()
        {
            OnPropertyChanged("Name");
        }

        public string Name
        {
            get { return _Name; }
            set
            {
                if (_Name == value)
                {
                    return;
                }

                var prev = _Name;

                _Name = value;

                Changed_Name(prev, _Name);

              
            }
        }

        string _LoginName = default;
        void EditLoginName()
        {
            OnPropertyChanged("LoginName");
        }

        public string LoginName
        {
            get { return _LoginName; }
            set
            {
                if (_LoginName == value)
                {
                    return;
                }

                var prev = _LoginName;

                _LoginName = value;

                Changed_LoginName(prev, _LoginName);

           
            }
        }

        string _ValidateBlock = default;
        void EditValidateBlock()
        {
            OnPropertyChanged("ValidateBlock");
        }

        public string ValidateBlock
        {
            get { return _ValidateBlock; }
            set
            {
                if (_ValidateBlock == value)
                {
                    return;
                }

                var prev = _ValidateBlock;

                _ValidateBlock = value;

                EditValidateBlock();


            }
        }


        partial void Changed_Name(string prev, string current);
        partial void Changed_LoginName(string prev, string current);

      

    }
}

