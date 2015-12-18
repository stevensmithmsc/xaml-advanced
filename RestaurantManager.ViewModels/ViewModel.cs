using RestaurantManager.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RestaurantManager.ViewModels
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        protected RestaurantContext Repository { get; private set; }

        private bool _isLoading;
        public bool IsLoading { get { return _isLoading; } set { _isLoading = value;  NotifyPropertyChanged(); } }

        public ViewModel()
        {
            LoadData();
        }

        private async void LoadData()
        {
            IsLoading = true;
            this.Repository = await RestaurantContextFactory.GetRestaurantContextAsync();
            OnDataLoaded();
            IsLoading = false;
        }

        protected abstract void OnDataLoaded();

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
