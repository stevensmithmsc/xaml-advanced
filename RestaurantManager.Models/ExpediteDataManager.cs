using System.Collections.Generic;

namespace RestaurantManager.Models
{
    public class ExpediteDataManager : DataManager
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
                this.OnPropertyChanged();
            }
        }
    }
}
