using Library.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FrontDesk
{
    /// <summary>
    /// Interaction logic for RoomsPage.xaml
    /// </summary>
    public partial class RoomsPage : Page
    {
        private readonly dat154_2022_42Context hcx;
        public RoomsPage(dat154_2022_42Context hcx)
        {
            InitializeComponent();

            hcx.Rooms.Load();

            this.hcx = hcx;

            var rooms = hcx.Rooms;

            RoomsList.DataContext = rooms.Local.ToObservableCollection();
        }
        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Gjettet meg også frem til store deler av denne. Gjetting nr 3 i prosjektet som funker?
            var room = (sender as ListViewItem).DataContext as Library.Models.Room;
            if (room != null)
            {
                this.NavigationService.Navigate(new RoomPage(hcx, room));
            }
        }
    }
}
