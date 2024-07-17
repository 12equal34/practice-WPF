
using System.Windows;
using ExampleBrowser;
using Microsoft.Win32;

namespace ModelViewer
{
	[Example(null,"Model viewer.")]
	public partial class Window1 : Window
	{
		public Window1()
		{
			this.InitializeComponent();
			this.DataContext = new MainViewModel(new FileDialogService(), view1);
		}
	}
}
