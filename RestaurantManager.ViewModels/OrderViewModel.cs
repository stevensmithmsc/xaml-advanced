using RestaurantManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Windows.UI.Popups;

namespace RestaurantManager.ViewModels
{
    public class OrderViewModel : ViewModel
    {       
        protected override void OnDataLoaded()
        {
            this.MenuItems = base.Repository.StandardMenuItems;
            this.SpecialRequests = "";
            this._table = base.Repository.Tables[0];
            this.CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>();
        }

        private List<MenuItem> _menuItems;

        public List<MenuItem> MenuItems { get { return this._menuItems; }
            set
            {
                this._menuItems = value;
                this.NotifyPropertyChanged();    
            }
        }

        private ObservableCollection<MenuItem> _currentlySelectedMenuItems;

        public ObservableCollection<MenuItem> CurrentlySelectedMenuItems { get { return this._currentlySelectedMenuItems; }
            set {
                this._currentlySelectedMenuItems = value;
                this.NotifyPropertyChanged();
            }
        }

        private string _specialRequests;

        public string SpecialRequests { get { return this._specialRequests; }
            set
            {
                this._specialRequests = value;
                this.NotifyPropertyChanged();
            }
        }

        private Table _table;  //not implemented in view yet so no need for getter and setter

        public ICommand AddToOrderCommand { get; private set; }

        public ICommand SubmitOrderCommand { get; private set; }

        private async void AddToOrder(object parameter)
        { 
            if (parameter is MenuItem) {
                MenuItem mymenuitem = (MenuItem)parameter;
                CurrentlySelectedMenuItems.Add(mymenuitem);
            } else await new MessageDialog("Please selected an item from the Menu!").ShowAsync();
        }

        private async void SubmitOrder(object parameter)
        {
            Order newOrder = new Order();
            newOrder.Table = this._table;
            newOrder.SpecialRequests = this.SpecialRequests;
            newOrder.Items = this.CurrentlySelectedMenuItems.ToList<MenuItem>();
            base.Repository.Orders.Add(newOrder);
            await new MessageDialog("Order has been submitted.").ShowAsync();
            resetOrder();
        }

        private void resetOrder()
        {
            this.SpecialRequests = "";
            this.CurrentlySelectedMenuItems.Clear();
        }

        public OrderViewModel() {
            AddToOrderCommand = new DelegateCommand<object>(AddToOrder);
            SubmitOrderCommand = new DelegateCommand<object>(SubmitOrder);
        }
    }
}
