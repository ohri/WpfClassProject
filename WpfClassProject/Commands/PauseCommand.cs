﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using WpfClassProject.DataContexts;

namespace WpfClassProject.Commands
{
    class PauseCommand : ICommand
    {
        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            var p = parameter as PlayCommandParameter;
            if (p.CurrentSong.Status == PlayStatus.Playing
                && p.CurrentSong.GetCurrentSong() == p.SelectedSong )
            {
                return true;
            }
            return false;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            var p = parameter as PlayCommandParameter;
            p.CurrentSong.Pause();
        }

        #endregion
    }
}
