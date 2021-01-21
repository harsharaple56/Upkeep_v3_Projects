Imports System.Data
Imports System.Xml

Public Class ClsQuickExcess
    Inherits ClsCommon

    Public Sub New()
        _FromDate = #1/1/1900#
        _ToDate = #1/1/1900#
    End Sub


#Region "Quick Excise"

    Private _PurchaseDate As DateTime
    Public Property PurchaseDate() As DateTime
        Get
            Return _PurchaseDate
        End Get
        Set(ByVal value As DateTime)
            _PurchaseDate = value
        End Set
    End Property

    Public Function FetchTPNo() As DataTable
        Try
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_QE_fetchPurchase")

            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseId", DbType.Double, DblPubLicenseID)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@Purchasedate", DbType.Date, _PurchaseDate)
            FetchTPNo = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)

        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(DbPubDataBase) = False Then
                DbPubDataBase = Nothing
            End If
            If IsNothing(ObjPriDbCommand) = False Then
                ObjPriDbCommand = Nothing
            End If

        End Try
    End Function

#End Region

#Region "DASHBARD FUNCTIONS"

#Region "Vars"
    Private _BrandOption As Char
    Public Property BrandOption() As Char
        Get
            Return _BrandOption
        End Get
        Set(ByVal value As Char)
            _BrandOption = value
        End Set
    End Property

    Private _TopBrands As Integer
    Public Property TopBrands() As Integer
        Get
            Return _TopBrands
        End Get
        Set(ByVal value As Integer)
            _TopBrands = value
        End Set
    End Property

    Private _FromDate As DateTime
    Public Property FromDate() As DateTime
        Get
            Return _FromDate
        End Get
        Set(ByVal value As DateTime)
            _FromDate = value
        End Set
    End Property

    Private _ToDate As DateTime
    Public Property ToDate() As DateTime
        Get
            Return _ToDate
        End Get
        Set(ByVal value As DateTime)
            _ToDate = value
        End Set
    End Property

    Private _DashboardID As String
    Public Property DashBoardID() As String
        Get
            Return _DashboardID
        End Get
        Set(ByVal value As String)
            _DashboardID = value
        End Set
    End Property

    Private _IsExport As Boolean = False
    Public Property IsExport() As Boolean
        Get
            Return _IsExport
        End Get
        Set(ByVal value As Boolean)
            _IsExport = value
        End Set
    End Property

