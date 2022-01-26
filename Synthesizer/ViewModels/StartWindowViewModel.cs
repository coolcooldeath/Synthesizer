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
using System.Globalization;
using System.Net.Mail;
using System.Net;

namespace Synthesizer
{
    public partial class StartWindowViewModel : INotifyPropertyChanged
    {
        private bool IsEng = false;
        private EDM db = new EDM();
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyChanged)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyChanged));
        }


        #region Свойства

        public string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
            + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
            + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

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


        bool _RestoreVisibility = false;



        void Raise_RestoreVisibility()
        {
            OnPropertyChanged("RestoreVisibility");
        }

        public bool RestoreVisibility
        {
            get { return _RestoreVisibility; }
            set
            {
                if (_RestoreVisibility == value)
                {
                    return;
                }
                var prev = _RestoreVisibility;

                _RestoreVisibility = value;




                Raise_RestoreVisibility();
            }
        }
        // --------------------------------------------------------------------

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
            if (current.Length < 4) {
                if (!IsEng)
                    LoginValidate = "Логин не может быть менее 4 символов";
                else
                    LoginValidate = "Login cannot be less than 4 characters";
            }

            else if (!new Regex("^[a-zA-Z0-9]+$").IsMatch(current))
            {
                if (!IsEng)
                    LoginValidate = "Логин может содержать только латиницу и цифры";
                else
                    LoginValidate = "Login can contain only eng. letters and numbers";
            }
                
           
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

                Raise_Password();
            }
        }
        // --------------------------------------------------------------------

        public void Changed_Password(string value)
        {
            ResetCanExecute();
            if (value.Length < 5)
            {
            if(!IsEng)
                    RegisterRepeat = "Пароль не может быть менее 5 символов";
            else
                    RegisterRepeat = "Password cannot be less than 5 characters";
            }
                
            else if (!new Regex("^[a-zA-Z0-9!?.@]+$").IsMatch(Password))
            {
                if (!IsEng)
                    RegisterRepeat = "Пароль может содержать только латиницу, цифры и специальные символы('!', '?', '.', '@')";
                else
                    RegisterRepeat = "Password can contain only eng. letters, numbers and special characters('!', '?', '.', '@')";

            }
            else
            { LoginValidate = ""; RegisterRepeat = ""; }
               
        }

        string _Gmail = default;

        void Raise_Gmail()
        {
            OnPropertyChanged("Gmail");
        }

        public string Gmail
        {
            get { return _Gmail; }
            set
            {
                if (_Gmail == value)
                {
                    return;
                }

                var prev = _Gmail;

                _Gmail = value;

                Changed_Gmail(value);

                Raise_Gmail();
            }
        }
        // --------------------------------------------------------------------

        public void Changed_Gmail(string value)
        {
             
            ResetCanExecute();
            if (value.Length < 5)
            {
                if (!IsEng)
                    MailValidate = "Почта не может быть менее 5 символов";
                else
                    MailValidate = "Mail cannot be less than 5 characters";
            }
            
            else if (!new Regex(validEmailPattern).IsMatch(value))
            {
                if (!IsEng)
                    MailValidate = "Некорректный формат почты";
                else
                    MailValidate = "Mail is not correct";

            }
            else
            { LoginValidate = ""; MailValidate = ""; }
                
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
            {
                if(!IsEng)
                    UserNameValidate = "Имя не может быть меньше 2 символов";
                else
                    UserNameValidate = "The name cannot be less than 2 characters";
            }
               
            else if (!new Regex("^[a-zA-Zа-яА-я]+$").IsMatch(value))
            {
                if (!IsEng)
                    UserNameValidate = "Имя может содержать латиницу и русский алфавит";
                else
                    UserNameValidate = "Name can contain only eng. and rus. letters ";
            }
               
            else
            { LoginValidate = ""; UserNameValidate = ""; }
                
        }

        string  _RegisterRepeat = default;
        string  _MailValidate = default;
        string _LoginValidate = default;
        string _UserNameValidate = default;

        void Raise_MailValidate()
        {
            OnPropertyChanged("MailValidate");
        }

        public string MailValidate
        {
            get { return _MailValidate; }
            set
            {
                if (_MailValidate == value)
                {
                    return;
                }

                var prev = _MailValidate;

                _MailValidate = value;



                Raise_MailValidate();
            }
        }

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

        readonly UserCommand _SwitchLangCommand;

        bool CanExecuteSwitchLangCommand()
        {
            bool result = false;
            CanExecute_SwitchLangCommand(ref result);

            return result;
        }

        void ExecuteSwitchLangCommand()
        {
            Execute_SwitchLangCommand();
        }

        public ICommand SwitchLangCommand { get { return _SwitchLangCommand; } }
        // --------------------------------------------------------------------
        public void CanExecute_SwitchLangCommand(ref bool result)
        {
            result = true;
        }
        public void Execute_SwitchLangCommand()
        {
            if (IsEng)
            {
                App.Language = new CultureInfo("ru-RU");
                IsEng = false;
            }
            else
            {
                App.Language = new CultureInfo("en-US");
                IsEng = true;
            }
        }

        readonly UserCommand _SendPasswordCommand;

        bool CanExecuteSendPasswordCommand()
        {
            bool result = false;
            CanExecute_SendPasswordCommand(ref result);

            return result;
        }

        void ExecuteSendPasswordCommand()
        {
            Execute_SendPasswordCommand();
        }

        public ICommand SendPasswordCommand { get { return _SendPasswordCommand; } }
        // --------------------------------------------------------------------
        public void CanExecute_SendPasswordCommand(ref bool result)
        {
            if (LoginName != "" && LoginName != null && Gmail != null && Gmail != "")
            {
                if (LoginName.Length > 3 && new Regex("^[a-zA-Z0-9]+$").IsMatch(LoginName) && new Regex(validEmailPattern).IsMatch(Gmail))
                    result = true;
                else
                    result = false;
            }

            else result = false;
        }
        public void Execute_SendPasswordCommand()
        {
            try
            {
                users user = db.users.FirstOrDefault(u => u.login == LoginName);
                if (user != null)
                {
                    if(user.gmail == Gmail)
                    {
                        string password = Helpers.Random.RandomPassword(8);
                        MailAddress from = new MailAddress("strangergear@gmail.com", "PolivoksSynthesizer");
                        MailAddress to = new MailAddress(Gmail);
                        MailMessage message = new MailMessage(from, to);
                        message.Subject = "Восстановление пароля";
                        message.Body = "Здравствуйте, ваш новый пароль - " + password +  ". С уважением,команда Polivoks";
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                        smtp.Credentials = new NetworkCredential("strangergear@gmail.com", "12345678stranger");
                        smtp.EnableSsl = true;
                        smtp.SendMailAsync(message);
                        user.password = HelperClass.getHash(password);
                        db.SaveChangesAsync();
                        ExecuteCloseRestorePasswordWindowCommand();

                    }
                    else
                    {
                        if (IsEng)
                            MailValidate = "Invalid data entered";
                        else
                            MailValidate = "Введены неверные данные";
                    }
                    
                   
                }
                else
                {
                    if (IsEng)
                        MailValidate = "Invalid data entered"; 
                    else
                        MailValidate = "Введены неверные данные";
                }
               
            }
            catch { }
            
        }

        readonly UserCommand _OpenRestorePasswordCommand;

        bool CanExecuteOpenRestorePasswordCommand()
        {
            bool result = false;
            CanExecute_OpenRestorePasswordCommand(ref result);

            return result;
        }

        void ExecuteOpenRestorePasswordCommand()
        {
            Execute_OpenRestorePasswordCommand();
        }

        public ICommand OpenRestorePasswordCommand { get { return _OpenRestorePasswordCommand; } }
        // --------------------------------------------------------------------
        public void CanExecute_OpenRestorePasswordCommand(ref bool result)
        {
            result = true;
        }
        public void Execute_OpenRestorePasswordCommand()
        {
          
            RestoreVisibility = true;
        }

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
            RestoreVisibility = false;
        }

        readonly UserCommand _CloseRestorePasswordWindowCommand;

        bool CanExecuteCloseRestorePasswordWindowCommand()
        {
            bool result = false;
            CanExecute_CloseRestorePasswordWindowCommand(ref result);

            return result;
        }

        void ExecuteCloseRestorePasswordWindowCommand()
        {
            Execute_CloseRestorePasswordWindowCommand();
        }

        public ICommand CloseRestorePasswordWindowCommand { get { return _CloseRestorePasswordWindowCommand; } }
        // --------------------------------------------------------------------
        public void CanExecute_CloseRestorePasswordWindowCommand(ref bool result)
        {
            result = true;
        }
        public void Execute_CloseRestorePasswordWindowCommand()
        {
            LoginName = "";
            Gmail = "";
            LoginValidate = "";
            MailValidate = "";
            
            RestoreVisibility = false;
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
            if (LoginName != "" && LoginName != null && Password != "" && Password != null && UserName != "" && UserName != null && Gmail!=null && Gmail!="") {
                if (LoginName.Length > 3 && Password.Length > 4 && UserName.Length>1 && new Regex("^[a-zA-Zа-яА-я]+$").IsMatch(UserName) && new Regex("^[a-zA-Z0-9!?.@]+$").IsMatch(Password) && new Regex("^[a-zA-Z0-9]+$").IsMatch(LoginName) && new Regex(validEmailPattern).IsMatch(Gmail))
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
                    viewModel.IsEng = IsEng;
                    viewModel.UserVisibility = Visibility.Visible;
                    MainWindow mainWindow = new MainWindow(viewModel);
                    mainWindow.Show();
                    Window window = _window as Window;
                    window.Close();
                }
                else
                {
                    if (IsEng) LoginValidate = "Invalid login or password";
                    else
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
                    if(db.users.FirstOrDefault(u => u.gmail == Gmail) == null) 
                    {
                        users user = new users { name = this.UserName, gmail = Gmail, password = HelperClass.getHash(Password), login = this.LoginName, date = DateTime.Now, isadmin = false };
                        factory factory = new factory { factory_name = this.UserName, login = this.LoginName };
                        db.users.Add(user);
                        db.factory.Add(factory);
                        db.SaveChangesAsync();
                        Execute_OpenLoginCommand(_window);
                    }
                    else
                    {
                        if (IsEng) MailValidate = "Maill is not available";
                        else
                            MailValidate = "Почта занята";
                    }
                   



                }
                else {  if (IsEng) LoginValidate = "Login is not available";
                        else
                        LoginValidate = "Логин занят";
                        
                }
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
            window.Height =500;

            RegisterVisibility = Visibility.Visible;
            LoginVisibility = Visibility.Collapsed;

        }
        public void Execute_OpenLoginCommand(object _window)
        {
            Window window = _window as Window;
            window.Height = 400;
            
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




/*            users Admin = new users { name = "Admin", isadmin = true, gmail = "dobre4ko@gmail.com", login = "Admin", password = HelperClass.getHash("135135"), date = DateTime.Now };
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

            }
*/
            DataBaseAsync();
            _LoginCommand = new UserCommandWithParametrs(CanExecuteLoginCommand, ExecuteLoginCommand);
            _CloseNetworkErrorWindowCommand = new UserCommand(CanExecuteCloseNetworkErrorWindowCommand, ExecuteCloseNetworkErrorWindowCommand);
            _CloseRestorePasswordWindowCommand = new UserCommand(CanExecuteCloseRestorePasswordWindowCommand, ExecuteCloseRestorePasswordWindowCommand);
            _CloseLoginWindowCommand = new UserCommandWithParametrs(CanExecuteCloseLoginWindowCommand, ExecuteCloseLoginWindowCommand);
            _RegisterCommand = new UserCommandWithParametrs(CanExecuteRegisterCommand, ExecuteRegisterCommand);
            _OpenRegisterCommand = new UserCommandWithParametrs(CanExecuteOpenRegisterCommand, ExecuteOpenRegisterCommand);
            _OpenLoginCommand = new UserCommandWithParametrs(CanExecuteOpenLoginCommand, ExecuteOpenLoginCommand);
            _SwitchLangCommand = new UserCommand(CanExecuteSwitchLangCommand, ExecuteSwitchLangCommand);
            _SendPasswordCommand = new UserCommand(CanExecuteSendPasswordCommand, ExecuteSendPasswordCommand);
            _OpenRestorePasswordCommand = new UserCommand(CanExecuteOpenRestorePasswordCommand, ExecuteOpenRestorePasswordCommand);

        }

        void ResetCanExecute()
        {
            _SendPasswordCommand.RefreshCanExecute();
            _OpenRestorePasswordCommand.RefreshCanExecute();
            _RegisterCommand.RefreshCanExecute();
            _LoginCommand.RefreshCanExecute();
            _OpenLoginCommand.RefreshCanExecute();
            _OpenRegisterCommand.RefreshCanExecute();

        }

    }
}
