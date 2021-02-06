using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDIMDesktopUI.ViewModels
{
    public class CharacterViewModel : Screen
    {
		private string _characterName;

		public string CharacterName
		{
			get { return _characterName; }
			set 
			{ 
				_characterName = value;
				NotifyOfPropertyChange(() => CharacterName);
			}
		}

		private BindingList<string> _items;

		public BindingList<string> Items
		{
			get { return _items; }
			set 
			{ 
				_items = value;
				NotifyOfPropertyChange(() => Items);
			}
		}

		private string _descriptionText;

		public string DescriptionText
		{
			get { return _descriptionText; }
			set 
			{
				_descriptionText = value;
				NotifyOfPropertyChange(() => DescriptionText);
			}
		}

		private int _itemQuantity;

		public int ItemQuantity
		{
			get { return _itemQuantity; }
			set 
			{ 
				_itemQuantity = value;
				NotifyOfPropertyChange(() => ItemQuantity);
			}
		}
		public void RemoveItem()
		{

		}

		public bool CanRemoveItem
		{
			get
			{
				bool output = false;

				return output;
			}
		}


	}
}
