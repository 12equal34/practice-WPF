using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MvvmCameraDemo
{
	public class BindingProxy : Freezable
	{
		// Using a DependencyProperty as the backing store for Data.  This enables animation, styling, binding, etc...
		public static DependencyProperty DataProperty = DependencyProperty.Register("Data", typeof(object), typeof(BindingProxy), new UIPropertyMetadata(null));
		public object Data 
		{
			get => GetValue(DataProperty);
			set => SetValue(DataProperty, value);
		}
		protected override Freezable CreateInstanceCore() => new BindingProxy();
	}
}
