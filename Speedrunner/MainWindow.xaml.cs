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
using NHotkey;
using NHotkey.Wpf;
using Speedrunner.ViewModels;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Speedrunner
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		private string _timer;
		public string Timer
		{
			get { return _timer; }
			set
			{
				_timer = value;
				OnPropertyChanged("Timer");
			}
		}
		public bool isTimerActive { get; set; }

		public MainWindow()
		{
			HotkeyManager.HotkeyAlreadyRegistered += HotkeyManager_HotkeyAlreadyRegistered;

			HotkeyManager.Current.AddOrReplace("StartStopTimer", Key.D1, ModifierKeys.Shift, OnStartStopTimer);

			//HotkeyManager.Current.Remove("Increment");
			//HotkeyManager.Current.Remove("Decrement");

			InitializeComponent();
			DataContext = this;
		}

		private void HotkeyManager_HotkeyAlreadyRegistered(object sender, HotkeyAlreadyRegisteredEventArgs e)
		{
			MessageBox.Show(string.Format("The hotkey {0} is already registered by another application", e.Name));
		}

		private void OnStartStopTimer(object sender, HotkeyEventArgs e)
		{
			if (isTimerActive == false)
			{
				Timer = "Timer Started";
				isTimerActive = true;
			}
			else
			{
				Timer = "Timer Stopped";
				isTimerActive = false;
			}

			e.Handled = true;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
