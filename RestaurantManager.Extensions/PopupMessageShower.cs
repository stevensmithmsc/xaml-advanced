using Microsoft.Xaml.Interactivity;
using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace RestaurantManager.Extensions
{
    public class PopupMessageShower : DependencyObject, IBehavior
    {
        public string Message { get; set; }

        public DependencyObject AssociatedObject { get; private set; }

        public void Attach(DependencyObject associatedObject)
        {
            if (associatedObject is Page)
            {
                this.AssociatedObject = associatedObject;
                (this.AssociatedObject as Page).RightTapped += Page_RightTapped;
            }
        }

        public void Detach()
        {
            if (this.AssociatedObject != null && this.AssociatedObject is Page)
            {
                this.AssociatedObject = null;
                (this.AssociatedObject as Page).RightTapped -= Page_RightTapped;
            }
        }

        private async void Page_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            await new MessageDialog(this.Message).ShowAsync();
        }

    }
}
