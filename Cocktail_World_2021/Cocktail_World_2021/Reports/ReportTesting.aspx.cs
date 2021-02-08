using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Services;
using System.Collections;
using System.IO;
using System.Data.OleDb;
using System.Text;
using Microsoft.Reporting.WebForms;


namespace Cocktail_World_2021.Reports
{
    public partial class ReportTesting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            bindgrid();

        }

        public void bindgrid()
        {
            DataTable dt = new DataTable();
           // string StrConn = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString.ToString();
           // using (SqlConnection con = new SqlConnection(StrConn))
            //{
              //  SqlCommand sqlComm = new SqlCommand("", con);




            //    sqlComm.CommandType = CommandType.StoredProcedure;

            //    SqlDataAdapter da = new SqlDataAdapter();
            //    da.SelectCommand = sqlComm;
            //    da.Fill(dt);

            //}
            //if (dt.Rows.Count > 0)
            //{
            //    UpdatePrintFlag(userlist);
            //}
            //DataSet ds = new DataSet();
            //ds.Tables["tbl1"].Merge(dt);

           ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Rdlc/Report1.rdlc");
            //ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Rdlc/Flr3AReport.rdlc");
            // ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/ReportCerticate01.rdlc");
            //ReportDataSource datasource = new ReportDataSource("DataSet1", dt);
            ReportViewer1.LocalReport.DataSources.Clear();
           // ReportViewer1.LocalReport.DataSources.Add(datasource);

            //Warning[] warnings;
        //    string[] streamIds;
        //    string contentType;
        //    string encoding;
        //    string extension;

        //    //Export the RDLC Report to Byte Array.
        ////    byte[] bytes = ReportViewer1.LocalReport.Render("PDF", null, out contentType, out encoding, out extension, out streamIds, out warnings);

        //    // Open generated PDF.
        //    Response.Clear();
        //    Response.Buffer = true;
        //    Response.Charset = "";
        //    Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //    Response.ContentType = contentType;
        //    Response.BinaryWrite(bytes);
        //    Response.Flush();
        //    Response.End();


        }

    }
}