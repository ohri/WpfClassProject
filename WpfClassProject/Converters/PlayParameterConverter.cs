using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using WpfClassProject.DataContexts;
using System.Windows;

namespace WpfClassProject.Converters
{
    class PlayParameterConverter : IMultiValueConverter
    {

        #region IMultiValueConverter Members

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            PlayCommandParameter p = new PlayCommandParameter();

            if (values[0] != DependencyProperty.UnsetValue)
            {
                p.CurrentSong = (IMediaPlayer)values[0];
            }
            if (values[1] != DependencyProperty.UnsetValue)
            {
                p.SelectedPlaylist = (IPlaylist)values[1];
            }
            if (values[2] != DependencyProperty.UnsetValue)
            {
                p.SelectedSong = (ISong)values[2];
            }

            return p;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            object[] o = new object[3];

            if (value != null)
            {
                o[0] = ((PlayCommandParameter)value).CurrentSong;
                o[1] = ((PlayCommandParameter)value).SelectedPlaylist;
                o[2] = ((PlayCommandParameter)value).SelectedSong;
            }

            return o;
        }

        #endregion
    }
}
