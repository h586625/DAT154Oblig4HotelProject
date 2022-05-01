using FrontDesk.Dialogs;
using Library.Data;
using Library.Models;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace FrontDesk
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private readonly dat154_2022_42Context ctx = new();

        public MainPage()
        {
            InitializeComponent();
        }

        private void SearchForRoomByRoomNumber_Click(object sender, RoutedEventArgs e)
        {
            bool isRoom = int.TryParse(roomNumberText.Text, out int roomId);
            Room roomFound = ctx.Rooms.Find(roomId);
            if (isRoom && (roomFound != null))
            {
                this.NavigationService.Navigate(new RoomPage(ctx, roomFound));

            }
            else
            {
                roomNumberText.Text = "Enter a valid roomnumber";
            }
        }

        private void SearchForReservationByUser_Click(object sender, RoutedEventArgs e)
        {
            var studentName = ctx.Users.FirstOrDefault(u => u.Name.Equals(userNameText.Text));
            Trace.WriteLine(studentName);
            if (studentName != null)
            {
                ReservationsPage reservationsPage = new(ctx, userNameText.Text);
                this.NavigationService.Navigate(reservationsPage);
            }
            else
            {
                userNameText.Text = "Please enter a valid user.";
            }
        }
        private void ShowRooms_Click(object sender, RoutedEventArgs e)
        {
            RoomsPage roomsPage = new(ctx);
            this.NavigationService.Navigate(roomsPage);
        }

        private void ShowReservations_Click(object sender, RoutedEventArgs e)
        {
            ReservationsPage reservationsPage = new(ctx);
            this.NavigationService.Navigate(reservationsPage);
        }
        private void CreateNewRoom_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new NewRoomDialog();
            dialog.Show();
            dialog.Owner = Window.GetWindow(this);
            dialog.Closing += (sender, e) =>
            {
                var d = sender as NewRoomDialog;
                if (!d.Canceled)
                {
                    int roomnr = int.Parse(d.RoomnrTextBox.Text);
                    int beds = int.Parse(d.BedsTextBox.Text);
                    int size = int.Parse(d.SizeTextBox.Text);
                    int price = int.Parse(d.PriceTextBox.Text);

                    Room room = new() { 
                        Roomnr = roomnr, 
                        Beds = beds, 
                        Size = size, 
                        Price = price,
                        Available = true,
                        InOrder = true
                    };
                    ctx.Rooms.Add(room);
                    ctx.SaveChanges();
                }
            };
        }

        private void CreateNewReservation_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new NewReservationDialog();
            dialog.Show();
            dialog.Owner = Window.GetWindow(this);
            dialog.Closing += (sender, e) =>
            {
                var d = sender as NewReservationDialog;
                if (!d.Canceled)
                {
                    int roomnr = int.Parse(d.RoomnrTextBox.Text);
                    int userid = int.Parse(d.UseridTextBox.Text);
                    var dateStart = DateTime.Parse(d.DateStart.Text);
                    var dateEnd = DateTime.Parse(d.DateEnd.Text);

                    Reservation reservation = new()
                    {
                        Roomnr = roomnr,
                        Userid = userid,
                        DateStart = dateStart,
                        DateEnd = dateEnd,
                    };
                    ctx.Reservations.Add(reservation);
                    ctx.SaveChanges();
                }
            };
        }
    }
}
