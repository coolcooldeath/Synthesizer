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
using System.Windows.Threading;
using System.Text.RegularExpressions;

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
            if (current.Length < 4)
                LoginValidate = "Логин не может быть менее 4 символов";
            else if (!new Regex("^[a-zA-Z0-9]+$").IsMatch(current))
                LoginValidate = "Логин может содержать только латиницу и цифры";
           
            else
                LoginValidate = "";
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

                Changed_Password(value);

                Raise_LoginName();
            }
        }
        // --------------------------------------------------------------------

        public void Changed_Password(string value)
        {
            ResetCanExecute();
            if (value.Length < 5)
                RegisterRepeat = "Пароль не может быть менее 5 символов";
            else if (!new Regex("^[a-zA-Z0-9!?.@]+$").IsMatch(Password))
                RegisterRepeat = "Пароль может содержать только латиницу, цифры и специальные символы('!', '?', '.', '@')";
            
            else
                RegisterRepeat = "";
        }

        bool _NetworkError = default;

        void Raise_NetworkError()
        {
            OnPropertyChanged("NetworkError");
        }

        public bool NetworkError
        {
            get { return _NetworkError; }
            set
            {
                if (_NetworkError == value)
                {
                    return;
                }

                var prev = _NetworkError;

                _NetworkError = value;

                Changed_NetworkError();

                Raise_NetworkError();
            }
        }
        // --------------------------------------------------------------------

        public void Changed_NetworkError()
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

                Changed_UserName( value);

                Raise_LoginName();
            }
        }
        // --------------------------------------------------------------------

        public void Changed_UserName(string value)
        {
            ResetCanExecute();
            if (value.Length < 2)
                UserNameValidate = "Имя не может быть меньше 2 символов";
            else if (!new Regex("^[a-zA-Zа-яА-я]+$").IsMatch(value))
                UserNameValidate = "Имя может содержать латиницу и русский алфавит";
            else
                UserNameValidate = "";
        }

        string  _RegisterRepeat = default;
        string _LoginValidate = default;
        string _UserNameValidate = default;

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


        void Raise_LoginValidate()
        {
            OnPropertyChanged("LoginValidate");
        }

        public string LoginValidate
        {
            get { return _LoginValidate; }
            set
            {
                if (_LoginValidate == value)
                {
                    return;
                }

                var prev = _LoginValidate;

                _LoginValidate = value;



                Raise_LoginValidate();
            }
        }

        void Raise_UserNameValidate()
        {
            OnPropertyChanged("UserNameValidate");
        }

        public string UserNameValidate
        {
            get { return _UserNameValidate; }
            set
            {
                if (_UserNameValidate == value)
                {
                    return;
                }

                var prev = _UserNameValidate;

                _UserNameValidate = value;



                Raise_UserNameValidate();
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
            if (LoginName != "" && LoginName != null && Password != "" && Password != null)
            {
                if (LoginName.Length > 3 && Password.Length > 4 && new Regex("^[a-zA-Z0-9!?.@]+$").IsMatch(Password) && new Regex("^[a-zA-Z0-9]+$").IsMatch(LoginName))
                    result = true;
                else
                    result = false;
            }
            else
                result = false;



        }

       
        
        
        readonly UserCommand _CloseNetworkErrorWindowCommand;

        bool CanExecuteCloseNetworkErrorWindowCommand()
        {
            bool result = false;
            CanExecute_CloseNetworkErrorWindowCommand(ref result);

            return result;
        }

        void ExecuteCloseNetworkErrorWindowCommand()
        {
            Execute_CloseNetworkErrorWindowCommand();
        }

        public ICommand CloseNetworkErrorWindowCommand { get { return _CloseNetworkErrorWindowCommand; } }
        // --------------------------------------------------------------------
        public void CanExecute_CloseNetworkErrorWindowCommand(ref bool result)
        {
            result =  true;
        }
        public void Execute_CloseNetworkErrorWindowCommand()
        {
            NetworkError = false;
        }

        readonly UserCommandWithParametrs _CloseLoginWindowCommand;

        bool CanExecuteCloseLoginWindowCommand()
        {
            bool result = false;
            CanExecute_CloseLoginWindowCommand(ref result);

            return result;
        }

        void ExecuteCloseLoginWindowCommand(object window)
        {
            Execute_CloseLoginWindowCommand(window);
        }

        public ICommand CloseLoginWindowCommand { get { return _CloseLoginWindowCommand; } }
        // --------------------------------------------------------------------





        public void CanExecute_CloseLoginWindowCommand(ref bool result)
        {
            result = true;


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
            if (LoginName != "" && LoginName != null && Password != "" && Password != null && UserName != "" && UserName != null) {
                if (LoginName.Length > 3 && Password.Length > 4 && new Regex("^[a-zA-Zа-яА-я]+$").IsMatch(UserName) && new Regex("^[a-zA-Z0-9!?.@]+$").IsMatch(Password) && new Regex("^[a-zA-Z0-9]+$").IsMatch(LoginName))
                    result = true;
                else
                    result = false;
            }

            else result = false;



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
            
            string hashPassword = HelperClass.getHash(Password);

            try
            {
                if (db.users.FirstOrDefault(u => u.login.Equals(LoginName) && u.password == hashPassword) != null)
                {

                    users user = db.users.FirstOrDefault(u => u.login == LoginName);
                    factory factory = (db.factory.FirstOrDefault(u => u.login == LoginName));
                    MainWindowViewModel viewModel = new MainWindowViewModel();
                    viewModel.LoginName = this.LoginName;
                    viewModel.User = user;
                    viewModel.factory = factory;
                    factory BaseFactory = db.factory.FirstOrDefault(p => p.login == "Admin");
                   
                    viewModel.SynthesesList = new ObservableCollection<Syntheses>(db.Syntheses.Where(p => p.FactId == factory.id_factory));
                    viewModel.BaseSynthesesList = new ObservableCollection<Syntheses>((db.Syntheses.Where(p => p.FactId == BaseFactory.id_factory)));
                    viewModel.UsersList = new ObservableCollection<users>((db.users.Where(p => p.isadmin == false)));
                    if (user.isadmin == true)
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
                    LoginValidate = "Неверный логин или пароль";
                }
            }
            catch (Exception)
            {
                NetworkError = true;
            }
            

            ResetCanExecute();



          


        }
        public void Execute_RegisterCommand(object _window)
        {

      
            try
            {
                if (db.users.FirstOrDefault(u => u.login == LoginName) == null)
                {

                    users user = new users { name = this.UserName, password = HelperClass.getHash(Password), login = this.LoginName, date = DateTime.Now, isadmin = false };
                    factory factory = new factory { factory_name = this.UserName, login = this.LoginName };
                    db.users.Add(user);
                    db.factory.Add(factory);
                    db.SaveChangesAsync();
                    Execute_OpenLoginCommand(_window);



                }
                else { LoginValidate = "Логин занят"; }
            }
            catch (Exception)
            {
                NetworkError = true;
            }

            ResetCanExecute();


            


        }
        async void DataBaseAsync()
        {
            await Task.Run(() => {
                try
                {
                    db.users.FirstOrDefault(u => u.login == "1");
                   
                }
                catch
                {
                    NetworkError = true;
                }
            });
        }

        public void Execute_OpenRegisterCommand(object _window)
        {
            Window window = _window as Window;
            window.Height =420;

            RegisterVisibility = Visibility.Visible;
            LoginVisibility = Visibility.Collapsed;

        }
        public void Execute_OpenLoginCommand(object _window)
        {
            Window window = _window as Window;
            window.Height = 350;
            
            RegisterVisibility = Visibility.Collapsed;
            LoginVisibility = Visibility.Visible;

        }

        public void Execute_CloseLoginWindowCommand(object _window)
        {
            Window window = _window as Window;
            window.Close();

        }

        public StartWindowViewModel()
        {


            /*users Admin = new users { name = "Admin", isadmin = true, login = "Admin", password = HelperClass.getHash("135135"), date = DateTime.Now };
            factory factory = new factory { factory_name = Admin.name, login = Admin.login };
            try
            {
                if (db.users.FirstOrDefault(u => u.name == Admin.name && u.password == Admin.password && u.login == Admin.login) == null)
                {
                    db.users.Add(Admin);
                    db.factory.Add(factory);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Сасать");
            }*/

            DataBaseAsync();
            _LoginCommand = new UserCommandWithParametrs(CanExecuteLoginCommand, ExecuteLoginCommand);
            _CloseNetworkErrorWindowCommand = new UserCommand(CanExecuteCloseNetworkErrorWindowCommand, ExecuteCloseNetworkErrorWindowCommand);
            _CloseLoginWindowCommand = new UserCommandWithParametrs(CanExecuteCloseLoginWindowCommand, ExecuteCloseLoginWindowCommand);
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