#End Region

    'FOR DASHBOARD
    Public Function FetchLiqBevSummary() As DataTable
        Try
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_Dash_FetchLiqBevSummary")
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid", DbType.Double, DblPubLicenseID)
            FetchLiqBevSummary = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(DbPubDataBase) = False Then
                DbPubDataBase = Nothing
            End If
            If IsNothing(ObjPriDbCommand) = False Then
                ObjPriDbCommand = Nothing
            End If

        End Try
    End Function

    Public Function FetchLiqBevSummaryCategoryWise() As DataTable
        Try
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_Dash_FetchLiqBevSummaryCategoryWise")
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@categoryid", DbType.Double, DblPubCategoryID)
            FetchLiqBevSummaryCategoryWise = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(DbPubDataBase) = False Then
                DbPubDataBase = Nothing
            End If
            If IsNothing(ObjPriDbCommand) = False Then
                ObjPriDbCommand = Nothing
            End If

        End Try
    End Function

    Public Function FunFetchControlsDataByPeriodCategorywise() As DataTable
        Try
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchControlsDataByPeriodCategorywise")
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ControlHeadID", DbType.Double, DblPubControlHeadID)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@Categoryid", DbType.Double, DblPubCategoryID)
            FunFetchControlsDataByPeriodCategorywise = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(DbPubDataBase) = False Then
                DbPubDataBase = Nothing
            End If
            If IsNothing(ObjPriDbCommand) = False Then
                ObjPriDbCommand = Nothing
            End If

        End Try
    End Function

    Public Function FetchCosting() As DataTable
        Try
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_QC_FetchCosting")
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@fromdate", DbType.Date, _FromDate)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@todate", DbType.Date, _ToDate)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
            FetchCosting = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(DbPubDataBase) = False Then
                DbPubDataBase = Nothing
            End If
            If IsNothing(ObjPriDbCommand) = False Then
                ObjPriDbCommand = Nothing
            End If

        End Try
    End Function

    Public Function FunFetchControlsPeriod() As DataTable
        Try
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_QC_FetchControlsPeriod")
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
            FunFetchControlsPeriod = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(DbPubDataBase) = False Then
                DbPubDataBase = Nothing
            End If
            If IsNothing(ObjPriDbCommand) = False Then
                ObjPriDbCommand = Nothing
            End If

        End Try
    End Function

    Public Function FunFetchControlsDataByPeriod() As DataTable
        Try
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchControlsDataByPeriod")
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ControlHeadID", DbType.Double, DblPubControlHeadID)
            FunFetchControlsDataByPeriod = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(DbPubDataBase) = False Then
                DbPubDataBase = Nothing
            End If
            If IsNothing(ObjPriDbCommand) = False Then
                ObjPriDbCommand = Nothing
            End If

        End Try
    End Function

    Public Function FetchTopBrands() As DataTable
        Try
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_Dash_FetchTopBrands")
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@noofbrands", DbType.Int32, _TopBrands)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@period", DbType.String, _BrandOption)
            FetchTopBrands = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(DbPubDataBase) = False Then
                DbPubDataBase = Nothing
            End If
            If IsNothing(ObjPriDbCommand) = False Then
                ObjPriDbCommand = Nothing
            End If

        End Try
    End Function


    Public Function FetchDashLists() As DataTable
        Try
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_Dash_GetDashlets")
            FetchDashLists = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(DbPubDataBase) = False Then
                DbPubDataBase = Nothing
            End If
            If IsNothing(ObjPriDbCommand) = False Then
                ObjPriDbCommand = Nothing
            End If

        End Try
    End Function

    Public Function FetchUserChartList() As DataTable
        Try
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_Dash_GetUserChartList")
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@userid", DbType.Double, DblPubUserID)
            FetchUserChartList = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(DbPubDataBase) = False Then
                DbPubDataBase = Nothing
            End If
            If IsNothing(ObjPriDbCommand) = False Then
                ObjPriDbCommand = Nothing
            End If

        End Try
    End Function


    Public Sub SaveUserChartList()

        Try
            ObjPriConnection = DbPubDataBase.CreateConnection
            ObjPriConnection.Open()
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_Dash_SaveDashLetsByUser")
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@userid", DbType.Double, DblPubUserID)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@DashboardID", DbType.String, _DashboardID)
            DbPubDataBase.ExecuteNonQuery(ObjPriDbCommand)
            ObjPriConnection.Close()
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(DbPubDataBase) = False Then
                DbPubDataBase = Nothing
            End If

            If IsNothing(ObjPriCommand) = False Then
                ObjPriDbCommand = Nothing
            End If
            If IsNothing(ObjPriConnection) = False Then
                ObjPriConnection = Nothing
            End If

            If IsNothing(ObjPriTrans) = False Then
                ObjPriTrans = Nothing

            End If
        End Try

    End Sub


    Public Function FetchControlsStep1() As DataTable
        Try
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_Dash_QCStep1Report")
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ControlHeadID", DbType.Double, DblPubControlHeadID)
            'DbPubDataBase.AddInParameter(ObjPriDbCommand, "@FromDate", DbType.DateTime, _FromDate)
            'DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ToDate", DbType.DateTime, _ToDate)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@CategoryID", DbType.Double, DblPubCategoryID)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@SubCategoryID", DbType.Double, DblPubSubCategoryID)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@isexport", DbType.Boolean, _IsExport)
            FetchControlsStep1 = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(DbPubDataBase) = False Then
                DbPubDataBase = Nothing
            End If
            If IsNothing(ObjPriDbCommand) = False Then
                ObjPriDbCommand = Nothing
            End If

        End Try
    End Function

    Public Function FetchQuickVariance() As DataTable
        Try
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_Dash_QuickVarianceReport")
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@FromDate", DbType.DateTime, _FromDate)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ToDate", DbType.DateTime, _ToDate)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@CategoryID", DbType.Double, DblPubCategoryID)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@SubCategoryID", DbType.Double, DblPubSubCategoryID)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@isexport", DbType.Boolean, _IsExport)
            FetchQuickVariance = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(DbPubDataBase) = False Then
                DbPubDataBase = Nothing
            End If
            If IsNothing(ObjPriDbCommand) = False Then
                ObjPriDbCommand = Nothing
            End If

        End Try
    End Function

    Public Function FetchPotentialCosting() As DataTable
        Try
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_Dash_PotentialCosting")
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ControlHeadID", DbType.Double, DblPubControlHeadID)
            'DbPubDataBase.AddInParameter(ObjPriDbCommand, "@FromDate", DbType.DateTime, _FromDate)
            'DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ToDate", DbType.DateTime, _ToDate)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@CategoryID", DbType.Double, DblPubCategoryID)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@SubCategoryID", DbType.Double, DblPubSubCategoryID)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@isexport", DbType.Boolean, _IsExport)
            FetchPotentialCosting = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(DbPubDataBase) = False Then
                DbPubDataBase = Nothing
            End If
            If IsNothing(ObjPriDbCommand) = False Then
                ObjPriDbCommand = Nothing
            End If

        End Try
    End Function

    Public Function FetchSaleToPurchaseRatio() As DataTable
        Try
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("spr_Dash_SaleToPurchaseRatioReport")
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ControlHeadID", DbType.Double, DblPubControlHeadID)
            
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@CategoryID", DbType.Double, DblPubCategoryID)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@SubCategoryID", DbType.Double, DblPubSubCategoryID)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@isexport", DbType.Boolean, _IsExport)
            If DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables.Count > 0 Then
                FetchSaleToPurchaseRatio = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Else
                FetchSaleToPurchaseRatio = Nothing
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(DbPubDataBase) = False Then
                DbPubDataBase = Nothing
            End If
            If IsNothing(ObjPriDbCommand) = False Then
                ObjPriDbCommand = Nothing
            End If

        End Try
    End Function

    Public Function FetchSlowMovingBrands() As DataSet
        Try
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchSlowMovingStock")
            ObjPriDbCommand.CommandTimeout = 10000
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseID", DbType.Double, DblPubLicenseID)

            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@FromDate", DbType.DateTime, _FromDate)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ToDate", DbType.DateTime, _ToDate)

            FetchSlowMovingBrands = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand)

        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(DbPubDataBase) = False Then
                DbPubDataBase = Nothing
            End If
            If IsNothing(ObjPriDbCommand) = False Then
                ObjPriDbCommand = Nothing
            End If

        End Try
    End Function

    Public Function FetchMenuEngineering(ByVal Profit As Integer, ByVal Popular As Integer, ByVal CostType As Integer) As DataTable
        Try
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchMenuEngineering")
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@Profit", DbType.Int64, Profit)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@popular", DbType.Int64, Popular)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@CostType", DbType.Int64, CostType)

            If DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables.Count > 0 Then
                FetchMenuEngineering = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            Else
                FetchMenuEngineering = Nothing
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(DbPubDataBase) = False Then
                DbPubDataBase = Nothing
            End If
            If IsNothing(ObjPriDbCommand) = False Then
                ObjPriDbCommand = Nothing
            End If

        End Try
    End Function

    Public Function FetchWhatIfParameters() As DataTable
        Try
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchWhatIfParameters")
           FetchWhatIfParameters = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
            
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(DbPubDataBase) = False Then
                DbPubDataBase = Nothing
            End If
            If IsNothing(ObjPriDbCommand) = False Then
                ObjPriDbCommand = Nothing
            End If

        End Try
    End Function
