using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Windows;
using System.Reflection;

namespace ProcessSample
{
    class MyProcess
    {

		#region file extension methods
		enum FileExtension
		{
			None, Exe, Uri
		}

		static FileExtension getExtensionFrom(string fileName)
		{
			FileExtension result = FileExtension.None;
			if (fileName.EndsWith(".exe"))
			{
				result = FileExtension.Exe;
			}
			else if (fileName.StartsWith("https://"))
			{
				result = FileExtension.Uri;
			}
			else
			{
				Debug.WriteLine(@"매개변수 fileName('{fileName}')이 파일 형식에 맞지 않습니다.");
			}
			return result;
		} 
		#endregion

		static public void TestProcess()
		{
			// 1. Assembly를 사용한 방법
			string assemblyPath = Assembly.GetExecutingAssembly().Location;
			Debug.WriteLine($"Assembly path: {assemblyPath}");

			// 2. AppDomain을 사용한 방법
			string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
			Debug.WriteLine($"Base directory: {baseDirectory}");

			// 3. Environment를 사용한 방법
			string currentDirectory = Environment.CurrentDirectory;
			Debug.WriteLine($"Current directory: {currentDirectory}");

			// 4. Process를 사용한 방법
			string? processPath = Environment.ProcessPath;
			if (processPath != null)
			{
				Debug.WriteLine($"Process path: {processPath ?? "null"}");
			}

			Process("https://www.google.com");
		}

		static public void Process(string fileName)
        {
			FileExtension extension = getExtensionFrom(fileName);
			if (extension == FileExtension.None)
			{
				Debug.WriteLine("주어진 fileName에 대해 프로세스를 실행하지 못했습니다.");
				return;
			}
			bool useShellExecute = (extension == FileExtension.Uri);
			bool bCreateNoWindow   = (extension == FileExtension.Exe);
			Process(fileName, useShellExecute, bCreateNoWindow);
		}

		static public void Process(string fileName, bool useShellExecute, bool bCreateNoWindow)
		{
			try
			{
				using (Process myProcess = new Process())
				{
					myProcess.StartInfo.FileName        = fileName;
					myProcess.StartInfo.UseShellExecute = useShellExecute;
					myProcess.StartInfo.CreateNoWindow  = bCreateNoWindow;
					myProcess.Start();
				}
			}
			catch (Exception e)
			{
				Debug.WriteLine(e.Message);
			}
		}
	}
}
