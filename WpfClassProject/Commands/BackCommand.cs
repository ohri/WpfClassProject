using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using WpfClassProject.DataContexts;

namespace WpfClassProject.Commands
{
    class BackCommand : ICommand
    {
        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            var p = parameter as PlayCommandParameter;
            p.CurrentSong.Back();
        }

        #endregion
    }
}
