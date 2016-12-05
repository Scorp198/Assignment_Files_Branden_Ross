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

namespace FileAssignment
{
    public partial class InputForm : Form
    {
        private StreamReader employeeStreamReader;
        private StreamWriter employeeStreamWriter;
        private String employeeData;

        public InputForm()
        {
            InitializeComponent();
        }

        private void InputForm_Load(object sender, EventArgs e)
        {
            //shows a open file dialog and prompts the user to select a file
            DialogResult response;

            //closing the file if already open
            if (employeeStreamReader != null)
                employeeStreamReader.Close();

            //set some properties of the file open dialog
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            openFileDialog1.FileName = "Employees.txt";
            openFileDialog1.Title = "Select File or Directory";
            openFileDialog1.Filter = "Text Files(*.txt)|*.txt|All files(*.*)|*.*";
            //show the open file dialog
            response = openFileDialog1.ShowDialog();

            //check the response
            if (response != DialogResult.Cancel)
            {
                try
                {
                    employeeStreamReader = new StreamReader(openFileDialog1.FileName);

                    while (employeeStreamReader.Peek() != -1)
                    {
                        employeeData = employeeData + employeeStreamReader.ReadLine() + "\n";
                    }
                }
                catch (FileNotFoundException ex1)
                {
                    MessageBox.Show("File does not exist", "File Opening Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (IOException ex2)
                {
                    MessageBox.Show(ex2.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (employeeStreamReader != null)
                           employeeStreamReader.Close();
                }
            }
        }//End of InputForm_Load

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }//End of btnExit_Click

        private void btnSave_Click(object sender, EventArgs e)
        {
            String employeeName = txtEmployeeName.Text;
            String employeeNumber = txtEmployeeNumber.Text;
            String employeeHoursWorked = txtHoursWorked.Text;

            if (employeeStreamWriter != null)
                employeeStreamWriter.Close();

            //set properties and show the save file dialog 
            saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            saveFileDialog1.FileName = "Employees";
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Title = "Save File";
            saveFileDialog1.Filter = "Text Files(*.txt)|*.txt|All files(*.*)|*.*";

            DialogResult response = saveFileDialog1.ShowDialog();

            if (response != DialogResult.Cancel)
            {
                try
                {
                    
                    employeeData = employeeData + employeeName + employeeNumber + employeeHoursWorked;
                    employeeData = employeeData + "\n";

                    employeeStreamWriter = new StreamWriter(saveFileDialog1.FileName);
                    //write the contents of the coffee list to the file
                    employeeStreamWriter.WriteLine(employeeData);
                    //all changes saved

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "File Creation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                finally
                {
                    if (employeeStreamWriter != null)
                        employeeStreamWriter.Close();
                }
            }
            else
            {
                MessageBox.Show("No Changes to Save",
                    "Save Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }//End of btnSave_Click

        private void btnDone_Click(object sender, EventArgs e)
        {
            this.Hide();

            //displays the information about an employee
            OutputForm output = new OutputForm();
            output.ShowDialog();
        }//End of btnDone_Click

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEmployeeName.Clear();
            txtEmployeeNumber.Clear();
            txtHoursWorked.Clear();
            txtEmployeeName.Focus();
        }//End of btnClear_Click
    }//End of Class
}//End of Namespace
