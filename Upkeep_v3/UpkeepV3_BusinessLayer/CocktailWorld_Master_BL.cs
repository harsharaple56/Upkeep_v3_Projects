using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Reflection;
using System.Data;
namespace UpkeepV3_BusinessLayer
{
  public class CocktailWorld_Master_BL
    {


        DataSet ds = new DataSet();

        public DataSet Category_CRUD(int Company_ID, int Category_ID, string Category_Desc, string Category_Alias, string LoggedInUserID, string Action, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;

                SqlConnection con = new SqlConnection(StrConn);

                SqlCommand cmd = new SqlCommand("Anjali_CW_Mst_Category", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Company_ID",Company_ID);
                cmd.Parameters.AddWithValue("@Category_Id", Category_ID);
                cmd.Parameters.AddWithValue("@Category_Desc", Category_Desc);
                cmd.Parameters.AddWithValue("@Category_Alias", Category_Alias);
                cmd.Parameters.AddWithValue("@loginId", LoggedInUserID);
                cmd.Parameters.AddWithValue("@Action", Action);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet FetchCategory_SizeLinkup(int Category_ID,string StrConn)
        {
            try
            {
                string strOutput = string.Empty;

                SqlConnection con = new SqlConnection(StrConn);

                SqlCommand cmd = new SqlCommand("Spr_Fetch_CategorySizeLinkUP", con);
                cmd.CommandType = CommandType.StoredProcedure;             
                cmd.Parameters.AddWithValue("@Category_Id", Category_ID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
          public DataSet BrandMaster_CRUD(int Company_ID,int Brand_ID, int Category_ID, int SubCategory_ID, string Brand_Desc, int Strength, int Purchase_Rate_Peg, int Selling_Rate_Peg, int Selling_Rate_Bottle, int Is_Disabled, string LoggedInUserID, string Action,string StrConn)
          {
                try
                {
                    string strOutput = string.Empty;

                    SqlConnection con = new SqlConnection(StrConn);
                    SqlCommand cmd = new SqlCommand("Spr_CRUD_CW_CocktailWorld_Brand", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CompanyID", Company_ID);
                    cmd.Parameters.AddWithValue("@Brand_ID", Brand_ID);
                    cmd.Parameters.AddWithValue("@Category_ID", Category_ID);
                    cmd.Parameters.AddWithValue("@SubCategory_ID", SubCategory_ID);
                    cmd.Parameters.AddWithValue("@Brand_Desc", Brand_Desc);
                    cmd.Parameters.AddWithValue("@Strength", Strength);
                    cmd.Parameters.AddWithValue("@Purchase_Rate_Peg", Purchase_Rate_Peg);
                    cmd.Parameters.AddWithValue("@Selling_Rate_Peg", Selling_Rate_Peg);
                    cmd.Parameters.AddWithValue("@Selling_Rate_Bottle", Selling_Rate_Bottle);
                    cmd.Parameters.AddWithValue("@Is_Disabled", Is_Disabled);
                    cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                    cmd.Parameters.AddWithValue("@Action", Action);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                     da.Fill(ds);
                     return ds;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

          }

        public DataSet SizeMaster_CRUD(int Size_ID, string Size_Desc, int Size_Alias, string LoggedInUserID, int Company_ID, string Action, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;

                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_CRUD_CW_CocktailWorld_Size", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Size_ID", Size_ID);
                cmd.Parameters.AddWithValue("@Size_Desc", Size_Desc);
                cmd.Parameters.AddWithValue("@Size", Size_Alias);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@CompanyID", Company_ID);
                cmd.Parameters.AddWithValue("@Action", Action);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet SubCategory_CRUD(int SubCategory_ID, int Category_ID, string SubCategory_Desc, string LoggedInUserID,int Company_ID, string Action, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;

                SqlConnection con = new SqlConnection(StrConn);

                SqlCommand cmd = new SqlCommand("Spr_CRUD_CW_CocktailWorld_SubCategory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SubCategory_ID", SubCategory_ID);
                cmd.Parameters.AddWithValue("@Category_ID", Category_ID);
                cmd.Parameters.AddWithValue("@SubCategory_Desc", SubCategory_Desc);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@CompanyID", Company_ID);
                cmd.Parameters.AddWithValue("@Action", Action);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet PermitMaster_CRUD(int Permit_ID, string Permit_Desc, string LoggedInUserID, int Company_ID, string Action, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;

                SqlConnection con = new SqlConnection(StrConn);

                SqlCommand cmd = new SqlCommand("Spr_CRUD_CW_CocktailWorld_Permit", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Permit_ID", Permit_ID);
                cmd.Parameters.AddWithValue("@Permit_Desc", Permit_Desc);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@CompanyID", Company_ID);
                cmd.Parameters.AddWithValue("@Action", Action);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
