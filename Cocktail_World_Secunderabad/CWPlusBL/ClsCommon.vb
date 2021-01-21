Imports System.Data
Imports System.Data.Common
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Configuration
Imports System.Web


Public MustInherit Class ClsCommon

#Region "Common DB Variables"
    Protected ObjPriCommand As DbCommand = Nothing
    Protected ObjPriTrans As DbTransaction = Nothing
    Protected ObjPriConnection As DbConnection = Nothing
    Protected ObjPriDbCommand As DbCommand = Nothing
    Protected DbPubDataBase As Database
    Protected BoolPubOutParam As Boolean
    Protected StrPubErrorMsg, StrPubOperator As String
#End Region
#Region "Common Variables"
    Public DblPubCategorySizeLinkID, DblPubCategoryID, DblPubSizeID, DblPubLicenseID, DblPubforLicenseID, dbpubControlID, DblPubUserID, DblPubSupplierID, DblPubCategoryTaxID, DblPubBrandID, DblPubCocktailID, DblPubPurchaseID, DblPubSubCategoryID As Double
    Public DblPubPermitTypeID, DblPubAssignCocktailcodeID, dblPubBrandOpeningId, dblpubAssignBrandCodeiD, dblPubDeptID As Double
    Public DblPubPermitHolderID, DblPubMenuID, DblPubParentMenuID, DblPubUserLicenseID, DblPubLicenseCodeID, DblpUbFreezId, DblPubMethodID, DblPubBillID, DblPubInterfaceFileSetUpID, DblPubTransferHeadID, DblPubTransferDetailID, DblPubConsumptionID, DblPubAutoBillID As Double
    Public DblPubParameterID, DblPubControlHeadID, DblpubCocktailReportID, DblPubScheduleID, DblPubOneDayPermitId, DblPubFinancialYearID, DblPubVoidID, DblPubDiscountID As Double
    Public DblPubEvalLicenseID, DblPubMenuItemID, DblPubEvalDepartmentId, DblDisableID As Double
    Public DblTransDate As String

#End Region

    Public Sub New()
        DbPubDataBase = DatabaseFactory.CreateDatabase("StrSqlConn")
    End Sub

