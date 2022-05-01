using System.Windows;

namespace FrontDesk.Dialogs
{
    /// <summary>
    /// Interaction logic for NewRoomDialog.xaml
    /// </summary>
    public partial class NewReservationDialog : Window
    {
        public NewReservationDialog()
        {
            InitializeComponent();
        }

        public bool Canceled { get; set; }
        
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            Canceled = false;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Canceled = true;
            Close();
        }
    }
}
