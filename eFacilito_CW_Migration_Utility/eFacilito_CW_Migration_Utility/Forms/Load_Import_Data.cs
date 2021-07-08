using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eFacilito_CW_Migration_Utility.Forms
{
    public partial class Load_Import_Data : Form 
    {

        public Load_Import_Data()
        {
            InitializeComponent();
        }

        private void Load_Import_Data_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void BindGrid()
        {
            using (SqlConnection con = new SqlConnection(Global.CW_DBConn_String))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT [LicenseID],[LicenseDesc],[LicenseNo] FROM [Tbl_License]", con))
                {
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        using (DataTable dt = new DataTable())
                        {
                                sda.Fill(dt);
                                dgv_Licenses.DataSource = dt;
                        }
                    }
                }
            }
        }

        private void btn_ViewLicenseData_Click(object sender, EventArgs e)
        {
            string message = string.Empty;
            foreach (DataGridViewRow row in dgv_Licenses.Rows)
            {
                bool isSelected = Convert.ToBoolean(row.Cells["Select"].Value);
                if (isSelected)
                {
                    message += Environment.NewLine;
                    message += row.Cells["License_Name"].Value.ToString();
                }
            }

            MessageBox.Show("Selected Values" + message);
        }



    }

}
