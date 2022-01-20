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

        public DataSet SaleDetailsMaster_Crud(int Sale_ID, int SaleDetail_ID, string Brand_Desc, string Size_Desc, string Cocktail_Desc, int Opening_ID, string TaxType, decimal Bottle_Qty, decimal Bottle_Rate, decimal SPeg_Qty, decimal SPeg_Rate, decimal LPeg_Qty, decimal LPeg_Rate, decimal TaxAmount, decimal Amount, int Permit_Holder, int License_ID, string Action, int LoggedInUser, int Company_ID, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;

                SqlConnection con = new SqlConnection(StrConn);

                SqlCommand cmd = new SqlCommand("Spr_CRUD_CW_CocktailWorld_SaleDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Sale_ID", Sale_ID);
                cmd.Parameters.AddWithValue("@SaleDetail_ID", SaleDetail_ID);
                cmd.Parameters.AddWithValue("@Brand_Desc", Brand_Desc);
                cmd.Parameters.AddWithValue("@Size_Desc", Size_Desc);
                cmd.Parameters.AddWithValue("@Cocktail_Desc", Cocktail_Desc);
                cmd.Parameters.AddWithValue("@Opening_ID", Opening_ID);
                cmd.Parameters.AddWithValue("@TaxType", TaxType);
                cmd.Parameters.AddWithValue("@Bottle_Qty", Bottle_Qty);
                cmd.Parameters.AddWithValue("@Bottle_Rate", Bottle_Rate);
                cmd.Parameters.AddWithValue("@SPeg_Qty", SPeg_Qty);
                cmd.Parameters.AddWithValue("@SPeg_Rate", SPeg_Rate);
                cmd.Parameters.AddWithValue("@LPeg_Qty", LPeg_Qty);
                cmd.Parameters.AddWithValue("@LPeg_Rate", LPeg_Rate);
                cmd.Parameters.AddWithValue("@TaxAmount", TaxAmount);
                cmd.Parameters.AddWithValue("@Amount", Amount);
                cmd.Parameters.AddWithValue("@Permit_Holder", Permit_Holder);
                cmd.Parameters.AddWithValue("@License_ID", License_ID);
                cmd.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
                cmd.Parameters.AddWithValue("@Company_ID", Company_ID);
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



        public DataSet BrandOpeningMaster_CRUD(int BrandOpening_ID, string CategoryDetails, int BrandID, decimal closingBottle, decimal closingSpeg, int Company_ID, string LoggedInUser, string Action, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;

                SqlConnection con = new SqlConnection(StrConn);

                SqlCommand cmd = new SqlCommand("Spr_CRUD_CW_CocktailWorld_BrandOpening", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BrandOpening_ID", BrandOpening_ID);
                cmd.Parameters.AddWithValue("@CategoryDetails", CategoryDetails);
                cmd.Parameters.AddWithValue("@closingBottle", closingBottle);
                cmd.Parameters.AddWithValue("@closingSpeg", closingSpeg);
                cmd.Parameters.AddWithValue("@BrandID", BrandID);
                cmd.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
                cmd.Parameters.AddWithValue("@Company_ID", Company_ID);
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

        public DataSet SaleMaster_Crud(int Sale_ID, string Date, string Bill_No, int License, string Action, int LoggedInUser, int Company_ID, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;

                SqlConnection con = new SqlConnection(StrConn);

                SqlCommand cmd = new SqlCommand("Spr_CRUD_CW_CocktailWorld_Sale", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Date", Date);
                cmd.Parameters.AddWithValue("@Bill_No", Bill_No);
                cmd.Parameters.AddWithValue("@License", License);
                cmd.Parameters.AddWithValue("@LoggedInUser", LoggedInUser);
                cmd.Parameters.AddWithValue("@Company_ID", Company_ID);
                cmd.Parameters.AddWithValue("@Action", Action);
                cmd.Parameters.AddWithValue("@SaleID", Sale_ID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet FetchTaxDetails(int Brand_ID, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;

                SqlConnection con = new SqlConnection(StrConn);

                SqlCommand cmd = new SqlCommand("Spr_Fetch_Category_Tax", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Brand_ID", Brand_ID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet CategoryMaster_CRUD(int Company_ID, int Category_ID, string Category_Desc, string Category_Alias, string LoggedInUserID, string Action, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;

                SqlConnection con = new SqlConnection(StrConn);

                SqlCommand cmd = new SqlCommand("Spr_CRUD_CW_CocktailWorld_Category", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Company_ID",Company_ID);
                cmd.Parameters.AddWithValue("@Category_Id", Category_ID);
                cmd.Parameters.AddWithValue("@Category_Desc", Category_Desc);
                cmd.Parameters.AddWithValue("@Category_Alias", Category_Alias);
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

        public DataSet Fetch_Category_Brand(int CompanyID, int CategoryID, String StrConn) //Added CompanyId by sujata
        {
            try
            {
                string strOutput = string.Empty;
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Fetch_Category_Brand", con);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.Parameters.AddWithValue("@CategoryID", CategoryID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public DataSet Fetch_Brand_Opening(int Cat_Size_ID, int Opening_ID, int BrandID, string Brand_Desc, string Cocktail_Desc, int CompanyID, String StrConn) //Added CompanyId by sujata
        {
            try
            {
                string strOutput = string.Empty;
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_Fetch_Brand_Opening", con);
                cmd.Parameters.AddWithValue("@Cat_Size_ID", Cat_Size_ID);
                cmd.Parameters.AddWithValue("@BrandID", BrandID);
                cmd.Parameters.AddWithValue("@Opening_ID", Opening_ID);
                cmd.Parameters.AddWithValue("@Brand_Desc", Brand_Desc);
                cmd.Parameters.AddWithValue("@Cocktail_Desc", Cocktail_Desc);
                cmd.Parameters.AddWithValue("@CompanyID", CompanyID);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public DataSet FetchBrand_SizeLinkup(int Category_ID,int Brand_ID, int Size_ID, string Brand_Desc, string Size_Desc, int Company_ID, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;

                SqlConnection con = new SqlConnection(StrConn);

                SqlCommand cmd = new SqlCommand("Spr_Fetch_BrandSizeLinkUP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Category_Id", Category_ID);
                cmd.Parameters.AddWithValue("@Brand_ID", Brand_ID);
                cmd.Parameters.AddWithValue("@Size_ID", Size_ID);
                cmd.Parameters.AddWithValue("@Brand_Desc", Brand_Desc);
                cmd.Parameters.AddWithValue("@Size_Desc", Size_Desc);
                cmd.Parameters.AddWithValue("@Company_ID", Company_ID);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet FetchCategory_SizeLinkup(int Category_ID, string StrConn)
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
        public DataSet BrandMaster_CRUD(int Company_ID,int Brand_ID, int Category_ID, int SubCategory_ID, string Brand_Desc,string Brand_Short_Name, int Strength, int Purchase_Rate_Peg, int Selling_Rate_Peg, int Selling_Rate_Bottle, int Is_Disabled, string LoggedInUserID, string Action,string StrConn)
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
                cmd.Parameters.AddWithValue("@Brand_Short_Name", Brand_Short_Name);
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

        public DataSet PurchaseMaster_CRUD(int Purchase_ID,int Supplier_ID, string TP_No, string Invoice_No, string Purchase_Date, decimal Other_Charges, 
            decimal Discount_Percentage, int License_ID,int Company_ID ,string LoggedInUserID, string Action, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;

                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_CRUD_CW_CocktailWorld_Purchase", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Purchase_ID", Purchase_ID);
                cmd.Parameters.AddWithValue("@Supplier_ID", Supplier_ID);
                cmd.Parameters.AddWithValue("@TP_No", TP_No);
                cmd.Parameters.AddWithValue("@Invoice_No", Invoice_No);
                cmd.Parameters.AddWithValue("@Purchase_Date", Purchase_Date);
                cmd.Parameters.AddWithValue("@Other_Charges", Other_Charges);
                cmd.Parameters.AddWithValue("@Discount_Percentage", Discount_Percentage);
                cmd.Parameters.AddWithValue("@License_ID", License_ID);
                cmd.Parameters.AddWithValue("@CompanyID", Company_ID);
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

        public DataSet TransferMaster_CRUD(int Transfer_ID,string TransferDate, string TP_No, string Invoice_No, string FL_IV, string Is_Show_Excise,
            int Trasnfer_To_LicenseID, int License_ID, string LoggedInUserID, int Company_ID, string Action, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;

                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_CRUD_CW_CocktailWorld_Transfer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Transfer_ID", Transfer_ID);
                cmd.Parameters.AddWithValue("@TransferDate", TransferDate);
                cmd.Parameters.AddWithValue("@TP_No", TP_No);
                cmd.Parameters.AddWithValue("@Invoice_No", Invoice_No);
                cmd.Parameters.AddWithValue("@FL_IV", FL_IV);
                cmd.Parameters.AddWithValue("@Is_Show_Excise", Is_Show_Excise);
                cmd.Parameters.AddWithValue("@Trasnfer_To_LicenseID", Trasnfer_To_LicenseID);
                cmd.Parameters.AddWithValue("@License_ID", License_ID);
                cmd.Parameters.AddWithValue("@CompanyID", Company_ID);
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

        public DataSet PurchaseDetailsMaster_CRUD(int Purchase_ID, int Brand_Opening_ID,string Brand_Desc,string Size_Desc,decimal Bottle_Qty, decimal Bottle_Rate
            ,decimal Speg_Qty, decimal Speg_Rate, int Free_Qty, int No_Of_Boxes, int Batch_No,string Mfg,string Tax_Type,decimal Tax_Amt,decimal Total_Amt
            ,int License_ID,int Company_ID, string LoggedInUserID, string Action, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_CRUD_CW_CocktailWorld_PurchaseDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Purchase_ID", Purchase_ID);
                cmd.Parameters.AddWithValue("@Brand_Opening_ID", Brand_Opening_ID);
                cmd.Parameters.AddWithValue("@Brand_Desc", Brand_Desc);
                cmd.Parameters.AddWithValue("@Size_Desc", Size_Desc);
                cmd.Parameters.AddWithValue("@Bottle_Qty", Bottle_Qty);
                cmd.Parameters.AddWithValue("@Bottle_Rate", Bottle_Rate);
                cmd.Parameters.AddWithValue("@Speg_Qty", Speg_Qty);
                cmd.Parameters.AddWithValue("@Speg_Rate", Speg_Rate);
                cmd.Parameters.AddWithValue("@Free_Qty", Free_Qty);
                cmd.Parameters.AddWithValue("@No_Of_Boxes", No_Of_Boxes);
                cmd.Parameters.AddWithValue("@Batch_No", Batch_No);
                cmd.Parameters.AddWithValue("@Mfg", Mfg);
                cmd.Parameters.AddWithValue("@Tax_Type", Tax_Type);
                cmd.Parameters.AddWithValue("@Tax_Amt", Tax_Amt);
                cmd.Parameters.AddWithValue("@Total_Amt", Total_Amt);
                cmd.Parameters.AddWithValue("@License_ID", License_ID);
                cmd.Parameters.AddWithValue("@Company_ID", Company_ID);
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

        public DataSet TransferDetailsMaster_CRUD(int Transfer_ID, string Transfer_Against, string TP_No, int Brand_Opening_ID, string MfgDate, string Boxes, string BatchNo, decimal Speg_Qty, decimal Speg_Rate
        , decimal Bottle_Qty, decimal Bottle_Rate, int License_ID, int Company_ID, string LoggedInUserID, string Created_By,string Created_Date, string Action , string StrConn)
        {
            try
            {
                string strOutput = string.Empty;
                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_CRUD_CW_CocktailWorld_TransferDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Transfer_ID", Transfer_ID);
                cmd.Parameters.AddWithValue("@Transfer_Against", Transfer_Against);
                cmd.Parameters.AddWithValue("@TP_No", TP_No);
                cmd.Parameters.AddWithValue("@Brand_Opening_ID", Brand_Opening_ID);
                cmd.Parameters.AddWithValue("@MfgDate", MfgDate);
                cmd.Parameters.AddWithValue("@Boxes", Boxes);
                cmd.Parameters.AddWithValue("@BatchNo", BatchNo);
                cmd.Parameters.AddWithValue("@Speg_Qty", Speg_Qty);
                cmd.Parameters.AddWithValue("@Speg_Rate", Speg_Rate);
                cmd.Parameters.AddWithValue("@Bottle_Qty", Bottle_Qty);
                cmd.Parameters.AddWithValue("@Bottle_Rate", Bottle_Rate);
                cmd.Parameters.AddWithValue("@License_ID", License_ID);
                cmd.Parameters.AddWithValue("@Company_ID", Company_ID);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@Created_By", Created_By);
                cmd.Parameters.AddWithValue("@Created_Date", Created_Date);
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

        public DataSet Save_CategorySizeLinkup(int CategoryID, string CategoryDetails, int LicenseID, int CompanyID, string LoggedInUserID, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;

                SqlConnection con = new SqlConnection(StrConn);

                SqlCommand cmd = new SqlCommand("Spr_Save_Category_Size", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Category_ID", CategoryID);
                cmd.Parameters.AddWithValue("@CategoryDetails", CategoryDetails);
                cmd.Parameters.AddWithValue("@License_ID", LicenseID);
                cmd.Parameters.AddWithValue("@Company_ID", CompanyID);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet Save_BrandOpening(int Opening_ID, string CategoryDetails, int BrandID, int CompanyID, string LoggedInUserID,string Operation, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;

                SqlConnection con = new SqlConnection(StrConn);

                SqlCommand cmd = new SqlCommand("Spr_Save_Brand_Opening", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Opening_ID", Opening_ID);
                cmd.Parameters.AddWithValue("@CategoryDetails", CategoryDetails);
                cmd.Parameters.AddWithValue("@Brand_ID", BrandID);
                cmd.Parameters.AddWithValue("@Company_ID", CompanyID);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@Operation", Operation);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet License_CRUD(int LicenseID, string LicenseName, string LicenseNo, string LoggedInUserID, int Company_ID, string Action, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;

                SqlConnection con = new SqlConnection(StrConn);

                SqlCommand cmd = new SqlCommand("Spr_CRUD_CW_CocktailWorld_License", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@LicenseID", LicenseID);
                cmd.Parameters.AddWithValue("@LicenseName", LicenseName);
                cmd.Parameters.AddWithValue("@LicenseNo", LicenseNo);
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



        public DataSet SupplierMaster_CRUD(int Supplier_ID,  string SupplierName, string Code, int pincode, string Address, string Contact,string City ,string Email , string LoggedInUserID, int Company_ID, string Action, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;

                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_CRUD_CW_CocktailWorld_Supplier", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Supplier_ID", Supplier_ID);
                cmd.Parameters.AddWithValue("@Supplier_Name", SupplierName);
                cmd.Parameters.AddWithValue("@Supplier_Code", Code);
                cmd.Parameters.AddWithValue("@Supplier_PINCODE", pincode);
                cmd.Parameters.AddWithValue("@Supplier_Address", Address);
                cmd.Parameters.AddWithValue("@Supplier_Contact", Contact);
                cmd.Parameters.AddWithValue("@Supplier_City", City);
                cmd.Parameters.AddWithValue("@Supplier_Email", Email);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@Company_ID", Company_ID);
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


        public DataSet CocktailMaster_CRUD(int Cocktail_ID,string Cocktail_Name, string Rate, int Company_ID, string LoggedInUserID, string Action, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;

                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_CRUD_CW_CocktailWorld_Cocktail", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Cocktail_ID", Cocktail_ID);
                cmd.Parameters.AddWithValue("@CocktailName", Cocktail_Name);
                cmd.Parameters.AddWithValue("@Rate", Rate);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@Company_ID", Company_ID);
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

        public DataSet CocktailBrandsMaster_CRUD(int Cocktail_Brand_ID, int Cocktail_ID, int Brand_ID, int Pegml, int Size, int Company_ID, string LoggedInUserID, string Action, string StrConn)
        {
            try
            {
                string strOutput = string.Empty;

                SqlConnection con = new SqlConnection(StrConn);
                SqlCommand cmd = new SqlCommand("Spr_CRUD_CW_CocktailWorld_CocktailBrandMaster", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Cocktail_Brand_ID", Cocktail_Brand_ID);
                cmd.Parameters.AddWithValue("@Cocktail_ID", Cocktail_ID);
                cmd.Parameters.AddWithValue("@Brand_ID", Brand_ID);
                cmd.Parameters.AddWithValue("@Pegml", Pegml);
                cmd.Parameters.AddWithValue("@Size", Size);
                cmd.Parameters.AddWithValue("@LoggedInUserID", LoggedInUserID);
                cmd.Parameters.AddWithValue("@Company_ID", Company_ID);
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

        public DataSet Fetch_Test_Dataset_RDLC(string StrConn)
        {
            try
            {
                string strOutput = string.Empty;

                SqlConnection con = new SqlConnection(StrConn);

                SqlCommand cmd = new SqlCommand("Test_RDLC_Dataset", con);
                cmd.CommandType = CommandType.StoredProcedure;
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
