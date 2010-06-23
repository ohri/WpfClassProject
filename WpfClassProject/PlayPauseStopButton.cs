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
using PlayCmmnd = WpfClassProject.Commands.PlayCommand;
using PauseCmmnd = WpfClassProject.Commands.PauseCommand;
using StopCmmnd = WpfClassProject.Commands.StopCommand;

namespace WpfClassProject
{
    public class PlayPauseStopButton : RoundImageButton
    {
        static PlayPauseStopButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PlayPauseStopButton), new FrameworkPropertyMetadata(typeof(PlayPauseStopButton)));
        }

        public static readonly DependencyProperty StopCommandProperty =
            DependencyProperty.Register("StopCommand",
                                        typeof(ICommand),
                                        typeof(PlayPauseStopButton),
                                        new PropertyMetadata(OnCommandChanged));
        public ICommand StopCommand
        {
            get { return (ICommand)GetValue(StopCommandProperty); }
            set { SetValue(StopCommandProperty, value); }
        }
        public static readonly DependencyProperty PlayCommandProperty =
            DependencyProperty.Register("PlayCommand",
                                typeof(ICommand),
                                typeof(PlayPauseStopButton),
                                new PropertyMetadata(OnCommandChanged));
        public ICommand PlayCommand
        {
            get { return (ICommand)GetValue(PlayCommandProperty); }
            set { SetValue(PlayCommandProperty, value); }
        }
        public static readonly DependencyProperty PauseCommandProperty =
            DependencyProperty.Register("PauseCommand",
                       typeof(ICommand),
                       typeof(PlayPauseStopButton),
                       new PropertyMetadata(OnCommandChanged));
        public ICommand PauseCommand
        {
            get { return (ICommand)GetValue(PauseCommandProperty); }
            set { SetValue(PauseCommandProperty, value); }
        }

        public PlayStatus NextAction
        {
            get { return (PlayStatus)GetValue(NextActionProperty); }
            set { SetValue(NextActionProperty, value); }
        }

        public static readonly DependencyProperty NextActionProperty =
            DependencyProperty.Register("NextAction",
               typeof(PlayStatus),
               typeof(PlayPauseStopButton) );

        private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var self = d as PlayPauseStopButton;
            if (self == null) return;
            var newCommand = e.NewValue as ICommand;
            if (newCommand != null)
                newCommand.CanExecuteChanged += (s, _) => self.UpdateState();
        }

        public PlayStatus UpdateState()
        {
            if (((PlayCmmnd)PlayCommand).CanExecute(CommandParameter))
            {
                NextAction = PlayStatus.Playing;
                //this.ImageSource.SetValue(ImageSourceProperty, "Images/Play.gif");
                //SetValue(ImageSourceProperty, (ImageSource)("Images/Play.gif"));
                //Console.WriteLine("Set NextAction to playing");
            }
            else if (((PauseCmmnd)PauseCommand).CanExecute(CommandParameter))
            {
                NextAction = PlayStatus.Paused;
                //this.ImageSource.SetValue(ImageSourceProperty, "Images/Pause.gif");
                //SetValue(ImageSourceProperty, (ImageSource)("Images/Pause.gif"));
                //Console.WriteLine("Set NextAction to paused");
            }
            else if (((StopCmmnd)StopCommand).CanExecute(CommandParameter))
            {
                NextAction = PlayStatus.Stopped;
                //this.ImageSource.SetValue(ImageSourceProperty, "Images/stop.gif");
                //SetValue(ImageSourceProperty, (ImageSource)("Images/Stop.gif"));
                //Console.WriteLine("Set NextAction to stopped");
            }
            return NextAction;
        }

        protected override void OnClick()
        {
            UpdateState();
            switch (NextAction)
            {
                case PlayStatus.Paused:
                    ((PauseCmmnd)PauseCommand).Execute(CommandParameter);
                    break;

                case PlayStatus.Playing:
                    ((PlayCmmnd)PlayCommand).Execute(CommandParameter);
                    break;

                case PlayStatus.Stopped:
                    ((StopCmmnd)StopCommand).Execute(CommandParameter);
                    break;
            }
            UpdateState();
        }

    }
}
