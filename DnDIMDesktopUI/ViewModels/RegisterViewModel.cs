using Caliburn.Micro;
using DnDIMDesktopUI.EventModel;
using DnDIMDesktopUI.Helpers.API;
using DnDIMDesktopUI.Library.API;
using DnDIMDesktopUI.Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDIMDesktopUI.ViewModels
{
    public class RegisterViewModel :Screen
    {
		
		IEventAggregator _events;
		IRegisterUserEndPoint _registerUserEndpoint;
		private IAPIHelper _aPIHelper;

		private string _userName;
		private string _email;
		private string _password;
		private string _confirmPassword;

		public RegisterViewModel(IAPIHelper apiHelper ,IEventAggregator events, IRegisterUserEndPoint registerUserEndpoint)
		{

			_events = events;
			_aPIHelper = apiHelper;
			_registerUserEndpoint = registerUserEndpoint;
		}

		public string UserName 
		{
			get { return _userName; }

			set
			{
				_userName = value;
				NotifyOfPropertyChange(() => UserName);
				NotifyOfPropertyChange(() => CanRegister);
			}
		}

		public string Email
		{
			get { return _email; }
			set 
			{ 
				_email = value;
				NotifyOfPropertyChange(() => Email);
				NotifyOfPropertyChange(() => CanRegister);
			}
		}

		public string Password
		{
			get { return _password; }
			set 
			{ 
				_password = value;
				NotifyOfPropertyChange(() => Password);
				NotifyOfPropertyChange(() => CanRegister);
			}
		}

		public string ConfirmPassword
		{
			get { return _confirmPassword; }
			set 
			{ 
				_confirmPassword = value;
				NotifyOfPropertyChange(() => ConfirmPassword);
				NotifyOfPropertyChange(() => CanRegister);

			}
		}


		public bool IsErrorVisible
		{
			get
			{
				bool output = false;
				if (ErrorMessage?.Length > 0)
				{
					output = true;
				}

				return output;
			}

		}

		private string _errorMessage;
		public string ErrorMessage
		{
			get { return _errorMessage; }
			set
			{
				_errorMessage = value;
				NotifyOfPropertyChange(() => IsErrorVisible);
				NotifyOfPropertyChange(() => ErrorMessage);

			}
		}

		public bool CanRegister
		{
			get
			{	bool output = false;

				//if (UserName?.Length > 0 && Email?.Length >0 && Password?.Length > 0 && ConfirmPassword?.Length >0)
				//{
				//	output = true;
				//}
				return output;
			}  
		}

		public async Task Register()
		{
			RegisterUserModel newUser = new RegisterUserModel
			{
				UserName = UserName,
				Email = Email,
				Password = Password,
				ConfrimPassword = ConfirmPassword
			};

			try
			{
				
				ErrorMessage = "";
				await _registerUserEndpoint.PostRegisterUser(newUser);
				_events.PublishOnUIThread(new LogInEvent());

			}
			catch (Exception ex)
			{
				ErrorMessage = ex.Message;
			}

		}


		public void Cancel()
        {
			_events.PublishOnUIThread(new LogInEvent()); 
		}
	}
}
