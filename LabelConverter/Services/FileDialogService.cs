using Ookii.Dialogs.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabelConverter.Services
{
	public class FileDialogService
	{
		public static string SelectFolder ()
		{
			using (var dialog = new VistaFolderBrowserDialog ())
			{
				return dialog.ShowDialog () == DialogResult.OK
					? dialog.SelectedPath
					: null;
			}
		}

		public static string OpenJsonFile()
		{
			using (var dialog = new OpenFileDialog
			{
				Filter = "Json Files (*.json)|*.json"
			})
			{
				return dialog.ShowDialog () == DialogResult.OK
					? dialog.FileName
					: null;
			}
		}

		public static string SaveJsonFile()
		{
			using (var dialog = new SaveFileDialog
			{
				Filter = "Json Files (*.json)|*.json"
			})
			{
				return dialog.ShowDialog () == DialogResult.OK
					? dialog.FileName
					: null;
			}
		}
	}
}
