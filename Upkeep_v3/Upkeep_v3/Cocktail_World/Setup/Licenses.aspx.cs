using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Upkeep_v3.Cocktail_World.Setup
{


  

    public partial class Licenses : System.Web.UI.Page
    {

        CocktailWorld_Service.CocktailWorld_Service ObjCocktailWorld = new CocktailWorld_Service.CocktailWorld_Service();

        DataSet ds = new DataSet();
        string LoggedInUserID = string.Empty;
        int CompanyID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

          
          
                LoggedInUserID = Convert.ToString(Session["LoggedInUserID"]);
                CompanyID = Convert.ToInt32(Session["CompanyID"]);
                if (!IsPostBack)
                {
                    bindgrid();

                   
                }

        }



        public string bindgrid()
        {
            string data = "";
            try
            {
                ds = ds = ObjCocktailWorld.License( LoggedInUserID,24, "R");

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int count = Convert.ToInt32(ds.Tables[0].Rows.Count);

                        for (int i = 0; i < count; i++)
                        {
                            int License_ID = Convert.ToInt32(ds.Tables[0].Rows[i]["License_ID"]);
                            string License_Name = Convert.ToString(ds.Tables[0].Rows[i]["License_Name"]);
                            string License_No = Convert.ToString(ds.Tables[0].Rows[i]["License_No"]);
                           


                            data += "<tr><td>" + License_Name + "</td><td>" + License_No + "</td></tr>";

                        }
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data;
        }

    }
}