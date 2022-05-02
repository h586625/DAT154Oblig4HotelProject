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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class RoomPage : Page
    {
        private Room r;
        //DbSet<Todo> todos;
        //Todo t;
        dat154_2022_42Context hcx;
        public RoomPage(dat154_2022_42Context hcx, Room r)
        {
            InitializeComponent();
            this.hcx = hcx;
            this.r = r;
            hcx.Rooms.Load();
            var todos = hcx.Todos;

            RoomNumber.Text += r.Roomnr;
            Beds.Text += r.Beds;
            Size.Text += r.Size;
            tasksList.DataContext = todos.Local.ToObservableCollection().Where(t => t.Roomid == r.Roomnr);
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (sender != null) {

                Todo td = new Todo() {
                    Roomid = r.Roomnr,
                    Cleaned = !(bool)AddCleaning.IsChecked,
                    Maintained = !(bool)AddMaintenance.IsChecked,
                    Serviced = !(bool)AddService.IsChecked,
                    Notes = AddNotes.Text,
                };
                if (!td.Cleaned || !td.Maintained || !td.Serviced)
                {
                    hcx.Todos.Add(td);
                    hcx.SaveChanges();
                } else
                {
                    Debug.WriteLine("You tried to submit an empty request");
                }
            } else {
                Debug.WriteLine("Ermagerd!");
            }
            this.NavigationService.Navigate(new RoomPage(hcx, r));
        }

        private void TaskList_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //t = (Task)tasksList.SelectedItem;
            //AddNotes.Text = t.Note;
            //AddInfo.Text = t.Info;
            //TaskType.SelectedIndex = t.Type - 1;
            //TaskState.SelectedIndex = t.State;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            //Reset();
        }

        private void Reset()
        {
            //AddNotes.Text = "";
            //AddInfo.Text = "";
            //TaskType.SelectedIndex = -1;
            //TaskState.SelectedIndex = -1;
            //t = null;
            //TTNS.Visibility = Visibility.Hidden;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            hcx.Rooms.Remove(r);
            hcx.SaveChanges();
            RoomsPage roomsPage = new(hcx);
            this.NavigationService.Navigate(roomsPage);
        }
    }
}
