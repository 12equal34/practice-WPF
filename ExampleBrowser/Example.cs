using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ExampleBrowser
{
	public class Example
	{
		public string Title { get; private set; }
		public string Description { get; set; }
		private Type MainWindowType { get; set; }
		public ImageSource Thumbnail { get; set; }
		public string ThumbnailFileName
		{
			get
			{
				return this.MainWindowType.Namespace + "_small.png";
			}
		}

		public Example(Type mainWindowType, string title = null, string description = null)
		{
			this.MainWindowType = mainWindowType;
			this.Title = title ?? mainWindowType.Namespace;
			this.Description = description;
			try
			{
				this.Thumbnail =
					new BitmapImage(new Uri("pack://application:,,,/Images/" + this.ThumbnailFileName));
			}
			catch (Exception e)
			{
				MessageBox.Show($"이미지를 로드할 수 없습니다: {e.Message}");
				Debug.WriteLine(e);
			}
		}

		public override string ToString()
		{
			return this.Title;
		}

		public Window Create()
		{
			return Activator.CreateInstance(this.MainWindowType) as Window;
		}
	}
}
