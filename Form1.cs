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

namespace FileCompareTool
{
    public partial class Form1 : Form
    {
        private string[] commandLineArgs;
        string workingDirectory;
        public List<string> differences;
        DifferenceListForm differenceListForm = new DifferenceListForm();

        public Form1(string[] Args)
        {
            commandLineArgs = Args;
            InitializeComponent();
        }

        private void LoadExcel(DataGridView view, string filepath)
        {
            ExcelFile efile = new ExcelFile(filepath);
            string[,] filedata = efile.GetExcelFile(filepath);
            view.ColumnCount = 17;
            for (int i = 0; i < 17; i++)
            {
                view.Columns[i].Name = "a";
            }
            for (int i = 0; i < 2339; i++)
            {
                view.Rows.Add(ExcelFile.GetRow(filedata, i));

            }
        }

        private void CompareExcelFiles()
        {
            if ((dataGridView1.RowCount != 0) && (dataGridView2.RowCount != 0) && (dataGridView1.RowCount == dataGridView2.RowCount))
            {
                differences.Clear();
                for (int row = 0; row < dataGridView1.RowCount - 1; row++)
                {
                    for (int column = 0; column < 17; column++)
                    {
                        try
                        {
                            if (dataGridView1.Rows[row].Cells[column].Value.ToString() != dataGridView2.Rows[row].Cells[column].Value.ToString())
                            {
                                dataGridView1.Rows[row].Cells[column].Style.BackColor = Color.Red;
                                dataGridView2.Rows[row].Cells[column].Style.BackColor = Color.Red;
                                differences.Add("Row: " + row + "   Column: " + column + "   Left: " + dataGridView1.Rows[row].Cells[column].Value.ToString() + "   Right: " + dataGridView2.Rows[row].Cells[column].Value.ToString());
                                Console.WriteLine("'" + dataGridView1.Rows[row].Cells[column].Value + "'    '" + dataGridView2.Rows[row].Cells[column].Value + "'");
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                        
                    }
                }
            }
        }

        private void HandleCommandLine()
        {
            if (commandLineArgs.Length > 1) // Will be 0 from icon or 1 from cmd line w/ no args
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            differenceListForm.Owner = this;
            workingDirectory = Directory.GetCurrentDirectory();
            workingDirectory = workingDirectory.Replace("bin\\Release", "");

            differences = new List<string>();
            //LoadExcel(dataGridView1, workingDirectory + "\\AlarmList.xlsx");
            //LoadExcel(dataGridView2, workingDirectory + "\\AlarmList2.xlsx");

            HandleCommandLine();

        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            var width = (ClientRectangle.Width / 2) - 50;
            dataGridView1.Left = 0;
            dataGridView1.Width = width;
            dataGridView2.Left = width + panel1.Width + 20;
            dataGridView2.Width = width;
            panel1.Left = dataGridView1.Width+10;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Add cleanup code that might be needed
            Application.Exit();
        }

        private void CompareButton_Click(object sender, EventArgs e)
        {
            CompareExcelFiles();
            if (differenceListForm != null) differenceListForm.Notify(this);
        }

        private string FileDialogHandler()
        {
            string filepath = "";
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "C# Corner Open File Dialog";
            fdlg.InitialDirectory = workingDirectory;
            fdlg.Filter = "All files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            fdlg.FilterIndex = 1;
            fdlg.RestoreDirectory = true;

            if (fdlg.ShowDialog() == DialogResult.OK) filepath = fdlg.FileName;

            return filepath;
        }

        private void OpenLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filepath = FileDialogHandler();
            if (filepath != "")
            {
                LoadExcel(dataGridView1, filepath);
            }
        }

        private void OpenRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filepath = FileDialogHandler();
            if (filepath != "")
            {
                LoadExcel(dataGridView2, filepath);
            }
        }

        private void CompareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompareExcelFiles();
            if (differenceListForm != null) differenceListForm.Notify(this);
        }

        private void DifferenceListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (differenceListForm == null)
            {
                differenceListForm = new DifferenceListForm();
            }
            differenceListForm.Show(this); // if you need non-modal window
        }
    }
}
