﻿using System;
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

namespace Session12
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Свойства

        #region Статические свойства

        public static MainWindow Instance { get; set; }

        #endregion

        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }

        #region Обработчики
        private void ButtonClickExit(object sender, RoutedEventArgs e) => Close();

        private void OpenMainList(object sender, RoutedEventArgs e)
        {

        }

        private void OpenProductList(object sender, RoutedEventArgs e) => MainFrame.Navigate(new Pages.ProductsListPage());

        private void OpenPostavchikList(object sender, RoutedEventArgs e)
        {

        }

        private void OpenOrdersList(object sender, RoutedEventArgs e)
        {

        }

        private void OpenGoinYourHouseList(object sender, RoutedEventArgs e)
        {

        }
        #endregion

    }
}
