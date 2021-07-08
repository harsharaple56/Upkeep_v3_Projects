using System;
using System.Data;
using System.Windows.Forms;
using System.Data.Sql;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Win32;
using IWshRuntimeLibrary;
using System.Reflection;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace eFacilito_CW_Migration_Utility.Forms
{
    public partial class CW_Migrate_Setup : Form
    {
        
        public CW_Migrate_Setup()
        {
            InitializeComponent();
        }

        private void CW_Migrate_Setup_Load(object sender, EventArgs e)
        {
            Fetch_Server();
            loadingImage.Visible = false;
            lbl_ValidationStatus.Visible = false;
            Global.eFacilito_DB_Config = "server='www.compelapps.in',username='sa',password='SQL99!',Database='eFacilito_UAT'";
        }


        public void Fetch_Server()
        {
            DataTable instances = SqlDataSourceEnumerator.Instance.GetDataSources();
            foreach (DataRow row in instances.Rows)
            {
                string name = row["ServerName"].ToString();
                string slash = "\\";
                string InstanceName = string.Empty;
                string final = string.Empty;
                if (row["InstanceName"] != null && row["InstanceName"].ToString() != string.Empty)
                    InstanceName = string.Format(@"{0}", row["InstanceName"]);
                final = string.Concat(name, slash, InstanceName);
                this.ddl_cb_Server_Name.Items.Add(final);
            }
        }

        public List<string> GetDatabaseList()
        {
            List<string> list = new List<string>();
            string Username = txt_ServerUsername.Text;
            string Password = txt_ServerPassword.Text;
            string ServerName = Convert.ToString(ddl_cb_Server_Name.SelectedItem);

            // Open connection to the database
            string conString = "server="+ ServerName + ";uid=" + Username + ";pwd=" + Password + "; database=master";

            using (SqlConnection con = new SqlConnection(conString))
            {
                con.Open();

                // Set up a command with the given query and associate
                // this with the current connection.
                using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", con))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            //list.Add(dr[0].ToString()     );
                            ddl_cb_DatabaseList.Items.Add(dr[0]);
                        }
                    }
                }
            }
            return list;

        }

        private void btb_ConnectServer_Click(object sender, EventArgs e)
        {
            GetDatabaseList();
        }

        public void btn_Connect_CW_DB_Click(object sender, EventArgs e)
        {
            SetLoading(true);

            string Username = txt_ServerUsername.Text;
            string Password = txt_ServerPassword.Text;
            string ServerName = Convert.ToString(ddl_cb_Server_Name.SelectedItem);
            string Database = Convert.ToString(ddl_cb_DatabaseList.SelectedItem);

            // Open connection to the database
            Global.CW_DBConn_String = "server=" + ServerName + ";uid=" + Username + ";pwd=" + Password + "; database=" + Database ;
            
            var canAccessDB = false;
            SqlConnection conn = new SqlConnection(Global.CW_DBConn_String);

            try
            {
                conn.Open();
                
                canAccessDB = true; // Will only get here if Open() is successful
            }
            catch
            {
                // nothing needed here
            }
            finally
            {
                if (conn != null)
                    conn.Dispose(); // Safely clean up conn
            }

            if (!canAccessDB)
            {
                //label1.Visible = true;
                
                lbl_DBConnection_Status.Text = "CONNECTION FAILED";
                lbl_DBConnection_Status.BackColor = System.Drawing.Color.Red;
                lbl_DBConnection_Status.ForeColor = System.Drawing.Color.White;

                SetLoading(false);
            }
            else
            {
                //this.Hide();
                lbl_DBConnection_Status.Text = "SUCCESSFUL";
                lbl_DBConnection_Status.BackColor = System.Drawing.Color.GreenYellow;
                lbl_DBConnection_Status.ForeColor = System.Drawing.Color.Black;

                SetLoading(false);
            }


        }


        private void btn_ProceedMigration_Click(object sender, EventArgs e)
        {
            string DBConnection = lbl_DBConnection_Status.Text;
            string AccConnection = lbl_AccountConn_Status.Text;

            if (DBConnection.Equals("SUCCESSFUL") && AccConnection.Equals("SUCCESSFUL"))
            {
                Load_Import_Data impData = new Load_Import_Data();
                impData.Show();
                this.Hide();
            }
            else
            {
                lbl_ValidationStatus.Visible = true;
                lbl_ValidationStatus.Text = "Validations Failed. Please ensure the above note mentioned in RED is satisfied";
            }
        }

        private void btn_Connect_CWAccount_Click(object sender, EventArgs e)
        {
            string CW_CompanyCode = txt_CWAccount_CompanyCode.Text;
            string CW_Username = txt_CWAccount_Username.Text;
            string CW_Password = txt_CWAccount_Password.Text;

            Validate_CW_Account(CW_CompanyCode, CW_Username, CW_Password);
            

        }

        private void Validate_CW_Account(string Company_Code , string Username , string Password)
        {
            try
            {
                string sURL = "";
                string baseURL = "https://www.compelapps.in/efacilito_UAT_Api/api/CocktailWorld/Validate_CW_Account_Migration?";

                sURL = baseURL+ "StrCompanyCode=" + Company_Code + "&StrUsername=" + Username + "&StrPassword=" + Password;


                var client = new RestClient(sURL);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Content-Type", "application/json");

                request.AddParameter("application/json", sURL, ParameterType.QueryString);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);

                string json_response = response.Content.ToString();

                List<CW_API_Response> cw = JsonConvert.DeserializeObject<List<CW_API_Response>>(json_response);

                string StatusCode = cw[0].Status.ToString();
                Global.Company_ID = cw[0].Company_ID.ToString();

                if (StatusCode == "1")
                {
                    lbl_AccountConn_Status.Text = "SUCCESSFUL";
                    lbl_AccountConn_Status.BackColor = System.Drawing.Color.GreenYellow;
                    lbl_AccountConn_Status.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    lbl_AccountConn_Status.Text = "AUTHENTICATION FAILED";
                    lbl_AccountConn_Status.BackColor = System.Drawing.Color.Red;
                    lbl_AccountConn_Status.ForeColor = System.Drawing.Color.White;
                }
                
            }


            catch (Exception ex)
            {
                throw ex;
            }

            
        }

        
        private void SetLoading(bool displayLoader)
        {
            if (displayLoader)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    loadingImage.Visible = true;
                    this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                });
            }
            else
            {
                this.Invoke((MethodInvoker)delegate
                {
                    loadingImage.Visible = false;
                    this.Cursor = System.Windows.Forms.Cursors.Default;
                });
            }
        }
        private void txt_ServerPassword_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        
    }

    public class CW_API_Response
    {
        public int Status { get; set; }
        public int Company_ID { get; set; }
    }
    class Global
    {
        public static string CW_DBConn_String;
        public static string Company_ID;
        public static string eFacilito_DB_Config;
        
    }
}