#End Region

#Region "Quick Variance"

#Region "Vars"

    Private blHideButton As Boolean = False
    Public Property HideButton As Boolean
        Get
            Return blHideButton
        End Get
        Set(ByVal value As Boolean)
            blHideButton = value
        End Set
    End Property



    Private _VarianceID As Long
    Public Property VarianceID() As Long
        Get
            Return _VarianceID
        End Get
        Set(ByVal value As Long)
            _VarianceID = value
        End Set
    End Property

    Private _VarianceDetailsXML As XmlDocument
    Public Property VarDetailsXML() As XmlDocument
        Get
            Return _VarianceDetailsXML
        End Get
        Set(ByVal value As XmlDocument)
            _VarianceDetailsXML = value
        End Set
    End Property

    Private _Month As Integer
    Private _Year As Integer
  

    Public Property Month() As Integer
        Get
            Return _Month
        End Get
        Set(ByVal value As Integer)
            _Month = value
        End Set
    End Property
    Public Property Year() As Integer
        Get
            Return _Year
        End Get
        Set(ByVal value As Integer)
            _Year = value
        End Set
    End Property

    Private _bookbottle As Integer
    Public Property BookBottle() As Integer
        Get
            Return _bookbottle
        End Get
        Set(ByVal value As Integer)
            _bookbottle = value
        End Set
    End Property

    Private _BookSpeg As Integer
    Public Property BookSpeg() As Integer
        Get
            Return _BookSpeg
        End Get
        Set(ByVal value As Integer)
            _BookSpeg = value
        End Set
    End Property

    Private _ActualBottle As Integer
    Public Property ActualBottle() As Integer
        Get
            Return _ActualBottle
        End Get
        Set(ByVal value As Integer)
            _ActualBottle = value
        End Set
    End Property

    Private _ActualSpeg As Integer
    Public Property ActualSpeg() As Integer
        Get
            Return _ActualSpeg
        End Get
        Set(ByVal value As Integer)
            _ActualSpeg = value
        End Set
    End Property

    Private _OutPutType As Char
    Public Property OutPutType() As Char
        Get
            Return _OutPutType
        End Get
        Set(ByVal value As Char)
            _OutPutType = value
        End Set
    End Property


    '[+][14/09/2019][Ajay Prajapati]
    'Private _LicenseID As Integer
    'Public Property LicenseID() As Integer
    '    Get
    '        Return _LicenseID
    '    End Get
    '    Set(ByVal value As Integer)
    '        _LicenseID = value
    '    End Set
    'End Property
    '[-][14/09/2019][Ajay Prajapati]



