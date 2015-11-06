using ModernUIForWPFSample.WithoutBackButton.Functions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ModernUIForWPFSample.WithoutBackButton
{
	/// <summary>
	/// Interaction logic for firstOpen.xaml
	/// </summary>
	public partial class firstOpen : UserControl
	{
		public firstOpen()
		{
			this.InitializeComponent();
		}

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            nameLabel.Content = new LoginDetails().getUser();
            descriptionLabel.Content = new LoginDetails().showUserText();
        }
	}
}