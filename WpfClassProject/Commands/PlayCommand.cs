using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using WpfClassProject.DataContexts;

namespace WpfClassProject.Commands
{
    class PlayCommand : RoutedCommand
    {
        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            var p = parameter as PlayCommandParameter;
            if (p.CurrentSong.Status == PlayStatus.Stopped)
            {
                return true;
            }
            if (p.CurrentSong.Status == PlayStatus.Paused 
                && p.SelectedPlaylist == p.CurrentSong.CurrentPlaylist)
            {
                return true;
            }
            return false;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            var p = parameter as PlayCommandParameter;
            p.CurrentSong.PlaySong(p.SelectedSong, p.SelectedPlaylist);
        }

        #endregion
    }
}
