using System.Collections.Generic;
using RestaurantManager.Models;

namespace RestaurantManager.ViewModels
{
    public class ExpediteViewModels : ViewModel
    {
        protected override void OnDataLoaded()
        {
            this.OrderItems = base.Repository.Orders;
        }

        private List<Order> _orderItems;

        public List<Order> OrderItems
        {
            get { return this._orderItems; }
            set {
                this._orderItems = value;
                this.NotifyPropertyChanged();
            }
        }
    }
}
