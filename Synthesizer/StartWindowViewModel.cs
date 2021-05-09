using Synthesizer.DataLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Synthesizer.Helpers;
namespace Synthesizer
{
    public partial class StartWindowViewModel : INotifyPropertyChanged
    {
        private EDM db = new EDM();
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyChanged)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyChanged));
        }


        #region Свойства
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


        
        string _LoginName = default;

        void Raise_LoginName()
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

                Raise_LoginName();
            }
        }
        // --------------------------------------------------------------------

        public void Changed_LoginName(string prev, string current)
        {
            ResetCanExecute();
        }
        


        string _Password = default;

        void Raise_Password()
        {
            OnPropertyChanged("Password");
        }

        public string Password
        {
            get { return _Password; }
            set
            {
                if (_Password == value)
                {
                    return;
                }

                var prev = _Password;

                _Password = value;

                Changed_Password();

                Raise_LoginName();
            }
        }
        // --------------------------------------------------------------------

        public void Changed_Password()
        {
            ResetCanExecute();
        }

        bool _Loading = default;

        void Raise_Loading()
        {
            OnPropertyChanged("Loading");
        }

        public bool Loading
        {
            get { return _Loading; }
            set
            {
                if (_Loading == value)
                {
                    return;
                }

                var prev = _Loading;

                _Loading = value;

                Changed_Loading();

                Raise_Loading();
            }
        }
        // --------------------------------------------------------------------

        public void Changed_Loading()
        {
            ResetCanExecute();
        }


        string _UserName = default;

        void Raise_UserName()
        {
            OnPropertyChanged("UserName");
        }

        public string UserName
        {
            get { return _UserName; }
            set
            {
                if (_UserName == value)
                {
                    return;
                }

                var prev = _UserName;

                _UserName = value;

                Changed_UserName();

                Raise_LoginName();
            }
        }
        // --------------------------------------------------------------------

        public void Changed_UserName()
        {
            ResetCanExecute();
        }

        string  _RegisterRepeat = default;

        void Raise_RegisterRepeat()
        {
            OnPropertyChanged("RegisterRepeat");
        }

        public string RegisterRepeat
        {
            get { return _RegisterRepeat; }
            set
            {
                if (_RegisterRepeat == value)
                {
                    return;
                }

                var prev = _RegisterRepeat;

                _RegisterRepeat = value;



                Raise_RegisterRepeat();
            }
        }
        #endregion



        #region Команды
        readonly UserCommandWithParametrs _LoginCommand;

        bool CanExecuteLoginCommand()
        {
            bool result = false;
            CanExecute_LoginCommand(ref result);

            return result;
        }

        void ExecuteLoginCommand(object window)
        {
            Execute_LoginCommand(window);
        }

        public ICommand LoginCommand { get { return _LoginCommand; } }
        // --------------------------------------------------------------------
        
       



        public void CanExecute_LoginCommand(ref bool result)
        {
            if (LoginName != "" && LoginName!=null && Password != "" && Password != null)
                result = true;
            else
                result = false;
          
            
        }
       



        

        readonly UserCommandWithParametrs _RegisterCommand;

        bool CanExecuteRegisterCommand()
        {
            bool result = false;
            CanExecute_RegisterCommand(ref result);

            return result;
        }

        void ExecuteRegisterCommand(object window)
        {
            Execute_RegisterCommand(window);
        }

        public ICommand RegisterCommand { get { return _RegisterCommand; } }
        // --------------------------------------------------------------------





        public void CanExecute_RegisterCommand(ref bool result)
        {
            if (LoginName != "" && LoginName != null && Password != "" && Password != null && UserName != "" && UserName != null)
                result = true;
            else
                result = false;


        }
      







        readonly UserCommandWithParametrs _OpenRegisterCommand;

        bool CanExecuteOpenRegisterCommand()
        {
            bool result = false;
            CanExecute_OpenRegisterCommand(ref result);

            return result;
        }

        void ExecuteOpenRegisterCommand(object window)
        {
            Execute_OpenRegisterCommand(window);
        }

        public ICommand OpenRegisterCommand { get { return _OpenRegisterCommand; } }
        // --------------------------------------------------------------------

        public void CanExecute_OpenRegisterCommand(ref bool result)
        {
            result = true;
        }
       



        readonly UserCommandWithParametrs _OpenLoginCommand;

        bool CanExecuteOpenLoginCommand()
        {
            bool result = false;
            CanExecute_OpenLoginCommand(ref result);

            return result;
        }

        void ExecuteOpenLoginCommand(object window)
        {
            Execute_OpenLoginCommand(window);
        }

        public ICommand OpenLoginCommand { get { return _OpenLoginCommand; } }
        // --------------------------------------------------------------------





        public void CanExecute_OpenLoginCommand(ref bool result)
        {
            result = true;
        }

        #endregion


        public void Execute_LoginCommand(object _window)
        {
            Loading = true;
            string hashPassword = HelperClass.getHash(Password);
            
            if (db.users.FirstOrDefault(u => u.login == LoginName && u.password == hashPassword ) != null)
            {
                
                users user = db.users.FirstOrDefault(u => u.login == LoginName);
                factory factory = (db.factory.FirstOrDefault(u => u.login == LoginName));
                MainWindowViewModel viewModel = new MainWindowViewModel();
                viewModel.LoginName = this.LoginName;
                viewModel.User = user;
                viewModel.factory = factory;
                viewModel.SynthesesList = new ObservableCollection<Syntheses>(db.Syntheses.Where(p => p.FactId == factory.id_factory));
                if(user.isadmin == true)
                {
                    viewModel.AdminVisibility = Visibility.Visible;
                    viewModel.UserVisibility = Visibility.Collapsed;

                }
                else
                viewModel.AdminVisibility = Visibility.Collapsed;
                viewModel.UserVisibility = Visibility.Visible;
                MainWindow mainWindow = new MainWindow(viewModel);
                mainWindow.Show();
                Window window = _window as Window;
                window.Close();
            }
            else
            {
                RegisterRepeat = "Неверный логин или пароль";
            }
           
            

            ResetCanExecute();



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
        public void Execute_RegisterCommand(object _window)
        {

            Loading = true;
            if (db.users.FirstOrDefault(u => u.login == LoginName) == null)
            {
                
                users user = new users {name = this.UserName,password = HelperClass.getHash(Password),login = this.LoginName,date = DateTime.Now,isadmin=false};
                factory factory = new factory { factory_name = this.UserName, login = this.LoginName};
                db.users.Add(user);
                db.factory.Add(factory);
                db.SaveChangesAsync();
                Execute_OpenLoginCommand(_window);

                

            }
            else { RegisterRepeat = "Логин занят"; }


            ResetCanExecute();


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

        public void Execute_OpenRegisterCommand(object _window)
        {
            Window window = _window as Window;
            window.Height = 440;

            RegisterVisibility = Visibility.Visible;
            LoginVisibility = Visibility.Collapsed;

        }
        public void Execute_OpenLoginCommand(object _window)
        {
            Window window = _window as Window;
            window.Height = 370;
            
            RegisterVisibility = Visibility.Collapsed;
            LoginVisibility = Visibility.Visible;

        }

        public StartWindowViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                return;
            db.users.FindAsync(new users());
            _LoginCommand = new UserCommandWithParametrs(CanExecuteLoginCommand, ExecuteLoginCommand);
            _RegisterCommand = new UserCommandWithParametrs(CanExecuteRegisterCommand, ExecuteRegisterCommand);
            _OpenRegisterCommand = new UserCommandWithParametrs(CanExecuteOpenRegisterCommand, ExecuteOpenRegisterCommand);
            _OpenLoginCommand = new UserCommandWithParametrs(CanExecuteOpenLoginCommand, ExecuteOpenLoginCommand);

        }

        void ResetCanExecute()
        {
            _RegisterCommand.RefreshCanExecute();
            _LoginCommand.RefreshCanExecute();
            _OpenLoginCommand.RefreshCanExecute();
            _OpenRegisterCommand.RefreshCanExecute();   

        }
    }
}
