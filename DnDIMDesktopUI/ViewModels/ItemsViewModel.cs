using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDIMDesktopUI.ViewModels
{
    class ItemsViewModel :Screen
    {
		private BindingList<string> _itemList;

		public BindingList<string> ItemList
		{
			get { return _itemList; }
			set 
			{
				_itemList = value; 
			}
		}

		private string _itemListDescriptionText;

		public string ItemListDescriptionText
		{
			get { return _itemListDescriptionText; }
			set 
			{ 
				_itemListDescriptionText = value; 
			}
		}

		private int _addItemQuantity;

		public int AddItemQuantity
		{
			get { return _addItemQuantity; }
			set 
			{ 
				_addItemQuantity = value; 
			}
		}



	}
}
