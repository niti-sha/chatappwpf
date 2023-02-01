using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace chatappwpf.Core
{
    class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canexecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }

        }
        public RelayCommand( Action<object> execute, Func<object, bool> canexecute= null)
        {
            this.execute = execute;
            this.canexecute = canexecute;
        }
        public bool CanExecute( object parameter)
        {
            return this.CanExecute ==  null || this.CanExecute(parameter);
        }

        public void Execute( object parameter )
        {
            this.execute( parameter );
        }
    }
}
