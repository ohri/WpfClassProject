using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfClassProject.DataContexts.RuntimeContexts;
using WpfClassProject.DataContexts;

namespace WpfClassProject
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : Window
    {
        public Shell()
        {
            InitializeComponent();
            DataContext = new ShellContext();
        }

        protected void HandleDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var i = sender as ListViewItem;
            if (((ShellContext)DataContext).CurrentSong != (ISong)lvSongs.SelectedItem)
            {
                ((ShellContext)DataContext).CurrentSong.Stop();
            }
            ((ShellContext)DataContext).CurrentSong.PlaySong((ISong)lvSongs.SelectedItem,
                (IPlaylist)lbPlaylists.SelectedItem);

            e.Handled = true;
        }
    }
}
