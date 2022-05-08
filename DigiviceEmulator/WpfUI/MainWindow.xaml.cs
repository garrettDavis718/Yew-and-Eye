using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DigiviceEmulatorLib;
using System.Threading;
using System.Collections.Concurrent;

namespace WpfUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();     
        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
			Controller.Play();
        }

        private void cleanButton_Click(object sender, RoutedEventArgs e)
        {
			Controller.Clean();
        }

        private void feedButton_Click(object sender, RoutedEventArgs e)
        {
			Controller.Feed();
        }

        private void danceButton_Click(object sender, RoutedEventArgs e)
        {
			Controller.Dance();
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
			Controller.Reset();
        }

        private void quitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
            Thread DisplayDriver = new Thread(new ThreadStart(Animator))
            {
                IsBackground = true
            };
            DisplayDriver.Start();
        }

		private void Animator()
		{
			const int FrameDelay = 500,
					  AnimationLength = 2;
			Monster.States? previousState = null;
			int frameIndex = 0;
			DateTime notIdleSince = DateTime.UtcNow;
			while (true)
			{
				TimeOps.SimulateTime();
				if (previousState != Monster.State)
				{
					frameIndex = 0;
					if (Monster.State != Monster.States.idle)
					{
						notIdleSince = DateTime.UtcNow;
					}
				}
				switch (Monster.State)
				{
					case Monster.States.idle:
						AnimationQueue.Enqueue(Monster.Animations.Idle[frameIndex]);
						break;
					case Monster.States.eating:
						AnimationQueue.Enqueue(Monster.Animations.Eat[frameIndex]);
						break;
					case Monster.States.playing:
						AnimationQueue.Enqueue(Monster.Animations.Play[frameIndex]);
						break;
					case Monster.States.dancing:
						AnimationQueue.Enqueue(Monster.Animations.Dance[frameIndex]);
						break;
				}
				if (Monster.State != Monster.States.idle
					&& TimeOps.GetElapsedSeconds(notIdleSince, DateTime.UtcNow) >= AnimationLength)
				{
					Monster.State = Monster.States.idle;
				}
				AnimationQueue.TryDequeue(out string result);
				Dispatcher.BeginInvoke(new ThreadStart(() => monsterTextblock.Text = result));
				Dispatcher.BeginInvoke(new ThreadStart(() => healthTextBlock.Text = Monster.Health.ToString()));
				Dispatcher.BeginInvoke(new ThreadStart(() => moodTextBlock.Text = Monster.Mood.ToString()));
				Dispatcher.BeginInvoke(new ThreadStart(() => hygieneTextBlock.Text = Monster.Hygiene.ToString()));
				frameIndex = frameIndex == 3 ? 0 : frameIndex + 1;
				previousState = Monster.State;
				Thread.Sleep(FrameDelay);
			}


		}

		public ConcurrentQueue<string> AnimationQueue { get; set; } = new ConcurrentQueue<string>();
	}
}
