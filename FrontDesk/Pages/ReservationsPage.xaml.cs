using FrontDesk.Pages;
using Library;
using Library.Data;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for ReservationsPage.xaml
    /// </summary>
    public partial class ReservationsPage : Page
    {
        private readonly dat154_2022_42Context hcx;
        private Reservation selectedRes;
        private Room selectedAvbRoom;
        private string username;
        public ReservationsPage(dat154_2022_42Context hcx)
        {
            InitializeComponent();

            hcx.Reservations.Load();
            hcx.Rooms.Load();
            hcx.Users.Load();

            this.hcx = hcx;

            var res = hcx.Reservations;

            ResList.DataContext = res.Local.ToObservableCollection();

            ResList.SelectionChanged += ResList_SelectionChanged;
            AvailableRooms.SelectionChanged += AvailableRooms_SelectionChanged;
        }


        public ReservationsPage(dat154_2022_42Context hcx, string usr)
        {
            InitializeComponent();
            
            hcx.Reservations.Load();
            hcx.Rooms.Load();
            hcx.Users.Load();

            this.hcx = hcx;
            this.username = usr;

            var user = hcx.Users.Local.ToObservableCollection().FirstOrDefault(u => u.Name.Equals(usr));

            ResList.DataContext = user.Reservations;

            ResList.SelectionChanged += ResList_SelectionChanged;
            AvailableRooms.SelectionChanged += AvailableRooms_SelectionChanged;
        }

        private void ResList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListView).SelectedIndex != -1)
            {
                if (ContentGrid.Visibility is Visibility.Hidden) ContentGrid.Visibility = Visibility.Visible;
                selectedRes = (sender as ListView).SelectedItem as Reservation;
                ResId.Text = ((sender as ListView).SelectedItem as Reservation).Id.ToString();
                Roomnr.Text = ((sender as ListView).SelectedItem as Reservation).RoomnrNavigation.Roomnr.ToString();

                if (selectedRes.CheckedIn == true)
                {
                    CheckIn.Content = "Check out";
                }
                else
                {
                    CheckIn.Content = "Check in";
                }

                if (selectedRes.CheckedOut == true)
                {
                    CheckIn.Visibility = Visibility.Hidden;
                    othrAvbRooms.Visibility = Visibility.Hidden;
                }
                else
                {
                    CheckIn.Visibility = Visibility.Visible;
                    othrAvbRooms.Visibility = Visibility.Visible;
                }

                AvbRoomsTxt.Visibility = Visibility.Hidden;
                AvailableRooms.Visibility = Visibility.Hidden;
            }

        }

        private void AvailableRooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ListView).SelectedIndex != -1)
            {
                selectedAvbRoom = (sender as ListView).SelectedItem as Room;
                ChangeRoomBtn.Visibility = Visibility.Visible;
            }
            else
            {
                ChangeRoomBtn.Visibility = Visibility.Hidden;
            }

        }
        private void AvbRooms_Click(object sender, RoutedEventArgs e)
        {
            List<Room> availableRooms = Controller.GetAvailableRooms(hcx, 0, 0, selectedRes.DateStart, selectedRes.DateEnd);

            AvailableRooms.DataContext = availableRooms;

            AvbRoomsTxt.Visibility = Visibility.Visible;
            AvailableRooms.Visibility = Visibility.Visible;
        }

        private void ChangeRoom_Click(object sender, RoutedEventArgs e)
        {
            selectedRes.Roomnr = selectedAvbRoom.Roomnr;
            hcx.SaveChanges();

            AvailableRooms.DataContext = null;

            Roomnr.Text = selectedRes.Roomnr.ToString();

            AvailableRooms.Visibility = Visibility.Hidden;
            ChangeRoomBtn.Visibility = Visibility.Hidden;
            AvbRoomsTxt.Visibility = Visibility.Hidden;

            ResList.DataContext = null;
            var updatedRes = hcx.Reservations;
            ResList.DataContext = updatedRes.Local.ToObservableCollection();
        }

        private void CheckIn_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRes.CheckedIn == false)
            {
                selectedRes.CheckedIn = true;
                hcx.SaveChanges();

                ContentGrid.Visibility = Visibility.Hidden;
            }
            else
            {
                selectedRes.CheckedOut = true;

                hcx.SaveChanges();

                CheckIn.Visibility = Visibility.Hidden;
                othrAvbRooms.Visibility = Visibility.Hidden;
            }

            ResList.DataContext = null;

            if (username == null)
            {
                hcx.Reservations.Load();
                var updatedRes = hcx.Reservations;
                ResList.DataContext = updatedRes.Local.ToObservableCollection();
            }
            else
            {
                hcx.Users.Load();
                var user = hcx.Users.Local.FirstOrDefault(u => u.Name.Equals(username));
                ResList.DataContext = user.Reservations;
            }
        }

        private void DelRes_Click(object sender, RoutedEventArgs e)
        {
            hcx.Reservations.Remove(selectedRes);
            hcx.SaveChanges();

            ContentGrid.Visibility = Visibility.Hidden;

            ResList.DataContext = null;

            if (username == null)
            {
                hcx.Reservations.Load();
                var updatedRes = hcx.Reservations;
                ResList.DataContext = updatedRes.Local.ToObservableCollection();
            }
            else
            {
                hcx.Users.Load();
                var user = hcx.Users.Local.FirstOrDefault(u => u.Email.Equals(username));
                ResList.DataContext = user.Reservations;
            }
        }
    }
}
