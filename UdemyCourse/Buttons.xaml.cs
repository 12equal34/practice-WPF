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
	/// Interaction logic for Buttons.xaml
	/// </summary>
	public partial class Buttons : Window
	{
		readonly double minFontSize = 10;
		readonly double maxFontSize = 20;
		double fontSizeStep = 2;

		readonly Brush[] Palette = [Brushes.Blue, Brushes.Red, Brushes.Aqua, Brushes.Brown];

		public Buttons()
		{
			InitializeComponent();

			myLabel.Foreground = Palette[0];
			myButton.Foreground = Palette[2];

			Debug.Assert(myLabel.FontSize >= minFontSize && myLabel.FontSize <= maxFontSize);
		}

		private void myButton_Click(object sender, RoutedEventArgs e)
		{
			if (myLabel.Foreground == Palette[0])      myLabel.Foreground = Palette[1];
			else if (myLabel.Foreground == Palette[1]) myLabel.Foreground = Palette[0];

			myLabel.FontSize += fontSizeStep;

			if (myLabel.FontSize < minFontSize || myLabel.FontSize > maxFontSize) 
				fontSizeStep *= -1;
        }

		private void myButton_MouseEnter(object sender, MouseEventArgs e)
		{
			this.myButton.Foreground = Palette[3];
		}

		private void myButton_MouseLeave(object sender, MouseEventArgs e)
		{
			this.myButton.Foreground = Palette[2];
		}

		private void rbImage_Checked(object sender, RoutedEventArgs e)
		{
			if (sender is RadioButton rb)
			{
				toggleRadioButtonBackground(rb);
			}
		}

		private void rbImage_Unchecked(object sender, RoutedEventArgs e)
		{
			if (sender is RadioButton rb)
			{
				toggleRadioButtonBackground(rb);
			}
		}

		void toggleRadioButtonBackground(RadioButton rb)
		{
			Brush checkedBrush   = Brushes.Beige;
			Brush uncheckedBrush = Brushes.Transparent;

			if (rb.Content is WrapPanel wp)
			{
				foreach (var child in wp.Children)
				{
					if (child is Label lb)
					{
						lb.Background = (rb.IsChecked ?? false) ? checkedBrush : uncheckedBrush;
					}
				}
			}
		}
	}
}
