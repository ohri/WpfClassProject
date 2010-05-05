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
using WpfClassProject.DataContexts;

namespace WpfClassProject
{
    /// <summary>
    /// Interaction logic for PlayerControl.xaml
    /// </summary>
    public partial class PlayerControl : UserControl
    {
        public PlayerControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty PlayCommandParameterProperty =
            DependencyProperty.Register("PlayCommandParameter",
        typeof(PlayCommandParameter),
        typeof(PlayerControl));

        public PlayCommandParameter PlayCommandParameter
        {
            get { return PlayCommandParameter; }
            set { PlayCommandParameter = value; }
        }
    }
}
