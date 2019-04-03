using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using NHotkey;

namespace Speedrunner.ViewModels
{
	class MainViewModel
	{
		private string _timer = "TEST TEST";
		public string Timer
		{
			get { return _timer; }
			set
			{
				_timer = value;
				OnPropertyChanged();
			}
		}
		public bool IsTimerActive { get; set; }

		public void OnStartStopTimer(object sender, HotkeyEventArgs e)
		{
			if (IsTimerActive == false)
			{
				Timer = "Timer Started";
				IsTimerActive = true;
				e.Handled = true;

			}
			else
			{
				Timer = "Timer Stopped";
				IsTimerActive = false;
				e.Handled = true;
			}

		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
