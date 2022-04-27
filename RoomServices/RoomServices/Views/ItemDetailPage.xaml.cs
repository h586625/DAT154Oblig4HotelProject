using RoomServices.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace RoomServices.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}