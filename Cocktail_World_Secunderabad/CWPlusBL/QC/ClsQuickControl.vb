Imports System.Data
Imports System.Xml

Public Class ClsQuickControl
    Inherits ClsCommon

#Region "QuickControl"
#Region "Variable"
    Public StrQcStep2DetailsXml As XmlDocument
    Public StrQcStep1DetailsXml As XmlDocument

    Public dblPubTotalCost, dblPubGrossRevenue, dblpubNetRevenue As Double
    Public intPubTag As Integer
    Public dtToDate, dtFromDate, dtControlDate As Date

#End Region
#Region "Property"
    Public Property Tag() As Integer
        Get
            Return intPubTag
        End Get
        Set(ByVal value As Integer)
            intPubTag = value
        End Set
    End Property

    Public Property TotalCost As Double
        Get
            Return dblPubTotalCost
        End Get
        Set(ByVal value As Double)
            dblPubTotalCost = value
        End Set
    End Property
    Public Property GrossRevenue As Double
        Get
            Return dblPubGrossRevenue
        End Get
        Set(ByVal value As Double)
            dblPubGrossRevenue = value
        End Set
    End Property
    Public Property NetRevenue As Double
        Get
            Return dblpubNetRevenue
        End Get
        Set(ByVal value As Double)
            dblpubNetRevenue = value
        End Set
    End Property
    Public Property ToDate() As Date
        Get
            Return dtToDate
        End Get
        Set(ByVal value As Date)
            dtToDate = value
        End Set
    End Property
    Public Property FromDate() As Date
        Get
            Return dtFromDate
        End Get
        Set(ByVal value As Date)
            dtFromDate = value
        End Set
    End Property
    Public Property QcStep2DetailsXml As XmlDocument
        Get
            Return StrQcStep2DetailsXml
        End Get
        Set(ByVal value As XmlDocument)
            StrQcStep2DetailsXml = value
        End Set
    End Property

    Public Property QcStep1DetailsXml As XmlDocument
        Get
            Return StrQcStep1DetailsXml
        End Get
        Set(ByVal value As XmlDocument)
            StrQcStep1DetailsXml = value
        End Set
    End Property
    Public Property ControlDate() As Date
        Get
            Return dtControlDate
        End Get
        Set(ByVal value As Date)
            dtControlDate = value
        End Set
    End Property
#End Region

    Public Function FetchQuickControls() As DataSet
        Try
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchQcStep1")
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseId", DbType.Double, DblPubLicenseID)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@FromDate", DbType.DateTime, dtFromDate)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ToDate", DbType.DateTime, dtToDate)
            DbPubDataBase.AddOutParameter(ObjPriDbCommand, "@TotalCost", DbType.Double, dblPubTotalCost)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "Tag", DbType.Int32, intPubTag)
            FetchQuickControls = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand)
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
    Public Function FetchQuickControls2() As DataTable
        Try
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchQCStep2")
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@FromDate", DbType.DateTime, dtFromDate)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ToDate", DbType.DateTime, dtToDate)
            FetchQuickControls2 = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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

    Public Function FunFetcFromDateToDate() As DataTable
        Try
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchFromDateToDate")
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ToDate", DbType.DateTime, dtToDate)
            FunFetcFromDateToDate = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand).Tables(0)
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

    Public Function FunFetchContorlForQCStep2() As DataSet
        Try
            ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchControls")
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@Dtc", DbType.DateTime, dtFromDate)
            DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ControlHeadID", DbType.Double, DblPubControlHeadID)

            FunFetchContorlForQCStep2 = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand)
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

    Public Function FunSaveQcStep2() As Boolean
        FunSaveQcStep2 = False
        Try
            ObjPriConnection = DbPubDataBase.CreateConnection
            ObjPriConnection.Open()
            ObjPriTrans = ObjPriConnection.BeginTransaction
            ObjPriCommand = DbPubDataBase.GetStoredProcCommand("Spr_SaveQcStep2")
            DbPubDataBase.AddInParameter(ObjPriCommand, "@ControlHeadID", DbType.Double, DblPubControlHeadID)
            DbPubDataBase.AddInParameter(ObjPriCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
            DbPubDataBase.AddInParameter(ObjPriCommand, "@FromDate", DbType.DateTime, dtFromDate)
            DbPubDataBase.AddInParameter(ObjPriCommand, "@ToDate", DbType.DateTime, dtToDate)
            DbPubDataBase.AddInParameter(ObjPriCommand, "@GrossRevenue", DbType.Double, dblPubGrossRevenue)
            DbPubDataBase.AddInParameter(ObjPriCommand, "@NetRevenue", DbType.Double, dblpubNetRevenue)
            DbPubDataBase.AddInParameter(ObjPriCommand, "@XmlDoc", SqlDbType.Xml, StrQcStep2DetailsXml.InnerXml)
            DbPubDataBase.AddInParameter(ObjPriCommand, "@XmlDocQCSTEP1", SqlDbType.Xml, StrQcStep1DetailsXml.InnerXml)
            DbPubDataBase.AddInParameter(ObjPriCommand, "@ControlDate", DbType.Date, dtControlDate)

            DbPubDataBase.AddInParameter(ObjPriCommand, "@UserName", SqlDbType.VarChar, StrPubOperator)
            DbPubDataBase.AddOutParameter(ObjPriCommand, "@Outbit", SqlDbType.Bit, 1)
            DbPubDataBase.AddOutParameter(ObjPriCommand, "@OutMsg", SqlDbType.VarChar, 100)
            DbPubDataBase.ExecuteNonQuery(ObjPriCommand, ObjPriTrans)
            StrPubErrorMsg = Trim(ObjPriCommand.Parameters("@OutMsg").Value)
            ObjPriTrans.Commit()
            FunSaveQcStep2 = True
        Catch ex As Exception
            ObjPriTrans.Rollback()
            FunSaveQcStep2 = False
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

    ' 
    Public Function FunFectQCSTEP3Excel() As DataSet
        Try
            Try
                ObjPriDbCommand = DbPubDataBase.GetStoredProcCommand("Spr_FetchQCStep3ExcelData")
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@LicenseID", DbType.Double, DblPubLicenseID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ControlHeadID", DbType.Double, DblPubControlHeadID)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@FromDate", DbType.DateTime, dtFromDate)
                DbPubDataBase.AddInParameter(ObjPriDbCommand, "@ToDate", DbType.DateTime, dtToDate)
                FunFectQCSTEP3Excel = DbPubDataBase.ExecuteDataSet(ObjPriDbCommand)
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
        Catch ex As Exception

        End Try
    End Function

#End Region




    Public Overrides Function FunDelete() As Boolean

    End Function

    Public Overrides Function FunFetch() As System.Data.DataTable

    End Function

    Public Overrides Function FunSave() As Boolean

    End Function
End Class
