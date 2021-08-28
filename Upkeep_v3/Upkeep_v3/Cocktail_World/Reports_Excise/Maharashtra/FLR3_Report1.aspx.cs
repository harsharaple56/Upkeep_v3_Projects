﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;

namespace Upkeep_v3.Cocktail_World.Reports_Excise.Maharashtra
{
    public partial class FLR3_Report1 : System.Web.UI.Page
    {
        CocktailWorld_Service.CocktailWorld_Service ObjCocktailWorld = new CocktailWorld_Service.CocktailWorld_Service();

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                DataSet dsReport = new DataSet();
                dsReport = ObjCocktailWorld.Fetch_Test_Dataset_RDLC();

                if (dsReport != null)
                {
                    if (dsReport.Tables.Count > 0)
                    {
                        if (dsReport.Tables[0].Rows.Count > 0)
                        {
                            ReportViewer1.ProcessingMode = ProcessingMode.Local;
                            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Cocktail_World/Reports_Excise/RDLC_Files/Flr3ReportWizard.rdlc");

                            ReportDataSource datasource0 = new ReportDataSource("Flr3DatasetReportWizard", dsReport.Tables[0]);
                            ReportDataSource datasource1 = new ReportDataSource("DataSet1", dsReport.Tables[1]);

                            ReportViewer1.LocalReport.DataSources.Clear();
                            ReportViewer1.LocalReport.EnableHyperlinks = true;
                            ReportViewer1.LocalReport.DataSources.Add(datasource0);
                            ReportViewer1.LocalReport.DataSources.Add(datasource1);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}