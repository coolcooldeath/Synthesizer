using System;
using System.Windows.Input;

namespace Synthesizer
{
    public class UserCommandWithParametrs : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly Func<bool> _canExecute; 
        private Action<object> _executeLoadPatchCommand;

        

        public UserCommandWithParametrs(Func<bool> canExecuteLoadPatchCommand, Action<object> executeLoadPatchCommand)
        {
            _canExecute = canExecuteLoadPatchCommand;
            this._executeLoadPatchCommand = executeLoadPatchCommand;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute();
        }

        public void Execute(object parameter)
        {
            _executeLoadPatchCommand(parameter);
        }

        

        public void RefreshCanExecute()
        {

            try
            {
                if (CanExecuteChanged != null)
                    CanExecuteChanged(this, new EventArgs());
            }
            catch
            {

            }
        }

    }
}
