using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using DnDIMDesktopUI.EventModel;

namespace DnDIMDesktopUI.ViewModels
{
    public class ShellViewModel :Conductor<object>, IHandle<LogOnEvent>    
    {
        
        private IEventAggregator _events;
        private CharacterViewModel _characterVM;
        private SimpleContainer _container;
        public ShellViewModel( IEventAggregator events, CharacterViewModel characterVM,
            SimpleContainer container)

        {
            
            _events = events;
            _characterVM = characterVM;
            _events.Subscribe(this);
            _container = container;
            
            //This overrides current instaance of LoginViewModel with empty LoginViewModel
            //This ensures that we do not accidently capture user and password data
            //Also clears the login form if it reactivates
            ActivateItem(_container.GetInstance<LoginViewModel>());
        }

        public void Handle(LogOnEvent message)
        {
            ActivateItem(_characterVM);
        }

        public void CharacterTab()
        {

        }
    }
}