#End Region

    Public Function FetchBrandQuantity() As DataSet
        Try
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_QV_FetchBrandQuantity")
            ObjPriDbCommand.CommandTimeout = 999999999
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@date", DbType.Date, _PurchaseDate)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseID", DbType.Double, DblPubLicenseID)

            FetchBrandQuantity = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand)
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(DbPubDataBase) = False Then
                DbPubDataBase = Nothing
            End If
            If IsNothing(ObjPriDbCommand) = False Then
                ObjPriDbCommand = Nothing
            End If

        End Try
    End Function

    Public Function FetchVariances() As DataTable
        Try
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_QV_FetchVarians")
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@CategorySizeLinkID", DbType.Double, DblPubCategorySizeLinkID)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@bookbottel", DbType.Double, _bookbottle)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@bookspeg", DbType.Double, _BookSpeg)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@actualbottel", DbType.Double, _ActualBottle)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@actspeg", DbType.Double, _ActualSpeg)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@type", DbType.String, _OutPutType)
            FetchVariances = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(DbPubDataBase) = False Then
                DbPubDataBase = Nothing
            End If
            If IsNothing(ObjPriDbCommand) = False Then
                ObjPriDbCommand = Nothing
            End If

        End Try
    End Function


    Public Function FetchControlsDatewise() As DataSet
        Try
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_Qc_FetchControlsDatewise")
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@month", SqlDbType.Int, _Month)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@year", SqlDbType.Int, _Year)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@fromDate", DbType.Date, _FromDate)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@todate", DbType.Date, _ToDate)
            FetchControlsDatewise = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand)
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(DbPubDataBase) = False Then
                DbPubDataBase = Nothing
            End If
            If IsNothing(ObjPriDbCommand) = False Then
                ObjPriDbCommand = Nothing
            End If

        End Try
    End Function

    Public Function FetchVarianceDatewise() As DataSet
        Try
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("SPR_QV_FETCHVARIANCEDATEWISE")
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@month", SqlDbType.Int, _Month)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@year", SqlDbType.Int, _Year)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@fromDate", DbType.Date, _FromDate)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@todate", DbType.Date, _ToDate)
            '[+][14/09/2019][Ajay Prajapati]
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
            '[-][14/09/2019][Ajay Prajapati]
            FetchVarianceDatewise = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand)
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(DbPubDataBase) = False Then
                DbPubDataBase = Nothing
            End If
            If IsNothing(ObjPriDbCommand) = False Then
                ObjPriDbCommand = Nothing
            End If

        End Try
    End Function

    Public Function FunFetchBevRecon() As DataTable
        Try
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchBevRecon")
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@vardate", DbType.Date, _FromDate)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@licenseid", DbType.Double, DblPubLicenseID)
            FunFetchBevRecon = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
        Catch ex As Exception
            Throw ex
        Finally
            If IsNothing(DbPubDataBase) = False Then
                DbPubDataBase = Nothing
            End If
            If IsNothing(ObjPriDbCommand) = False Then
                ObjPriDbCommand = Nothing
            End If
        End Try
    End Function

    Public Function SaveVariance() As Boolean
        SaveVariance = False
        Try
            ObjPriConnection = DbPubDataBase.CreateConnection
            ObjPriConnection.Open()
            ObjPriTrans = ObjPriConnection.BeginTransaction
            ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_QV_SaveVariance")
            DbPubDataBase.AddInParameter(ObjPriCommand, "@varianceId", DbType.Double, _VarianceID)
            DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
            DbPubDataBase.AddInParameter(ObjPriCommand, "@Vardate", DbType.Date, _PurchaseDate)
            DbPubDataBase.AddInParameter(ObjPriCommand, "@disptype", DbType.String, _OutPutType)
            DbPubDataBase.AddInParameter(ObjPriCommand, "@XmlVariance", SqlDbType.Xml, _VarianceDetailsXML.InnerXml)
            DbPubDataBase.AddInParameter(ObjPriCommand, "@UserName", SqlDbType.VarChar, StrPubOperator)
            DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
            DbPubDataBase.AddOutParameter(ObjPriCommand, "@HideBtnSattalement", SqlDbType.Bit, 1)
            DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
            StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
            blHideButton = Trim(ObjPriCommand.Parameters("@HideBtnSattalement").Value)
            ObjPriTrans.Commit()
            SaveVariance = True
        Catch ex As Exception
            ObjPriTrans.Rollback()
            SaveVariance = False
            Throw ex
        Finally
            If IsNothing(DbPubDataBase) = False Then
                DbPubDataBase = Nothing
            End If

            If IsNothing(ObjPriCommand) = False Then
                ObjPriDbCommand = Nothing
            End If
            If IsNothing(ObjPriConnection) = False Then
                ObjPriConnection = Nothing
            End If

            If IsNothing(ObjPriTrans) = False Then
                ObjPriTrans = Nothing

            End If
        End Try
    End Function

