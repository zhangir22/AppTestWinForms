using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppTestWinForms.Models;
using AppTestWinForms.Models.Context;
using Microsoft.WindowsAPICodePack.Dialogs;
namespace AppTestWinForms
{
    public partial class Form1 : Form
    {

        private Context db;
        private CSVImport csv;
        public Form1()
        {
            InitializeComponent();
            db = new Context()
            company_table.DataSource = db.company.ToList();

        }

        private void company_table_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Companies company = (Companies)company_table.CurrentRow.DataBoundItem;
            var data = from a in db.employees.ToList()
                       where a.company_id == company.id
                       select a;

            employee_table.DataSource = data.ToList();
        }

        private void import_to_table_Click(object sender, EventArgs e)
        {

            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok) 
            {
                csv = new CSVImport();
                csv.NewDataTable(dialog.FileName, ";");
            }

        }
    }
}
