using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmCameraDemo
{
	using System.Windows.Media.Media3D;

	public class ViewportViewModel : Observable
	{
		PerspectiveCamera camera;
		public PerspectiveCamera Camera
		{
			get => this.camera;
			set
			{
				this.camera = value;
				this.OnPropertyChanged();
			}
		}
	}
}
