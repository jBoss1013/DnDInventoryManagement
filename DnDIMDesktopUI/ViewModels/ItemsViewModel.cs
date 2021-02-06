using Caliburn.Micro;
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
	public class ItemsViewModel : Screen
    {
		IItemEndPoint _itemEndPoint;
		public ItemsViewModel(IItemEndPoint itemEndPoint)
		{
			_itemEndPoint = itemEndPoint;
		}

		protected override async void OnViewLoaded(object view)
		{
			base.OnViewLoaded(view);
			await LoadItems();
		}
		

		private async Task LoadItems()
		{
			var itemsList = await _itemEndPoint.GetAll();

			ItemList = new BindingList<ItemsModel>(itemsList);
		}

		private BindingList<ItemsModel> _itemList;

		public BindingList<ItemsModel> ItemList
		{
			get { return _itemList; }
			set 
			{
				_itemList = value;
				NotifyOfPropertyChange(() => ItemList);
				
			}
		}
		private ItemsModel _selectedItem;

		public ItemsModel SelectedItem
		{
			get { return _selectedItem; }
			set 
			{ 
				_selectedItem = value;
				NotifyOfPropertyChange(() => SelectedItem);
				NotifyOfPropertyChange(() => CanAddToInventory);
				NotifyOfPropertyChange(() => CanDeleteItem);
			}
		}


		private string _itemListDescriptionText;

		public string ItemListDescriptionText
		{
			get { return _itemListDescriptionText; }
			set 
			{	
				_itemListDescriptionText = value;
				NotifyOfPropertyChange(() => SelectedItem);
				NotifyOfPropertyChange(() => ItemListDescriptionText);

			}
		}

		private int _addItemQuantity;

		public int AddItemQuantity
		{
			get { return _addItemQuantity; }
			set 
			{ 
				
				_addItemQuantity = value;
				NotifyOfPropertyChange(() => AddItemQuantity);
				NotifyOfPropertyChange(() => CanAddToInventory);
			}
		}

		public bool CanAddToInventory 
		{
			get 
			{
				
				bool output = false;
				if (SelectedItem!= null && AddItemQuantity >0)
				{
					output = true;
				}
				return output;
			} 
		}

		public bool CanDeleteItem

		{
			get 
			{
				bool output = false;
				if (SelectedItem!=null)
				{
					output = true;
				}
				return output;
			}
		}

		public void DeleteItem()
		{

		}

		public void AddToInventory()
		{
			
		}

	}
}
