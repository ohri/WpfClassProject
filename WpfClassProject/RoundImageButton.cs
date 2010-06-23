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

namespace WpfClassProject
{
    public class RoundImageButton : Button
    {
        static RoundImageButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RoundImageButton), new FrameworkPropertyMetadata(typeof(RoundImageButton)));
        }

        public static DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource",
               typeof(ImageSource),
               typeof(Button));

        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue( ImageSourceProperty, value ); }
        }
    }
}
