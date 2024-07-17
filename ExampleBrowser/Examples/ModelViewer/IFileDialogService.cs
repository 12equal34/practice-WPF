using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelViewer
{
	public interface IFileDialogService
	{
		string OpenFileDialog(string initialDirectory, string defaultPath, string filter, string defaultExtension);
		string SaveFileDialog(string initialDirectory, string defaultPath, string filter, string defaultExtension);
	}
}
