using Library.Data;
using Library.Models;
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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private readonly dat154_2022_42Context ctx = new();

        public MainPage()
        {
            InitializeComponent();
        }

        private void UserSearch_Button(object sender, RoutedEventArgs e)
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

        private void ShowReservations_Button(object sender, RoutedEventArgs e)
        {
            ReservationsPage reservationsPage = new(ctx);
            this.NavigationService.Navigate(reservationsPage);
        }

        private void RoomInfo_Button(object sender, RoutedEventArgs e)
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

        private void AllRoms_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void NewReservation_Button(object sender, RoutedEventArgs e)
        {
           
        }

        private void CreateNewRoomButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
