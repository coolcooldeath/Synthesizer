using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Synthesizer
{
    public partial class StartWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyChanged)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyChanged));
        }
        Visibility _RegisterVisibility = Visibility.Collapsed;

        void Raise_RegisterVisibility()
        {
            OnPropertyChanged("RegisterVisibility");
        }

        public Visibility RegisterVisibility
        {
            get { return _RegisterVisibility; }
            set
            {
                if (_RegisterVisibility == value)
                {
                    return;
                }

                var prev = _RegisterVisibility;

                _RegisterVisibility = value;

                Changed_RegisterVisibility(prev, _RegisterVisibility);

                Raise_RegisterVisibility();
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_RegisterVisibility(Visibility prev, Visibility current);


        Visibility _LoginVisibility = Visibility.Visible;

        void Raise_LoginVisibility()
        {
            OnPropertyChanged("LoginVisibility");
        }

        public Visibility LoginVisibility
        {
            get { return _LoginVisibility; }
            set
            {
                if (_LoginVisibility == value)
                {
                    return;
                }

                var prev = _LoginVisibility;

                _LoginVisibility = value;

                Changed_LoginVisibility(prev, _LoginVisibility);

                Raise_LoginVisibility();
            }
        }
        // --------------------------------------------------------------------
        partial void Changed_LoginVisibility(Visibility prev, Visibility current);

        bool _MidiEnabled = false;

        void Raise_MidiEnabled()
        {
            OnPropertyChanged("MidiEnabled");
        }
        public string LoginName { get; set; }
        readonly UserCommand _LoginCommand;

        bool CanExecuteLoginCommand()
        {
            bool result = false;
            CanExecute_LoginCommand(ref result);

            return result;
        }

        void ExecuteLoginCommand()
        {
            Execute_LoginCommand();
        }

        public ICommand LoginCommand { get { return _LoginCommand; } }
        // --------------------------------------------------------------------
        
       



        public void CanExecute_LoginCommand(ref bool result)
        {
            result = true;
        }
        public void Execute_LoginCommand()
        {
           
            MainWindowViewModel viewModel = new MainWindowViewModel();
            viewModel.LoginName = this.LoginName;
            MainWindow mainWindow = new MainWindow(viewModel);
            mainWindow.Show();
            Application.Current.MainWindow.Close();





            /*using (DataContext db = new DataContext())
            {
                // создаем два объекта User
                Synthesis SynthObject = new Synthesis { Name = this.Name, Decay = this.Decay, Attack = this.Attack };

                // добавляем их в бд

                db.Syntheses.Add(SynthObject);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                *//* var users = db.Users;
                 Console.WriteLine("Список объектов:");
                 foreach (User u in users)
                 {
                     Console.WriteLine("{0}.{1} - {2}", u.Id, u.Name, u.Age);
                 }*//*
            }*/


        }






        
        readonly UserCommand _OpenRegisterCommand;

        bool CanExecuteOpenRegisterCommand()
        {
            bool result = false;
            CanExecute_OpenRegisterCommand(ref result);

            return result;
        }

        void ExecuteOpenRegisterCommand()
        {
            Execute_OpenRegisterCommand();
        }

        public ICommand OpenRegisterCommand { get { return _OpenRegisterCommand; } }
        // --------------------------------------------------------------------

        public void CanExecute_OpenRegisterCommand(ref bool result)
        {
            result = true;
        }
        public void Execute_OpenRegisterCommand()
        {
            RegisterVisibility = Visibility.Visible;
            LoginVisibility = Visibility.Collapsed;

        }



        readonly UserCommand _OpenLoginCommand;

        bool CanExecuteOpenLoginCommand()
        {
            bool result = false;
            CanExecute_OpenLoginCommand(ref result);

            return result;
        }

        void ExecuteOpenLoginCommand()
        {
            Execute_OpenLoginCommand();
        }

        public ICommand OpenLoginCommand { get { return _OpenLoginCommand; } }
        // --------------------------------------------------------------------





        public void CanExecute_OpenLoginCommand(ref bool result)
        {
            result = true;
        }
        public void Execute_OpenLoginCommand()
        {
            RegisterVisibility = Visibility.Collapsed;
            LoginVisibility = Visibility.Visible;

        }

        public StartWindowViewModel()
        {
            _LoginCommand = new UserCommand(CanExecuteLoginCommand, ExecuteLoginCommand);
            _OpenRegisterCommand = new UserCommand(CanExecuteOpenRegisterCommand, ExecuteOpenRegisterCommand);
            _OpenLoginCommand = new UserCommand(CanExecuteOpenLoginCommand, ExecuteOpenLoginCommand);

        }
    }
}
