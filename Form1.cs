using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrangeByExtension
{
	public partial class Form1 : Form
	{
		private string _selectedFolder = "";
		private List<string> _files = new List<string>();

		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			ArrangeByExtension();
		}

		private void ArrangeByExtension()
		{
			_files = Directory.GetFiles(_selectedFolder).ToList();
			foreach (var file in _files)
			{
				var ext = Path.GetExtension(file);
				if (ext != null)
				{
					var extWithoutDot = ext.Substring(1).ToUpper();
					var dir = Path.Combine(_selectedFolder, extWithoutDot);
					if (!Directory.Exists(dir))
					{
						Directory.CreateDirectory(dir);
					}
					var newPath = Path.Combine(dir, Path.GetFileName(file));
					File.Move(file, newPath);
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbd = new FolderBrowserDialog();
			DialogResult res = fbd.ShowDialog();

			_selectedFolder = fbd.SelectedPath;
			textBox1.Text = _selectedFolder;
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			_selectedFolder = textBox1.Text;
		}
	}
}