#Region "Common Property"

    ' Added by Samvedna on [22-01-2020]

    Public Property DisableID() As Double
        Get
            Return DblDisableID
        End Get
        Set(ByVal value As Double)
            DblDisableID = value
        End Set
    End Property

    Public Property EvalDepartmentId() As Double
        Get
            Return DblPubEvalDepartmentId
        End Get
        Set(ByVal value As Double)
            DblPubEvalDepartmentId = value
        End Set
    End Property

    Public Property MenuItemID() As Double
        Get
            Return DblPubMenuItemID
        End Get
        Set(ByVal value As Double)
            DblPubMenuItemID = value
        End Set
    End Property
    Public Property EvalLicenseID() As Double
        Get
            Return DblPubEvalLicenseID
        End Get
        Set(ByVal value As Double)
            DblPubEvalLicenseID = value
        End Set
    End Property
    Public Property DiscountID() As Double
        Get
            Return DblPubDiscountID
        End Get
        Set(ByVal value As Double)
            DblPubDiscountID = value
        End Set
    End Property
    Public Property VoidID() As Double
        Get
            Return DblPubVoidID
        End Get
        Set(ByVal value As Double)
            DblPubVoidID = value
        End Set
    End Property

    Public Property FinancialYearID() As Double
        Get
            Return DblPubFinancialYearID
        End Get
        Set(ByVal value As Double)
            DblPubFinancialYearID = value
        End Set
    End Property

    Public Property OneDayPermitId() As Double
        Get
            Return DblPubOneDayPermitId
        End Get
        Set(ByVal value As Double)
            DblPubOneDayPermitId = value
        End Set
    End Property

    Public Property MethodID() As Double
        Get
            Return DblPubMethodID
        End Get
        Set(ByVal value As Double)
            DblPubMethodID = value
        End Set
    End Property

    Public Property ControlID() As Double
        Get
            Return dbpubControlID
        End Get
        Set(ByVal value As Double)
            dbpubControlID = value
        End Set
    End Property

    Public Property ScheduleID() As Double
        Get
            Return DblPubScheduleID
        End Get
        Set(ByVal value As Double)
            DblPubScheduleID = value
        End Set
    End Property

    Public Property DeptId() As Double
        Get
            Return dblPubDeptID
        End Get
        Set(ByVal value As Double)
            dblPubDeptID = value
        End Set
    End Property

    Public Property CocktailReportID() As Double
        Get
            Return DblpubCocktailReportID
        End Get
        Set(ByVal value As Double)
            DblpubCocktailReportID = value
        End Set
    End Property


    Public Property ControlHeadID() As Double
        Get
            Return DblPubControlHeadID
        End Get
        Set(ByVal value As Double)
            DblPubControlHeadID = value
        End Set
    End Property
    Public Property SubCategoryID() As Double
        Get
            Return DblPubSubCategoryID
        End Get
        Set(ByVal value As Double)
            DblPubSubCategoryID = value
        End Set
    End Property

    Public Property AssignBrandCodeID() As Double
        Get
            Return dblpubAssignBrandCodeiD
        End Get
        Set(ByVal value As Double)
            dblpubAssignBrandCodeiD = value
        End Set
    End Property
    Public Property ConsumptionID() As Double
        Get
            Return DblPubConsumptionID
        End Get
        Set(ByVal value As Double)
            DblPubConsumptionID = value
        End Set
    End Property

    Public Property TransferHeadID() As Double
        Get
            Return DblPubTransferHeadID
        End Get
        Set(ByVal value As Double)
            DblPubTransferHeadID = value
        End Set
    End Property
    Public Property TransferDetailID() As Double
        Get
            Return DblPubTransferDetailID
        End Get
        Set(ByVal value As Double)
            DblPubTransferDetailID = value
        End Set
    End Property

    Public Property InterfaceFileSetUpID() As Double
        Get
            Return DblPubInterfaceFileSetUpID
        End Get
        Set(ByVal value As Double)
            DblPubInterfaceFileSetUpID = value
        End Set
    End Property


    Public Property BillID() As Double
        Get
            Return DblPubBillID
        End Get
        Set(ByVal value As Double)
            DblPubBillID = value
        End Set
    End Property

    Public Property FreezID As Double
        Get
            Return DblpUbFreezId
        End Get
        Set(ByVal value As Double)
            DblpUbFreezId = value
        End Set
    End Property
    Public Property LicenseCodeID As Double
        Get
            Return DblPubLicenseCodeID
        End Get
        Set(ByVal value As Double)
            DblPubLicenseCodeID = value
        End Set
    End Property


    Public Property UserLicenseID As Double
        Get
            Return DblPubUserLicenseID
        End Get
        Set(ByVal value As Double)
            DblPubUserLicenseID = value
        End Set
    End Property

    Public Property PurchaseID() As Double
        Get
            Return DblPubPurchaseID
        End Get
        Set(ByVal value As Double)
            DblPubPurchaseID = value
        End Set
    End Property
    Public Property BrandopeningID() As Double
        Get
            Return dblPubBrandOpeningId
        End Get
        Set(ByVal value As Double)
            dblPubBrandOpeningId = value
        End Set
    End Property
    Public Property AssigncocktailcodeId() As Double
        Get
            Return DblPubAssignCocktailcodeID
        End Get
        Set(ByVal value As Double)
            DblPubAssignCocktailcodeID = value
        End Set
    End Property
    Public Property ParentMenuID() As Double
        Get
            Return DblPubParentMenuID
        End Get
        Set(ByVal value As Double)
            DblPubParentMenuID = value
        End Set
    End Property

    Public Property MenuID() As Double
        Get
            Return DblPubMenuID
        End Get
        Set(ByVal value As Double)
            DblPubMenuID = value
        End Set
    End Property


    Public Property CocktailId() As Double
        Get
            Return DblPubCocktailID
        End Get
        Set(ByVal value As Double)
            DblPubCocktailID = value
        End Set
    End Property
    Public Property BrandID() As Double
        Get
            Return DblPubBrandID
        End Get
        Set(ByVal value As Double)
            DblPubBrandID = value
        End Set
    End Property

    Public Property ErrorMsg() As String
        Get
            Return StrPubErrorMsg
        End Get
        Set(ByVal value As String)
            StrPubErrorMsg = value
        End Set
    End Property

    Public Property UserName() As String
        Get
            Return StrPubOperator
        End Get
        Set(ByVal value As String)
            StrPubOperator = value
        End Set
    End Property

    Public Property CategoryTaxID() As Double
        Get
            Return DblPubCategoryTaxID
        End Get
        Set(ByVal value As Double)
            DblPubCategoryTaxID = value
        End Set
    End Property
    Public Property SupplierID() As Double
        Get
            Return DblPubSupplierID
        End Get
        Set(ByVal value As Double)
            DblPubSupplierID = value
        End Set
    End Property

    'Added by Samvedna on [23-01-20]
    Public Property TransDate() As String
        Get
            Return DblTransDate
        End Get
        Set(ByVal value As String)
            DblTransDate = value
        End Set
    End Property

    Public Property LicenseID() As Double
        Get
            Return DblPubLicenseID
        End Get
        Set(ByVal value As Double)
            DblPubLicenseID = value
        End Set
    End Property

    Public Property forLicenseID() As Double
        Get
            Return DblPubforLicenseID
        End Get
        Set(ByVal value As Double)
            DblPubforLicenseID = value
        End Set
    End Property

    Public Property SizeID() As Double
        Get
            Return DblPubSizeID
        End Get
        Set(ByVal value As Double)
            DblPubSizeID = value
        End Set
    End Property

    Public Property CategoryID() As Double
        Get
            Return DblPubCategoryID
        End Get
        Set(ByVal value As Double)
            DblPubCategoryID = value
        End Set
    End Property

    Public Property CategorySizeLinkID() As Double
        Get
            Return DblPubCategorySizeLinkID
        End Get
        Set(ByVal value As Double)
            DblPubCategorySizeLinkID = value
        End Set
    End Property

    Public Property UserID() As Double
        Get
            Return DblPubUserID
        End Get
        Set(ByVal value As Double)
            DblPubUserID = value
        End Set
    End Property

    Public Property PermitTypeID As Double
        Get
            Return DblPubPermitTypeID
        End Get
        Set(ByVal value As Double)
            DblPubPermitTypeID = value
        End Set
    End Property

    Public Property PermitHolderID As Double
        Get
            Return DblPubPermitHolderID
        End Get
        Set(ByVal value As Double)
            DblPubPermitHolderID = value
        End Set
    End Property


    Public Property ParaMeterID As Double
        Get
            Return DblPubParameterID

        End Get
        Set(ByVal value As Double)
            DblPubParameterID = value
        End Set
    End Property

#End Region
    ''' <summary>
    ''' This function is used to fetch data by Id or all data
    ''' </summary>
    ''' <returns>Datatable</returns>
    Public MustOverride Function FunFetch() As DataTable

    ''' <summary>
    ''' This function is used Save data
    ''' </summary>
    ''' <returns>True/False</returns>
    Public MustOverride Function FunSave() As Boolean

    ''' <summary>
    ''' This function is used to delete record
    ''' </summary>
    ''' <returns>True/False</returns>
    Public MustOverride Function FunDelete() As Boolean



End Class
