using System.Diagnostics;
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
using System.Drawing;

namespace UdemyCourse
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			textBlock.Text = "Window의 생성자에서 텍스트가 바뀌었습니다.";

			TextBlock tb = new TextBlock();
			tb.Foreground = Brushes.Blue;
			tb.Text = "첫번째 텍스트 문장입니다.\n"; 
			tb.Inlines.Add("두번째 텍스트 문장입니다.\n");
			for (int i = 0; i < 5; ++i)
			{
				tb.Inlines.Add($"{i+3}번째 텍스트 문장입니다.\n");
			}
			tb.Inlines.Add(new Run("Run Text입니다.")
			{
				Foreground = Brushes.Brown,
				TextDecorations = TextDecorations.Underline
			});
			tb.Inlines.Add(new LineBreak());
			tb.Inlines.Add(new Bold(new Run("TextBlock")));
			tb.Inlines.Add(new Italic(new Run("TextBlock")));

			if (this.Content is StackPanel panel)
			{
				panel.Children.Add(tb);
			}
		}

		private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
		{
			System.Diagnostics.Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			ProcessSample.MyProcess.TestProcess();
		}
	}
}