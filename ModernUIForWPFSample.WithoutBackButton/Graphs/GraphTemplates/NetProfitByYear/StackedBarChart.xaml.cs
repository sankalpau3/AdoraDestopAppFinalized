﻿using ModernUIForWPFSample.WithoutBackButton.Graphs.ViewModels;
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

namespace ModernUIForWPFSample.WithoutBackButton.Graphs.GraphTemplates
{
    /// <summary>
    /// Interaction logic for StackedBarChart.xaml
    /// </summary>
    public partial class StackedBarChart4 : Page
    {
        public StackedBarChart4()
        {
            InitializeComponent();
            DataContext = new ChartViewModel("NetProfitByYear");
        }
    }
}
