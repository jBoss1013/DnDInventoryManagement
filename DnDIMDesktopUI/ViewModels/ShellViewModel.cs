using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using DnDIMDesktopUI.EventModel;
using DnDIMDesktopUI.Library.Model;

namespace DnDIMDesktopUI.ViewModels
{
    public class ShellViewModel :Conductor<object>, IHandle<LogOnEvent>, 
        IHandle<RegisterUserEvent>,
        IHandle<LogInEvent>
    {
        
        private IEventAggregator _events;
        private CharacterViewModel _characterVM;
        private ILoggedInUserModel _user;
        private RegisterViewModel _registerUser;
        
      

        public ShellViewModel( IEventAggregator events, CharacterViewModel characterVM, ILoggedInUserModel user,RegisterViewModel registerUser )

        {
            _events = events;
            _characterVM = characterVM;
            _user = user;
            _registerUser = registerUser;
            _events.Subscribe(this);
            
            //This overrides current instaance of LoginViewModel with empty LoginViewModel
            //This ensures that we do not accidently capture user and password data
            //Also clears the login form if it reactivates
            ActivateItem(IoC.Get<LoginViewModel>());
        }

        public bool IsLogOutVisible 
        {
            get
            {
                return IsLoggedIn();
            } 
        }

        public bool IsCharacterTabVisible
        {
            get
            {
                return IsLoggedIn();
            }  
        }

        public bool IsItemTabVisible
        {
            get
            {
                return IsLoggedIn();
            }
        }

        public bool IsCreateItemTabVisible
        {
            get
            {
                return IsLoggedIn();
            }
        }


        public void ExitApplication()
        {
            TryClose();
        }

        public void LogOut()
        {
            _user.LogOffUser();
            ActivateItem(IoC.Get<LoginViewModel>());
            NotifyOfPropertyChange(() => IsLogOutVisible);
            NotifyOfPropertyChange(() => IsCharacterTabVisible);
            NotifyOfPropertyChange(() => IsCreateItemTabVisible);
            NotifyOfPropertyChange(() => IsItemTabVisible);
        }

        public void Handle(LogOnEvent message)
        {
            ActivateItem(_characterVM);
            NotifyOfPropertyChange(() => IsLogOutVisible);
            NotifyOfPropertyChange(() => IsCharacterTabVisible);
            NotifyOfPropertyChange(() => IsCreateItemTabVisible);
            NotifyOfPropertyChange(() => IsItemTabVisible);
        }

        public void ItemTab()
        {
            
            ActivateItem(IoC.Get<ItemsViewModel>());
        }

        public void CharacterTab()
        {
            ActivateItem(IoC.Get<CharacterViewModel>());
        }

        private bool IsLoggedIn()
        {
            bool output = false;
            if (string.IsNullOrWhiteSpace(_user.Token) == false)
            {
                output = true;
            }
            return output;
        }

        public void Handle(RegisterUserEvent message)
        {
            ActivateItem(IoC.Get<RegisterViewModel>());
        }

        public void Handle(LogInEvent message)
        {
            ActivateItem(IoC.Get<LoginViewModel>());

        }
       
    }
}
