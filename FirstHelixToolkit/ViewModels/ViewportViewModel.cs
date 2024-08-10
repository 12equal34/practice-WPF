using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace FirstHelixToolkit.ViewModels
{
    class ViewportViewModel : ObservableObject
    {
        PerspectiveCamera? camera;
        public PerspectiveCamera? Camera
        {
            get => camera;
            set
            {
                camera = value;
                OnPropertyChanged();
            }
        }

        Visual3D? vobj;
        public Visual3D? Vobj
        {
            get => vobj;
            set
            {
                vobj = value;
                OnPropertyChanged();
            }
        }
	}
}
