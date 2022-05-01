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
        DbSet<Todo> todos;
        Todo t;
        dat154_2022_42Context hcx;
        public RoomPage(dat154_2022_42Context hcx, Room r)
        {
            InitializeComponent();
            this.hcx = hcx;

            this.r = r;
            todos = hcx.Todos;
            todos.Load();

            Roomnr.Text += r.Roomnr;
            Beds.Text += r.Beds;
            Size.Text += r.Size;
            Price.Text += r.Price;
            Available.Text += r.Available;
            InOrder.Text += r.InOrder;
            tasksList.DataContext = r.Todos;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            //String n = AddNotes.Text;
            //String i = AddInfo.Text;
            //int taskType = TaskType.SelectedIndex + 1;
            //int taskState = TaskState.SelectedIndex;
            //if (taskState == -1)
            //{
            //    taskState = 0;
            //}

            //if (taskType != 1 && taskType != 2)
            //{
            //    TTNS.Visibility = Visibility.Visible;
            //}
            //else
            //{
            //    if (t == null)
            //    {
            //        t = new ClassLibraryHotel.Task();
            //        t.Note = n;
            //        t.Info = i;
            //        t.Type = taskType;
            //        t.State = taskState;
            //        t.Room = r;
            //        t.RoomRoomId = r.RoomId;

            //        tasks.Add(t);
            //        hcx.SaveChanges();
            //        tasksList.DataContext = null;
            //        tasksList.DataContext = r.Tasks;
            //    }
            //    else
            //    {
            //        t.Note = n;
            //        t.Info = i;
            //        t.Type = taskType;
            //        t.State = taskState;
            //        hcx.SaveChanges();
            //        tasksList.DataContext = null;
            //        tasksList.DataContext = r.Tasks;
            //    }

            //    Reset();

                //Må oppdatere viduet slik at nye tasks vises.
            //}
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
    }
}
