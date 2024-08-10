using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HelixToolkit.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace FirstHelixToolkit.ViewModels
{
	internal class MainWindowViewModel : ObservableObject
	{
		public string Title { get; } = "연습";

		public ViewportViewModel Viewport1 { get; }
		public ViewportViewModel Viewport2 { get; }

		public MainWindowViewModel()
		{
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

			this.Viewport1.Vobj = new SphereVisual3D();
			this.Viewport2.Vobj = new BoxVisual3D();
		}
	}
}
