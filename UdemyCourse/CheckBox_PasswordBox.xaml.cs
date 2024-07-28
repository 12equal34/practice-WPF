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
using System.Windows.Shapes;

namespace UdemyCourse
{
	/// <summary>
	/// Interaction logic for CheckBox_PasswordBox.xaml
	/// </summary>
	public partial class CheckBox_PasswordBox : Window
	{
		public CheckBox_PasswordBox()
		{
			InitializeComponent();

		}

		private void cbAllSelect_CheckedChanged(object sender, RoutedEventArgs e)
		{
			bool bCheckAll = (cbAllSelect.IsChecked == true);
			foreach (var child in spToppingCheckBoxes.Children)
			{
				if (child is CheckBox cb)
				{
					cb.IsChecked = bCheckAll;
				}
			}
		}

		private void topping_CheckedChanged(object sender, RoutedEventArgs e)
		{
			int totalCount = spToppingCheckBoxes.Children.Count;
			int selectCount = 0;
			foreach (var child in spToppingCheckBoxes.Children)
				if (child is CheckBox cb && (cb.IsChecked ?? false))
					selectCount++;

			cbAllSelect.IsChecked = (selectCount == totalCount ? true : (selectCount == 0 ? false : null));
		}
	}
}
