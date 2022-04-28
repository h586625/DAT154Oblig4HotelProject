﻿using Library.Data;
using Library.Models;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HotelContext ctx = new();
        readonly DbSet<User> users;

        public MainWindow()
        {
            InitializeComponent();

            users = ctx.Set<User>();
            users.Load();

            Refresh();
        }

        private void Refresh()
        {
            CustomerList.DataContext = users.Local.ToList();
        }
    }
}
