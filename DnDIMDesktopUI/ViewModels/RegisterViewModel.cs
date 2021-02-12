using Caliburn.Micro;
using DnDIMDesktopUI.EventModel;
using DnDIMDesktopUI.Helpers.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDIMDesktopUI.ViewModels
{
    public class RegisterViewModel :Screen
    {
		
		IEventAggregator _events;

		public RegisterViewModel(IEventAggregator events)
		{

			_events = events;
		}

		public void Cancel()
        {
			_events.PublishOnUIThread(new LogInEvent()); 
		}
	}
}
