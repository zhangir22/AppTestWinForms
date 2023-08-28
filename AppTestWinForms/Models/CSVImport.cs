using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;

namespace AppTestWinForms.Models
{
    public class CSVImport
    {
        public DataTable NewDataTable(string fileName,string delimiters,bool firstRowContainsFieldName = true)
        {
            DataTable dt = new DataTable();
            using (TextFieldParser tfp = new TextFieldParser(fileName)) 
            {
                tfp.SetDelimiters(delimiters);
                if (!tfp.EndOfData)
                {
                    string[] fields = tfp.ReadFields();
                    for(int i = 0; i < fields.Count(); i++)
                    {
                        if (firstRowContainsFieldName)
                            dt.Columns.Add(fields[i]);
                        else
                            dt.Columns.Add("Col" + i);

                    }
                    if (!firstRowContainsFieldName)
                        dt.Rows.Add(tfp.ReadFields());
                }
                while (!tfp.EndOfData)
                    dt.Rows.Add(tfp.ReadFields());
            }
            return dt;

        }
    }
}
