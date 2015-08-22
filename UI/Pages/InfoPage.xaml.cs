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
using DiskMagic.DetectionLibrary;

namespace DiskMagic.UI
{
    /// <summary>
    /// InfoPage.xaml 的交互逻辑
    /// </summary>
    public partial class InfoPage : Page
    {
        public InfoPage()
        {
            InitializeComponent();
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var benchmark = new BenchmarkPage(model.CurrentPartitionInfo);
            NavigationService.Navigate(benchmark);
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (model.CurrentPartitionInfo != null)
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }

        private void list_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var value = e.NewValue is PartitionInfo ? (PartitionInfo)e.NewValue : null;
            model.CurrentPartitionInfo = value;
        }
    }
}