#End Region

    Public Function FunDeleteControls() As Boolean
        FunDeleteControls = False
        Try
            ObjPriConnection = DbPubDataBase.CreateConnection
            ObjPriConnection.Open()
            ObjPriTrans = ObjPriConnection.BeginTransaction
            ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_DeleteControls")
            DbPubDataBase.AddInParameter(ObjPriCommand, "@ControlID", DbType.Double, dbpubControlID)
            DbPubDataBase.AddOutParameter(ObjPriCommand, "@outbit", SqlDbType.Bit, 1)
            DbPubDataBase.AddOutParameter(ObjPriCommand, "@outmsg", SqlDbType.VarChar, 100)
            DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
            StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
            FunDeleteControls = Trim(ObjPriCommand.Parameters("@outbit").Value)
            ObjPriTrans.Commit()
        Catch ex As Exception
            ObjPriTrans.Rollback()
            Throw ex
        Finally
            If IsNothing(DbPubDataBase) = False Then
                DbPubDataBase = Nothing
            End If

            If IsNothing(ObjPriCommand) = False Then
                ObjPriDbCommand = Nothing
            End If
            If IsNothing(ObjPriConnection) = False Then
                ObjPriConnection = Nothing
            End If

            If IsNothing(ObjPriTrans) = False Then
                ObjPriTrans = Nothing

            End If
        End Try
    End Function

    Public Overrides Function FunDelete() As Boolean
        FunDelete = False
        Try
            ObjPriConnection = DbPubDataBase.CreateConnection
            ObjPriConnection.Open()
            ObjPriTrans = ObjPriConnection.BeginTransaction
            ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_DeleteVariance")
            DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
            DbPubDataBase.AddInParameter(ObjPriCommand, "@Vardate", DbType.Date, _PurchaseDate)
            DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
            DbPubDataBase.AddOutParameter(ObjPriCommand, "@outbit", SqlDbType.Bit, 1)
            DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
            StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
            FunDelete = Trim(ObjPriCommand.Parameters("@outbit").Value)
            ObjPriTrans.Commit()
        Catch ex As Exception
            ObjPriTrans.Rollback()
            Throw ex
        Finally
            If IsNothing(DbPubDataBase) = False Then
                DbPubDataBase = Nothing
            End If

            If IsNothing(ObjPriCommand) = False Then
                ObjPriDbCommand = Nothing
            End If
            If IsNothing(ObjPriConnection) = False Then
                ObjPriConnection = Nothing
            End If

            If IsNothing(ObjPriTrans) = False Then
                ObjPriTrans = Nothing

            End If
        End Try
    End Function

    Public Overrides Function FunFetch() As System.Data.DataTable

    End Function

    Public Overrides Function FunSave() As Boolean

    End Function


    Public Function RunCostAdjustment(ByVal DblLoclicenseid As Double) As Boolean
        RunCostAdjustment = False
        Try
            ObjPriConnection = DbPubDataBase.CreateConnection
            ObjPriConnection.Open()
            ObjPriTrans = ObjPriConnection.BeginTransaction
            ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_CostAdjustment")
            ObjPriCommand.CommandTimeout = 99999999
            DbPubDataBase.AddInParameter(ObjPriCommand, "@licenseid", DbType.Double, DblLoclicenseid)
            DbPubDataBase.AddOutParameter(ObjPriCommand, "@outbit", SqlDbType.Bit, 1)
            DbPubDataBase.AddOutParameter(ObjPriCommand, "@outmsg", SqlDbType.VarChar, 100)
            DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
            StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
            RunCostAdjustment = Trim(ObjPriCommand.Parameters("@outbit").Value)
            ObjPriTrans.Commit()
        Catch ex As Exception
            ObjPriTrans.Rollback()
            Throw ex
        Finally
            If IsNothing(DbPubDataBase) = False Then
                DbPubDataBase = Nothing
            End If

            If IsNothing(ObjPriCommand) = False Then
                ObjPriDbCommand = Nothing
            End If
            If IsNothing(ObjPriConnection) = False Then
                ObjPriConnection = Nothing
            End If

            If IsNothing(ObjPriTrans) = False Then
                ObjPriTrans = Nothing

            End If
        End Try
    End Function
End Class
