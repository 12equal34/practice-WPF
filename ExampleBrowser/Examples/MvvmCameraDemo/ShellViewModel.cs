using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Media3D;
using HelixToolkit.Wpf;

namespace MvvmCameraDemo
{
	public class ShellViewModel : Observable
	{
		public string Title
		{
			get => title;
			set
			{
				title = value;
				OnPropertyChanged();
			}
		}
		private string title;

		public ViewportViewModel Viewport1 { get; set; }
		public ViewportViewModel Viewport2 { get; set; }

		public ShellViewModel()
		{
			this.Title = "MvvmCameraDemo";
			this.Viewport1 = new ViewportViewModel();
			this.Viewport2 = new ViewportViewModel();
			var camera = new PerspectiveCamera()
			{
				Position = new Point3D(0, -10, 0),
				LookDirection = new Vector3D(0, 10, 0),
				UpDirection = new Vector3D(0, 0, 1),
				FieldOfView = 60,
			};

			this.Viewport1.Camera = camera;
			this.Viewport2.Camera = camera;
		}
	}
}
