using NAudio.Dsp;
using NAudio.Midi;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using Synthesizer.DataLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Synthesizer
{
    
    public enum EnBaseFrequency
    {
        A2 = 0,
        A3 = 1,
        A4 = 2,
    }




    public partial class MainWindowViewModel
    {


        private readonly List<Key> keyboard = new List<Key>
        {
            Key.Z, Key.S, Key.X, Key.C, Key.F, Key.V, Key.G, Key.B,
            Key.N, Key.J, Key.M, Key.K, Key.OemComma, Key.L,
            Key.OemPeriod, Key.OemQuestion,
        };
        public bool Tremolo { get; set; }
        private EDM db = new EDM();
        private MidiIn midiIn;
        public users User = new users();
        public factory factory = new factory();
        public List<string> NamesOfPresets { get; set; } = new List<string>();
        
        private SynthWaveProvider[] _oscillators = new SynthWaveProvider[88];
        private VolumeSampleProvider _volControl;
        private MixingSampleProvider _mixer;
        private ChorusSampleProvider _chorus;
        private PhaserSampleProvider _phaser;
        //private FFTSampleProvider _fftProvider;
        private LowPassFilterSampleProvider _lpf;
        private TremoloSampleProvider _tremolo;
        private IWavePlayer _player;

        public double BaseFrequency { get; set; } = 110.0;
        public SignalGeneratorType WaveType { get; set; } = SignalGeneratorType.Sin;
        public bool EnableLpf { get; set; }
        public bool EnableSubOsc { get; set; }
        public bool EnableVibrato { get; set; }


        private ObservableCollection<Syntheses> _SynthesesList = new ObservableCollection<Syntheses>();
        private ObservableCollection<Syntheses> _BaseSynthesesList = new ObservableCollection<Syntheses>((new EDM()).Syntheses.Where(p => p.FactId == 19));
        private ObservableCollection<users> _UsersList = new ObservableCollection<users>((new EDM()).users);


        void Raise_SynthesesList()
        {
            OnPropertyChanged("SynthesesList");
        }

        public ObservableCollection<Syntheses> SynthesesList
        {
            get { return _SynthesesList; }
            set
            {
                if (_SynthesesList == value)
                {
                    return;
                }

                var prev = _SynthesesList;

                _SynthesesList = value;

                Changed_SynthesesList();

                Raise_SynthesesList();
            }
        }

        public void Changed_SynthesesList()
        {
            ResetCanExecute();
        }

        

        void Raise_UsersList()
        {
            OnPropertyChanged("UsersList");
        }

        public ObservableCollection<users> UsersList
        {
            get { return _UsersList; }
            set
            {
                if (_UsersList == value)
                {
                    return;
                }

                var prev = _UsersList;

                _UsersList = value;

                Changed_UsersList();

                Raise_UsersList();
            }
        }

        public void Changed_UsersList()
        {
            ResetCanExecute();
        }

        void Raise_BaseSynthesesList()
        {
            OnPropertyChanged("BaseSynthesesList");
        }

        public ObservableCollection<Syntheses> BaseSynthesesList
        {
            get { return _BaseSynthesesList; }
            set
            {
                if (_BaseSynthesesList == value)
                {
                    return;
                }

                var prev = _BaseSynthesesList;

                _BaseSynthesesList = value;

                Changed_BaseSynthesesList();

                Raise_BaseSynthesesList();
            }
        }

        public void Changed_BaseSynthesesList()
        {
            ResetCanExecute();
        }

        /*  public ObservableCollection<Syntheses> SynthesesList
          {
              get => _SynthesesList;
          }*/
        public EnBaseFrequency[] SelectableBaseFrequencies => EnumValues<EnBaseFrequency>();
        public static T[] EnumValues<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToArray();
        }

        public int KeyValueBase
        {
            get
            {
                switch (BaseFrequency)
                {
                    case (double)EnBaseFrequency.A2: return 33;
                    case (double)EnBaseFrequency.A3: return 45;
                    case (double)EnBaseFrequency.A4: return 57;
                    default: return 33;
                }
            }
        }


        public void KeyDown(KeyEventArgs e)
        {
            if (MidiEnabled) return;

            var keyVal = keyboard.IndexOf(e.Key);
            var midiKeyVal = keyVal + KeyValueBase;
            NoteOn(keyVal, midiKeyVal);
        }

        public void KeyUp(KeyEventArgs e)
        {
            if (MidiEnabled) return;

            var keyVal = keyboard.IndexOf(e.Key);
            NoteOff(keyVal);
        }

        void MidiMessageReceived(object sender, MidiInMessageEventArgs e)
        {
            switch (e.MidiEvent.CommandCode)
            {
                case MidiCommandCode.NoteOff:

                    break;
                case MidiCommandCode.NoteOn:
                    var noteOnEvent = GetNoteOnEvent(e);
                    var velocity = noteOnEvent.Velocity / 127.0f;
                    NoteOn(noteOnEvent.NoteNumber, noteOnEvent.NoteNumber, velocity);
                    var noteOffEvent = (NoteEvent)e.MidiEvent;
                    if (noteOffEvent.Velocity == 0)
                        NoteOff(noteOffEvent.NoteNumber);
                 
                    break;
                 

            }
        }

        private static NoteEvent GetNoteOnEvent(MidiInMessageEventArgs e)
        {
            return (NoteEvent)e.MidiEvent;
        }

        private void NoteOn(int keyVal, int midiKeyVal, float velocity = 1.0f)
        {
            if (keyVal > -1 && keyVal < 88)
                //var keyVal = keyboard.IndexOf(e.Key);
                if (_oscillators[keyVal] is null)
                {
                    _oscillators[keyVal] = new SynthWaveProvider(WaveType, 44100, keyVal)
                    {
                        BaseFrequency = BaseFrequency,
                        AttackSeconds = Attack,
                        DecaySeconds = Decay,
                        SustainLevel = Sustain,
                        ReleaseSeconds = Release,
                        LfoFrequency = 5.0,

                        LfoGain = EnableVibrato ? 0.2 : 0.0,
                        EnableSubOsc = EnableSubOsc,



                    };

                    _mixer.AddMixerInput(EnableLpf
                        ? (ISampleProvider)new LowPassFilterSampleProvider(_oscillators[keyVal], CutOff, Q)
                        : _oscillators[keyVal]);
                }
        }

        private void NoteOff(int keyVal)
        {
            if (keyVal > -1 && keyVal < 88)
            {
                //var keyVal = keyboard.IndexOf(e.Key);
                if (_oscillators[keyVal] != null)
                {
                    _oscillators[keyVal].Stop();
                    _oscillators[keyVal] = null;
                }
                   
                
            }
        }

       

        // Construction event
        partial void Constructed()
        {
           

            for (var device = 0; device < NAudio.Midi.MidiIn.NumberOfDevices; device++)
            {
                _MidiDevices.Add(NAudio.Midi.MidiIn.DeviceInfo(device).ProductName);
            }

            if (_MidiDevices.Count > 0)
            {
                MidiDevice = MidiDevices[0];
                MidiVisibility = Visibility.Visible;
            }
            else
            {
                MidiVisibility = Visibility.Collapsed;
            }
            var waveFormat = WaveFormat.CreateIeeeFloatWaveFormat(44100, 1);
            _mixer = new MixingSampleProvider(waveFormat) { ReadFully = true }; // Always produce samples
            _volControl = new VolumeSampleProvider(_mixer)
            {
                Volume = 0.25f,
            };

            _tremolo = new TremoloSampleProvider(_volControl, TremoloFreq, TremoloGain);
            _chorus = new ChorusSampleProvider(_tremolo);
            _phaser = new PhaserSampleProvider(_chorus);
            _lpf = new LowPassFilterSampleProvider(_phaser, 20000);

            /*_fftProvider = new FFTSampleProvider(8, (ss, cs) => Dispatch=> UpdateRealTimeData(ss, cs)), _phaser);*/


           
            WaveType = SignalGeneratorType.Sin;
            Volume = 0.5;
            Attack = 0.01f;
            Decay = 0.01f;
            Sustain = 1.0f;
            Release = 0.3f;
            CutOff = 8000;
            Q = 1f;
            TremoloFreq = 5;
            TremoloFreqMult = 1;
            ChorusDelay = 0.0f;
            ChorusSweep = 0.0f;
            ChorusWidth = 0.01f;
            PhaserDry = 0.0f;
            PhaserWet = 0.0f;
            PhaserFeedback = 0.0f;
            PhaserFreq = 0.0f;
            PhaserWidth = 0.0f;
            PhaserSweep = 0.0f;
            


        }

        // Property events
        partial void Changed_Volume(double prev, double current)
        {
            _volControl.Volume = (float)current;
            VolumeLabel = $"{(int)(Volume * 100.0)}%";
        }

        partial void Changed_Attack(float prev, float current)
        {
            AttackLabel = $"{(int)(Attack * 1000.0)} ms";
        }

        partial void Changed_Decay(float prev, float current)
        {
            DecayLabel = $"{(int)(Decay * 1000.0)} ms";
        }

        partial void Changed_Sustain(float prev, float current)
        {
            SustainLabel = $"{(int)(Sustain * 100.0)}%";
        }

        partial void Changed_Release(float prev, float current)
        {
            ReleaseLabel = $"{(int)(Release * 1000.0)} ms";
        }

        partial void Changed_CutOff(int prev, int current)
        {
            CutOffLabel = $"{CutOff} Hz";
        }

        partial void Changed_Q(float prev, float current)
        {
            QLabel = $"{((int)(Q * 100.0f)) / 100.0f}";
        }

    

        partial void Changed_TremoloFreq(int prev, int current)
        {
            if (_tremolo != null)
            {
                _tremolo.LfoFrequency = TremoloFreqMult * TremoloFreq; ;
                _tremolo.UpdateLowFrequencyOscillator();
            }

            Raise_TremoloFreqMult();
        }

        partial void Changed_TremoloFreqMult(int prev, int current)
        {
            if (_tremolo != null)
            {
                _tremolo.LfoFrequency = TremoloFreqMult * TremoloFreq; ;
                _tremolo.UpdateLowFrequencyOscillator();
            }

            Raise_TremoloFreq();
        }

        partial void Changed_TremoloGain(float prev, float current)
        {
            if (_tremolo != null)
            {
                _tremolo.LfoGain = TremoloGain;
                _tremolo.UpdateLowFrequencyOscillator();
            }
        }

        partial void Changed_ChorusWidth(float prev, float current)
        {
            if (_chorus != null)
            {
                _chorus.Width = ChorusWidth;
            }
        }

        partial void Changed_ChorusSweep(float prev, float current)
        {
            if (_chorus != null)
            {
                _chorus.SweepRate = ChorusSweep;
            }
        }

        partial void Changed_ChorusDelay(float prev, float current)
        {
            if (_chorus != null)
            {
                _chorus.Delay = ChorusDelay;
            }
        }

        partial void Changed_PhaserDry(float prev, float current)
        {
            if (_phaser != null)
            {
                _phaser.DryMix = PhaserDry;
            }
        }
        partial void Changed_PhaserWet(float prev, float current)
        {
            if (_phaser != null)
            {
                _phaser.WetMix = PhaserWet;
            }
        }
        partial void Changed_PhaserFeedback(float prev, float current)
        {
            if (_phaser != null)
            {
                _phaser.Feedback = PhaserFeedback;
            }
        }
        partial void Changed_PhaserFreq(float prev, float current)
        {
            if (_phaser != null)
            {
                _phaser.BottomFrequency = PhaserFreq;
            }
        }
        partial void Changed_PhaserWidth(float prev, float current)
        {
            if (_phaser != null)
            {
                _phaser.Width = PhaserWidth;
            }
        }
        partial void Changed_PhaserSweep(float prev, float current)
        {
            if (_phaser != null)
            {
                _phaser.SweepRate = PhaserSweep;
            }
        }




        #region CanExecute
        partial void CanExecute_MidiOnCommand(ref bool result)
        {
            result = !MidiEnabled;
        }

        partial void CanExecute_MidiOffCommand(ref bool result)
        {
            result = MidiEnabled;
        }


        partial void CanExecute_LoadPatchCommand(ref bool result)
        {
            result = true;
        }

        partial void CanExecute_SavePatchCommand(ref bool result)
        {
            result = true;
        }

        partial void CanExecute_CloseGuideCommand(ref bool result)
        {
            result = true;
        }

        partial void CanExecute_ExitCommand(ref bool result)
        {
            result = true;
        }

        partial void CanExecute_OpenGuideCommand(ref bool result)
        {
            result = true;
        }

        partial void CanExecute_ChangeFactoryCommand(ref bool result)
        {
            result = true;
        }

        partial void CanExecute_DeletePatchCommand(ref bool result)
        {
            result = true;
        }

        partial void CanExecute_OpenUsersScrollCommand(ref bool result)
        {
            result = true;
        }

        partial void CanExecute_DeleteUserCommand(ref bool result)
        {
            result = true;
        }

        #endregion


        #region Execute

        partial void Execute_MidiOnCommand()
        {
            var selectedMidiDevice = MidiDevices.IndexOf(MidiDevice);
            if (selectedMidiDevice >= 0)
            {
                OctaveVisibility = Visibility.Hidden;
                MidiEnabled = true;
                midiIn = new MidiIn(selectedMidiDevice);
                midiIn.MessageReceived += MidiMessageReceived;
                // midiIn.ErrorReceived += MidiErrorReceived;
                midiIn.Start();
                ResetCanExecute();
            }
        }

        partial void Execute_MidiOffCommand()
        {
            MidiEnabled = false;
            midiIn.Stop();
            midiIn.Dispose();
            ResetCanExecute();
        }
        partial void Execute_ExitCommand(object _window)
        {
            Window window = _window as Window;
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            window.Close();
        }

        partial void Execute_OpenGuideCommand()
        {
            Guide = true;
        }

        partial void Execute_LoadPatchCommand(object _id)
        {
            
            int ID = Convert.ToInt32(_id);
            Syntheses SynthObject = db.Syntheses.FirstOrDefault(u => u.Id == ID);
            if (SynthObject != null)
            {
                

                Name = SynthObject.Name;
                Decay = (float)SynthObject.Decay;
                Attack = (float)SynthObject.Attack;
                ChorusDelay = (float)SynthObject.ChorusDelay;
                ChorusSweep = (float)SynthObject.ChorusSweep;
                ChorusWidth = (float)SynthObject.ChorusWidth;
                this.PhaserDry = (float)SynthObject.PhaserDry;
                this.PhaserFeedback = (float)SynthObject.PhaserFeedback;
                this.PhaserFreq = (float)SynthObject.PhaserFreq;
                this.PhaserSweep = (float)SynthObject.PhaserSweep;
                this.PhaserWet = (float)SynthObject.PhaserWet;
                this.PhaserWidth = (float)SynthObject.PhaserWidth;
                this.CutOff = (int)SynthObject.CutOff;
                this.Sustain = (float)SynthObject.Sustain;
                this.Q = (float)SynthObject.Q;
                this.Release = (float)SynthObject.Release;
                this.TremoloFreq = (int)SynthObject.TremoloFreq;
                this.Volume = (double)SynthObject.Volume;
                this.Tremolo = SynthObject.Tremolo;
                /*this.FactId = SynthObject.Name;*/
                   
                   
              

             

                // получаем объекты из бд и выводим на консоль
                /* var users = db.Users;
                 Console.WriteLine("Список объектов:");
                 foreach (User u in users)
                 {
                     Console.WriteLine("{0}.{1} - {2}", u.Id, u.Name, u.Age);
                 }*/
            }
            else
            {
               
            }

        }

        partial void Execute_SavePatchCommand()
        {
            
            if (TremoloGain > 0.2f)
                Tremolo = true;
            if(db.Syntheses.FirstOrDefault(u => u.Name == this.Name) == null)
                { 
                Syntheses SynthObject = new Syntheses
                {
                    Name = this.Name,
                    Decay = this.Decay,
                    Attack = this.Attack,
                    ChorusDelay = this.ChorusDelay,
                    ChorusSweep = this.ChorusSweep,
                    ChorusWidth = this.ChorusWidth,
                    PhaserDry = this.PhaserDry,
                    PhaserFeedback = this.PhaserFeedback,
                    PhaserFreq = this.PhaserFreq,
                    PhaserSweep = this.PhaserSweep,
                    PhaserWet = this.PhaserWet,
                    PhaserWidth = this.PhaserWidth,
                    CutOff = this.CutOff,
                    Sustain = this.Sustain,
                    Q = this.Q,
                    Release = this.Release,
                    TremoloFreq = this.TremoloFreq,
                    Volume = this.Volume,
                    Tremolo = this.Tremolo,
                    FactId = factory.id_factory
                };
               
                // добавляем их в бд

                db.Syntheses.Add(SynthObject);
                db.SaveChanges();
                ValidateBlock = ("Сохранено!");

                
                // получаем объекты из бд и выводим на консоль
                /* var users = db.Users;
                 Console.WriteLine("Список объектов:");
                 foreach (User u in users)
                 {
                     Console.WriteLine("{0}.{1} - {2}", u.Id, u.Name, u.Age);
                 }*/
            }
            else
            {
               
            }
            SynthesesList = new ObservableCollection<Syntheses>(db.Syntheses.Where(p => p.FactId == factory.id_factory));


        }

        partial void Execute_DeletePatchCommand(object _id)
        {

            int ID = Convert.ToInt32(_id);
            Syntheses SynthObject = db.Syntheses.FirstOrDefault(u => u.Id == ID);
            if (SynthObject != null)
            {
                db.Syntheses.Remove(SynthObject);
                db.SaveChanges();
            }
            else
            {
                
            }
            SynthesesList = new ObservableCollection<Syntheses>(db.Syntheses.Where(p => p.FactId == factory.id_factory));

        }

       
        public bool factoryVisible = true;
        partial void Execute_ChangeFactoryCommand()
        {
            
            if(factoryVisible == true)
            {
                
                BaseFactoryVisibility = Visibility.Visible;
                UserFactoryVisibility = Visibility.Collapsed;
                factoryVisible = false;
                return;
            }

            if (factoryVisible == false)
            {
                
                BaseFactoryVisibility = Visibility.Collapsed;
                UserFactoryVisibility = Visibility.Visible;
                factoryVisible = true;
                return;
            } 

        }

        partial void Execute_CloseGuideCommand()
        {
            Guide = false;
        }

        partial void Execute_DeleteUserCommand(object _id)
        {
            string login = Convert.ToString(_id);
            users user = db.users.FirstOrDefault(u => u.login == login);
            factory factory = db.factory.FirstOrDefault(u => u.login == login);
           
            if (user != null && factory!= null)
            {
                db.Syntheses.RemoveRange(db.Syntheses.Where(x => x.FactId == factory.id_factory));
                db.factory.Remove(factory);
                db.users.Remove(user);
                db.SaveChanges();
            }
            else
            {

            }
            UsersList = new ObservableCollection<users>(db.users);
        }

        public bool UserScrollVisible = true;
        partial void Execute_OpenUsersScrollCommand()
        {
            if (UserScrollVisible == true)
            {
                MessageBox.Show("Открывается нахуй");
                UserScrollVisibility = Visibility.Visible;
                UserFactoryVisibility = Visibility.Collapsed;
                UserScrollVisible = false;
                return;
            }

            if (UserScrollVisible == false)
            {
                MessageBox.Show("Закрывается нахуй");
                UserScrollVisibility = Visibility.Collapsed;
                UserFactoryVisibility = Visibility.Visible;
                UserScrollVisible = true;
                return;
            }
        }

        #endregion


        public void Stop()
        {
            if (_player != null)
            {
                _player.Dispose();
                _player = null;

                
            }
        }

        public void Start()
        {
            if (_player == null)
            {
                
                    // создаем два объекта User
                   /* List<Synthesis> list = db.Syntheses.ToList();
                    foreach (var l in list)
                        NamesOfPresets.Add(l.Name);
*/
                    // получаем объекты из бд и выводим на консоль
                    /* var users = db.Users;
                     Console.WriteLine("Список объектов:");
                     foreach (User u in users)
                     {
                         Console.WriteLine("{0}.{1} - {2}", u.Id, u.Name, u.Age);
                     }*/
               
                var waveOutEvent = new WaveOutEvent
                {
                    NumberOfBuffers = 2,
                    DesiredLatency = 100,
                };

                _player = waveOutEvent;
                _player.Init(new SampleToWaveProvider(_phaser));

                _player.Play();
            }
        }
    }
}




